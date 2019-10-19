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
    public partial class DishControl : UserControl
    {
        public DishControl()
        {
            InitializeComponent();
        }

        public void Reset()
        {
            DishName = "";
            Zuofa = "";
            Time = "";
            ZhuoTaiName = "";
            UID = "";
            Count = "";
            GuQingNum = "";
			DishStatusDesc = "";
            BackColor = Color.LightSkyBlue;
            lblZuofa.ForeColor = Color.Black;
            lblZuofa.BackColor = Color.LightSkyBlue;
            lblZhuoTai.ForeColor = Color.Black;
            lblZhuoTai.BackColor = Color.LightSkyBlue;

			pictureBox1.Image = null;
			pictureBox1.Visible = false;
			lblDishName.Location = new Point(0, 6);
        }

		public void TimeOutChangeImg(bool flag)
		{
			if (flag)
			{
				pictureBox1.Image = Properties.Resources.timeout;
				pictureBox1.Visible = true;
				lblDishName.Location = new Point(25, 6);
			}
			else
			{
				pictureBox1.Image = null;
				pictureBox1.Visible = false;
				lblDishName.Location = new Point(0, 6);
			}
		}

        public void ChangeFontColor(string zuofa, string color)
        {
            if (!string.IsNullOrEmpty(zuofa))
            {
                this.lblZuofa.ForeColor = System.Drawing.Color.White;
                this.lblZuofa.BackColor = System.Drawing.Color.Red;
            }
            else
            {
                if (color.Equals("LightSkyBlue"))
                {
                    lblZuofa.ForeColor = Color.Black;
                    lblZuofa.BackColor = Color.LightSkyBlue;
                }
                else if (color.Equals("Gray"))
                {
                    lblZuofa.ForeColor = Color.Black;
                    lblZuofa.BackColor = Color.Gray;
                }
                else if (color.Equals("AliceBlue"))
                {
                    lblZuofa.ForeColor = Color.Black;
                    lblZuofa.BackColor = Color.AliceBlue;
                }
                else {
                    lblZuofa.ForeColor = Color.Black;
                    lblZuofa.BackColor = Color.PaleVioletRed;
                }
            }
        }

        public void ChangeZhuoTaiFontColor(string zhuotainame, string color)
        {
            if (color.Equals("Gray"))
            {
                lblZhuoTai.ForeColor = Color.Black;
                lblZhuoTai.BackColor = Color.Gray;

				panel1.BackColor = Color.Gray;
				panel2.BackColor = Color.Gray;
				lblDishStatusDesc.BackColor = Color.Gray;
				lblCount.BackColor = Color.Gray;
				lblTime.BackColor = Color.Gray;
				lblGuQing.BackColor = Color.Gray;  
            }
			else if (color.Equals("PaleVioletRed"))
			{
				lblZhuoTai.ForeColor = Color.Black;
				lblZhuoTai.BackColor = Color.PaleVioletRed;

				panel1.BackColor = Color.PaleVioletRed;
				panel2.BackColor = Color.PaleVioletRed;
				lblDishStatusDesc.BackColor = Color.PaleVioletRed;
				lblCount.BackColor = Color.PaleVioletRed;
				lblTime.BackColor = Color.PaleVioletRed;
				lblGuQing.BackColor = Color.PaleVioletRed;
			}
			else {
				lblZhuoTai.ForeColor = Color.Black;
				lblZhuoTai.BackColor = Color.LightSkyBlue;

				panel1.BackColor = Color.LightSkyBlue;
				panel2.BackColor = Color.LightSkyBlue;
				lblDishStatusDesc.BackColor = Color.LightSkyBlue;
				lblCount.BackColor = Color.LightSkyBlue;
				lblTime.BackColor = Color.LightSkyBlue;
				lblGuQing.BackColor = Color.LightSkyBlue;
			}
        }

        public void ChangeIsWaiMaiStyle(string zuofa)
        {
            this.lblZhuoTai.ForeColor = System.Drawing.Color.White;
            this.lblZhuoTai.BackColor = System.Drawing.Color.Red;
        }

        public string DishName
        {
            get { return lblDishName.Text; }
            set { lblDishName.Text = value; }
        }

        public string Time
        {
            get { return lblTime.Text; }
            set { lblTime.Text = value; }
        }

        public string ZhuoTaiName
        {
            get { return lblZhuoTai.Text; }
            set { lblZhuoTai.Text = value; }
        }

        public string Count
        {
            get { return lblCount.Text; }
            set { lblCount.Text = value; }
        }

        public string Zuofa
        {
            get { return lblZuofa.Text; }
            set { lblZuofa.Text = value; }
        }

        public string GuQingNum
        {
            get { return lblGuQing.Text; }
            set { lblGuQing.Text = value; }
        }

		public string DishStatusDesc {
			get { return lblDishStatusDesc.Text; }
			set { lblDishStatusDesc.Text = value; }
		}

        public string UID { get; set; }

        private void lblDishName_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        private void lblTime_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        private void lblZhuoTai_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

		private void lblZuofa_Click(object sender, EventArgs e)
		{
			this.OnClick(e);
		}

		private void lblDishStatusDesc_Click(object sender, EventArgs e)
		{
			this.OnClick(e);
		}

		private void lblCount_Click(object sender, EventArgs e)
		{
			this.OnClick(e);
		}

		private void lblGuQing_Click(object sender, EventArgs e)
		{
			this.OnClick(e);
		}

		private void lblDishName_Click_1(object sender, EventArgs e)
		{
			this.OnClick(e);
		}


    }
}
