using HuaDan.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuaDan
{
	public partial class frmZTDish : Form
	{
		int ZTCurrentPageNo = 0;
		int DishCurrentPageNo = 0;
		DateTime startTime = DateTime.Now;//餐别开始时间
		public static double alertTime = 30;
		string ZTUID = string.Empty; //存放选择的桌台OrderZhuoTai的主键UID
		string ZTUIDArr = string.Empty;
		DataTable orderGuQingTable = new DataTable(); //存放沽清的数据源
		bool handMode = false;
		ZTDishControl[] ZTDishControls;
		/// <summary>
		/// 是否选择全部桌台
		/// </summary>
		bool IsChooseAllZhuoTai = false;

		int leftTableLayoutPaneHeight = 1;
		int leftTableLayoutPaneWidth = 1;
		int rightTableLayoutPaneHeight = 1;
		int rightTableLayoutPaneWidth = 1;

		public frmZTDish()
		{
			InitializeComponent();

			this.WindowState = FormWindowState.Maximized;
			this.Top = 0;
			this.Left = 0;
			this.Width = Screen.PrimaryScreen.Bounds.Width;
			this.Height = Screen.PrimaryScreen.Bounds.Height;

			leftTableLayoutPaneHeight = this.tableLayoutPanel1.Height;
			leftTableLayoutPaneWidth = this.tableLayoutPanel1.Width;
			rightTableLayoutPaneHeight = this.tableLayoutPanel2.Height;
			rightTableLayoutPaneWidth = this.tableLayoutPanel2.Width;

			ZTDishControl ctl = new ZTDishControl();

			int wCount = rightTableLayoutPaneWidth / 200;
			int hCount = rightTableLayoutPaneHeight / 100;
			int ctlWidth = rightTableLayoutPaneWidth / wCount;
			int ctlHeight = rightTableLayoutPaneHeight / hCount;

			tableLayoutPanel2.ColumnCount = wCount;
			tableLayoutPanel2.RowCount = hCount;

			ZTDishControls = new ZTDishControl[wCount * hCount];

			for (int i = 0; i < ZTDishControls.Length; i++)
			{
				ZTDishControls[i] = new ZTDishControl();
				ZTDishControls[i].Width = ctlWidth;
				ZTDishControls[i].Height = ctlHeight;

				ZTDishControls[i].Reset();

				ControlRegesterEventHandler handler = new ControlRegesterEventHandler(CTLRegesterEventHandler);
				handler.BeginInvoke(ZTDishControls[i], null, null);

				tableLayoutPanel2.Controls.Add(ZTDishControls[i]);

			}
		}

		private void frmZTDish_Load(object sender, EventArgs e)
		{
			try
			{
				setOemInfo();
				string isStartServer = ConfigurationManager.AppSettings["IsStartCallNumServer"];
				if ("1".Equals(isStartServer))
					CallNumServer.Start();
			}
			catch
			{
				MessageBox.Show("开启叫号服务器失败，请检查端口号是否被占用，重新设置后，重新登录用户，可重新连接叫号服务器。");
			}

			RefreshData();
		}

		public void RefreshData()
		{
			GetOrderGuQingAllData();
			LoadAllZhuoTai();      //顺序不可调-优先级：1
			LoadAllZhuoTaiDish();  //顺序不可调-优先级：2
			ChongZhiButton();      //顺序不可调-优先级：3
			txtHuaCaiNum.Focus();
			CallNumServer.sendBeiCanData(false);
		}

		public void LoadAllZhuoTai()
		{
			startTime = Common.InitCanBie();
			try
			{
				string strAlertTime = ConfigurationManager.AppSettings["alerttime"];
				if (!string.IsNullOrEmpty(strAlertTime))
					alertTime = double.Parse(strAlertTime);

				int qiantaiMode = 0;

				string strQiantaiMode = ConfigurationManager.AppSettings["qiantaimode"];

				if (!string.IsNullOrEmpty(strQiantaiMode))
					qiantaiMode = int.Parse(strQiantaiMode);

				string strDishTypes = ConfigurationManager.AppSettings["dishtypes"];
				string strDishes = ConfigurationManager.AppSettings["dishes"];

				string typeCondition = "";
				string dishCondition = "";

				if (string.IsNullOrEmpty(strDishTypes))
					typeCondition = "('')";
				else
					typeCondition = "('" + strDishTypes.Replace(",", "','") + "')";

				if (string.IsNullOrEmpty(strDishes))
					dishCondition = "('')";
				else
					dishCondition = "('" + strDishes.Replace(",", "','") + "')";

				string strSql = "";
				if (qiantaiMode == 0)  //中餐
				{
					string showDishForFinishPay = ConfigurationManager.AppSettings["showDishForFinishPay"];
					string sqlYJS = string.Empty;
					if ("1".Equals(showDishForFinishPay))
					{
						sqlYJS = " UNION ALL "
							   + " SELECT HisOrderZhuoTai.UID,HisOrderZhuoTai.ZhuoTaiName,HisOrderZhuoTai.AddTime "
							   + " FROM HisOrderZhuoTai with(nolock) INNER JOIN HisOrderZhuoTaiDish with(nolock) on HisOrderZhuoTai.OrderID=HisOrderZhuoTaiDish.OrderID "
							   + " WHERE HisOrderZhuoTaiDish.DishStatusID=1 AND HisOrderZhuoTaiDish.IsHuaCai=0 AND HisOrderZhuoTaiDish.StoreID=" + Tools.CurrentUser.StoreID + " AND HisOrderZhuoTaiDish.SongDanTime>'" + startTime + "'  "
							   + " AND HisOrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND (HisOrderZhuoTaiDish.DishNum+HisOrderZhuoTaiDish.DishZengSongNum)>0  AND HisOrderZhuoTaiDish.DishID NOT IN " + dishCondition
							   + " AND HisOrderZhuoTai.OrderID NOT IN(select OrderID From  OrderWaiMaiAddress with(nolock) where AddTime >'" + startTime + "' ) "
							   + " AND HisOrderZhuoTai.OrderID NOT IN(select OrderID From  HisOrderWaiMaiAddress with(nolock) where AddTime >'" + startTime + "' ) ";
					}

					strSql = " SELECT DISTINCT * FROM ( "
						   + " SELECT OrderZhuoTai.UID,OrderZhuoTai.ZhuoTaiName,OrderZhuoTai.AddTime "
						   + " FROM OrderZhuoTai with(nolock) INNER JOIN OrderZhuoTaiDish with(nolock) on OrderZhuoTai.OrderID=OrderZhuoTaiDish.OrderID "
						   + " WHERE OrderZhuoTaiDish.DishStatusID=1 AND OrderZhuoTaiDish.IsHuaCai=0 AND OrderZhuoTaiDish.StoreID=" + Tools.CurrentUser.StoreID + " AND OrderZhuoTaiDish.SongDanTime>'" + startTime + "'  "
						   + " AND OrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND (OrderZhuoTaiDish.DishNum+OrderZhuoTaiDish.DishZengSongNum)>0  AND OrderZhuoTaiDish.DishID NOT IN " + dishCondition
						   + " AND OrderZhuoTai.OrderID NOT IN(select OrderID From  OrderWaiMaiAddress with(nolock) where AddTime >'" + startTime + "' ) "
						   + " AND OrderZhuoTai.OrderID NOT IN(select OrderID From  HisOrderWaiMaiAddress with(nolock) where AddTime >'" + startTime + "' ) "
						   + " UNION ALL "
						   + " SELECT OrderZhuoTai.UID,OrderZhuoTai.ZhuoTaiName,OrderZhuoTai.AddTime "
						   + " FROM OrderZhuoTai with(nolock) INNER JOIN OrderZhuoTaiDish with(nolock) on OrderZhuoTai.OrderID=OrderZhuoTaiDish.OrderID "
						   + " INNER JOIN OrderWaiMaiAddress with(nolock) ON OrderWaiMaiAddress.OrderID=OrderZhuoTaiDish.OrderID "
						   + " WHERE OrderZhuoTaiDish.DishStatusID=1 AND OrderZhuoTaiDish.IsHuaCai=0 AND (OrderZhuoTaiDish.DishNum+OrderZhuoTaiDish.DishZengSongNum)>0 AND OrderZhuoTaiDish.StoreID=" + Tools.CurrentUser.StoreID + " AND OrderZhuoTaiDish.SongDanTime>'" + startTime + "' "
						   + " AND OrderZhuoTaiDish.DishTypeID IN " + typeCondition + "  AND OrderZhuoTaiDish.DishID NOT IN " + dishCondition
						   + " AND (OrderWaiMaiAddress.Source=11 or OrderWaiMaiAddress.Source=12 or OrderWaiMaiAddress.Source=13 or OrderWaiMaiAddress.Source=0) and OrderWaiMaiAddress.HasAccept=1 "
						   + " UNION ALL "
						   + " SELECT HisOrderZhuoTai.UID,HisOrderZhuoTai.ZhuoTaiName,HisOrderZhuoTai.AddTime "
						   + " FROM HisOrderZhuoTai with(nolock) INNER JOIN HisOrderZhuoTaiDish with(nolock) on HisOrderZhuoTai.OrderID=HisOrderZhuoTaiDish.OrderID "
						   + " INNER JOIN HisOrderWaiMaiAddress with(nolock) ON HisOrderWaiMaiAddress.OrderID=HisOrderZhuoTaiDish.OrderID "
						   + " WHERE HisOrderZhuoTaiDish.DishStatusID=1 AND IsHuaCai=0 AND (HisOrderZhuoTaiDish.DishNum+HisOrderZhuoTaiDish.DishZengSongNum)>0 AND HisOrderZhuoTaiDish.StoreID=" + Tools.CurrentUser.StoreID + " AND HisOrderZhuoTaiDish.SongDanTime>'" + startTime + "' "
						   + " AND HisOrderZhuoTaiDish.DishTypeID IN " + typeCondition + "  AND HisOrderZhuoTaiDish.DishID NOT IN " + dishCondition
						   + " AND (HisOrderWaiMaiAddress.Source=11 or HisOrderWaiMaiAddress.Source=12 or HisOrderWaiMaiAddress.Source=13 or HisOrderWaiMaiAddress.Source=0) and HisOrderWaiMaiAddress.HasAccept=1 "
						   + sqlYJS
						   + " ) as t ORDER BY t.AddTime asc ";
				}
				else if (qiantaiMode == 1) //快餐
				{
					strSql = " SELECT DISTINCT * FROM( "
						   + " SELECT HisOrderZhuoTai.UID,HisOrderZhuoTai.ZhuoTaiName,HisOrderZhuoTai.AddTime "
						   + " FROM HisOrderZhuoTai with(nolock) INNER JOIN HisOrderZhuoTaiDish with(nolock) on HisOrderZhuoTai.OrderID=HisOrderZhuoTaiDish.OrderID "
						   + " WHERE HisOrderZhuoTaiDish.DishStatusID=1 AND HisOrderZhuoTaiDish.IsHuaCai=0  AND (HisOrderZhuoTaiDish.DishNum+HisOrderZhuoTaiDish.DishZengSongNum)>0  AND HisOrderZhuoTaiDish.StoreID=" + Tools.CurrentUser.StoreID + " AND HisOrderZhuoTaiDish.SongDanTime>'" + startTime + "'  "
						   + " AND HisOrderZhuoTaiDish.DishTypeID IN " + typeCondition + "  AND HisOrderZhuoTaiDish.DishID NOT IN " + dishCondition
						   + " AND HisOrderZhuoTai.OrderID NOT IN(select OrderID From  OrderWaiMaiAddress with(nolock) where AddTime >'" + startTime + "' ) "
						   + " AND HisOrderZhuoTai.OrderID NOT IN(select OrderID From  HisOrderWaiMaiAddress with(nolock) where AddTime >'" + startTime + "' ) "
						   + " UNION ALL "
						   + " SELECT OrderZhuoTai.UID,OrderZhuoTai.ZhuoTaiName,OrderZhuoTai.AddTime "
						   + " FROM OrderZhuoTai with(nolock) INNER JOIN OrderZhuoTaiDish with(nolock) on OrderZhuoTai.OrderID=OrderZhuoTaiDish.OrderID "
						   + " INNER JOIN OrderWaiMaiAddress with(nolock) ON OrderWaiMaiAddress.OrderID=OrderZhuoTaiDish.OrderID "
						   + " WHERE OrderZhuoTaiDish.DishStatusID=1 AND OrderZhuoTaiDish.IsHuaCai=0  AND (OrderZhuoTaiDish.DishNum+OrderZhuoTaiDish.DishZengSongNum)>0  AND OrderZhuoTaiDish.StoreID=" + Tools.CurrentUser.StoreID + " AND OrderZhuoTaiDish.SongDanTime>'" + startTime + "' "
						   + " AND OrderZhuoTaiDish.DishTypeID IN " + typeCondition + "  AND OrderZhuoTaiDish.DishID NOT IN " + dishCondition
						   + " AND (OrderWaiMaiAddress.Source=11 or OrderWaiMaiAddress.Source=12 or OrderWaiMaiAddress.Source=13 or OrderWaiMaiAddress.Source=0) and OrderWaiMaiAddress.HasAccept=1 "
						   + " UNION ALL "
						   + " SELECT HisOrderZhuoTai.UID,HisOrderZhuoTai.ZhuoTaiName,HisOrderZhuoTai.AddTime "
						   + " FROM HisOrderZhuoTai with(nolock) INNER JOIN HisOrderZhuoTaiDish with(nolock) on HisOrderZhuoTai.OrderID=HisOrderZhuoTaiDish.OrderID "
						   + " INNER JOIN HisOrderWaiMaiAddress with(nolock) ON HisOrderWaiMaiAddress.OrderID=HisOrderZhuoTaiDish.OrderID "
						   + " WHERE HisOrderZhuoTaiDish.DishStatusID=1 AND HisOrderZhuoTaiDish.IsHuaCai=0  AND (HisOrderZhuoTaiDish.DishNum+HisOrderZhuoTaiDish.DishZengSongNum)>0  AND HisOrderZhuoTaiDish.StoreID=" + Tools.CurrentUser.StoreID + " AND HisOrderZhuoTaiDish.SongDanTime>'" + startTime + "' "
						   + " AND HisOrderZhuoTaiDish.DishTypeID IN " + typeCondition + "  AND HisOrderZhuoTaiDish.DishID NOT IN " + dishCondition
						   + " AND (HisOrderWaiMaiAddress.Source=11 or HisOrderWaiMaiAddress.Source=12 or HisOrderWaiMaiAddress.Source=13 or HisOrderWaiMaiAddress.Source=0) and HisOrderWaiMaiAddress.HasAccept=1 "
						   + " ) as t ORDER BY t.AddTime asc ";
				}

				DataTable table = DBHelper.ExeSqlForDataTable(strSql);
				if (table.Rows.Count > 0 && string.IsNullOrEmpty(ZTUID) && !IsChooseAllZhuoTai)
				{
					ZTUID = table.Rows[0]["UID"].ToString();
				}
				else if (table.Rows.Count > 0 && !string.IsNullOrEmpty(ZTUID) && !IsChooseAllZhuoTai)
				{
					var source = table.Select("UID='" + ZTUID + "'");
					if (source.Count() <= 0)
					{
						ZTUID = table.Rows[0]["UID"].ToString(); ZTCurrentPageNo = 0; DishCurrentPageNo = 0;
					}
				}
				else if (table.Rows.Count <= 0)
				{
					ZTUID = string.Empty;
					ZTUIDArr = string.Empty;
				}
				else if (table.Rows.Count > 0 && IsChooseAllZhuoTai)
				{
					ZTUIDArr = "(";
					for (int i = 0; i < table.Rows.Count; i++)
					{
						if (i == table.Rows.Count - 1)
						{
							ZTUIDArr = ZTUIDArr + "'" + table.Rows[i]["UID"].ToString() + "'";
						}
						else
						{
							ZTUIDArr = ZTUIDArr + "'" + table.Rows[i]["UID"].ToString() + "'" + ",";
						}
					}
					ZTUIDArr += ")";
				}

				ShowZhuoTai(table);
			}
			catch (Exception ex)
			{
				Log.WriteLog("frmZTDish LoadAllZhuoTai错误信息:" + ex.ToString());
			}
		}

		private delegate void BtnRegesterEventHandler(Button btn);
		public void RedesterEventHandler(Button btn)
		{
			btn.Click += new System.EventHandler(button_Click);
		}

		private void ShowZhuoTai(DataTable dataTable)
		{
			try
			{
				tableLayoutPanel1.Controls.Clear();

				int wCount = 2;
				int hCount = leftTableLayoutPaneHeight / 50;

				int ctlWidth = leftTableLayoutPaneWidth / 2;
				int ctlHeight = leftTableLayoutPaneHeight / hCount;

				tableLayoutPanel1.ColumnCount = wCount;
				tableLayoutPanel1.RowCount = hCount;

				int startIndex = ZTCurrentPageNo * tableLayoutPanel1.RowCount * tableLayoutPanel1.ColumnCount;
				if (ZTCurrentPageNo > 0)
					btnZTUp.Enabled = true;
				else
					btnZTUp.Enabled = false;

				int endIndex = startIndex + (tableLayoutPanel1.RowCount * tableLayoutPanel1.ColumnCount);
				if (endIndex > dataTable.Rows.Count)
					endIndex = dataTable.Rows.Count;

				if (endIndex < dataTable.Rows.Count)
					btnZTDown.Enabled = true;
				else
					btnZTDown.Enabled = false;

				DateTime dt = DateTime.Now;
				for (int i = startIndex; i < endIndex; i++)
				{

					Button button = new Button();

					button.Text = string.Concat(new string[]
                    {
                    dataTable.Rows[i]["ZhuoTaiName"].ToString() 
                    });
					button.Tag = string.Concat(new string[]
                    {
                    dataTable.Rows[i]["UID"].ToString() 
                    });

					button.Name = "btn_" + dataTable.Rows[i]["UID"].ToString();

					button.Width = ctlWidth;
					button.Height = ctlHeight;

					button.BackColor = Color.FromArgb(97, 97, 97);
					button.ForeColor = Color.FromArgb(255, 255, 255);
					button.Font = new Font("微软雅黑", 11f, button.Font.Style, button.Font.Unit);

					BtnRegesterEventHandler handler = new BtnRegesterEventHandler(RedesterEventHandler);
					handler.BeginInvoke(button, null, null);

					tableLayoutPanel1.Controls.Add(button);

				}
			}
			catch (Exception ex)
			{
				Log.WriteLog("frmZTDish ShowZhuoTai 错误信息:" + ex.ToString());
			}
		}

		private void button_Click(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			IsChooseAllZhuoTai = false;
			string str = button.Tag.ToString();
			ZTUID = str;
			DishCurrentPageNo = 0;
			LoadAllZhuoTaiDish();
			ChongZhiButton();
		}

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			RefreshData();
		}

		private void LoadAllZhuoTaiDish()
		{
			try
			{
				string strAlertTime = ConfigurationManager.AppSettings["alerttime"];
				if (!string.IsNullOrEmpty(strAlertTime))
					alertTime = double.Parse(strAlertTime);

				int qiantaiMode = 0;

				string strQiantaiMode = ConfigurationManager.AppSettings["qiantaimode"];

				if (!string.IsNullOrEmpty(strQiantaiMode))
					qiantaiMode = int.Parse(strQiantaiMode);

				string strDishTypes = ConfigurationManager.AppSettings["dishtypes"];
				string strDishes = ConfigurationManager.AppSettings["dishes"];

				string typeCondition = "";
				string dishCondition = "";

				if (string.IsNullOrEmpty(strDishTypes))
					typeCondition = "('')";
				else
					typeCondition = "('" + strDishTypes.Replace(",", "','") + "')";

				if (string.IsNullOrEmpty(strDishes))
					dishCondition = "('')";
				else
					dishCondition = "('" + strDishes.Replace(",", "','") + "')";

				string strSql = "";
				if (qiantaiMode == 0)  //中餐
				{
					string showDishForFinishPay = ConfigurationManager.AppSettings["showDishForFinishPay"];
					string sqlYJS = string.Empty;
					if ("1".Equals(showDishForFinishPay))
					{
						sqlYJS = " UNION ALL "
							   + " SELECT HisOrderZhuoTaiDish.IsHuaCai,HisOrderInfo.IsWaiMai,HisOrderZhuoTai.UID,HisOrderZhuoTai.ZhuoTaiName,HisOrderZhuoTai.AddTime,HisOrderZhuoTaiDish.UID as OrderZhuoTaiDishID,HisOrderZhuoTaiDish.DishID,HisOrderZhuoTaiDish.DishName,(HisOrderZhuoTaiDish.DishNum+HisOrderZhuoTaiDish.DishZengSongNum) as DishNum,HisOrderZhuoTaiDish.UnitName,HisOrderZhuoTaiDish.ZuoFaNames,HisOrderZhuoTaiDish.KouWeiNames,ISNULL(HisOrderZhuoTaiDish.SongDanTime,HisOrderZhuoTaiDish.AddTime) as SongDanTime,HisOrderZhuoTaiDish.DishStatusDesc "
							   + " FROM HisOrderZhuoTai with(nolock) INNER JOIN HisOrderZhuoTaiDish with(nolock) on HisOrderZhuoTai.UID=HisOrderZhuoTaiDish.OrderZhuoTaiID "
							   + " INNER JOIN HisOrderInfo with(nolock) ON HisOrderInfo.UID=HisOrderZhuoTai.OrderID  "
							   + " WHERE HisOrderZhuoTaiDish.DishStatusID=1 AND   HisOrderZhuoTaiDish.StoreID=" + Tools.CurrentUser.StoreID + " AND HisOrderZhuoTaiDish.SongDanTime>'" + startTime + "'  "
							   + " AND HisOrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND (HisOrderZhuoTaiDish.DishNum+HisOrderZhuoTaiDish.DishZengSongNum)>0  AND HisOrderZhuoTaiDish.DishID NOT IN " + dishCondition
							   + " AND HisOrderZhuoTai.OrderID NOT IN(select OrderID From  OrderWaiMaiAddress with(nolock) where AddTime >'" + startTime + "' ) "
							   + " AND HisOrderZhuoTai.OrderID NOT IN(select OrderID From  HisOrderWaiMaiAddress with(nolock) where AddTime >'" + startTime + "' )  " + (IsChooseAllZhuoTai ? (string.IsNullOrEmpty(ZTUIDArr) ? "" : " AND HisOrderZhuoTai.UID in " + ZTUIDArr) : " AND HisOrderZhuoTai.UID='" + ZTUID + "' ");
					}

					strSql = " SELECT * FROM ( "
						   + " SELECT OrderZhuoTaiDish.IsHuaCai,OrderInfo.IsWaiMai,OrderZhuoTai.UID,OrderZhuoTai.ZhuoTaiName,OrderZhuoTai.AddTime,OrderZhuoTaiDish.UID as OrderZhuoTaiDishID,OrderZhuoTaiDish.DishID,OrderZhuoTaiDish.DishName,(OrderZhuoTaiDish.DishNum+OrderZhuoTaiDish.DishZengSongNum) as DishNum,OrderZhuoTaiDish.UnitName,OrderZhuoTaiDish.ZuoFaNames,OrderZhuoTaiDish.KouWeiNames,ISNULL(OrderZhuoTaiDish.SongDanTime,OrderZhuoTaiDish.AddTime) as SongDanTime,OrderZhuoTaiDish.DishStatusDesc "
						   + " FROM OrderZhuoTai with(nolock) INNER JOIN OrderZhuoTaiDish with(nolock) on OrderZhuoTai.UID=OrderZhuoTaiDish.OrderZhuoTaiID "
						   + " INNER JOIN OrderInfo with(nolock) ON OrderInfo.UID=OrderZhuoTai.OrderID  "
						   + " WHERE OrderZhuoTaiDish.DishStatusID=1 AND  OrderZhuoTaiDish.StoreID=" + Tools.CurrentUser.StoreID + " AND OrderZhuoTaiDish.SongDanTime>'" + startTime + "'  "
						   + " AND OrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND (OrderZhuoTaiDish.DishNum+OrderZhuoTaiDish.DishZengSongNum)>0  AND OrderZhuoTaiDish.DishID NOT IN " + dishCondition
						   + " AND OrderZhuoTai.OrderID NOT IN(select OrderID From  OrderWaiMaiAddress with(nolock) where AddTime >'" + startTime + "' ) "
						   + " AND OrderZhuoTai.OrderID NOT IN(select OrderID From  HisOrderWaiMaiAddress with(nolock) where AddTime >'" + startTime + "' )  " + (IsChooseAllZhuoTai ? (string.IsNullOrEmpty(ZTUIDArr) ? "" : " AND OrderZhuoTai.UID in " + ZTUIDArr) : " AND OrderZhuoTai.UID='" + ZTUID + "' ")
						   + " UNION ALL "
						   + " SELECT OrderZhuoTaiDish.IsHuaCai,OrderInfo.IsWaiMai,OrderZhuoTai.UID,OrderZhuoTai.ZhuoTaiName,OrderZhuoTai.AddTime,OrderZhuoTaiDish.UID as OrderZhuoTaiDishID,OrderZhuoTaiDish.DishID,OrderZhuoTaiDish.DishName,(OrderZhuoTaiDish.DishNum+OrderZhuoTaiDish.DishZengSongNum) as DishNum,OrderZhuoTaiDish.UnitName,OrderZhuoTaiDish.ZuoFaNames,OrderZhuoTaiDish.KouWeiNames,ISNULL(OrderZhuoTaiDish.SongDanTime,OrderZhuoTaiDish.AddTime) as SongDanTime,OrderZhuoTaiDish.DishStatusDesc  "
						   + " FROM OrderZhuoTai with(nolock) INNER JOIN OrderZhuoTaiDish with(nolock) on OrderZhuoTai.UID=OrderZhuoTaiDish.OrderZhuoTaiID "
						   + " INNER JOIN OrderWaiMaiAddress with(nolock) ON OrderWaiMaiAddress.OrderID=OrderZhuoTaiDish.OrderID "
						   + " INNER JOIN OrderInfo with(nolock) ON OrderInfo.UID=OrderZhuoTai.OrderID  "
						   + " WHERE OrderZhuoTaiDish.DishStatusID=1   AND (OrderZhuoTaiDish.DishNum+OrderZhuoTaiDish.DishZengSongNum)>0 AND OrderZhuoTaiDish.StoreID=" + Tools.CurrentUser.StoreID + " AND OrderZhuoTaiDish.SongDanTime>'" + startTime + "' "
						   + " AND OrderZhuoTaiDish.DishTypeID IN " + typeCondition + "  AND OrderZhuoTaiDish.DishID NOT IN " + dishCondition
						   + " AND (OrderWaiMaiAddress.Source=11 or OrderWaiMaiAddress.Source=12 or OrderWaiMaiAddress.Source=13 or OrderWaiMaiAddress.Source=0) and OrderWaiMaiAddress.HasAccept=1 " + (IsChooseAllZhuoTai ? (string.IsNullOrEmpty(ZTUIDArr) ? "" : " AND OrderZhuoTai.UID in " + ZTUIDArr) : "  AND OrderZhuoTai.UID='" + ZTUID + "' ")
						   + " UNION ALL "
						   + " SELECT HisOrderZhuoTaiDish.IsHuaCai,HisOrderInfo.IsWaiMai,HisOrderZhuoTai.UID,HisOrderZhuoTai.ZhuoTaiName,HisOrderZhuoTai.AddTime,HisOrderZhuoTaiDish.UID as OrderZhuoTaiDishID,HisOrderZhuoTaiDish.DishID,HisOrderZhuoTaiDish.DishName,(HisOrderZhuoTaiDish.DishNum+HisOrderZhuoTaiDish.DishZengSongNum) as DishNum,HisOrderZhuoTaiDish.UnitName,HisOrderZhuoTaiDish.ZuoFaNames,HisOrderZhuoTaiDish.KouWeiNames,ISNULL(HisOrderZhuoTaiDish.SongDanTime,HisOrderZhuoTaiDish.AddTime) as SongDanTime,HisOrderZhuoTaiDish.DishStatusDesc  "
						   + " FROM HisOrderZhuoTai with(nolock) INNER JOIN HisOrderZhuoTaiDish with(nolock) on HisOrderZhuoTai.UID=HisOrderZhuoTaiDish.OrderZhuoTaiID "
						   + " INNER JOIN HisOrderWaiMaiAddress with(nolock) ON HisOrderWaiMaiAddress.OrderID=HisOrderZhuoTaiDish.OrderID "
						   + " INNER JOIN HisOrderInfo with(nolock) ON HisOrderInfo.UID=HisOrderZhuoTai.OrderID  "
						   + " WHERE HisOrderZhuoTaiDish.DishStatusID=1   AND (HisOrderZhuoTaiDish.DishNum+HisOrderZhuoTaiDish.DishZengSongNum)>0 AND HisOrderZhuoTaiDish.StoreID=" + Tools.CurrentUser.StoreID + " AND HisOrderZhuoTaiDish.SongDanTime>'" + startTime + "' "
						   + " AND HisOrderZhuoTaiDish.DishTypeID IN " + typeCondition + "  AND HisOrderZhuoTaiDish.DishID NOT IN " + dishCondition
						   + " AND (HisOrderWaiMaiAddress.Source=11 or HisOrderWaiMaiAddress.Source=12 or HisOrderWaiMaiAddress.Source=13 or HisOrderWaiMaiAddress.Source=0) and HisOrderWaiMaiAddress.HasAccept=1  " + (IsChooseAllZhuoTai ? (string.IsNullOrEmpty(ZTUIDArr) ? "" : " AND HisOrderZhuoTai.UID in " + ZTUIDArr) : "  AND HisOrderZhuoTai.UID='" + ZTUID + "'  ")
						   + sqlYJS
						   + " ) as t ORDER BY t.IsHuaCai,t.SongDanTime asc ";
				}
				else if (qiantaiMode == 1) //快餐
				{
					strSql = " SELECT * FROM( "
						   + " SELECT HisOrderZhuoTaiDish.IsHuaCai,HisOrderInfo.IsWaiMai,HisOrderZhuoTai.UID,HisOrderZhuoTai.ZhuoTaiName,HisOrderZhuoTai.AddTime,HisOrderZhuoTaiDish.UID as OrderZhuoTaiDishID,HisOrderZhuoTaiDish.DishID,HisOrderZhuoTaiDish.DishName,(HisOrderZhuoTaiDish.DishNum+HisOrderZhuoTaiDish.DishZengSongNum) as DishNum,HisOrderZhuoTaiDish.UnitName,HisOrderZhuoTaiDish.ZuoFaNames,HisOrderZhuoTaiDish.KouWeiNames,ISNULL(HisOrderZhuoTaiDish.SongDanTime,HisOrderZhuoTaiDish.AddTime) as SongDanTime,HisOrderZhuoTaiDish.DishStatusDesc   "
						   + " FROM HisOrderZhuoTai with(nolock) INNER JOIN HisOrderZhuoTaiDish with(nolock) on HisOrderZhuoTai.UID=HisOrderZhuoTaiDish.OrderZhuoTaiID "
						   + " INNER JOIN HisOrderInfo with(nolock) ON HisOrderInfo.UID=HisOrderZhuoTai.OrderID "
						   + " WHERE HisOrderZhuoTaiDish.DishStatusID=1 AND   (HisOrderZhuoTaiDish.DishNum+HisOrderZhuoTaiDish.DishZengSongNum)>0  AND HisOrderZhuoTaiDish.StoreID=" + Tools.CurrentUser.StoreID + " AND HisOrderZhuoTaiDish.SongDanTime>'" + startTime + "'  "
						   + " AND HisOrderZhuoTaiDish.DishTypeID IN " + typeCondition + "  AND HisOrderZhuoTaiDish.DishID NOT IN " + dishCondition
						   + " AND HisOrderZhuoTai.OrderID NOT IN(select OrderID From  OrderWaiMaiAddress with(nolock) where AddTime >'" + startTime + "' ) "
						   + " AND HisOrderZhuoTai.OrderID NOT IN(select OrderID From  HisOrderWaiMaiAddress with(nolock) where AddTime >'" + startTime + "' ) " + (IsChooseAllZhuoTai ? (string.IsNullOrEmpty(ZTUIDArr) ? "" : " AND HisOrderZhuoTai.UID in " + ZTUIDArr) : "   AND HisOrderZhuoTai.UID='" + ZTUID + "' ")
						   + " UNION ALL "
						   + " SELECT OrderZhuoTaiDish.IsHuaCai,OrderInfo.IsWaiMai,OrderZhuoTai.UID,OrderZhuoTai.ZhuoTaiName,OrderZhuoTai.AddTime,OrderZhuoTaiDish.UID as OrderZhuoTaiDishID,OrderZhuoTaiDish.DishID,OrderZhuoTaiDish.DishName,(OrderZhuoTaiDish.DishNum+OrderZhuoTaiDish.DishZengSongNum) as DishNum,OrderZhuoTaiDish.UnitName,OrderZhuoTaiDish.ZuoFaNames,OrderZhuoTaiDish.KouWeiNames,ISNULL(OrderZhuoTaiDish.SongDanTime,OrderZhuoTaiDish.AddTime) as SongDanTime,OrderZhuoTaiDish.DishStatusDesc  "
						   + " FROM OrderZhuoTai with(nolock) INNER JOIN OrderZhuoTaiDish with(nolock) on OrderZhuoTai.UID=OrderZhuoTaiDish.OrderZhuoTaiID "
						   + " INNER JOIN OrderWaiMaiAddress with(nolock) ON OrderWaiMaiAddress.OrderID=OrderZhuoTaiDish.OrderID "
						   + " INNER JOIN OrderInfo with(nolock) on OrderInfo.UID=OrderZhuoTai.OrderID "
						   + " WHERE OrderZhuoTaiDish.DishStatusID=1 AND   (OrderZhuoTaiDish.DishNum+OrderZhuoTaiDish.DishZengSongNum)>0  AND OrderZhuoTaiDish.StoreID=" + Tools.CurrentUser.StoreID + " AND OrderZhuoTaiDish.SongDanTime>'" + startTime + "' "
						   + " AND OrderZhuoTaiDish.DishTypeID IN " + typeCondition + "  AND OrderZhuoTaiDish.DishID NOT IN " + dishCondition
						   + " AND (OrderWaiMaiAddress.Source=11 or OrderWaiMaiAddress.Source=12 or OrderWaiMaiAddress.Source=13 or OrderWaiMaiAddress.Source=0) and OrderWaiMaiAddress.HasAccept=1 " + (IsChooseAllZhuoTai ? (string.IsNullOrEmpty(ZTUIDArr) ? "" : "  AND OrderZhuoTai.UID in " + ZTUIDArr) : "   AND OrderZhuoTai.UID='" + ZTUID + "' ")
						   + " UNION ALL "
						   + " SELECT HisOrderZhuoTaiDish.IsHuaCai,HisOrderInfo.IsWaiMai,HisOrderZhuoTai.UID,HisOrderZhuoTai.ZhuoTaiName,HisOrderZhuoTai.AddTime,HisOrderZhuoTaiDish.UID as OrderZhuoTaiDishID,HisOrderZhuoTaiDish.DishID,HisOrderZhuoTaiDish.DishName,(HisOrderZhuoTaiDish.DishNum+HisOrderZhuoTaiDish.DishZengSongNum) as DishNum,HisOrderZhuoTaiDish.UnitName,HisOrderZhuoTaiDish.ZuoFaNames,HisOrderZhuoTaiDish.KouWeiNames,ISNULL(HisOrderZhuoTaiDish.SongDanTime,HisOrderZhuoTaiDish.AddTime) as SongDanTime,HisOrderZhuoTaiDish.DishStatusDesc  "
						   + " FROM HisOrderZhuoTai with(nolock) INNER JOIN HisOrderZhuoTaiDish with(nolock) on HisOrderZhuoTai.UID=HisOrderZhuoTaiDish.OrderZhuoTaiID "
						   + " INNER JOIN HisOrderWaiMaiAddress ON HisOrderWaiMaiAddress.OrderID=HisOrderZhuoTaiDish.OrderID "
						   + " INNER JOIN HisOrderInfo with(nolock) on HisOrderInfo.UID=HisOrderZhuoTai.OrderID "
						   + " WHERE HisOrderZhuoTaiDish.DishStatusID=1 AND    (HisOrderZhuoTaiDish.DishNum+HisOrderZhuoTaiDish.DishZengSongNum)>0  AND HisOrderZhuoTaiDish.StoreID=" + Tools.CurrentUser.StoreID + " AND HisOrderZhuoTaiDish.SongDanTime>'" + startTime + "' "
						   + " AND HisOrderZhuoTaiDish.DishTypeID IN " + typeCondition + "  AND HisOrderZhuoTaiDish.DishID NOT IN " + dishCondition
						   + " AND (HisOrderWaiMaiAddress.Source=11 or HisOrderWaiMaiAddress.Source=12 or HisOrderWaiMaiAddress.Source=13 or HisOrderWaiMaiAddress.Source=0) and HisOrderWaiMaiAddress.HasAccept=1 " + (IsChooseAllZhuoTai ? (string.IsNullOrEmpty(ZTUIDArr) ? "" : "  AND HisOrderZhuoTai.UID in " + ZTUIDArr) : "   AND HisOrderZhuoTai.UID='" + ZTUID + "' ")
						   + " ) as t ORDER BY  t.IsHuaCai,t.SongDanTime asc ";
				}

				DataTable table = DBHelper.ExeSqlForDataTable(strSql);
				ShowZhuoTaiDish(table);
			}
			catch (Exception ex)
			{
				Log.WriteLog("frmZTDish LoadAllZhuoTaiDish 错误信息:" + ex.ToString());
			}
		}

		private delegate void ControlRegesterEventHandler(Control ctl);
		public void CTLRegesterEventHandler(Control ctl)
		{
			ctl.Click += new System.EventHandler(ZTDishControl_Click);
		}
		private void ShowZhuoTaiDish(DataTable table)
		{
			try
			{

				for (int i = 0; i < ZTDishControls.Length; i++)
				{
					ZTDishControls[i].Reset();
				}

				int wCount = rightTableLayoutPaneWidth / 200;
				int hCount = rightTableLayoutPaneHeight / 100;

				int ctlWidth = rightTableLayoutPaneWidth / wCount;
				int ctlHeight = rightTableLayoutPaneHeight / hCount;

				tableLayoutPanel2.ColumnCount = wCount;
				tableLayoutPanel2.RowCount = hCount;

				int startIndex = DishCurrentPageNo * tableLayoutPanel2.RowCount * tableLayoutPanel2.ColumnCount;
				if (DishCurrentPageNo > 0)
					btnUp.Enabled = true;
				else
					btnUp.Enabled = false;

				int endIndex = startIndex + (tableLayoutPanel2.RowCount * tableLayoutPanel2.ColumnCount);
				if (endIndex > table.Rows.Count)
					endIndex = table.Rows.Count;

				if (endIndex < table.Rows.Count)
					btnDown.Enabled = true;
				else
					btnDown.Enabled = false;

				int j = 0;
				for (int i = startIndex; i < endIndex; i++)
				{
					#region //之前 可用 速度慢
					//Log.WriteLog("1="+DateTime.Now.ToString("HH:mm:ss"));
					//ZTDishControl ctl = new ZTDishControl();
					//Log.WriteLog("2=" + DateTime.Now.ToString("HH:mm:ss"));
					//ctl.Height = ctlHeight;
					//ctl.Width = ctlWidth;

					//DataRow row = table.Rows[i];
					//string ZuoFaNames = row["ZuoFaNames"] as string;
					//string KouWeiNames = row["KouWeiNames"] as string;
					//string UnitName = row["UnitName"].ToString();
					//string DishID = row["DishID"] as string;
					//string DishName = row["DishName"] as string;
					//string UID = row["UID"] as string;           //OrderZhuoTai的主键UID
					//string DishNum = row["DishNum"] as string;
					//bool IsWaiMai = (bool)row["IsWaiMai"];
					//string ZhuoTaiName = row["ZhuoTaiName"] as string;
					//string OrderZhuoTaiDishID = row["OrderZhuoTaiDishID"] as string;  //OrderZhuoTaiDish的主键UID
					//Log.WriteLog("3=" + DateTime.Now.ToString("HH:mm:ss"));
					//ctl.DishID = DishID;
					//ctl.DishName = DishName;
					//ctl.ZFKW = ZuoFaNames + " " + KouWeiNames;
					//if (IsWaiMai)
					//    ctl.IsWaiMai = "(外卖)";
					//else
					//    ctl.IsWaiMai = "";
					//ctl.DishNum = DishNum;
					//string num = String.Format("{0:F}", row["DishNum"]);
					//if (num.EndsWith(".00"))
					//    num = num.Substring(0, num.Length - 3);
					//ctl.DishNumContent = num + " " + UnitName;
					//TimeSpan delta = DateTime.Now - (DateTime)row["SongDanTime"];
					//double strDelta = delta.TotalMinutes;
					//string strTime = "(" + strDelta.ToString("f0") + "分钟)";
					//ctl.Time = strTime;
					//ctl.ZhuoTaiName = ZhuoTaiName;
					//ctl.OrderZhuoTaiDishID = OrderZhuoTaiDishID;  //OrderZhuoTaiDish的主键UID
					//Log.WriteLog("4=" + DateTime.Now.ToString("HH:mm:ss"));
					//if (orderGuQingTable.Rows.Count > 0)
					//{
					//    var sourceGQ = orderGuQingTable.Select("DishID='" + DishID + "'");
					//    if (sourceGQ.Count() > 0)
					//    {
					//        ctl.ChangeBackColor(true);
					//    }
					//    else
					//    {
					//        ctl.ChangeBackColor(false);
					//    }
					//}
					//else
					//{
					//    ctl.ChangeBackColor(false);
					//}

					//Log.WriteLog("5=" + DateTime.Now.ToString("HH:mm:ss"));
					//ControlRegesterEventHandler handler = new ControlRegesterEventHandler(CTLRegesterEventHandler);
					//handler.BeginInvoke(ctl, null, null);
					//Log.WriteLog("6=" + DateTime.Now.ToString("HH:mm:ss"));
					//tableLayoutPanel2.Controls.Add(ctl);
					//Log.WriteLog("7=" + DateTime.Now.ToString("HH:mm:ss"));
					#endregion

					DataRow row = table.Rows[i];
					string ZuoFaNames = row["ZuoFaNames"] as string;
					string KouWeiNames = row["KouWeiNames"] as string;
					string UnitName = row["UnitName"].ToString();
					string DishID = row["DishID"] as string;
					string DishName = row["DishName"] as string;
					string UID = row["UID"] as string;           //OrderZhuoTai的主键UID
					string DishNum = row["DishNum"] as string;
					bool IsWaiMai = (bool)row["IsWaiMai"];
					string ZhuoTaiName = row["ZhuoTaiName"] as string;
					string OrderZhuoTaiDishID = row["OrderZhuoTaiDishID"] as string;  //OrderZhuoTaiDish的主键UID
					bool IsHuaCai = Convert.ToBoolean(row["IsHuaCai"]);
					string DishStatusDesc = row["DishStatusDesc"] as string;

					ZTDishControls[j].DishID = DishID;
					ZTDishControls[j].DishName = (string.IsNullOrEmpty(DishStatusDesc.Trim()) ? "" : "【" + DishStatusDesc + "】") + DishName;
					ZTDishControls[j].ZFKW = ZuoFaNames + " " + KouWeiNames;
					if (IsWaiMai)
						ZTDishControls[j].IsWaiMai = "(外卖)";
					else
						ZTDishControls[j].IsWaiMai = "";
					ZTDishControls[j].DishNum = DishNum;
					string num = String.Format("{0:F}", row["DishNum"]);
					if (num.EndsWith(".00"))
						num = num.Substring(0, num.Length - 3);
					ZTDishControls[j].DishNumContent = num + " " + UnitName;
					TimeSpan delta = DateTime.Now - (DateTime)row["SongDanTime"];
					double strDelta = delta.TotalMinutes;
					string strTime = "(" + strDelta.ToString("f0") + "分钟)";
					ZTDishControls[j].Time = strTime;
					ZTDishControls[j].ZhuoTaiName = ZhuoTaiName;
					ZTDishControls[j].OrderZhuoTaiDishID = OrderZhuoTaiDishID;  //OrderZhuoTaiDish的主键UID

					if (orderGuQingTable.Rows.Count > 0)
					{
						var sourceGQ = orderGuQingTable.Select("DishID='" + DishID + "'");
						if (sourceGQ.Count() > 0)
						{
							ZTDishControls[j].ChangeBackColor("已沽清");
						}
						else
						{
							ZTDishControls[j].ChangeBackColor("未沽清");
						}
					}
					else
					{
						ZTDishControls[j].ChangeBackColor("未沽清");
					}

					if (IsHuaCai)
					{
						ZTDishControls[j].ChangeBackColor("已划单");
					}

					j++;
				}

			}
			catch (Exception ex)
			{
				Log.WriteLog("frmZTDish 错误信息:" + ex.ToString());
			}
		}


		/// <summary>
		/// 获取当前时间段内所有沽清菜品
		/// </summary>
		private void GetOrderGuQingAllData()
		{
			string guQingModel = ConfigurationManager.AppSettings["guQingModel"];
			if (!string.IsNullOrEmpty(guQingModel) && !"0".Equals(guQingModel))
			{
				orderGuQingTable = CommonGuQing.GetOrderGuQingAllData();
			}
		}

		private void ZTDishControl_Click(object sender, EventArgs e)
		{
			try
			{
				ZTDishControl ctl = sender as ZTDishControl;
				string uid = ctl.OrderZhuoTaiDishID;
				if (!string.IsNullOrEmpty(uid))
				{
					string DishName = ctl.DishName;
					string DishID = ctl.DishID;

					string strGuQing = string.Empty;
					if (orderGuQingTable.Rows.Count > 0)
					{
						var sourceGQ = orderGuQingTable.Select("DishID='" + DishID + "'");
						if (sourceGQ.Count() > 0)
						{
							strGuQing = "是否取消沽清";
						}
					}
					frmSingleGuQing frm = new frmSingleGuQing("确认划单?", ctl.DishName, strGuQing);
					frm.Owner = this;
					if (frm.ShowDialog() == DialogResult.OK)
					{
						if (IsGuQing)
						{
							if (!SingleGuQingOperate(uid, DishName, strGuQing))
							{
								MessageBox.Show("沽清失败！");
							}
							else { CommonGuQing.uploadGuQingData(); }
						}

						List<string> uids = new List<string>();
						uids.Add(uid);
						HuaDan(uids);

						CallNumber(uids);
					}
					else
					{
						if (IsGuQing)
						{
							if (!SingleGuQingOperate(uid, DishName, strGuQing))
							{
								MessageBox.Show("沽清失败！");
							}
							else { CommonGuQing.uploadGuQingData(); }
						}
					}
				}
			}
			catch (Exception ex)
			{
				Log.WriteLog("frmZTDish ZTDishControl_Click错误原因:" + ex.ToString());
			}
		}

		private void HuaDan(List<string> uids)
		{
			try
			{
				StringBuilder builder = new StringBuilder();
				string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
				foreach (string uid in uids)
				{
					builder.Append("UPDATE OrderZhuoTaiDish SET IsHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE UID='" + uid + "' ").Append("\r\n")
						.Append("UPDATE HisOrderZhuoTaiDish SET IsHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE UID='" + uid + "' ").Append("\r\n");

					builder.Append("UPDATE OrderPackageDishDetail SET IfHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE UID='" + uid + "' ").Append("\r\n")
						.Append("UPDATE HisOrderPackageDishDetail SET IfHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE UID='" + uid + "' ").Append("\r\n");

				}
				string strSql = builder.ToString();

				DBHelper.ExecuteNonQuery(strSql);

				RefreshData();

				if ("1".Equals(ConfigurationManager.AppSettings["autoprint"]))
				{
					Task.Factory.StartNew(
					   () =>
					   {
						   HuaDanClass.PrintDishes(uids, new List<OrderAllZTDishModel>());
					   }
				   );
				}

				bool ifweixin = "1".Equals(ConfigurationManager.AppSettings["ifweixin"]);
				if (ifweixin)
				{
					Task.Factory.StartNew(
						() =>
						{
							HuaDanClass.CallWeiXin(uids);
						}
					);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		/// <summary>
		/// 单项沽清用
		/// </summary>
		public bool IsGuQing = false;
		public void GetChildFormParam(bool param)
		{
			IsGuQing = param;
		}

		#region//单项沽清操作
		/// <summary>
		/// 单项沽清操作---直接沽清|普通沽清
		/// </summary>
		/// <param name="uid"></param>
		/// <param name="DishName"></param>
		/// <param name="gqName"></param>
		/// <returns></returns>
		private bool SingleGuQingOperate(string uid, string DishName, string gqName)
		{
			bool result = true;
			if (IsGuQing)
			{
				string sqlDish = "select DishID,IsPackage from OrderZhuoTaiDish where uid='" + uid + "' union select DishID,IsPackage from HisOrderZhuoTaiDish where uid='" + uid + "' ";
				var dishSource = DBHelper.ExeSqlForDataTable(sqlDish);
				if (dishSource.Rows.Count > 0)
				{
					bool isPackage = (bool)dishSource.Rows[0]["IsPackage"];
					if (isPackage)
					{
						MessageBox.Show("套餐不能沽清！");
						result = true;
					}
				}

				if (string.IsNullOrEmpty(gqName))
				{
					gqName = "沽清";
				}
				else { gqName = "取消沽清"; }

				string guQingModel = ConfigurationManager.AppSettings["guQingModel"]; //是否快速沽清
				if (!object.Equals(guQingModel, null) && "1".Equals(guQingModel))
				{
					if (dishSource.Rows.Count > 0)
					{
						//快速沽清模式
						string quickGuQingTip = ConfigurationManager.AppSettings["quickGuQingTip"]; //快速沽清是否提醒
						if (!object.Equals(quickGuQingTip, null) && "1".Equals(quickGuQingTip))
						{
							if (DialogResult.Yes == MessageBox.Show("菜品【" + DishName + "】确定要" + gqName + "吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
							{

								if (!CommonGuQing.GuQingOpreate(gqName, DishName, dishSource.Rows[0][0].ToString(), "", 0))
								{
									result = false;
								}
							}
						}
						else
						{
							//直接操作
							if (!CommonGuQing.GuQingOpreate(gqName, DishName, dishSource.Rows[0][0].ToString(), "", 0))
							{
								result = false;
							}
						}
					}
				}
				else if (!object.Equals(guQingModel, null) && "2".Equals(guQingModel))
				{
					//普通沽清模式
					frmGuQing frmgq = new frmGuQing(gqName, DishName, dishSource.Rows[0][0].ToString(), false);
					if (frmgq.ShowDialog() == DialogResult.OK)
					{
						//RefreshGuQing();
					}
				}
			}
			return result;
		}
		#endregion

		private void btnGuQingList_Click(object sender, EventArgs e)
		{
			frmGuQingList frm = new frmGuQingList();
			if (frm.ShowDialog() == DialogResult.OK)
			{

			}
		}

		#region //翻页
		private void btnZTUp_Click(object sender, EventArgs e)
		{
			ZTCurrentPageNo--;
			LoadAllZhuoTai();
		}

		private void btnZTDown_Click(object sender, EventArgs e)
		{
			ZTCurrentPageNo++;
			LoadAllZhuoTai();
		}

		private void btnUp_Click(object sender, EventArgs e)
		{
			DishCurrentPageNo--;
			LoadAllZhuoTaiDish();
		}

		private void btnDown_Click(object sender, EventArgs e)
		{
			DishCurrentPageNo++;
			LoadAllZhuoTaiDish();
		}

		#endregion

		private void txtHuaCaiNum_Click(object sender, EventArgs e)
		{
			handMode = false;
		}

		private void txtHuaCaiNum_Leave(object sender, EventArgs e)
		{
			if (!handMode)
				txtHuaCaiNum.Focus();
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
					string sql = string.Empty;
					string qiantaiMode = ConfigurationManager.AppSettings["qiantaimode"];
					if (string.IsNullOrEmpty(qiantaiMode) || "0".Equals(qiantaiMode))
					{
						sql = " select OrderZhuoTaiDish.UID,OrderPackageDishDetail.HuaCaiNum,OrderPackageDishDetail.OrderZhuoTaiDishID from OrderZhuoTaiDish " +
									" INNER JOIN OrderPackageDishDetail ON OrderPackageDishDetail.OrderZhuoTaiDishID=OrderZhuoTaiDish.UID where OrderPackageDishDetail.IfHuaCai=0 AND OrderZhuoTaiDish.IsHuaCai=0 and OrderZhuoTaiDish.DishNum>0 and OrderPackageDishDetail.DishNum>0 ";
					}
					else
					{
						sql = " select HisOrderZhuoTaiDish.UID,HisOrderPackageDishDetail.HuaCaiNum,HisOrderPackageDishDetail.OrderZhuoTaiDishID from HisOrderZhuoTaiDish " +
							  " INNER JOIN HisOrderPackageDishDetail ON HisOrderPackageDishDetail.OrderZhuoTaiDishID=HisOrderZhuoTaiDish.UID where HisOrderPackageDishDetail.IfHuaCai=0 AND HisOrderZhuoTaiDish.IsHuaCai=0 and HisOrderZhuoTaiDish.DishNum>0 and HisOrderPackageDishDetail.DishNum>0 ";
					}
					DataTable dt = DBHelper.ExeSqlForDataTable(sql);
					if (dt.Rows.Count > 0) //说明有套餐明细
					{
						DataRow[] source = dt.Select("HuaCaiNum='" + txtHuaCaiNum.Text.Trim() + "'");//是套餐的划单号
						if (source.Count() <= 0) //套餐OrderZhuoTaiDish表的菜品总名称
						{
							string sqlAll = string.Empty;
							if (string.IsNullOrEmpty(qiantaiMode) || "0".Equals(qiantaiMode))
							{
								sqlAll = " select top 1 * from OrderZhuoTaiDish where HuaCaiNum='" + txtHuaCaiNum.Text.Trim() + "' order by addtime desc ";
							}
							else
							{
								sqlAll = " select top 1 * from HisOrderZhuoTaiDish where HuaCaiNum='" + txtHuaCaiNum.Text.Trim() + "' order by addtime desc  ";
							}
							DataTable dtAll = DBHelper.ExeSqlForDataTable(sqlAll);
							if (dtAll.Rows.Count > 0)
							{
								if ((bool)dtAll.Rows[0]["IsPackage"])
								{
									string UID = dtAll.Rows[0]["UID"].ToString();
									DialogResult dr = MessageBox.Show("确定整个套餐划单？", "提示", MessageBoxButtons.OKCancel);
									if (dr == DialogResult.OK)
									{
										builder.Append("UPDATE OrderZhuoTaiDish SET IsHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE UID='" + UID + "' ").Append("\r\n")
											   .Append("UPDATE HisOrderZhuoTaiDish SET IsHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE UID='" + UID + "' ").Append("\r\n")
											   .Append("UPDATE OrderPackageDishDetail SET IfHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE OrderZhuoTaiDishID='" + UID + "' ").Append("\r\n")
											   .Append("UPDATE HisOrderPackageDishDetail SET IfHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE OrderZhuoTaiDishID='" + UID + "' ").Append("\r\n");
									}
								}
								else
								{
									builder.Append("UPDATE OrderZhuoTaiDish SET IsHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE HuaCaiNum='" + txtHuaCaiNum.Text.Trim() + "' ").Append("\r\n")
										   .Append("UPDATE HisOrderZhuoTaiDish SET IsHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE HuaCaiNum='" + txtHuaCaiNum.Text.Trim() + "' ").Append("\r\n");
								}
							}
						}
						else
						{
							string OrderZhuoTaiDishUID = source[0]["UID"].ToString();

							DataRow[] sourceDetail = dt.Select("OrderZhuoTaiDishID='" + OrderZhuoTaiDishUID + "'");
							if (sourceDetail.Count() == 1)
							{
								builder.Append("UPDATE OrderZhuoTaiDish SET IsHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE UID='" + OrderZhuoTaiDishUID + "' ").Append("\r\n")
									   .Append("UPDATE HisOrderZhuoTaiDish SET IsHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE UID='" + OrderZhuoTaiDishUID + "' ").Append("\r\n")
									   .Append("UPDATE OrderPackageDishDetail SET IfHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE OrderZhuoTaiDishID='" + OrderZhuoTaiDishUID + "' ").Append("\r\n")
									   .Append("UPDATE HisOrderPackageDishDetail SET IfHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE OrderZhuoTaiDishID='" + OrderZhuoTaiDishUID + "' ").Append("\r\n");
							}
							else
							{
								#region//注释=>根据套餐划单号是否 划去整个套餐
								//DialogResult dr = MessageBox.Show("确定整个套餐划单？\r\n确定 --> 套餐内所有菜品被划单！\r\n取消 --> 根据划单号划单一菜品！", "提示", MessageBoxButtons.OKCancel);

								//if (dr == DialogResult.OK)
								//{
								//    builder.Append("UPDATE OrderZhuoTaiDish SET IsHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE UID='" + OrderZhuoTaiDishUID + "' ").Append("\r\n")
								//           .Append("UPDATE HisOrderZhuoTaiDish SET IsHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE UID='" + OrderZhuoTaiDishUID + "' ").Append("\r\n")
								//           .Append("UPDATE OrderPackageDishDetail SET IfHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE OrderZhuoTaiDishID='" + OrderZhuoTaiDishUID + "' ").Append("\r\n")
								//           .Append("UPDATE HisOrderPackageDishDetail SET IfHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE OrderZhuoTaiDishID='" + OrderZhuoTaiDishUID + "' ").Append("\r\n");
								//}
								//else if (dr == DialogResult.Cancel)
								//{
								//    builder.Append("UPDATE OrderPackageDishDetail SET IfHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE HuaCaiNum='" + txtHuaCaiNum.Text.Trim() + "' ").Append("\r\n")
								//           .Append("UPDATE HisOrderPackageDishDetail SET IfHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE HuaCaiNum='" + txtHuaCaiNum.Text.Trim() + "' ").Append("\r\n");
								//}
								#endregion

								builder.Append("UPDATE OrderPackageDishDetail SET IfHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE HuaCaiNum='" + txtHuaCaiNum.Text.Trim() + "' ").Append("\r\n")
									   .Append("UPDATE HisOrderPackageDishDetail SET IfHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE HuaCaiNum='" + txtHuaCaiNum.Text.Trim() + "' ").Append("\r\n");

							}
						}
					}
					else
					{
						builder.Append("UPDATE OrderZhuoTaiDish SET IsHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE HuaCaiNum='" + txtHuaCaiNum.Text.Trim() + "' ").Append("\r\n")
								.Append("UPDATE HisOrderZhuoTaiDish SET IsHuaCai=1,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE HuaCaiNum='" + txtHuaCaiNum.Text.Trim() + "' ").Append("\r\n");
					}
					string strSql = builder.ToString();

					DBHelper.ExecuteNonQuery(strSql);

					txtHuaCaiNum.Clear();

					RefreshData();
				}
			}
			catch (Exception ex)
			{
				Log.WriteLog("txtHuaCaiNum_KeyDown 错误信息:" + ex.ToString());
			}
		}

		private void btnSetup_Click(object sender, EventArgs e)
		{
			new frmSetup().ShowDialog(this);
		}

		/// <summary>
		/// 划单叫号
		/// </summary>
		/// <param name="uids"></param>
		private void CallNumber(List<string> uids)
		{
			foreach (string uid in uids)
			{
				//Log.WriteLog("叫号UID="+uid);
				CallNumServer.SetCallNumber(uid);
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			RefreshData();
		}

		private void btnAllZhuoTai_Click(object sender, EventArgs e)
		{
			IsChooseAllZhuoTai = true;
			ZTUID = string.Empty;
			LoadAllZhuoTai();      //顺序不可调-优先级：1
			ChongZhiButton();

			LoadAllZhuoTaiDish();
		}

		/// <summary>
		/// 重置按钮样式
		/// </summary>
		private void ChongZhiButton()
		{
			//DishCurrentPageNo = 0;
			Button btn = new Button();
			//重置所有桌台按钮为原始背景色
			foreach (Control ctl in tableLayoutPanel1.Controls)
			{
				if (ctl is Button)
				{
					ctl.BackColor = Color.FromArgb(97, 97, 97);
					ctl.ForeColor = Color.FromArgb(255, 255, 255);

					if (!string.IsNullOrEmpty(ZTUID) && ZTUID.Equals(ctl.Tag.ToString()))
					{
						btn = ctl as Button;
					}
				}
			}

			if (IsChooseAllZhuoTai)
			{
				btnAllZhuoTai.BackColor = Color.FromArgb(255, 102, 0);
				btnAllZhuoTai.ForeColor = Color.White;
			}
			else
			{
				btnAllZhuoTai.BackColor = Color.FromArgb(241, 241, 241);
				btnAllZhuoTai.ForeColor = Color.Black;

				btn.BackColor = Color.FromArgb(255, 102, 0);
			}
		}

		private void frmZTDish_MaximumSizeChanged(object sender, EventArgs e)
		{
			//leftTableLayoutPaneHeight = this.tableLayoutPanel1.Height;
			//leftTableLayoutPaneWidth = this.tableLayoutPanel1.Width;
			//rightTableLayoutPaneHeight = this.tableLayoutPanel2.Height;
			//rightTableLayoutPaneWidth = this.tableLayoutPanel2.Width;
		}

		private void setOemInfo()
		{
			try
			{
				if (!File.Exists(Directory.GetCurrentDirectory() + "\\oem\\info.ini"))
					return;

				IniFileHelper iniHelper = new IniFileHelper(Directory.GetCurrentDirectory() + "\\oem\\info.ini");

				StringBuilder simplename = new StringBuilder(55);
				iniHelper.GetIniString("oem", "simplename", "", simplename, simplename.Capacity);

				if (File.Exists(Directory.GetCurrentDirectory() + "\\oem\\res\\images\\app.ico"))
				{
					this.Icon = new System.Drawing.Icon(Directory.GetCurrentDirectory() + "\\oem\\res\\images\\app.ico");
				}
			}
			catch (Exception ex)
			{
				Log.WriteLog("frmZTDish setOemInfo():" + ex.ToString());
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			frmQuery frm = new frmQuery("frmZTDish");
			frm.Owner = this;
			frm.ShowDialog();
		}

		private void btnTJ_Click(object sender, EventArgs e)
		{
			frmDishTongJi frm = new frmDishTongJi();
			frm.ShowDialog();
		}

		private void btnZTHuaDan_Click(object sender, EventArgs e)
		{
			try
			{
				if (string.IsNullOrEmpty(ZTUID))
				{
					MessageBox.Show("请先选择要整桌划单的桌台!");
					return;
				}

				string strSql = " select zt.ZhuoTaiName,dish.UID,dish.DishID,dish.DishName,zt.OrderID "
							  + " from OrderZhuoTai zt with(nolock) "
							  + " inner join OrderZhuoTaiDish dish with(nolock) on zt.OrderID=dish.OrderID "
							  + " where dish.DishStatusID=1 and IsHuaCai=0 and zt.UID='" + ZTUID + "' "
							  + " union "
							  + " select zt.ZhuoTaiName,dish.UID,dish.DishID,dish.DishName,zt.OrderID "
							  + " from HisOrderZhuoTai zt with(nolock) "
							  + " inner join HisOrderZhuoTaiDish dish with(nolock) on zt.OrderID=dish.OrderID "
							  + " where dish.DishStatusID=1 and IsHuaCai=0 and zt.UID='" + ZTUID + "'";

				DataTable table = DBHelper.ExeSqlForDataTable(strSql);
				if (table.Rows.Count <= 0)
				{
					MessageBox.Show("未查询到菜品信息!");
					return;
				}

				if (MessageBox.Show("桌台【" + table.Rows[0]["ZhuoTaiName"].ToString() + "】,确定要整桌划单吗?", "划单提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
				{
					List<string> uids = new List<string>();
					for (int i = 0; i < table.Rows.Count; i++)
					{
						uids.Add(table.Rows[i]["UID"].ToString());
					}

					HuaDan(uids);

					CallNumServer.SetCallNumberForZhengZhuo(table.Rows[0]["OrderID"].ToString());
				}

			}
			catch (Exception ex)
			{
				Log.WriteLog("frmZTDish btnZTHuaDan_Click 错误原因:" + ex.ToString());
				MessageBox.Show("系统错误,请重新尝试!");
			}
		}
	}
}
