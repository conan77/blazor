using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using CaiMomoClient;
using System.Collections.Specialized;
using HuaDan.Model;

namespace HuaDan
{
	public partial class frmMain : Form
	{
		public static frmMain Instance { get; set; }
		int CurrentPageNo = 0;
		ListBox[] listBoxes = new ListBox[8];
		Label[] listLabels = new Label[8];
		DishControl[] DishControls;
		DateTime lastClickTime = DateTime.Now;
		public static double alertTime = 30;
		bool handMode = false;
		Dictionary<string, int> OrderSendCount = new Dictionary<string, int>();
		List<OrderHuaDan> orderHuaDanList = new List<OrderHuaDan>();
		string getdishmodel = string.Empty;//是否单项抢单模式
		string strZhuotaiMode = string.Empty;
		DateTime startTime = DateTime.Now;//餐别开始时间
		DataTable orderGuQingTable = new DataTable();
		#region//初始方法
		public frmMain()
		{
			InitializeComponent();
			Instance = this;
			this.Top = 0;
			this.Left = 0;
			this.Width = Screen.PrimaryScreen.Bounds.Width;
			this.Height = Screen.PrimaryScreen.Bounds.Height;

			string qiantaiModeTmp = ConfigurationManager.AppSettings["qiantaimode"];
			if (string.IsNullOrEmpty(qiantaiModeTmp) || "0".Equals(qiantaiModeTmp))
			{
				btnQuery.Visible = true;
			}
			else
			{
				btnQuery.Visible = false;
			}

			IsShowGuQing();

			int zhuotaiMode = 0;
			strZhuotaiMode = ConfigurationManager.AppSettings["zhuotaimode"];
			if (!string.IsNullOrEmpty(strZhuotaiMode))
				zhuotaiMode = int.Parse(strZhuotaiMode);

			if (zhuotaiMode == 0 || zhuotaiMode == 1)
			{
				btnHuaDan.Visible = true;
				for (int i = 0; i < 8; i++)
				{
					Panel panel = new Panel();
					panel.Dock = DockStyle.Fill;

					listLabels[i] = new Label();
					listLabels[i].Dock = DockStyle.Top;
					listLabels[i].Font = new Font("新宋体", 16.0f, FontStyle.Bold);
					listLabels[i].BackColor = Color.FromArgb(96, 96, 96);
					listLabels[i].ForeColor = Color.LightYellow;
					listLabels[i].Click += listLabels_Click;

					listBoxes[i] = new ListBox();
					listBoxes[i].Dock = DockStyle.Fill;
					listBoxes[i].BackColor = Color.FromArgb(64, 64, 64);
					listBoxes[i].ForeColor = Color.LightYellow;
					listBoxes[i].Font = new Font("新宋体", 16.0f);
					listBoxes[i].SelectionMode = SelectionMode.MultiSimple;
					listBoxes[i].DrawMode = DrawMode.OwnerDrawFixed;
					listBoxes[i].DrawItem += listBoxes_DrawItem;
					listBoxes[i].ItemHeight = 30;
					listBoxes[i].Click += listBoxes_Click;
					listBoxes[i].MouseDown += listBox1_MouseDown;

					panel.Controls.Add(listBoxes[i]);
					panel.Controls.Add(listLabels[i]);
					tableLayoutPanel1.Controls.Add(panel);
				}

			}
			else if (zhuotaiMode == 2)
			{
				btnQuery.Visible = false;
				btnHuaDan.Visible = false;
				for (int i = 0; i < tableLayoutPanel1.ColumnCount; i++)
				{
					tableLayoutPanel1.ColumnStyles[i].SizeType = SizeType.AutoSize;
				}
				for (int i = 0; i < tableLayoutPanel1.RowCount; i++)
				{
					tableLayoutPanel1.RowStyles[i].SizeType = SizeType.AutoSize;
				}


				DishControl ctl = new DishControl();

				int wCount = this.ClientSize.Width / ctl.Width;
				int hCount = (this.ClientSize.Height - 100) / ctl.Height;

				int ctlWidth = this.ClientSize.Width / wCount;
				int ctlHeight = this.ClientSize.Height / hCount - (100 / hCount);

				tableLayoutPanel1.ColumnCount = wCount;
				tableLayoutPanel1.RowCount = hCount;

				DishControls = new DishControl[wCount * hCount];

				for (int i = 0; i < DishControls.Length; i++)
				{
					DishControls[i] = new DishControl();
					DishControls[i].Width = ctlWidth;
					DishControls[i].Height = ctlHeight;

					DishControls[i].DishName = "";
					DishControls[i].Zuofa = "";
					DishControls[i].Time = "";
					DishControls[i].ZhuoTaiName = "";
					DishControls[i].UID = "";
					DishControls[i].Count = "";

					DishControls[i].Click += DishControl_Click;

					tableLayoutPanel1.Controls.Add(DishControls[i]);
				}
			}


		}

