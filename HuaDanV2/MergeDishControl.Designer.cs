namespace HuaDan
{
    partial class MergeDishControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
			this.lblDishName = new System.Windows.Forms.Label();
			this.lblZhuoTaiNum = new System.Windows.Forms.Label();
			this.lblDishNum = new System.Windows.Forms.Label();
			this.lblZFKW = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.lblUnitName = new System.Windows.Forms.Label();
			this.lblDishID = new System.Windows.Forms.Label();
			this.lblKouWei = new System.Windows.Forms.Label();
			this.lblZuoFa = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// lblDishName
			// 
			this.lblDishName.AutoSize = true;
			this.lblDishName.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblDishName.Location = new System.Drawing.Point(21, 8);
			this.lblDishName.Name = "lblDishName";
			this.lblDishName.Size = new System.Drawing.Size(160, 31);
			this.lblDishName.TabIndex = 0;
			this.lblDishName.Text = "lblDishName";
			this.lblDishName.Click += new System.EventHandler(this.lblDishName_Click);
			// 
			// lblZhuoTaiNum
			// 
			this.lblZhuoTaiNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblZhuoTaiNum.AutoSize = true;
			this.lblZhuoTaiNum.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblZhuoTaiNum.Location = new System.Drawing.Point(4, 90);
			this.lblZhuoTaiNum.Name = "lblZhuoTaiNum";
			this.lblZhuoTaiNum.Size = new System.Drawing.Size(152, 19);
			this.lblZhuoTaiNum.TabIndex = 1;
			this.lblZhuoTaiNum.Text = "lblZhuoTaiNum";
			this.lblZhuoTaiNum.Click += new System.EventHandler(this.lblZhuoTaiNum_Click);
			// 
			// lblDishNum
			// 
			this.lblDishNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDishNum.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblDishNum.Location = new System.Drawing.Point(49, 80);
			this.lblDishNum.Name = "lblDishNum";
			this.lblDishNum.Size = new System.Drawing.Size(136, 30);
			this.lblDishNum.TabIndex = 2;
			this.lblDishNum.Text = "100千克";
			this.lblDishNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lblDishNum.Click += new System.EventHandler(this.lblDishNum_Click);
			// 
			// lblZFKW
			// 
			this.lblZFKW.AutoSize = true;
			this.lblZFKW.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblZFKW.Location = new System.Drawing.Point(5, 47);
			this.lblZFKW.Name = "lblZFKW";
			this.lblZFKW.Size = new System.Drawing.Size(56, 14);
			this.lblZFKW.TabIndex = 3;
			this.lblZFKW.Text = "lblZFKW";
			this.lblZFKW.Click += new System.EventHandler(this.lblZFKW_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Controls.Add(this.lblUnitName);
			this.panel1.Controls.Add(this.lblDishID);
			this.panel1.Controls.Add(this.lblKouWei);
			this.panel1.Controls.Add(this.lblZuoFa);
			this.panel1.Controls.Add(this.lblDishName);
			this.panel1.Controls.Add(this.lblZFKW);
			this.panel1.Controls.Add(this.lblZhuoTaiNum);
			this.panel1.Controls.Add(this.lblDishNum);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(180, 111);
			this.panel1.TabIndex = 4;
			this.panel1.Click += new System.EventHandler(this.panel1_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(4, 6);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(24, 28);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 8;
			this.pictureBox1.TabStop = false;
			// 
			// lblUnitName
			// 
			this.lblUnitName.AutoSize = true;
			this.lblUnitName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblUnitName.Location = new System.Drawing.Point(52, 67);
			this.lblUnitName.Name = "lblUnitName";
			this.lblUnitName.Size = new System.Drawing.Size(84, 14);
			this.lblUnitName.TabIndex = 7;
			this.lblUnitName.Text = "lblUnitName";
			this.lblUnitName.Visible = false;
			// 
			// lblDishID
			// 
			this.lblDishID.AutoSize = true;
			this.lblDishID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblDishID.Location = new System.Drawing.Point(107, 67);
			this.lblDishID.Name = "lblDishID";
			this.lblDishID.Size = new System.Drawing.Size(70, 14);
			this.lblDishID.TabIndex = 6;
			this.lblDishID.Text = "lblDishID";
			this.lblDishID.Visible = false;
			// 
			// lblKouWei
			// 
			this.lblKouWei.AutoSize = true;
			this.lblKouWei.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblKouWei.Location = new System.Drawing.Point(74, 67);
			this.lblKouWei.Name = "lblKouWei";
			this.lblKouWei.Size = new System.Drawing.Size(70, 14);
			this.lblKouWei.TabIndex = 5;
			this.lblKouWei.Text = "lblKouWei";
			this.lblKouWei.Visible = false;
			// 
			// lblZuoFa
			// 
			this.lblZuoFa.AutoSize = true;
			this.lblZuoFa.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblZuoFa.Location = new System.Drawing.Point(5, 67);
			this.lblZuoFa.Name = "lblZuoFa";
			this.lblZuoFa.Size = new System.Drawing.Size(63, 14);
			this.lblZuoFa.TabIndex = 4;
			this.lblZuoFa.Text = "lblZuoFa";
			this.lblZuoFa.Visible = false;
			// 
			// MergeDishControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.LightSkyBlue;
			this.Controls.Add(this.panel1);
			this.Margin = new System.Windows.Forms.Padding(1);
			this.Name = "MergeDishControl";
			this.Size = new System.Drawing.Size(180, 111);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDishName;
        private System.Windows.Forms.Label lblZhuoTaiNum;
        private System.Windows.Forms.Label lblDishNum;
        private System.Windows.Forms.Label lblZFKW;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDishID;
        private System.Windows.Forms.Label lblKouWei;
        private System.Windows.Forms.Label lblZuoFa;
        private System.Windows.Forms.Label lblUnitName;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
