namespace RestProject
{
	partial class newAccount
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
            this.createBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.passInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.userInput = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // createBtn
            // 
            this.createBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.createBtn.Font = new System.Drawing.Font("Malgun Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createBtn.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.createBtn.Location = new System.Drawing.Point(593, 400);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(273, 49);
            this.createBtn.TabIndex = 17;
            this.createBtn.Text = "Krijo";
            this.createBtn.UseVisualStyleBackColor = true;
            this.createBtn.Click += new System.EventHandler(this.createBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Malgun Gothic", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label3.Location = new System.Drawing.Point(560, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(343, 62);
            this.label3.TabIndex = 15;
            this.label3.Text = "REGJISTROHU";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Malgun Gothic", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label1.Location = new System.Drawing.Point(552, 282);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 38);
            this.label1.TabIndex = 14;
            this.label1.Text = "PASSWORD";
            // 
            // passInput
            // 
            this.passInput.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passInput.Location = new System.Drawing.Point(564, 332);
            this.passInput.Name = "passInput";
            this.passInput.PasswordChar = '*';
            this.passInput.Size = new System.Drawing.Size(339, 34);
            this.passInput.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Malgun Gothic", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label2.Location = new System.Drawing.Point(557, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 38);
            this.label2.TabIndex = 12;
            this.label2.Text = "USERNAME";
            // 
            // userInput
            // 
            this.userInput.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userInput.Location = new System.Drawing.Point(564, 225);
            this.userInput.Name = "userInput";
            this.userInput.Size = new System.Drawing.Size(339, 34);
            this.userInput.TabIndex = 11;
            this.userInput.TextChanged += new System.EventHandler(this.userInput_TextChanged);
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
            this.panel1.Size = new System.Drawing.Size(497, 562);
            this.panel1.TabIndex = 10;
            // 
            // newAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.createBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.userInput);
            this.Controls.Add(this.panel1);
            this.Name = "newAccount";
            this.Text = "newAccount";
            this.Load += new System.EventHandler(this.newAccount_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button createBtn;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox passInput;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox userInput;
		private System.Windows.Forms.Panel panel1;
	}
}