		private void DishControl_Click(object sender, EventArgs e)
		{
			LoadAllOrderHuaDan();//选择单项时，加载所有已被抢单数据，方便下边处理
			DishControl ctl = sender as DishControl;

			string uid = ctl.UID;
			if (!string.IsNullOrEmpty(uid))
			{
				if (strZhuotaiMode.Equals("2") && getdishmodel.Equals("1"))
				{
					#region 单项抢单模式
					var ifQiangDan = orderHuaDanList.Where(p => p.ZTDishUID.Equals(ctl.UID)).ToList();//判断是不是已被抢单
					if (ifQiangDan.Count > 0)
					{
						if (ifQiangDan.Where(p => p.QiangDanUser.Equals(Tools.CurrentUser.UID)).ToList().Count > 0)//判断是不是本台机器抢单
						{
							frmHuaDan frm = new frmHuaDan(ctl.DishName, ctl.GuQingNum);
							frm.Owner = this;
							if (frm.ShowDialog() == DialogResult.OK)
							{
								if (IsGuQing)
								{
									if (!SingleGuQingOperate(uid, ctl.DishName, ctl.GuQingNum))
									{
										MessageBox.Show("沽清失败！");
										return;
									}
									else { CommonGuQing.uploadGuQingData(); }
								}

								string result = frm.result;
								if (result.Equals("0"))
								{
									CanCelQiangDan(uid);            //取消抢单
								}
								else if (result.Equals("1"))
								{
									List<string> uids = new List<string>();
									uids.Add(uid);
									HuaDan(uids);                   //抢单完成后-划单操作
								}

								frm.Close();
								btnRefresh_Click(null, null);
							}
							else
							{
								if (IsGuQing)
								{
									if (!SingleGuQingOperate(uid, ctl.DishName, ctl.GuQingNum))
									{
										MessageBox.Show("沽清失败！");
										return;
									}
									else { CommonGuQing.uploadGuQingData(); }
								}
							}
						}
						else
						{
							MessageBox.Show("该单项已被其他人抢单，您不能进行操作！");
							btnRefresh_Click(null, null);
						}
					}
					else
					{
						int num = LoadAllHisOrderHuaDan(ctl.UID);//防止 一台机器 划单，其他机器没刷新，这时是不可以【抢单】操作。
						if (num == 0)
						{
							string DishName = ctl.DishName;
							frmSingleGuQing frm = new frmSingleGuQing("确认抢单?", ctl.DishName, ctl.GuQingNum);
							frm.Owner = this;
							if (frm.ShowDialog() == DialogResult.OK)
							{
								QiangDan(ctl);              //抢单

								if (IsGuQing)
								{
									if (!SingleGuQingOperate(uid, DishName, ctl.GuQingNum))
									{
										MessageBox.Show("沽清失败！");
									}
									else { CommonGuQing.uploadGuQingData(); }
								}

							}
							else
							{
								if (IsGuQing)
								{
									if (!SingleGuQingOperate(uid, ctl.DishName, ctl.GuQingNum))
									{
										MessageBox.Show("沽清失败！");
										return;
									}
									else { CommonGuQing.uploadGuQingData(); }
								}
							}
						}
						else
						{
							MessageBox.Show("该单项已被划单！");
						}
						btnRefresh_Click(null, null);
					}
					#endregion
				}
				else
				{
					#region 普通单项模式
					string DishName = ctl.DishName;
					frmSingleGuQing frm = new frmSingleGuQing("确认划单?", ctl.DishName, ctl.GuQingNum);
					frm.Owner = this;
					if (frm.ShowDialog() == DialogResult.OK)
					{
						if (IsGuQing)
						{
							if (!SingleGuQingOperate(uid, DishName, ctl.GuQingNum))
							{
								MessageBox.Show("沽清失败！");
							}
							else { CommonGuQing.uploadGuQingData(); }
						}

						List<string> uids = new List<string>();
						uids.Add(uid);
						HuaDan(uids);
					}
					else
					{
						if (IsGuQing)
						{
							if (!SingleGuQingOperate(uid, ctl.DishName, ctl.GuQingNum))
							{
								MessageBox.Show("沽清失败！");
								return;
							}
							else { CommonGuQing.uploadGuQingData(); }
						}
					}
					#endregion
				}
			}
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

		private void Form1_Load(object sender, EventArgs e)
		{
			setOemInfo();
			this.WindowState = FormWindowState.Maximized;
			Instance = this;
			txtHuaCaiNum.Focus();
			StartMonitor();
		}

		public void LoadAllZhuoTaiDish()
		{
			startTime = InitCanBie();//DateTime.Now.AddDays(-1); //DateTime.Parse("2015-08-01"); 这个地方将来要改成按照餐别来
			try
			{
				string strAlertTime = ConfigurationManager.AppSettings["alerttime"];
				if (!string.IsNullOrEmpty(strAlertTime))
					alertTime = double.Parse(strAlertTime);

				int qiantaiMode = 0;
				int zhuotaiMode = 0;

				string strQiantaiMode = ConfigurationManager.AppSettings["qiantaimode"];

				if (!string.IsNullOrEmpty(strQiantaiMode))
					qiantaiMode = int.Parse(strQiantaiMode);
				if (!string.IsNullOrEmpty(strZhuotaiMode))
					zhuotaiMode = int.Parse(strZhuotaiMode);

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
					if (zhuotaiMode == 0 || zhuotaiMode == 1)  //台卡号 或 桌台
					{
						if ("1".Equals(showDishForFinishPay))
						{
							strSql = " select * from( "
							   + "SELECT OrderZhuoTai.AddTime as ZTAddTime,OrderZhuoTaiDish.AddTime as DishAddTime,OrderZhuoTaiDish.UID, OrderZhuoTaiDish.StoreID, OrderZhuoTaiDish.OrderID, OrderZhuoTaiDish.OrderZhuoTaiID, OrderZhuoTaiDish.DishID, "
							   + "OrderZhuoTaiDish.DishName, OrderZhuoTaiDish.DishTypeID,OrderZhuoTaiDish.UnitName,(OrderZhuoTaiDish.DishNum+OrderZhuoTaiDish.DishZengSongNum) as DishNum, OrderZhuoTaiDish.DishStatusID, OrderZhuoTai.ZhuoTaiID, OrderZhuoTai.ZhuoTaiName, "
							   + "OrderZhuoTaiDish.SongDanTime,OrderZhuoTaiDish.IsHuaCai,OrderZhuoTaiDish.HuaCaiNum ,OrderZhuoTaiDish.ZuoFaNames,OrderZhuoTaiDish.KouWeiNames,OrderInfo.IsWaiMai,OrderZhuoTaiDish.DishTuiCaiNum,OrderZhuoTaiDish.DishZengSongNum,OrderZhuoTaiDish.DishStatusDesc,OrderZhuoTaiDish.IsPackage,'否' as IsTaoCanDetail,'' as OrderZhuoTaiDishID "
							   + "FROM OrderZhuoTaiDish INNER JOIN "
							   + "OrderZhuoTai ON OrderZhuoTaiDish.OrderZhuoTaiID=OrderZhuoTai.UID "
							   + "INNER JOIN OrderInfo ON OrderZhuoTaiDish.OrderID=OrderInfo.UID "
							   + "WHERE OrderZhuoTaiDish.DishStatusID=1 AND OrderZhuoTai.UID IN "
							   + "(SELECT DISTINCT OrderZhuoTaiID FROM OrderZhuoTaiDish WHERE IsHuaCai=0 AND (DishNum+DishZengSongNum)>0 AND StoreID=@StoreID AND SongDanTime>@AddTime  AND OrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND OrderZhuoTaiDish.DishID NOT IN " + dishCondition + ") "
							   + " AND OrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND OrderZhuoTaiDish.DishID NOT IN " + dishCondition
							   + " UNION "
							   + "SELECT HisOrderZhuoTai.AddTime as ZTAddTime,HisOrderZhuoTaiDish.AddTime as DishAddTime,HisOrderZhuoTaiDish.UID, HisOrderZhuoTaiDish.StoreID, HisOrderZhuoTaiDish.OrderID, HisOrderZhuoTaiDish.OrderZhuoTaiID, HisOrderZhuoTaiDish.DishID, "
							   + "HisOrderZhuoTaiDish.DishName, HisOrderZhuoTaiDish.DishTypeID,HisOrderZhuoTaiDish.UnitName,(HisOrderZhuoTaiDish.DishNum+HisOrderZhuoTaiDish.DishZengSongNum) as DishNum, HisOrderZhuoTaiDish.DishStatusID, HisOrderZhuoTai.ZhuoTaiID, HisOrderZhuoTai.ZhuoTaiName, "
							   + "HisOrderZhuoTaiDish.SongDanTime,HisOrderZhuoTaiDish.IsHuaCai,HisOrderZhuoTaiDish.HuaCaiNum ,HisOrderZhuoTaiDish.ZuoFaNames,HisOrderZhuoTaiDish.KouWeiNames,HisOrderInfo.IsWaiMai,HisOrderZhuoTaiDish.DishTuiCaiNum,HisOrderZhuoTaiDish.DishZengSongNum,HisOrderZhuoTaiDish.DishStatusDesc,HisOrderZhuoTaiDish.IsPackage,'否' as IsTaoCanDetail,'' as OrderZhuoTaiDishID "
							   + "FROM HisOrderZhuoTaiDish INNER JOIN "
							   + "HisOrderZhuoTai ON HisOrderZhuoTaiDish.OrderZhuoTaiID=HisOrderZhuoTai.UID "
							   + "INNER JOIN HisOrderInfo ON HisOrderZhuoTaiDish.OrderID=HisOrderInfo.UID "
							   + "WHERE HisOrderZhuoTaiDish.DishStatusID=1 AND HisOrderZhuoTai.UID IN "
							   + "(SELECT DISTINCT OrderZhuoTaiID FROM HisOrderZhuoTaiDish WHERE IsHuaCai=0 AND (DishNum+DishZengSongNum)>0 AND StoreID=@StoreID AND SongDanTime>@AddTime  AND HisOrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND HisOrderZhuoTaiDish.DishID NOT IN " + dishCondition + ") "
							   + " AND HisOrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND HisOrderZhuoTaiDish.DishID NOT IN " + dishCondition
							   + " ) d " + (IsHuaDel() ? " where IsHuaCai=0 " : "") + " ORDER BY ZTAddTime,ZhuoTaiName,DishAddTime,IsHuaCai,DishTypeID,DishName";
						}
						else
						{
							strSql = "SELECT OrderZhuoTai.AddTime as ZTAddTime,OrderZhuoTaiDish.AddTime as DishAddTime,OrderZhuoTaiDish.UID, OrderZhuoTaiDish.StoreID, OrderZhuoTaiDish.OrderID, OrderZhuoTaiDish.OrderZhuoTaiID, OrderZhuoTaiDish.DishID, "
								   + "OrderZhuoTaiDish.DishName, OrderZhuoTaiDish.DishTypeID,OrderZhuoTaiDish.UnitName,(OrderZhuoTaiDish.DishNum+OrderZhuoTaiDish.DishZengSongNum) as DishNum, OrderZhuoTaiDish.DishStatusID, OrderZhuoTai.ZhuoTaiID, OrderZhuoTai.ZhuoTaiName, "
								   + "OrderZhuoTaiDish.SongDanTime,OrderZhuoTaiDish.IsHuaCai,OrderZhuoTaiDish.HuaCaiNum ,OrderZhuoTaiDish.ZuoFaNames,OrderZhuoTaiDish.KouWeiNames,OrderInfo.IsWaiMai,OrderZhuoTaiDish.DishTuiCaiNum,OrderZhuoTaiDish.DishZengSongNum,OrderZhuoTaiDish.DishStatusDesc,OrderZhuoTaiDish.IsPackage,'否' as IsTaoCanDetail,'' as OrderZhuoTaiDishID "
								   + "FROM OrderZhuoTaiDish INNER JOIN "
								   + "OrderZhuoTai ON OrderZhuoTaiDish.OrderZhuoTaiID=OrderZhuoTai.UID "
								   + "INNER JOIN OrderInfo ON OrderZhuoTaiDish.OrderID=OrderInfo.UID "
								   + "WHERE OrderZhuoTaiDish.DishStatusID=1 AND OrderZhuoTai.UID IN "
								   + "(SELECT DISTINCT OrderZhuoTaiID FROM OrderZhuoTaiDish WHERE IsHuaCai=0 AND (DishNum+DishZengSongNum)>0 AND StoreID=@StoreID AND SongDanTime>@AddTime  AND OrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND OrderZhuoTaiDish.DishID NOT IN " + dishCondition + ") "
								   + " AND OrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND OrderZhuoTaiDish.DishID NOT IN " + dishCondition + (IsHuaDel() ? " and OrderZhuoTaiDish.IsHuaCai=0 " : "")
								   + " ORDER BY OrderZhuoTai.AddTime,ZhuoTaiName, OrderZhuoTaiDish.AddTime,IsHuaCai,DishTypeID,DishName";
						}
					}
					else //单品
					{
						if ("1".Equals(showDishForFinishPay))
						{
							strSql = " select * from( "
								   + "SELECT OrderZhuoTaiDish.UID, OrderZhuoTaiDish.StoreID, OrderZhuoTaiDish.OrderID, OrderZhuoTaiDish.OrderZhuoTaiID, OrderZhuoTaiDish.DishID, "
								   + "OrderZhuoTaiDish.DishName, OrderZhuoTaiDish.DishTypeID,OrderZhuoTaiDish.UnitName,(OrderZhuoTaiDish.DishNum+OrderZhuoTaiDish.DishZengSongNum) as DishNum, OrderZhuoTaiDish.DishStatusID, OrderZhuoTai.ZhuoTaiID, OrderZhuoTai.ZhuoTaiName, "
								   + "OrderZhuoTaiDish.SongDanTime,OrderZhuoTaiDish.IsHuaCai,OrderZhuoTaiDish.HuaCaiNum ,OrderZhuoTaiDish.ZuoFaNames,OrderZhuoTaiDish.KouWeiNames,OrderInfo.IsWaiMai,OrderZhuoTaiDish.DishTuiCaiNum,OrderZhuoTaiDish.DishZengSongNum,OrderZhuoTaiDish.DishStatusDesc,OrderZhuoTaiDish.IsPackage,'否' as IsTaoCanDetail,'' as OrderZhuoTaiDishID,OrderZhuoTaiDish.AddTime as DishAddTime "
								   + "FROM OrderZhuoTaiDish INNER JOIN "
								   + "OrderZhuoTai ON OrderZhuoTaiDish.OrderZhuoTaiID=OrderZhuoTai.UID "
								   + "INNER JOIN OrderInfo ON OrderZhuoTaiDish.OrderID=OrderInfo.UID "
								   + "WHERE OrderZhuoTaiDish.DishStatusID=1 AND OrderZhuoTaiDish.IsHuaCai=0  AND (OrderZhuoTaiDish.DishNum+OrderZhuoTaiDish.DishZengSongNum)>0  AND OrderZhuoTaiDish.SongDanTime>@AddTime "
								   + " AND OrderZhuoTaiDish.DishTypeID IN " + typeCondition + "  AND OrderZhuoTaiDish.DishID NOT IN " + dishCondition
								   + " UNION "
								   + "SELECT HisOrderZhuoTaiDish.UID, HisOrderZhuoTaiDish.StoreID, HisOrderZhuoTaiDish.OrderID, HisOrderZhuoTaiDish.OrderZhuoTaiID, HisOrderZhuoTaiDish.DishID, "
								   + "HisOrderZhuoTaiDish.DishName, HisOrderZhuoTaiDish.DishTypeID,HisOrderZhuoTaiDish.UnitName,(HisOrderZhuoTaiDish.DishNum+HisOrderZhuoTaiDish.DishZengSongNum) as DishNum, HisOrderZhuoTaiDish.DishStatusID, HisOrderZhuoTai.ZhuoTaiID, HisOrderZhuoTai.ZhuoTaiName, "
								   + "HisOrderZhuoTaiDish.SongDanTime,HisOrderZhuoTaiDish.IsHuaCai,HisOrderZhuoTaiDish.HuaCaiNum ,HisOrderZhuoTaiDish.ZuoFaNames,HisOrderZhuoTaiDish.KouWeiNames,HisOrderInfo.IsWaiMai,HisOrderZhuoTaiDish.DishTuiCaiNum,HisOrderZhuoTaiDish.DishZengSongNum,HisOrderZhuoTaiDish.DishStatusDesc,HisOrderZhuoTaiDish.IsPackage,'否' as IsTaoCanDetail,'' as OrderZhuoTaiDishID,HisOrderZhuoTaiDish.AddTime as DishAddTime "
								   + "FROM HisOrderZhuoTaiDish INNER JOIN "
								   + "HisOrderZhuoTai ON HisOrderZhuoTaiDish.OrderZhuoTaiID=HisOrderZhuoTai.UID "
								   + "INNER JOIN HisOrderInfo ON HisOrderZhuoTaiDish.OrderID=HisOrderInfo.UID "
								   + "WHERE HisOrderZhuoTaiDish.DishStatusID=1 AND HisOrderZhuoTaiDish.IsHuaCai=0  AND (HisOrderZhuoTaiDish.DishNum+HisOrderZhuoTaiDish.DishZengSongNum)>0  AND HisOrderZhuoTaiDish.SongDanTime>@AddTime "
								   + " AND HisOrderZhuoTaiDish.DishTypeID IN " + typeCondition + "  AND HisOrderZhuoTaiDish.DishID NOT IN " + dishCondition
								   + " ) d ORDER BY DishAddTime, ZhuoTaiName,IsHuaCai,DishTypeID,DishName";
						}
						else
						{
							strSql = "SELECT OrderZhuoTaiDish.UID, OrderZhuoTaiDish.StoreID, OrderZhuoTaiDish.OrderID, OrderZhuoTaiDish.OrderZhuoTaiID, OrderZhuoTaiDish.DishID, "
									 + "OrderZhuoTaiDish.DishName, OrderZhuoTaiDish.DishTypeID,OrderZhuoTaiDish.UnitName,(OrderZhuoTaiDish.DishNum+OrderZhuoTaiDish.DishZengSongNum) as DishNum, OrderZhuoTaiDish.DishStatusID, OrderZhuoTai.ZhuoTaiID, OrderZhuoTai.ZhuoTaiName, "
									 + "OrderZhuoTaiDish.SongDanTime,OrderZhuoTaiDish.IsHuaCai,OrderZhuoTaiDish.HuaCaiNum ,OrderZhuoTaiDish.ZuoFaNames,OrderZhuoTaiDish.KouWeiNames,OrderInfo.IsWaiMai,OrderZhuoTaiDish.DishTuiCaiNum,OrderZhuoTaiDish.DishZengSongNum,OrderZhuoTaiDish.DishStatusDesc,OrderZhuoTaiDish.IsPackage,'否' as IsTaoCanDetail,'' as OrderZhuoTaiDishID,OrderZhuoTaiDish.AddTime as DishAddTime "
									 + "FROM OrderZhuoTaiDish INNER JOIN "
									 + "OrderZhuoTai ON OrderZhuoTaiDish.OrderZhuoTaiID=OrderZhuoTai.UID "
									 + "INNER JOIN OrderInfo ON OrderZhuoTaiDish.OrderID=OrderInfo.UID "
									 + "WHERE OrderZhuoTaiDish.DishStatusID=1 AND OrderZhuoTaiDish.IsHuaCai=0  AND (OrderZhuoTaiDish.DishNum+OrderZhuoTaiDish.DishZengSongNum)>0  AND OrderZhuoTaiDish.SongDanTime>@AddTime "
									 + " AND OrderZhuoTaiDish.DishTypeID IN " + typeCondition + "  AND OrderZhuoTaiDish.DishID NOT IN " + dishCondition
									 + " ORDER BY OrderZhuoTaiDish.AddTime, ZhuoTaiName,IsHuaCai,DishTypeID,DishName";
						}
					}

				}
				else if (qiantaiMode == 1)
				{
					if (zhuotaiMode == 0)  //台卡号
					{
						strSql = "SELECT HisOrderZhuoTai.AddTime as ZTAddTime,HisOrderZhuoTaiDish.AddTime as DishAddTime,HisOrderZhuoTaiDish.UID, HisOrderZhuoTaiDish.StoreID, HisOrderZhuoTaiDish.OrderID, HisOrderZhuoTaiDish.OrderZhuoTaiID, HisOrderZhuoTaiDish.DishID, "
							   + "HisOrderZhuoTaiDish.DishName,HisOrderZhuoTaiDish.DishTypeID,HisOrderZhuoTaiDish.UnitName,(HisOrderZhuoTaiDish.DishNum+HisOrderZhuoTaiDish.DishZengSongNum) as DishNum, HisOrderZhuoTaiDish.DishStatusID, HisOrderZhuoTai.ZhuoTaiID,HisOrderZhuoTai.ZhuoTaiName, "// HisOrderInfo.TaiKaHao ZhuoTaiName, "
							   + "HisOrderZhuoTaiDish.SongDanTime,HisOrderZhuoTaiDish.IsHuaCai,HisOrderZhuoTaiDish.HuaCaiNum,HisOrderZhuoTaiDish.ZuoFaNames,HisOrderZhuoTaiDish.KouWeiNames,HisOrderInfo.IsWaiMai,HisOrderZhuoTaiDish.DishTuiCaiNum,HisOrderZhuoTaiDish.DishZengSongNum,HisOrderZhuoTaiDish.DishStatusDesc,HisOrderZhuoTaiDish.IsPackage,'否' as IsTaoCanDetail,'' as OrderZhuoTaiDishID "
							   + "FROM HisOrderZhuoTaiDish INNER JOIN "
							   + "HisOrderInfo ON HisOrderZhuoTaiDish.OrderID=HisOrderInfo.UID "
							   + " INNER JOIN HisOrderZhuoTai ON HisOrderZhuoTaiDish.OrderZhuoTaiID=HisOrderZhuoTai.UID "
							   + "WHERE HisOrderZhuoTaiDish.DishStatusID=1 AND HisOrderInfo.UID IN "
							   + "(SELECT DISTINCT OrderID FROM HisOrderZhuoTaiDish WHERE IsHuaCai=0 AND (DishNum+DishZengSongNum)>0 AND StoreID=@StoreID AND SongDanTime>@AddTime  AND HisOrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND HisOrderZhuoTaiDish.DishID NOT IN " + dishCondition + ") "
							   + " AND HisOrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND HisOrderZhuoTaiDish.DishID NOT IN " + dishCondition + (IsHuaDel() ? " and HisOrderZhuoTaiDish.IsHuaCai=0 " : "")
							   + " ORDER BY HisOrderZhuoTai.AddTime,ZhuoTaiName,HisOrderZhuoTaiDish.AddTime,IsHuaCai,DishTypeID,DishName";
					}
					else if (zhuotaiMode == 1)  //桌台
					{
						strSql = "SELECT HisOrderZhuoTai.AddTime as ZTAddTime,HisOrderZhuoTaiDish.AddTime as DishAddTime,HisOrderZhuoTaiDish.UID, HisOrderZhuoTaiDish.StoreID, HisOrderZhuoTaiDish.OrderID, HisOrderZhuoTaiDish.OrderZhuoTaiID, HisOrderZhuoTaiDish.DishID, "
							   + "HisOrderZhuoTaiDish.DishName,HisOrderZhuoTaiDish.DishTypeID,HisOrderZhuoTaiDish.UnitName,(HisOrderZhuoTaiDish.DishNum+HisOrderZhuoTaiDish.DishZengSongNum) as DishNum, HisOrderZhuoTaiDish.DishStatusID, HisOrderZhuoTai.ZhuoTaiID, HisOrderZhuoTai.ZhuoTaiName, "
							   + "HisOrderZhuoTaiDish.SongDanTime,HisOrderZhuoTaiDish.IsHuaCai,HisOrderZhuoTaiDish.HuaCaiNum,HisOrderZhuoTaiDish.ZuoFaNames,HisOrderZhuoTaiDish.KouWeiNames,HisOrderInfo.IsWaiMai,HisOrderZhuoTaiDish.DishTuiCaiNum,HisOrderZhuoTaiDish.DishZengSongNum,HisOrderZhuoTaiDish.DishStatusDesc,HisOrderZhuoTaiDish.IsPackage,'否' as IsTaoCanDetail,'' as OrderZhuoTaiDishID "
							   + "FROM HisOrderZhuoTaiDish INNER JOIN "
							   + "HisOrderZhuoTai ON HisOrderZhuoTaiDish.OrderZhuoTaiID=HisOrderZhuoTai.UID "
							   + " INNER JOIN HisOrderInfo ON HisOrderZhuoTaiDish.OrderID=HisOrderInfo.UID "
							   + "WHERE HisOrderZhuoTaiDish.DishStatusID=1 AND HisOrderZhuoTai.UID IN "
							   + "(SELECT DISTINCT OrderZhuoTaiID FROM HisOrderZhuoTaiDish WHERE IsHuaCai=0 AND (DishNum+DishZengSongNum)>0 AND StoreID=@StoreID AND SongDanTime>@AddTime  AND HisOrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND HisOrderZhuoTaiDish.DishID NOT IN " + dishCondition + ") "
							   + " AND HisOrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND HisOrderZhuoTaiDish.DishID NOT IN " + dishCondition + (IsHuaDel() ? " and HisOrderZhuoTaiDish.IsHuaCai=0 " : "")
							   + " ORDER BY HisOrderZhuoTai.AddTime,ZhuoTaiName,HisOrderZhuoTaiDish.AddTime,IsHuaCai,DishTypeID,DishName";
					}
					else if (zhuotaiMode == 2)
					{
						strSql = "SELECT HisOrderZhuoTaiDish.UID, HisOrderZhuoTaiDish.StoreID, HisOrderZhuoTaiDish.OrderID, HisOrderZhuoTaiDish.OrderZhuoTaiID, HisOrderZhuoTaiDish.DishID, "
							   + "HisOrderZhuoTaiDish.DishName,HisOrderZhuoTaiDish.DishTypeID,HisOrderZhuoTaiDish.UnitName,(HisOrderZhuoTaiDish.DishNum+HisOrderZhuoTaiDish.DishZengSongNum) as DishNum, HisOrderZhuoTaiDish.DishStatusID, HisOrderZhuoTai.ZhuoTaiID, HisOrderZhuoTai.ZhuoTaiName, "
							   + "HisOrderInfo.JieSuanTime SongDanTime,HisOrderZhuoTaiDish.IsHuaCai,HisOrderZhuoTaiDish.HuaCaiNum,HisOrderZhuoTaiDish.ZuoFaNames,HisOrderZhuoTaiDish.KouWeiNames,HisOrderInfo.IsWaiMai,HisOrderZhuoTaiDish.DishTuiCaiNum,HisOrderZhuoTaiDish.DishZengSongNum,HisOrderZhuoTaiDish.DishStatusDesc,HisOrderZhuoTaiDish.IsPackage,'否' as IsTaoCanDetail,'' as OrderZhuoTaiDishID,HisOrderZhuoTaiDish.AddTime as DishAddTime "
							   + "FROM HisOrderZhuoTaiDish INNER JOIN HisOrderInfo ON HisOrderZhuoTaiDish.OrderID=HisOrderInfo.UID "
							   + "LEFT JOIN HisOrderZhuoTai ON HisOrderZhuoTaiDish.OrderZhuoTaiID=HisOrderZhuoTai.UID "
							   + "WHERE HisOrderZhuoTaiDish.DishStatusID=1 AND HisOrderZhuoTaiDish.IsHuaCai=0 AND (HisOrderZhuoTaiDish.DishNum+HisOrderZhuoTaiDish.DishZengSongNum)>0  AND HisOrderZhuoTaiDish.StoreID=@StoreID AND HisOrderZhuoTaiDish.SongDanTime>@AddTime "
							   + " AND HisOrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND HisOrderZhuoTaiDish.DishID NOT IN " + dishCondition
							   + " ORDER BY HisOrderZhuoTaiDish.AddTime,ZhuoTaiName,IsHuaCai,DishTypeID,DishName";
					}
				}


				string strConn = ConfigurationManager.AppSettings["dbconn"];
				DataTable table = new DataTable();

				using (SqlConnection conn = new SqlConnection(strConn))
				{
					SqlCommand cmd = conn.CreateCommand();
					cmd.CommandText = strSql;
					cmd.Parameters.AddWithValue("@StoreID", Tools.CurrentUser.StoreID);
					cmd.Parameters.AddWithValue("@AddTime", startTime);
					SqlDataAdapter adapter = new SqlDataAdapter(cmd);
					try
					{
						conn.Open();
						adapter.Fill(table);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message);
					}
				}

				GetOrderGuQing();

				//获取外卖--数据  select 字段 同步上面sql
				DataTable dtTpm = QueryKCWaiMaiOrder(table);
				table.Clear();
				table = dtTpm.Copy();

				if (zhuotaiMode == 0 || zhuotaiMode == 1)
				{

					string ifsort = ConfigurationManager.AppSettings["ifsort"];
					if ("0".Equals(ifsort) || object.Equals(ifsort, null))
					{
						if (qiantaiMode == 0)
							ShowZhuoTaiDish(QueryTaoCan(table));
						else
							ShowZhuoTaiDish(table);
					}
					else
						ShowZhuoTaiDish(CloneTable(table));
				}
				else if (zhuotaiMode == 2)
				{
					string ifsort = ConfigurationManager.AppSettings["ifsort"];
					if ("0".Equals(ifsort) || object.Equals(ifsort, null))
						ShowDishs(table);
					else
						ShowDishs(CloneTable(table));
				}
			}
			catch (Exception ex)
			{
				Log.WriteLog("LoadAllZhuoTaiDish startTime:" + startTime);
				Log.WriteLog("LoadAllZhuoTaiDish 错误信息:" + ex.ToString());
			}

		}

