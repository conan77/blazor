using CaiMomoClient;
using HuaDan;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuaDan
{
    public partial class frmDishGuQing : Form
    {
        int TotalPageNum = 0;
        int CurrentPageNo = 0;
        public frmDishGuQing()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.Top = 0;
            this.Left = 0;
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height;
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string arrStr = button.Tag.ToString();
            if (!string.IsNullOrEmpty(arrStr))
            {
                frmGuQing frm = new frmGuQing("沽清", arrStr.Split(';')[1], arrStr.Split(';')[0],true);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();

                    CommonGuQing.uploadGuQingData();
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            CurrentPageNo = 0;
            LoadData();
        }

        private void BindDishType()
        {
            try
            {
                string sql = "select UID,TypeName from BaseDishType where IsEnable=1 and IsPackage=0 Order By PrintOrder,TypeCode";
                DataTable dt = DBHelper.ExeSqlForDataTable(sql);
                DataRow dr = dt.NewRow();
                dr["UID"] = "请选择";//这个值可以自己需要设置，但不要和已经存在ID重复，所以最好设置特殊一点
                dr["TypeName"] = "请选择";
                dt.Rows.InsertAt(dr, 0);//指定起始位置插入

                if (dt.Rows.Count > 0)
                {
                    comDishType.DataSource = dt;
                    comDishType.DisplayMember = "TypeName";
                    comDishType.ValueMember = "UID";
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog("BindDishType 错误信息:" + ex.ToString());
            }
        }

        private void frmDishGuQing_Load(object sender, EventArgs e)
        {
            BindDishType();
            comDishType.SelectedIndex = 0;

            CurrentPageNo = 0;
            LoadData();
        }

        private void LoadData()
        {
            string condition = string.Empty;
            if (!comDishType.Text.Trim().Equals("请选择"))
                condition += " AND TypeID = '" + comDishType.SelectedValue.ToString() + "' ";

            string dishCode = txtDishCode.Text.Trim();
            if (!string.IsNullOrEmpty(dishCode))
                condition += " AND (BaseDish.QuickCode1 like '%" + dishCode + "%' OR BaseDish.DishName like '%" + dishCode + "%' OR BaseDish.DishCode like '%" + dishCode + "%')";

            string sql = "SELECT BaseDish.* FROM BaseDish INNER JOIN BaseDishType ON BaseDish.TypeID = BaseDishType.UID  Where BaseDishType.IsEnable = 1 and BaseDishType.IsPackage=0 and BaseDish.IsPackage=0 AND BaseDish.IsEnable = 1 " + condition + " ORDER BY BaseDish.QuickCode1";
            var source = DBHelper.ExeSqlForDataTable(sql);
            ShowDishs(source);

        }

        public delegate void BtnRegesterEventHandler(Button btn);

        public void RedesterEventHandler(Button btn)
        {
            btn.Click += new System.EventHandler(button_Click);
        }
        private void ShowDishs(DataTable dataTable)
        {
            try
            {
                tableLayoutPanel1.Controls.Clear();

                string sqlOrderGuQing = "select * from OrderGuQing WHERE GQStartTime <= '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' AND GQEndTime >= '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'  Order By GQEndTime desc ";
                var dtOrderGuQing = DBHelper.ExeSqlForDataTable(sqlOrderGuQing);

                int wCount = this.ClientSize.Width / 173;
                int hCount = (this.ClientSize.Height - 100) / 98;

                int ctlWidth = this.ClientSize.Width / wCount;
                int ctlHeight = this.ClientSize.Height / hCount - (100 / hCount);

                tableLayoutPanel1.ColumnCount = wCount;
                tableLayoutPanel1.RowCount = hCount;

                TotalPageNum = wCount * hCount;

                int startIndex = CurrentPageNo * tableLayoutPanel1.RowCount * tableLayoutPanel1.ColumnCount;
                if (CurrentPageNo > 0)
                    btnUp.Enabled = true;
                else
                    btnUp.Enabled = false;

                int endIndex = startIndex + (tableLayoutPanel1.RowCount * tableLayoutPanel1.ColumnCount);
                if (endIndex > dataTable.Rows.Count)
                    endIndex = dataTable.Rows.Count;

                if (endIndex < dataTable.Rows.Count)
                    btnDown.Enabled = true;
                else
                    btnDown.Enabled = false;

                for (int i = startIndex; i < endIndex; i++)
                {

                    Button button = new Button();

                    string content = string.Empty;
                    var orderGQCount = dtOrderGuQing.Select("DishID='" + dataTable.Rows[i]["UID"].ToString() + "'");
                    if (orderGQCount.Count() > 0)
                    {
                        button.BackColor = Color.Teal;
                        content = ",\n(沽:" + DanJu.decimalFormatter(Convert.ToDecimal(orderGQCount[0]["DishNumber"].ToString())) + ")";
                    }
                    else
                    {
                        button.BackColor = Color.FromArgb(97, 97, 97);
                    }

                    button.Text = string.Concat(new string[]
                    {
                    dataTable.Rows[i]["DishName"].ToString(),
                    "\n(单位:",
                    dataTable.Rows[i]["UnitName"].ToString(),
                    ")\n单价:",
                    Convert.ToDouble(dataTable.Rows[i]["SalePrice"]).ToString("f2"),
                    "元"
                    +content
                    });
                    button.Tag = string.Concat(new string[]
                    {
                    dataTable.Rows[i]["UID"].ToString(),
                    ";",
                    dataTable.Rows[i]["DishName"].ToString()
                    });
                    button.Width = ctlWidth;
                    button.Height = ctlHeight;


                    button.ForeColor = Color.FromArgb(255, 255, 255);
                    button.Font = new Font("微软雅黑", 11f, button.Font.Style, button.Font.Unit);
                    //button.Click += new System.EventHandler(button_Click);

                    BtnRegesterEventHandler handler = new BtnRegesterEventHandler(RedesterEventHandler);
                    handler.BeginInvoke(button,null,null);

                    tableLayoutPanel1.Controls.Add(button);
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog("ShowDishs 错误信息:" + ex.ToString());
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            CurrentPageNo--;
            LoadData();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            CurrentPageNo++;
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comDishType.SelectedIndex = 0;
            txtDishCode.Clear();
        }

        private void btnKeyboard_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("osk.exe");
            txtDishCode.Focus();
        }

        private void comDishType_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentPageNo = 0;
            LoadData();
        }
    }
}
