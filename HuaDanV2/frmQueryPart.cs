using HuaDan.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HuaDan
{
	public partial class frmQueryPart : Form
	{
		DataTable dt = new DataTable();
		int currPage = 1;
		string FrmName = string.Empty;

		public frmQueryPart(string paramFrmName)
		{
			InitializeComponent();
			FrmName = paramFrmName;
		}

		private void frmQueryPart_Load(object sender, EventArgs e)
		{
			setOemInfo();
			dt = new DataTable();
			Clear();
			LoadHuaDanInfo();
			Init();

			try
			{
				if (!object.Equals(dgSource.Columns["UID"], null))
				{
					//隐藏列
					dgSource.Columns["UID"].Visible = false;
					dgSource.Columns["OrderZhuoTaiDishID"].Visible = false;
					dgSource.Columns["ZTUID"].Visible = false;

					//禁止点击表头排序
					for (int i = 0; i < this.dgSource.Columns.Count; i++)
					{
						this.dgSource.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
					}
				}

				dgSource.Columns[0].Width = 100;
				dgSource.Columns[2].Width = 150;//订单号
				dgSource.Columns[3].Width = 100;//桌台名称
				dgSource.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
				dgSource.Columns[4].Width = 180;//菜品名称
				dgSource.Columns[5].Width = 80; //数量
				dgSource.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				dgSource.Columns[6].Width = 80;  //单位
				dgSource.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
				dgSource.Columns[7].Width = 80;  //是否套餐
				dgSource.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
				dgSource.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
				dgSource.Columns[9].Width = 150;
				dgSource.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		public void LoadHuaDanInfo()
		{
			DateTimeModel currCB = Common.GetCurrCanBie();
			string condition = string.Empty;
			if (!string.IsNullOrEmpty(txtOrderCode.Text.Trim()))
				condition = " AND part.OrderCode like '%" + txtOrderCode.Text.Trim() + "%' ";
			if (!string.IsNullOrEmpty(txtZhuoTai.Text.Trim()))
				condition += " AND part.ZTName like '%" + txtZhuoTai.Text.Trim() + "%' ";
			if (!string.IsNullOrEmpty(txtDish.Text.Trim()))
				condition += " AND (BaseDish.DishCode LIKE '%" + txtDish.Text.Trim() + "%' "
						 + " OR BaseDish.DishName LIKE '%" + txtDish.Text.Trim() + "%' "
						 + " OR BaseDish.QuickCode1 LIKE '%" + txtDish.Text.Trim() + "%' "
						 + " OR BaseDish.BarCode = '" + txtDish.Text.Trim() + "' )";

			string sql = " select part.UID,part.OrderCode as 订单号,part.ZTName as 桌台名称,part.DishName as 品项名称,part.HuaDanNum as 数量,part.UnitName as 单位, "
					   + " case when part.IsPackage='1' then '是' else '否' end as 是否套餐, "
					   + " case when part.IsPackageDetail='1' then '是' else '否' end as 是否套餐内菜品, "
					   + " DATEADD(second,1,part.HuaDanTime) as 划单时间,part.ZTUID, part.DishUID as OrderZhuoTaiDishID "
					   + " from OrderHuaDanPart part with(nolock)  "
					   + " inner join BaseDish with(nolock) on part.DishID=BaseDish.UID "
					   + " where part.StoreID='" + Tools.CurrentUser.StoreID + "' AND part.HuaDanTime BETWEEN '" + currCB.StartTime + "' AND '" + currCB.EndTime + "' " + condition
					   + " order by part.HuaDanTime desc ";
			dt = DBHelper.ExeSqlForDataTable(sql);
		}

		public void BindDataSource()
		{
			lblPage.Text = "共1页，当前第1页";
			if (dt.Rows.Count <= 0)
			{
				dgSource.DataSource = dt;
				return;
			}

			DataTable curTable = dt.Clone();
			if (currPage == 1)
			{
				for (int i = 0; i < 10; i++)
				{
					if (i < dt.Rows.Count)
					{
						DataRow newRow = curTable.NewRow();
						curTable.Rows.Add(newRow);
						for (int j = 0; j < dt.Rows[i].ItemArray.Length; j++)
						{
							newRow[j] = dt.Rows[i][j];
						}
					}
				}
			}
			else
			{
				for (int i = (currPage - 1) * 10; i < currPage * 10; i++)
				{
					if (i < dt.Rows.Count)
					{
						DataRow newRow = curTable.NewRow();
						curTable.Rows.Add(newRow);
						for (int j = 0; j < dt.Rows[i].ItemArray.Length; j++)
						{
							newRow[j] = dt.Rows[i][j];
						}
					}
				}
			}
			dgSource.DataSource = curTable;

			lblPage.Text = "共" + (dt.Rows.Count == 0 ? "1" : Math.Ceiling((double)dt.Rows.Count / 10).ToString()) + "页，当前第" + currPage + "页";
		}

		public void Clear()
		{
			txtOrderCode.Clear();
			txtDish.Clear();
			txtZhuoTai.Clear();
		}

		public void Init()
		{
			currPage = 1;
			btnDown.Enabled = false;
			btnUp.Enabled = false;
			int totalNum = Convert.ToInt32(Math.Ceiling((double)dt.Rows.Count / 10));
			if (totalNum > 1)
				btnDown.Enabled = true;
			BindDataSource();
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
				Log.WriteLog("frmQueryPart setOemInfo():" + ex.ToString());
			}
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			Clear();
		}

		private void btnQuery_Click(object sender, EventArgs e)
		{
			LoadHuaDanInfo();
			Init();
		}

		private void btnUp_Click(object sender, EventArgs e)
		{
			int totalNum = Convert.ToInt32(Math.Ceiling((double)dt.Rows.Count / 10));
			if (totalNum == 1)
			{
				currPage = totalNum;
				btnUp.Enabled = false;
				btnDown.Enabled = false;
			}
			else if (currPage - 1 > 1)
			{
				currPage--;
				btnDown.Enabled = true;
			}
			else if ((currPage - 1 == 1) && totalNum == 1)
			{
				currPage = 1;
				btnUp.Enabled = false;
				btnDown.Enabled = false;
			}
			else if ((currPage - 1 == 1) && totalNum > 1)
			{
				currPage = 1;
				btnUp.Enabled = false;
				btnDown.Enabled = true;
			}
			BindDataSource();
		}

		private void btnDown_Click(object sender, EventArgs e)
		{
			int totalNum = Convert.ToInt32(Math.Ceiling((double)dt.Rows.Count / 10));
			if (totalNum == 1)
			{
				currPage = 1;
				btnUp.Enabled = false;
				btnDown.Enabled = false;
			}
			else if (currPage >= totalNum)
			{
				currPage = totalNum;
				btnDown.Enabled = false;
			}
			else if (currPage + 1 < totalNum)
			{
				currPage++;
				btnUp.Enabled = true;
				btnDown.Enabled = true;
			}
			else if (currPage + 1 == totalNum)
			{
				currPage++;
				btnUp.Enabled = true;
				btnDown.Enabled = false;
			}
			BindDataSource();
		}

		private void dgSource_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (e.RowIndex == -1)
					return;
				if (e.ColumnIndex == dgSource.Columns[0].Index)
				{
					string UID = dt.Rows[e.RowIndex]["UID"].ToString();
					string DishName = dt.Rows[e.RowIndex]["品项名称"].ToString();
					string IsPackage = dt.Rows[e.RowIndex]["是否套餐"].ToString();
					string IsPackageDetail = dt.Rows[e.RowIndex]["是否套餐内菜品"].ToString();
					string OrderZhuoTaiDishID = dt.Rows[e.RowIndex]["OrderZhuoTaiDishID"].ToString();

					StringBuilder builder = new StringBuilder();
					string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

					builder.Append("UPDATE OrderZhuoTaiDish SET IsHuaCai=0,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE UID='" + OrderZhuoTaiDishID + "' ").Append("\r\n")
						   .Append("UPDATE OrderPackageDishDetail SET IfHuaCai=0,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE UID='" + OrderZhuoTaiDishID + "' ").Append("\r\n");

					builder.Append("UPDATE HisOrderZhuoTaiDish SET IsHuaCai=0,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE UID='" + OrderZhuoTaiDishID + "' ").Append("\r\n")
					 .Append("UPDATE HisOrderPackageDishDetail SET IfHuaCai=0,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE UID='" + OrderZhuoTaiDishID + "' ").Append("\r\n");

					builder.Append("delete from OrderHuaDanPart where UID='" + UID + "'").Append("\r\n");

					string strSql = builder.ToString();
					bool result = DBHelper.ExecuteNonQuery(strSql);
					if (result)
					{
						LoadHuaDanInfo();
						Init();

						if (FrmName.Equals("frmDanXiangMergeDishFixed"))
						{
							frmDanXiangMergeDishFixed frm = (frmDanXiangMergeDishFixed)this.Owner;
							frm.RefreshData();
						}
					}
				}
				else if (e.ColumnIndex == dgSource.Columns[3].Index)
				{
					string ZTName = dt.Rows[e.RowIndex]["桌台名称"].ToString();
					DialogResult dr = MessageBox.Show("是否【" + ZTName + "】整桌取消划单？", "提示", MessageBoxButtons.OKCancel);
					if (dr == DialogResult.OK)
					{
						string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
						string UID = dt.Rows[e.RowIndex]["UID"].ToString();
						string OrderZhuoTaiID = dt.Rows[e.RowIndex]["ZTUID"].ToString();

						StringBuilder builder = new StringBuilder();

						builder.Append("UPDATE OrderZhuoTaiDish SET IsHuaCai=0,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE OrderZhuoTaiID='" + OrderZhuoTaiID + "' ").Append("\r\n")
							   .Append("UPDATE OrderPackageDishDetail SET IfHuaCai=0,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE OrderZhuoTaiID='" + OrderZhuoTaiID + "' ").Append("\r\n");

						builder.Append("UPDATE HisOrderZhuoTaiDish SET IsHuaCai=0,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE OrderZhuoTaiID='" + OrderZhuoTaiID + "' ").Append("\r\n")
							   .Append("UPDATE HisOrderPackageDishDetail SET IfHuaCai=0,UpdateTime='" + now + "',UpdateUser='" + Tools.CurrentUser.UID + "' WHERE OrderZhuoTaiID='" + OrderZhuoTaiID + "' ").Append("\r\n");
						
						builder.Append("delete from OrderHuaDanPart where UID='" + UID + "'").Append("\r\n");

						string strSql = builder.ToString();
						bool result = DBHelper.ExecuteNonQuery(strSql);
						if (result)
						{
							LoadHuaDanInfo();
							Init();

							if (FrmName.Equals("frmDanXiangMergeDishFixed"))
							{
								frmDanXiangMergeDishFixed frm = (frmDanXiangMergeDishFixed)this.Owner;
								frm.RefreshData();
							}

						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("取消划单失败：" + ex.ToString());
			}
		}
	}
}
