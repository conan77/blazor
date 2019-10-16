using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HuaDan
{
    public partial class frmGuQing : Form
    {

        public string btnName { get; set; }
        public string DishID { get; set; }
        public string DishName { get; set; }
        public bool IsCanCancelGuQing { get; set; }

        public frmGuQing(string btnname, string dishname, string dishid, bool isCanCancelGuQing)
        {
            InitializeComponent();
            btnName = btnname;
            DishID = dishid;
            DishName = dishname;
            IsCanCancelGuQing = isCanCancelGuQing;
            if (string.IsNullOrEmpty(DishName))
                lblDishName.Text = "";
            else
                lblDishName.Text = "【品项名称：" + DishName + "】";
        }

        private void frmGuQing_Resize(object sender, EventArgs e)
        {
            //圆角
            this.Region = FormOptimization.SetWindowRegion(this.Width, this.Height);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGuQing_Load(object sender, EventArgs e)
        {
            string sqlOrderGuQing = "select * from OrderGuQing WHERE GQStartTime <= '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' AND GQEndTime >= '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' AND DishID='" + DishID + "'  ORDER By GQEndTime desc  ";
            var dtOrderGuQing = DBHelper.ExeSqlForDataTable(sqlOrderGuQing);
            if (dtOrderGuQing.Rows.Count > 0)
            {
                string GQType = dtOrderGuQing.Rows[0]["GQType"].ToString();
                SetQuQingModel(GQType);

                if (!string.IsNullOrEmpty(dtOrderGuQing.Rows[0]["DishNumber"].ToString()))
                    txtNum.Text = decimalFormatter(Convert.ToDecimal(dtOrderGuQing.Rows[0]["DishNumber"].ToString()));
            }
            else
            {
                string gqModel = Common.getSystemConfig("GuQingDefaultMode", "1");//1:按餐别 2:按天 3:长期
                SetQuQingModel(gqModel);

                txtNum.Text = "0";
                txtNum.Select();
            }

            if (IsCanCancelGuQing)
            {
                btnCancelGuQing.Enabled = true;
            }
            else
            {
                if (btnName.Equals("沽清"))
                {
                    btnCancelGuQing.Enabled = false;
                }
                else
                {
                    btnCancelGuQing.Enabled = true;
                }
            }
        }

        public string decimalFormatter(decimal value)
        {
            var result = value.ToString("F2").Replace(".00", "");
            if (result == "-0")
                result = "0";

            return result;
        }

        #region//键盘

        private void KeyMethod(int index, string content, string inputValue)
        {
            if (txtNum.Text.Trim().Length==txtNum.SelectionLength)
            {
                txtNum.Text = "";
            }
            if (content.Length <= 0)
            {
                string value = txtNum.Text.Trim();
                txtNum.Text = value + inputValue;
                txtNum.Focus();
                txtNum.Select(txtNum.TextLength, 0);
            }
            else
            {
                if (index + 1 >= content.Length)
                {
                    string value = txtNum.Text.Trim();
                    txtNum.Text = value + inputValue;
                    txtNum.Focus();
                    txtNum.Select(txtNum.TextLength, 0);
                }
                else
                {
                    string s1 = content.Substring(0, index);
                    string s2 = content.Substring(index, txtNum.Text.Trim().Length - index);
                    txtNum.Text = s1 + inputValue + s2;
                    txtNum.Focus();
                    txtNum.Select(txtNum.TextLength, 0);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            KeyMethod(txtNum.SelectionStart, txtNum.Text.Trim(), "1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KeyMethod(txtNum.SelectionStart, txtNum.Text.Trim(), "2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            KeyMethod(txtNum.SelectionStart, txtNum.Text.Trim(), "3");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            KeyMethod(txtNum.SelectionStart, txtNum.Text.Trim(), "4");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            KeyMethod(txtNum.SelectionStart, txtNum.Text.Trim(), "5");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            KeyMethod(txtNum.SelectionStart, txtNum.Text.Trim(), "6");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            KeyMethod(txtNum.SelectionStart, txtNum.Text.Trim(), "7");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            KeyMethod(txtNum.SelectionStart, txtNum.Text.Trim(), "8");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            KeyMethod(txtNum.SelectionStart, txtNum.Text.Trim(), "9");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            KeyMethod(txtNum.SelectionStart, txtNum.Text.Trim(), ".");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            KeyMethod(txtNum.SelectionStart, txtNum.Text.Trim(), "0");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string value = txtNum.Text.Trim();
            if (!string.IsNullOrEmpty(value))
            {
                txtNum.Text = value.Substring(0, value.Length - 1);
            }
            txtNum.Focus();
            txtNum.Select(txtNum.TextLength, 0);
        }
        #endregion

        private void btnAddGuQing_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comModel.Text.Trim()))
            {
                MessageBox.Show("请先选择沽清模式！");
                return;
            }

            decimal gqNum = -1;
            try
            {
                gqNum = Convert.ToDecimal(txtNum.Text.Trim());
                if (gqNum < 0)
                {
                    MessageBox.Show("沽清数量不能小于0！");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("请正确输入沽清数量!");
                txtNum.Clear();
                txtNum.Focus();
                return;
            }

            if (CommonGuQing.GuQingOpreate("沽清", DishName, DishID, ConvertQuQingModel(comModel.Text.Trim()), Convert.ToDecimal(txtNum.Text.Trim())))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("沽清失败！");
            }
        }

        private void btnCancelGuQing_Click(object sender, EventArgs e)
        {
            if (CommonGuQing.GuQingOpreate("取消沽清", DishName, DishID, ConvertQuQingModel(comModel.Text.Trim()), 0))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("取消沽清失败!");
            }
        }

        private void SetQuQingModel(string gqType)
        {
            if (gqType.Equals("1"))
            {
                comModel.Text = "按餐别";
            }
            else if (gqType.Equals("2"))
            {
                comModel.Text = "按天";
            }
            else if (gqType.Equals("3"))
            {
                comModel.Text = "长期";
            }
        }

        private string ConvertQuQingModel(string model)
        {
            string value = "1";
            if (model.Equals("按餐别"))
                value = "1";
            else if (model.Equals("按天"))
                value = "2";
            else if (model.Equals("长期"))
                value = "3";
            return value;
        }


    }
}
