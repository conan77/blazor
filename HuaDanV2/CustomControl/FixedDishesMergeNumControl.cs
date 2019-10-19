using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace HuaDan.CustomControl
{
	public partial class FixedDishesMergeNumControl : UserControl
	{
		public FixedDishesMergeNumControl()
		{
			InitializeComponent();
		}

		public string DishName
		{
			get { return lblDishName.Text; }
			set { lblDishName.Text = value; }
		}

		public string DishNum
		{
			get { return lblDishNum.Text; }
			set { lblDishNum.Text = value; }
		}

		public string UnitName { get; set; }

		public void Reset()
		{
			DishName = "";
			DishNum = "";
			UnitName = "";
		}

		public void ChangFontColor(Color color, Color colorNum, bool isPaging)
		{
			lblDishName.ForeColor = color;
			lblDishNum.ForeColor = colorNum;
			if (isPaging)
				lblDishNum.TextAlign = ContentAlignment.TopCenter;
			else
				lblDishNum.TextAlign = ContentAlignment.MiddleCenter;
		}

		public void ChangeBackColor(Color color)
		{
			lblDishName.BackColor = color;
			lblDishNum.BackColor = color;
			this.BorderStyle = BorderStyle.None;
		}

		private void lblDishName_Click(object sender, EventArgs e)
		{
			this.OnClick(e);
		}

		private void lblDishNum_Click(object sender, EventArgs e)
		{
			this.OnClick(e);
		}

		private void lblDishName_Paint(object sender, PaintEventArgs e)
		{
			//e.Graphics.DrawLine(Pens.Black, new Point(1, this.lblDishName.Height - 1), new Point(this.lblDishName.Width, this.lblDishName.Height - 1));
		}


	}
}
