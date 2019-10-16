namespace HuaDan
{
    partial class frmMain
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGuQingList = new System.Windows.Forms.Button();
            this.btnGuQing = new System.Windows.Forms.Button();
            this.lblZCTip = new System.Windows.Forms.Label();
            this.btnQuery = new System.Windows.Forms.Button();
            this.grpColor = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHuaCaiNum = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSetup = new System.Windows.Forms.Button();
            this.btnHuaDan = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.grpColor.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1097, 416);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.tableLayoutPanel1_CellPaint);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnGuQingList);
            this.panel1.Controls.Add(this.btnGuQing);
            this.panel1.Controls.Add(this.lblZCTip);
            this.panel1.Controls.Add(this.btnQuery);
            this.panel1.Controls.Add(this.grpColor);
            this.panel1.Controls.Add(this.txtHuaCaiNum);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnSetup);
            this.panel1.Controls.Add(this.btnHuaDan);
            this.panel1.Controls.Add(this.btnDown);
            this.panel1.Controls.Add(this.btnUp);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Font = new System.Drawing.Font("宋体", 10.71429F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.ForeColor = System.Drawing.Color.Red;
            this.panel1.Location = new System.Drawing.Point(0, 416);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1097, 58);
            this.panel1.TabIndex = 1;
            // 
            // btnGuQingList
            // 
            this.btnGuQingList.Font = new System.Drawing.Font("宋体", 10.71429F, System.Drawing.FontStyle.Bold);
            this.btnGuQingList.ForeColor = System.Drawing.Color.Red;
            this.btnGuQingList.Location = new System.Drawing.Point(203, 3);
            this.btnGuQingList.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuQingList.Name = "btnGuQingList";
            this.btnGuQingList.Size = new System.Drawing.Size(90, 52);
            this.btnGuQingList.TabIndex = 8;
            this.btnGuQingList.Text = "沽清列表";
            this.btnGuQingList.UseVisualStyleBackColor = true;
            this.btnGuQingList.Click += new System.EventHandler(this.btnGuQingList_Click);
            // 
            // btnGuQing
            // 
            this.btnGuQing.Location = new System.Drawing.Point(392, 3);
            this.btnGuQing.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuQing.Name = "btnGuQing";
            this.btnGuQing.Size = new System.Drawing.Size(90, 52);
            this.btnGuQing.TabIndex = 8;
            this.btnGuQing.Text = "沽清";
            this.btnGuQing.UseVisualStyleBackColor = true;
            this.btnGuQing.Click += new System.EventHandler(this.btnGuQing_Click);
            // 
            // lblZCTip
            // 
            this.lblZCTip.BackColor = System.Drawing.Color.Green;
            this.lblZCTip.ForeColor = System.Drawing.Color.White;
            this.lblZCTip.Location = new System.Drawing.Point(500, 10);
            this.lblZCTip.Name = "lblZCTip";
            this.lblZCTip.Size = new System.Drawing.Size(81, 39);
            this.lblZCTip.TabIndex = 3;
            this.lblZCTip.Text = "已沽清";
            this.lblZCTip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblZCTip.Click += new System.EventHandler(this.lblZCTip_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(297, 3);
            this.btnQuery.Margin = new System.Windows.Forms.Padding(2);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(77, 52);
            this.btnQuery.TabIndex = 7;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // grpColor
            // 
            this.grpColor.Controls.Add(this.label3);
            this.grpColor.Controls.Add(this.label2);
            this.grpColor.Controls.Add(this.label1);
            this.grpColor.Location = new System.Drawing.Point(451, 3);
            this.grpColor.Name = "grpColor";
            this.grpColor.Size = new System.Drawing.Size(279, 52);
            this.grpColor.TabIndex = 6;
            this.grpColor.TabStop = false;
            this.grpColor.Visible = false;
            this.grpColor.Paint += new System.Windows.Forms.PaintEventHandler(this.grpColor_Paint);
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
            this.label3.Text = "未被抢单";
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
            this.label2.Text = "已被自己抢单";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.GrayText;
            this.label1.Font = new System.Drawing.Font("宋体", 9F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(7, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "已被他人抢单";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtHuaCaiNum
            // 
            this.txtHuaCaiNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHuaCaiNum.Font = new System.Drawing.Font("宋体", 15.85714F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtHuaCaiNum.Location = new System.Drawing.Point(735, 14);
            this.txtHuaCaiNum.Margin = new System.Windows.Forms.Padding(2);
            this.txtHuaCaiNum.Name = "txtHuaCaiNum";
            this.txtHuaCaiNum.Size = new System.Drawing.Size(159, 32);
            this.txtHuaCaiNum.TabIndex = 5;
            this.txtHuaCaiNum.Click += new System.EventHandler(this.txtHuaCaiNum_Click);
            this.txtHuaCaiNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHuaCaiNum_KeyDown);
            this.txtHuaCaiNum.Leave += new System.EventHandler(this.txtHuaCaiNum_Leave);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(905, 3);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(77, 52);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSetup
            // 
            this.btnSetup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetup.Location = new System.Drawing.Point(1000, 3);
            this.btnSetup.Margin = new System.Windows.Forms.Padding(2);
            this.btnSetup.Name = "btnSetup";
            this.btnSetup.Size = new System.Drawing.Size(77, 52);
            this.btnSetup.TabIndex = 3;
            this.btnSetup.Text = "设置";
            this.btnSetup.UseVisualStyleBackColor = true;
            this.btnSetup.Click += new System.EventHandler(this.btnSetup_Click);
            // 
            // btnHuaDan
            // 
            this.btnHuaDan.Location = new System.Drawing.Point(203, 3);
            this.btnHuaDan.Margin = new System.Windows.Forms.Padding(2);
            this.btnHuaDan.Name = "btnHuaDan";
            this.btnHuaDan.Size = new System.Drawing.Size(77, 52);
            this.btnHuaDan.TabIndex = 2;
            this.btnHuaDan.Text = "划单";
            this.btnHuaDan.UseVisualStyleBackColor = true;
            this.btnHuaDan.Click += new System.EventHandler(this.btnHuaDan_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(108, 3);
            this.btnDown.Margin = new System.Windows.Forms.Padding(2);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(77, 52);
            this.btnDown.TabIndex = 1;
            this.btnDown.Text = "下一页";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(14, 3);
            this.btnUp.Margin = new System.Windows.Forms.Padding(2);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(77, 52);
            this.btnUp.TabIndex = 0;
            this.btnUp.Text = "上一页";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1097, 416);
            this.panel2.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Interval = 15000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1097, 474);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmMain";
            this.Text = "菜嬷嬷划单系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grpColor.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnHuaDan;
        private System.Windows.Forms.Button btnSetup;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtHuaCaiNum;
        private System.Windows.Forms.GroupBox grpColor;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Button btnGuQing;
        public System.Windows.Forms.Label lblZCTip;
        private System.Windows.Forms.Button btnGuQingList;
    }
}

