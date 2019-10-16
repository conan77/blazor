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
	public partial class MergeDishDetailControl : UserControl
	{
		public MergeDishDetailControl()
		{
			InitializeComponent();
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

		public string ZFKW
		{
			get { return lblZFKW.Text; }
			set { lblZFKW.Text = value; }
		}

		public string UID
		{
			get { return lblOrderZhuiTaiDishUID.Text; }
			set { lblOrderZhuiTaiDishUID.Text = value; }
		}

		public string WaiMai
		{
			get { return lblWaiMai.Text; }
			set { lblWaiMai.Text = value; }
		}

		public string DishStatusDesc
		{
			get { return lblDishStatusDesc.Text; }
			set { lblDishStatusDesc.Text = value; }
		}

		public string IsPackage 
		{
			get { return lblIsPackage.Text; }
			set { lblIsPackage.Text = value; }
		}

		public void Reset()
		{
			DishName = "";
			ZFKW = "";
			Time = "";
			ZhuoTaiName = "";
			UID = "";
			Count = "";
			WaiMai = "";
			BackColor = Color.Gray;
			DishStatusDesc = "";
			IsPackage = "0";
			pictureBox1.Image = null;
			pictureBox1.Visible = false;
			lblDishName.Location = new Point(4, 9);
		}

		public void TimeOutChangeImg(bool flag)
		{
			if (flag)
			{
				pictureBox1.Image = Properties.Resources.timeout;
				pictureBox1.Visible = true;
				lblDishName.Location = new Point(29, 4);
			}
			else
			{
				pictureBox1.Image = null;
				pictureBox1.Visible = false;
				lblDishName.Location = new Point(0, 4);
			}
		}

		public void ChangeBackColor(bool flag)
		{
			if (flag)
			{
				BackColor = Color.PaleVioletRed;
				lblDishName.ForeColor = Color.White;
				lblCount.ForeColor = Color.White;
				lblTime.ForeColor = Color.White;
				lblZhuoTai.ForeColor = Color.White;
			}
			else
			{
				BackColor = Color.FromArgb(255, 197, 239, 255);
				lblDishName.ForeColor = Color.Black;
				lblCount.ForeColor = Color.Black;
				lblTime.ForeColor = Color.Black;
				lblZhuoTai.ForeColor = Color.Black;
			}
		}

		#region //单击事件
		private void lblDishName_Click(object sender, EventArgs e)
		{
			this.OnClick(e);
		}

		private void lblZhuoTai_Click(object sender, EventArgs e)
		{
			this.OnClick(e);
		}

		private void lblTime_Click(object sender, EventArgs e)
		{
			this.OnClick(e);
		}

		private void lblZFKW_Click(object sender, EventArgs e)
		{
			this.OnClick(e);
		}

		private void lblCount_Click(object sender, EventArgs e)
		{
			this.OnClick(e);
		}

		private void panel1_Click(object sender, EventArgs e)
		{
			this.OnClick(e);
		}

		private void lblWaiMai_Click(object sender, EventArgs e)
		{
			this.OnClick(e);
		}

		#endregion

		#region //双击事件
		private void lblDishName_DoubleClick(object sender, EventArgs e)
		{
			this.OnDoubleClick(e);
		}

		#endregion




	}
}
