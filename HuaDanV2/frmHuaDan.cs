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
    public partial class frmHuaDan : Form
    {
        public frmHuaDan(string dishName, string GuQingNum)
        {
            InitializeComponent();

            lblDishName.Text = dishName;

            if (string.IsNullOrEmpty(GuQingNum))
                chkGuQing.Text = "是否沽清";
            else
                chkGuQing.Text = "是否取消沽清";
        }

        public string result { get; set; } //0:取消抢单 1：确认划单 2：关闭弹出窗体

        private void btnCancelQiangDan_Click(object sender, EventArgs e)
        {
            result = "0";
            frmMain frm = (frmMain)this.Owner;
            frm.GetChildFormParam(chkGuQing.Checked);
            this.DialogResult = DialogResult.OK;
        }

        private void btnHuaDanOK_Click(object sender, EventArgs e)
        {
            result = "1";
            frmMain frm = (frmMain)this.Owner;
            frm.GetChildFormParam(chkGuQing.Checked);
            this.DialogResult = DialogResult.OK;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            result = "2";
            this.DialogResult = DialogResult.OK;
        }

        private void frmHuaDan_Resize(object sender, EventArgs e)
        {
            //圆角
            this.Region = FormOptimization.SetWindowRegion(this.Width, this.Height);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            result = "2";
            this.DialogResult = DialogResult.OK;
        }

        private void frmHuaDan_Load(object sender, EventArgs e)
        {
            string guQingModel = ConfigurationManager.AppSettings["guQingModel"]; //是否快速沽清
            if ("1".Equals(guQingModel) || "2".Equals(guQingModel))
            {
                chkGuQing.Visible = true;
            }
            else
            {
                chkGuQing.Visible = false;
            }
        }

    }
}
