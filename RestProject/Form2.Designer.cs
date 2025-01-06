namespace RestProject
{
	partial class Form2
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
			this.userInput = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.passInput = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// userInput
			// 
			this.userInput.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.userInput.Location = new System.Drawing.Point(578, 229);
			this.userInput.Name = "userInput";
			this.userInput.Size = new System.Drawing.Size(339, 34);
			this.userInput.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Malgun Gothic", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.SystemColors.WindowFrame;
			this.label2.Location = new System.Drawing.Point(571, 179);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(170, 38);
			this.label2.TabIndex = 3;
			this.label2.Text = "USERNAME";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Malgun Gothic", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.WindowFrame;
			this.label1.Location = new System.Drawing.Point(566, 286);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(175, 38);
			this.label1.TabIndex = 5;
			this.label1.Text = "PASSWORD";
			// 
			// passInput
			// 
			this.passInput.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.passInput.Location = new System.Drawing.Point(578, 336);
			this.passInput.Name = "passInput";
			this.passInput.PasswordChar = '*';
			this.passInput.Size = new System.Drawing.Size(339, 34);
			this.passInput.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Malgun Gothic", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.SystemColors.WindowFrame;
			this.label3.Location = new System.Drawing.Point(643, 50);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(223, 81);
			this.label3.TabIndex = 6;
			this.label3.Text = "LOGIN";
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.ForeColor = System.Drawing.SystemColors.WindowFrame;
			this.button1.Location = new System.Drawing.Point(573, 410);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(168, 49);
			this.button1.TabIndex = 7;
			this.button1.Text = "Login";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Enabled = false;
			this.button2.Font = new System.Drawing.Font("Malgun Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button2.ForeColor = System.Drawing.SystemColors.WindowFrame;
			this.button2.Location = new System.Drawing.Point(747, 412);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(170, 49);
			this.button2.TabIndex = 8;
			this.button2.Text = "Krijo llogari te re";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label4.Location = new System.Drawing.Point(517, 484);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(433, 20);
			this.label4.TabIndex = 9;
			this.label4.Text = "Nese keni harruar passwordin tuaj,kontaktoni ne numrin ---";
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.panel1.BackgroundImage = global::RestProject.Properties.Resources.peakpx;
			this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(497, 566);
			this.panel1.TabIndex = 0;
			// 
			// Form2
			// 
			this.AcceptButton = this.button1;
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(980, 566);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.passInput);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.userInput);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MaximizeBox = false;
			this.Name = "Form2";
			this.Text = "RestWare";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox userInput;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox passInput;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label4;
	}
}