using HuaDan.Model;
using HuaDan.TipForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuaDan
{
	public partial class frmDanXiangMergeDishFixed : Form
	{
		public static frmDanXiangMergeDishFixed Instance { get; set; }
		int CurrentPageNo = 0;
		int CurrentPageNoDetail = 0;
		MergeDishControl[] mergeDishControls;
		MergeDishDetailControl[] mergeDishDetailControl;
		string strZhuotaiMode = string.Empty;
		DateTime startTime = DateTime.Now;//餐别开始时间
		public static double alertTime = 30;
		int qiantaiMode = 0;
		int ctlHeight = 0;
		List<OrderAllZTDishModel> orderAllZTDishList = new List<OrderAllZTDishModel>();
		MergeDishDetailModel model = new MergeDishDetailModel();
		GuQingModelClass guQingModelClass = new GuQingModelClass();
		DataTable orderGuQingTable = new DataTable();
		int btnDishTypeWidth = 100;
		ComboBox combox = new ComboBox();//存放菜品类别
		int cmbIndex = 0;////存放菜品类别下拉框索引
		List<Button> btnDishTypeList = new List<Button>();//存放菜品类别的按钮UID
		string CurrDishTypeUID = string.Empty;//当前菜品选择的类别UID
		List<OrderAllZTDishModel> dishPartList = new List<OrderAllZTDishModel>();  //选中待划菜品数据源
		string CurrDishName = string.Empty;//当前选中的菜品名称

		string typeCondition = string.Empty;  //设置选中的类型
		string dishCondition = string.Empty;  //设置界面选中的菜品

		public frmDanXiangMergeDishFixed()
		{
			InitializeComponent();

			this.WindowState = FormWindowState.Maximized;
			Instance = this;
			this.Top = 0;
			this.Left = 0;
			this.Width = Screen.PrimaryScreen.Bounds.Width;
			this.Height = Screen.PrimaryScreen.Bounds.Height;

			int zhuotaiMode = 0;
			strZhuotaiMode = ConfigurationManager.AppSettings["zhuotaimode"];
			if (!string.IsNullOrEmpty(strZhuotaiMode))
				zhuotaiMode = int.Parse(strZhuotaiMode);

			if (zhuotaiMode == 2)
			{
				#region //左半边

				MergeDishControl ctl = new MergeDishControl();

				int wCount = (this.ClientSize.Width - this.panOuter.Width) / ctl.Width;
				int hCount = (this.ClientSize.Height - 62 - this.panel2.Height) / ctl.Height;

				int ctlWidth = (this.ClientSize.Width - this.panOuter.Width) / wCount;
				ctlHeight = (this.ClientSize.Height - 62 - this.panel2.Height) / hCount;// -(100 / hCount);

				tableLayoutPanel1.ColumnCount = wCount;
				tableLayoutPanel1.RowCount = hCount;

				mergeDishControls = new MergeDishControl[wCount * hCount];

				for (int i = 0; i < mergeDishControls.Length; i++)
				{
					mergeDishControls[i] = new MergeDishControl();
					mergeDishControls[i].Width = ctlWidth;
					mergeDishControls[i].Height = ctlHeight;

					mergeDishControls[i].DishName = "";
					mergeDishControls[i].ZFKW = "";
					mergeDishControls[i].ZhuoTaiNum = "";
					mergeDishControls[i].UID = "";
					mergeDishControls[i].DishNum = "";

					mergeDishControls[i].DishID = "";
					mergeDishControls[i].ZuoFa = "";
					mergeDishControls[i].KouWei = "";
					mergeDishControls[i].UintName = "";
					mergeDishControls[i].TimeOutChangeImg(false);

					mergeDishControls[i].Click += MergeDishControl_Click;

					tableLayoutPanel1.Controls.Add(mergeDishControls[i]);
				}
				#endregion

				#region //右半边

				int heightTmp = this.tableLayoutPanel1.GetPreferredSize(mergeDishControls[0].Size).Height;

				MergeDishDetailControl ctlDetail = new MergeDishDetailControl();

				int wCountDetail = 1;
				int hCountDetail = hCount - 1;

				tableLayoutPanel2.ColumnCount = wCountDetail;
				tableLayoutPanel2.RowCount = hCountDetail;

				mergeDishDetailControl = new MergeDishDetailControl[wCountDetail * hCountDetail];

				for (int i = 0; i < mergeDishDetailControl.Length; i++)
				{
					mergeDishDetailControl[i] = new MergeDishDetailControl();
					mergeDishDetailControl[i].Height = heightTmp;

					mergeDishDetailControl[i].DishName = "";
					mergeDishDetailControl[i].ZFKW = "";
					mergeDishDetailControl[i].Time = "";
					mergeDishDetailControl[i].UID = "";
					mergeDishDetailControl[i].ZhuoTaiName = "";
					mergeDishDetailControl[i].WaiMai = "";
					mergeDishDetailControl[i].Count = "";
					mergeDishDetailControl[i].Click += MergeDishDetailControl_Click;
					mergeDishDetailControl[i].DoubleClick += MergeDishDetailControl_DoubleClick;

					tableLayoutPanel2.Controls.Add(mergeDishDetailControl[i]);
				}
				#endregion

				int height = heightTmp;
				panel3.Height = heightTmp;
				var panHeight = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(height / 3)));
				panBtnHuaDan.Height = panHeight;
				panTurnPage.Height = panHeight;
				panBtnHuaDanPart.Height = height - panHeight - panHeight;
			}
		}

		private void frmDanXiangMergeDishFixed_Load(object sender, EventArgs e)
		{
			string guQingModel = ConfigurationManager.AppSettings["guQingModel"];
			if (!string.IsNullOrEmpty(guQingModel) && !"0".Equals(guQingModel))
			{
				btnGuQing.Visible = true;
				grpColor.Visible = true;
			}
			else
			{
				btnGuQing.Visible = false;
				grpColor.Visible = false;
			}
			Instance = this;
			LoadDishType();
			StartMonitor();
		}

		private void LoadAllDish()
		{
			startTime = Common.InitCanBie();
			GetSetupDishInfo();
			List<BaseDishModel> baseDishList = Common.GetAllDish(typeCondition, dishCondition, CurrDishTypeUID); //基础菜品数据，固定
			List<OrderZTDishModel> orderZTDishList = LoadAllZhuoTaiDish();                         //已点菜品-----------已合并
			orderAllZTDishList = GetAllData();                                                     //已点菜品-----------未合并
			List<OrderHuaDanPart> dishHuaDanPartList =Common.GetDishPartHuaDanData();

			ShowDishs(baseDishList, orderZTDishList, orderAllZTDishList, dishHuaDanPartList);
		}

		private List<OrderZTDishModel> LoadAllZhuoTaiDish()
		{
			List<OrderZTDishModel> orderZTDishList = new List<OrderZTDishModel>();
			try
			{
				string strAlertTime = ConfigurationManager.AppSettings["alerttime"];
				if (!string.IsNullOrEmpty(strAlertTime))
					alertTime = double.Parse(strAlertTime);

				qiantaiMode = 0;

				string strQiantaiMode = ConfigurationManager.AppSettings["qiantaimode"];

				if (!string.IsNullOrEmpty(strQiantaiMode))
					qiantaiMode = int.Parse(strQiantaiMode);

				string sql = " select ztdish.UID,ztdish.DishID,ztdish.DishName,ztdish.DishNum+ztdish.DishZengSongNum as DishNum,ztdish.UnitName,ztdish.AddTime as AddTime "
						   + " from HisOrderZhuoTaiDish ztdish with(nolock)  "
						   + " INNER JOIN HisOrderZhuoTai orderzt with(nolock) ON orderzt.OrderID=ztdish.OrderID "
						   + " INNER JOIN BaseDishType with(nolock) on BaseDishType.UID=ztdish.DishTypeID  "
						   + " left join BaseZhuoTai zt  with(nolock) on orderzt.ZhuoTaiID=zt.UID "
                           + " left join BaseTingMianLouCeng tmlc  with(nolock) on tmlc.UID=zt.TMLCID "
						   + " where ztdish.DishStatusID=1 AND IsHuaCai=0 and ztdish.IsPackage = 0 AND ztdish.StoreID= " + Tools.CurrentUser.StoreID + " AND ztdish.SongDanTime>'" + startTime + "'  "
						   + " AND ztdish.DishTypeID IN " + typeCondition + " AND (ztdish.DishNum+ztdish.DishZengSongNum)>0  AND ztdish.DishID NOT IN " + dishCondition + AddQueryCondition() + Common.GetTMLCCondition()
						   + " union "
						   + " select dishpackage.UID,dishpackage.DishID,dishpackage.DishName,((dishpackage.DishNum+dishpackage.DishZengSongNum)*(ztdish.DishNum+ztdish.DishZengSongNum)) as DishNum,dishpackage.UnitName,dishpackage.AddTime as AddTime "
						   + " from HisOrderPackageDishDetail  dishpackage  with(nolock) "
						   + " inner join HisOrderZhuoTaiDish ztdish with(nolock) on dishpackage.OrderZhuoTaiDishID=ztdish.UID "
						   + " INNER JOIN HisOrderZhuoTai orderzt with(nolock) ON orderzt.OrderID=ztdish.OrderID "
						   + " INNER JOIN BaseDishType with(nolock) on BaseDishType.UID=dishpackage.DishTypeID  "
						   + " left join BaseZhuoTai zt  with(nolock) on orderzt.ZhuoTaiID=zt.UID "
						   + " left join BaseTingMianLouCeng tmlc  with(nolock) on tmlc.UID=zt.TMLCID "
						   + " where dishpackage.DishStatusID=1 AND dishpackage.IfHuaCai=0 and ztdish.IsPackage = 1 AND dishpackage.StoreID= " + Tools.CurrentUser.StoreID + " AND dishpackage.SongDanTime>'" + startTime + "'  "
						   + " AND dishpackage.DishTypeID IN " + typeCondition + " AND ((dishpackage.DishNum+dishpackage.DishZengSongNum)*(ztdish.DishNum+ztdish.DishZengSongNum))>0  AND dishpackage.DishID NOT IN " + dishCondition + AddQueryCondition() + Common.GetTMLCCondition();

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
						   + " INNER JOIN OrderZhuoTai orderzt with(nolock) ON orderzt.OrderID=ztdish.OrderID "
						   + " INNER JOIN BaseDishType with(nolock) on BaseDishType.UID=ztdish.DishTypeID  "
						   + " left join BaseZhuoTai zt  with(nolock) on orderzt.ZhuoTaiID=zt.UID "
                           + " left join BaseTingMianLouCeng tmlc  with(nolock) on tmlc.UID=zt.TMLCID "
						   + " where ztdish.DishStatusID=1 AND IsHuaCai=0 and ztdish.IsPackage = 0 AND ztdish.StoreID= " + Tools.CurrentUser.StoreID + " AND ztdish.SongDanTime>'" + startTime + "'  "
						   + " AND ztdish.DishTypeID IN " + typeCondition + " AND (ztdish.DishNum+ztdish.DishZengSongNum)>0  AND ztdish.DishID NOT IN " + dishCondition + AddQueryCondition() + Common.GetTMLCCondition()
						   + " union "
						   + " select dishpackage.UID,dishpackage.DishID,dishpackage.DishName,((dishpackage.DishNum+dishpackage.DishZengSongNum)*(ztdish.DishNum+ztdish.DishZengSongNum)) as DishNum,dishpackage.UnitName,dishpackage.AddTime as AddTime "
						   + " from OrderPackageDishDetail  dishpackage  with(nolock) "
						   + " inner join OrderZhuoTaiDish ztdish with(nolock) on dishpackage.OrderZhuoTaiDishID=ztdish.UID "
						   + " INNER JOIN OrderZhuoTai orderzt with(nolock) ON orderzt.OrderID=ztdish.OrderID "
						   + " INNER JOIN BaseDishType with(nolock) on BaseDishType.UID=dishpackage.DishTypeID  "
						   + " left join BaseZhuoTai zt  with(nolock) on orderzt.ZhuoTaiID=zt.UID "
						   + " left join BaseTingMianLouCeng tmlc  with(nolock) on tmlc.UID=zt.TMLCID "
						   + " where dishpackage.DishStatusID=1 AND dishpackage.IfHuaCai=0 and ztdish.IsPackage = 1 AND dishpackage.StoreID= " + Tools.CurrentUser.StoreID + " AND dishpackage.SongDanTime>'" + startTime + "'  "
						   + " AND dishpackage.DishTypeID IN " + typeCondition + " AND ((dishpackage.DishNum+dishpackage.DishZengSongNum)*(ztdish.DishNum+ztdish.DishZengSongNum))>0  AND dishpackage.DishID NOT IN " + dishCondition + AddQueryCondition() + Common.GetTMLCCondition()
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

				GetOrderGuQingAllData();

				DataTable table = DBHelper.ExeSqlForDataTable(strSql);
				orderZTDishList = EntityUtil.ToList<OrderZTDishModel>(table);
			}
			catch (Exception ex)
			{
				Log.WriteLog("frmDanXiagnMergeDishFixed 菜品合并 LoadAllZhuoTaiDish错误信息:" + ex.ToString());
			}

			return orderZTDishList;
		}

		private List<OrderAllZTDishModel> GetAllData()
		{
			List<OrderAllZTDishModel> orderZTDishList = new List<OrderAllZTDishModel>();

			try
			{
				string strAlertTime = ConfigurationManager.AppSettings["alerttime"];
				if (!string.IsNullOrEmpty(strAlertTime))
					alertTime = double.Parse(strAlertTime);

				qiantaiMode = 0;

				string strQiantaiMode = ConfigurationManager.AppSettings["qiantaimode"];

				if (!string.IsNullOrEmpty(strQiantaiMode))
					qiantaiMode = int.Parse(strQiantaiMode);


				string sql = " SELECT orderzt.UID as ZTUID,ztdish.DishID,ztdish.DishName,ztdish.ZuoFaNames,ztdish.KouWeiNames, "
							 + " ztdish.UnitName,ztdish.AddTime,orderzt.ZhuoTaiName,ztdish.IsHuaCai,ztdish.DishTypeID, "
							 + " ztdish.UID,(ztdish.DishNum+ztdish.DishZengSongNum) as DishNum,isnull(ztdish.SongDanTime, "
							 + " ztdish.Addtime) as SongDanTime,HisOrderInfo.IsWaiMai,ztdish.DishStatusDesc,'0' as IsPackage,HisOrderInfo.UID as OrderID,HisOrderInfo.OrderCode,ztdish.HuaCaiNum   "
							 + " FROM HisOrderZhuoTaiDish ztdish with(nolock)  "
							 + " INNER JOIN HisOrderInfo with(nolock) on HisOrderInfo.UID =ztdish.OrderID  "
							 + " INNER JOIN HisOrderZhuoTai orderzt with(nolock) ON orderzt.OrderID=HisOrderInfo.UID  "
							 + " INNER JOIN BaseDishType with(nolock) on BaseDishType.UID=ztdish.DishTypeID  "
							 + " left join BaseZhuoTai zt  with(nolock) on orderzt.ZhuoTaiID=zt.UID "
                             + " left join BaseTingMianLouCeng tmlc  with(nolock) on tmlc.UID=zt.TMLCID "
							 + " WHERE ztdish.DishStatusID=1 AND IsHuaCai=0 AND (ztdish.DishNum+ztdish.DishZengSongNum)>0  AND (ztdish.DishNum+ztdish.DishZengSongNum)>0   "
							 + " AND ztdish.IsPackage=0 and ztdish.StoreID=" + Tools.CurrentUser.StoreID + "  AND ztdish.SongDanTime>'" + startTime + "'   "
							 + " AND ztdish.DishTypeID IN " + typeCondition + " AND ztdish.DishID NOT IN " + dishCondition + AddQueryCondition() + Common.GetTMLCCondition()
							 + " union "
							 + " SELECT orderzt.UID as ZTUID,dishpackage.DishID,dishpackage.DishName,dishpackage.ZuoFaNames,dishpackage.KouWeiNames, "
							 + " dishpackage.UnitName,dishpackage.AddTime,orderzt.ZhuoTaiName,dishpackage.IfHuaCai as IsHuaCai,dishpackage.DishTypeID, "
							 + " dishpackage.UID,((ztdish.DishNum+ztdish.DishZengSongNum)*(dishpackage.DishNum+dishpackage.DishZengSongNum)) as DishNum,isnull(dishpackage.SongDanTime, "
							 + " dishpackage.Addtime) as SongDanTime,HisOrderInfo.IsWaiMai,dishpackage.DishStatusDesc,'1' as IsPackage ,HisOrderInfo.UID as OrderID,HisOrderInfo.OrderCode,dishpackage.HuaCaiNum   "
							 + " FROM HisOrderZhuoTaiDish ztdish with(nolock)  "
							 + " INNER JOIN HisOrderPackageDishDetail dishpackage with(nolock) on ztdish.UID=dishpackage.OrderZhuoTaiDishID "
							 + " INNER JOIN HisOrderInfo with(nolock) on HisOrderInfo.UID =ztdish.OrderID  "
							 + " INNER JOIN HisOrderZhuoTai orderzt with(nolock) ON orderzt.OrderID=HisOrderInfo.UID  "
							 + " INNER JOIN BaseDishType with(nolock) on BaseDishType.UID=dishpackage.DishTypeID  "
							 + " left join BaseZhuoTai zt  with(nolock) on orderzt.ZhuoTaiID=zt.UID "
                             + " left join BaseTingMianLouCeng tmlc  with(nolock) on tmlc.UID=zt.TMLCID "
							 + " WHERE dishpackage.DishStatusID=1 AND dishpackage.IfHuaCai=0  AND ((ztdish.DishNum+ztdish.DishZengSongNum)+(dishpackage.DishNum+dishpackage.DishZengSongNum))>0  "
							 + " AND  ztdish.IsPackage=1 AND ((dishpackage.DishNum+dishpackage.DishZengSongNum)*(ztdish.DishNum+ztdish.DishZengSongNum))>0 and dishpackage.StoreID=" + Tools.CurrentUser.StoreID + "  AND dishpackage.SongDanTime>'" + startTime + "'   "
							 + " AND dishpackage.DishTypeID IN " + typeCondition + "  AND dishpackage.DishID NOT IN " + dishCondition + AddQueryCondition() + Common.GetTMLCCondition();

				string strSql = "";
				if (qiantaiMode == 0)  //中餐
				{
					string showDishForFinishPay = ConfigurationManager.AppSettings["showDishForFinishPay"];
					string sqlYJS = string.Empty;
					if ("1".Equals(showDishForFinishPay))
					{
						sqlYJS = " union " + sql;

					}

					strSql = " SELECT * FROM ( "
						   + " SELECT orderzt.UID as ZTUID,ztdish.DishID,ztdish.DishName,ztdish.ZuoFaNames,ztdish.KouWeiNames, "
						   + " ztdish.UnitName,ztdish.AddTime,orderzt.ZhuoTaiName,ztdish.IsHuaCai,ztdish.DishTypeID, "
						   + " ztdish.UID,(ztdish.DishNum+ztdish.DishZengSongNum) as DishNum,isnull(ztdish.SongDanTime, "
						   + " ztdish.Addtime) as SongDanTime,OrderInfo.IsWaiMai,ztdish.DishStatusDesc ,'0' as IsPackage,OrderInfo.UID as OrderID,OrderInfo.OrderCode,ztdish.HuaCaiNum  "
						   + " FROM OrderZhuoTaiDish ztdish with(nolock)  "
						   + " INNER JOIN OrderInfo with(nolock) on OrderInfo.UID =ztdish.OrderID  "
						   + " INNER JOIN OrderZhuoTai orderzt with(nolock) ON orderzt.OrderID=OrderInfo.UID  "
						   + " INNER JOIN BaseDishType with(nolock) on BaseDishType.UID=ztdish.DishTypeID  "
						   + " left join BaseZhuoTai zt  with(nolock) on orderzt.ZhuoTaiID=zt.UID "
                           + " left join BaseTingMianLouCeng tmlc  with(nolock) on tmlc.UID=zt.TMLCID "
						   + " WHERE ztdish.DishStatusID=1 AND IsHuaCai=0 AND (ztdish.DishNum+ztdish.DishZengSongNum)>0  AND (ztdish.DishNum+ztdish.DishZengSongNum)>0   "
						   + " AND ztdish.IsPackage=0 and ztdish.StoreID=" + Tools.CurrentUser.StoreID + "  AND ztdish.SongDanTime>'" + startTime + "'   "
						   + " AND ztdish.DishTypeID IN " + typeCondition + " AND ztdish.DishID NOT IN " + dishCondition + AddQueryCondition() + Common.GetTMLCCondition()
						   + " union "
						   + " SELECT orderzt.UID as ZTUID,dishpackage.DishID,dishpackage.DishName,dishpackage.ZuoFaNames,dishpackage.KouWeiNames, "
						   + " dishpackage.UnitName,dishpackage.AddTime,orderzt.ZhuoTaiName,dishpackage.IfHuaCai as IsHuaCai,dishpackage.DishTypeID, "
						   + " dishpackage.UID,((ztdish.DishNum+ztdish.DishZengSongNum)*(dishpackage.DishNum+dishpackage.DishZengSongNum)) as DishNum,isnull(dishpackage.SongDanTime, "
						   + " dishpackage.Addtime) as SongDanTime,OrderInfo.IsWaiMai,dishpackage.DishStatusDesc ,'1' as IsPackage,OrderInfo.UID as OrderID,OrderInfo.OrderCode,dishpackage.HuaCaiNum  "
						   + " FROM OrderZhuoTaiDish ztdish with(nolock)  "
						   + " INNER JOIN OrderPackageDishDetail dishpackage with(nolock) on ztdish.UID=dishpackage.OrderZhuoTaiDishID "
						   + " INNER JOIN OrderInfo with(nolock) on OrderInfo.UID =ztdish.OrderID  "
						   + " INNER JOIN OrderZhuoTai orderzt with(nolock) ON orderzt.OrderID=OrderInfo.UID  "
						   + " INNER JOIN BaseDishType with(nolock) on BaseDishType.UID=dishpackage.DishTypeID  "
						   + " left join BaseZhuoTai zt  with(nolock) on orderzt.ZhuoTaiID=zt.UID "
                           + " left join BaseTingMianLouCeng tmlc  with(nolock) on tmlc.UID=zt.TMLCID "
						   + " WHERE dishpackage.DishStatusID=1 AND dishpackage.IfHuaCai=0 AND ((dishpackage.DishNum+dishpackage.DishZengSongNum)*(ztdish.DishNum+ztdish.DishZengSongNum))>0 AND ((ztdish.DishNum+ztdish.DishZengSongNum)+(dishpackage.DishNum+dishpackage.DishZengSongNum))>0  "
						   + " AND  ztdish.IsPackage=1 and dishpackage.StoreID=" + Tools.CurrentUser.StoreID + "  AND dishpackage.SongDanTime>'" + startTime + "'   "
						   + " AND dishpackage.DishTypeID IN " + typeCondition + "  AND dishpackage.DishID NOT IN " + dishCondition + AddQueryCondition() + Common.GetTMLCCondition()
						   + sqlYJS
						   + " ) tableTmp ORDER BY AddTime asc ";
				}
				else
				{
					strSql = " SELECT * FROM ( " + sql + " ) tableTmp ORDER BY AddTime asc ";
				}

				DataTable table = DBHelper.ExeSqlForDataTable(strSql);
				orderZTDishList = EntityUtil.ToList<OrderAllZTDishModel>(table);
			}
			catch (Exception ex)
			{
				Log.WriteLog("frmDanXiagnMergeDishFixed 菜品合并 GetAllData错误信息:" + ex.ToString());
			}

			return orderZTDishList;
		}

		

		private void ShowDishs(List<BaseDishModel> dishList, List<OrderZTDishModel> orderZTDishList, List<OrderAllZTDishModel> orderAllZTDishList, List<OrderHuaDanPart> dishHuaDanPartList)
		{
			try
			{
				this.SuspendLayout();
				tableLayoutPanel1.SuspendLayout();

				for (int i = 0; i < mergeDishControls.Length; i++)
				{
					mergeDishControls[i].Reset();
				}

				int startIndex = CurrentPageNo * tableLayoutPanel1.RowCount * tableLayoutPanel1.ColumnCount;
				if (CurrentPageNo > 0)
					btnUp.Enabled = true;
				else
					btnUp.Enabled = false;

				int endIndex = startIndex + (tableLayoutPanel1.RowCount * tableLayoutPanel1.ColumnCount);
				if (endIndex > dishList.Count)
					endIndex = dishList.Count;

				if (endIndex < dishList.Count)
					btnDown.Enabled = true;
				else
					btnDown.Enabled = false;

				DateTime now = DateTime.Now;
				int j = 0;
				for (int i = startIndex; i < endIndex; i++)
				{
					BaseDishModel dishModel = dishList[i];
					string ZuoFaNames = "";
					string KouWeiNames = "";
					string UnitName = dishModel.UnitName;
					string DishID = dishModel.DishID;
					string DishName = dishModel.DishName;

					mergeDishControls[j].DishName = DishName;
					mergeDishControls[j].ZFKW = ZuoFaNames + " " + KouWeiNames;
					mergeDishControls[j].DishID = DishID;
					mergeDishControls[j].ZuoFa = ZuoFaNames;
					mergeDishControls[j].KouWei = KouWeiNames;
					mergeDishControls[j].UintName = UnitName;
					mergeDishControls[j].DishNum = "0 " + UnitName;
					decimal num = 0;
					if (orderZTDishList.Count > 0)
					{
						decimal yhNum = 0m;
						if (orderAllZTDishList.Count > 0)
						{
							var allDish = orderAllZTDishList.Where(p => p.DishID.Equals(DishID)).Select(p => p.UID).Distinct().ToList();
							for (int k = 0; k < allDish.Count; k++)
							{
								yhNum = yhNum + dishHuaDanPartList.Where(p => p.DishUID.Equals(allDish[k])).Select(p => p.HuaDanNum).Sum();
							}
						}

						num = orderZTDishList.Where(p => p.DishID.Equals(DishID)).Sum(p => p.DishNum) - yhNum;
						mergeDishControls[j].DishNum = (num).ToString("0.##") + UnitName;
					}

					mergeDishControls[j].ZhuoTaiNum = 0 + " 桌";
					if (orderAllZTDishList.Count > 0)
					{
						mergeDishControls[j].ZhuoTaiNum = orderAllZTDishList.Where(p => p.DishID.Equals(DishID)).Select(p => p.ZTUID).Distinct().ToList().Count + " 桌";
					}

					if (JudgeIsGuQing(DishID))
					{
						mergeDishControls[j].ChangeBackColorGQ(true);
					}
					else
					{
						mergeDishControls[j].ChangeBackColorGQ(false);
					}

					//数量大于0,改变数量的字体颜色
					mergeDishControls[j].ChangeDishNumFontColor(false);
					if (num > 0)
						mergeDishControls[j].ChangeDishNumFontColor(true);

					mergeDishControls[j].TimeOutChangeImg(false);
					if (orderAllZTDishList.Count > 0)
					{
						try
						{
							//使用这种效率高，通过orderAllZTDishList.Min(p => p.AddTime)效率太低
							var source = orderAllZTDishList.Where(p => p.DishID.Equals(DishID)).ToList();
							if (source.Count > 0)
							{
								DateTime dtMin = source[0].AddTime;
								for (int k = 0; k < source.Count; k++)
								{
									if (source[k].AddTime.Ticks < dtMin.Ticks)
										dtMin = source[k].AddTime;
								}

								TimeSpan delta = DateTime.Now - dtMin;
								double strDelta = delta.TotalMinutes;
								if (strDelta > alertTime)
								{
									mergeDishControls[j].TimeOutChangeImg(true);
								}
							}
						}
						catch (Exception ex)
						{
							Log.WriteLog("frmDanXiangMergeDishFixed ShowDishs 时间转换错误,错误原因:" + ex.ToString());
						}
					}

					if (!string.IsNullOrEmpty(mergeDishControls[j].DishID) && mergeDishControls[j].DishID.Equals(guQingModelClass.DishID) && mergeDishControls[j].ZFKW.Trim().Equals(guQingModelClass.ZFKW.Trim()))
						mergeDishControls[j].ChangeBackColor(true);

					j++;
				}

				if (orderAllZTDishList.Count > 0 && !string.IsNullOrEmpty(model.DishID))
				{
					List<OrderAllZTDishModel> sourceTmp = orderAllZTDishList.Where(p => p.DishID.Equals(model.DishID)).OrderBy(p => p.AddTime).ToList();
					ShowDishsDetail(sourceTmp);
				}
				else
				{
					ShowDishsDetail(new List<OrderAllZTDishModel>());
				}

				tableLayoutPanel1.ResumeLayout();
				this.ResumeLayout();
			}
			catch (Exception ex)
			{
				Log.WriteLog("ShowDishs 错误信息:" + ex.ToString());
			}
		}

		private void ShowDishsDetail(List<OrderAllZTDishModel> orderAllZTDishList)
		{
			try
			{
				List<OrderHuaDanPart> dishHuaDanPartList = Common.GetDishPartHuaDanData();

				this.SuspendLayout();
				tableLayoutPanel2.SuspendLayout();

				for (int i = 0; i < mergeDishDetailControl.Length; i++)
				{
					mergeDishDetailControl[i].Reset();
				}

				int startIndex = CurrentPageNoDetail * tableLayoutPanel2.RowCount * tableLayoutPanel2.ColumnCount;
				if (CurrentPageNoDetail > 0)
					btnUpDetail.Enabled = true;
				else
					btnUpDetail.Enabled = false;

				int endIndex = startIndex + (tableLayoutPanel2.RowCount * tableLayoutPanel2.ColumnCount);
				if (endIndex > orderAllZTDishList.Count)
					endIndex = orderAllZTDishList.Count;

				if (endIndex < orderAllZTDishList.Count)
					btnDownDetail.Enabled = true;
				else
					btnDownDetail.Enabled = false;

				DateTime now = DateTime.Now;
				int j = 0;
				for (int i = startIndex; i < endIndex; i++)
				{
					OrderAllZTDishModel dishObj = orderAllZTDishList[i];
					string ZuoFaNames = dishObj.ZuoFaNames;
					string KouWeiNames = dishObj.KouWeiNames;
					string UnitName = dishObj.UnitName;
					string DishID = dishObj.DishID;
					string DishName = dishObj.DishName;
					string ZTName = dishObj.ZhuoTaiName;
					string UID = dishObj.UID;
					string DishStatusDesc = dishObj.DishStatusDesc;

					mergeDishDetailControl[j].UID = UID;
					mergeDishDetailControl[j].DishName = DishName;
					mergeDishDetailControl[j].ZFKW = ZuoFaNames + " " + KouWeiNames;

					decimal num = dishObj.DishNum;
					if (dishHuaDanPartList.Count > 0)
					{
						num = num - dishHuaDanPartList.Where(p => p.DishUID.Equals(UID)).Sum(p => p.HuaDanNum);
					}
					mergeDishDetailControl[j].Count = num.ToString("0.##") + " " + UnitName;
					mergeDishDetailControl[j].ZhuoTaiName = ZTName;
					mergeDishDetailControl[j].DishStatusDesc = DishStatusDesc;

					TimeSpan delta = DateTime.Now - dishObj.SongDanTime;
					double strDelta = delta.TotalMinutes;
					string strTime = "(" + strDelta.ToString("f0") + "分钟)";
					mergeDishDetailControl[j].Time = strTime;
					if (dishPartList.Where(p => p.UID.Equals(UID)).ToList().Count() > 0)
					{
						mergeDishDetailControl[j].ChangeBackColor(true);
					}
					else
					{
						mergeDishDetailControl[j].ChangeBackColor(false);
					}
					if (dishObj.IsWaiMai)
					{
						mergeDishDetailControl[j].WaiMai = "(外卖)";
					}

					mergeDishDetailControl[j].TimeOutChangeImg(false);
					if (strDelta > alertTime)
					{
					 	mergeDishDetailControl[j].TimeOutChangeImg(true);
					}

					j++;
				}

				tableLayoutPanel2.ResumeLayout();
				this.ResumeLayout();
			}
			catch (Exception ex)
			{
				Log.WriteLog("ShowDishs 错误信息:" + ex.ToString());
			}
		}

		public void RefreshData()
		{
			LoadAllDish();
		}

		private void MergeDishControl_Click(object sender, EventArgs e)
		{
			try
			{
				dishPartList = new List<OrderAllZTDishModel>();
				CurrDishName = string.Empty;
				model = new MergeDishDetailModel();
				guQingModelClass = new GuQingModelClass();
				MergeDishControl ctl = sender as MergeDishControl;
				CurrentPageNoDetail = 0;

				string dishID = ctl.DishID;
				model.DishID = dishID;
				if (!string.IsNullOrEmpty(dishID))
				{
					string zuofa = ctl.ZuoFa;
					string kouwei = ctl.KouWei;
					string dishname = ctl.DishName;
					string unitname = ctl.UintName;

					model.ZuoFa = zuofa;
					model.KouWei = kouwei;
					model.DishName = dishname;
					model.UnitName = unitname;

					CurrDishName = dishname;

					#region //沽清
					string guQingModel = ConfigurationManager.AppSettings["guQingModel"];
					if (!string.IsNullOrEmpty(guQingModel) && !"0".Equals(guQingModel))
					{
						btnGuQing.Visible = true;
						grpColor.Visible = true;
						guQingModelClass.DishID = dishID;
						guQingModelClass.DishName = dishname;
						guQingModelClass.ZFKW = zuofa + " " + kouwei;

						if (orderGuQingTable.Rows.Count > 0)
						{
							var sourceTmp = orderGuQingTable.Select("DishID='" + dishID + "'");
							if (sourceTmp.Count() > 0)
							{
								btnGuQing.Text = "取消沽清";
							}
							else
							{
								btnGuQing.Text = "沽清";
							}
						}
						else
						{
							btnGuQing.Text = "沽清";
						}
					}
					else
					{
						btnGuQing.Visible = false;
						grpColor.Visible = false;
					}
					#endregion

					if (orderAllZTDishList.Count > 0)
					{
						var sourceTmp = orderAllZTDishList.Where(p => p.DishID.Equals(dishID)).OrderBy(p => p.AddTime).ToList();
						ShowDishsDetail(sourceTmp);
					}
					else
					{
						ShowDishsDetail(new List<OrderAllZTDishModel>());
					}
				}

				ChangeBackColorForGQ();
			}
			catch (Exception ex)
			{
				Log.WriteLog("MergeDishControl_Click 错误信息:" + ex.ToString());
			}
		}

		private void MergeDishDetailControl_Click(object sender, EventArgs e)
		{
			MergeDishDetailControl ctl = sender as MergeDishDetailControl;
			string uid = ctl.UID;
			if (!string.IsNullOrEmpty(uid))
			{
				OrderAllZTDishModel obj = dishPartList.Where(p => p.UID.Equals(uid)).FirstOrDefault();
				if (!Object.Equals(obj, null) && !string.IsNullOrEmpty(obj.UID))
				{
					dishPartList.Remove(obj);
					ctl.ChangeBackColor(false);
				}
				else
				{
					OrderAllZTDishModel save = orderAllZTDishList.Where(p => p.UID.Equals(uid)).FirstOrDefault();
					if (!object.Equals(save, null))
					{
						dishPartList.Add(save);
						ctl.ChangeBackColor(true);
					}
				}
			}

			if (dishPartList.Count <= 1)
				btnPartHuaDan.Enabled = true;
			else
				btnPartHuaDan.Enabled = false;
		}

		private void MergeDishDetailControl_DoubleClick(object sender, EventArgs e)
		{
			MergeDishDetailControl ctl = sender as MergeDishDetailControl;
			string uid = ctl.UID;
			if (!string.IsNullOrEmpty(uid))
			{
				OrderAllZTDishModel obj = orderAllZTDishList.Where(p => p.UID.Equals(uid)).FirstOrDefault();
				List<OrderAllZTDishModel> list = new List<OrderAllZTDishModel>();
				list.Add(obj);

				HuaDan(list);
			}
		}

		private void HuaDan(List<OrderAllZTDishModel> paramDishPartList)
		{
			try
			{
				StringBuilder builder = new StringBuilder();
				string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
				foreach (OrderAllZTDishModel obj in paramDishPartList)
				{
					builder.Append("UPDATE OrderZhuoTaiDish SET IsHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE UID='" + obj.UID + "' ").Append("\r\n")
						.Append("UPDATE HisOrderZhuoTaiDish SET IsHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE UID='" + obj.UID + "' ").Append("\r\n");

					builder.Append("UPDATE OrderPackageDishDetail SET IfHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE UID='" + obj.UID + "' ").Append("\r\n")
						.Append("UPDATE HisOrderPackageDishDetail SET IfHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE UID='" + obj.UID + "' ").Append("\r\n");
				}

				List<OrderHuaDanPart> dishHuaDanPartList = Common.GetDishPartHuaDanData();
				for (int i = 0; i < paramDishPartList.Count; i++)
				{
					OrderAllZTDishModel obj = paramDishPartList[i];
					var yhTmp = dishHuaDanPartList.Where(p => p.DishUID.Equals(obj.UID)).Sum(p => p.HuaDanNum);
					obj.DishNum = obj.DishNum - yhTmp;
				}

				InsertOrderHuaDanPart(paramDishPartList, builder);

				string strSql = builder.ToString();

				if (!DBHelper.ExecuteNonQuery(strSql))
				{
					MessageBox.Show("划单失败！");
					return;
				}

				txtHuaCaiNum.Clear();
				txtHuaCaiNum.Focus();

				LoadAllDish();
				if (orderAllZTDishList.Count > 0)
				{
					for (int i = 0; i < orderAllZTDishList.Count; i++)
					{
						if (paramDishPartList.Where(p => p.UID.Equals(orderAllZTDishList[i].UID)).ToList().Count > 0)
						{
							orderAllZTDishList.Remove(orderAllZTDishList[i]);
						}
					}

					var sourceTmp = orderAllZTDishList.Where(p => p.DishID.Equals(model.DishID)).OrderBy(p => p.AddTime).ToList();
					if (sourceTmp.Count <= 0)
					{
						CurrentPageNoDetail = 0;
						model = new MergeDishDetailModel();
						guQingModelClass = new GuQingModelClass();
					}

					ShowDishsDetail(sourceTmp);
				}

				List<string> uids = paramDishPartList.Select(p => p.UID).ToList();

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
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void InsertOrderHuaDanPart(List<OrderAllZTDishModel> paramDishPartList, StringBuilder builder)
		{
			DateTime now = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
			for (int i = 0; i < paramDishPartList.Count; i++)
			{
				OrderAllZTDishModel obj = paramDishPartList[i];

				var sqlInsert = " INSERT INTO OrderHuaDanPart(UID,GroupID,StoreID,OrderID,OrderCode "
				  + " ,ZTUID,ZTName,DishUID,DishID,DishName "
				  + " ,HuaDanNum,UnitName,IsPackage,IsPackageDetail "
				  + " ,HuaDanTime,AddUser,AddTime,UpdateUser,UpdateTime) "
				  + " VALUES('" + Guid.NewGuid().ToString("N") + "'," + Tools.CurrentUser.GroupID + "," + Tools.CurrentUser.StoreID + ",'" + obj.OrderID + "','" + obj.OrderCode + "' "
				  + " ,'" + obj.ZTUID + "','" + obj.ZhuoTaiName + "','" + obj.UID + "','" + obj.DishID + "','" + obj.DishName + "' "
				  + " ," + obj.DishNum + ",'" + obj.UnitName + "'," + obj.IsPackage + "," + obj.IsPackage + " "
				  + " ,'" + now + "','" + Tools.CurrentUser.UID + "','" + now + "','" + Tools.CurrentUser.UID + "','" + now + "') ";
				builder.Append(sqlInsert).Append("\r\n");
			}

		}

		private class MergeDishDetailModel
		{
			public string DishID { get; set; }
			public string DishName { get; set; }
			public string ZuoFa { get; set; }
			public string KouWei { get; set; }
			public string UnitName { get; set; }
		}

		public class GuQingModelClass
		{
			public string DishID { get; set; }
			public string DishName { get; set; }
			public string ZFKW { get; set; }
		}

		private void btnSetup_Click(object sender, EventArgs e)
		{
			new frmSetup().ShowDialog(this);
		}

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			LoadDishType();
			RefreshData();
		}


		#region//类别加载
		private void LoadDishType()
		{
			try
			{
				this.panel2.Controls.Clear();
				int wCount = (this.panel2.Width - 200) / btnDishTypeWidth;//去除全部之后，行存的个数
				int width = this.panel2.Width / wCount;

				//清空
				btnDishTypeList = new List<Button>();

				SetDishTypeBtn("全部", "全部", width, 0);

				GetSetupDishInfo();
				string strDishTypes = ConfigurationManager.AppSettings["dishtypes"];
				string sql = "SELECT * FROM BaseDishType WHERE UID IN " + typeCondition + " AND IsEnable=1 and IsPackage=0 ORDER BY PrintOrder ASC";
				DataTable dtSource = DBHelper.ExeSqlForDataTable(sql);
				if (dtSource.Rows.Count > 0)
				{
					if (dtSource.Rows.Count <= wCount)
					{
						//按钮个数小于行最大数，不需要combox控件
						for (int i = 1; i <= dtSource.Rows.Count; i++)
						{
							SetDishTypeBtn(dtSource.Rows[i - 1]["UID"].ToString(), dtSource.Rows[i - 1]["TypeName"].ToString(), width, i);
						}
					}
					else
					{
						for (int i = 1; i <= dtSource.Rows.Count; i++)
						{
							if (i < wCount - 1)
							{
								SetDishTypeBtn(dtSource.Rows[i - 1]["UID"].ToString(), dtSource.Rows[i - 1]["TypeName"].ToString(), width, i);
							}
							else
							{
								combox = new ComboBox();
								combox.Name = "cmbDishType";
								combox.Height = 80;
								combox.Width = width;
								combox.Font = new System.Drawing.Font("微软雅黑", 18, FontStyle.Regular);
								combox.Location = new Point(width * i, 6);

								combox.DropDownStyle = ComboBoxStyle.DropDownList;

								if ("标题".Equals("标题"))
								{
									ComboBoxItem items = new ComboBoxItem();
									items.Text = "更多";
									items.Value = "更多";
									combox.Items.Add(items);
								}

								for (int j = wCount - 2; j < dtSource.Rows.Count; j++)
								{
									ComboBoxItem items = new ComboBoxItem();
									items.Text = dtSource.Rows[j]["TypeName"].ToString();
									items.Value = dtSource.Rows[j]["UID"].ToString();
									combox.Items.Add(items);
								}

								//默认显示第一条
								combox.SelectedIndex = cmbIndex;

								//combox注册事件
								CmbRegesterEventHandler handler = new CmbRegesterEventHandler(RedesterEventHandlerForCombox);
								handler.BeginInvoke(combox, null, null);

								panel2.Controls.Add(combox);
								break;
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Log.WriteLog("frmDanXiangMergeDish LoadDishType 错误原因:" + ex.ToString());
			}

			SetDishTypeBackColor();
		}

		/// <summary>
		/// 设置类别按钮
		/// </summary>
		/// <param name="uid">UID</param>
		/// <param name="typeName">类别名称</param>
		/// <param name="width">按钮宽度</param>
		/// <param name="i">计算按钮所在位置</param>
		private void SetDishTypeBtn(string uid, string typeName, int width, int i)
		{
			Button button = new Button();
			button.Name = "btn_" + uid;
			button.Text = string.Concat(new string[] { typeName });
			button.Tag = string.Concat(new string[] { uid });
			button.Width = width;
			button.Height = 48;
			button.BackColor = Color.FromArgb(255, 64, 64, 64);
			button.ForeColor = Color.White;
			button.Font = new System.Drawing.Font("微软雅黑", 12, FontStyle.Regular);
			button.Location = new Point(width * i, 2);
			BtnRegesterEventHandler handler = new BtnRegesterEventHandler(RedesterEventHandler);
			handler.BeginInvoke(button, null, null);
			btnDishTypeList.Add(button);
			panel2.Controls.Add(button);
		}

		/// <summary>
		/// 设置全部默认颜色
		/// </summary>
		private void SetDishTypeBackColor()
		{
			try
			{
				if (string.IsNullOrEmpty(CurrDishTypeUID) && btnDishTypeList.Count >= 1)
				{
					btnDishTypeList[0].BackColor = Color.PaleVioletRed;
				}
				else if (!string.IsNullOrEmpty(CurrDishTypeUID) && btnDishTypeList.Count >= 1)
				{
					for (int i = 0; i < btnDishTypeList.Count; i++)
					{
						if (btnDishTypeList[i].Tag.ToString().Equals(CurrDishTypeUID))
						{
							btnDishTypeList[i].BackColor = Color.PaleVioletRed;
							break;
						}
					}
				}
			}
			catch (Exception ex)
			{
				Log.WriteLog("frmDanXiangMergeDish SetDishTypeBackColor 错误信息:" + ex.ToString());
			}
		}

		public delegate void BtnRegesterEventHandler(Button btn);
		public void RedesterEventHandler(Button btn)
		{
			btn.Click += new System.EventHandler(button_Click);
		}

		private void button_Click(object sender, EventArgs e)
		{
			try
			{
				CurrentPageNo = 0;
				guQingModelClass = new GuQingModelClass();
			
				//combox默认显示第一项
				if (combox.Items.Count > 0)
					combox.SelectedIndex = 0;
			}
			catch (Exception ex)
			{
				Log.WriteLog("frmDanXiangMergeDish 菜品类别 button_Click 错误原因:" + ex.ToString());
			}

			try
			{
				//所有菜品类别颜色置为默认颜色
				if (btnDishTypeList.Count > 0)
				{
					for (int i = 0; i < btnDishTypeList.Count; i++)
					{
						btnDishTypeList[i].BackColor = Color.FromArgb(255, 64, 64, 64);
					}
				}

				Button button = (Button)sender;
				string arrStr = button.Tag.ToString();
				if (!string.IsNullOrEmpty(arrStr))
				{
					button.BackColor = Color.PaleVioletRed;
					CurrDishTypeUID = arrStr;
					RefreshData();
					cmbIndex = 0;
				}
			}
			catch (Exception ex)
			{
				Log.WriteLog("frmDanXiangMergeDish button_Click 错误信息:" + ex.ToString());
			}

		}

		public delegate void CmbRegesterEventHandler(ComboBox btn);
		public void RedesterEventHandlerForCombox(ComboBox cmb)
		{
			cmb.SelectedIndexChanged += new System.EventHandler(comboBox_SelectedIndexChanged);
		}

		private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				CurrentPageNo = 0;
				guQingModelClass = new GuQingModelClass();
			
				if (btnDishTypeList.Count > 0)
				{
					for (int i = 0; i < btnDishTypeList.Count; i++)
					{
						btnDishTypeList[i].BackColor = Color.FromArgb(255, 64, 64, 64);
					}
				}

				string value = ((ComboBoxItem)this.combox.SelectedItem).Value as string;
				if (!value.Equals("更多"))
				{
					CurrDishTypeUID = ((ComboBoxItem)this.combox.SelectedItem).Value as string;
					RefreshData();
					cmbIndex = this.combox.SelectedIndex;
				}
			}
			catch (Exception ex)
			{
				Log.WriteLog("frmDanXiangMergeDish comboBox_SelectedIndexChanged 错误信息:" + ex.ToString());
			}
		}

		/// <summary>
		/// combox菜品类别赋值
		/// </summary>
		public class ComboBoxItem
		{
			private string _text = null;
			private object _value = null;
			public string Text { get { return this._text; } set { this._text = value; } }
			public object Value { get { return this._value; } set { this._value = value; } }
			public override string ToString()
			{
				return this._text;
			}
		}

		/// <summary>
		/// 添加菜品类别的查询条件
		/// </summary>
		/// <returns></returns>
		private string AddQueryCondition()
		{
			if (!string.IsNullOrEmpty(CurrDishTypeUID) && !CurrDishTypeUID.Equals("全部"))
			{
				return " and BaseDishType.UID='" + CurrDishTypeUID + "'";
			}

			return "";
		}
		#endregion

		#region //自定义方法

		public void StartMonitor()
		{
			Common.ajudgeLocalTimeBaseServer();

			var result = Common.CreateDB();
			if (result == "fail")
			{
				MessageBox.Show("创建表【OrderHuaDan】和【HisOrderHuaDan】失败！");
				return;
			}

			var result1 = Common.CreatePartHuaDanDB();
			if (result1 == "fail")
			{
				MessageBox.Show("创建表【OrderHuaDanPart】失败！");
				return;
			}

			try
			{
				string sql = "delete from OrderHuaDanPart where AddTime<='" + DateTime.Now.AddDays(-2) + "'";
				DBHelper.ExecuteNonQuery(sql);
			}
			catch (Exception ex)
			{

			}

			LoadAllDish();
			timer1.Start();
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

		/// <summary>
		/// 获取所有沽清数据
		/// </summary>
		private void GetOrderGuQingAllData()
		{
			string guQingModel = ConfigurationManager.AppSettings["guQingModel"];
			if (!string.IsNullOrEmpty(guQingModel) && !"0".Equals(guQingModel))
			{
				orderGuQingTable = CommonGuQing.GetOrderGuQingAllData();
			}
		}

		private bool JudgeIsGuQing(string dishID)
		{
			bool result = false;
			if (orderGuQingTable.Rows.Count > 0)
			{
				var source = orderGuQingTable.Select("DishID='" + dishID + "'");
				if (source.Count() > 0)
					result = true;
			}
			return result;
		}

		private void ChangeBackColorForGQ()
		{
			#region//选中效果
			//int startIndex = CurrentPageNo * tableLayoutPanel1.RowCount * tableLayoutPanel1.ColumnCount;
			//int endIndex = startIndex + (tableLayoutPanel1.RowCount * tableLayoutPanel1.ColumnCount);

			int startIndex = 0 ;
			int endIndex = tableLayoutPanel1.RowCount * tableLayoutPanel1.ColumnCount;

			for (int i = startIndex; i < endIndex; i++)
			{
				if (JudgeIsGuQing(mergeDishControls[i].DishID))
				{
					mergeDishControls[i].ChangeBackColorGQ(true);
				}
				else
				{
					mergeDishControls[i].ChangeBackColorGQ(false);
				}
				string zfkwTmp = mergeDishControls[i].ZFKW + " " + mergeDishControls[i].KouWei;
				if (!string.IsNullOrEmpty(mergeDishControls[i].DishID) && mergeDishControls[i].DishID.Equals(guQingModelClass.DishID) && zfkwTmp.Trim().Equals(guQingModelClass.ZFKW.Trim()))
					mergeDishControls[i].ChangeBackColor(true);

				try
				{
					mergeDishControls[i].ChangeDishNumFontColor(false);
					var strNum = mergeDishControls[i].DishNum.Replace(mergeDishControls[i].UintName, "");
					if (Convert.ToDecimal(strNum) > 0)
						mergeDishControls[i].ChangeDishNumFontColor(true);
				}
				catch (Exception ex)
				{ }
			}
			#endregion
		}

		#endregion

		private void btnUp_Click(object sender, EventArgs e)
		{
			guQingModelClass = new GuQingModelClass();
			CurrentPageNo--;
			LoadAllDish();
		}

		private void btnDown_Click(object sender, EventArgs e)
		{
			guQingModelClass = new GuQingModelClass();
			CurrentPageNo++;
			LoadAllDish();
		}

		private void btnUpDetail_Click(object sender, EventArgs e)
		{
			CurrentPageNoDetail--;

			if (!string.IsNullOrEmpty(model.DishID) && orderAllZTDishList.Count > 0)
			{
				List<OrderAllZTDishModel> sourceTmp = orderAllZTDishList.Where(p => p.DishID.Equals(model.DishID)).OrderBy(p => p.AddTime).ToList();
				ShowDishsDetail(sourceTmp);
			}
			else
			{
				ShowDishsDetail(new List<OrderAllZTDishModel>());
			}
		}

		private void btnDownDetail_Click(object sender, EventArgs e)
		{
			CurrentPageNoDetail++;
			if (!string.IsNullOrEmpty(model.DishID) && orderAllZTDishList.Count > 0)
			{
				List<OrderAllZTDishModel> sourceTmp = orderAllZTDishList.Where(p => p.DishID.Equals(model.DishID)).OrderBy(p => p.AddTime).ToList();
				ShowDishsDetail(sourceTmp);
			}
			else
			{
				ShowDishsDetail(new List<OrderAllZTDishModel>());
			}
		}

		private void btnPartHuaDan_Click(object sender, EventArgs e)
		{
			if (dishPartList.Count <= 0)
			{
				MessageBox.Show("未选菜品,不能划单!");
				return;
			}

			if (dishPartList.Count > 1)
			{
				MessageBox.Show("部分划单只能操作单个品项,不能多菜品同时操作!");
				return;
			}

			frmHuaDanPart frm = new frmHuaDanPart(dishPartList[0]);
			if (frm.ShowDialog() == DialogResult.OK)
			{
				dishPartList = new List<OrderAllZTDishModel>();
				//CurrDishName = string.Empty;
				LoadAllDish();
			}
		}

		private void btnBatchHuaDan_Click(object sender, EventArgs e)
		{
			if (dishPartList.Count <= 0)
			{
				MessageBox.Show("未选菜品,不能划单!");
				return;
			}

			if (dishPartList.Count > 0)
			{
				frmTip frm = new frmTip(CurrDishName + "(共计:" + dishPartList.Count + ")");
				if (frm.ShowDialog() == DialogResult.OK)
				{
					HuaDan(dishPartList);
					dishPartList = new List<OrderAllZTDishModel>();
					//CurrDishName = string.Empty;
					LoadAllDish();
				}
			}
		}

		private void btnAllHuaDan_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(model.DishID) && orderAllZTDishList.Count > 0)
			{
				frmTip frm = new frmTip("是否全部划单!");
				if (frm.ShowDialog() == DialogResult.OK)
				{
					var sourceTmp = orderAllZTDishList.Where(p => p.DishID.Equals(model.DishID)).OrderBy(p => p.AddTime).ToList();

					HuaDan(sourceTmp);

					guQingModelClass = new GuQingModelClass();

					orderAllZTDishList = new List<OrderAllZTDishModel>();
					CurrDishName = string.Empty;
					LoadAllDish();
				}
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			RefreshData();
		}

		private void btnQuery_Click(object sender, EventArgs e)
		{
			frmQueryPart frm = new frmQueryPart("frmDanXiangMergeDishFixed");
			frm.Owner = this;
			frm.ShowDialog();
		}

		private void btnGuQing_Click(object sender, EventArgs e)
		{
			try
			{
				if (!string.IsNullOrEmpty(guQingModelClass.DishID))
				{
					string sqlDish = "select UID,IsPackage from BaseDish where UID='" + guQingModelClass.DishID + "' ";
					var dishSource = DBHelper.ExeSqlForDataTable(sqlDish);
					if (dishSource.Rows.Count > 0)
					{
						bool isPackage = (bool)dishSource.Rows[0]["IsPackage"];
						if (isPackage)
						{
							MessageBox.Show("套餐不能沽清！");
							return;
						}
					}

					string guQingModel = ConfigurationManager.AppSettings["guQingModel"]; //是否快速沽清
					if (!object.Equals(guQingModel, null) && "1".Equals(guQingModel))
					{
						if (dishSource.Rows.Count > 0)
						{
							//快速沽清模式
							string quickGuQingTip = ConfigurationManager.AppSettings["quickGuQingTip"]; //快速沽清是否提醒
							if (!object.Equals(quickGuQingTip, null) && "1".Equals(quickGuQingTip))
							{
								if (DialogResult.Yes == MessageBox.Show("菜品【" + guQingModelClass.DishName + "】确定要" + btnGuQing.Text.Trim() + "吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
								{

									if (!CommonGuQing.GuQingOpreate(btnGuQing.Text.Trim(), guQingModelClass.DishName, dishSource.Rows[0][0].ToString(), "", 0))
									{
										MessageBox.Show("沽清失败！");
									}
									else
									{
										RefreshGuQing();
									}
								}
							}
							else
							{
								//直接操作
								if (!CommonGuQing.GuQingOpreate(btnGuQing.Text.Trim(), guQingModelClass.DishName, dishSource.Rows[0][0].ToString(), "", 0))
								{
									MessageBox.Show("沽清失败！");
								}
								else
								{
									RefreshGuQing();
								}
							}
						}
					}
					else if (!object.Equals(guQingModel, null) && "2".Equals(guQingModel))
					{
						//普通沽清模式
						frmGuQing frmgq = new frmGuQing(btnGuQing.Text.Trim(), guQingModelClass.DishName, dishSource.Rows[0][0].ToString(), false);
						if (frmgq.ShowDialog() == DialogResult.OK)
						{
							RefreshGuQing();
						}
					}
				}
				else
				{
					MessageBox.Show("请先选择要沽清的商品！");
				}
			}
			catch (Exception ex)
			{
				Log.WriteLog("frmDanXiangMergeDishFixed btnGuQing_Click错误信息:" + ex.ToString());
			}
		}

		private void RefreshGuQing()
		{
			if (btnGuQing.Text.Trim().Equals("取消沽清"))
				btnGuQing.Text = "沽清";
			else if (btnGuQing.Text.Trim().Equals("沽清"))
				btnGuQing.Text = "取消沽清";

			GetOrderGuQingAllData();

			ChangeBackColorForGQ();
			CommonGuQing.uploadGuQingData();

		}

		private void label1_Click(object sender, EventArgs e)
		{
			frmGuQingList frm = new frmGuQingList();
			if (frm.ShowDialog() == DialogResult.OK)
			{
				RefreshData();
			}
		}

		private void txtHuaCaiNum_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Enter)
				{
					if (string.IsNullOrEmpty(txtHuaCaiNum.Text.Trim()))
						return;

					StringBuilder builder = new StringBuilder();
					string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
					List<OrderAllZTDishModel> source = orderAllZTDishList.Where(p => p.HuaCaiNum.Equals(txtHuaCaiNum.Text.Trim())).ToList();
					HuaDan(source);
				}
			}
			catch (Exception ex)
			{
				Log.WriteLog("frmDanXiangMergeDishFixed txtHuaCaiNum_KeyDown 错误信息:" + ex.ToString());
			}
		}




	}
}
