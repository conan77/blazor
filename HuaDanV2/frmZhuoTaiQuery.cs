using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace HuaDan
{
	public partial class frmZhuoTaiQuery : Form
	{
		int ZTCurrentPageNo = 0;
		int DishCurrentPageNo = 0;
		private string paramZTUID = string.Empty;

		private delegate void ControlRegesterEventHandler(Control ctl);
		private delegate void BtnRegesterEventHandler(Button btn);

		DataTable dataTable = new DataTable();

		ZTDishControl[] ZTDishControls;
		int leftTableLayoutPaneHeight = 1;
		int leftTableLayoutPaneWidth = 1;
		int rightTableLayoutPaneHeight = 1;
		int rightTableLayoutPaneWidth = 1;

		public frmZhuoTaiQuery(DataTable paramDt)
		{
			InitializeComponent();

			dataTable = paramDt;

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

				//ControlRegesterEventHandler handler = new ControlRegesterEventHandler(CTLRegesterEventHandler);
				//handler.BeginInvoke(ZTDishControls[i], null, null);
				tableLayoutPanel2.Controls.Add(ZTDishControls[i]);
			}
		}

		private void frmZhuoTaiQuery_Load(object sender, EventArgs e)
		{
			ShowZhuoTai();
			if (dataTable.Rows.Count > 0)
			{
				paramZTUID = dataTable.Rows[0]["ZTUID"].ToString();
				LoadAllZhuoTaiDish();
				ChongZhiButton();
			}
		}

		private void ShowZhuoTai()
		{
			//显示桌台
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
                    dataTable.Rows[i]["ZTUID"].ToString() 
                    });

					button.Name = "btn_" + dataTable.Rows[i]["ZTUID"].ToString();

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
				Log.WriteLog("frmZhuoTaiQuery ShowZhuoTai 错误信息:" + ex.ToString());
			}
		}

		public void RedesterEventHandler(Button btn)
		{
			btn.Click += new System.EventHandler(button_Click);
		}

		private void button_Click(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			string ZTUID = button.Tag.ToString();
			paramZTUID = ZTUID;
			LoadAllZhuoTaiDish();
			ChongZhiButton();
		}

		private void CTLRegesterEventHandler(Control ctl)
		{
			ctl.Click += new System.EventHandler(ZTDishControl_Click);
		}

		private void ZTDishControl_Click(object sender, EventArgs e)
		{

		}

		private void LoadAllZhuoTaiDish()
		{
			try
			{
				string sql = "SELECT dish.IsHuaCai,info.IsWaiMai,zt.UID,zt.ZhuoTaiName,zt.AddTime,dish.UID as OrderZhuoTaiDishID,dish.DishID,dish.DishName,(dish.DishNum+dish.DishZengSongNum) as DishNum,dish.UnitName,dish.ZuoFaNames,dish.KouWeiNames,ISNULL(dish.SongDanTime,dish.AddTime) as SongDanTime,dish.DishStatusDesc "
						   + " FROM OrderZhuoTai zt with(nolock) INNER JOIN OrderInfo info with(nolock) on info.UID=zt.OrderID INNER JOIN  OrderZhuoTaiDish dish with(nolock) on  zt.UID=dish.OrderZhuoTaiID WHERE zt.UID='" + paramZTUID + "'";
				DataTable dt = DBHelper.ExeSqlForDataTable(sql);
				if (dt.Rows.Count <= 0)
				{
					sql = "SELECT dish.IsHuaCai,info.IsWaiMai,zt.UID,zt.ZhuoTaiName,zt.AddTime,dish.UID as OrderZhuoTaiDishID,dish.DishID,dish.DishName,(dish.DishNum+dish.DishZengSongNum) as DishNum,dish.UnitName,dish.ZuoFaNames,dish.KouWeiNames,ISNULL(dish.SongDanTime,dish.AddTime) as SongDanTime,dish.DishStatusDesc "
						+ " FROM HisOrderZhuoTai zt with(nolock)  INNER JOIN HisOrderInfo info with(nolock) on info.UID=zt.OrderID  INNER JOIN HisOrderZhuoTaiDish dish with(nolock) on  zt.UID=dish.OrderZhuoTaiID WHERE zt.UID='" + paramZTUID + "'";
					dt = DBHelper.ExeSqlForDataTable(sql);
					if (dt.Rows.Count <= 0)
					{
						MessageBox.Show("未找到该桌台对应的菜品!");
						return;
					}
				}

				ShowZhuoTaiDish(dt);
			}
			catch (Exception ex)
			{
				Log.WriteLog("frmZhuoTaiQuery GetAllDishByZTUID 错误信息:" + ex.ToString());
				MessageBox.Show("获取桌台菜品失败!");
			}
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

		private void btnZTUp_Click(object sender, EventArgs e)
		{
			ZTCurrentPageNo--;
			ShowZhuoTai();
		}

		private void btnZTDown_Click(object sender, EventArgs e)
		{
			ZTCurrentPageNo++;
			ShowZhuoTai();
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

					if (!string.IsNullOrEmpty(paramZTUID) && paramZTUID.Equals(ctl.Tag.ToString()))
					{
						btn = ctl as Button;
						btn.BackColor = Color.FromArgb(255, 102, 0);
					}
				}
			}
		}
	}
}
