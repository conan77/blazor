using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HuaDan.TipForm
{
    public partial class frmTip : Form
    {
        public frmTip(string content)
        {
            InitializeComponent();

            lblDishName.Text = content;
        }

        private void btnAddGuQing_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void frmTip_Resize(object sender, EventArgs e)
        {
            //圆角
            this.Region = FormOptimization.SetWindowRegion(this.Width, this.Height);
        }
    }
}