		public DataTable QueryTaoCan(DataTable table)
		{
			DataTable curTable;
			curTable = table.Clone();
			try
			{
				if (object.Equals(table, null))
				{
					Log.WriteLog("QueryTaoCan table为NULL");
					return table;
				}
				#region //【目的】：将等叫的桌台放在最后面---获取所有起菜和等叫的桌台
				List<string> listDishStatusQiCai = new List<string>();       //用于存放所有【起菜】的桌台
				List<string> listDishStatusDengJiao = new List<string>();    //用于存放所有【等叫】的桌台
				DataRow[] strDj = table.Select("DishStatusDesc='等叫'", "ZTAddTime,ZhuoTaiName, DishAddTime,IsHuaCai,DishTypeID,DishName");
				foreach (DataRow drDish in strDj)
				{
					string ZhuoTaiID = drDish["ZhuoTaiID"] as string;
					if (!listDishStatusDengJiao.Contains(ZhuoTaiID))
					{
						listDishStatusDengJiao.Add(ZhuoTaiID);
					}
				}

				DataRow[] strQc = table.Select("DishStatusDesc<>'等叫'", "ZTAddTime,ZhuoTaiName, DishAddTime,IsHuaCai,DishTypeID,DishName");
				foreach (DataRow drDish in strQc)
				{
					string ZhuoTaiID = drDish["ZhuoTaiID"] as string;
					if (!listDishStatusDengJiao.Contains(ZhuoTaiID) && !listDishStatusQiCai.Contains(ZhuoTaiID))
					{
						listDishStatusQiCai.Add(ZhuoTaiID);
					}
				}

				#endregion

				#region //拼接套餐【目的】：可以划菜单个套餐菜品
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

				//注释【此sql语句所有字段排序必须与LoadAllZhuoTaiDish 的 sql 字段 排序一致】【===否则问题很大===】【目的：拼接表格】
				string strSql = "";
				string showDishForFinishPay = ConfigurationManager.AppSettings["showDishForFinishPay"];
				if ("1".Equals(showDishForFinishPay))
				{
					strSql = "select * from ("
					+ "SELECT  OrderZhuoTai.AddTime as ZTAddTime,OrderPackageDishDetail.AddTime as DishAddTime,OrderPackageDishDetail.UID, OrderPackageDishDetail.StoreID, OrderPackageDishDetail.OrderID, OrderPackageDishDetail.OrderZhuoTaiID, OrderPackageDishDetail.DishID, "
					+ "OrderPackageDishDetail.DishName, OrderPackageDishDetail.DishTypeID,OrderPackageDishDetail.UnitName,(OrderPackageDishDetail.DishNum+OrderPackageDishDetail.DishZengSongNum) as DishNum, OrderPackageDishDetail.DishStatusID, OrderZhuoTai.ZhuoTaiID, OrderZhuoTai.ZhuoTaiName, "
					+ "OrderZhuoTaiDish.SongDanTime,OrderPackageDishDetail.IfHuaCai as IsHuaCai,OrderPackageDishDetail.HuaCaiNum ,OrderPackageDishDetail.ZuoFaNames,OrderPackageDishDetail.KouWeiNames,OrderInfo.IsWaiMai,OrderPackageDishDetail.DishTuiCaiNum,OrderPackageDishDetail.DishZengSongNum,OrderPackageDishDetail.DishStatusDesc,0 as IsPackage,'是' as IsTaoCanDetail,OrderPackageDishDetail.OrderZhuoTaiDishID "
					+ "FROM OrderZhuoTaiDish INNER JOIN "
					+ "OrderZhuoTai ON OrderZhuoTaiDish.OrderZhuoTaiID=OrderZhuoTai.UID "
					+ "INNER JOIN OrderInfo ON OrderZhuoTaiDish.OrderID=OrderInfo.UID "
					+ "INNER JOIN OrderPackageDishDetail ON OrderPackageDishDetail.OrderZhuoTaiDishID=OrderZhuoTaiDish.UID "
					+ "WHERE OrderZhuoTaiDish.DishStatusID=1 AND OrderZhuoTai.UID IN "
					+ "(SELECT DISTINCT OrderZhuoTaiID FROM OrderZhuoTaiDish WHERE IsHuaCai=0 AND (DishNum+DishZengSongNum)>0 AND StoreID=" + Tools.CurrentUser.StoreID + " AND SongDanTime>'" + startTime + "'  AND OrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND OrderZhuoTaiDish.DishID NOT IN " + dishCondition + ") "
					+ " AND OrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND OrderZhuoTaiDish.DishID NOT IN " + dishCondition
					+ " UNION "
					+ " SELECT  HisOrderZhuoTai.AddTime as ZTAddTime,HisOrderPackageDishDetail.AddTime as DishAddTime,HisOrderPackageDishDetail.UID, HisOrderPackageDishDetail.StoreID, HisOrderPackageDishDetail.OrderID, HisOrderPackageDishDetail.OrderZhuoTaiID, HisOrderPackageDishDetail.DishID, "
					+ " HisOrderPackageDishDetail.DishName, HisOrderPackageDishDetail.DishTypeID,HisOrderPackageDishDetail.UnitName,(HisOrderPackageDishDetail.DishNum+HisOrderPackageDishDetail.DishZengSongNum) as DishNum, HisOrderPackageDishDetail.DishStatusID, HisOrderZhuoTai.ZhuoTaiID, HisOrderZhuoTai.ZhuoTaiName, "
					+ "HisOrderZhuoTaiDish.SongDanTime,HisOrderPackageDishDetail.IfHuaCai as IsHuaCai,HisOrderPackageDishDetail.HuaCaiNum ,HisOrderPackageDishDetail.ZuoFaNames,HisOrderPackageDishDetail.KouWeiNames,HisOrderInfo.IsWaiMai,HisOrderPackageDishDetail.DishTuiCaiNum,HisOrderPackageDishDetail.DishZengSongNum,HisOrderPackageDishDetail.DishStatusDesc,0 as IsPackage,'是' as IsTaoCanDetail,HisOrderPackageDishDetail.OrderZhuoTaiDishID "
					+ "FROM HisOrderZhuoTaiDish INNER JOIN "
					+ "HisOrderZhuoTai ON HisOrderZhuoTaiDish.OrderZhuoTaiID=HisOrderZhuoTai.UID "
					+ "INNER JOIN HisOrderInfo ON HisOrderZhuoTaiDish.OrderID=HisOrderInfo.UID "
					+ "INNER JOIN HisOrderPackageDishDetail ON HisOrderPackageDishDetail.OrderZhuoTaiDishID=HisOrderZhuoTaiDish.UID "
					+ "WHERE HisOrderZhuoTaiDish.DishStatusID=1 AND HisOrderZhuoTai.UID IN "
					+ "(SELECT DISTINCT OrderZhuoTaiID FROM HisOrderZhuoTaiDish WHERE IsHuaCai=0 AND (DishNum+DishZengSongNum)>0 AND StoreID=" + Tools.CurrentUser.StoreID + " AND SongDanTime>'" + startTime + "'  AND HisOrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND HisOrderZhuoTaiDish.DishID NOT IN " + dishCondition + ") "
					+ " AND HisOrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND HisOrderZhuoTaiDish.DishID NOT IN " + dishCondition
					+ ") as t  " + (IsHuaDel() ? " where IsHuaCai=0 " : "") + "  order by ZTAddTime,ZhuoTaiName,IsHuaCai,DishTypeID,DishName";
				}
				else
				{
					strSql = "SELECT  OrderZhuoTai.AddTime as ZTAddTime,OrderPackageDishDetail.AddTime as DishAddTime,OrderPackageDishDetail.UID, OrderPackageDishDetail.StoreID, OrderPackageDishDetail.OrderID, OrderPackageDishDetail.OrderZhuoTaiID, OrderPackageDishDetail.DishID, "
				   + "OrderPackageDishDetail.DishName, OrderPackageDishDetail.DishTypeID,OrderPackageDishDetail.UnitName,(OrderPackageDishDetail.DishNum+OrderPackageDishDetail.DishZengSongNum) as DishNum, OrderPackageDishDetail.DishStatusID, OrderZhuoTai.ZhuoTaiID, OrderZhuoTai.ZhuoTaiName, "
				   + "OrderZhuoTaiDish.SongDanTime,OrderPackageDishDetail.IfHuaCai as IsHuaCai,OrderPackageDishDetail.HuaCaiNum ,OrderPackageDishDetail.ZuoFaNames,OrderPackageDishDetail.KouWeiNames,OrderInfo.IsWaiMai,OrderPackageDishDetail.DishTuiCaiNum,OrderPackageDishDetail.DishZengSongNum,OrderPackageDishDetail.DishStatusDesc,0 as IsPackage,'是' as IsTaoCanDetail,OrderPackageDishDetail.OrderZhuoTaiDishID "
				   + "FROM OrderZhuoTaiDish INNER JOIN "
				   + "OrderZhuoTai ON OrderZhuoTaiDish.OrderZhuoTaiID=OrderZhuoTai.UID "
				   + "INNER JOIN OrderInfo ON OrderZhuoTaiDish.OrderID=OrderInfo.UID "
				   + "INNER JOIN OrderPackageDishDetail ON OrderPackageDishDetail.OrderZhuoTaiDishID=OrderZhuoTaiDish.UID "
				   + "WHERE OrderZhuoTaiDish.DishStatusID=1 AND OrderZhuoTai.UID IN "
				   + "(SELECT DISTINCT OrderZhuoTaiID FROM OrderZhuoTaiDish WHERE IsHuaCai=0 AND (DishNum+DishZengSongNum)>0 AND StoreID=" + Tools.CurrentUser.StoreID + " AND SongDanTime>'" + startTime + "'  AND OrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND OrderZhuoTaiDish.DishID NOT IN " + dishCondition + ") "
				   + " AND OrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND OrderZhuoTaiDish.DishID NOT IN " + dishCondition + (IsHuaDel() ? " and OrderPackageDishDetail.IfHuaCai=0 " : "")
				   + " ORDER BY OrderZhuoTai.AddTime,OrderZhuoTai.ZhuoTaiName, OrderPackageDishDetail.AddTime,OrderPackageDishDetail.IfHuaCai,OrderPackageDishDetail.DishTypeID,OrderPackageDishDetail.DishName";
				}
				DataTable tableTaoCan = DBHelper.ExeSqlForDataTable(strSql);

				#endregion



				#region //重新拼接table
				string conditionQC = string.Empty;
				for (int i = 0; i < listDishStatusQiCai.Count; i++)
				{
					if (string.IsNullOrEmpty(conditionQC))
						conditionQC = "ZhuoTaiID='" + listDishStatusQiCai[i] + "'";
					else
						conditionQC += " OR ZhuoTaiID='" + listDishStatusQiCai[i] + "'";
				}
				if (!string.IsNullOrEmpty(conditionQC))
				{

					DataRow[] dr = table.Select(conditionQC, "ZTAddTime,ZhuoTaiName, DishAddTime,IsHuaCai,DishTypeID,DishName");

					foreach (DataRow drDJ in dr)
					{
						DataRow newRow = curTable.NewRow();
						curTable.Rows.Add(newRow);
						for (int i = 0; i < drDJ.ItemArray.Length; i++)
						{
							newRow[i] = drDJ[i];
						}

						var ispackage = (bool)drDJ["IsPackage"];
						if (ispackage)
						{
							string dishUID = drDJ["UID"] as string;
							DataRow[] drPackage = tableTaoCan.Select("OrderZhuoTaiDishID='" + dishUID + "'", "ZTAddTime,ZhuoTaiName,IsHuaCai, DishAddTime,DishTypeID,DishName");
							foreach (DataRow drpackageTmp in drPackage)
							{
								DataRow newRowPackage = curTable.NewRow();
								curTable.Rows.Add(newRowPackage);
								for (int i = 0; i < drpackageTmp.ItemArray.Length; i++)
								{
									newRowPackage[i] = drpackageTmp[i];
								}
							}
						}
					}
				}

				string conditionDJ = string.Empty;
				for (int i = 0; i < listDishStatusDengJiao.Count; i++)
				{
					if (string.IsNullOrEmpty(conditionDJ))
						conditionDJ = "ZhuoTaiID='" + listDishStatusDengJiao[i] + "'";
					else
						conditionDJ += " OR ZhuoTaiID='" + listDishStatusDengJiao[i] + "'";
				}

				if (!string.IsNullOrEmpty(conditionDJ))
				{
					DataRow[] dr = table.Select(conditionDJ, "ZTAddTime,ZhuoTaiName, DishAddTime,IsHuaCai,DishTypeID,DishName");

					foreach (DataRow drDJ in dr)
					{
						DataRow newRow = curTable.NewRow();
						curTable.Rows.Add(newRow);
						for (int i = 0; i < drDJ.ItemArray.Length; i++)
						{
							newRow[i] = drDJ[i];
						}

						var ispackage = (bool)drDJ["IsPackage"];
						if (ispackage)
						{
							string dishUID = drDJ["UID"] as string;
							DataRow[] drPackage = tableTaoCan.Select("OrderZhuoTaiDishID='" + dishUID + "'", "ZTAddTime,ZhuoTaiName,IsHuaCai, DishAddTime,DishTypeID,DishName");

							foreach (DataRow drpackageTmp in drPackage)
							{
								DataRow newRowPackage = curTable.NewRow();
								curTable.Rows.Add(newRowPackage);
								for (int i = 0; i < drpackageTmp.ItemArray.Length; i++)
								{
									newRowPackage[i] = drpackageTmp[i];
								}
							}
						}
					}
				}

				#endregion



				return curTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show("QueryTaoCan 错误原因:" + ex.ToString());

			}

			return curTable;
		}

