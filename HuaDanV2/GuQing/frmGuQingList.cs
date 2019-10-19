using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace HuaDan
{
    public partial class frmGuQingList : Form
    {
        public DataTable resultSource = new DataTable();
        GuQingClassTmp gqClassTmp;

        public frmGuQingList()
        {
            InitializeComponent();
        }

        private void frmGuQingList_Load(object sender, EventArgs e)
        {
            if (Common.getSystemConfig("IsNeedUploadGuQingData", "0").Equals("0"))
                btnUpload.Visible = false;
            else
                btnUpload.Visible = true;

            gqClassTmp = new GuQingClassTmp();

            txtDishCode.Focus();

            Query();
        }

        public void Query()
        {
            string condition = "";

            string searchWord = txtDishCode.Text.Trim();
            if (searchWord != "")
                condition += " AND (BaseDish.QuickCode1 like '%" + searchWord + "%' OR BaseDish.DishName like '%" + searchWord + "%' OR BaseDish.DishCode like '%" + searchWord + "%')";

            string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string sql = "SELECT OrderGuQing.UID,'' as '顺序',OrderGuQing.DishID, BaseDish.DishName as '品项名称',OrderGuQing.DishNumber as '数量',CONVERT(CHAR(19), OrderGuQing.GQStartTime, 20) as '开始时间',CONVERT(CHAR(19), OrderGuQing.GQEndTime, 20) as '结束时间',SysGroupUser.TrueName as '沽清人',OrderGuQing.UpdateTime as '沽清时间', BaseDish.QuickCode1,BaseDish.DishCode FROM OrderGuQing INNER JOIN BaseDish ON OrderGuQing.DishID = BaseDish.UID "
                    + " INNER JOIN SysGroupUser ON  SysGroupUser.UID =  OrderGuQing.UpdateUser"
                    + " WHERE OrderGuQing.GQStartTime <= '" + now + "' AND OrderGuQing.GQEndTime >= '" + now + "' " + condition + " ORDER BY OrderGuQing.AddTime DESC";
            resultSource = DBHelper.ExeSqlForDataTable(sql);

            dgSource.DataSource = resultSource;

            for (int i = 0; i < dgSource.Rows.Count; i++)
            {
                dgSource.Rows[i].Cells["顺序"].Value = i + 1;
                dgSource.Rows[i].Cells["开始时间"].Value = dateFormatter(Convert.ToDateTime(dgSource.Rows[i].Cells["开始时间"].Value.ToString()));
                dgSource.Rows[i].Cells["结束时间"].Value = dateFormatter(Convert.ToDateTime(dgSource.Rows[i].Cells["结束时间"].Value.ToString()));
                dgSource.Rows[i].Cells["沽清时间"].Value = Convert.ToDateTime(dgSource.Rows[i].Cells["沽清时间"].Value.ToString()).ToString("yyyy-MM-dd HH:mm:ss");

                dgSource.Rows[i].Selected = false;
            }

            #region//隐藏多余列---内容居中显示
            dgSource.Columns["UID"].Visible = false;
            dgSource.Columns["DishID"].Visible = false;
            dgSource.Columns["QuickCode1"].Visible = false;
            dgSource.Columns["DishCode"].Visible = false;

            foreach (DataGridViewColumn item in this.dgSource.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;  //列标题 小箭头
                item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //列标题内容居中
            }
            #endregion
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            Query();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmDishGuQing frm = new frmDishGuQing();
            frm.Owner = this;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Query();
            }

            //uploadGuQingData();
        }

        public string dateFormatter(DateTime curDate)
        {
            if (curDate.ToString("yyyy-MM-dd") != (DateTime.Now.ToString("yyyy-MM-dd")))
            {
                if (curDate.ToString("HH:mm:ss") == "00:00:00")
                    return curDate.ToString("yyyy-MM-dd");
                else
                    return curDate.ToString("yyyy-MM-dd HH:mm:ss");
            }
            else
                return curDate.ToString("HH:mm:ss");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(gqClassTmp.OrderGuQingUID.Trim()))
                {
                    MessageBox.Show("请先选择要取消的记录！");
                    return;
                }

                if (DialogResult.No == MessageBox.Show("确定要删除对菜品【" + gqClassTmp.OrderGuQingName + "】的沽清记录吗？", "通讯录", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    return;
                }

                if (DBHelper.ExecuteNonQuery("DELETE FROM OrderGuQing WHERE UID='" + gqClassTmp.OrderGuQingUID.Trim() + "'"))
                {
                    gqClassTmp = new GuQingClassTmp();
                    Query();

                    //上传
                    CommonGuQing.uploadGuQingData();
                }
                else
                {
                    MessageBox.Show("取消沽清失败！");
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog("frmGuQingList btnCancel_Click 错误信息:" + ex.ToString());
            }
        }

        private void dgSource_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                    return;

                gqClassTmp.OrderGuQingUID = dgSource.Rows[e.RowIndex].Cells["UID"].Value == null ? "" : dgSource.Rows[e.RowIndex].Cells["UID"].Value.ToString();
                gqClassTmp.OrderGuQingDishID = dgSource.Rows[e.RowIndex].Cells["DishID"].Value == null ? "" : dgSource.Rows[e.RowIndex].Cells["DishID"].Value.ToString();
                gqClassTmp.OrderGuQingName = dgSource.Rows[e.RowIndex].Cells["品项名称"].Value == null ? "" : dgSource.Rows[e.RowIndex].Cells["品项名称"].Value.ToString();
            }
            catch (Exception ex)
            {
                Log.WriteLog("frmGuQingList dgSource_CellClick 错误信息:" + ex.ToString());
            }
        }

        private class GuQingClassTmp
        {
            public string OrderGuQingUID { get; set; }
            public string OrderGuQingDishID { get; set; }
            public string OrderGuQingName { get; set; }

            public GuQingClassTmp()
            {
                OrderGuQingUID = string.Empty;
                OrderGuQingDishID = string.Empty;
                OrderGuQingDishID = string.Empty;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(gqClassTmp.OrderGuQingUID))
            {
                frmGuQing frm = new frmGuQing("沽清", gqClassTmp.OrderGuQingName, gqClassTmp.OrderGuQingDishID, true);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Query();
                    CommonGuQing.uploadGuQingData();
                }
            }
            else
            {
                MessageBox.Show("请先选择要编辑的记录！");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Query();
        }

        private void btnKeyboard_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("osk.exe");
            txtDishCode.Focus();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            completeUploadGuQingDish(CommonGuQing.uploadGuQingData());
        }

        private void completeUploadGuQingDish(int result)
        {

            if (result == 1)
                MessageBox.Show("上传成功");
            else if (result == 2)
                MessageBox.Show("上传失败");
            else if (result == 3)
                MessageBox.Show("无可上传数据");
        }

    }
}
