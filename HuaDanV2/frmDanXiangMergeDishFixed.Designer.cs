namespace HuaDan
{
	partial class frmDanXiangMergeDishFixed
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDanXiangMergeDishFixed));
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnQuery = new System.Windows.Forms.Button();
			this.grpColor = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btnGuQing = new System.Windows.Forms.Button();
			this.txtHuaCaiNum = new System.Windows.Forms.TextBox();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.btnSetup = new System.Windows.Forms.Button();
			this.btnDown = new System.Windows.Forms.Button();
			this.btnUp = new System.Windows.Forms.Button();
			this.panOuter = new System.Windows.Forms.Panel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panBtnHuaDan = new System.Windows.Forms.Panel();
			this.btnAllHuaDan = new System.Windows.Forms.Button();
			this.btnBatchHuaDan = new System.Windows.Forms.Button();
			this.panBtnHuaDanPart = new System.Windows.Forms.Panel();
			this.btnPartHuaDan = new System.Windows.Forms.Button();
			this.panTurnPage = new System.Windows.Forms.Panel();
			this.btnDownDetail = new System.Windows.Forms.Button();
			this.btnUpDetail = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.panel1.SuspendLayout();
			this.grpColor.SuspendLayout();
			this.panOuter.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panBtnHuaDan.SuspendLayout();
			this.panBtnHuaDanPart.SuspendLayout();
			this.panTurnPage.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(856, 51);
			this.panel2.TabIndex = 7;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.panel1.Controls.Add(this.btnQuery);
			this.panel1.Controls.Add(this.grpColor);
			this.panel1.Controls.Add(this.btnGuQing);
			this.panel1.Controls.Add(this.txtHuaCaiNum);
			this.panel1.Controls.Add(this.btnRefresh);
			this.panel1.Controls.Add(this.btnSetup);
			this.panel1.Controls.Add(this.btnDown);
			this.panel1.Controls.Add(this.btnUp);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 442);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(856, 62);
			this.panel1.TabIndex = 8;
			// 
			// btnQuery
			// 
			this.btnQuery.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnQuery.ForeColor = System.Drawing.Color.Red;
			this.btnQuery.Location = new System.Drawing.Point(191, 5);
			this.btnQuery.Margin = new System.Windows.Forms.Padding(2);
			this.btnQuery.Name = "btnQuery";
			this.btnQuery.Size = new System.Drawing.Size(77, 52);
			this.btnQuery.TabIndex = 11;
			this.btnQuery.Text = "查询";
			this.btnQuery.UseVisualStyleBackColor = true;
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			// 
			// grpColor
			// 
			this.grpColor.Controls.Add(this.label3);
			this.grpColor.Controls.Add(this.label2);
			this.grpColor.Controls.Add(this.label1);
			this.grpColor.Location = new System.Drawing.Point(375, 5);
			this.grpColor.Name = "grpColor";
			this.grpColor.Size = new System.Drawing.Size(279, 52);
			this.grpColor.TabIndex = 10;
			this.grpColor.TabStop = false;
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.LightSkyBlue;
			this.label3.Font = new System.Drawing.Font("宋体", 9F);
			this.label3.ForeColor = System.Drawing.Color.White;
			this.label3.Location = new System.Drawing.Point(190, 13);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(81, 32);
			this.label3.TabIndex = 2;
			this.label3.Text = "正常状态";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.PaleVioletRed;
			this.label2.Font = new System.Drawing.Font("宋体", 9F);
			this.label2.ForeColor = System.Drawing.Color.White;
			this.label2.Location = new System.Drawing.Point(99, 13);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(81, 32);
			this.label2.TabIndex = 1;
			this.label2.Text = "当前选中品项";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.label1.Font = new System.Drawing.Font("宋体", 9F);
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(7, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(81, 32);
			this.label1.TabIndex = 0;
			this.label1.Text = "已沽清";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// btnGuQing
			// 
			this.btnGuQing.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnGuQing.ForeColor = System.Drawing.Color.Red;
			this.btnGuQing.Location = new System.Drawing.Point(281, 5);
			this.btnGuQing.Margin = new System.Windows.Forms.Padding(2);
			this.btnGuQing.Name = "btnGuQing";
			this.btnGuQing.Size = new System.Drawing.Size(77, 52);
			this.btnGuQing.TabIndex = 9;
			this.btnGuQing.Text = "沽清";
			this.btnGuQing.UseVisualStyleBackColor = true;
			this.btnGuQing.Click += new System.EventHandler(this.btnGuQing_Click);
			// 
			// txtHuaCaiNum
			// 
			this.txtHuaCaiNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtHuaCaiNum.Font = new System.Drawing.Font("宋体", 15.85714F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtHuaCaiNum.Location = new System.Drawing.Point(503, 17);
			this.txtHuaCaiNum.Margin = new System.Windows.Forms.Padding(2);
			this.txtHuaCaiNum.Name = "txtHuaCaiNum";
			this.txtHuaCaiNum.Size = new System.Drawing.Size(159, 32);
			this.txtHuaCaiNum.TabIndex = 8;
			this.txtHuaCaiNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHuaCaiNum_KeyDown);
			// 
			// btnRefresh
			// 
			this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRefresh.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
			this.btnRefresh.ForeColor = System.Drawing.Color.Red;
			this.btnRefresh.Location = new System.Drawing.Point(673, 6);
			this.btnRefresh.Margin = new System.Windows.Forms.Padding(2);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(77, 52);
			this.btnRefresh.TabIndex = 7;
			this.btnRefresh.Text = "刷新";
			this.btnRefresh.UseVisualStyleBackColor = true;
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// btnSetup
			// 
			this.btnSetup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSetup.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
			this.btnSetup.ForeColor = System.Drawing.Color.Red;
			this.btnSetup.Location = new System.Drawing.Point(768, 6);
			this.btnSetup.Margin = new System.Windows.Forms.Padding(2);
			this.btnSetup.Name = "btnSetup";
			this.btnSetup.Size = new System.Drawing.Size(77, 52);
			this.btnSetup.TabIndex = 6;
			this.btnSetup.Text = "设置";
			this.btnSetup.UseVisualStyleBackColor = true;
			this.btnSetup.Click += new System.EventHandler(this.btnSetup_Click);
			// 
			// btnDown
			// 
			this.btnDown.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnDown.ForeColor = System.Drawing.Color.Red;
			this.btnDown.Location = new System.Drawing.Point(101, 5);
			this.btnDown.Margin = new System.Windows.Forms.Padding(2);
			this.btnDown.Name = "btnDown";
			this.btnDown.Size = new System.Drawing.Size(77, 52);
			this.btnDown.TabIndex = 2;
			this.btnDown.Text = "下一页";
			this.btnDown.UseVisualStyleBackColor = true;
			this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
			// 
			// btnUp
			// 
			this.btnUp.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnUp.ForeColor = System.Drawing.Color.Red;
			this.btnUp.Location = new System.Drawing.Point(11, 5);
			this.btnUp.Margin = new System.Windows.Forms.Padding(2);
			this.btnUp.Name = "btnUp";
			this.btnUp.Size = new System.Drawing.Size(77, 52);
			this.btnUp.TabIndex = 1;
			this.btnUp.Text = "上一页";
			this.btnUp.UseVisualStyleBackColor = true;
			this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
			// 
			// panOuter
			// 
			this.panOuter.Controls.Add(this.tableLayoutPanel2);
			this.panOuter.Controls.Add(this.panel3);
			this.panOuter.Dock = System.Windows.Forms.DockStyle.Right;
			this.panOuter.Location = new System.Drawing.Point(656, 51);
			this.panOuter.Name = "panOuter";
			this.panOuter.Size = new System.Drawing.Size(200, 391);
			this.panOuter.TabIndex = 9;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.BackColor = System.Drawing.Color.Gray;
			this.tableLayoutPanel2.ColumnCount = 1;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 10;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(200, 291);
			this.tableLayoutPanel2.TabIndex = 3;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.panBtnHuaDan);
			this.panel3.Controls.Add(this.panBtnHuaDanPart);
			this.panel3.Controls.Add(this.panTurnPage);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel3.Location = new System.Drawing.Point(0, 291);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(200, 100);
			this.panel3.TabIndex = 0;
			// 
			// panBtnHuaDan
			// 
			this.panBtnHuaDan.Controls.Add(this.btnAllHuaDan);
			this.panBtnHuaDan.Controls.Add(this.btnBatchHuaDan);
			this.panBtnHuaDan.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panBtnHuaDan.Location = new System.Drawing.Point(0, 66);
			this.panBtnHuaDan.Name = "panBtnHuaDan";
			this.panBtnHuaDan.Size = new System.Drawing.Size(200, 34);
			this.panBtnHuaDan.TabIndex = 4;
			// 
			// btnAllHuaDan
			// 
			this.btnAllHuaDan.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnAllHuaDan.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnAllHuaDan.Location = new System.Drawing.Point(100, 0);
			this.btnAllHuaDan.Name = "btnAllHuaDan";
			this.btnAllHuaDan.Size = new System.Drawing.Size(100, 34);
			this.btnAllHuaDan.TabIndex = 4;
			this.btnAllHuaDan.Text = "全部划单";
			this.btnAllHuaDan.UseVisualStyleBackColor = true;
			this.btnAllHuaDan.Click += new System.EventHandler(this.btnAllHuaDan_Click);
			// 
			// btnBatchHuaDan
			// 
			this.btnBatchHuaDan.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnBatchHuaDan.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnBatchHuaDan.Location = new System.Drawing.Point(0, 0);
			this.btnBatchHuaDan.Name = "btnBatchHuaDan";
			this.btnBatchHuaDan.Size = new System.Drawing.Size(100, 34);
			this.btnBatchHuaDan.TabIndex = 3;
			this.btnBatchHuaDan.Text = "选中划单";
			this.btnBatchHuaDan.UseVisualStyleBackColor = true;
			this.btnBatchHuaDan.Click += new System.EventHandler(this.btnBatchHuaDan_Click);
			// 
			// panBtnHuaDanPart
			// 
			this.panBtnHuaDanPart.Controls.Add(this.btnPartHuaDan);
			this.panBtnHuaDanPart.Dock = System.Windows.Forms.DockStyle.Top;
			this.panBtnHuaDanPart.Location = new System.Drawing.Point(0, 35);
			this.panBtnHuaDanPart.Name = "panBtnHuaDanPart";
			this.panBtnHuaDanPart.Size = new System.Drawing.Size(200, 31);
			this.panBtnHuaDanPart.TabIndex = 3;
			// 
			// btnPartHuaDan
			// 
			this.btnPartHuaDan.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnPartHuaDan.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnPartHuaDan.Location = new System.Drawing.Point(0, 0);
			this.btnPartHuaDan.Name = "btnPartHuaDan";
			this.btnPartHuaDan.Size = new System.Drawing.Size(200, 31);
			this.btnPartHuaDan.TabIndex = 4;
			this.btnPartHuaDan.Text = "部分划单";
			this.btnPartHuaDan.UseVisualStyleBackColor = true;
			this.btnPartHuaDan.Click += new System.EventHandler(this.btnPartHuaDan_Click);
			// 
			// panTurnPage
			// 
			this.panTurnPage.Controls.Add(this.btnDownDetail);
			this.panTurnPage.Controls.Add(this.btnUpDetail);
			this.panTurnPage.Dock = System.Windows.Forms.DockStyle.Top;
			this.panTurnPage.Location = new System.Drawing.Point(0, 0);
			this.panTurnPage.Name = "panTurnPage";
			this.panTurnPage.Size = new System.Drawing.Size(200, 35);
			this.panTurnPage.TabIndex = 1;
			// 
			// btnDownDetail
			// 
			this.btnDownDetail.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnDownDetail.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnDownDetail.Location = new System.Drawing.Point(100, 0);
			this.btnDownDetail.Name = "btnDownDetail";
			this.btnDownDetail.Size = new System.Drawing.Size(100, 35);
			this.btnDownDetail.TabIndex = 2;
			this.btnDownDetail.Text = "下一页";
			this.btnDownDetail.UseVisualStyleBackColor = true;
			this.btnDownDetail.Click += new System.EventHandler(this.btnDownDetail_Click);
			// 
			// btnUpDetail
			// 
			this.btnUpDetail.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnUpDetail.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnUpDetail.Location = new System.Drawing.Point(0, 0);
			this.btnUpDetail.Name = "btnUpDetail";
			this.btnUpDetail.Size = new System.Drawing.Size(100, 35);
			this.btnUpDetail.TabIndex = 1;
			this.btnUpDetail.Text = "上一页";
			this.btnUpDetail.UseVisualStyleBackColor = true;
			this.btnUpDetail.Click += new System.EventHandler(this.btnUpDetail_Click);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.tableLayoutPanel1.ColumnCount = 10;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 51);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 10;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(656, 391);
			this.tableLayoutPanel1.TabIndex = 10;
			// 
			// timer1
			// 
			this.timer1.Interval = 15000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// frmDanXiangMergeDishFixed
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(856, 504);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.panOuter);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel2);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmDanXiangMergeDishFixed";
			this.Text = "菜嬷嬷划单系统";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmDanXiangMergeDishFixed_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.grpColor.ResumeLayout(false);
			this.panOuter.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panBtnHuaDan.ResumeLayout(false);
			this.panBtnHuaDanPart.ResumeLayout(false);
			this.panTurnPage.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnQuery;
		private System.Windows.Forms.GroupBox grpColor;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnGuQing;
		private System.Windows.Forms.TextBox txtHuaCaiNum;
		private System.Windows.Forms.Button btnRefresh;
		private System.Windows.Forms.Button btnSetup;
		private System.Windows.Forms.Button btnDown;
		private System.Windows.Forms.Button btnUp;
		private System.Windows.Forms.Panel panOuter;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Panel panBtnHuaDan;
		private System.Windows.Forms.Panel panBtnHuaDanPart;
		private System.Windows.Forms.Panel panTurnPage;
		private System.Windows.Forms.Button btnUpDetail;
		private System.Windows.Forms.Button btnDownDetail;
		private System.Windows.Forms.Button btnAllHuaDan;
		private System.Windows.Forms.Button btnBatchHuaDan;
		private System.Windows.Forms.Button btnPartHuaDan;
	}
}