		public DataTable QueryKCWaiMaiOrder(DataTable paramTable)
		{
			DataTable curTable = new DataTable();
			int zhuotaiMode = int.Parse(strZhuotaiMode);

			string strSql = string.Empty;
			try
			{
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

				string showDishForFinishPay = ConfigurationManager.AppSettings["showDishForFinishPay"];
				if (zhuotaiMode == 0)
				{
					if ("1".Equals(showDishForFinishPay))
					{
						#region //台卡号
						strSql = " SELECT * FROM ( "
							   + " SELECT OrderZhuoTai.AddTime as ZTAddTime,OrderZhuoTaiDish.AddTime as DishAddTime,OrderZhuoTaiDish.UID, OrderZhuoTaiDish.StoreID, OrderZhuoTaiDish.OrderID, OrderZhuoTaiDish.OrderZhuoTaiID, OrderZhuoTaiDish.DishID, "
							   + " OrderZhuoTaiDish.DishName,OrderZhuoTaiDish.DishTypeID,OrderZhuoTaiDish.UnitName,(OrderZhuoTaiDish.DishNum+OrderZhuoTaiDish.DishZengSongNum) as DishNum, OrderZhuoTaiDish.DishStatusID,  OrderZhuoTai.ZhuoTaiID,OrderZhuoTai.ZhuoTaiName, "// OrderInfo.TaiKaHao ZhuoTaiName, "
							   + " OrderZhuoTaiDish.SongDanTime,OrderZhuoTaiDish.IsHuaCai,OrderZhuoTaiDish.HuaCaiNum,OrderZhuoTaiDish.ZuoFaNames,OrderZhuoTaiDish.KouWeiNames,OrderInfo.IsWaiMai,OrderZhuoTaiDish.DishTuiCaiNum,OrderZhuoTaiDish.DishZengSongNum,OrderZhuoTaiDish.DishStatusDesc,OrderZhuoTaiDish.IsPackage,'否' as IsTaoCanDetail,'' as OrderZhuoTaiDishID "
							   + " FROM OrderZhuoTaiDish INNER JOIN "
							   + " OrderInfo ON OrderZhuoTaiDish.OrderID=OrderInfo.UID "
							   + " INNER JOIN OrderZhuoTai ON OrderZhuoTaiDish.OrderZhuoTaiID=OrderZhuoTai.UID "
							   + " INNER JOIN OrderWaiMaiAddress ON OrderWaiMaiAddress.OrderId=OrderInfo.UID "
							   + " WHERE OrderZhuoTaiDish.DishStatusID=1  AND OrderInfo.UID IN "
							   + " (SELECT DISTINCT OrderID FROM OrderZhuoTaiDish WHERE IsHuaCai=0 AND (DishNum+DishZengSongNum)>0 AND StoreID=" + Tools.CurrentUser.StoreID + " AND SongDanTime>'" + startTime + "'  AND OrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND OrderZhuoTaiDish.DishID NOT IN " + dishCondition + ") "
							   + " AND OrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND OrderZhuoTaiDish.DishID NOT IN " + dishCondition
							   + " AND (OrderWaiMaiAddress.Source=11 or OrderWaiMaiAddress.Source=12 or OrderWaiMaiAddress.Source=13 or OrderWaiMaiAddress.Source=0) and HasAccept=1 "
							   + " UNION ALL "
							   + " SELECT HisOrderZhuoTai.AddTime as ZTAddTime,HisOrderZhuoTaiDish.AddTime as DishAddTime,HisOrderZhuoTaiDish.UID, HisOrderZhuoTaiDish.StoreID, HisOrderZhuoTaiDish.OrderID, HisOrderZhuoTaiDish.OrderZhuoTaiID, HisOrderZhuoTaiDish.DishID, "
							   + " HisOrderZhuoTaiDish.DishName,HisOrderZhuoTaiDish.DishTypeID,HisOrderZhuoTaiDish.UnitName,(HisOrderZhuoTaiDish.DishNum+HisOrderZhuoTaiDish.DishZengSongNum) as DishNum, HisOrderZhuoTaiDish.DishStatusID,  HisOrderZhuoTai.ZhuoTaiID,HisOrderZhuoTai.ZhuoTaiName, "// OrderInfo.TaiKaHao ZhuoTaiName, "
							   + " HisOrderZhuoTaiDish.SongDanTime,HisOrderZhuoTaiDish.IsHuaCai,HisOrderZhuoTaiDish.HuaCaiNum,HisOrderZhuoTaiDish.ZuoFaNames,HisOrderZhuoTaiDish.KouWeiNames,HisOrderInfo.IsWaiMai,HisOrderZhuoTaiDish.DishTuiCaiNum,HisOrderZhuoTaiDish.DishZengSongNum,HisOrderZhuoTaiDish.DishStatusDesc,HisOrderZhuoTaiDish.IsPackage,'否' as IsTaoCanDetail,'' as OrderZhuoTaiDishID "
							   + " FROM HisOrderZhuoTaiDish INNER JOIN "
							   + " HisOrderInfo ON HisOrderZhuoTaiDish.OrderID=HisOrderInfo.UID "
							   + " INNER JOIN HisOrderZhuoTai ON HisOrderZhuoTaiDish.OrderZhuoTaiID=HisOrderZhuoTai.UID "
							   + " INNER JOIN HisOrderWaiMaiAddress ON HisOrderWaiMaiAddress.OrderId=HisOrderInfo.UID "
							   + " WHERE HisOrderZhuoTaiDish.DishStatusID=1  AND HisOrderInfo.UID IN "
							   + " (SELECT DISTINCT OrderID FROM HisOrderZhuoTaiDish WHERE IsHuaCai=0 AND (DishNum+DishZengSongNum)>0 AND StoreID=" + Tools.CurrentUser.StoreID + " AND SongDanTime>'" + startTime + "'  AND HisOrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND HisOrderZhuoTaiDish.DishID NOT IN " + dishCondition + ") "
							   + " AND HisOrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND HisOrderZhuoTaiDish.DishID NOT IN " + dishCondition
							   + " AND (HisOrderWaiMaiAddress.Source=11 or HisOrderWaiMaiAddress.Source=12 or HisOrderWaiMaiAddress.Source=13 or HisOrderWaiMaiAddress.Source=0) and HasAccept=1 "
							   + " ) tmpTable " + (IsHuaDel() ? " where IsHuaCai=0 " : "") + " ORDER BY ZTAddTime,ZhuoTaiName,DishAddTime,IsHuaCai,DishTypeID,DishName ";
						#endregion
					}
					else
					{
						strSql = " SELECT * FROM ( "
							   + " SELECT OrderZhuoTai.AddTime as ZTAddTime,OrderZhuoTaiDish.AddTime as DishAddTime,OrderZhuoTaiDish.UID, OrderZhuoTaiDish.StoreID, OrderZhuoTaiDish.OrderID, OrderZhuoTaiDish.OrderZhuoTaiID, OrderZhuoTaiDish.DishID, "
							   + " OrderZhuoTaiDish.DishName,OrderZhuoTaiDish.DishTypeID,OrderZhuoTaiDish.UnitName,(OrderZhuoTaiDish.DishNum+OrderZhuoTaiDish.DishZengSongNum) as DishNum, OrderZhuoTaiDish.DishStatusID,  OrderZhuoTai.ZhuoTaiID,OrderZhuoTai.ZhuoTaiName, "// OrderInfo.TaiKaHao ZhuoTaiName, "
							   + " OrderZhuoTaiDish.SongDanTime,OrderZhuoTaiDish.IsHuaCai,OrderZhuoTaiDish.HuaCaiNum,OrderZhuoTaiDish.ZuoFaNames,OrderZhuoTaiDish.KouWeiNames,OrderInfo.IsWaiMai,OrderZhuoTaiDish.DishTuiCaiNum,OrderZhuoTaiDish.DishZengSongNum,OrderZhuoTaiDish.DishStatusDesc,OrderZhuoTaiDish.IsPackage,'否' as IsTaoCanDetail,'' as OrderZhuoTaiDishID "
							   + " FROM OrderZhuoTaiDish INNER JOIN "
							   + " OrderInfo ON OrderZhuoTaiDish.OrderID=OrderInfo.UID "
							   + " INNER JOIN OrderZhuoTai ON OrderZhuoTaiDish.OrderZhuoTaiID=OrderZhuoTai.UID "
							   + " INNER JOIN OrderWaiMaiAddress ON OrderWaiMaiAddress.OrderId=OrderInfo.UID "
							   + " WHERE OrderZhuoTaiDish.DishStatusID=1  AND OrderInfo.UID IN "
							   + " (SELECT DISTINCT OrderID FROM OrderZhuoTaiDish WHERE IsHuaCai=0 AND (DishNum+DishZengSongNum)>0 AND StoreID=" + Tools.CurrentUser.StoreID + " AND SongDanTime>'" + startTime + "'  AND OrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND OrderZhuoTaiDish.DishID NOT IN " + dishCondition + ") "
							   + " AND OrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND OrderZhuoTaiDish.DishID NOT IN " + dishCondition
							   + " AND (OrderWaiMaiAddress.Source=11 or OrderWaiMaiAddress.Source=12 or OrderWaiMaiAddress.Source=13 or OrderWaiMaiAddress.Source=0) and HasAccept=1 "
							   + " ) tmpTable " + (IsHuaDel() ? " where IsHuaCai=0 " : "") + " ORDER BY ZTAddTime,ZhuoTaiName,DishAddTime,IsHuaCai,DishTypeID,DishName ";
					}
				}
				else if (zhuotaiMode == 1)
				{
					if ("1".Equals(showDishForFinishPay))
					{
						#region //桌台
						strSql = " select * from ( "
							   + " SELECT OrderZhuoTai.AddTime as ZTAddTime,OrderZhuoTaiDish.AddTime as DishAddTime,OrderZhuoTaiDish.UID, OrderZhuoTaiDish.StoreID, OrderZhuoTaiDish.OrderID, OrderZhuoTaiDish.OrderZhuoTaiID, OrderZhuoTaiDish.DishID, "
							   + " OrderZhuoTaiDish.DishName,OrderZhuoTaiDish.DishTypeID,OrderZhuoTaiDish.UnitName,(OrderZhuoTaiDish.DishNum+OrderZhuoTaiDish.DishZengSongNum) as DishNum, OrderZhuoTaiDish.DishStatusID, OrderZhuoTai.ZhuoTaiID, OrderZhuoTai.ZhuoTaiName, "
							   + " OrderZhuoTaiDish.SongDanTime,OrderZhuoTaiDish.IsHuaCai,OrderZhuoTaiDish.HuaCaiNum,OrderZhuoTaiDish.ZuoFaNames,OrderZhuoTaiDish.KouWeiNames,OrderInfo.IsWaiMai,OrderZhuoTaiDish.DishTuiCaiNum,OrderZhuoTaiDish.DishZengSongNum,OrderZhuoTaiDish.DishStatusDesc,OrderZhuoTaiDish.IsPackage,'否' as IsTaoCanDetail,'' as OrderZhuoTaiDishID "
							   + " FROM OrderZhuoTaiDish  "
							   + " INNER JOIN OrderZhuoTai ON OrderZhuoTaiDish.OrderZhuoTaiID=OrderZhuoTai.UID "
							   + " INNER JOIN OrderWaiMaiAddress ON OrderWaiMaiAddress.OrderId=OrderZhuoTaiDish.OrderID "
							   + " INNER JOIN OrderInfo ON OrderZhuoTaiDish.OrderID=OrderInfo.UID "
							   + " WHERE OrderZhuoTaiDish.DishStatusID=1 AND OrderZhuoTai.UID IN "
							   + " (SELECT DISTINCT OrderZhuoTaiID FROM OrderZhuoTaiDish WHERE IsHuaCai=0 AND (DishNum+DishZengSongNum)>0 AND StoreID=" + Tools.CurrentUser.StoreID + " AND SongDanTime>'" + startTime + "' AND OrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND OrderZhuoTaiDish.DishID NOT IN " + dishCondition + ") "
							   + " AND (OrderWaiMaiAddress.Source=11 or OrderWaiMaiAddress.Source=12 or OrderWaiMaiAddress.Source=13 or OrderWaiMaiAddress.Source=0) and HasAccept=1 "
							   + " AND OrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND OrderZhuoTaiDish.DishID NOT IN " + dishCondition
							   + " UNION ALL "
							   + " SELECT HisOrderZhuoTai.AddTime as ZTAddTime,HisOrderZhuoTaiDish.AddTime as DishAddTime,HisOrderZhuoTaiDish.UID, HisOrderZhuoTaiDish.StoreID, HisOrderZhuoTaiDish.OrderID, HisOrderZhuoTaiDish.OrderZhuoTaiID, HisOrderZhuoTaiDish.DishID, "
							   + " HisOrderZhuoTaiDish.DishName,HisOrderZhuoTaiDish.DishTypeID,HisOrderZhuoTaiDish.UnitName,(HisOrderZhuoTaiDish.DishNum+HisOrderZhuoTaiDish.DishZengSongNum) as DishNum, HisOrderZhuoTaiDish.DishStatusID, HisOrderZhuoTai.ZhuoTaiID, HisOrderZhuoTai.ZhuoTaiName, "
							   + " HisOrderZhuoTaiDish.SongDanTime,HisOrderZhuoTaiDish.IsHuaCai,HisOrderZhuoTaiDish.HuaCaiNum,HisOrderZhuoTaiDish.ZuoFaNames,HisOrderZhuoTaiDish.KouWeiNames,HisOrderInfo.IsWaiMai,HisOrderZhuoTaiDish.DishTuiCaiNum,HisOrderZhuoTaiDish.DishZengSongNum,HisOrderZhuoTaiDish.DishStatusDesc,HisOrderZhuoTaiDish.IsPackage,'否' as IsTaoCanDetail,'' as OrderZhuoTaiDishID "
							   + " FROM HisOrderZhuoTaiDish  "
							   + " INNER JOIN HisOrderZhuoTai ON HisOrderZhuoTaiDish.OrderZhuoTaiID=HisOrderZhuoTai.UID "
							   + " INNER JOIN HisOrderWaiMaiAddress ON HisOrderWaiMaiAddress.OrderId=HisOrderZhuoTaiDish.OrderID "
							   + " INNER JOIN HisOrderInfo ON HisOrderZhuoTaiDish.OrderID=HisOrderInfo.UID "
							   + " WHERE HisOrderZhuoTaiDish.DishStatusID=1 AND HisOrderZhuoTai.UID IN "
							   + " (SELECT DISTINCT OrderZhuoTaiID FROM HisOrderZhuoTaiDish WHERE IsHuaCai=0 AND (DishNum+DishZengSongNum)>0 AND StoreID=" + Tools.CurrentUser.StoreID + " AND SongDanTime>'" + startTime + "'  AND HisOrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND HisOrderZhuoTaiDish.DishID NOT IN " + dishCondition + " ) "
							   + " AND (HisOrderWaiMaiAddress.Source=11 or HisOrderWaiMaiAddress.Source=12 or HisOrderWaiMaiAddress.Source=13 or HisOrderWaiMaiAddress.Source=0) and HasAccept=1 "
							   + " AND HisOrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND HisOrderZhuoTaiDish.DishID NOT IN " + dishCondition
							   + " )tmpTable  " + (IsHuaDel() ? " where IsHuaCai=0 " : "") + "  ORDER BY ZTAddTime,ZhuoTaiName,DishAddTime,IsHuaCai,DishTypeID,DishName ";

						#endregion
					}
					else
					{
						strSql = " select * from ( "
							   + " SELECT OrderZhuoTai.AddTime as ZTAddTime,OrderZhuoTaiDish.AddTime as DishAddTime,OrderZhuoTaiDish.UID, OrderZhuoTaiDish.StoreID, OrderZhuoTaiDish.OrderID, OrderZhuoTaiDish.OrderZhuoTaiID, OrderZhuoTaiDish.DishID, "
							   + " OrderZhuoTaiDish.DishName,OrderZhuoTaiDish.DishTypeID,OrderZhuoTaiDish.UnitName,(OrderZhuoTaiDish.DishNum+OrderZhuoTaiDish.DishZengSongNum) as DishNum, OrderZhuoTaiDish.DishStatusID, OrderZhuoTai.ZhuoTaiID, OrderZhuoTai.ZhuoTaiName, "
							   + " OrderZhuoTaiDish.SongDanTime,OrderZhuoTaiDish.IsHuaCai,OrderZhuoTaiDish.HuaCaiNum,OrderZhuoTaiDish.ZuoFaNames,OrderZhuoTaiDish.KouWeiNames,OrderInfo.IsWaiMai,OrderZhuoTaiDish.DishTuiCaiNum,OrderZhuoTaiDish.DishZengSongNum,OrderZhuoTaiDish.DishStatusDesc,OrderZhuoTaiDish.IsPackage,'否' as IsTaoCanDetail,'' as OrderZhuoTaiDishID "
							   + " FROM OrderZhuoTaiDish  "
							   + " INNER JOIN OrderZhuoTai ON OrderZhuoTaiDish.OrderZhuoTaiID=OrderZhuoTai.UID "
							   + " INNER JOIN OrderWaiMaiAddress ON OrderWaiMaiAddress.OrderId=OrderZhuoTaiDish.OrderID "
							   + " INNER JOIN OrderInfo ON OrderZhuoTaiDish.OrderID=OrderInfo.UID "
							   + " WHERE OrderZhuoTaiDish.DishStatusID=1 AND OrderZhuoTai.UID IN "
							   + " (SELECT DISTINCT OrderZhuoTaiID FROM OrderZhuoTaiDish WHERE IsHuaCai=0 AND (DishNum+DishZengSongNum)>0 AND StoreID=" + Tools.CurrentUser.StoreID + " AND SongDanTime>'" + startTime + "' AND OrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND OrderZhuoTaiDish.DishID NOT IN " + dishCondition + ") "
							   + " AND (OrderWaiMaiAddress.Source=11 or OrderWaiMaiAddress.Source=12 or OrderWaiMaiAddress.Source=13 or OrderWaiMaiAddress.Source=0) and HasAccept=1 "
							   + " AND OrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND OrderZhuoTaiDish.DishID NOT IN " + dishCondition
							   + " )tmpTable  " + (IsHuaDel() ? " where IsHuaCai=0 " : "") + "  ORDER BY ZTAddTime,ZhuoTaiName,DishAddTime,IsHuaCai,DishTypeID,DishName ";
					}
				}
				else if (zhuotaiMode == 2)
				{
					if ("1".Equals(showDishForFinishPay))
					{
						#region //单项
						strSql = " select * from ( "
							   + " SELECT OrderZhuoTaiDish.UID, OrderZhuoTaiDish.StoreID, OrderZhuoTaiDish.OrderID, OrderZhuoTaiDish.OrderZhuoTaiID, OrderZhuoTaiDish.DishID, "
							   + " OrderZhuoTaiDish.DishName,OrderZhuoTaiDish.DishTypeID,OrderZhuoTaiDish.UnitName,(OrderZhuoTaiDish.DishNum+OrderZhuoTaiDish.DishZengSongNum) as DishNum, OrderZhuoTaiDish.DishStatusID,  OrderZhuoTai.ZhuoTaiID, OrderZhuoTai.ZhuoTaiName, "
							   + " isnull(OrderZhuoTaiDish.SongDanTime,OrderInfo.Addtime) SongDanTime,OrderZhuoTaiDish.IsHuaCai,OrderZhuoTaiDish.HuaCaiNum,OrderZhuoTaiDish.ZuoFaNames,OrderZhuoTaiDish.KouWeiNames,OrderInfo.IsWaiMai,OrderZhuoTaiDish.DishTuiCaiNum,OrderZhuoTaiDish.DishZengSongNum,OrderZhuoTaiDish.DishStatusDesc,OrderZhuoTaiDish.IsPackage,'否' as IsTaoCanDetail,'' as OrderZhuoTaiDishID,OrderZhuoTaiDish.AddTime as DishAddTime "
							   + " FROM OrderZhuoTaiDish INNER JOIN OrderInfo ON OrderZhuoTaiDish.OrderID=OrderInfo.UID "
							   + " LEFT JOIN OrderZhuoTai ON OrderZhuoTaiDish.OrderZhuoTaiID=OrderZhuoTai.UID "
							   + " INNER JOIN OrderWaiMaiAddress ON OrderWaiMaiAddress.OrderId=OrderInfo.UID "
							   + " WHERE OrderZhuoTaiDish.DishStatusID=1 AND OrderZhuoTaiDish.IsHuaCai=0 AND (OrderZhuoTaiDish.DishNum+OrderZhuoTaiDish.DishZengSongNum)>0 AND OrderZhuoTaiDish.StoreID=" + Tools.CurrentUser.StoreID + " AND OrderZhuoTaiDish.SongDanTime>'" + startTime + "'  "
							   + " AND (OrderWaiMaiAddress.Source=11 or OrderWaiMaiAddress.Source=12 or OrderWaiMaiAddress.Source=13 or OrderWaiMaiAddress.Source=0) and HasAccept=1 "
							   + " AND OrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND OrderZhuoTaiDish.DishID NOT IN " + dishCondition
							   + " UNION "
							   + " SELECT HisOrderZhuoTaiDish.UID, HisOrderZhuoTaiDish.StoreID, HisOrderZhuoTaiDish.OrderID, HisOrderZhuoTaiDish.OrderZhuoTaiID, HisOrderZhuoTaiDish.DishID, "
							   + " HisOrderZhuoTaiDish.DishName,HisOrderZhuoTaiDish.DishTypeID,HisOrderZhuoTaiDish.UnitName,(HisOrderZhuoTaiDish.DishNum+HisOrderZhuoTaiDish.DishZengSongNum) as DishNum, HisOrderZhuoTaiDish.DishStatusID, HisOrderZhuoTai.ZhuoTaiID, HisOrderZhuoTai.ZhuoTaiName, "
							   + " isnull(HisOrderZhuoTaiDish.SongDanTime,HisOrderInfo.Addtime)  SongDanTime,HisOrderZhuoTaiDish.IsHuaCai,HisOrderZhuoTaiDish.HuaCaiNum,HisOrderZhuoTaiDish.ZuoFaNames,HisOrderZhuoTaiDish.KouWeiNames,HisOrderInfo.IsWaiMai,HisOrderZhuoTaiDish.DishTuiCaiNum,HisOrderZhuoTaiDish.DishZengSongNum,HisOrderZhuoTaiDish.DishStatusDesc,HisOrderZhuoTaiDish.IsPackage,'否' as IsTaoCanDetail,'' as OrderZhuoTaiDishID,HisOrderZhuoTaiDish.AddTime as DishAddTime "
							   + " FROM HisOrderZhuoTaiDish INNER JOIN HisOrderInfo ON HisOrderZhuoTaiDish.OrderID=HisOrderInfo.UID "
							   + " LEFT JOIN HisOrderZhuoTai ON HisOrderZhuoTaiDish.OrderZhuoTaiID=HisOrderZhuoTai.UID "
							   + " INNER JOIN HisOrderWaiMaiAddress ON HisOrderWaiMaiAddress.OrderId=HisOrderInfo.UID "
							   + " WHERE HisOrderZhuoTaiDish.DishStatusID=1 AND HisOrderZhuoTaiDish.IsHuaCai=0 AND (HisOrderZhuoTaiDish.DishNum+HisOrderZhuoTaiDish.DishZengSongNum)>0 AND HisOrderZhuoTaiDish.StoreID=" + Tools.CurrentUser.StoreID + " AND HisOrderZhuoTaiDish.SongDanTime>'" + startTime + "'  "
							   + " AND (HisOrderWaiMaiAddress.Source=11 or HisOrderWaiMaiAddress.Source=12 or HisOrderWaiMaiAddress.Source=13 or HisOrderWaiMaiAddress.Source=0) and HasAccept=1 "
							   + " AND HisOrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND HisOrderZhuoTaiDish.DishID NOT IN " + dishCondition
							   + " )tmpTable ORDER BY DishAddTime,ZhuoTaiName,IsHuaCai,DishTypeID,DishName ";
						#endregion
					}
					else
					{
						strSql = " select * from ( "
							   + " SELECT OrderZhuoTaiDish.UID, OrderZhuoTaiDish.StoreID, OrderZhuoTaiDish.OrderID, OrderZhuoTaiDish.OrderZhuoTaiID, OrderZhuoTaiDish.DishID, "
							   + " OrderZhuoTaiDish.DishName,OrderZhuoTaiDish.DishTypeID,OrderZhuoTaiDish.UnitName,(OrderZhuoTaiDish.DishNum+OrderZhuoTaiDish.DishZengSongNum) as DishNum, OrderZhuoTaiDish.DishStatusID,  OrderZhuoTai.ZhuoTaiID, OrderZhuoTai.ZhuoTaiName, "
							   + " isnull(OrderZhuoTaiDish.SongDanTime,OrderInfo.Addtime) SongDanTime,OrderZhuoTaiDish.IsHuaCai,OrderZhuoTaiDish.HuaCaiNum,OrderZhuoTaiDish.ZuoFaNames,OrderZhuoTaiDish.KouWeiNames,OrderInfo.IsWaiMai,OrderZhuoTaiDish.DishTuiCaiNum,OrderZhuoTaiDish.DishZengSongNum,OrderZhuoTaiDish.DishStatusDesc,OrderZhuoTaiDish.IsPackage,'否' as IsTaoCanDetail,'' as OrderZhuoTaiDishID,OrderZhuoTaiDish.AddTime as DishAddTime "
							   + " FROM OrderZhuoTaiDish INNER JOIN OrderInfo ON OrderZhuoTaiDish.OrderID=OrderInfo.UID "
							   + " LEFT JOIN OrderZhuoTai ON OrderZhuoTaiDish.OrderZhuoTaiID=OrderZhuoTai.UID "
							   + " INNER JOIN OrderWaiMaiAddress ON OrderWaiMaiAddress.OrderId=OrderInfo.UID "
							   + " WHERE OrderZhuoTaiDish.DishStatusID=1 AND OrderZhuoTaiDish.IsHuaCai=0 AND (OrderZhuoTaiDish.DishNum+OrderZhuoTaiDish.DishZengSongNum)>0 AND OrderZhuoTaiDish.StoreID=" + Tools.CurrentUser.StoreID + " AND OrderZhuoTaiDish.SongDanTime>'" + startTime + "'  "
							   + " AND (OrderWaiMaiAddress.Source=11 or OrderWaiMaiAddress.Source=12 or OrderWaiMaiAddress.Source=13 or OrderWaiMaiAddress.Source=0) and HasAccept=1 "
							   + " AND OrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND OrderZhuoTaiDish.DishID NOT IN " + dishCondition
							   + " )tmpTable ORDER BY DishAddTime,ZhuoTaiName,IsHuaCai,DishTypeID,DishName ";
					}
				}

				//所有外卖信息
				DataTable tableWaiMai = DBHelper.ExeSqlForDataTable(strSql);

				curTable = paramTable.Clone();
				foreach (DataRow dr in paramTable.Rows)
				{
					DataRow newRow = curTable.NewRow();
					curTable.Rows.Add(newRow);
					for (int i = 0; i < dr.ItemArray.Length; i++)
					{
						newRow[i] = dr[i];
					}
				}

				foreach (DataRow dr in tableWaiMai.Rows)
				{
					DataRow newRow = curTable.NewRow();
					curTable.Rows.Add(newRow);
					for (int i = 0; i < dr.ItemArray.Length; i++)
					{
						newRow[i] = dr[i];
					}
				}

				if (zhuotaiMode == 0 || zhuotaiMode == 1)  //台卡号
				{
					curTable.DefaultView.Sort = "ZTAddTime,ZhuoTaiName,DishAddTime,IsHuaCai,DishTypeID,DishName";
				}
				else
				{
					curTable.DefaultView.Sort = "DishAddTime,ZhuoTaiName,IsHuaCai,DishTypeID,DishName";
				}

				curTable = curTable.DefaultView.ToTable();
			}
			catch (Exception ex)
			{
				Log.WriteLog("QueryKCWaiMaiOrder strSql=" + strSql);
				Log.WriteLog("QueryKCWaiMaiOrder 错误信息:" + ex.ToString());
			}

			//去重
			DataView dv = new DataView(curTable);
			DataTable table = dv.ToTable(true);
			if (zhuotaiMode == 0 || zhuotaiMode == 1)  //台卡号
			{
				table.DefaultView.Sort = "ZTAddTime,ZhuoTaiName,DishAddTime,IsHuaCai,DishTypeID,DishName";
			}
			else
			{
				table.DefaultView.Sort = "DishAddTime,ZhuoTaiName,IsHuaCai,DishTypeID,DishName";
			}

			return table;
		}

