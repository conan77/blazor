namespace HuaDan
{
    partial class MergeDishDetailControl
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
			this.lblZFKW = new System.Windows.Forms.Label();
			this.lblTime = new System.Windows.Forms.Label();
			this.lblZhuoTai = new System.Windows.Forms.Label();
			this.lblCount = new System.Windows.Forms.Label();
			this.lblOrderZhuiTaiDishUID = new System.Windows.Forms.Label();
			this.lblWaiMai = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lblIsPackage = new System.Windows.Forms.Label();
			this.lblDishStatusDesc = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// lblDishName
			// 
			this.lblDishName.AutoSize = true;
			this.lblDishName.Font = new System.Drawing.Font("微软雅黑", 13F);
			this.lblDishName.Location = new System.Drawing.Point(29, 4);
			this.lblDishName.Name = "lblDishName";
			this.lblDishName.Size = new System.Drawing.Size(122, 24);
			this.lblDishName.TabIndex = 0;
			this.lblDishName.Text = "lblDishName";
			this.lblDishName.Click += new System.EventHandler(this.lblDishName_Click);
			this.lblDishName.DoubleClick += new System.EventHandler(this.lblDishName_DoubleClick);
			// 
			// lblZFKW
			// 
			this.lblZFKW.AutoSize = true;
			this.lblZFKW.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblZFKW.ForeColor = System.Drawing.Color.MediumSlateBlue;
			this.lblZFKW.Location = new System.Drawing.Point(3, 32);
			this.lblZFKW.Name = "lblZFKW";
			this.lblZFKW.Size = new System.Drawing.Size(63, 14);
			this.lblZFKW.TabIndex = 4;
			this.lblZFKW.Text = "lblZFKW";
			this.lblZFKW.Click += new System.EventHandler(this.lblZFKW_Click);
			this.lblZFKW.DoubleClick += new System.EventHandler(this.lblDishName_DoubleClick);
			// 
			// lblTime
			// 
			this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblTime.ForeColor = System.Drawing.Color.Black;
			this.lblTime.Location = new System.Drawing.Point(1, 89);
			this.lblTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblTime.Name = "lblTime";
			this.lblTime.Size = new System.Drawing.Size(102, 19);
			this.lblTime.TabIndex = 5;
			this.lblTime.Text = "(12分钟)";
			this.lblTime.Click += new System.EventHandler(this.lblTime_Click);
			this.lblTime.DoubleClick += new System.EventHandler(this.lblDishName_DoubleClick);
			// 
			// lblZhuoTai
			// 
			this.lblZhuoTai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblZhuoTai.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblZhuoTai.ForeColor = System.Drawing.Color.Black;
			this.lblZhuoTai.Location = new System.Drawing.Point(109, 89);
			this.lblZhuoTai.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblZhuoTai.Name = "lblZhuoTai";
			this.lblZhuoTai.Size = new System.Drawing.Size(87, 19);
			this.lblZhuoTai.TabIndex = 6;
			this.lblZhuoTai.Text = "5号台";
			this.lblZhuoTai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lblZhuoTai.Click += new System.EventHandler(this.lblZhuoTai_Click);
			this.lblZhuoTai.DoubleClick += new System.EventHandler(this.lblDishName_DoubleClick);
			// 
			// lblCount
			// 
			this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblCount.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblCount.ForeColor = System.Drawing.Color.Black;
			this.lblCount.Location = new System.Drawing.Point(114, 57);
			this.lblCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblCount.Name = "lblCount";
			this.lblCount.Size = new System.Drawing.Size(84, 26);
			this.lblCount.TabIndex = 7;
			this.lblCount.Text = "lblCount";
			this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lblCount.Click += new System.EventHandler(this.lblCount_Click);
			this.lblCount.DoubleClick += new System.EventHandler(this.lblDishName_DoubleClick);
			// 
			// lblOrderZhuiTaiDishUID
			// 
			this.lblOrderZhuiTaiDishUID.Location = new System.Drawing.Point(5, 68);
			this.lblOrderZhuiTaiDishUID.Name = "lblOrderZhuiTaiDishUID";
			this.lblOrderZhuiTaiDishUID.Size = new System.Drawing.Size(99, 24);
			this.lblOrderZhuiTaiDishUID.TabIndex = 8;
			this.lblOrderZhuiTaiDishUID.Text = "lblOrderZhuiTaiDishUID";
			this.lblOrderZhuiTaiDishUID.Visible = false;
			// 
			// lblWaiMai
			// 
			this.lblWaiMai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblWaiMai.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblWaiMai.ForeColor = System.Drawing.Color.Red;
			this.lblWaiMai.Location = new System.Drawing.Point(3, 58);
			this.lblWaiMai.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblWaiMai.Name = "lblWaiMai";
			this.lblWaiMai.Size = new System.Drawing.Size(84, 26);
			this.lblWaiMai.TabIndex = 9;
			this.lblWaiMai.Text = "lblWaiMai";
			this.lblWaiMai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblWaiMai.Click += new System.EventHandler(this.lblWaiMai_Click);
			this.lblWaiMai.DoubleClick += new System.EventHandler(this.lblDishName_DoubleClick);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lblIsPackage);
			this.panel1.Controls.Add(this.lblDishStatusDesc);
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Controls.Add(this.lblDishName);
			this.panel1.Controls.Add(this.lblWaiMai);
			this.panel1.Controls.Add(this.lblZFKW);
			this.panel1.Controls.Add(this.lblCount);
			this.panel1.Controls.Add(this.lblOrderZhuiTaiDishUID);
			this.panel1.Controls.Add(this.lblZhuoTai);
			this.panel1.Controls.Add(this.lblTime);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(200, 111);
			this.panel1.TabIndex = 10;
			this.panel1.Click += new System.EventHandler(this.panel1_Click);
			this.panel1.DoubleClick += new System.EventHandler(this.lblDishName_DoubleClick);
			// 
			// lblIsPackage
			// 
			this.lblIsPackage.AutoSize = true;
			this.lblIsPackage.Location = new System.Drawing.Point(109, 83);
			this.lblIsPackage.Name = "lblIsPackage";
			this.lblIsPackage.Size = new System.Drawing.Size(89, 12);
			this.lblIsPackage.TabIndex = 12;
			this.lblIsPackage.Text = "是否套餐内菜品";
			this.lblIsPackage.Visible = false;
			// 
			// lblDishStatusDesc
			// 
			this.lblDishStatusDesc.AutoSize = true;
			this.lblDishStatusDesc.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblDishStatusDesc.ForeColor = System.Drawing.Color.Black;
			this.lblDishStatusDesc.Location = new System.Drawing.Point(3, 50);
			this.lblDishStatusDesc.Name = "lblDishStatusDesc";
			this.lblDishStatusDesc.Size = new System.Drawing.Size(143, 14);
			this.lblDishStatusDesc.TabIndex = 11;
			this.lblDishStatusDesc.Text = "lblDishStatusDesc";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(2, 1);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(24, 28);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 10;
			this.pictureBox1.TabStop = false;
			// 
			// MergeDishDetailControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Gray;
			this.Controls.Add(this.panel1);
			this.Margin = new System.Windows.Forms.Padding(1);
			this.Name = "MergeDishDetailControl";
			this.Size = new System.Drawing.Size(200, 111);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDishName;
        private System.Windows.Forms.Label lblZFKW;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblZhuoTai;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblOrderZhuiTaiDishUID;
        private System.Windows.Forms.Label lblWaiMai;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label lblDishStatusDesc;
		private System.Windows.Forms.Label lblIsPackage;

    }
}
