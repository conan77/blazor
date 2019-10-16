namespace HuaDan.CustomControl
{
	partial class FixedDishesMergeNumControl
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
			this.lblDishName = new System.Windows.Forms.Label();
			this.lblDishNum = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblDishName
			// 
			this.lblDishName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
			this.lblDishName.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblDishName.Font = new System.Drawing.Font("微软雅黑", 16F);
			this.lblDishName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.lblDishName.Location = new System.Drawing.Point(0, 0);
			this.lblDishName.Name = "lblDishName";
			this.lblDishName.Size = new System.Drawing.Size(147, 66);
			this.lblDishName.TabIndex = 0;
			this.lblDishName.Text = "lblDishName";
			this.lblDishName.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.lblDishName.Click += new System.EventHandler(this.lblDishName_Click);
			this.lblDishName.Paint += new System.Windows.Forms.PaintEventHandler(this.lblDishName_Paint);
			// 
			// lblDishNum
			// 
			this.lblDishNum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
			this.lblDishNum.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblDishNum.Font = new System.Drawing.Font("微软雅黑", 19F);
			this.lblDishNum.ForeColor = System.Drawing.Color.Red;
			this.lblDishNum.Location = new System.Drawing.Point(0, 66);
			this.lblDishNum.Name = "lblDishNum";
			this.lblDishNum.Size = new System.Drawing.Size(147, 46);
			this.lblDishNum.TabIndex = 1;
			this.lblDishNum.Text = "lblDishNum";
			this.lblDishNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblDishNum.Click += new System.EventHandler(this.lblDishNum_Click);
			// 
			// FixedDishesMergeNumControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.LightGray;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.lblDishNum);
			this.Controls.Add(this.lblDishName);
			this.Name = "FixedDishesMergeNumControl";
			this.Size = new System.Drawing.Size(147, 112);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label lblDishName;
		private System.Windows.Forms.Label lblDishNum;



	}
}
