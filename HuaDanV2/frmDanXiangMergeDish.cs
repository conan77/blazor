using HuaDan.Model;
using HuaDan.TipForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuaDan
{
	public partial class frmDanXiangMergeDish : Form
	{
		public static frmDanXiangMergeDish Instance { get; set; }
		int CurrentPageNo = 0;
		int CurrentPageNoDetail = 0;
		MergeDishControl[] mergeDishControls;
		MergeDishDetailControl[] mergeDishDetailControl;
		string strZhuotaiMode = string.Empty;
		DateTime startTime = DateTime.Now;//餐别开始时间
		public static double alertTime = 30;
		int qiantaiMode = 0;
		DataTable tableAllData = new DataTable();
		int ctlHeight = 0;
		MergeDishDetailModel model = new MergeDishDetailModel();
		bool handMode = false;
		GuQingModelClass guQingModelClass = new GuQingModelClass();
		DataTable orderGuQingTable = new DataTable();
		int btnDishTypeWidth = 100;
		ComboBox combox = new ComboBox();//存放菜品类别
		int cmbIndex = 0;////存放菜品类别下拉框索引
		List<Button> btnDishTypeList = new List<Button>();//存放菜品类别的按钮UID
		string CurrDishTypeUID = string.Empty;//当前菜品选择的类别UID
		List<string> uidsList = new List<string>();//记录选中的划单记录
		string CurrDishName = string.Empty;//当前选中的菜品名称

		public frmDanXiangMergeDish()
		{
			InitializeComponent();

			this.WindowState = FormWindowState.Maximized;
			Instance = this;
			this.Top = 0;
			this.Left = 0;
			this.Width = Screen.PrimaryScreen.Bounds.Width;
			this.Height = Screen.PrimaryScreen.Bounds.Height;

			int dsd = this.tableLayoutPanel1.Top;

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

				//int ctlWidth = (this.ClientSize.Width - 200) / wCount;
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

				//for (int i = 0; i < tableLayoutPanel2.ColumnCount; i++)
				//{
				//    tableLayoutPanel2.ColumnStyles[i].SizeType = SizeType.AutoSize;
				//}
				//for (int i = 0; i < tableLayoutPanel2.RowCount; i++)
				//{
				//    tableLayoutPanel2.RowStyles[i].SizeType = SizeType.AutoSize;
				//}
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
				panBtnHuaDan.Height = height / 2;
				panTunPage.Height = height / 2;
			}
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

				string strDishTypes = ConfigurationManager.AppSettings["dishtypes"];
				string typeCondition = "";

				if (string.IsNullOrEmpty(strDishTypes))
					typeCondition = "('')";
				else
					typeCondition = "('" + strDishTypes.Replace(",", "','") + "')";
				string sql = "SELECT * FROM BaseDishType WHERE UID IN " + typeCondition + " AND IsEnable=1 ORDER BY PrintOrder ASC";
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

		private void frmDanXiangMergeDish_Load(object sender, EventArgs e)
		{
			setOemInfo();

			LoadDishType();

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
			StartMonitor();
		}

		private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
		{
			Pen pp = new Pen(Color.Gray);
			e.Graphics.DrawRectangle(pp, e.CellBounds.X, e.CellBounds.Y, e.CellBounds.X + e.CellBounds.Width - 1, e.CellBounds.Y + e.CellBounds.Height - 1);
		}

		public void StartMonitor()
		{
			Common.ajudgeLocalTimeBaseServer();

			var result = Common.CreateDB();
			if (result == "fail")
			{
				MessageBox.Show("创建表【OrderHuaDan】和【HisOrderHuaDan】失败！");
				return;
			}

			LoadAllZhuoTaiDish("");
			timer1.Start();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			//TimeSpan delta = DateTime.Now - lastClickTime;
			//if (delta.TotalMilliseconds >= 15000)
			//{
			RefreshData();

			//txtHuaCaiNum.Focus();
			//}
		}

		private void RefreshData()
		{
			LoadAllZhuoTaiDish("");
			//txtHuaCaiNum.Focus();
		}

		public void LoadAllZhuoTaiDish(string dishInfo)
		{
			startTime = Common.InitCanBie();//DateTime.Now.AddDays(-1); //DateTime.Parse("2015-08-01"); 这个地方将来要改成按照餐别来
			try
			{
				string strAlertTime = ConfigurationManager.AppSettings["alerttime"];
				if (!string.IsNullOrEmpty(strAlertTime))
					alertTime = double.Parse(strAlertTime);

				qiantaiMode = 0;

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

				string conditionDishQuery = string.Empty;
				if (!string.IsNullOrEmpty(dishInfo))
					conditionDishQuery = " inner join BaseDish on t.DishID=BaseDish.UID where BaseDish.QuickCode1 like '%" + dishInfo + "%' or BaseDish.QuickCode2 like '%" + dishInfo + "%' or BaseDish.DishName like '%" + dishInfo + "%' ";

				string strSql = "";
				if (qiantaiMode == 0)  //中餐
				{
					string showDishForFinishPay = ConfigurationManager.AppSettings["showDishForFinishPay"];
					string sqlYJS = string.Empty;
					if ("1".Equals(showDishForFinishPay))
					{
						sqlYJS = " UNION ALL "
							   + " SELECT HisOrderZhuoTaiDish.DishID,HisOrderZhuoTaiDish.dishName,SUM(HisOrderZhuoTaiDish.DishNum+HisOrderZhuoTaiDish.DishZengSongNum) as DishNum,HisOrderZhuoTaiDish.UnitName,Min(HisOrderZhuoTaiDish.AddTime) as AddTime "
							   + " FROM HisOrderZhuoTaiDish with(nolock)  INNER JOIN HisOrderInfo with(nolock) on HisOrderInfo.UID =HisOrderZhuoTaiDish.OrderID "
							   + " INNER JOIN BaseDishType with(nolock) on BaseDishType.UID=HisOrderZhuoTaiDish.DishTypeID "
							   + " INNER JOIN HisOrderZhuoTai orderzt with(nolock) ON orderzt.UID=HisOrderZhuoTaiDish.OrderZhuoTaiID "
							   + " left join BaseZhuoTai zt  with(nolock) on orderzt.ZhuoTaiID=zt.UID "
							   + " left join BaseTingMianLouCeng tmlc  with(nolock) on tmlc.UID=zt.TMLCID  "
							   + " WHERE HisOrderZhuoTaiDish.DishStatusID=1 AND IsHuaCai=0 AND HisOrderZhuoTaiDish.StoreID=" + Tools.CurrentUser.StoreID + " AND HisOrderZhuoTaiDish.SongDanTime>'" + startTime + "'  "
							   + " AND HisOrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND (HisOrderZhuoTaiDish.DishNum+HisOrderZhuoTaiDish.DishZengSongNum)>0  AND HisOrderZhuoTaiDish.DishID NOT IN " + dishCondition
							   + " AND HisOrderInfo.UID NOT IN(select OrderID From  OrderWaiMaiAddress with(nolock) where AddTime >'" + startTime + "' ) "
							   + " AND HisOrderInfo.UID NOT IN(select OrderID From  HisOrderWaiMaiAddress with(nolock) where AddTime >'" + startTime + "' ) " + AddQueryCondition() + Common.GetTMLCCondition()
							   + " GROUP BY HisOrderZhuoTaiDish.DishID,HisOrderZhuoTaiDish.dishName,HisOrderZhuoTaiDish.UnitName ";
					}

					strSql = " select  t.DishID,t.DishName,ISNULL(SUM(t.DishNum),0) as DishNum,t.UnitName,Min(t.AddTime) as AddTime  from ( "
						   + " SELECT OrderZhuoTaiDish.DishID,OrderZhuoTaiDish.dishName,SUM(OrderZhuoTaiDish.DishNum+OrderZhuoTaiDish.DishZengSongNum) as DishNum,OrderZhuoTaiDish.UnitName,Min(OrderZhuoTaiDish.AddTime) as AddTime "
						   + " FROM OrderZhuoTaiDish with(nolock)  INNER JOIN OrderInfo with(nolock) on OrderInfo.UID =OrderZhuoTaiDish.OrderID "
						   + " INNER JOIN BaseDishType with(nolock) on BaseDishType.UID=OrderZhuoTaiDish.DishTypeID "
						   + " INNER JOIN OrderZhuoTai orderzt with(nolock) ON orderzt.UID=OrderZhuoTaiDish.OrderZhuoTaiID "
						   + " left join BaseZhuoTai zt  with(nolock) on orderzt.ZhuoTaiID=zt.UID "
						   + " left join BaseTingMianLouCeng tmlc  with(nolock) on tmlc.UID=zt.TMLCID  "
						   + " WHERE OrderZhuoTaiDish.DishStatusID=1 AND IsHuaCai=0 AND OrderZhuoTaiDish.StoreID=" + Tools.CurrentUser.StoreID + " AND OrderZhuoTaiDish.SongDanTime>'" + startTime + "'  "
						   + " AND OrderZhuoTaiDish.DishTypeID IN " + typeCondition + " AND (OrderZhuoTaiDish.DishNum+OrderZhuoTaiDish.DishZengSongNum)>0  AND OrderZhuoTaiDish.DishID NOT IN " + dishCondition
						   + " AND OrderInfo.UID NOT IN(select OrderID From  OrderWaiMaiAddress with(nolock) where AddTime >'" + startTime + "' ) "
						   + " AND OrderInfo.UID NOT IN(select OrderID From  HisOrderWaiMaiAddress with(nolock) where AddTime >'" + startTime + "' ) " + AddQueryCondition() + Common.GetTMLCCondition()
						   + " GROUP BY OrderZhuoTaiDish.DishID,OrderZhuoTaiDish.dishName,OrderZhuoTaiDish.UnitName "
						   + " UNION  ALL "
						   + " SELECT OrderZhuoTaiDish.DishID,OrderZhuoTaiDish.dishName,SUM(OrderZhuoTaiDish.DishNum+OrderZhuoTaiDish.DishZengSongNum) as DishNum,OrderZhuoTaiDish.UnitName,Min(OrderZhuoTaiDish.AddTime) as AddTime "
						   + " FROM OrderZhuoTaiDish with(nolock) "
						   + " INNER JOIN OrderWaiMaiAddress with(nolock) ON OrderWaiMaiAddress.OrderID=OrderZhuoTaiDish.OrderID "
						   + " INNER JOIN BaseDishType with(nolock) on BaseDishType.UID=OrderZhuoTaiDish.DishTypeID "
						   + " INNER JOIN OrderZhuoTai orderzt with(nolock) ON orderzt.UID=OrderZhuoTaiDish.OrderZhuoTaiID "
						   + " left join BaseZhuoTai zt  with(nolock) on orderzt.ZhuoTaiID=zt.UID "
						   + " left join BaseTingMianLouCeng tmlc  with(nolock) on tmlc.UID=zt.TMLCID  "
						   + " WHERE OrderZhuoTaiDish.DishStatusID=1 AND IsHuaCai=0 AND (OrderZhuoTaiDish.DishNum+OrderZhuoTaiDish.DishZengSongNum)>0 AND OrderZhuoTaiDish.StoreID=" + Tools.CurrentUser.StoreID + " AND OrderZhuoTaiDish.SongDanTime>'" + startTime + "' "
						   + " AND OrderZhuoTaiDish.DishTypeID IN " + typeCondition + "  AND OrderZhuoTaiDish.DishID NOT IN " + dishCondition
						   + " AND (OrderWaiMaiAddress.Source=11 or OrderWaiMaiAddress.Source=12 or OrderWaiMaiAddress.Source=13 or OrderWaiMaiAddress.Source=0) and OrderWaiMaiAddress.HasAccept=1 " + AddQueryCondition() + Common.GetTMLCCondition()
						   + " GROUP BY OrderZhuoTaiDish.DishID,OrderZhuoTaiDish.dishName,OrderZhuoTaiDish.UnitName "
						   + " UNION  ALL "
						   + " SELECT HisOrderZhuoTaiDish.DishID,HisOrderZhuoTaiDish.dishName,SUM(HisOrderZhuoTaiDish.DishNum+HisOrderZhuoTaiDish.DishZengSongNum) as DishNum,HisOrderZhuoTaiDish.UnitName,Min(HisOrderZhuoTaiDish.AddTime) as AddTime "
						   + " FROM HisOrderZhuoTaiDish with(nolock) "
						   + " INNER JOIN HisOrderWaiMaiAddress with(nolock) ON HisOrderWaiMaiAddress.OrderID=HisOrderZhuoTaiDish.OrderID "
						   + " INNER JOIN BaseDishType with(nolock) on BaseDishType.UID=HisOrderZhuoTaiDish.DishTypeID "
						   + " INNER JOIN HisOrderZhuoTai orderzt with(nolock) ON orderzt.UID=HisOrderZhuoTaiDish.OrderZhuoTaiID "
						   + " left join BaseZhuoTai zt  with(nolock) on orderzt.ZhuoTaiID=zt.UID "
						   + " left join BaseTingMianLouCeng tmlc  with(nolock) on tmlc.UID=zt.TMLCID  "
						   + " WHERE HisOrderZhuoTaiDish.DishStatusID=1 AND IsHuaCai=0 AND (HisOrderZhuoTaiDish.DishNum+HisOrderZhuoTaiDish.DishZengSongNum)>0 AND HisOrderZhuoTaiDish.StoreID=" + Tools.CurrentUser.StoreID + " AND HisOrderZhuoTaiDish.SongDanTime>'" + startTime + "' "
						   + " AND HisOrderZhuoTaiDish.DishTypeID IN " + typeCondition + "  AND HisOrderZhuoTaiDish.DishID NOT IN " + dishCondition
						   + " AND (HisOrderWaiMaiAddress.Source=11 or HisOrderWaiMaiAddress.Source=12 or HisOrderWaiMaiAddress.Source=13 or HisOrderWaiMaiAddress.Source=0) and HisOrderWaiMaiAddress.HasAccept=1 " + AddQueryCondition() + Common.GetTMLCCondition()
						   + " GROUP BY HisOrderZhuoTaiDish.DishID,HisOrderZhuoTaiDish.dishName,HisOrderZhuoTaiDish.UnitName " + sqlYJS + " ) t " + conditionDishQuery + " Group BY t.DishID,t.DishName,t.UnitName order by AddTime asc";
				}
				else if (qiantaiMode == 1) //快餐
				{
					strSql = " select t.DishID,t.DishName,ISNULL(SUM(t.DishNum),0) as DishNum,t.UnitName,Min(t.AddTime) as AddTime from ( "
						  + " SELECT HisOrderZhuoTaiDish.DishID,HisOrderZhuoTaiDish.dishName,SUM(HisOrderZhuoTaiDish.DishNum+HisOrderZhuoTaiDish.DishZengSongNum) as DishNum,HisOrderZhuoTaiDish.UnitName,Min(HisOrderZhuoTaiDish.AddTime) as AddTime "
						  + " FROM HisOrderZhuoTaiDish with(nolock) INNER JOIN HisOrderInfo with(nolock) on HisOrderInfo.UID =HisOrderZhuoTaiDish.OrderID "
						  + " INNER JOIN BaseDishType with(nolock) on BaseDishType.UID=HisOrderZhuoTaiDish.DishTypeID "
						  + " INNER JOIN HisOrderZhuoTai orderzt with(nolock) ON orderzt.UID=HisOrderZhuoTaiDish.OrderZhuoTaiID "
						  + " left join BaseZhuoTai zt  with(nolock) on orderzt.ZhuoTaiID=zt.UID "
						  + " left join BaseTingMianLouCeng tmlc  with(nolock) on tmlc.UID=zt.TMLCID  "
						  + " WHERE HisOrderZhuoTaiDish.DishStatusID=1 AND IsHuaCai=0  AND (HisOrderZhuoTaiDish.DishNum+HisOrderZhuoTaiDish.DishZengSongNum)>0  AND HisOrderZhuoTaiDish.StoreID=" + Tools.CurrentUser.StoreID + " AND HisOrderZhuoTaiDish.SongDanTime>'" + startTime + "'  "
						  + " AND HisOrderZhuoTaiDish.DishTypeID IN " + typeCondition + "  AND HisOrderZhuoTaiDish.DishID NOT IN " + dishCondition
						  + " AND HisOrderInfo.UID NOT IN(select OrderID From  OrderWaiMaiAddress with(nolock) where AddTime >'" + startTime + "' ) "
						  + " AND HisOrderInfo.UID NOT IN(select OrderID From  HisOrderWaiMaiAddress with(nolock) where AddTime >'" + startTime + "' ) " + AddQueryCondition() + Common.GetTMLCCondition()
						  + " GROUP BY HisOrderZhuoTaiDish.DishID,HisOrderZhuoTaiDish.dishName,HisOrderZhuoTaiDish.UnitName "
						  + " UNION ALL "
						  + " SELECT OrderZhuoTaiDish.DishID,OrderZhuoTaiDish.dishName,SUM(OrderZhuoTaiDish.DishNum+OrderZhuoTaiDish.DishZengSongNum) as DishNum,OrderZhuoTaiDish.UnitName,Min(OrderZhuoTaiDish.AddTime) as AddTime "
						  + " FROM OrderZhuoTaiDish with(nolock) "
						  + " INNER JOIN OrderWaiMaiAddress with(nolock) ON OrderWaiMaiAddress.OrderID=OrderZhuoTaiDish.OrderID "
						  + " INNER JOIN BaseDishType with(nolock) on BaseDishType.UID=OrderZhuoTaiDish.DishTypeID "
						  + " INNER JOIN OrderZhuoTai orderzt with(nolock) ON orderzt.UID=OrderZhuoTaiDish.OrderZhuoTaiID "
						  + " left join BaseZhuoTai zt  with(nolock) on orderzt.ZhuoTaiID=zt.UID "
						  + " left join BaseTingMianLouCeng tmlc  with(nolock) on tmlc.UID=zt.TMLCID  "
						  + " WHERE OrderZhuoTaiDish.DishStatusID=1 AND IsHuaCai=0  AND (OrderZhuoTaiDish.DishNum+OrderZhuoTaiDish.DishZengSongNum)>0  AND OrderZhuoTaiDish.StoreID=" + Tools.CurrentUser.StoreID + " AND OrderZhuoTaiDish.SongDanTime>'" + startTime + "' "
						  + " AND OrderZhuoTaiDish.DishTypeID IN " + typeCondition + "  AND OrderZhuoTaiDish.DishID NOT IN " + dishCondition
						  + " AND (OrderWaiMaiAddress.Source=11 or OrderWaiMaiAddress.Source=12 or OrderWaiMaiAddress.Source=13 or OrderWaiMaiAddress.Source=0) and OrderWaiMaiAddress.HasAccept=1 " + AddQueryCondition() + Common.GetTMLCCondition()
						  + " GROUP BY OrderZhuoTaiDish.DishID,OrderZhuoTaiDish.dishName,OrderZhuoTaiDish.UnitName "
						  + " UNION ALL "
						  + " SELECT HisOrderZhuoTaiDish.DishID,HisOrderZhuoTaiDish.dishName,SUM(HisOrderZhuoTaiDish.DishNum+HisOrderZhuoTaiDish.DishZengSongNum) as DishNum,HisOrderZhuoTaiDish.UnitName,Min(HisOrderZhuoTaiDish.AddTime) as AddTime "
						  + " FROM HisOrderZhuoTaiDish "
						  + " INNER JOIN HisOrderWaiMaiAddress ON HisOrderWaiMaiAddress.OrderID=HisOrderZhuoTaiDish.OrderID "
						  + " INNER JOIN BaseDishType with(nolock) on BaseDishType.UID=HisOrderZhuoTaiDish.DishTypeID "
						  + " INNER JOIN HisOrderZhuoTai orderzt with(nolock) ON orderzt.UID=HisOrderZhuoTaiDish.OrderZhuoTaiID "
						  + " left join BaseZhuoTai zt  with(nolock) on orderzt.ZhuoTaiID=zt.UID "
						  + " left join BaseTingMianLouCeng tmlc  with(nolock) on tmlc.UID=zt.TMLCID  "
						  + " WHERE HisOrderZhuoTaiDish.DishStatusID=1 AND IsHuaCai=0  AND (HisOrderZhuoTaiDish.DishNum+HisOrderZhuoTaiDish.DishZengSongNum)>0  AND HisOrderZhuoTaiDish.StoreID=" + Tools.CurrentUser.StoreID + " AND HisOrderZhuoTaiDish.SongDanTime>'" + startTime + "' "
						  + " AND HisOrderZhuoTaiDish.DishTypeID IN " + typeCondition + "  AND HisOrderZhuoTaiDish.DishID NOT IN " + dishCondition
						  + " AND (HisOrderWaiMaiAddress.Source=11 or HisOrderWaiMaiAddress.Source=12 or HisOrderWaiMaiAddress.Source=13 or HisOrderWaiMaiAddress.Source=0) and HisOrderWaiMaiAddress.HasAccept=1 " + AddQueryCondition() + Common.GetTMLCCondition()
						  + " GROUP BY HisOrderZhuoTaiDish.DishID,HisOrderZhuoTaiDish.dishName,HisOrderZhuoTaiDish.UnitName "
						  + " ) t " + conditionDishQuery + " Group BY t.DishID,t.DishName,t.UnitName  order by AddTime asc";
				}


				GetOrderGuQingAllData();

				DataTable table = DBHelper.ExeSqlForDataTable(strSql);
				tableAllData = GetAllData();
				ShowDishs(table, tableAllData);
			}
			catch (Exception ex)
			{
				Log.WriteLog("菜品合并 LoadAllZhuoTaiDish错误信息:" + ex.ToString());
			}
		}

		private DataTable GetAllData()
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



			string strSql = "";
			if (qiantaiMode == 0)  //中餐
			{
				string showDishForFinishPay = ConfigurationManager.AppSettings["showDishForFinishPay"];
				string sqlYJS = string.Empty;
				if ("1".Equals(showDishForFinishPay))
				{
					sqlYJS = " UNION "
						   + " SELECT orderzt.UID as ZTUID,HisOrderZhuoTaiDish.DishID,HisOrderZhuoTaiDish.dishName,HisOrderZhuoTaiDish.ZuoFaNames,HisOrderZhuoTaiDish.KouWeiNames,HisOrderZhuoTaiDish.UnitName,HisOrderZhuoTaiDish.AddTime,orderzt.ZhuoTaiName,HisOrderZhuoTaiDish.IsHuaCai,HisOrderZhuoTaiDish.DishTypeID,HisOrderZhuoTaiDish.UID,(HisOrderZhuoTaiDish.DishNum+HisOrderZhuoTaiDish.DishZengSongNum) as DishNum,isnull(HisOrderZhuoTaiDish.SongDanTime,HisOrderZhuoTaiDish.Addtime) as SongDanTime,HisOrderInfo.IsWaiMai,HisOrderZhuoTaiDish.DishStatusDesc "
						   + " FROM HisOrderZhuoTaiDish with(nolock) INNER JOIN HisOrderInfo with(nolock) on HisOrderInfo.UID =HisOrderZhuoTaiDish.OrderID "
						   + " INNER JOIN HisOrderZhuoTai orderzt with(nolock) ON orderzt.OrderID=HisOrderInfo.UID "
						   + " INNER JOIN BaseDishType with(nolock) on BaseDishType.UID=HisOrderZhuoTaiDish.DishTypeID "
						   + " left join BaseZhuoTai zt  with(nolock)  on orderzt.ZhuoTaiID=zt.UID "
						   + " left join BaseTingMianLouCeng  tmlc with(nolock) on tmlc.UID=zt.TMLCID "
						   + " WHERE HisOrderZhuoTaiDish.DishStatusID=1 AND IsHuaCai=0  AND (HisOrderZhuoTaiDish.DishNum+HisOrderZhuoTaiDish.DishZengSongNum)>0  AND HisOrderZhuoTaiDish.StoreID=" + Tools.CurrentUser.StoreID + " AND HisOrderZhuoTaiDish.SongDanTime>'" + startTime + "'  "
						   + " AND HisOrderZhuoTaiDish.DishTypeID IN " + typeCondition + "  AND HisOrderZhuoTaiDish.DishID NOT IN " + dishCondition
						   + " AND HisOrderInfo.UID NOT IN(select OrderID From  OrderWaiMaiAddress with(nolock) where AddTime >'" + startTime + "' ) "
						   + " AND HisOrderInfo.UID NOT IN(select OrderID From  HisOrderWaiMaiAddress with(nolock) where AddTime >'" + startTime + "' ) " + AddQueryCondition() + Common.GetTMLCCondition();
				}

				strSql = " SELECT * FROM ( "
							 + " SELECT orderzt.UID as ZTUID,OrderZhuoTaiDish.DishID,OrderZhuoTaiDish.dishName,OrderZhuoTaiDish.ZuoFaNames,OrderZhuoTaiDish.KouWeiNames,OrderZhuoTaiDish.UnitName,OrderZhuoTaiDish.AddTime,orderzt.ZhuoTaiName,OrderZhuoTaiDish.IsHuaCai,OrderZhuoTaiDish.DishTypeID,OrderZhuoTaiDish.UID,(OrderZhuoTaiDish.DishNum+OrderZhuoTaiDish.DishZengSongNum) as DishNum,isnull(OrderZhuoTaiDish.SongDanTime,OrderZhuoTaiDish.Addtime) as SongDanTime,OrderInfo.IsWaiMai,OrderZhuoTaiDish.DishStatusDesc "
							 + " FROM OrderZhuoTaiDish with(nolock) INNER JOIN OrderInfo with(nolock) on OrderInfo.UID =OrderZhuoTaiDish.OrderID "
							 + " INNER JOIN OrderZhuoTai orderzt with(nolock) ON orderzt.OrderID=OrderInfo.UID "
							 + " INNER JOIN BaseDishType with(nolock) on BaseDishType.UID=OrderZhuoTaiDish.DishTypeID "
							 + " left join BaseZhuoTai zt  with(nolock) on orderzt.ZhuoTaiID=zt.UID "
							 + " left join BaseTingMianLouCeng tmlc  with(nolock) on tmlc.UID=zt.TMLCID "
							 + " WHERE OrderZhuoTaiDish.DishStatusID=1 AND IsHuaCai=0  AND (OrderZhuoTaiDish.DishNum+OrderZhuoTaiDish.DishZengSongNum)>0  AND OrderZhuoTaiDish.StoreID=" + Tools.CurrentUser.StoreID + " AND OrderZhuoTaiDish.SongDanTime>'" + startTime + "'  "
							 + " AND OrderZhuoTaiDish.DishTypeID IN " + typeCondition + "  AND OrderZhuoTaiDish.DishID NOT IN " + dishCondition
							 + " AND OrderInfo.UID NOT IN(select OrderID From  OrderWaiMaiAddress with(nolock) where AddTime >'" + startTime + "' ) "
							 + " AND OrderInfo.UID NOT IN(select OrderID From  HisOrderWaiMaiAddress with(nolock) where AddTime >'" + startTime + "' ) " + AddQueryCondition() + Common.GetTMLCCondition()
							 + " UNION "
							 + " SELECT orderzt.UID as ZTUID,OrderZhuoTaiDish.DishID,OrderZhuoTaiDish.dishName,OrderZhuoTaiDish.ZuoFaNames,OrderZhuoTaiDish.KouWeiNames,OrderZhuoTaiDish.UnitName,OrderZhuoTaiDish.AddTime,orderzt.ZhuoTaiName,OrderZhuoTaiDish.IsHuaCai,OrderZhuoTaiDish.DishTypeID,OrderZhuoTaiDish.UID,(OrderZhuoTaiDish.DishNum+OrderZhuoTaiDish.DishZengSongNum) as DishNum,isnull(OrderZhuoTaiDish.SongDanTime,OrderZhuoTaiDish.Addtime) as SongDanTime,OrderInfo.IsWaiMai,OrderZhuoTaiDish.DishStatusDesc "
							 + " FROM OrderZhuoTaiDish with(nolock) "
							 + " INNER JOIN OrderZhuoTai orderzt with(nolock) ON orderzt.UID=OrderZhuoTaiDish.OrderZhuoTaiID "
							 + " INNER JOIN OrderInfo with(nolock) ON OrderInfo.UID=orderzt.OrderID  "
							 + " INNER JOIN OrderWaiMaiAddress with(nolock) ON OrderWaiMaiAddress.OrderID=OrderZhuoTaiDish.OrderID "
							 + " INNER JOIN BaseDishType with(nolock) on BaseDishType.UID=OrderZhuoTaiDish.DishTypeID "
							 + " left join BaseZhuoTai zt  with(nolock) on orderzt.ZhuoTaiID=zt.UID "
							 + " left join BaseTingMianLouCeng tmlc  with(nolock) on tmlc.UID=zt.TMLCID "
							 + " WHERE OrderZhuoTaiDish.DishStatusID=1 AND IsHuaCai=0  AND (OrderZhuoTaiDish.DishNum+OrderZhuoTaiDish.DishZengSongNum)>0  AND OrderZhuoTaiDish.StoreID=" + Tools.CurrentUser.StoreID + " AND OrderZhuoTaiDish.SongDanTime>'" + startTime + "' "
							 + " AND OrderZhuoTaiDish.DishTypeID IN " + typeCondition + "  AND OrderZhuoTaiDish.DishID NOT IN " + dishCondition
							 + " AND (OrderWaiMaiAddress.Source=11 or OrderWaiMaiAddress.Source=12 or OrderWaiMaiAddress.Source=13 or OrderWaiMaiAddress.Source=0) and OrderWaiMaiAddress.HasAccept=1 " + AddQueryCondition() + Common.GetTMLCCondition()
							 + " UNION "
							 + " SELECT orderzt.UID as ZTUID,HisOrderZhuoTaiDish.DishID,HisOrderZhuoTaiDish.dishName,HisOrderZhuoTaiDish.ZuoFaNames,HisOrderZhuoTaiDish.KouWeiNames,HisOrderZhuoTaiDish.UnitName,HisOrderZhuoTaiDish.AddTime,orderzt.ZhuoTaiName,HisOrderZhuoTaiDish.IsHuaCai,HisOrderZhuoTaiDish.DishTypeID,HisOrderZhuoTaiDish.UID,(HisOrderZhuoTaiDish.DishNum+HisOrderZhuoTaiDish.DishZengSongNum) as DishNum,isnull(HisOrderZhuoTaiDish.SongDanTime,HisOrderZhuoTaiDish.Addtime) as SongDanTime,HisOrderInfo.IsWaiMai,HisOrderZhuoTaiDish.DishStatusDesc "
							 + " FROM HisOrderZhuoTaiDish with(nolock) "
							 + " INNER JOIN HisOrderZhuoTai orderzt with(nolock) ON orderzt.UID=HisOrderZhuoTaiDish.OrderZhuoTaiID "
							 + " INNER JOIN HisOrderInfo with(nolock) ON HisOrderInfo.UID=orderzt.OrderID  "
							 + " INNER JOIN HisOrderWaiMaiAddress with(nolock) ON HisOrderWaiMaiAddress.OrderID=HisOrderZhuoTaiDish.OrderID "
							 + " INNER JOIN BaseDishType with(nolock) on BaseDishType.UID=HisOrderZhuoTaiDish.DishTypeID "
							 + " left join BaseZhuoTai zt  with(nolock) on orderzt.ZhuoTaiID=zt.UID "
							 + " left join BaseTingMianLouCeng tmlc  with(nolock) on tmlc.UID=zt.TMLCID "
							 + " WHERE HisOrderZhuoTaiDish.DishStatusID=1 AND IsHuaCai=0  AND (HisOrderZhuoTaiDish.DishNum+HisOrderZhuoTaiDish.DishZengSongNum)>0  AND HisOrderZhuoTaiDish.StoreID=" + Tools.CurrentUser.StoreID + " AND HisOrderZhuoTaiDish.SongDanTime>'" + startTime + "' "
							 + " AND HisOrderZhuoTaiDish.DishTypeID IN " + typeCondition + "  AND HisOrderZhuoTaiDish.DishID NOT IN " + dishCondition
							 + " AND (HisOrderWaiMaiAddress.Source=11 or HisOrderWaiMaiAddress.Source=12 or HisOrderWaiMaiAddress.Source=13 or HisOrderWaiMaiAddress.Source=0) and HisOrderWaiMaiAddress.HasAccept=1 " + AddQueryCondition() + Common.GetTMLCCondition()
							 + sqlYJS
							 + " ) tableTmp ORDER BY AddTime asc ";
			}
			else
			{
				strSql = " SELECT * FROM ( "
					   + " SELECT orderzt.UID as ZTUID,HisOrderZhuoTaiDish.DishID,HisOrderZhuoTaiDish.dishName,HisOrderZhuoTaiDish.ZuoFaNames,HisOrderZhuoTaiDish.KouWeiNames,HisOrderZhuoTaiDish.UnitName,HisOrderZhuoTaiDish.AddTime,orderzt.ZhuoTaiName,HisOrderZhuoTaiDish.IsHuaCai,HisOrderZhuoTaiDish.DishTypeID,HisOrderZhuoTaiDish.UID,(HisOrderZhuoTaiDish.DishNum+HisOrderZhuoTaiDish.DishZengSongNum) as DishNum,isnull(HisOrderZhuoTaiDish.SongDanTime,HisOrderZhuoTaiDish.Addtime) as SongDanTime,HisOrderInfo.IsWaiMai,HisOrderZhuoTaiDish.DishStatusDesc "
					   + " FROM HisOrderZhuoTaiDish with(nolock) INNER JOIN HisOrderInfo with(nolock) on HisOrderInfo.UID =HisOrderZhuoTaiDish.OrderID "
					   + " INNER JOIN HisOrderZhuoTai orderzt with(nolock) ON orderzt.OrderID=HisOrderInfo.UID "
					   + " INNER JOIN BaseDishType with(nolock) on BaseDishType.UID=HisOrderZhuoTaiDish.DishTypeID "
					   + " left join BaseZhuoTai zt  with(nolock) on orderzt.ZhuoTaiID=zt.UID "
					   + " left join BaseTingMianLouCeng tmlc  with(nolock) on tmlc.UID=zt.TMLCID "
					   + " WHERE HisOrderZhuoTaiDish.DishStatusID=1 AND IsHuaCai=0  AND (HisOrderZhuoTaiDish.DishNum+HisOrderZhuoTaiDish.DishZengSongNum)>0  AND HisOrderZhuoTaiDish.StoreID=" + Tools.CurrentUser.StoreID + " AND HisOrderZhuoTaiDish.SongDanTime>'" + startTime + "'  "
					   + " AND HisOrderZhuoTaiDish.DishTypeID IN " + typeCondition + "  AND HisOrderZhuoTaiDish.DishID NOT IN " + dishCondition
					   + " AND HisOrderInfo.UID NOT IN(select OrderID From  OrderWaiMaiAddress with(nolock) where AddTime >'" + startTime + "' ) "
					   + " AND HisOrderInfo.UID NOT IN(select OrderID From  HisOrderWaiMaiAddress with(nolock) where AddTime >'" + startTime + "' ) " + AddQueryCondition() + Common.GetTMLCCondition()
					   + " UNION "
					   + " SELECT orderzt.UID as ZTUID,OrderZhuoTaiDish.DishID,OrderZhuoTaiDish.dishName,OrderZhuoTaiDish.ZuoFaNames,OrderZhuoTaiDish.KouWeiNames,OrderZhuoTaiDish.UnitName,OrderZhuoTaiDish.AddTime,orderzt.ZhuoTaiName,OrderZhuoTaiDish.IsHuaCai,OrderZhuoTaiDish.DishTypeID,OrderZhuoTaiDish.UID,(OrderZhuoTaiDish.DishNum+OrderZhuoTaiDish.DishZengSongNum) as DishNum,isnull(OrderZhuoTaiDish.SongDanTime,OrderZhuoTaiDish.Addtime) as SongDanTime,OrderInfo.IsWaiMai,OrderZhuoTaiDish.DishStatusDesc "
					   + " FROM OrderZhuoTaiDish with(nolock) "
					   + " INNER JOIN OrderZhuoTai orderzt with(nolock) ON orderzt.UID=OrderZhuoTaiDish.OrderZhuoTaiID "
					   + " INNER JOIN OrderInfo with(nolock) ON OrderInfo.UID=orderzt.OrderID  "
					   + " INNER JOIN OrderWaiMaiAddress with(nolock) ON OrderWaiMaiAddress.OrderID=OrderZhuoTaiDish.OrderID "
					   + " INNER JOIN BaseDishType with(nolock) on BaseDishType.UID=OrderZhuoTaiDish.DishTypeID "
					   + " left join BaseZhuoTai zt  with(nolock) on orderzt.ZhuoTaiID=zt.UID "
					   + " left join BaseTingMianLouCeng tmlc  with(nolock) on tmlc.UID=zt.TMLCID "
					   + " WHERE OrderZhuoTaiDish.DishStatusID=1 AND IsHuaCai=0  AND (OrderZhuoTaiDish.DishNum+OrderZhuoTaiDish.DishZengSongNum)>0  AND OrderZhuoTaiDish.StoreID=" + Tools.CurrentUser.StoreID + " AND OrderZhuoTaiDish.SongDanTime>'" + startTime + "' "
					   + " AND OrderZhuoTaiDish.DishTypeID IN " + typeCondition + "  AND OrderZhuoTaiDish.DishID NOT IN " + dishCondition
					   + " AND (OrderWaiMaiAddress.Source=11 or OrderWaiMaiAddress.Source=12 or OrderWaiMaiAddress.Source=13 or OrderWaiMaiAddress.Source=0) and OrderWaiMaiAddress.HasAccept=1 " + AddQueryCondition() + Common.GetTMLCCondition()
					   + " UNION "
					   + " SELECT orderzt.UID as ZTUID,HisOrderZhuoTaiDish.DishID,HisOrderZhuoTaiDish.dishName,HisOrderZhuoTaiDish.ZuoFaNames,HisOrderZhuoTaiDish.KouWeiNames,HisOrderZhuoTaiDish.UnitName,HisOrderZhuoTaiDish.AddTime,orderzt.ZhuoTaiName,HisOrderZhuoTaiDish.IsHuaCai,HisOrderZhuoTaiDish.DishTypeID,HisOrderZhuoTaiDish.UID,(HisOrderZhuoTaiDish.DishNum+HisOrderZhuoTaiDish.DishZengSongNum) as DishNum,isnull(HisOrderZhuoTaiDish.SongDanTime,HisOrderZhuoTaiDish.Addtime) as SongDanTime,HisOrderInfo.IsWaiMai,HisOrderZhuoTaiDish.DishStatusDesc "
					   + " FROM HisOrderZhuoTaiDish "
					   + " INNER JOIN HisOrderZhuoTai orderzt with(nolock) ON orderzt.UID=HisOrderZhuoTaiDish.OrderZhuoTaiID "
					   + " INNER JOIN HisOrderInfo with(nolock) ON HisOrderInfo.UID=orderzt.OrderID  "
					   + " INNER JOIN HisOrderWaiMaiAddress ON HisOrderWaiMaiAddress.OrderID=HisOrderZhuoTaiDish.OrderID "
					   + " INNER JOIN BaseDishType with(nolock) on BaseDishType.UID=HisOrderZhuoTaiDish.DishTypeID "
					   + " left join BaseZhuoTai zt  with(nolock) on orderzt.ZhuoTaiID=zt.UID "
					   + " left join BaseTingMianLouCeng tmlc  with(nolock) on tmlc.UID=zt.TMLCID "
					   + " WHERE HisOrderZhuoTaiDish.DishStatusID=1 AND IsHuaCai=0  AND (HisOrderZhuoTaiDish.DishNum+HisOrderZhuoTaiDish.DishZengSongNum)>0  AND HisOrderZhuoTaiDish.StoreID=" + Tools.CurrentUser.StoreID + " AND HisOrderZhuoTaiDish.SongDanTime>'" + startTime + "' "
					   + " AND HisOrderZhuoTaiDish.DishTypeID IN " + typeCondition + "  AND HisOrderZhuoTaiDish.DishID NOT IN " + dishCondition
					   + " AND (HisOrderWaiMaiAddress.Source=11 or HisOrderWaiMaiAddress.Source=12 or HisOrderWaiMaiAddress.Source=13 or HisOrderWaiMaiAddress.Source=0) and HisOrderWaiMaiAddress.HasAccept=1 " + AddQueryCondition() + Common.GetTMLCCondition()
					   + " ) tableTmp ORDER BY AddTime asc ";
			}

			return DBHelper.ExeSqlForDataTable(strSql);
		}

		private void ShowDishs(DataTable table, DataTable tableAllData)
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
					string ZuoFaNames = "";// row["ZuoFaNames"] as string;
					string KouWeiNames = "";// row["KouWeiNames"] as string;
					string UnitName = row["UnitName"].ToString();
					string DishID = row["DishID"] as string;
					string DishName = row["DishName"] as string;
					mergeDishControls[j].ZhuoTaiNum = 0 + " 桌";
					if (tableAllData.Rows.Count > 0)
					{
						//var sourceTmp = tableAllData.AsEnumerable().Where(p => p["DishID"].ToString().Equals(DishID) && p["DishName"].ToString().Equals(DishName) && p["ZuoFaNames"].ToString().Equals(ZuoFaNames) && p["KouWeiNames"].ToString().Equals(KouWeiNames)
						//                && p["UnitName"].ToString().Equals(UnitName)).Select(p => p["ZTUID"].ToString()).Distinct().ToList();

						var sourceTmp = tableAllData.AsEnumerable().Where(p => p["DishID"].ToString().Equals(DishID) && p["DishName"].ToString().Equals(DishName)
								&& p["UnitName"].ToString().Equals(UnitName)).Select(p => p["ZTUID"].ToString()).Distinct().ToList();
						mergeDishControls[j].ZhuoTaiNum = sourceTmp.Count + " 桌";
					}

					mergeDishControls[j].DishName = DishName;
					mergeDishControls[j].ZFKW = ZuoFaNames + " " + KouWeiNames;
					mergeDishControls[j].DishID = DishID;
					mergeDishControls[j].ZuoFa = ZuoFaNames;
					mergeDishControls[j].KouWei = KouWeiNames;
					mergeDishControls[j].UintName = UnitName;
					string num = String.Format("{0:F}", row["DishNum"]);
					if (num.EndsWith(".00"))
						num = num.Substring(0, num.Length - 3);
					mergeDishControls[j].DishNum = num + " " + UnitName;

					if (JudgeIsGuQing(DishID))
					{
						mergeDishControls[j].ChangeBackColorGQ(true);
					}
					else
					{
						mergeDishControls[j].ChangeBackColorGQ(false);
					}

					mergeDishControls[j].TimeOutChangeImg(false);
					if (tableAllData.Rows.Count > 0)
					{
						try
						{
							var diancaitimeTmp = tableAllData.AsEnumerable().Where(p => p["DishID"].ToString().Equals(DishID)).Select(p => p["AddTime"]).Min();
							if (!object.Equals(diancaitimeTmp, null))
							{
								TimeSpan delta = DateTime.Now - Convert.ToDateTime(diancaitimeTmp);
								double strDelta = delta.TotalMinutes;
								if (strDelta > alertTime)
								{
									mergeDishControls[j].TimeOutChangeImg(true);
								}
							}
						}
						catch (Exception ex)
						{
							Log.WriteLog("frmDanXiangMergeDish ShowDishs 时间转换错误,错误原因:" + ex.ToString());
						}
					}

					if (!string.IsNullOrEmpty(mergeDishControls[j].DishID) && mergeDishControls[j].DishID.Equals(guQingModelClass.DishID) && mergeDishControls[j].ZFKW.Trim().Equals(guQingModelClass.ZFKW.Trim()))
						mergeDishControls[j].ChangeBackColor(true);

					j++;
				}

				if (tableAllData.Rows.Count > 0 && !string.IsNullOrEmpty(model.DishID))
				{
					var sourceTmp = tableAllData.AsEnumerable().Where(p => p["DishID"].ToString().Equals(model.DishID) && p["DishName"].ToString().Equals(model.DishName)
								 && p["UnitName"].ToString().Equals(model.UnitName)).OrderBy(p => p["AddTime"]).ToList();
					ShowDishsDetail(sourceTmp);
				}
				else
				{
					ShowDishsDetail(new List<DataRow>());
				}

				tableLayoutPanel1.ResumeLayout();
				this.ResumeLayout();
			}
			catch (Exception ex)
			{
				Log.WriteLog("ShowDishs 错误信息:" + ex.ToString());
			}
		}

		private void btnUp_Click(object sender, EventArgs e)
		{
			guQingModelClass = new GuQingModelClass();
			CurrentPageNo--;
			LoadAllZhuoTaiDish("");
		}

		private void btnDown_Click(object sender, EventArgs e)
		{
			guQingModelClass = new GuQingModelClass();
			CurrentPageNo++;
			LoadAllZhuoTaiDish("");
		}

		private void MergeDishControl_Click(object sender, EventArgs e)
		{
			try
			{
				uidsList = new List<string>();
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
								//if ("1".Equals(guQingModel))
								btnGuQing.Text = "取消沽清";
								//else
								//    btnGuQing.Text = "沽清";
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

					if (tableAllData.Rows.Count > 0)
					{
						var sourceTmp = tableAllData.AsEnumerable().Where(p => p["DishID"].ToString().Equals(dishID) && p["DishName"].ToString().Equals(dishname)
										&& p["UnitName"].ToString().Equals(unitname)).OrderBy(p => p["AddTime"]).ToList();
						ShowDishsDetail(sourceTmp);
					}
					else
					{
						ShowDishsDetail(new List<DataRow>());
					}
				}

				ChangeBackColorForGQ();
			}
			catch (Exception ex)
			{
				Log.WriteLog("MergeDishControl_Click 错误信息:" + ex.ToString());
			}
		}

		private void ShowDishsDetail(List<DataRow> table)
		{
			try
			{
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
				if (endIndex > table.Count)
					endIndex = table.Count;

				if (endIndex < table.Count)
					btnDownDetail.Enabled = true;
				else
					btnDownDetail.Enabled = false;

				DateTime now = DateTime.Now;
				int j = 0;
				for (int i = startIndex; i < endIndex; i++)
				{
					DataRow row = table[i];
					string ZuoFaNames = row["ZuoFaNames"] as string;
					string KouWeiNames = row["KouWeiNames"] as string;
					string UnitName = row["UnitName"].ToString();
					string DishID = row["DishID"] as string;
					string DishName = row["DishName"] as string;
					string ZTName = row["ZhuoTaiName"] as string;
					string UID = row["UID"] as string;
					string DishStatusDesc = row["DishStatusDesc"] as string;

					mergeDishDetailControl[j].UID = UID;
					mergeDishDetailControl[j].DishName = DishName;
					mergeDishDetailControl[j].ZFKW = ZuoFaNames + " " + KouWeiNames;
					string num = String.Format("{0:F}", row["DishNum"]);
					if (num.EndsWith(".00"))
						num = num.Substring(0, num.Length - 3);
					mergeDishDetailControl[j].Count = num + " " + UnitName;
					mergeDishDetailControl[j].ZhuoTaiName = ZTName;
					mergeDishDetailControl[j].DishStatusDesc = DishStatusDesc;

					TimeSpan delta = DateTime.Now - (DateTime)row["SongDanTime"];
					double strDelta = delta.TotalMinutes;
					string strTime = "(" + strDelta.ToString("f0") + "分钟)";
					mergeDishDetailControl[j].Time = strTime;
					if (uidsList.Contains(UID))
					{
						mergeDishDetailControl[j].ChangeBackColor(true);
					}
					else
					{
						mergeDishDetailControl[j].ChangeBackColor(false);
					}
					if ((bool)row["IsWaiMai"])
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

		private void tableLayoutPanel2_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
		{
			Pen pp = new Pen(Color.Gray);
			e.Graphics.DrawRectangle(pp, e.CellBounds.X, e.CellBounds.Y, e.CellBounds.X + e.CellBounds.Width - 1, e.CellBounds.Y + e.CellBounds.Height - 1);
		}

		private void btnUpDetail_Click(object sender, EventArgs e)
		{
			CurrentPageNoDetail--;

			if (!string.IsNullOrEmpty(model.DishID) && tableAllData.Rows.Count > 0)
			{
				var sourceTmp = tableAllData.AsEnumerable().Where(p => p["DishID"].ToString().Equals(model.DishID) && p["DishName"].ToString().Equals(model.DishName)
								&& p["UnitName"].ToString().Equals(model.UnitName)).OrderBy(p => p["AddTime"]).ToList();
				ShowDishsDetail(sourceTmp);
			}
			else
			{
				ShowDishsDetail(new List<DataRow>());
			}
		}

		private void btnDownDetail_Click(object sender, EventArgs e)
		{
			CurrentPageNoDetail++;
			if (!string.IsNullOrEmpty(model.DishID) && tableAllData.Rows.Count > 0)
			{
				var sourceTmp = tableAllData.AsEnumerable().Where(p => p["DishID"].ToString().Equals(model.DishID) && p["DishName"].ToString().Equals(model.DishName)
								&& p["UnitName"].ToString().Equals(model.UnitName)).OrderBy(p => p["AddTime"]).ToList();
				ShowDishsDetail(sourceTmp);
			}
			else
			{
				ShowDishsDetail(new List<DataRow>());
			}
		}

		private void MergeDishDetailControl_Click(object sender, EventArgs e)
		{
			MergeDishDetailControl ctl = sender as MergeDishDetailControl;
			string uid = ctl.UID;
			if (!string.IsNullOrEmpty(uid))
			{
				//DialogResult result = MessageBox.Show(ctl.DishName, "划单确认", MessageBoxButtons.YesNo);
				//if (result == DialogResult.Yes)
				//{
				//    List<string> uids = new List<string>();
				//    uids.Add(uid);
				//    HuaDan(uids);
				//}

				if (uidsList.Contains(uid))
				{
					uidsList.Remove(uid);
					ctl.ChangeBackColor(false);
				}
				else
				{
					uidsList.Add(uid);
					ctl.ChangeBackColor(true);
				}
			}
		}

		private void MergeDishDetailControl_DoubleClick(object sender, EventArgs e)
		{
			MergeDishDetailControl ctl = sender as MergeDishDetailControl;
			string uid = ctl.UID;
			if (!string.IsNullOrEmpty(uid))
			{
				List<string> list = new List<string>();
				list.Add(uid);
				HuaDan(list);
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

				LoadAllZhuoTaiDish("");
				if (tableAllData.Rows.Count > 0)
				{
					for (int i = 0; i < tableAllData.Rows.Count; i++)
					{
						if (uids.Contains(tableAllData.Rows[i]["UID"].ToString()))
						{
							tableAllData.Rows.Remove(tableAllData.Rows[i]);
						}
					}

					var sourceTmp = tableAllData.AsEnumerable().Where(p => p["DishID"].ToString().Equals(model.DishID) && p["DishName"].ToString().Equals(model.DishName)
								   && p["UnitName"].ToString().Equals(model.UnitName)).OrderBy(p => p["AddTime"]).ToList();

					if (sourceTmp.Count <= 0)
					{
						CurrentPageNoDetail = 0;
						model = new MergeDishDetailModel();
						guQingModelClass = new GuQingModelClass();
					}
					ShowDishsDetail(sourceTmp);

				}

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

		private class MergeDishDetailModel
		{
			public string DishID { get; set; }
			public string DishName { get; set; }
			public string ZuoFa { get; set; }
			public string KouWei { get; set; }
			public string UnitName { get; set; }
		}

		private void btnAllHuaDan_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(model.DishID) && tableAllData.Rows.Count > 0)
			{
				//DialogResult result = MessageBox.Show("是否全部划单!", "划单", MessageBoxButtons.YesNo);
				//if (result == DialogResult.Yes)
				//{
				frmTip frm = new frmTip("是否全部划单!");
				if (frm.ShowDialog() == DialogResult.OK)
				{
					var sourceTmp = tableAllData.AsEnumerable().Where(p => p["DishID"].ToString().Equals(model.DishID) && p["DishName"].ToString().Equals(model.DishName)
									&& p["UnitName"].ToString().Equals(model.UnitName)).OrderBy(p => p["AddTime"]).ToList();
					List<string> uids = new List<string>();
					for (int i = 0; i < sourceTmp.Count; i++)
					{
						uids.Add(sourceTmp[i]["UID"].ToString());
					}

					HuaDan(uids);

					guQingModelClass = new GuQingModelClass();

					uidsList = new List<string>();
					CurrDishName = string.Empty;
				}
				//}
			}
		}

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			LoadDishType();
			RefreshData();
		}

		private void btnSetup_Click(object sender, EventArgs e)
		{
			new frmSetup().ShowDialog(this);
		}

		private void txtHuaCaiNum_Click(object sender, EventArgs e)
		{
			handMode = false;
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
					LoadAllZhuoTaiDish("");
				}
			}
			catch (Exception ex)
			{
				Log.WriteLog("txtHuaCaiNum_KeyDown 错误信息:" + ex.ToString());
			}
		}

		private void txtHuaCaiNum_Leave(object sender, EventArgs e)
		{
			//if (!handMode)
			//    txtHuaCaiNum.Focus();
		}

		private void frmDanXiangMergeDish_SizeChanged(object sender, EventArgs e)
		{

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
				Log.WriteLog("frmDanXiangMergeDish btnGuQing_Click错误信息:" + ex.ToString());
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

			int startIndex = 0;
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
			}
			#endregion
		}

		public class GuQingModelClass
		{
			public string DishID { get; set; }
			public string DishName { get; set; }
			public string ZFKW { get; set; }
		}

		private void label1_Click(object sender, EventArgs e)
		{
			frmGuQingList frm = new frmGuQingList();
			if (frm.ShowDialog() == DialogResult.OK)
			{
				RefreshData();
			}
		}

		private void btnBatchHuaDan_Click(object sender, EventArgs e)
		{
			if (uidsList.Count > 0)
			{
				frmTip frm = new frmTip(CurrDishName + "(共计:" + uidsList.Count + ")");
				if (frm.ShowDialog() == DialogResult.OK)
				{
					HuaDan(uidsList);
					uidsList = new List<string>();
					//CurrDishName = string.Empty;
				}
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
				Log.WriteLog("frmDanXiangMergeDish setOemInfo():" + ex.ToString());
			}
		}

		private void btnQuery_Click(object sender, EventArgs e)
		{
			frmQuery frm = new frmQuery("frmDanXiangMergeDish");
			frm.Owner = this;
			frm.ShowDialog();
		}

		private void txtHuaCaiNum_TextChanged(object sender, EventArgs e)
		{
			string value = txtHuaCaiNum.Text.Trim();
			try
			{
				decimal c = Convert.ToDecimal(value);
			}
			catch (Exception ex)
			{
				CurrentPageNo = 0;
				LoadAllZhuoTaiDish(value);
			}
		}

		private void btnKeyboard_Click(object sender, EventArgs e)
		{
			try
			{
				System.Diagnostics.Process.Start("osk.exe");
			}
			catch (Exception ex)
			{

			}
		}

		private void btnZTDish_Click(object sender, EventArgs e)
		{
			GetZhuoTaiNameList();
		}

		private void GetZhuoTaiNameList()
		{
			tableAllData = GetAllData();
			if (tableAllData.Rows.Count > 0)
			{
				List<string> list = new List<string>();
				DataTable tblDatas = new DataTable("Datas");
				tblDatas.Columns.Add("ZTUID", Type.GetType("System.String"));
				tblDatas.Columns.Add("ZhuoTaiName", Type.GetType("System.String"));

				foreach (DataRow dr in tableAllData.Rows)
				{
					string ztuid = dr["ZTUID"].ToString();
					if (list.IndexOf(ztuid) < 0)
					{
						list.Add(ztuid);
						tblDatas.Rows.Add(new object[] { ztuid, dr["ZhuoTaiName"].ToString() });
					}
				}

				if (list.Count > 0)
				{
					frmZhuoTaiQuery frm = new frmZhuoTaiQuery(tblDatas);
					frm.ShowDialog();
				}
				else
				{
					MessageBox.Show("桌台数据异常!");
				}
			}
			else
			{
				MessageBox.Show("无可划单桌台!");
			}
		}
	}
}
