namespace RestProject
{
	partial class removeProduct
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
			this.comboBox = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnSubmit = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// comboBox
			// 
			this.comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.comboBox.FormattingEnabled = true;
			this.comboBox.Location = new System.Drawing.Point(206, 68);
			this.comboBox.Name = "comboBox";
			this.comboBox.Size = new System.Drawing.Size(121, 28);
			this.comboBox.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(86, 67);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(114, 29);
			this.label1.TabIndex = 1;
			this.label1.Text = "Products:";
			// 
			// btnSubmit
			// 
			this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSubmit.Location = new System.Drawing.Point(351, 62);
			this.btnSubmit.Name = "btnSubmit";
			this.btnSubmit.Size = new System.Drawing.Size(148, 39);
			this.btnSubmit.TabIndex = 6;
			this.btnSubmit.Text = "Remove Product";
			this.btnSubmit.UseVisualStyleBackColor = true;
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			// 
			// removeProduct
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.WindowFrame;
			this.ClientSize = new System.Drawing.Size(582, 170);
			this.Controls.Add(this.btnSubmit);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comboBox);
			this.Name = "removeProduct";
			this.Text = "Remove Product";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox comboBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnSubmit;
	}
}