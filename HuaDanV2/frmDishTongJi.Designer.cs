namespace HuaDan
{
    partial class frmDishTongJi
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDishTongJi));
			this.panel1 = new System.Windows.Forms.Panel();
			this.button1 = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.txtDishCondition = new System.Windows.Forms.TextBox();
			this.btnQuery = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.dgSource = new System.Windows.Forms.DataGridView();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgSource)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.btnQuery);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(468, 54);
			this.panel1.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.Gray;
			this.button1.FlatAppearance.BorderSize = 0;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.ForeColor = System.Drawing.Color.White;
			this.button1.Location = new System.Drawing.Point(363, 10);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(64, 33);
			this.button1.TabIndex = 4;
			this.button1.Text = "重置";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.White;
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.txtDishCondition);
			this.panel2.Location = new System.Drawing.Point(130, 10);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(157, 33);
			this.panel2.TabIndex = 3;
			// 
			// txtDishCondition
			// 
			this.txtDishCondition.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtDishCondition.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtDishCondition.Location = new System.Drawing.Point(3, 6);
			this.txtDishCondition.Name = "txtDishCondition";
			this.txtDishCondition.Size = new System.Drawing.Size(151, 22);
			this.txtDishCondition.TabIndex = 1;
			// 
			// btnQuery
			// 
			this.btnQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(101)))), ((int)(((byte)(26)))));
			this.btnQuery.FlatAppearance.BorderSize = 0;
			this.btnQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnQuery.ForeColor = System.Drawing.Color.White;
			this.btnQuery.Location = new System.Drawing.Point(293, 10);
			this.btnQuery.Name = "btnQuery";
			this.btnQuery.Size = new System.Drawing.Size(64, 33);
			this.btnQuery.TabIndex = 2;
			this.btnQuery.Text = "查询";
			this.btnQuery.UseVisualStyleBackColor = false;
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(5, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(128, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "菜品名称/编码：";
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
			this.dgSource.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgSource.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.dgSource.EnableHeadersVisualStyles = false;
			this.dgSource.Location = new System.Drawing.Point(0, 54);
			this.dgSource.Name = "dgSource";
			this.dgSource.ReadOnly = true;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.dgSource.RowsDefaultCellStyle = dataGridViewCellStyle2;
			this.dgSource.RowTemplate.Height = 28;
			this.dgSource.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.dgSource.Size = new System.Drawing.Size(468, 432);
			this.dgSource.TabIndex = 2;
			// 
			// frmDishTongJi
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(468, 486);
			this.Controls.Add(this.dgSource);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmDishTongJi";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "菜品统计";
			this.Load += new System.EventHandler(this.frmDishTongJi_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgSource)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.TextBox txtDishCondition;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgSource;
    }
}