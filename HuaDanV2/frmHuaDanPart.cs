using HuaDan.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuaDan
{
	public partial class frmHuaDanPart : Form
	{
		OrderAllZTDishModel dishModel = new OrderAllZTDishModel();

		public frmHuaDanPart()
		{
			InitializeComponent();
		}

		public frmHuaDanPart(OrderAllZTDishModel dishmodel)
		{
			InitializeComponent();

			dishModel = dishmodel;

			List<OrderHuaDanPart> dishHuaDanPartList = Common.GetDishPartHuaDanData();
			var hyNum = dishHuaDanPartList.Where(p => p.DishUID.Equals(dishmodel.UID)).Sum(p => p.HuaDanNum);
			 
			lblDishName.Text = dishModel.DishName;
			txtLeftNum.Text = (dishModel.DishNum - hyNum).ToString("0.##");
			txtNum.Focus();
		}

		private void btnHuaDan_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(dishModel.UID))
			{
				MessageBox.Show("参数错误，请关闭该页面重新尝试!");
				return;
			}

			string strHuaNum = txtNum.Text.Trim();
			if (string.IsNullOrEmpty(strHuaNum))
			{
				MessageBox.Show("数量不能为空!");
				return;
			}

			decimal num = 0m;
			try
			{
				num = Convert.ToDecimal(strHuaNum);
			}
			catch (Exception ex)
			{
				MessageBox.Show("请正确输入数量!");
				return;
			}

			if (num <= 0)
			{
				MessageBox.Show("划单数量必须大于0!");
				return;
			}

			if (num > dishModel.DishNum)
			{
				MessageBox.Show("划单数量不能大于当前菜品剩余数量!");
				return;
			}

			string sql = "select * from OrderHuaDanPart where StoreID=" + Tools.CurrentUser.StoreID + " and DishUID='" + dishModel.UID + "' ";
			List<OrderHuaDanPart> dishPartSource = EntityUtil.ToList<OrderHuaDanPart>(DBHelper.ExeSqlForDataTable(sql));

			List<OrderAllZTDishModel> orderZTDishList = new List<OrderAllZTDishModel>();

			int isPackageDetail = 0;
			string sqlZTDish = " SELECT * FROM ( "
					   + " SELECT OrderZhuoTai.UID as ZTUID,ztdish.DishID,ztdish.DishName,ztdish.ZuoFaNames,ztdish.KouWeiNames, "
					   + " ztdish.UnitName,ztdish.AddTime,OrderZhuoTai.ZhuoTaiName,ztdish.IsHuaCai,ztdish.DishTypeID, "
					   + " ztdish.UID,(ztdish.DishNum+ztdish.DishZengSongNum) as DishNum,isnull(ztdish.SongDanTime, "
					   + " ztdish.Addtime) as SongDanTime,OrderInfo.IsWaiMai,ztdish.DishStatusDesc,OrderInfo.UID as OrderID,OrderInfo.OrderCode  "
					   + " FROM OrderZhuoTaiDish ztdish with(nolock)  "
					   + " INNER JOIN OrderInfo with(nolock) on OrderInfo.UID =ztdish.OrderID  "
					   + " INNER JOIN OrderZhuoTai with(nolock) ON OrderZhuoTai.OrderID=OrderInfo.UID  "
					   + " INNER JOIN BaseDishType with(nolock) on BaseDishType.UID=ztdish.DishTypeID  "
					   + " WHERE ztdish.UID='" + dishModel.UID + "' AND ztdish.StoreID=" + Tools.CurrentUser.StoreID
					   + " UNION "
					   + " SELECT HisOrderZhuoTai.UID as ZTUID,ztdish.DishID,ztdish.DishName,ztdish.ZuoFaNames,ztdish.KouWeiNames, "
					   + " ztdish.UnitName,ztdish.AddTime,HisOrderZhuoTai.ZhuoTaiName,ztdish.IsHuaCai,ztdish.DishTypeID, "
					   + " ztdish.UID,(ztdish.DishNum+ztdish.DishZengSongNum) as DishNum,isnull(ztdish.SongDanTime, "
					   + " ztdish.Addtime) as SongDanTime,HisOrderInfo.IsWaiMai,ztdish.DishStatusDesc,HisOrderInfo.UID as OrderID,HisOrderInfo.OrderCode  "
					   + " FROM HisOrderZhuoTaiDish ztdish with(nolock)  "
					   + " INNER JOIN HisOrderInfo with(nolock) on HisOrderInfo.UID =ztdish.OrderID  "
					   + " INNER JOIN HisOrderZhuoTai with(nolock) ON HisOrderZhuoTai.OrderID=HisOrderInfo.UID  "
					   + " INNER JOIN BaseDishType with(nolock) on BaseDishType.UID=ztdish.DishTypeID  "
					   + " WHERE ztdish.UID='" + dishModel.UID + "' and ztdish.StoreID=" + Tools.CurrentUser.StoreID
					   + " ) tableTmp ";

			orderZTDishList = EntityUtil.ToList<OrderAllZTDishModel>(DBHelper.ExeSqlForDataTable(sqlZTDish));
			if (orderZTDishList.Count <= 0)
			{
				sqlZTDish = " SELECT * FROM ( "
					  + " SELECT OrderZhuoTai.UID as ZTUID,dishpackage.DishID,dishpackage.DishName,dishpackage.ZuoFaNames,dishpackage.KouWeiNames, "
					  + " dishpackage.UnitName,dishpackage.AddTime,OrderZhuoTai.ZhuoTaiName,dishpackage.IfHuaCai as IsHuaCai,dishpackage.DishTypeID, "
					  + " dishpackage.UID,((ztdish.DishNum+ztdish.DishZengSongNum)*(dishpackage.DishNum+dishpackage.DishZengSongNum)) as DishNum,isnull(dishpackage.SongDanTime, "
					  + " dishpackage.Addtime) as SongDanTime,OrderInfo.IsWaiMai,dishpackage.DishStatusDesc,OrderInfo.UID as OrderID,OrderInfo.OrderCode  "
					  + " FROM OrderZhuoTaiDish ztdish with(nolock)  "
					  + " INNER JOIN OrderPackageDishDetail dishpackage with(nolock) on ztdish.UID=dishpackage.OrderZhuoTaiDishID "
					  + " INNER JOIN OrderInfo with(nolock) on OrderInfo.UID =ztdish.OrderID  "
					  + " INNER JOIN OrderZhuoTai with(nolock) ON OrderZhuoTai.OrderID=OrderInfo.UID  "
					  + " INNER JOIN BaseDishType with(nolock) on BaseDishType.UID=dishpackage.DishTypeID  "
					  + " WHERE dishpackage.DishStatusID=1 and ztdish.IsPackage=1 and dishpackage.StoreID=" + Tools.CurrentUser.StoreID + " AND dishpackage.UID='" + dishModel.UID + "' "
					  + " union "
					  + " SELECT HisOrderZhuoTai.UID as ZTUID,dishpackage.DishID,dishpackage.DishName,dishpackage.ZuoFaNames,dishpackage.KouWeiNames, "
					  + " dishpackage.UnitName,dishpackage.AddTime,HisOrderZhuoTai.ZhuoTaiName,dishpackage.IfHuaCai as IsHuaCai,dishpackage.DishTypeID, "
					  + " dishpackage.UID,((ztdish.DishNum+ztdish.DishZengSongNum)*(dishpackage.DishNum+dishpackage.DishZengSongNum)) as DishNum,isnull(dishpackage.SongDanTime, "
					  + " dishpackage.Addtime) as SongDanTime,HisOrderInfo.IsWaiMai,dishpackage.DishStatusDesc,HisOrderInfo.UID as OrderID,HisOrderInfo.OrderCode  "
					  + " FROM HisOrderZhuoTaiDish ztdish with(nolock)  "
					  + " INNER JOIN HisOrderPackageDishDetail dishpackage with(nolock) on ztdish.UID=dishpackage.OrderZhuoTaiDishID "
					  + " INNER JOIN HisOrderInfo with(nolock) on HisOrderInfo.UID =ztdish.OrderID  "
					  + " INNER JOIN HisOrderZhuoTai with(nolock) ON HisOrderZhuoTai.OrderID=HisOrderInfo.UID  "
					  + " INNER JOIN BaseDishType with(nolock) on BaseDishType.UID=dishpackage.DishTypeID  "
					  + " WHERE dishpackage.UID='" + dishModel.UID + "' AND  ztdish.IsPackage=1 and dishpackage.StoreID=" + Tools.CurrentUser.StoreID
					  + " ) tableTmp ";
				orderZTDishList = EntityUtil.ToList<OrderAllZTDishModel>(DBHelper.ExeSqlForDataTable(sqlZTDish));
				if (orderZTDishList.Count > 0)
				{
					isPackageDetail = 1;
				}
			}

			if (orderZTDishList.Count <= 0)
			{
				MessageBox.Show("未找到该条记录!");
				return;
			}

			if (orderZTDishList.Count > 1)
			{
				MessageBox.Show("数据错误，找到多条数据!");
				return;
			}

			OrderAllZTDishModel obj = orderZTDishList[0];
			decimal dishPartSum = dishPartSource.Sum(p => p.HuaDanNum);
			if (dishPartSum + num > obj.DishNum)
			{
				MessageBox.Show("划单数量不能大于当前菜品剩余数量!");
				return;
			}

			StringBuilder builder = new StringBuilder();
			DateTime now = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
			var sqlInsert = " INSERT INTO OrderHuaDanPart(UID,GroupID,StoreID,OrderID,OrderCode "
						  + " ,ZTUID,ZTName,DishUID,DishID,DishName "
						  + " ,HuaDanNum,UnitName,IsPackage,IsPackageDetail "
						  + " ,HuaDanTime,AddUser,AddTime,UpdateUser,UpdateTime) "
						  + " VALUES('" + Guid.NewGuid().ToString("N") + "'," + Tools.CurrentUser.GroupID + "," + Tools.CurrentUser.StoreID + ",'" + obj.OrderID + "','" + obj.OrderCode + "' "
						  + " ,'" + obj.ZTUID + "','" + obj.ZhuoTaiName + "','" + obj.UID + "','" + obj.DishID + "','" + obj.DishName + "' "
						  + " ," + num + ",'" + obj.UnitName + "'," + isPackageDetail + "," + isPackageDetail + " "
						  + " ,'" + now + "','" + Tools.CurrentUser.UID + "','" + now + "','" + Tools.CurrentUser.UID + "','" + now + "') ";
			builder.Append(sqlInsert).Append("\r\n");
			if (dishPartSum + num == obj.DishNum)
			{
				builder.Append("UPDATE OrderZhuoTaiDish SET IsHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE UID='" + dishModel.UID + "' ").Append("\r\n")
					   .Append("UPDATE HisOrderZhuoTaiDish SET IsHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE UID='" + dishModel.UID + "' ").Append("\r\n");

				builder.Append("UPDATE OrderPackageDishDetail SET IfHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE UID='" + dishModel.UID + "' ").Append("\r\n")
					.Append("UPDATE HisOrderPackageDishDetail SET IfHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE UID='" + dishModel.UID + "' ").Append("\r\n");
			}

			if (DBHelper.ExecuteNonQuery(builder.ToString()))
			{
				List<string> uids = new List<string>() { dishModel.UID };
				List<OrderAllZTDishModel> paramDishPartList = new List<OrderAllZTDishModel>();
				obj.DishNum = num;
				paramDishPartList.Add(obj);
				if ("1".Equals(ConfigurationManager.AppSettings["autoprint"]))
				{
					Task.Factory.StartNew(
					   () =>
					   {
						   HuaDanClass.PrintDishes(uids, paramDishPartList);
					   }
				   );
				}

				bool ifweixin = "1".Equals(ConfigurationManager.AppSettings["ifweixin"]);
				if (ifweixin)
				{
					Task.Factory.StartNew(
						() =>
						{
							HuaDanClass.SendNotify(paramDishPartList);
						}
					);
				}

				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			else
			{
				MessageBox.Show("划单失败!");
			}
		}

		private void frmHuaDanPart_Resize(object sender, EventArgs e)
		{
			//圆角
			this.Region = FormOptimization.SetWindowRegion(this.Width, this.Height);
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btn1_Click(object sender, EventArgs e)
		{
			string str = txtNum.Text.Trim();

			string result = string.Empty;
			Button btn = sender as Button;
			switch (btn.Text)
			{
				case "1":
					result = "1";
					break;
				case "2":
					result = "2";
					break;
				case "3":
					result = "3";
					break;
				case "4":
					result = "4";
					break;
				case "5":
					result = "5";
					break;
				case "6":
					result = "6";
					break;
				case "7":
					result = "7";
					break;
				case "8":
					result = "8";
					break;
				case "9":
					result = "9";
					break;
				case "0":
					result = "0";
					break;
			}

			txtNum.Text = str + result;
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			txtNum.Clear();
			txtNum.Focus();
		}
	}
}
