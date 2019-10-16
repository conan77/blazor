using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HuaDan
{
    /// <summary>
    /// 单个沽清模式
    /// </summary>
    public partial class frmSingleGuQing : Form
    {
        public bool IsGuQing = false;
        public frmSingleGuQing(string title, string DishName, string GuQingNum)
        {
            InitializeComponent();

            lblTitleName.Text = title;
            lblDishName.Text = DishName;

            if (string.IsNullOrEmpty(GuQingNum))
            {
                chkGuQing.Text = "是否沽清";
            }
            else
            {
                chkGuQing.Text = "是否取消沽清";
            }
        }


        private void frmSingleGuQing_Load(object sender, EventArgs e)
        {
            string guQingModel = ConfigurationManager.AppSettings["guQingModel"]; //是否快速沽清
            if ("1".Equals(guQingModel) || "2".Equals(guQingModel))
            {
                chkGuQing.Visible = true;
                lblDishName.Location = new Point(32, 29);
            }
            else
            {
                chkGuQing.Visible = false;
                lblDishName.Location = new Point(32, 45);
            }
        }

        private void frmSingleGuQing_Resize(object sender, EventArgs e)
        {
            //圆角
            this.Region = FormOptimization.SetWindowRegion(this.Width, this.Height);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string zhuotaiMode = ConfigurationManager.AppSettings["zhuotaimode"];
            if (!string.IsNullOrEmpty(zhuotaiMode) && "3".Equals(zhuotaiMode))
            {
                frmZTDish frm = (frmZTDish)this.Owner;
                if (chkGuQing.Checked)
                {
                    frm.GetChildFormParam(true);
                }
                else
                {
                    frm.GetChildFormParam(false);
                }
            }
            else
            {
                frmMain frm = (frmMain)this.Owner;
                if (chkGuQing.Checked)
                {
                    frm.GetChildFormParam(true);
                }
                else
                {
                    frm.GetChildFormParam(false);
                }
            }
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string zhuotaiMode = ConfigurationManager.AppSettings["zhuotaimode"];
            if (!string.IsNullOrEmpty(zhuotaiMode) && "3".Equals(zhuotaiMode))
            {
                frmZTDish frm = (frmZTDish)this.Owner;
                if (chkGuQing.Checked)
                {
                    frm.GetChildFormParam(true);
                }
                else
                {
                    frm.GetChildFormParam(false);
                }
            }
            else
            {
                frmMain frm = (frmMain)this.Owner;
                if (chkGuQing.Checked)
                {
                    frm.GetChildFormParam(true);
                }
                else
                {
                    frm.GetChildFormParam(false);
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
