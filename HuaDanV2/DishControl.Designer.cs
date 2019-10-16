namespace HuaDan
{
    partial class DishControl
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
			this.lblZhuoTai = new System.Windows.Forms.Label();
			this.lblTime = new System.Windows.Forms.Label();
			this.lblCount = new System.Windows.Forms.Label();
			this.lblZuofa = new System.Windows.Forms.Label();
			this.lblGuQing = new System.Windows.Forms.Label();
			this.lblDishStatusDesc = new System.Windows.Forms.Label();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.lblDishName = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// lblZhuoTai
			// 
			this.lblZhuoTai.BackColor = System.Drawing.Color.LightSkyBlue;
			this.lblZhuoTai.Dock = System.Windows.Forms.DockStyle.Right;
			this.lblZhuoTai.Font = new System.Drawing.Font("宋体", 21.85714F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblZhuoTai.ForeColor = System.Drawing.Color.Black;
			this.lblZhuoTai.Location = new System.Drawing.Point(159, 0);
			this.lblZhuoTai.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblZhuoTai.Name = "lblZhuoTai";
			this.lblZhuoTai.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
			this.lblZhuoTai.Size = new System.Drawing.Size(138, 36);
			this.lblZhuoTai.TabIndex = 1;
			this.lblZhuoTai.Text = "5号台";
			this.lblZhuoTai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lblZhuoTai.Click += new System.EventHandler(this.lblZhuoTai_Click);
			// 
			// lblTime
			// 
			this.lblTime.BackColor = System.Drawing.Color.LightSkyBlue;
			this.lblTime.Dock = System.Windows.Forms.DockStyle.Left;
			this.lblTime.Font = new System.Drawing.Font("宋体", 18F);
			this.lblTime.ForeColor = System.Drawing.Color.Black;
			this.lblTime.Location = new System.Drawing.Point(0, 0);
			this.lblTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblTime.Name = "lblTime";
			this.lblTime.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
			this.lblTime.Size = new System.Drawing.Size(118, 36);
			this.lblTime.TabIndex = 2;
			this.lblTime.Text = "(12分钟)";
			this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblTime.Click += new System.EventHandler(this.lblTime_Click);
			// 
			// lblCount
			// 
			this.lblCount.BackColor = System.Drawing.Color.LightSkyBlue;
			this.lblCount.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblCount.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblCount.ForeColor = System.Drawing.Color.Black;
			this.lblCount.Location = new System.Drawing.Point(0, 0);
			this.lblCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblCount.Name = "lblCount";
			this.lblCount.Size = new System.Drawing.Size(297, 36);
			this.lblCount.TabIndex = 4;
			this.lblCount.Text = "lblCount";
			this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lblCount.Click += new System.EventHandler(this.lblCount_Click);
			// 
			// lblZuofa
			// 
			this.lblZuofa.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblZuofa.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Bold);
			this.lblZuofa.ForeColor = System.Drawing.Color.Black;
			this.lblZuofa.Location = new System.Drawing.Point(2, 54);
			this.lblZuofa.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblZuofa.Name = "lblZuofa";
			this.lblZuofa.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
			this.lblZuofa.Size = new System.Drawing.Size(293, 54);
			this.lblZuofa.TabIndex = 5;
			this.lblZuofa.Text = "lblzuofa";
			this.lblZuofa.Click += new System.EventHandler(this.lblZuofa_Click);
			// 
			// lblGuQing
			// 
			this.lblGuQing.BackColor = System.Drawing.Color.LightSkyBlue;
			this.lblGuQing.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblGuQing.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblGuQing.ForeColor = System.Drawing.Color.Red;
			this.lblGuQing.Location = new System.Drawing.Point(118, 0);
			this.lblGuQing.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblGuQing.Name = "lblGuQing";
			this.lblGuQing.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
			this.lblGuQing.Size = new System.Drawing.Size(41, 36);
			this.lblGuQing.TabIndex = 7;
			this.lblGuQing.Text = "沽";
			this.lblGuQing.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.lblGuQing.Click += new System.EventHandler(this.lblGuQing_Click);
			// 
			// lblDishStatusDesc
			// 
			this.lblDishStatusDesc.BackColor = System.Drawing.Color.LightSkyBlue;
			this.lblDishStatusDesc.Dock = System.Windows.Forms.DockStyle.Left;
			this.lblDishStatusDesc.Font = new System.Drawing.Font("宋体", 23.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblDishStatusDesc.Location = new System.Drawing.Point(0, 0);
			this.lblDishStatusDesc.Name = "lblDishStatusDesc";
			this.lblDishStatusDesc.Size = new System.Drawing.Size(175, 36);
			this.lblDishStatusDesc.TabIndex = 8;
			this.lblDishStatusDesc.Text = "lblDishStatusDesc";
			this.lblDishStatusDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblDishStatusDesc.Click += new System.EventHandler(this.lblDishStatusDesc_Click);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Controls.Add(this.lblZuofa, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 4;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(297, 180);
			this.tableLayoutPanel1.TabIndex = 9;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lblDishStatusDesc);
			this.panel1.Controls.Add(this.lblCount);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 108);
			this.panel1.Margin = new System.Windows.Forms.Padding(0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(297, 36);
			this.panel1.TabIndex = 7;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.lblGuQing);
			this.panel2.Controls.Add(this.lblTime);
			this.panel2.Controls.Add(this.lblZhuoTai);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 144);
			this.panel2.Margin = new System.Windows.Forms.Padding(0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(297, 36);
			this.panel2.TabIndex = 8;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.pictureBox1);
			this.panel3.Controls.Add(this.lblDishName);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Font = new System.Drawing.Font("微软雅黑", 26.14286F, System.Drawing.FontStyle.Bold);
			this.panel3.ForeColor = System.Drawing.Color.Black;
			this.panel3.Location = new System.Drawing.Point(3, 3);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(291, 48);
			this.panel3.TabIndex = 9;
			// 
			// lblDishName
			// 
			this.lblDishName.AutoSize = true;
			this.lblDishName.Location = new System.Drawing.Point(29, 0);
			this.lblDishName.Name = "lblDishName";
			this.lblDishName.Size = new System.Drawing.Size(245, 46);
			this.lblDishName.TabIndex = 0;
			this.lblDishName.Text = "lblDishName";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(2, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(24, 28);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 11;
			this.pictureBox1.TabStop = false;
			// 
			// DishControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.LightSkyBlue;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "DishControl";
			this.Size = new System.Drawing.Size(297, 180);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblZhuoTai;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblCount;
		private System.Windows.Forms.Label lblZuofa;
        private System.Windows.Forms.Label lblGuQing;
		private System.Windows.Forms.Label lblDishStatusDesc;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		public System.Windows.Forms.Panel panel1;
		public System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label lblDishName;
		private System.Windows.Forms.PictureBox pictureBox1;
    }
}
