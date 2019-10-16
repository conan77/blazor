namespace HuaDan
{
    partial class frmMainNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainNew));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnGuQing = new System.Windows.Forms.Button();
            this.btnHuaDan = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtHuaCaiNum = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSetup = new System.Windows.Forms.Button();
            this.lblZCTip = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnGuQing);
            this.panel1.Controls.Add(this.btnQuery);
            this.panel1.Controls.Add(this.lblZCTip);
            this.panel1.Controls.Add(this.txtHuaCaiNum);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnSetup);
            this.panel1.Controls.Add(this.btnHuaDan);
            this.panel1.Controls.Add(this.btnDown);
            this.panel1.Controls.Add(this.btnUp);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 450);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(925, 65);
            this.panel1.TabIndex = 0;
            // 
            // btnQuery
            // 
            this.btnQuery.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuery.ForeColor = System.Drawing.Color.Red;
            this.btnQuery.Location = new System.Drawing.Point(272, 6);
            this.btnQuery.Margin = new System.Windows.Forms.Padding(2);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(77, 52);
            this.btnQuery.TabIndex = 5;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnGuQing
            // 
            this.btnGuQing.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnGuQing.ForeColor = System.Drawing.Color.Red;
            this.btnGuQing.Location = new System.Drawing.Point(362, 6);
            this.btnGuQing.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuQing.Name = "btnGuQing";
            this.btnGuQing.Size = new System.Drawing.Size(77, 52);
            this.btnGuQing.TabIndex = 4;
            this.btnGuQing.Text = "沽清";
            this.btnGuQing.UseVisualStyleBackColor = true;
            this.btnGuQing.Click += new System.EventHandler(this.btnGuQing_Click);
            // 
            // btnHuaDan
            // 
            this.btnHuaDan.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnHuaDan.ForeColor = System.Drawing.Color.Red;
            this.btnHuaDan.Location = new System.Drawing.Point(182, 6);
            this.btnHuaDan.Margin = new System.Windows.Forms.Padding(2);
            this.btnHuaDan.Name = "btnHuaDan";
            this.btnHuaDan.Size = new System.Drawing.Size(77, 52);
            this.btnHuaDan.TabIndex = 3;
            this.btnHuaDan.Text = "划单";
            this.btnHuaDan.UseVisualStyleBackColor = true;
            this.btnHuaDan.Click += new System.EventHandler(this.btnHuaDan_Click);
            // 
            // btnDown
            // 
            this.btnDown.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDown.ForeColor = System.Drawing.Color.Red;
            this.btnDown.Location = new System.Drawing.Point(92, 6);
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
            this.btnUp.Location = new System.Drawing.Point(2, 6);
            this.btnUp.Margin = new System.Windows.Forms.Padding(2);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(77, 52);
            this.btnUp.TabIndex = 1;
            this.btnUp.Text = "上一页";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 450F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(925, 450);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // txtHuaCaiNum
            // 
            this.txtHuaCaiNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHuaCaiNum.Font = new System.Drawing.Font("宋体", 15.85714F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtHuaCaiNum.Location = new System.Drawing.Point(582, 18);
            this.txtHuaCaiNum.Margin = new System.Windows.Forms.Padding(2);
            this.txtHuaCaiNum.Name = "txtHuaCaiNum";
            this.txtHuaCaiNum.Size = new System.Drawing.Size(159, 32);
            this.txtHuaCaiNum.TabIndex = 8;
            this.txtHuaCaiNum.Click += new System.EventHandler(this.txtHuaCaiNum_Click);
            this.txtHuaCaiNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHuaCaiNum_KeyDown);
            this.txtHuaCaiNum.Leave += new System.EventHandler(this.txtHuaCaiNum_Leave);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRefresh.ForeColor = System.Drawing.Color.Red;
            this.btnRefresh.Location = new System.Drawing.Point(755, 7);
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
            this.btnSetup.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSetup.ForeColor = System.Drawing.Color.Red;
            this.btnSetup.Location = new System.Drawing.Point(844, 6);
            this.btnSetup.Margin = new System.Windows.Forms.Padding(2);
            this.btnSetup.Name = "btnSetup";
            this.btnSetup.Size = new System.Drawing.Size(77, 52);
            this.btnSetup.TabIndex = 6;
            this.btnSetup.Text = "设置";
            this.btnSetup.UseVisualStyleBackColor = true;
            this.btnSetup.Click += new System.EventHandler(this.btnSetup_Click);
            // 
            // lblZCTip
            // 
            this.lblZCTip.BackColor = System.Drawing.Color.Green;
            this.lblZCTip.ForeColor = System.Drawing.Color.White;
            this.lblZCTip.Location = new System.Drawing.Point(452, 6);
            this.lblZCTip.Name = "lblZCTip";
            this.lblZCTip.Size = new System.Drawing.Size(77, 52);
            this.lblZCTip.TabIndex = 9;
            this.lblZCTip.Text = "已沽清";
            this.lblZCTip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblZCTip.Click += new System.EventHandler(this.lblZCTip_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 15000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmMainNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 515);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMainNew";
            this.Text = "菜嬷嬷划单系统";
            this.Load += new System.EventHandler(this.frmMainNew_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Button btnGuQing;
        private System.Windows.Forms.Button btnHuaDan;
        private System.Windows.Forms.TextBox txtHuaCaiNum;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSetup;
        public System.Windows.Forms.Label lblZCTip;
        private System.Windows.Forms.Timer timer1;
    }
}