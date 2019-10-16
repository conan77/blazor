namespace HuaDan
{
    partial class frmDanXiangMergeDish
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDanXiangMergeDish));
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
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.panel2 = new System.Windows.Forms.Panel();
			this.panOuter = new System.Windows.Forms.Panel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.panTunPage = new System.Windows.Forms.Panel();
			this.btnDownDetail = new System.Windows.Forms.Button();
			this.btnUpDetail = new System.Windows.Forms.Button();
			this.panBtnHuaDan = new System.Windows.Forms.Panel();
			this.btnAllHuaDan = new System.Windows.Forms.Button();
			this.btnBatchHuaDan = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.btnKeyboard = new System.Windows.Forms.Button();
			this.btnZTDish = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.grpColor.SuspendLayout();
			this.panOuter.SuspendLayout();
			this.panTunPage.SuspendLayout();
			this.panBtnHuaDan.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.panel1.Controls.Add(this.btnZTDish);
			this.panel1.Controls.Add(this.btnKeyboard);
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
			this.panel1.TabIndex = 0;
			// 
			// btnQuery
			// 
			this.btnQuery.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
			this.btnQuery.ForeColor = System.Drawing.Color.Red;
			this.btnQuery.Location = new System.Drawing.Point(160, 5);
			this.btnQuery.Margin = new System.Windows.Forms.Padding(2);
			this.btnQuery.Name = "btnQuery";
			this.btnQuery.Size = new System.Drawing.Size(70, 52);
			this.btnQuery.TabIndex = 11;
			this.btnQuery.Text = "已划";
			this.btnQuery.UseVisualStyleBackColor = true;
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			// 
			// grpColor
			// 
			this.grpColor.Controls.Add(this.label3);
			this.grpColor.Controls.Add(this.label2);
			this.grpColor.Controls.Add(this.label1);
			this.grpColor.Location = new System.Drawing.Point(397, 5);
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
			this.btnGuQing.Location = new System.Drawing.Point(316, 5);
			this.btnGuQing.Margin = new System.Windows.Forms.Padding(2);
			this.btnGuQing.Name = "btnGuQing";
			this.btnGuQing.Size = new System.Drawing.Size(70, 52);
			this.btnGuQing.TabIndex = 9;
			this.btnGuQing.Text = "沽清";
			this.btnGuQing.UseVisualStyleBackColor = true;
			this.btnGuQing.Click += new System.EventHandler(this.btnGuQing_Click);
			// 
			// txtHuaCaiNum
			// 
			this.txtHuaCaiNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtHuaCaiNum.Font = new System.Drawing.Font("宋体", 15.85714F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtHuaCaiNum.Location = new System.Drawing.Point(528, 18);
			this.txtHuaCaiNum.Margin = new System.Windows.Forms.Padding(2);
			this.txtHuaCaiNum.Name = "txtHuaCaiNum";
			this.txtHuaCaiNum.Size = new System.Drawing.Size(131, 32);
			this.txtHuaCaiNum.TabIndex = 8;
			this.txtHuaCaiNum.Click += new System.EventHandler(this.txtHuaCaiNum_Click);
			this.txtHuaCaiNum.TextChanged += new System.EventHandler(this.txtHuaCaiNum_TextChanged);
			this.txtHuaCaiNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHuaCaiNum_KeyDown);
			this.txtHuaCaiNum.Leave += new System.EventHandler(this.txtHuaCaiNum_Leave);
			// 
			// btnRefresh
			// 
			this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRefresh.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
			this.btnRefresh.ForeColor = System.Drawing.Color.Red;
			this.btnRefresh.Location = new System.Drawing.Point(700, 5);
			this.btnRefresh.Margin = new System.Windows.Forms.Padding(2);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(70, 52);
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
			this.btnSetup.Location = new System.Drawing.Point(778, 6);
			this.btnSetup.Margin = new System.Windows.Forms.Padding(2);
			this.btnSetup.Name = "btnSetup";
			this.btnSetup.Size = new System.Drawing.Size(70, 52);
			this.btnSetup.TabIndex = 6;
			this.btnSetup.Text = "设置";
			this.btnSetup.UseVisualStyleBackColor = true;
			this.btnSetup.Click += new System.EventHandler(this.btnSetup_Click);
			// 
			// btnDown
			// 
			this.btnDown.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnDown.ForeColor = System.Drawing.Color.Red;
			this.btnDown.Location = new System.Drawing.Point(82, 5);
			this.btnDown.Margin = new System.Windows.Forms.Padding(2);
			this.btnDown.Name = "btnDown";
			this.btnDown.Size = new System.Drawing.Size(70, 52);
			this.btnDown.TabIndex = 2;
			this.btnDown.Text = "下一页";
			this.btnDown.UseVisualStyleBackColor = true;
			this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
			// 
			// btnUp
			// 
			this.btnUp.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnUp.ForeColor = System.Drawing.Color.Red;
			this.btnUp.Location = new System.Drawing.Point(4, 5);
			this.btnUp.Margin = new System.Windows.Forms.Padding(2);
			this.btnUp.Name = "btnUp";
			this.btnUp.Size = new System.Drawing.Size(70, 52);
			this.btnUp.TabIndex = 1;
			this.btnUp.Text = "上一页";
			this.btnUp.UseVisualStyleBackColor = true;
			this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
			// 
			// timer1
			// 
			this.timer1.Interval = 15000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(856, 51);
			this.panel2.TabIndex = 6;
			// 
			// panOuter
			// 
			this.panOuter.BackColor = System.Drawing.Color.White;
			this.panOuter.Controls.Add(this.tableLayoutPanel2);
			this.panOuter.Controls.Add(this.panTunPage);
			this.panOuter.Controls.Add(this.panBtnHuaDan);
			this.panOuter.Dock = System.Windows.Forms.DockStyle.Right;
			this.panOuter.Location = new System.Drawing.Point(656, 51);
			this.panOuter.Name = "panOuter";
			this.panOuter.Size = new System.Drawing.Size(200, 391);
			this.panOuter.TabIndex = 7;
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
			this.tableLayoutPanel2.Size = new System.Drawing.Size(200, 299);
			this.tableLayoutPanel2.TabIndex = 2;
			// 
			// panTunPage
			// 
			this.panTunPage.BackColor = System.Drawing.Color.Gray;
			this.panTunPage.Controls.Add(this.btnDownDetail);
			this.panTunPage.Controls.Add(this.btnUpDetail);
			this.panTunPage.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panTunPage.Location = new System.Drawing.Point(0, 299);
			this.panTunPage.Name = "panTunPage";
			this.panTunPage.Size = new System.Drawing.Size(200, 46);
			this.panTunPage.TabIndex = 1;
			// 
			// btnDownDetail
			// 
			this.btnDownDetail.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnDownDetail.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnDownDetail.Location = new System.Drawing.Point(100, 0);
			this.btnDownDetail.Name = "btnDownDetail";
			this.btnDownDetail.Size = new System.Drawing.Size(100, 46);
			this.btnDownDetail.TabIndex = 1;
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
			this.btnUpDetail.Size = new System.Drawing.Size(100, 46);
			this.btnUpDetail.TabIndex = 0;
			this.btnUpDetail.Text = "上一页";
			this.btnUpDetail.UseVisualStyleBackColor = true;
			this.btnUpDetail.Click += new System.EventHandler(this.btnUpDetail_Click);
			// 
			// panBtnHuaDan
			// 
			this.panBtnHuaDan.BackColor = System.Drawing.Color.Gray;
			this.panBtnHuaDan.Controls.Add(this.btnAllHuaDan);
			this.panBtnHuaDan.Controls.Add(this.btnBatchHuaDan);
			this.panBtnHuaDan.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panBtnHuaDan.Location = new System.Drawing.Point(0, 345);
			this.panBtnHuaDan.Name = "panBtnHuaDan";
			this.panBtnHuaDan.Size = new System.Drawing.Size(200, 46);
			this.panBtnHuaDan.TabIndex = 0;
			// 
			// btnAllHuaDan
			// 
			this.btnAllHuaDan.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnAllHuaDan.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnAllHuaDan.Location = new System.Drawing.Point(100, 0);
			this.btnAllHuaDan.Name = "btnAllHuaDan";
			this.btnAllHuaDan.Size = new System.Drawing.Size(100, 46);
			this.btnAllHuaDan.TabIndex = 0;
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
			this.btnBatchHuaDan.Size = new System.Drawing.Size(100, 46);
			this.btnBatchHuaDan.TabIndex = 1;
			this.btnBatchHuaDan.Text = "划单";
			this.btnBatchHuaDan.UseVisualStyleBackColor = true;
			this.btnBatchHuaDan.Click += new System.EventHandler(this.btnBatchHuaDan_Click);
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
			this.tableLayoutPanel1.TabIndex = 8;
			// 
			// btnKeyboard
			// 
			this.btnKeyboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnKeyboard.BackgroundImage = global::HuaDan.Properties.Resources.keyboard;
			this.btnKeyboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnKeyboard.FlatAppearance.BorderSize = 0;
			this.btnKeyboard.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnKeyboard.Location = new System.Drawing.Point(663, 18);
			this.btnKeyboard.Margin = new System.Windows.Forms.Padding(2);
			this.btnKeyboard.Name = "btnKeyboard";
			this.btnKeyboard.Size = new System.Drawing.Size(31, 31);
			this.btnKeyboard.TabIndex = 12;
			this.btnKeyboard.UseVisualStyleBackColor = true;
			this.btnKeyboard.Click += new System.EventHandler(this.btnKeyboard_Click);
			// 
			// btnZTDish
			// 
			this.btnZTDish.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnZTDish.ForeColor = System.Drawing.Color.Red;
			this.btnZTDish.Location = new System.Drawing.Point(238, 5);
			this.btnZTDish.Margin = new System.Windows.Forms.Padding(2);
			this.btnZTDish.Name = "btnZTDish";
			this.btnZTDish.Size = new System.Drawing.Size(70, 52);
			this.btnZTDish.TabIndex = 13;
			this.btnZTDish.Text = "桌台";
			this.btnZTDish.UseVisualStyleBackColor = true;
			this.btnZTDish.Click += new System.EventHandler(this.btnZTDish_Click);
			// 
			// frmDanXiangMergeDish
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(856, 504);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.panOuter);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmDanXiangMergeDish";
			this.Text = "菜嬷嬷划单系统";
			this.Load += new System.EventHandler(this.frmDanXiangMergeDish_Load);
			this.SizeChanged += new System.EventHandler(this.frmDanXiangMergeDish_SizeChanged);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.grpColor.ResumeLayout(false);
			this.panOuter.ResumeLayout(false);
			this.panTunPage.ResumeLayout(false);
			this.panBtnHuaDan.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.TextBox txtHuaCaiNum;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSetup;
        private System.Windows.Forms.Button btnGuQing;
        private System.Windows.Forms.GroupBox grpColor;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panOuter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panTunPage;
        private System.Windows.Forms.Button btnDownDetail;
        private System.Windows.Forms.Button btnUpDetail;
        private System.Windows.Forms.Panel panBtnHuaDan;
        private System.Windows.Forms.Button btnAllHuaDan;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnBatchHuaDan;
        private System.Windows.Forms.Button btnQuery;
		private System.Windows.Forms.Button btnKeyboard;
		private System.Windows.Forms.Button btnZTDish;

    }
}