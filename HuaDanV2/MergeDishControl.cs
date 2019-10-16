using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HuaDan
{
    public partial class MergeDishControl : UserControl
    {
        public MergeDishControl()
        {
            InitializeComponent();
        }

        public string UID { get; set; }

        public string DishName
        {
            get { return lblDishName.Text; }
            set { lblDishName.Text = value; }
        }

        public string ZFKW
        {
            get { return lblZFKW.Text; }
            set { lblZFKW.Text = value; }
        }

        public string DishNum
        {
            get { return lblDishNum.Text; }
            set { lblDishNum.Text = value; }
        }

        public string ZhuoTaiNum
        {
            get { return lblZhuoTaiNum.Text; }
            set { lblZhuoTaiNum.Text = value; }
        }

        public string DishID
        {
            get { return lblDishID.Text; }
            set { lblDishID.Text = value; }
        }

        public string ZuoFa
        {
            get { return lblZuoFa.Text; }
            set { lblZuoFa.Text = value; }
        }

        public string KouWei
        {
            get { return lblKouWei.Text; }
            set { lblKouWei.Text = value; }
        }

        public string UintName
        {
            get { return lblUnitName.Text; }
            set { lblUnitName.Text = value; }
        }

        public void Reset()
        {
            UID = "";
            DishName = "";
            ZFKW = "";
            ZhuoTaiNum = "";
            DishNum = "";
            DishID = "";
            ZuoFa = "";
            KouWei = "";
            UintName = "";
            BackColor = Color.LightSkyBlue;

            pictureBox1.Image = null;
            pictureBox1.Visible = false;
            lblDishName.Location = new Point(0, 6);
        }

        /// <summary>
        /// 改变背景颜色
        /// </summary>
        /// <param name="flag">是否选中</param>

        public void ChangeBackColor(bool flag)
        {
			if (flag)
			{
				BackColor = Color.PaleVioletRed;
				lblDishName.ForeColor = Color.White;
				lblZFKW.ForeColor = Color.White;
				lblDishNum.ForeColor = Color.White;
				lblZhuoTaiNum.ForeColor = Color.White;
			}
			else
			{
				BackColor = Color.LightSkyBlue;
				lblDishName.ForeColor = Color.Black;
				lblZFKW.ForeColor = Color.Black;
				lblDishNum.ForeColor = Color.Black;
				lblZhuoTaiNum.ForeColor = Color.Black;
			}
        }

        public void ChangeBackColorGQ(bool flag)
        {
			if (flag)
			{
				BackColor = Color.FromArgb(0, 192, 0);
				lblDishName.ForeColor = Color.White;
				lblZFKW.ForeColor = Color.White;
				lblDishNum.ForeColor = Color.White;
				lblZhuoTaiNum.ForeColor = Color.White;
			}
			else
			{
				BackColor = Color.LightSkyBlue;
				lblDishName.ForeColor = Color.Black;
				lblZFKW.ForeColor = Color.Black;
				lblDishNum.ForeColor = Color.Black;
				lblZhuoTaiNum.ForeColor = Color.Black;
			}
        }

		public void ChangeDishNumFontColor(bool flag)
		{
			if (flag)
			{
				lblDishNum.ForeColor = Color.Red;
			}
			else
			{
				lblDishNum.ForeColor = Color.Black;
			}
		}

        public void TimeOutChangeImg(bool flag)
        {
            if (flag)
            {
                pictureBox1.Image = Properties.Resources.timeout;
                pictureBox1.Visible = true;
                lblDishName.Location = new Point(25, 6);
            }
            else {
                pictureBox1.Image = null;
                pictureBox1.Visible = false;
                lblDishName.Location = new Point(0, 6);
            }
        }

        private void lblDishName_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        private void lblZhuoTaiNum_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        private void lblDishNum_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        private void lblZFKW_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }


    }
}
