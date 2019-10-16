namespace HuaDan
{
	partial class frmQueryPart
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQueryPart));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtZhuoTai = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.btnClear = new System.Windows.Forms.Button();
			this.txtDish = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnQuery = new System.Windows.Forms.Button();
			this.txtOrderCode = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btnDown = new System.Windows.Forms.Button();
			this.btnUp = new System.Windows.Forms.Button();
			this.lblPage = new System.Windows.Forms.Label();
			this.dgSource = new System.Windows.Forms.DataGridView();
			this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgSource)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.txtZhuoTai);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.btnClear);
			this.groupBox1.Controls.Add(this.txtDish);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.btnQuery);
			this.groupBox1.Controls.Add(this.txtOrderCode);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(959, 47);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI Symbol", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.InfoText;
			this.label1.Location = new System.Drawing.Point(9, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 19);
			this.label1.TabIndex = 10;
			this.label1.Text = "订单号：";
			// 
			// txtZhuoTai
			// 
			this.txtZhuoTai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
			this.txtZhuoTai.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtZhuoTai.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtZhuoTai.Location = new System.Drawing.Point(532, 16);
			this.txtZhuoTai.Name = "txtZhuoTai";
			this.txtZhuoTai.Size = new System.Drawing.Size(150, 22);
			this.txtZhuoTai.TabIndex = 9;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Segoe UI Symbol", 10.5F);
			this.label4.ForeColor = System.Drawing.SystemColors.InfoText;
			this.label4.Location = new System.Drawing.Point(478, 18);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(51, 19);
			this.label4.TabIndex = 8;
			this.label4.Text = "桌台：";
			// 
			// btnClear
			// 
			this.btnClear.BackColor = System.Drawing.Color.Gray;
			this.btnClear.FlatAppearance.BorderSize = 0;
			this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnClear.ForeColor = System.Drawing.Color.White;
			this.btnClear.Location = new System.Drawing.Point(869, 12);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(75, 30);
			this.btnClear.TabIndex = 7;
			this.btnClear.Text = "清空";
			this.btnClear.UseVisualStyleBackColor = false;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// txtDish
			// 
			this.txtDish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
			this.txtDish.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtDish.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtDish.Location = new System.Drawing.Point(302, 16);
			this.txtDish.Name = "txtDish";
			this.txtDish.Size = new System.Drawing.Size(150, 22);
			this.txtDish.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Segoe UI Symbol", 10.5F);
			this.label2.ForeColor = System.Drawing.SystemColors.InfoText;
			this.label2.Location = new System.Drawing.Point(247, 18);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(51, 19);
			this.label2.TabIndex = 3;
			this.label2.Text = "菜品：";
			// 
			// btnQuery
			// 
			this.btnQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(101)))), ((int)(((byte)(26)))));
			this.btnQuery.FlatAppearance.BorderSize = 0;
			this.btnQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnQuery.ForeColor = System.Drawing.Color.White;
			this.btnQuery.Location = new System.Drawing.Point(788, 12);
			this.btnQuery.Name = "btnQuery";
			this.btnQuery.Size = new System.Drawing.Size(75, 30);
			this.btnQuery.TabIndex = 2;
			this.btnQuery.Text = "查询";
			this.btnQuery.UseVisualStyleBackColor = false;
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			// 
			// txtOrderCode
			// 
			this.txtOrderCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
			this.txtOrderCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtOrderCode.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtOrderCode.Location = new System.Drawing.Point(78, 16);
			this.txtOrderCode.Name = "txtOrderCode";
			this.txtOrderCode.Size = new System.Drawing.Size(150, 23);
			this.txtOrderCode.TabIndex = 1;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btnDown);
			this.groupBox2.Controls.Add(this.btnUp);
			this.groupBox2.Controls.Add(this.lblPage);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.groupBox2.Location = new System.Drawing.Point(0, 489);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(959, 43);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			// 
			// btnDown
			// 
			this.btnDown.Location = new System.Drawing.Point(867, 5);
			this.btnDown.Name = "btnDown";
			this.btnDown.Size = new System.Drawing.Size(75, 34);
			this.btnDown.TabIndex = 6;
			this.btnDown.Text = "下一页";
			this.btnDown.UseVisualStyleBackColor = true;
			this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
			// 
			// btnUp
			// 
			this.btnUp.Location = new System.Drawing.Point(786, 5);
			this.btnUp.Name = "btnUp";
			this.btnUp.Size = new System.Drawing.Size(75, 34);
			this.btnUp.TabIndex = 5;
			this.btnUp.Text = "上一页";
			this.btnUp.UseVisualStyleBackColor = true;
			this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
			// 
			// lblPage
			// 
			this.lblPage.AutoSize = true;
			this.lblPage.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblPage.Location = new System.Drawing.Point(14, 15);
			this.lblPage.Name = "lblPage";
			this.lblPage.Size = new System.Drawing.Size(21, 14);
			this.lblPage.TabIndex = 0;
			this.lblPage.Text = "共";
			// 
			// dgSource
			// 
			this.dgSource.AllowUserToAddRows = false;
			this.dgSource.AllowUserToDeleteRows = false;
			this.dgSource.BackgroundColor = System.Drawing.Color.White;
			this.dgSource.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.Honeydew;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgSource.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dgSource.ColumnHeadersHeight = 40;
			this.dgSource.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
			this.dgSource.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgSource.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.dgSource.EnableHeadersVisualStyles = false;
			this.dgSource.Location = new System.Drawing.Point(0, 47);
			this.dgSource.Name = "dgSource";
			this.dgSource.ReadOnly = true;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.dgSource.RowsDefaultCellStyle = dataGridViewCellStyle2;
			this.dgSource.RowTemplate.Height = 28;
			this.dgSource.Size = new System.Drawing.Size(959, 442);
			this.dgSource.TabIndex = 4;
			this.dgSource.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgSource_CellContentClick);
			// 
			// Column1
			// 
			this.Column1.HeaderText = "操作";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.Column1.Text = "取消划单";
			this.Column1.UseColumnTextForButtonValue = true;
			this.Column1.Width = 916;
			// 
			// frmQueryPart
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Silver;
			this.ClientSize = new System.Drawing.Size(959, 532);
			this.Controls.Add(this.dgSource);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmQueryPart";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "已划单信息";
			this.Load += new System.EventHandler(this.frmQueryPart_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtZhuoTai;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.TextBox txtDish;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnQuery;
		private System.Windows.Forms.TextBox txtOrderCode;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btnDown;
		private System.Windows.Forms.Button btnUp;
		private System.Windows.Forms.Label lblPage;
		private System.Windows.Forms.DataGridView dgSource;
		private System.Windows.Forms.DataGridViewButtonColumn Column1;
	}
}