		#endregion

		#region //单项抢单相关操作

		void QiangDan(DishControl ctl)
		{
			var orderhuadantemp = orderHuaDanList.Where(p => p.ZTDishUID.Equals(ctl.UID)).ToList();
			if (orderhuadantemp.Count <= 0)
			{
				decimal count = string.IsNullOrEmpty(ctl.Count) ? 0 : Convert.ToDecimal(ctl.Count.Split(' ')[0]);
				string strSql = " if not exists (select * from OrderHuaDan where ZTDishUID='" + ctl.UID + "') INSERT INTO OrderHuaDan(UID,GroupID,StoreID,ZTDishUID,ZTName,QiangDanTime,TotalNum,QiangDanUser,IsEnable,AddUser,AddTime ,UpdateUser,UpdateTime) " +
										   " VALUES('" + Guid.NewGuid().ToString("N") + "','" + Tools.CurrentUser.GroupID + "','" + Tools.CurrentUser.StoreID + "','" + ctl.UID + "','" + ctl.ZhuoTaiName + "','" + DateTime.Now + "','" + count + "', " +
										   " '" + Tools.CurrentUser.UID + "','" + '1' + "','" + Tools.CurrentUser.UID + "','" + DateTime.Now + "','" + Tools.CurrentUser.UID + "','" + DateTime.Now + "' ) ";

				string strConn = ConfigurationManager.AppSettings["dbconn"];

				using (SqlConnection conn = new SqlConnection(strConn))
				{
					SqlCommand cmd = conn.CreateCommand();
					cmd.CommandText = strSql;
					try
					{
						conn.Open();
						cmd.ExecuteNonQuery();
						conn.Close();

						//多台同时操作，一台成功，其他不成功！
						LoadAllOrderHuaDan();
						var listTmp = orderHuaDanList.Where(p => p.ZTDishUID.Equals(ctl.UID) && p.QiangDanUser.Equals(Tools.CurrentUser.UID)).ToList();
						if (listTmp.Count <= 0)
						{
							MessageBox.Show("该单项已经被抢单，不能重复抢单！");
						}
					}
					catch { }
				}
			}
			else
			{
				MessageBox.Show("该单项已经被抢单，不能重复抢单！");
			}
		}

