namespace RestProject
{
	partial class ChangeCostForm
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
			this.numericUpDown = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.applyBtn = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// numericUpDown
			// 
			this.numericUpDown.DecimalPlaces = 2;
			this.numericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numericUpDown.Location = new System.Drawing.Point(228, 68);
			this.numericUpDown.MaximumSize = new System.Drawing.Size(150, 0);
			this.numericUpDown.Name = "numericUpDown";
			this.numericUpDown.Size = new System.Drawing.Size(133, 30);
			this.numericUpDown.TabIndex = 46;
			this.numericUpDown.Value = new decimal(new int[] {
            133,
            0,
            0,
            131072});
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(57, 67);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(146, 28);
			this.label5.TabIndex = 45;
			this.label5.Text = "Price per hour:";
			// 
			// applyBtn
			// 
			this.applyBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.applyBtn.BackColor = System.Drawing.SystemColors.Control;
			this.applyBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.applyBtn.FlatAppearance.BorderSize = 0;
			this.applyBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
			this.applyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.applyBtn.Font = new System.Drawing.Font("Malgun Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.applyBtn.Location = new System.Drawing.Point(400, 55);
			this.applyBtn.Name = "applyBtn";
			this.applyBtn.Size = new System.Drawing.Size(199, 57);
			this.applyBtn.TabIndex = 44;
			this.applyBtn.Text = "Apply";
			this.applyBtn.UseVisualStyleBackColor = false;
			this.applyBtn.Click += new System.EventHandler(this.applyBtn_Click);
			// 
			// ChangeCostForm
			// 
			this.AcceptButton = this.applyBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(676, 175);
			this.Controls.Add(this.numericUpDown);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.applyBtn);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ChangeCostForm";
			this.Text = "Price per hour";
			this.Load += new System.EventHandler(this.ChangeCostForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.NumericUpDown numericUpDown;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button applyBtn;
	}
}