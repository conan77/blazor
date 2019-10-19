namespace HuaDan
{
    partial class ZTDishControl
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
			this.lblWaiMai = new System.Windows.Forms.Label();
			this.lblZhuoTai = new System.Windows.Forms.Label();
			this.lblTime = new System.Windows.Forms.Label();
			this.lblOrderZTDishID = new System.Windows.Forms.Label();
			this.lblDishID = new System.Windows.Forms.Label();
			this.lblDishNum = new System.Windows.Forms.Label();
			this.lblDishNumContent = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblDishName
			// 
			this.lblDishName.AutoSize = true;
			this.lblDishName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblDishName.Location = new System.Drawing.Point(4, 4);
			this.lblDishName.Name = "lblDishName";
			this.lblDishName.Size = new System.Drawing.Size(107, 21);
			this.lblDishName.TabIndex = 0;
			this.lblDishName.Text = "lblDishName";
			this.lblDishName.Click += new System.EventHandler(this.lblDishName_Click);
			// 
			// lblZFKW
			// 
			this.lblZFKW.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lblZFKW.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblZFKW.Location = new System.Drawing.Point(4, 32);
			this.lblZFKW.Name = "lblZFKW";
			this.lblZFKW.Size = new System.Drawing.Size(196, 25);
			this.lblZFKW.TabIndex = 1;
			this.lblZFKW.Text = "lblZFKW";
			this.lblZFKW.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblZFKW.Click += new System.EventHandler(this.lblZFKW_Click);
			// 
			// lblWaiMai
			// 
			this.lblWaiMai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblWaiMai.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblWaiMai.ForeColor = System.Drawing.Color.Red;
			this.lblWaiMai.Location = new System.Drawing.Point(4, 60);
			this.lblWaiMai.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblWaiMai.Name = "lblWaiMai";
			this.lblWaiMai.Size = new System.Drawing.Size(86, 25);
			this.lblWaiMai.TabIndex = 10;
			this.lblWaiMai.Text = "lblWaiMai";
			this.lblWaiMai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblWaiMai.Click += new System.EventHandler(this.lblWaiMai_Click);
			// 
			// lblZhuoTai
			// 
			this.lblZhuoTai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblZhuoTai.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblZhuoTai.ForeColor = System.Drawing.Color.Black;
			this.lblZhuoTai.Location = new System.Drawing.Point(111, 88);
			this.lblZhuoTai.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblZhuoTai.Name = "lblZhuoTai";
			this.lblZhuoTai.Size = new System.Drawing.Size(87, 19);
			this.lblZhuoTai.TabIndex = 13;
			this.lblZhuoTai.Text = "5号台";
			this.lblZhuoTai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lblZhuoTai.Click += new System.EventHandler(this.lblZhuoTai_Click);
			// 
			// lblTime
			// 
			this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblTime.ForeColor = System.Drawing.Color.Black;
			this.lblTime.Location = new System.Drawing.Point(3, 88);
			this.lblTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblTime.Name = "lblTime";
			this.lblTime.Size = new System.Drawing.Size(102, 19);
			this.lblTime.TabIndex = 12;
			this.lblTime.Text = "(12分钟)";
			this.lblTime.Click += new System.EventHandler(this.lblTime_Click);
			// 
			// lblOrderZTDishID
			// 
			this.lblOrderZTDishID.AutoSize = true;
			this.lblOrderZTDishID.Location = new System.Drawing.Point(145, 4);
			this.lblOrderZTDishID.Name = "lblOrderZTDishID";
			this.lblOrderZTDishID.Size = new System.Drawing.Size(101, 12);
			this.lblOrderZTDishID.TabIndex = 14;
			this.lblOrderZTDishID.Text = "lblOrderZTDishID";
			this.lblOrderZTDishID.Visible = false;
			// 
			// lblDishID
			// 
			this.lblDishID.AutoSize = true;
			this.lblDishID.Location = new System.Drawing.Point(147, 20);
			this.lblDishID.Name = "lblDishID";
			this.lblDishID.Size = new System.Drawing.Size(59, 12);
			this.lblDishID.TabIndex = 15;
			this.lblDishID.Text = "lblDishID";
			this.lblDishID.Visible = false;
			// 
			// lblDishNum
			// 
			this.lblDishNum.AutoSize = true;
			this.lblDishNum.Location = new System.Drawing.Point(145, 32);
			this.lblDishNum.Name = "lblDishNum";
			this.lblDishNum.Size = new System.Drawing.Size(65, 12);
			this.lblDishNum.TabIndex = 16;
			this.lblDishNum.Text = "lblDishNum";
			this.lblDishNum.Visible = false;
			// 
			// lblDishNumContent
			// 
			this.lblDishNumContent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDishNumContent.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblDishNumContent.ForeColor = System.Drawing.Color.Black;
			this.lblDishNumContent.Location = new System.Drawing.Point(95, 60);
			this.lblDishNumContent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblDishNumContent.Name = "lblDishNumContent";
			this.lblDishNumContent.Size = new System.Drawing.Size(105, 25);
			this.lblDishNumContent.TabIndex = 17;
			this.lblDishNumContent.Text = "lblDishNumContent";
			this.lblDishNumContent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lblDishNumContent.Click += new System.EventHandler(this.lblDishNumContent_Click);
			// 
			// ZTDishControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.LightSkyBlue;
			this.Controls.Add(this.lblDishNumContent);
			this.Controls.Add(this.lblDishNum);
			this.Controls.Add(this.lblDishID);
			this.Controls.Add(this.lblOrderZTDishID);
			this.Controls.Add(this.lblZhuoTai);
			this.Controls.Add(this.lblTime);
			this.Controls.Add(this.lblWaiMai);
			this.Controls.Add(this.lblZFKW);
			this.Controls.Add(this.lblDishName);
			this.Name = "ZTDishControl";
			this.Size = new System.Drawing.Size(200, 111);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDishName;
        private System.Windows.Forms.Label lblZFKW;
        private System.Windows.Forms.Label lblWaiMai;
        private System.Windows.Forms.Label lblZhuoTai;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblOrderZTDishID;
        private System.Windows.Forms.Label lblDishID;
        private System.Windows.Forms.Label lblDishNum;
		private System.Windows.Forms.Label lblDishNumContent;
    }
}