		void CanCelQiangDan(string uid)
		{

			string strSql = "DELETE FROM OrderHuaDan WHERE ZTDishUID='" + uid + "'";

			string strConn = ConfigurationManager.AppSettings["dbconn"];

			using (SqlConnection conn = new SqlConnection(strConn))
			{
				SqlCommand cmd = conn.CreateCommand();
				cmd.CommandText = strSql;
				try
				{
					conn.Open();
					cmd.ExecuteNonQuery();
					conn.Close();
				}
				catch { }
			}
		}

		void LoadAllOrderHuaDan()
		{
			string strConn = ConfigurationManager.AppSettings["dbconn"];
			DataTable table = new DataTable();

			using (SqlConnection conn = new SqlConnection(strConn))
			{
				SqlCommand cmd = conn.CreateCommand();
				cmd.CommandText = " select * from OrderHuaDan where StoreID='" + Tools.CurrentUser.StoreID + "' ";
				SqlDataAdapter adapter = new SqlDataAdapter(cmd);
				try
				{
					conn.Open();
					adapter.Fill(table);

					orderHuaDanList.Clear();
					orderHuaDanList = DBOperator.TableToList<OrderHuaDan>(table);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
				finally
				{
					conn.Close();
				}
			}
		}

		int LoadAllHisOrderHuaDan(string uid)
		{
			string strConn = ConfigurationManager.AppSettings["dbconn"];
			DataTable table = new DataTable();

			using (SqlConnection conn = new SqlConnection(strConn))
			{
				SqlCommand cmd = conn.CreateCommand();
				cmd.CommandText = " select * from HisOrderHuaDan where StoreID='" + Tools.CurrentUser.StoreID + "' and  ZTDishUID='" + uid + "'";
				SqlDataAdapter adapter = new SqlDataAdapter(cmd);
				try
				{
					conn.Open();
					adapter.Fill(table);

					List<HisOrderHuaDan> hisOrderHuaDanList = new List<HisOrderHuaDan>();
					hisOrderHuaDanList = DBOperator.TableToList<HisOrderHuaDan>(table);
					return hisOrderHuaDanList.Count;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
					return 0;
				}
				finally
				{
					conn.Close();
				}
			}
		}

		DateTime InitCanBie()
		{
			string strConn = ConfigurationManager.AppSettings["dbconn"];
			DataTable table = new DataTable();

			using (SqlConnection conn = new SqlConnection(strConn))
			{
				SqlCommand cmd = conn.CreateCommand();
				cmd.CommandText = " select * from BaseCanBie where StoreID='" + Tools.CurrentUser.StoreID + "' and  IsEnable='1' order by SeqID asc";
				SqlDataAdapter adapter = new SqlDataAdapter(cmd);
				try
				{
					conn.Open();
					adapter.Fill(table);

					List<BaseCanBie> canbieList = new List<BaseCanBie>();
					canbieList = DBOperator.TableToList<BaseCanBie>(table);
					if (canbieList.Count <= 0)
						return DateTime.Now.AddDays(-1);

					DateTime dtTmp = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd" + " " + canbieList[0].StartTime.ToString("HH:mm:ss")));
					if (dtTmp.Ticks > DateTime.Now.Ticks)
						dtTmp = dtTmp.AddDays(-1);
					//return Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd" + " " + canbieList[0].StartTime.ToString("HH:mm:ss"))).AddSeconds(-1);
					return dtTmp;
				}
				catch (Exception ex)
				{
					MessageBox.Show("初始化餐别失败，失败原因:" + ex.Message);
					return DateTime.Now.AddDays(-1); ;
				}
				finally
				{
					conn.Close();
				}
			}
		}

		#endregion

		#region//设置按钮
		private void btnSetup_Click(object sender, EventArgs e)
		{
			new frmSetup().ShowDialog(this);
		}
		#endregion

		#region //按菜品时间排序
		public DataTable CloneTable(DataTable tableParam)
		{
			DataTable table = new DataTable();
			List<string> list = new List<string>();
			foreach (DataRow row in tableParam.Rows)
			{
				string dishname = row["DishName"] as string;
				if (!string.IsNullOrEmpty(dishname) && !list.Contains(dishname))
				{
					list.Add(dishname);
				}
			}

			table = tableParam.Clone();

			for (int i = 0; i < list.Count; i++)
			{
				foreach (DataRow row in tableParam.Rows)
				{
					if (list[i].Equals(row[5]))
					{
						DataRow newRow = table.NewRow();
						table.Rows.Add(newRow);
						for (int j = 0; j < row.ItemArray.Length; j++)
						{
							newRow[j] = row[j];
						}
					}
				}
			}

			return table;
		}
		#endregion

		#region //【单项】模式
		private void ShowDishs(DataTable table)
		{
			try
			{
				this.SuspendLayout();
				tableLayoutPanel1.SuspendLayout();

				for (int i = 0; i < DishControls.Length; i++)
				{
					DishControls[i].Reset();
				}

				int startIndex = CurrentPageNo * tableLayoutPanel1.RowCount * tableLayoutPanel1.ColumnCount;
				if (CurrentPageNo > 0)
					btnUp.Enabled = true;
				else
					btnUp.Enabled = false;

				int endIndex = startIndex + (tableLayoutPanel1.RowCount * tableLayoutPanel1.ColumnCount);
				if (endIndex > table.Rows.Count)
					endIndex = table.Rows.Count;

				if (endIndex < table.Rows.Count)
					btnDown.Enabled = true;
				else
					btnDown.Enabled = false;

				DateTime now = DateTime.Now;
				int j = 0;
				for (int i = startIndex; i < endIndex; i++)
				{
					DataRow row = table.Rows[i];

					TimeSpan delta = now - (DateTime)row["SongDanTime"];
					double strDelta = delta.TotalMinutes;
					string strTime = "(" + strDelta.ToString("f0") + "分钟)";
					string num = String.Format("{0:F}", row["DishNum"]);
					if (num.EndsWith(".00"))
						num = num.Substring(0, num.Length - 3);

					DishControls[j].DishName = row["DishName"].ToString();
					DishControls[j].Zuofa = (row["ZuoFaNames"] as string) + " " + (row["KouWeiNames"] as string);
					if (!string.IsNullOrEmpty(DishControls[j].Zuofa.Trim()))
					{
						DishControls[j].ChangeFontColor(DishControls[j].Zuofa.Trim(), "LightSkyBlue");
					}

					if (strDelta > alertTime)
					{
						DishControls[j].TimeOutChangeImg(true);
					}
					else {
						DishControls[j].TimeOutChangeImg(false);
					}

					if ((bool)row["IsWaiMai"])
					{
						if (DishControls[j].DishName.IndexOf("外卖") == -1 && DishControls[j].Zuofa.IndexOf("外卖") == -1)
						{
							DishControls[j].DishName = DishControls[j].DishName + "(外卖)";
						}
					}

					DishControls[j].Count = num + " " + row["UnitName"].ToString();
					DishControls[j].Time = strTime;
					if (!string.IsNullOrEmpty(row["ZhuoTaiName"] as string))
						DishControls[j].ZhuoTaiName = row["ZhuoTaiName"] as string;
					else
						DishControls[j].ZhuoTaiName = row["TaiKaHao"] as string;
					DishControls[j].UID = row["UID"] as string;
					DishControls[j].DishStatusDesc = row["DishStatusDesc"] as string;

					if (DishControls[j].ZhuoTaiName.IndexOf("外卖") > -1)
					{
						DishControls[j].ChangeIsWaiMaiStyle(DishControls[j].ZhuoTaiName.Trim());
					}

					if (((bool)row["IsWaiMai"]) || DishControls[j].DishName.IndexOf("外卖") > -1 || DishControls[j].Zuofa.IndexOf("外卖") > -1
						|| DishControls[j].DishName.IndexOf("打包") > -1 || DishControls[j].Zuofa.IndexOf("打包") > -1
						|| ((!string.IsNullOrEmpty(row["ZhuoTaiName"] as string)) && (row["ZhuoTaiName"] as string).IndexOf("外卖") > -1)
						|| ((!string.IsNullOrEmpty(row["ZhuoTaiName"] as string)) && (row["ZhuoTaiName"] as string).IndexOf("打包") > -1))
					{
						DishControls[j].BackColor = Color.AliceBlue; // SystemColors.Desktop;

						DishControls[j].ChangeFontColor(DishControls[j].Zuofa.Trim(), "AliceBlue");

					}
					else
					{
						DishControls[j].BackColor = Color.LightSkyBlue;
					}

					//单项抢单模式
					if (strZhuotaiMode.Equals("2") && getdishmodel.Equals("1"))
					{
						var tmp = orderHuaDanList.Where(p => p.ZTDishUID.Equals(row["UID"].ToString())).ToList();
						if (tmp.Count > 0)
						{
							var userTmp = tmp.Where(p => p.QiangDanUser.Equals(Tools.CurrentUser.UID)).ToList();
							if (userTmp.Count <= 0)
							{
								DishControls[j].BackColor = Color.Gray;
								DishControls[j].ChangeFontColor(DishControls[j].Zuofa.Trim(), "Gray");
								DishControls[j].ChangeZhuoTaiFontColor(DishControls[j].ZhuoTaiName.Trim(), "Gray");

							}
							else
							{
								DishControls[j].BackColor = Color.PaleVioletRed;
								DishControls[j].ChangeFontColor(DishControls[j].Zuofa.Trim(), "PaleVioletRed");
								DishControls[j].ChangeZhuoTaiFontColor(DishControls[j].ZhuoTaiName.Trim(), "PaleVioletRed");
							}
						}
						else
						{
							DishControls[j].BackColor = Color.LightSkyBlue;
							DishControls[j].ChangeFontColor(DishControls[j].Zuofa.Trim(), "LightSkyBlue");
							DishControls[j].ChangeZhuoTaiFontColor(DishControls[j].ZhuoTaiName.Trim(), "LightSkyBlue");
						}
					}

					if (orderGuQingTable.Rows.Count > 0)
					{
						var sourceGQ = orderGuQingTable.Select("DishID='" + row["DishID"].ToString() + "'");
						if (sourceGQ.Count() > 0)
						{
							decimal dishNumber = sourceGQ[0]["DishNumber"] == null ? 0 : Convert.ToDecimal(sourceGQ[0]["DishNumber"].ToString());
							if (dishNumber > 0)
							{
								DishControls[j].GuQingNum = "余" + DanJu.decimalFormatter(dishNumber);
							}
							else
							{
								DishControls[j].GuQingNum = "沽";
							}
						}
						else
						{
							DishControls[j].GuQingNum = "";
						}
					}
					else
					{
						DishControls[j].GuQingNum = "";
					}

					j++;
				}

				tableLayoutPanel1.ResumeLayout();
				this.ResumeLayout();
			}
			catch (Exception ex)
			{
				Log.WriteLog("ShowDishs 错误信息:" + ex.ToString());
			}
		}

		#endregion

		#region //【桌台|台卡】模式
		private void ShowZhuoTaiDish(DataTable table)
		{
			List<DataTable> dataTables = new List<DataTable>();
			string currZhuoTaiID = null;
			DataTable curTable = null;
			foreach (DataRow row in table.Rows)
			{
				string newZhuoTaiID = row["ZhuoTaiName"] as string; //row["ZhuoTaiID"] as string;
				if (!string.Equals(currZhuoTaiID, newZhuoTaiID))
				{
					currZhuoTaiID = newZhuoTaiID;
					curTable = table.Clone();
					dataTables.Add(curTable);
				}

				DataRow newRow = curTable.NewRow();
				curTable.Rows.Add(newRow);
				for (int i = 0; i < row.ItemArray.Length; i++)
				{
					newRow[i] = row[i];
				}
			}

			//MessageBox.Show(dataTables.Count.ToString());

			this.SuspendLayout();
			tableLayoutPanel1.SuspendLayout();

			for (int i = 0; i < 8; i++)
			{
				listBoxes[i].Items.Clear();
				listLabels[i].Text = "";
			}

			int startIndex = CurrentPageNo * 8;
			if (CurrentPageNo > 0)
				btnUp.Enabled = true;
			else
				btnUp.Enabled = false;

			int endIndex = startIndex + 8;
			if (endIndex > dataTables.Count)
				endIndex = dataTables.Count;

			if (endIndex < dataTables.Count)
				btnDown.Enabled = true;
			else
				btnDown.Enabled = false;

			//MessageBox.Show(startIndex + ":" + endIndex);

			for (int i = startIndex; i < endIndex; i++)
			{
				ListBox listBox = listBoxes[i % 8];
				DataTable nowTable = dataTables[i];
				foreach (DataRow row in nowTable.Rows)
				{
					//Label lbl = new Label();
					//lbl.Text = row["DishName"] as string;
					string dishName = row["DishName"] as string;
					string DishStatusDesc = row["DishStatusDesc"] as string;

					if (string.Equals((string)row["IsTaoCanDetail"], "否"))
					{
						if ((bool)row["IsPackage"] == true && string.Equals(DishStatusDesc, "等叫"))
						{
							dishName = "【等叫】【套】" + dishName;
						}
						else if ((bool)row["IsPackage"] == false && string.Equals(DishStatusDesc, "等叫"))
						{
							dishName = "【等叫】" + dishName;
						}
					}
					else
					{
						dishName = "   " + dishName;
					}


					ListBoxItem item = new ListBoxItem()
					{
						UID = row["UID"] as string,//说明：1、IsTaoCanDetail="是"=>OrderPackageDishDetail的主键UID 2、IsTaoCanDetail="否"=>OrderZhuoTaiDish的主键UID
						DishName = dishName,
						DishNum = (decimal)row["DishNum"],
						IsHuaCai = (bool)row["IsHuaCai"],
						SongDanTime = (DateTime)row["SongDanTime"],
						DishTuiCaiNum = (decimal)row["DishTuiCaiNum"],
						DishZengSongNum = (decimal)row["DishZengSongNum"],
						IsPackage = (bool)row["IsPackage"],
						IsTaoCanDetail = row["IsTaoCanDetail"] as string, //区分是套餐内菜品还是套餐外菜品
						OrderZhuoTaiDishID = row["OrderZhuoTaiDishID"] as string,
						DishID = row["DishID"] as string,
						ZuoFaNames = row["ZuoFaNames"] as string,
						KouWeiNames = row["KouWeiNames"] as string
					};

					listBox.Items.Add(item);

					if (string.IsNullOrEmpty(listLabels[i % 8].Text))
						listLabels[i % 8].Text = row["ZhuoTaiName"] as string;

				}
			}

			tableLayoutPanel1.ResumeLayout();
			this.ResumeLayout();
		}

		#endregion

		#region//定时器-刷新
		private void timer1_Tick(object sender, EventArgs e)
		{
			TimeSpan delta = DateTime.Now - lastClickTime;
			if (delta.TotalMilliseconds >= 15000)
			{
				LoadAllOrderHuaDan();
				LoadAllZhuoTaiDish();
				txtHuaCaiNum.Focus();
			}
		}

		#endregion

		#region//关闭窗体
		private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			timer1.Stop();
		}
		#endregion

