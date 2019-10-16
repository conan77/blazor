namespace HuaDan
{
    partial class frmHuaDan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHuaDan));
            this.lblDishName = new System.Windows.Forms.Label();
            this.btnCancelQiangDan = new System.Windows.Forms.Button();
            this.btnHuaDanOK = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTitleName = new System.Windows.Forms.Label();
            this.chkGuQing = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDishName
            // 
            this.lblDishName.AutoSize = true;
            this.lblDishName.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDishName.ForeColor = System.Drawing.Color.Black;
            this.lblDishName.Location = new System.Drawing.Point(17, 25);
            this.lblDishName.Name = "lblDishName";
            this.lblDishName.Size = new System.Drawing.Size(103, 29);
            this.lblDishName.TabIndex = 0;
            this.lblDishName.Text = "label1";
            // 
            // btnCancelQiangDan
            // 
            this.btnCancelQiangDan.BackColor = System.Drawing.Color.Gainsboro;
            this.btnCancelQiangDan.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancelQiangDan.ForeColor = System.Drawing.Color.Black;
            this.btnCancelQiangDan.Location = new System.Drawing.Point(66, 155);
            this.btnCancelQiangDan.Name = "btnCancelQiangDan";
            this.btnCancelQiangDan.Size = new System.Drawing.Size(109, 49);
            this.btnCancelQiangDan.TabIndex = 1;
            this.btnCancelQiangDan.Text = "取消抢单";
            this.btnCancelQiangDan.UseVisualStyleBackColor = false;
            this.btnCancelQiangDan.Click += new System.EventHandler(this.btnCancelQiangDan_Click);
            // 
            // btnHuaDanOK
            // 
            this.btnHuaDanOK.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnHuaDanOK.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnHuaDanOK.ForeColor = System.Drawing.Color.Black;
            this.btnHuaDanOK.Location = new System.Drawing.Point(206, 155);
            this.btnHuaDanOK.Name = "btnHuaDanOK";
            this.btnHuaDanOK.Size = new System.Drawing.Size(109, 49);
            this.btnHuaDanOK.TabIndex = 2;
            this.btnHuaDanOK.Text = "确认划单";
            this.btnHuaDanOK.UseVisualStyleBackColor = false;
            this.btnHuaDanOK.Click += new System.EventHandler(this.btnHuaDanOK_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.SlateGray;
            this.btnClose.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(282, 302);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(109, 60);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Visible = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.chkGuQing);
            this.panel1.Controls.Add(this.lblDishName);
            this.panel1.Controls.Add(this.btnHuaDanOK);
            this.panel1.Controls.Add(this.btnCancelQiangDan);
            this.panel1.Location = new System.Drawing.Point(12, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(392, 225);
            this.panel1.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::HuaDan.Properties.Resources.close;
            this.pictureBox1.Location = new System.Drawing.Point(363, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lblTitleName
            // 
            this.lblTitleName.AutoSize = true;
            this.lblTitleName.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitleName.ForeColor = System.Drawing.Color.White;
            this.lblTitleName.Location = new System.Drawing.Point(12, 18);
            this.lblTitleName.Name = "lblTitleName";
            this.lblTitleName.Size = new System.Drawing.Size(88, 25);
            this.lblTitleName.TabIndex = 8;
            this.lblTitleName.Text = "是否划单";
            // 
            // chkGuQing
            // 
            this.chkGuQing.AutoSize = true;
            this.chkGuQing.BackColor = System.Drawing.Color.White;
            this.chkGuQing.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkGuQing.Location = new System.Drawing.Point(119, 87);
            this.chkGuQing.Name = "chkGuQing";
            this.chkGuQing.Size = new System.Drawing.Size(115, 32);
            this.chkGuQing.TabIndex = 10;
            this.chkGuQing.Text = "是否沽清";
            this.chkGuQing.UseVisualStyleBackColor = false;
            // 
            // frmHuaDan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(416, 292);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblTitleName);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnClose);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmHuaDan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "是否划单";
            this.Load += new System.EventHandler(this.frmHuaDan_Load);
            this.Resize += new System.EventHandler(this.frmHuaDan_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDishName;
        private System.Windows.Forms.Button btnCancelQiangDan;
        private System.Windows.Forms.Button btnHuaDanOK;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTitleName;
        private System.Windows.Forms.CheckBox chkGuQing;
    }
}