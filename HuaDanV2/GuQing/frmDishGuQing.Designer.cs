namespace HuaDan
{
    partial class frmDishGuQing
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnKeyboard = new System.Windows.Forms.Button();
			this.panel3 = new System.Windows.Forms.Panel();
			this.comDishType = new System.Windows.Forms.ComboBox();
			this.btnUp = new System.Windows.Forms.Button();
			this.btnDown = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.btnQuery = new System.Windows.Forms.Button();
			this.txtDishCode = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.panLine = new System.Windows.Forms.Panel();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(981, 64);
			this.panel1.TabIndex = 0;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.pictureBox1.Image = global::HuaDan.Properties.Resources.close;
			this.pictureBox1.Location = new System.Drawing.Point(916, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(53, 46);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(12, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 28);
			this.label1.TabIndex = 0;
			this.label1.Text = "品项沽清";
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.Control;
			this.panel2.Controls.Add(this.btnKeyboard);
			this.panel2.Controls.Add(this.panel3);
			this.panel2.Controls.Add(this.btnUp);
			this.panel2.Controls.Add(this.btnDown);
			this.panel2.Controls.Add(this.button1);
			this.panel2.Controls.Add(this.btnQuery);
			this.panel2.Controls.Add(this.txtDishCode);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.panLine);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 64);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(981, 60);
			this.panel2.TabIndex = 1;
			// 
			// btnKeyboard
			// 
			this.btnKeyboard.BackgroundImage = global::HuaDan.Properties.Resources.keyboard;
			this.btnKeyboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnKeyboard.FlatAppearance.BorderSize = 0;
			this.btnKeyboard.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnKeyboard.Location = new System.Drawing.Point(586, 16);
			this.btnKeyboard.Margin = new System.Windows.Forms.Padding(2);
			this.btnKeyboard.Name = "btnKeyboard";
			this.btnKeyboard.Size = new System.Drawing.Size(31, 24);
			this.btnKeyboard.TabIndex = 17;
			this.btnKeyboard.UseVisualStyleBackColor = true;
			this.btnKeyboard.Click += new System.EventHandler(this.btnKeyboard_Click);
			// 
			// panel3
			// 
			this.panel3.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel3.Controls.Add(this.comDishType);
			this.panel3.Location = new System.Drawing.Point(96, 14);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(160, 29);
			this.panel3.TabIndex = 9;
			// 
			// comDishType
			// 
			this.comDishType.Dock = System.Windows.Forms.DockStyle.Fill;
			this.comDishType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comDishType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.comDishType.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.comDishType.FormattingEnabled = true;
			this.comDishType.Location = new System.Drawing.Point(0, 0);
			this.comDishType.Name = "comDishType";
			this.comDishType.Size = new System.Drawing.Size(158, 29);
			this.comDishType.TabIndex = 2;
			this.comDishType.SelectedIndexChanged += new System.EventHandler(this.comDishType_SelectedIndexChanged);
			// 
			// btnUp
			// 
			this.btnUp.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.btnUp.BackColor = System.Drawing.Color.Gray;
			this.btnUp.FlatAppearance.BorderSize = 0;
			this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnUp.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnUp.ForeColor = System.Drawing.Color.White;
			this.btnUp.Location = new System.Drawing.Point(806, 13);
			this.btnUp.Name = "btnUp";
			this.btnUp.Size = new System.Drawing.Size(83, 33);
			this.btnUp.TabIndex = 8;
			this.btnUp.Text = "上一页";
			this.btnUp.UseVisualStyleBackColor = false;
			this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
			// 
			// btnDown
			// 
			this.btnDown.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.btnDown.BackColor = System.Drawing.Color.Gray;
			this.btnDown.FlatAppearance.BorderSize = 0;
			this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDown.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnDown.ForeColor = System.Drawing.Color.White;
			this.btnDown.Location = new System.Drawing.Point(895, 12);
			this.btnDown.Name = "btnDown";
			this.btnDown.Size = new System.Drawing.Size(83, 33);
			this.btnDown.TabIndex = 7;
			this.btnDown.Text = "下一页";
			this.btnDown.UseVisualStyleBackColor = false;
			this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
			// 
			// button1
			// 
			this.button1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.button1.BackColor = System.Drawing.Color.Gray;
			this.button1.FlatAppearance.BorderSize = 0;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.button1.ForeColor = System.Drawing.Color.White;
			this.button1.Location = new System.Drawing.Point(723, 13);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(83, 33);
			this.button1.TabIndex = 6;
			this.button1.Text = "重置";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// btnQuery
			// 
			this.btnQuery.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnQuery.BackColor = System.Drawing.Color.Orange;
			this.btnQuery.FlatAppearance.BorderSize = 0;
			this.btnQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnQuery.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnQuery.ForeColor = System.Drawing.Color.White;
			this.btnQuery.Location = new System.Drawing.Point(634, 13);
			this.btnQuery.Name = "btnQuery";
			this.btnQuery.Size = new System.Drawing.Size(83, 33);
			this.btnQuery.TabIndex = 5;
			this.btnQuery.Text = "查询";
			this.btnQuery.UseVisualStyleBackColor = false;
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			// 
			// txtDishCode
			// 
			this.txtDishCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.txtDishCode.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtDishCode.Location = new System.Drawing.Point(426, 16);
			this.txtDishCode.Multiline = true;
			this.txtDishCode.Name = "txtDishCode";
			this.txtDishCode.Size = new System.Drawing.Size(160, 27);
			this.txtDishCode.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label3.Location = new System.Drawing.Point(284, 18);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(136, 21);
			this.label3.TabIndex = 3;
			this.label3.Text = "品项名称(速查吗):";
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label2.Location = new System.Drawing.Point(12, 18);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(78, 21);
			this.label2.TabIndex = 1;
			this.label2.Text = "品项类型:";
			// 
			// panLine
			// 
			this.panLine.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.panLine.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panLine.Location = new System.Drawing.Point(0, 59);
			this.panLine.Name = "panLine";
			this.panLine.Size = new System.Drawing.Size(981, 1);
			this.panLine.TabIndex = 0;
			// 
			// tableLayoutPanel1
			// 
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
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 124);
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
			this.tableLayoutPanel1.Size = new System.Drawing.Size(981, 551);
			this.tableLayoutPanel1.TabIndex = 2;
			// 
			// frmDishGuQing
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.ClientSize = new System.Drawing.Size(981, 675);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmDishGuQing";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmDishGuQing";
			this.Load += new System.EventHandler(this.frmDishGuQing_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panLine;
        private System.Windows.Forms.ComboBox comDishType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDishCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnKeyboard;
    }
}