		#region//刷新按钮
		private void btnRefresh_Click(object sender, EventArgs e)
		{

			LoadAllOrderHuaDan();
			LoadAllZhuoTaiDish();
		}
		#endregion

		#region//划单按钮
		private void btnHuaDan_Click(object sender, EventArgs e)
		{
			List<string> uids = new List<string>();
			ListBoxItem onSelectedItem = null;  //划过的菜再划提示下，如果只有一个菜，那就是这个菜啦。
			foreach (ListBox listBox in listBoxes)
			{
				foreach (object obj in listBox.SelectedItems)
				{
					uids.Add((obj as ListBoxItem).UID);
					onSelectedItem = obj as ListBoxItem;
				}
			}

			if (uids.Count == 1 && !object.Equals(onSelectedItem, null))
			{
				if (onSelectedItem.IsHuaCai)
				{
					DialogResult result = MessageBox.Show(onSelectedItem.DishName + " 已经划过了，重新划吗？", "确认", MessageBoxButtons.YesNo);
					if (result == DialogResult.No)
						return;
				}
			}

			HuaDan(uids);
		}

		#endregion

		#region//划单方法
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

					if (strZhuotaiMode.Equals("2") && getdishmodel.Equals("1"))
					{
						builder.Append("UPDATE OrderHuaDan set IsEnable=1,HuaDanTime='" + DateTime.Now + "',UpdateUser='" + Tools.CurrentUser.UID + "',UpdateTime='" + DateTime.Now + "' where ZTDishUID='" + uid + "'").Append("\r\n")
							.Append(" INSERT INTO HisOrderHuaDan select * From OrderHuaDan where ZTDishUID='" + uid + "'").Append("\r\n")
							.Append("DELETE FROM OrderHuaDan WHERE ZTDishUID='" + uid + "'").Append("\r\n");
					}
				}
				string strSql = builder.ToString();

				string strConn = ConfigurationManager.AppSettings["dbconn"];

				using (SqlConnection conn = new SqlConnection(strConn))
				{
					SqlCommand cmd = conn.CreateCommand();
					cmd.CommandText = strSql;
					try
					{
						conn.Open();
						cmd.ExecuteNonQuery();
						conn.Close();
					}
					catch { }
				}

				LoadAllZhuoTaiDish();
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

		void listBoxes_Click(object sender, EventArgs e)
		{
			lastClickTime = DateTime.Now;
			handMode = true;
		}

		/// <summary>
		/// 返回指定坐标处的项的从零开始的索引。
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void listBox1_MouseDown(object sender, MouseEventArgs e)
		{
			ListBox lb = ((ListBox)sender);
			Point pt = new Point(e.X, e.Y);
			int index = lb.IndexFromPoint(pt);
			if (index >= 0)
			{
				ListBox listBox = sender as ListBox;
				if (listBox.Items.Count == 0)
					return;

				ListBoxItem list = listBox.Items[index] as ListBoxItem;
				string isTaoCanDetail = list.IsTaoCanDetail; //区分是否套餐明细 是：是 | 否：否
				bool isPackage = list.IsPackage;             //是否套餐
				string OrderZhuoTaiDishID = list.IsPackage ? list.UID : list.OrderZhuoTaiDishID;//OrderZhuoTaiDish主键UID
				bool selected = listBox.GetSelected(index);
				if (string.Equals(isTaoCanDetail, "否") && isPackage) //表示套餐总名称
				{
					#region //点击套餐全部选中或取消
					string UID = string.Empty;
					for (int i = 0; i < listBox.Items.Count; i++)
					{
						ListBoxItem listTmp = listBox.Items[i] as ListBoxItem;
						if (string.Equals(listTmp.IsTaoCanDetail, "否") && listTmp.IsPackage && i == index) //套餐的名称 非明细
						{
							UID = listTmp.UID;
						}

						if (string.Equals(listTmp.IsTaoCanDetail, "是") && !listTmp.IsPackage && string.Equals(UID, listTmp.OrderZhuoTaiDishID) && !listTmp.IsHuaCai && listTmp.DishNum > 0)
						{
							if (selected)
								listBox.SetSelected(i, true);
							else
								listBox.SetSelected(i, false);
						}
					}
					#endregion
				}
				else if (string.Equals(isTaoCanDetail, "是") && !isPackage) //表示套餐内菜品明细
				{
					#region//点击套餐内明细全部选中或取消套餐名称选中状态
					int countTotal = 0;//获取套餐内菜品总数--未划菜
					int count = 0;     //获取套餐内菜品以选中总数--未划菜
					int indexDish = 0;//套餐菜品所在索引
					for (int i = 0; i < listBox.Items.Count; i++)
					{
						ListBoxItem listTmp = listBox.Items[i] as ListBoxItem;
						if (string.Equals(listTmp.IsTaoCanDetail, "否") && listTmp.IsPackage && string.Equals(listTmp.UID, OrderZhuoTaiDishID))
							indexDish = i;
						if (string.Equals(isTaoCanDetail, "是") && !isPackage && listTmp.DishNum > 0 && !listTmp.IsHuaCai && string.Equals(listTmp.OrderZhuoTaiDishID, OrderZhuoTaiDishID))
						{
							bool selectedTmp = listBox.GetSelected(i);
							if (selectedTmp)
								count++;
							countTotal++;
						}
					}

					if (!selected)
						listBox.SetSelected(indexDish, false);
					else
					{
						if (count == countTotal && countTotal != 0)
							listBox.SetSelected(indexDish, true);
						else
							listBox.SetSelected(indexDish, false);
					}
					#endregion
				}
			}

			#region //沽清按钮
			List<string> resultList = CommonGuQing.ChangeBtnGuQingName(listBoxes);
			if (resultList.Count <= 0)
			{
				btnGuQing.Enabled = false;
				btnGuQing.Text = "沽清";
			}
			else
			{
				btnGuQing.Enabled = true;
				string guQingModel = ConfigurationManager.AppSettings["guQingModel"];
				if (!string.IsNullOrEmpty(guQingModel) && "1".Equals(guQingModel))
				{
					btnGuQing.Text = resultList[0];
				}
				else
				{
					btnGuQing.Text = "沽清";
				}
			}
			#endregion
		}

		void listLabels_Click(object sender, EventArgs e)
		{
			lastClickTime = DateTime.Now;
			handMode = true;

			int index = -1;
			for (int i = 0; i < listLabels.Length; i++)
			{
				if (object.Equals(listLabels[i], sender))
				{
					index = i;
					break;
				}
			}
			if (index >= 0)
			{
				ListBox listbox = listBoxes[index];
				if (listbox.Items.Count == 0)
					return;
				bool selected = listbox.GetSelected(0) && listbox.GetSelected(listbox.Items.Count - 1);

				for (int i = 0; i < listbox.Items.Count; i++)
				{
					if (selected)
						listbox.SetSelected(i, false);
					else
						listbox.SetSelected(i, true);
				}
			}


			List<string> resultList = CommonGuQing.ChangeBtnGuQingName(listBoxes);
			if (resultList.Count <= 0)
			{
				btnGuQing.Enabled = false;
				btnGuQing.Text = "沽清";
			}
			else
			{
				btnGuQing.Enabled = true;
				string guQingModel = ConfigurationManager.AppSettings["guQingModel"];
				if (!string.IsNullOrEmpty(guQingModel) && "1".Equals(guQingModel))
				{
					btnGuQing.Text = resultList[0];
				}
				else
				{
					btnGuQing.Text = "沽清";
				}
			}
		}


		void listBoxes_DrawItem(object sender, DrawItemEventArgs e)
		{
			if (e.Index >= 0)
			{
				ListBoxItem item = (sender as ListBox).Items[e.Index] as ListBoxItem;

				e.DrawBackground();
				Brush mybsh = Brushes.LightYellow;
				e.DrawFocusRectangle();
				if (item.IsHuaCai || (item.DishNum + item.DishZengSongNum) == 0)
				{
					mybsh = Brushes.Red;
				}

				try
				{
					if (orderGuQingTable.Rows.Count > 0)
					{
						DataRow[] dr = orderGuQingTable.Select("DishID='" + item.DishID + "'");
						Brush br;
						if (dr.Count() > 0)
						{
							br = Brushes.Green;
							//e.DrawBackground();
							//if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
							//    e.DrawFocusRectangle();
							e.Graphics.FillRectangle(br, e.Bounds);
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString());
				}

				//文本 
				e.Graphics.DrawString(item.ToString(), e.Font, mybsh, e.Bounds, StringFormat.GenericDefault);
			}
		}

		#endregion

		#region//【上一页】【下一页】
		private void btnDown_Click(object sender, EventArgs e)
		{
			CurrentPageNo++;
			LoadAllZhuoTaiDish();
		}

		private void btnUp_Click(object sender, EventArgs e)
		{
			CurrentPageNo--;
			LoadAllZhuoTaiDish();
		}
		#endregion

		#region//文本框相关事件
		private void txtHuaCaiNum_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{

			}
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
					//MessageBox.Show(txtHuaCaiNum.Text);
					//
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

					string strConn = ConfigurationManager.AppSettings["dbconn"];

					using (SqlConnection conn = new SqlConnection(strConn))
					{
						SqlCommand cmd = conn.CreateCommand();
						cmd.CommandText = strSql;
						try
						{
							conn.Open();
							cmd.ExecuteNonQuery();
							conn.Close();
						}
						catch { }
					}
					txtHuaCaiNum.Clear();
					LoadAllZhuoTaiDish();
				}
			}
			catch (Exception ex)
			{
				Log.WriteLog("txtHuaCaiNum_KeyDown 错误信息:" + ex.ToString());
			}
		}

		private void txtHuaCaiNum_Click(object sender, EventArgs e)
		{
			handMode = false;
		}

		#endregion

		#region//其他
		private void grpColor_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.Clear(this.BackColor);
		}

		public string CreateDB()
		{
			string strConn = ConfigurationManager.AppSettings["dbconn"];

			using (SqlConnection conn = new SqlConnection(strConn))
			{
				SqlCommand cmd = conn.CreateCommand();
				string sql = " IF NOT EXISTS (select * from dbo.sysobjects where xtype='U' and Name = 'OrderHuaDan') " +
							 " BEGIN " +
							 " create table OrderHuaDan( " +
							 " UID          varchar(50) primary key , " +
							 " GroupID      int, " +
							 " StoreID      int, " +
							 " ZTDishUID    varchar(50), " +
							 " ZTName       varchar(50), " +
							 " XiaDanTime   datetime, " +
							 " QiangDanTime datetime, " +
							 " HuaDanTime   datetime, " +
							 " TotalNum     decimal(18,2), " +
							 " HuaDanNum    decimal(18,2), " +
							 " QiangDanUser varchar(50), " +
							 " IsEnable     bit, " +
							 " AddUser      varchar(50), " +
							 " AddTime      datetime, " +
							 " UpdateUser   varchar(50), " +
							 " UpdateTime   datetime, " +
							 " bak1         varchar(50), " +
							 " bak2         varchar(50), " +
							 " bak3         varchar(50) " +
							 " ); " +
							 " create table HisOrderHuaDan( " +
							 " UID          varchar(50) primary key , " +
							 " GroupID      int, " +
							 " StoreID      int, " +
							 " ZTDishUID    varchar(50), " +
							 " ZTName       varchar(50), " +
							 " XiaDanTime   datetime, " +
							 " QiangDanTime datetime, " +
							 " HuaDanTime   datetime, " +
							 " TotalNum     decimal(18,2), " +
							 " HuaDanNum    decimal(18,2), " +
							 " QiangDanUser varchar(50), " +
							 " IsEnable     bit, " +
							 " AddUser      varchar(50), " +
							 " AddTime      datetime, " +
							 " UpdateUser   varchar(50), " +
							 " UpdateTime   datetime, " +
							 " bak1         varchar(50), " +
							 " bak2         varchar(50), " +
							 " bak3         varchar(50)  " +
							 " ); " +
							 " END ";
				cmd.CommandText = sql;
				try
				{
					conn.Open();
					cmd.ExecuteNonQuery();
					conn.Close();
				}
				catch (Exception ex)
				{
					return "fail";
				}
			}

			return "success";
		}

		public void ajudgeLocalTimeBaseServer()
		{
			string strConn = ConfigurationManager.AppSettings["dbconn"];
			DataTable table = new DataTable();
			using (SqlConnection conn = new SqlConnection(strConn))
			{
				SqlCommand cmd = conn.CreateCommand();
				cmd.CommandText = "select GETDATE()";
				SqlDataAdapter adapter = new SqlDataAdapter(cmd);
				try
				{
					conn.Open();
					adapter.Fill(table);

					if (table.Rows.Count > 0)
					{
						SystemTimeManage.setSystemTime(Convert.ToDateTime(table.Rows[0][0]));
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
				finally
				{
					conn.Close();
				}
			}
		}

		public void StartMonitor()
		{
			ajudgeLocalTimeBaseServer();

			var result = CreateDB();
			if (result == "fail")
			{
				MessageBox.Show("创建表【OrderHuaDan】和【HisOrderHuaDan】失败！");
				return;
			}

			strZhuotaiMode = ConfigurationManager.AppSettings["zhuotaimode"];
			getdishmodel = ConfigurationManager.AppSettings["getdishmodel"];
			if (strZhuotaiMode == null || getdishmodel == null)
			{
				strZhuotaiMode = "0";
				getdishmodel = "0";
				grpColor.Visible = false;
			}
			else
			{
				if (strZhuotaiMode.Equals("2") && getdishmodel.Equals("1"))
					grpColor.Visible = true;
				else
					grpColor.Visible = false;
			}



			LoadAllOrderHuaDan();
			LoadAllZhuoTaiDish();
			timer1.Start();
		}

		private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
		{
			Pen pp = new Pen(Color.Gray);
			e.Graphics.DrawRectangle(pp, e.CellBounds.X, e.CellBounds.Y, e.CellBounds.X + e.CellBounds.Width - 1, e.CellBounds.Y + e.CellBounds.Height - 1);
		}

		#endregion

		private void btnQuery_Click(object sender, EventArgs e)
		{
			frmQuery frm = new frmQuery("frmMain");
			frm.Owner = this;
			frm.ShowDialog();
		}

		private void btnGuQing_Click(object sender, EventArgs e)
		{
			List<string> list = CommonGuQing.ChangeBtnGuQingName(listBoxes);
			if (list.Count > 0)
			{
				string guQingModel = ConfigurationManager.AppSettings["guQingModel"]; //是否快速沽清
				if (!object.Equals(guQingModel, null) && "1".Equals(guQingModel))
				{
					//快速沽清模式
					string quickGuQingTip = ConfigurationManager.AppSettings["quickGuQingTip"]; //快速沽清是否提醒
					if (!object.Equals(quickGuQingTip, null) && "1".Equals(quickGuQingTip))
					{
						if (DialogResult.Yes == MessageBox.Show("菜品【" + list[2] + "】确定要" + btnGuQing.Text.Trim() + "吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
						{
							if (CommonGuQing.GuQingOpreate(btnGuQing.Text.Trim(), list[2], list[1], "", 0))
							{
								RefreshGuQing();
							}
							else
							{
								MessageBox.Show("沽清失败！");
							}
						}
					}
					else
					{
						//直接操作
						if (CommonGuQing.GuQingOpreate(btnGuQing.Text.Trim(), list[2], list[1], "", 0))
						{
							RefreshGuQing();
						}
						else
						{
							MessageBox.Show("沽清失败！");
						}
					}
				}
				else if (!object.Equals(guQingModel, null) && "2".Equals(guQingModel))
				{
					//普通沽清模式
					frmGuQing frm = new frmGuQing(btnGuQing.Text.Trim(), list[2], list[1], false);
					if (frm.ShowDialog() == DialogResult.OK)
					{
						RefreshGuQing();
					}
				}

			}
		}

		/// <summary>
		/// 是否启用沽清
		/// </summary>
		private void IsShowGuQing()
		{
			string guQingModel = ConfigurationManager.AppSettings["guQingModel"]; //是否快速沽清
			if (!object.Equals(guQingModel, null) && ("1".Equals(guQingModel) || "2".Equals(guQingModel)))
			{
				btnGuQing.Visible = true;
				lblZCTip.Visible = true;
				btnGuQingList.Visible = false;

				int zhuotaiMode = 0;
				strZhuotaiMode = ConfigurationManager.AppSettings["zhuotaimode"];
				if (!string.IsNullOrEmpty(strZhuotaiMode))
					zhuotaiMode = int.Parse(strZhuotaiMode);
				if (zhuotaiMode == 2)
				{
					btnGuQing.Visible = false;
					lblZCTip.Visible = false;
					btnGuQingList.Visible = true;
				}
			}
			else
			{
				btnGuQing.Visible = false;
				lblZCTip.Visible = false;
				btnGuQingList.Visible = false;
			}

		}

		private void RefreshGuQing()
		{
			if (btnGuQing.Text.Trim().Equals("取消沽清"))
				btnGuQing.Text = "沽清";
			else if (btnGuQing.Text.Trim().Equals("沽清"))
				btnGuQing.Text = "取消沽清";
			LoadAllZhuoTaiDish();
			CommonGuQing.uploadGuQingData();
		}

		/// <summary>
		/// 刷新沽清菜品数据源
		/// </summary>
		private void GetOrderGuQing()
		{
			string guQingModel = ConfigurationManager.AppSettings["guQingModel"];
			if (!string.IsNullOrEmpty(guQingModel) && !"0".Equals(guQingModel))
			{
				orderGuQingTable = CommonGuQing.GetOrderGuQingAllData();
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

		private void lblZCTip_Click(object sender, EventArgs e)
		{
			frmGuQingList frm = new frmGuQingList();
			if (frm.ShowDialog() == DialogResult.OK)
			{
				LoadAllOrderHuaDan();
				LoadAllZhuoTaiDish();
			}
		}

		private void btnGuQingList_Click(object sender, EventArgs e)
		{
			frmGuQingList frm = new frmGuQingList();
			if (frm.ShowDialog() == DialogResult.OK)
			{
				LoadAllOrderHuaDan();
				LoadAllZhuoTaiDish();
			}
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
				Log.WriteLog("frmMain setOemInfo():" + ex.ToString());
			}
		}

		private bool IsHuaDel()
		{
			string huadelfordesk = ConfigurationManager.AppSettings["huadelfordesk"];
			if (string.IsNullOrEmpty(huadelfordesk) || "0".Equals(huadelfordesk))
				return false;

			return true;
		}
	}



	class ListBoxItem
	{
		public string UID { get; set; } //说明：1、IsTaoCanDetail="是"=>OrderPackageDishDetail的主键UID 2、IsTaoCanDetail="否"=>OrderZhuoTaiDish的主键UID
		public string DishName { get; set; }
		public decimal DishNum { get; set; }
		public bool IsHuaCai { get; set; }
		public DateTime SongDanTime { get; set; }
		public decimal DishTuiCaiNum { get; set; }
		public decimal DishZengSongNum { get; set; }
		public string IsTaoCanDetail { get; set; }
		public bool IsPackage { get; set; }//说明：1、IsTaoCanDetail="是"=>OrderPackageDishDetail表的数据 2、IsTaoCanDetail="否"=>OrderZhuoTaiDish的数据&&（IsPackage==true=>OrderZhuoTaiDish表的数据【套餐名称】，否则：非套餐菜品名称）
		public string OrderZhuoTaiDishID { get; set; }
		public string DishID { get; set; }
		public string ZuoFaNames { get; set; }
		public string KouWeiNames { get; set; }
		public override string ToString()
		{
			TimeSpan delta = DateTime.Now - SongDanTime;
			double strDelta = delta.TotalMinutes;

			string tip = string.Empty;
			if (DishTuiCaiNum > 0 && DishZengSongNum <= 0 && (DishNum - DishZengSongNum) <= 0)
				tip = "退";
			else if (DishTuiCaiNum <= 0 && DishZengSongNum > 0 && (DishNum - DishZengSongNum) <= 0)
				tip = "送";
			else if (DishTuiCaiNum > 0 && DishZengSongNum > 0 && (DishNum - DishZengSongNum) <= 0)
				tip = "退&送";

			string kwzf = "";
			if (!string.IsNullOrEmpty(ZuoFaNames) || !string.IsNullOrEmpty(KouWeiNames))
			{
				kwzf = ZuoFaNames;
				if (string.IsNullOrEmpty(kwzf) && !string.IsNullOrEmpty(KouWeiNames))
					kwzf = KouWeiNames;
				else if (!string.IsNullOrEmpty(kwzf) && !string.IsNullOrEmpty(KouWeiNames))
					kwzf = kwzf + "," + KouWeiNames;

				if (!string.IsNullOrEmpty(kwzf))
					kwzf = "(" + kwzf + ")";
			}

			if (strDelta > frmMain.alertTime && !IsHuaCai && DishNum > 0)
				return "*" + DishName + kwzf + "(" + (string.IsNullOrEmpty(tip) ? DishNum.ToString("0.##") : tip) + ") " + "(" + strDelta.ToString("f0") + "分钟)";
			else
				return DishName + kwzf + "(" + (string.IsNullOrEmpty(tip) ? DishNum.ToString("0.##") : tip) + ") " + "(" + strDelta.ToString("f0") + "分钟)";

		}
	}

	class OrderHuaDan
	{
		public string UID { get; set; }
		public int GroupID { get; set; }
		public int StoreID { get; set; }
		public string ZTDishUID { get; set; }
		public string ZTName { get; set; }
		public DateTime XiaDanTime { get; set; }
		public DateTime QiangDanTime { get; set; }
		public DateTime HuaDanTime { get; set; }
		public decimal TotalNum { get; set; }
		public decimal HuaDanNum { get; set; }
		public string QiangDanUser { get; set; }
		public Boolean IsEnable { get; set; }
		public string AddUser { get; set; }
		public DateTime AddTime { get; set; }
		public string UpdateUser { get; set; }
		public DateTime UpdateTime { get; set; }
		public string bak1 { get; set; }
		public string bak2 { get; set; }
		public string bak3 { get; set; }
	}

	class HisOrderHuaDan : OrderHuaDan
	{
	}

	class BaseCanBie
	{
		public string UID { get; set; }
		public int SeqID { get; set; }
		public int StoreID { get; set; }
		public string CBName { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public bool IsEnable { get; set; }
	}
}
