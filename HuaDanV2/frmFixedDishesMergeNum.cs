using HuaDan.CustomControl;
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
	public partial class frmFixedDishesMergeNum : Form
	{
		public static frmFixedDishesMergeNum Instance { get; set; }
		FixedDishesMergeNumControl[] fixedDishesMergeNumControl;
		List<BaseDishModel> baseDishList = new List<BaseDishModel>();

		List<BaseDishModel> baseDishListForShow = new List<BaseDishModel>();
		string TURNPEEPAGE = "上一页";
		string TURNNEXTPAGE = "下一页";
		string BTNlOGO = "BKY";  //标识上一页下一页按钮是否可用

		int qiantaiMode = 0;
		DateTime startTime = DateTime.Now;//餐别开始时间
		string typeCondition = string.Empty;  //设置选中的类型
		string dishCondition = string.Empty;  //设置界面选中的菜品
		int CurrentPageNo = 0;
		int TotalPage = 0;

		public frmFixedDishesMergeNum()
		{
			InitializeComponent();

			this.WindowState = FormWindowState.Maximized;
			Instance = this;
			this.Top = 0;
			this.Left = 0;
			this.Width = Screen.PrimaryScreen.Bounds.Width;
			this.Height = Screen.PrimaryScreen.Bounds.Height;

			FixedDishesMergeNumControl ctl = new FixedDishesMergeNumControl();

			int wCount = this.ClientSize.Width / ctl.Width;
			int hCount = this.ClientSize.Height / ctl.Height;

			int ctlWidth = this.ClientSize.Width / wCount;
			int ctlHeight = this.ClientSize.Height / hCount;

			tableLayoutPanel1.ColumnCount = wCount;
			tableLayoutPanel1.RowCount = hCount;

			fixedDishesMergeNumControl = new FixedDishesMergeNumControl[wCount * hCount];

			for (int i = 0; i < fixedDishesMergeNumControl.Length; i++)
			{
				fixedDishesMergeNumControl[i] = new FixedDishesMergeNumControl();
				fixedDishesMergeNumControl[i].Width = ctlWidth;
				fixedDishesMergeNumControl[i].Height = ctlHeight;
				fixedDishesMergeNumControl[i].DishName = "";
				fixedDishesMergeNumControl[i].DishNum = "";

				fixedDishesMergeNumControl[i].Click += FixedDishesMergeNumControl_Click;

				tableLayoutPanel1.Controls.Add(fixedDishesMergeNumControl[i]);
			}
		}



		private void frmFixedDishesMergeNum_Load(object sender, EventArgs e)
		{
			Common.ajudgeLocalTimeBaseServer();
			LoadAllDish();
		}

		public void LoadAllDish()
		{
			startTime = Common.InitCanBie();
			GetSetupDishInfo();
			baseDishList = Common.GetAllDish(typeCondition, dishCondition, ""); //基础菜品数据，固定
			List<OrderZTDishModel> orderZTDishList = LoadAllZhuoTaiDish();                         //已点菜品-----------已合并

			ShowDishs(baseDishList, orderZTDishList);
		}


		/// <summary>
		/// 获取设置页菜品类型和菜品信息选中的信息
		/// </summary>
		private void GetSetupDishInfo()
		{
			string strDishTypes = ConfigurationManager.AppSettings["dishtypes"];
			string strDishes = ConfigurationManager.AppSettings["dishes"];

			if (string.IsNullOrEmpty(strDishTypes))
				typeCondition = "('')";
			else
				typeCondition = "('" + strDishTypes.Replace(",", "','") + "')";

			if (string.IsNullOrEmpty(strDishes))
				dishCondition = "('')";
			else
				dishCondition = "('" + strDishes.Replace(",", "','") + "')";
		}

		private List<OrderZTDishModel> LoadAllZhuoTaiDish()
		{
			List<OrderZTDishModel> orderZTDishList = new List<OrderZTDishModel>();
			try
			{
				qiantaiMode = 0;

				string strQiantaiMode = ConfigurationManager.AppSettings["qiantaimode"];

				if (!string.IsNullOrEmpty(strQiantaiMode))
					qiantaiMode = int.Parse(strQiantaiMode);

				string sql = " select ztdish.UID,ztdish.DishID,ztdish.DishName,ztdish.DishNum+ztdish.DishZengSongNum as DishNum,ztdish.UnitName,ztdish.AddTime as AddTime "
						   + " from HisOrderZhuoTaiDish ztdish with(nolock)  "
						   + " where ztdish.DishStatusID=1 AND IsHuaCai=0 and ztdish.IsPackage = 0 AND ztdish.StoreID= " + Tools.CurrentUser.StoreID + " AND ztdish.SongDanTime>'" + startTime + "'  "
						   + " AND ztdish.DishTypeID IN " + typeCondition + " AND (ztdish.DishNum+ztdish.DishZengSongNum)>0  AND ztdish.DishID NOT IN " + dishCondition
						   + " union "
						   + " select dishpackage.UID,dishpackage.DishID,dishpackage.DishName,((dishpackage.DishNum+dishpackage.DishZengSongNum)*(ztdish.DishNum+ztdish.DishZengSongNum)) as DishNum,dishpackage.UnitName,dishpackage.AddTime as AddTime "
						   + " from HisOrderPackageDishDetail  dishpackage  with(nolock) "
						   + " inner join HisOrderZhuoTaiDish ztdish with(nolock) on dishpackage.OrderZhuoTaiDishID=ztdish.UID "
						   + " where dishpackage.DishStatusID=1 AND dishpackage.IfHuaCai=0 and ztdish.IsPackage = 1 AND dishpackage.StoreID= " + Tools.CurrentUser.StoreID + " AND dishpackage.SongDanTime>'" + startTime + "'  "
						   + " AND dishpackage.DishTypeID IN " + typeCondition + " AND ((dishpackage.DishNum+dishpackage.DishZengSongNum)*(ztdish.DishNum+ztdish.DishZengSongNum))>0  AND dishpackage.DishID NOT IN " + dishCondition;

				string strSql = "";
				if (qiantaiMode == 0)  //中餐
				{
					string showDishForFinishPay = ConfigurationManager.AppSettings["showDishForFinishPay"];
					string sqlYJS = string.Empty;
					if ("1".Equals(showDishForFinishPay))
					{
						sqlYJS = "UNION" + sql;
					}

					strSql = " select  DishID,DishName,SUM(ISNULL(DishNum,0)) as DishNum,UnitName,Min(AddTime) as AddTime  from ( "
						   + " select ztdish.UID,ztdish.DishID,ztdish.DishName,ztdish.DishNum+ztdish.DishZengSongNum as DishNum,ztdish.UnitName,ztdish.AddTime as AddTime "
						   + " from OrderZhuoTaiDish ztdish with(nolock)  "
						   + " where ztdish.DishStatusID=1 AND IsHuaCai=0 and ztdish.IsPackage = 0 AND ztdish.StoreID= " + Tools.CurrentUser.StoreID + " AND ztdish.SongDanTime>'" + startTime + "'  "
						   + " AND ztdish.DishTypeID IN " + typeCondition + " AND (ztdish.DishNum+ztdish.DishZengSongNum)>0  AND ztdish.DishID NOT IN " + dishCondition
						   + " union "
						   + " select dishpackage.UID,dishpackage.DishID,dishpackage.DishName,((dishpackage.DishNum+dishpackage.DishZengSongNum)*(ztdish.DishNum+ztdish.DishZengSongNum)) as DishNum,dishpackage.UnitName,dishpackage.AddTime as AddTime "
						   + " from OrderPackageDishDetail  dishpackage  with(nolock) "
						   + " inner join OrderZhuoTaiDish ztdish with(nolock) on dishpackage.OrderZhuoTaiDishID=ztdish.UID "
						   + " where dishpackage.DishStatusID=1 AND dishpackage.IfHuaCai=0 and ztdish.IsPackage = 1 AND dishpackage.StoreID= " + Tools.CurrentUser.StoreID + " AND dishpackage.SongDanTime>'" + startTime + "'  "
						   + " AND dishpackage.DishTypeID IN " + typeCondition + " AND ((dishpackage.DishNum+dishpackage.DishZengSongNum)*(ztdish.DishNum+ztdish.DishZengSongNum))>0  AND dishpackage.DishID NOT IN " + dishCondition
						   + sqlYJS
						   + " ) t "
						   + " group by DishID,DishName,UnitName ";
				}
				else
				{
					strSql = " select DishID,DishName,SUM(ISNULL(DishNum,0)) as DishNum,UnitName,Min(AddTime) as AddTime  from ( "
						   + sql + " ) t "
						   + " group by DishID,DishName,UnitName ";
				}

				DataTable table = DBHelper.ExeSqlForDataTable(strSql);
				orderZTDishList = EntityUtil.ToList<OrderZTDishModel>(table);
			}
			catch (Exception ex)
			{
				Log.WriteLog("frmDanXiagnMergeDishFixed 菜品合并 LoadAllZhuoTaiDish错误信息:" + ex.ToString());
			}

			return orderZTDishList;
		}

		private void ShowDishs(List<BaseDishModel> dishList, List<OrderZTDishModel> orderZTDishList)
		{
			try
			{
				this.SuspendLayout();
				tableLayoutPanel1.SuspendLayout();

				for (int i = 0; i < fixedDishesMergeNumControl.Length; i++)
				{
					fixedDishesMergeNumControl[i].Reset();
				}

				CalculateTotalPage();
				int startIndex = CurrentPageNo * tableLayoutPanel1.RowCount * tableLayoutPanel1.ColumnCount;
				int endIndex = startIndex + (tableLayoutPanel1.RowCount * tableLayoutPanel1.ColumnCount);

				DateTime now = DateTime.Now;
				int j = 0;
				for (int i = startIndex; i < endIndex; i++)
				{
					BaseDishModel dishModel = baseDishListForShow[i];
					fixedDishesMergeNumControl[j].DishName = dishModel.DishName;
					fixedDishesMergeNumControl[j].DishNum = "";
					fixedDishesMergeNumControl[j].UnitName = dishModel.UnitName;

					decimal totalNum = orderZTDishList.Where(p => p.DishID.Equals(dishModel.DishID)).Select(p => p.DishNum).Sum();
					if (totalNum != 0)
					{
						fixedDishesMergeNumControl[j].DishNum = totalNum.ToString("0.##");
					}

					fixedDishesMergeNumControl[j].ChangFontColor(Color.Black, Color.Red,false);
					if (dishModel.DishName.Equals(TURNPEEPAGE) || dishModel.DishName.Equals(TURNNEXTPAGE))
					{
						fixedDishesMergeNumControl[j].DishNum = "(" + (CurrentPageNo + 1) + "/" + TotalPage + ")";
						if (dishModel.UnitName.Equals(BTNlOGO))
							fixedDishesMergeNumControl[j].ChangFontColor(Color.Gray, Color.Gray,true);
						else
							fixedDishesMergeNumControl[j].ChangFontColor(Color.Red, Color.Red,true);
					}

					if (string.IsNullOrEmpty(dishModel.DishName) && string.IsNullOrEmpty(dishModel.UnitName))
					{
						fixedDishesMergeNumControl[j].ChangeBackColor(Color.FromArgb(210, 210, 210));
					}

					j++;
				}

				tableLayoutPanel1.ResumeLayout();
				this.ResumeLayout();
			}
			catch (Exception ex)
			{
				Log.WriteLog("frmFixedDishesMergeNum ShowDishs 错误信息:" + ex.ToString());
			}
		}

		private void FixedDishesMergeNumControl_Click(object sender, EventArgs e)
		{
			FixedDishesMergeNumControl ctl = sender as FixedDishesMergeNumControl;
			string dishname = ctl.DishName;
			string dishnum = ctl.DishNum;
			string unitname = ctl.UnitName;
			if (dishname.Equals(TURNPEEPAGE))
			{
				if (!unitname.Equals(BTNlOGO))
				{
					CurrentPageNo--;
					LoadAllDish();
				}
			}
			else if (dishname.Equals(TURNNEXTPAGE))
			{
				if (!unitname.Equals(BTNlOGO))
				{
					CurrentPageNo++;
					LoadAllDish();
				}
			}
			else if (!string.IsNullOrEmpty(dishname) && !string.IsNullOrEmpty(dishnum))
			{
				frmLoading frm = new frmLoading();
				frm.Show();
				frm.Update();

				HuaDanOpreate(dishname);

				frm.Close();
			}
		}

		private void CalculateTotalPage()
		{
			TotalPage = 0;
			baseDishListForShow = new List<BaseDishModel>();
			int totalCount = tableLayoutPanel1.RowCount * tableLayoutPanel1.ColumnCount;
			int dishToalCount = baseDishList.Count;
			if (dishToalCount <= totalCount)
			{
				baseDishListForShow = baseDishList;
			}
			else
			{
				int j = 0;
				for (int i = 0; i < baseDishList.Count; i++)
				{
					baseDishListForShow.Add(baseDishList[i]);

					j++;
					if ((j == totalCount - 2))
					{
						if (CurrentPageNo == 0)
							baseDishListForShow.Add(new BaseDishModel { DishID = "", DishName = TURNPEEPAGE, TypeID = "", UnitName = BTNlOGO });
						else
							baseDishListForShow.Add(new BaseDishModel { DishID = "", DishName = TURNPEEPAGE, TypeID = "", UnitName = "" });
						baseDishListForShow.Add(new BaseDishModel { DishID = "", DishName = TURNNEXTPAGE, TypeID = "", UnitName = "" });
						j = 0;
						TotalPage++;
					}
					else if (i == dishToalCount - 1)
					{
						for (var k = j + 1; k <= totalCount - 2; k++)
						{
							baseDishListForShow.Add(new BaseDishModel { DishID = "", DishName = "", TypeID = "", UnitName = "" });

							if ((k == totalCount - 2))
							{
								baseDishListForShow.Add(new BaseDishModel { DishID = "", DishName = TURNPEEPAGE, TypeID = "", UnitName = "" });
								baseDishListForShow.Add(new BaseDishModel { DishID = "", DishName = TURNNEXTPAGE, TypeID = "", UnitName = BTNlOGO });
								j = 0;
								TotalPage++;
							}
						}
					}
				}
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			LoadAllDish();
		}

		private void HuaDan(List<string> uidList)
		{
			try
			{
				if (uidList.Count() <= 0)
					return;

				StringBuilder builder = new StringBuilder();
				string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

				builder.Append("UPDATE OrderZhuoTaiDish SET IsHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE UID='" + uidList[0] + "' ").Append("\r\n")
					   .Append("UPDATE HisOrderZhuoTaiDish SET IsHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE UID='" + uidList[0] + "' ").Append("\r\n")
					   .Append("UPDATE OrderPackageDishDetail SET IfHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE UID='" + uidList[0] + "' ").Append("\r\n")
					   .Append("UPDATE HisOrderPackageDishDetail SET IfHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE UID='" + uidList[0] + "' ").Append("\r\n");

				string strSql = builder.ToString();
				if (!DBHelper.ExecuteNonQuery(strSql))
				{
					MessageBox.Show("划单失败！");
					return;
				}

				LoadAllDish();

				if ("1".Equals(ConfigurationManager.AppSettings["autoprint"]))
				{
					Task.Factory.StartNew(
					   () =>
					   {
						   HuaDanClass.PrintDishes(uidList, new List<OrderAllZTDishModel>());
					   }
				   );
				}

				bool ifweixin = "1".Equals(ConfigurationManager.AppSettings["ifweixin"]);
				if (ifweixin)
				{
					Task.Factory.StartNew(
						() =>
						{
							HuaDanClass.CallWeiXin(uidList);
						}
					);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void HuaDanOpreate(string DishName)
		{
			try
			{
				if (string.IsNullOrEmpty(DishName))
				{
					this.Close();
					return;
				}

				int qiantaiMode = 0;
				string strQiantaiMode = ConfigurationManager.AppSettings["qiantaimode"];

				if (!string.IsNullOrEmpty(strQiantaiMode))
					qiantaiMode = int.Parse(strQiantaiMode);

				string strSql = "";

				string sql = " select UID,DishName,DishNum,DishZengSongNum,AddTime,SongDanTime from HisOrderZhuoTaiDish where IsPackage=0 and DishStatusID=1 and IsHuaCai=0"
						   + " union all "
						   + " select UID,DishName,DishNum,DishZengSongNum,AddTime,SongDanTime from HisOrderPackageDishDetail where DishStatusID=1 and IfHuaCai=0 ";
				if (qiantaiMode == 0)  //中餐
				{
					string showDishForFinishPay = ConfigurationManager.AppSettings["showDishForFinishPay"];
					string sqlYJS = string.Empty;
					if ("1".Equals(showDishForFinishPay))
					{
						sqlYJS = "UNION all" + sql;
					}

					strSql = " select * from  ("
						+ " select UID,DishName,DishNum,DishZengSongNum,AddTime,SongDanTime from OrderZhuoTaiDish where IsPackage=0 and DishStatusID=1 and IsHuaCai=0"
						+ " union all "
						+ " select UID,DishName,DishNum,DishZengSongNum,AddTime,SongDanTime from OrderPackageDishDetail where DishStatusID=1 and IfHuaCai=0 "
						+ sqlYJS
						+ " ) t where SongDanTime>'" + startTime + "' and DishName='" + DishName + "' order by AddTime asc";
				}
				else
				{
					strSql = " select * from  ("
						+ sql
						+ " ) t where SongDanTime>'" + startTime + "' and DishName='" + DishName + "' order by AddTime asc";
				}

				DataTable dt = DBHelper.ExeSqlForDataTable(strSql);
				if (!object.Equals(dt, null) && dt.Rows.Count > 0)
				{
					string uid = dt.Rows[0]["UID"].ToString();
					List<string> uidList = new List<string>();
					uidList.Add(uid);
					HuaDan(uidList);
				}
			}
			catch (Exception ex)
			{
				Log.WriteLog("frmLoading frmLoading_Load 【" + DishName + "】错误原因:" + ex.ToString());
			}
		}
	}
}
