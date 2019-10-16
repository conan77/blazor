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
    public partial class ZTDishControl : UserControl
    {
        public ZTDishControl()
        {
            InitializeComponent();
        }

        public string DishID
        {
            get { return lblDishID.Text; }
            set { lblDishID.Text = value; }
        }

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

        public string IsWaiMai
        {
            get { return lblWaiMai.Text; }
            set { lblWaiMai.Text = value; }
        }

        public string DishNum
        {
            get { return lblDishNum.Text; }
            set { lblDishNum.Text = value; }
        }

        public string DishNumContent
        {
            get { return lblDishNumContent.Text; }
            set { lblDishNumContent.Text = value; }
        }

        public string OrderZhuoTaiDishID
        {
            get { return lblOrderZTDishID.Text; }
            set { lblOrderZTDishID.Text = value; }
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

        public void Reset()
        {
            DishID = "";
            DishName = "";
            ZFKW = "";
            Time = "";
            ZhuoTaiName = "";
            DishNum = "";
            DishNumContent = "";
            OrderZhuoTaiDishID = "";
            IsWaiMai = "";
            BackColor = Color.LightSkyBlue;
        }

        public void ChangeBackColor(string name)
        {
            if (name.Equals("已沽清"))
            {
                BackColor = Color.FromArgb(250, 235, 215);
            }
            else if (name.Equals("未沽清"))
            {
                BackColor = Color.LightSkyBlue;
            }
            else if(name.Equals("已划单")){
                //BackColor = Color.FromArgb(67, 205, 128);
                //BackColor = Color.FromArgb(205, 104, 57);
                BackColor = Color.FromArgb(205, 85, 85);
            }
        }

        private void lblDishName_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        private void lblZFKW_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        private void lblWaiMai_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        private void lblDishNumContent_Click(object sender, EventArgs e)
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
    }
}
