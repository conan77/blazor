namespace HuaDan
{
    partial class frmSingleGuQing
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
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.lblTitleName = new System.Windows.Forms.Label();
			this.lblDishName = new System.Windows.Forms.Label();
			this.chkGuQing = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.button2 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::HuaDan.Properties.Resources.close;
			this.pictureBox1.Location = new System.Drawing.Point(352, 7);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(41, 35);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 7;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(this.button2_Click);
			// 
			// lblTitleName
			// 
			this.lblTitleName.AutoSize = true;
			this.lblTitleName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblTitleName.ForeColor = System.Drawing.Color.White;
			this.lblTitleName.Location = new System.Drawing.Point(12, 12);
			this.lblTitleName.Name = "lblTitleName";
			this.lblTitleName.Size = new System.Drawing.Size(74, 21);
			this.lblTitleName.TabIndex = 6;
			this.lblTitleName.Text = "添加沽清";
			// 
			// lblDishName
			// 
			this.lblDishName.AutoSize = true;
			this.lblDishName.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblDishName.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblDishName.Location = new System.Drawing.Point(32, 29);
			this.lblDishName.Name = "lblDishName";
			this.lblDishName.Size = new System.Drawing.Size(73, 28);
			this.lblDishName.TabIndex = 8;
			this.lblDishName.Text = "label1";
			// 
			// chkGuQing
			// 
			this.chkGuQing.AutoSize = true;
			this.chkGuQing.BackColor = System.Drawing.Color.White;
			this.chkGuQing.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.chkGuQing.ForeColor = System.Drawing.SystemColors.ControlText;
			this.chkGuQing.Location = new System.Drawing.Point(124, 96);
			this.chkGuQing.Name = "chkGuQing";
			this.chkGuQing.Size = new System.Drawing.Size(115, 32);
			this.chkGuQing.TabIndex = 9;
			this.chkGuQing.Text = "是否沽清";
			this.chkGuQing.UseVisualStyleBackColor = false;
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.SystemColors.Control;
			this.button1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.button1.Location = new System.Drawing.Point(59, 175);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(114, 44);
			this.button1.TabIndex = 10;
			this.button1.Text = "是";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.White;
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.lblDishName);
			this.panel1.Controls.Add(this.chkGuQing);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Location = new System.Drawing.Point(12, 48);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(381, 244);
			this.panel1.TabIndex = 12;
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.SystemColors.Control;
			this.button2.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.button2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.button2.Location = new System.Drawing.Point(207, 175);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(114, 44);
			this.button2.TabIndex = 11;
			this.button2.Text = "否";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// frmSingleGuQing
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Teal;
			this.ClientSize = new System.Drawing.Size(406, 308);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.lblTitleName);
			this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmSingleGuQing";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmSingleGuQing";
			this.Load += new System.EventHandler(this.frmSingleGuQing_Load);
			this.Resize += new System.EventHandler(this.frmSingleGuQing_Resize);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTitleName;
        private System.Windows.Forms.Label lblDishName;
        private System.Windows.Forms.CheckBox chkGuQing;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
    }
}