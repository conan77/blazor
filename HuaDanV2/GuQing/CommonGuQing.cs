using HuaDan.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace HuaDan
{
	public class CommonGuQing
	{
		/// <summary>
		/// 选择菜品触发【非单项模式】--台卡|桌台模式
		/// 目的：实时改变沽清状态
		/// </summary>
		/// <param name="listBoxes"></param>
		/// <returns></returns>
		public static List<string> ChangeBtnGuQingName(ListBox[] listBoxes)
		{
			List<string> list = new List<string>();
			List<ModelTmp> modelTmpList = new List<ModelTmp>();
			ListBoxItem onSelectedItem = null;
			foreach (ListBox listBox in listBoxes)
			{
				foreach (object obj in listBox.SelectedItems)
				{
					onSelectedItem = obj as ListBoxItem;
					ModelTmp tmp = new ModelTmp();
					tmp.UID = onSelectedItem.UID;
					tmp.IsTaoCanDetail = onSelectedItem.IsTaoCanDetail;
					tmp.IsPackage = onSelectedItem.IsPackage;
					tmp.DishName = onSelectedItem.DishName;
					tmp.DishID = onSelectedItem.DishID;
					modelTmpList.Add(tmp);
				}
			}

			if (modelTmpList.Count <= 0 || modelTmpList.Count > 1)
				return list;

			if (modelTmpList.Count == 1)
			{
				//是否是套餐壳子
				if (string.Equals(modelTmpList[0].IsTaoCanDetail, "否") && modelTmpList[0].IsPackage)
					return list;

				string sqlOrderGuQing = "select * from OrderGuQing WITH(NOLOCK) WHERE GQStartTime <= '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' AND GQEndTime >= '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' AND DishID='" + modelTmpList[0].DishID + "' ORDER By GQEndTime desc ";
				var dtOrderGuQing = DBHelper.ExeSqlForDataTable(sqlOrderGuQing);
				if (dtOrderGuQing.Rows.Count > 0)
				{
					list.Add("取消沽清");
					list.Add(modelTmpList[0].DishID);
					list.Add(modelTmpList[0].DishName);
				}
				else
				{
					list.Add("沽清");
					list.Add(modelTmpList[0].DishID);
					list.Add(modelTmpList[0].DishName);
				}
			}

			return list;
		}

		/// <summary>
		/// 沽清操作
		/// </summary>
		/// <param name="gqName"></param>
		/// <param name="dishName"></param>
		/// <param name="dishID"></param>
		/// <returns></returns>
		public static bool GuQingOpreate(string gqName, string dishName, string dishID, string gqModel, decimal dishNumber)
		{
			try
			{
				DateTimeModel dtModel = new DateTimeModel();
				if (string.IsNullOrEmpty(gqModel))
					gqModel = Common.getSystemConfig("GuQingDefaultMode", "1");//1:按餐别 2:按天
				if ("1".Equals(gqModel))
				{
					dtModel = Common.GetCurrCanBie();
				}
				else if ("2".Equals(gqModel))
				{
					dtModel = Common.GetCurrDayCanBie();
				}
				else
				{
					dtModel.StartTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
					dtModel.EndTime = "2199-01-01 00:00:00";
					dtModel.CanBieUID = "";
				}

				if (string.IsNullOrEmpty(dtModel.StartTime) || string.IsNullOrEmpty(dtModel.EndTime))
					return false;

				string sqlOrderGuQing = "select * from OrderGuQing WHERE GQStartTime <= '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' AND GQEndTime >= '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' AND DishID='" + dishID + "' Order By GQEndTime desc ";
				var dtOrderGuQing = DBHelper.ExeSqlForDataTable(sqlOrderGuQing);
				if (gqName.Equals("沽清"))
				{
					if (dtOrderGuQing.Rows.Count > 0)
					{
						//更新
						return DBHelper.ExecuteNonQuery("update OrderGuQing set DishNumber=" + dishNumber + ",GQStartTime='" + dtModel.StartTime + "',GQEndTime='" + dtModel.EndTime + "',GQType=" + Convert.ToInt32(gqModel) + ",CanBieID='" + dtModel.CanBieUID + "',updatetime='" + DateTime.Now + "',updateuser='" + Tools.CurrentUser.UID + "' where uid='" + dtOrderGuQing.Rows[0]["UID"].ToString() + "'");
					}
					else
					{
						//新增
						string sqlInsert = string.Format(" INSERT INTO OrderGuQing(UID,StoreID,DishID,DishNumber,GQStartTime,GQEndTime,GQType,CanBieID "
										 + " ,AddUser,AddTime,UpdateUser,UpdateTime,Memo) "
										 + " VALUES('{0}',{1},'{2}','{3}','{4}','{5}',{6},'{7}','{8}','{9}','{10}','{11}','{12}')", Guid.NewGuid().ToString("N"), Tools.CurrentUser.StoreID,
										 dishID, dishNumber, dtModel.StartTime, dtModel.EndTime, Convert.ToInt32(gqModel), dtModel.CanBieUID, Tools.CurrentUser.UID, DateTime.Now, Tools.CurrentUser.UID, DateTime.Now, "");
						return DBHelper.ExecuteNonQuery(sqlInsert);
					}
				}
				else
				{
					//直接删除
					return DBHelper.ExecuteNonQuery("delete from OrderGuQing  WHERE GQStartTime <= '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' AND GQEndTime >= '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' AND DishID='" + dishID + "' ");
				}
			}
			catch (Exception ex)
			{
				Log.WriteLog("CommonGuQing GuQingOpreate 错误原因:" + ex.ToString());
				return false;
			}
		}

		/// <summary>
		/// 获取当前时间所在时间段内的所有沽清菜品
		/// </summary>
		/// <returns></returns>
		public static DataTable GetOrderGuQingAllData()
		{
			string sqlOrderGuQing = "select DishID,DishNumber from OrderGuQing WITH(NOLOCK) WHERE GQStartTime <= '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' AND GQEndTime >= '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' ";
			return DBHelper.ExeSqlForDataTable(sqlOrderGuQing);
		}


		#region //沽清上传
		public static bool hasUploadedEmptyGuQingData = false;
		/// <summary>
		/// 沽清上传
		/// </summary>
		/// <returns>1:上传成功 2：上传失败 3：无数据可上传</returns>
		public static int uploadGuQingData()
		{
			try
			{
				if (Common.getSystemConfig("IsNeedUploadGuQingData", "0").Equals("0"))
					return 0;

				XmlDocument doc = new XmlDocument();
				doc.LoadXml("<?xml version='1.0' encoding='utf-8'?><root></root>");
				XmlElement root = doc.DocumentElement;
				string strSelectSql = "SELECT * FROM OrderGuQing WHERE GQEndTime >= '" + DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss") + "'";

				string strJson = DBHelper.DateTableToJson(DBHelper.ExeSqlForDataTable(strSelectSql));

				if (string.IsNullOrWhiteSpace(strJson) || string.IsNullOrEmpty(strJson) || object.Equals(strJson, "[]"))
				{
					if (hasUploadedEmptyGuQingData)
					{
						return 3;
					}
					else
						hasUploadedEmptyGuQingData = true;
				}
				else
					hasUploadedEmptyGuQingData = false;

				XmlNode node = doc.CreateNode(XmlNodeType.Element, "OrderGuQing", null);
				root.AppendChild(node);

				XmlCDataSection data = doc.CreateCDataSection(strJson);
				node.AppendChild(data);

				//上传服务器
				string url = ConfigurationManager.AppSettings["serverurl"] + "/QiantaiWeb/AjaxHandler.ashx?methodName=UploadGuQingDataHandler";
				HandleResult result = uploadDataToServer(doc, url);

				if (result.completeSuccess())
					return 1;
				else
					return 0;
			}
			catch (Exception e)
			{
				Log.WriteLog("UploadClass uploadGuQingData():" + e.ToString());
				return 0;
			}
		}

		public static HandleResult uploadDataToServer(XmlDocument doc, String url)
		{
			HandleResult result = new HandleResult(false, "尚未上传", "");
			try
			{
				WebRequest request = HttpWebRequest.Create(url);
				request.Method = "Post";
				request.ContentType = "text/xml";
				request.Headers.Add("cookie", CookiesCommon.handleCookie(CookiesCommon.getCurrentUserCookie(Tools.CurrentUser.UID)));

				using (Stream reqStream = request.GetRequestStream())
				{
					byte[] content = Encoding.UTF8.GetBytes(doc.OuterXml);
					reqStream.Write(content, 0, content.Length);
					reqStream.Close();
				}

				using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
				{
					using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
					{
						string re = reader.ReadToEnd().ToString();
						result = HandleResult.DeserializeResultObj(re);
					}
				}
			}
			catch (Exception ex)
			{
				result.Message = ex.Message;
				Log.WriteLog("上传服务器数据出错  Common uploadDataToServer():\r\n" + ex.ToString());
			}

			return result;
		}

		#endregion

		public class ModelTmp
		{
			/// <summary>
			/// orderzhuotaidish主键UID
			/// </summary>
			public string UID { get; set; }
			/// <summary>
			/// 是否是套餐明细【是|否】
			/// </summary>
			public string IsTaoCanDetail { get; set; }
			/// <summary>
			/// 是否是套餐壳名称
			/// </summary>
			public bool IsPackage { get; set; }
			/// <summary>
			/// 菜品名称
			/// </summary>
			public string DishName { get; set; }
			/// <summary>
			/// 菜品ID
			/// </summary>
			public string DishID { get; set; }
		}



	}
}
