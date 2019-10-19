using CaiMomoClient;
using HuaDan.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Web.Script.Serialization;

namespace HuaDan
{
	public class HuaDanClass
	{
		public static Dictionary<string, int> OrderSendCount = new Dictionary<string, int>();

		public static void InitPrinter(string printerid)
		{
			DataTable table = new DataTable();

			using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["dbconn"]))
			{
				conn.Open();
				SqlCommand cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT * FROM BasePrinter WHERE UID='" + printerid + "'";
				SqlDataAdapter adapter = new SqlDataAdapter(cmd);
				adapter.Fill(table);
			}

			if (table.Rows.Count == 0)
				return;

			NameValueCollection values = new NameValueCollection();
			DataRow row = table.Rows[0];
			foreach (DataColumn jp in table.Columns)
			{
				values.Add(jp.ColumnName, row[jp.ColumnName] == null ? "" : row[jp.ColumnName].ToString());
			}

			Printer.LocalPrinter = PrinterFactory.GetPrinter((int)row["PrinterType"]);
			Printer.LocalPrinter.initParameter(values);
			Printer.LocalPrinter.paperType = (E_PaperType)((int)row["PaperType"]);
			Printer.LocalPrinter.printerName = row["Name"] == null ? "" : row["Name"].ToString();
		}

		public static void PrintDishes(List<string> uids,List<OrderAllZTDishModel> paramDishPartList)
		{
			string printerid = ConfigurationManager.AppSettings["printer"];
			if (string.IsNullOrEmpty(printerid))
				return;

			lock (Printer.LockObject)
			{
				if (Printer.LocalPrinter == null)  //初始化打印机
				{
					InitPrinter(printerid);
				}
			}

			//划单的所有可能性：
			//1、单独的菜品非套餐【orderzhuotaidish】or【hisorderzhuotaidish】。
			//2、仅有套餐名字，没有套餐明细【快餐版】。
			//3、套餐壳子与套餐明细均存在。
			//4、仅套餐明细，无壳子名称【仅划单套餐明细的某条或多条菜品，但不是全部】。

			DataTable Dishes = GetOrders(uids);//获取OrderZhuoTaiDish或HisOrderZhuoTaiDish表数据
			DataTable DishesPackage = GetOrdersPackage(uids);//获取OrderPackageDishDetail或HisOrderPackageDishDetail表数据

			//筛选套餐和套餐明细均存在的数据
			var query = from dishes in Dishes.AsEnumerable()
						join dishesPackage in DishesPackage.AsEnumerable() on dishes.Field<string>("UID") equals dishesPackage.Field<string>("OrderZhuoTaiDishID")
						select dishesPackage;

			var sourceTC = query.ToArray();

			List<string> dishUIDList = new List<string>();//用于存放套餐和套餐明细均存在【orderzhuotaidish】【hisorderzhuotaidish】的主键UID
			string condition = string.Empty;              //单独划单套餐菜品明细,不包含套餐壳子【OrderPackageDishDetail】or【HisOrderPackageDishDetail】表数据
			string conditionFPackageTableData = string.Empty; //单独划单【orderzhuotaidish】or【hisorderzhuotaidish】表数据
			string conditionData = string.Empty;          //套餐和套餐明细均有的数据
			foreach (DataRow row in sourceTC)
			{
				if (string.IsNullOrEmpty(condition))
					condition += "OrderZhuoTaiDishID<>'" + row["OrderZhuoTaiDishID"].ToString() + "'";
				else
					condition += " and OrderZhuoTaiDishID<>'" + row["OrderZhuoTaiDishID"].ToString() + "'";

				if (!dishUIDList.Contains(row["OrderZhuoTaiDishID"].ToString()))
				{
					dishUIDList.Add(row["OrderZhuoTaiDishID"].ToString());

					if (string.IsNullOrEmpty(conditionFPackageTableData))
						conditionFPackageTableData += "UID<>'" + row["OrderZhuoTaiDishID"].ToString() + "'";
					else
						conditionFPackageTableData += " and UID<>'" + row["OrderZhuoTaiDishID"].ToString() + "'";

					if (string.IsNullOrEmpty(conditionData))
						conditionData += "OrderZhuoTaiDishID='" + row["OrderZhuoTaiDishID"].ToString() + "'";
					else
						conditionData += " and OrderZhuoTaiDishID='" + row["OrderZhuoTaiDishID"].ToString() + "'";
				}
			}

			//单独划单【orderzhuotaidish】or【hisorderzhuotaidish】表数据
			var dishSingleSource = Dishes.Select(conditionFPackageTableData);
			foreach (DataRow row in dishSingleSource)
			{
				decimal dishNum = paramDishPartList.Where(p => p.UID.Equals(row["UID"].ToString())).Sum(p => p.DishNum);
				string danju = DanJu.GenerateZhiZuoDan(row,dishNum, Printer.LocalPrinter.paperType, Printer.LocalPrinter.printerName);
				Printer.print(danju);
			}

			//单独划单套餐菜品明细,不包含套餐壳子【OrderPackageDishDetail】or【HisOrderPackageDishDetail】表数据
			var dishPackageSingleSource = DishesPackage.Select(condition);
			foreach (DataRow row in dishPackageSingleSource)
			{
				decimal dishNum = paramDishPartList.Where(p => p.UID.Equals(row["UID"].ToString())).Sum(p => p.DishNum);
				string danju = DanJu.GenerateZhiZuoDan(row, dishNum,Printer.LocalPrinter.paperType, Printer.LocalPrinter.printerName);
				Printer.print(danju);
			}

			//套餐和套餐明细均有的数据
			if (!string.IsNullOrEmpty(conditionData))
			{
				var dishAllSource = DishesPackage.Select(conditionData);
				foreach (DataRow row in dishAllSource)
				{
					string danju = DanJu.GenerateZhiZuoDan(row,0, Printer.LocalPrinter.paperType, Printer.LocalPrinter.printerName);
					Printer.print(danju);
				}
			}

		}

		public static DataTable GetOrders(List<string> uids)
		{
			string lstUids = "'" + string.Join("','", uids) + "'";
			string strSql = string.Empty;
			string qiantaiMode = ConfigurationManager.AppSettings["qiantaimode"];
			strSql = " SELECT OrderZhuoTaiDish.UID, OrderZhuoTaiDish.StoreID, OrderZhuoTaiDish.OrderID, OrderZhuoTaiDish.OrderZhuoTaiID, OrderZhuoTaiDish.DishID, "
				   + " OrderZhuoTaiDish.DishName,OrderZhuoTaiDish.DishTypeID,OrderZhuoTaiDish.UnitName,OrderZhuoTaiDish.DishNum, OrderZhuoTaiDish.DishStatusID, "
				   + " OrderZhuoTaiDish.ZuoFaNames,OrderZhuoTaiDish.KouWeiNames,OrderInfo.TaiKaHao, OrderZhuoTai.ZhuoTaiName,OrderInfo.TotalPeopleNum,"
				   + " OrderZhuoTaiDish.SongDanUserName,OrderZhuoTaiDish.Memo6,OrderZhuoTaiDish.AddTime,OrderZhuoTaiDish.IsHuaCai,OrderZhuoTaiDish.HuaCaiNum,"
				   + " OrderZhuoTaiDish.DishStatusDesc,OrderZhuoTaiDish.DishTZS,OrderZhuoTaiDish.IsPackage,OrderZhuoTaiDish.DishZengSongNum,OrderZhuoTaiDish.DishPaidMoney,'否' as IsPackageDetail "
				   + " FROM OrderZhuoTaiDish INNER JOIN OrderInfo ON OrderZhuoTaiDish.OrderID=OrderInfo.UID "
				   + " LEFT JOIN OrderZhuoTai ON OrderZhuoTaiDish.OrderZhuoTaiID=OrderZhuoTai.UID "
				   + " WHERE OrderZhuoTaiDish.UID IN(" + lstUids + ")"
				   + "  UNION "
				   + " SELECT HisOrderZhuoTaiDish.UID, HisOrderZhuoTaiDish.StoreID, HisOrderZhuoTaiDish.OrderID, HisOrderZhuoTaiDish.OrderZhuoTaiID, HisOrderZhuoTaiDish.DishID, "
				   + " HisOrderZhuoTaiDish.DishName,HisOrderZhuoTaiDish.DishTypeID,HisOrderZhuoTaiDish.UnitName,HisOrderZhuoTaiDish.DishNum, HisOrderZhuoTaiDish.DishStatusID, "
				   + " HisOrderZhuoTaiDish.ZuoFaNames,HisOrderZhuoTaiDish.KouWeiNames,HisOrderInfo.TaiKaHao, HisOrderZhuoTai.ZhuoTaiName,HisOrderInfo.TotalPeopleNum,"
				   + " HisOrderZhuoTaiDish.SongDanUserName,HisOrderZhuoTaiDish.Memo6,HisOrderZhuoTaiDish.AddTime,HisOrderZhuoTaiDish.IsHuaCai,HisOrderZhuoTaiDish.HuaCaiNum,"
				   + " HisOrderZhuoTaiDish.DishStatusDesc,HisOrderZhuoTaiDish.DishTZS,HisOrderZhuoTaiDish.IsPackage,HisOrderZhuoTaiDish.DishZengSongNum,HisOrderZhuoTaiDish.DishPaidMoney,'否' as IsPackageDetail "
				   + " FROM HisOrderZhuoTaiDish INNER JOIN HisOrderInfo ON HisOrderZhuoTaiDish.OrderID=HisOrderInfo.UID "
				   + " LEFT JOIN HisOrderZhuoTai ON HisOrderZhuoTaiDish.OrderZhuoTaiID=HisOrderZhuoTai.UID "
				   + " WHERE HisOrderZhuoTaiDish.UID IN(" + lstUids + ")";


			string strConn = ConfigurationManager.AppSettings["dbconn"];

			DataTable orderDishs = new DataTable();
			using (SqlConnection conn = new SqlConnection(strConn))
			{
				SqlCommand cmd = conn.CreateCommand();
				cmd.CommandText = strSql;
				SqlDataAdapter adapter = new SqlDataAdapter(cmd);
				conn.Open();
				adapter.Fill(orderDishs);
				conn.Close();
			}
			return orderDishs;
		}

		public static DataTable GetOrdersPackage(List<string> uids)
		{
			string lstUids = "'" + string.Join("','", uids) + "'";
			string strSql = string.Empty;
			string qiantaiMode = ConfigurationManager.AppSettings["qiantaimode"];
			strSql = " SELECT OrderPackageDishDetail.UID, OrderPackageDishDetail.StoreID, OrderPackageDishDetail.OrderID, OrderPackageDishDetail.OrderZhuoTaiID, OrderPackageDishDetail.DishID, "
					 + " OrderPackageDishDetail.DishName,OrderPackageDishDetail.DishTypeID,OrderPackageDishDetail.UnitName,OrderPackageDishDetail.DishNum, OrderPackageDishDetail.DishStatusID, "
					 + " OrderPackageDishDetail.ZuoFaNames,OrderPackageDishDetail.KouWeiNames,OrderInfo.TaiKaHao, OrderZhuoTai.ZhuoTaiName,OrderInfo.TotalPeopleNum,"
					 + " OrderPackageDishDetail.SongDanUserName,OrderPackageDishDetail.Memo6,OrderPackageDishDetail.AddTime,OrderPackageDishDetail.HuaCaiNum,"
					 + " OrderPackageDishDetail.DishStatusDesc,OrderPackageDishDetail.DishTZS,OrderPackageDishDetail.OrderZhuoTaiDishID,OrderPackageDishDetail.DishZengSongNum,OrderPackageDishDetail.DishPaidMoney, "
					 + " OrderZhuoTaiDish.DishName as ZTDishName,OrderZhuoTaiDish.DishZengSongNum as ZTDishZengSongNum,OrderZhuoTaiDish.DishNum as ZTDishNum,OrderZhuoTaiDish.UnitName as ZTUnitName,'是' as IsPackageDetail "
					 + " FROM OrderPackageDishDetail INNER JOIN OrderInfo ON OrderPackageDishDetail.OrderID=OrderInfo.UID "
					 + " INNER JOIN OrderZhuoTaiDish on OrderZhuoTaiDish.UID=OrderPackageDishDetail.OrderZhuoTaiDishID "
					 + " LEFT JOIN OrderZhuoTai ON OrderZhuoTaiDish.OrderZhuoTaiID=OrderZhuoTai.UID "
					 + " WHERE OrderPackageDishDetail.UID IN(" + lstUids + ") "
					 + "  UNION "
					 + " SELECT HisOrderPackageDishDetail.UID, HisOrderPackageDishDetail.StoreID, HisOrderPackageDishDetail.OrderID, HisOrderPackageDishDetail.OrderZhuoTaiID, HisOrderPackageDishDetail.DishID, "
					 + " HisOrderPackageDishDetail.DishName,HisOrderPackageDishDetail.DishTypeID,HisOrderPackageDishDetail.UnitName,HisOrderPackageDishDetail.DishNum, HisOrderPackageDishDetail.DishStatusID, "
					 + " HisOrderPackageDishDetail.ZuoFaNames,HisOrderPackageDishDetail.KouWeiNames,HisOrderInfo.TaiKaHao, HisOrderZhuoTai.ZhuoTaiName,HisOrderInfo.TotalPeopleNum,"
					 + " HisOrderPackageDishDetail.SongDanUserName,HisOrderPackageDishDetail.Memo6,HisOrderPackageDishDetail.AddTime,HisOrderPackageDishDetail.HuaCaiNum,"
					 + " HisOrderPackageDishDetail.DishStatusDesc,HisOrderPackageDishDetail.DishTZS,HisOrderPackageDishDetail.OrderZhuoTaiDishID,HisOrderPackageDishDetail.DishZengSongNum,HisOrderPackageDishDetail.DishPaidMoney, "
					 + " HisOrderZhuoTaiDish.DishName as ZTDishName,HisOrderZhuoTaiDish.DishZengSongNum as ZTDishZengSongNum,HisOrderZhuoTaiDish.DishNum as ZTDishNum,HisOrderZhuoTaiDish.UnitName as ZTUnitName,'是' as IsPackageDetail "
					 + " FROM HisOrderPackageDishDetail INNER JOIN HisOrderInfo ON HisOrderPackageDishDetail.OrderID=HisOrderInfo.UID "
					 + " INNER JOIN HisOrderZhuoTaiDish on HisOrderZhuoTaiDish.UID=HisOrderPackageDishDetail.OrderZhuoTaiDishID "
					 + " LEFT JOIN HisOrderZhuoTai ON HisOrderZhuoTaiDish.OrderZhuoTaiID=HisOrderZhuoTai.UID "
					 + " WHERE HisOrderPackageDishDetail.UID IN(" + lstUids + ")";
			string strConn = ConfigurationManager.AppSettings["dbconn"];

			DataTable orderDishs = new DataTable();
			using (SqlConnection conn = new SqlConnection(strConn))
			{
				SqlCommand cmd = conn.CreateCommand();
				cmd.CommandText = strSql;
				SqlDataAdapter adapter = new SqlDataAdapter(cmd);
				conn.Open();
				adapter.Fill(orderDishs);
				conn.Close();
			}
			return orderDishs;
		}

		public static void CallWeiXin(List<string> uids)
		{
			DataTable orderDishs = null;

			try { orderDishs = GetOrders(uids); }
			catch
			{
				try { Thread.Sleep(500); orderDishs = GetOrders(uids); }
				catch
				{
					try { Thread.Sleep(500); orderDishs = GetOrders(uids); }
					catch { return; }
				}
			}

			try { SendNotify(orderDishs); }
			catch
			{
				try { Thread.Sleep(500); SendNotify(orderDishs); }
				catch
				{
					try { Thread.Sleep(500); SendNotify(orderDishs); }
					catch { }
				}
			}
		}

		public static void SendNotify(DataTable orderDishs)
		{
			try
			{
				string title = "取餐通知";
				string keyword1 = "您的订单已准备好，请至取餐台取餐!";
				if (!object.Equals(orderDishs, null) && orderDishs.Rows.Count > 0)
				{
					if (!object.Equals(orderDishs.Rows[0]["ZhuoTaiName"], null))
						keyword1 += "\\n取餐号:" + orderDishs.Rows[0]["ZhuoTaiName"].ToString();
				}

				//string title = "您的餐食已备好，请前来取餐";
				//string keyword1 = string.Empty;
				//if (!object.Equals(orderDishs, null) && orderDishs.Rows.Count > 0)
				//{
				//	if (!object.Equals(orderDishs.Rows[0]["ZhuoTaiName"], null))
				//		keyword1 = orderDishs.Rows[0]["ZhuoTaiName"].ToString();
				//}
				//string keyword2 = Common.GetStoreName();

				string serverurl = ConfigurationManager.AppSettings["serverurl"];
				serverurl = serverurl + "/WeiXinWeb/AjaxHandler.ashx?methodName=SendForZiTi";
				foreach (DataRow row in orderDishs.Rows)
				{
					string orderid = row["OrderID"].ToString();
					lock (OrderSendCount)
					{
						if (OrderSendCount.ContainsKey(orderid))
						{
							if (OrderSendCount[orderid] > 1)
								return;
							OrderSendCount[orderid] = OrderSendCount[orderid] + 1;
						}
						else
						{
							OrderSendCount[orderid] = 1;
						}
					}


					var order = new { OrderID = orderid, OrderIDEnc = Com.Caimomo.Common.RSAEncrypt.EncryptString(row["OrderID"].ToString()), StoreID = row["StoreID"], Title = title, Keyword1 = keyword1, Remark = "" };
					//var order = new { OrderID = orderid, OrderIDEnc = Com.Caimomo.Common.RSAEncrypt.EncryptString(row["OrderID"].ToString()), StoreID = row["StoreID"], Title = title, Keyword1 = keyword1, Keyword2 = keyword2, Remark = "" };

					JavaScriptSerializer jserizor = new JavaScriptSerializer();
					string strOrder = jserizor.Serialize(order);

					WebRequest request = HttpWebRequest.Create(serverurl);
					request.Method = "POST";
					Stream reqStream = request.GetRequestStream();
					StreamWriter writer = new StreamWriter(reqStream);
					writer.Write(strOrder);
					writer.Close();
					reqStream.Close();

					WebResponse response = request.GetResponse();
					Stream stream = response.GetResponseStream();
					StreamReader reader = new StreamReader(stream);
					string result = reader.ReadToEnd();
					reader.Close();
				}

			}
			catch (Exception ex)
			{

			}
		}

		public static void SendNotify(List<OrderAllZTDishModel> paramDishPartList)
		{
			try
			{
				string title= "取餐通知";
				string keyword1 = "您的订单已准备好，请至取餐台取餐!";

				//string title = "您的餐食已备好，请前来取餐";
				//string keyword1 = "";
				//string keyword2 = Common.GetStoreName();

				string serverurl = ConfigurationManager.AppSettings["serverurl"];
				serverurl = serverurl + "/WeiXinWeb/AjaxHandler.ashx?methodName=SendForZiTi";
				for (int i = 0; i < paramDishPartList.Count;i++ )
				{
					OrderAllZTDishModel obj = paramDishPartList[i];

					if (!object.Equals(obj.ZhuoTaiName, null) && !string.IsNullOrEmpty(obj.ZhuoTaiName))
						keyword1 += "\\n取餐号:" + obj.ZhuoTaiName;

					//if (!object.Equals(obj.ZhuoTaiName, null) && !string.IsNullOrEmpty(obj.ZhuoTaiName))
					//	keyword1 = obj.ZhuoTaiName;

					string orderid = obj.OrderID;
					lock (OrderSendCount)
					{
						if (OrderSendCount.ContainsKey(orderid))
						{
							if (OrderSendCount[orderid] > 1)
								return;
							OrderSendCount[orderid] = OrderSendCount[orderid] + 1;
						}
						else
						{
							OrderSendCount[orderid] = 1;
						}
					}

					var order = new { OrderID = orderid, OrderIDEnc = Com.Caimomo.Common.RSAEncrypt.EncryptString(obj.OrderID), StoreID = Tools.CurrentUser.StoreID, Title = title, Keyword1 = keyword1, Remark = "" };
					//var order = new { OrderID = orderid, OrderIDEnc = Com.Caimomo.Common.RSAEncrypt.EncryptString(obj.OrderID), StoreID = Tools.CurrentUser.StoreID, Title = title, Keyword1 = keyword1, Keyword2 = keyword2, Remark = "" };


					JavaScriptSerializer jserizor = new JavaScriptSerializer();
					string strOrder = jserizor.Serialize(order);

					WebRequest request = HttpWebRequest.Create(serverurl);
					request.Method = "POST";
					Stream reqStream = request.GetRequestStream();
					StreamWriter writer = new StreamWriter(reqStream);
					writer.Write(strOrder);
					writer.Close();
					reqStream.Close();

					WebResponse response = request.GetResponse();
					Stream stream = response.GetResponseStream();
					StreamReader reader = new StreamReader(stream);
					string result = reader.ReadToEnd();
					reader.Close();
				}

			}
			catch (Exception ex)
			{

			}
		}
	}
}
