namespace RestProject
{
	partial class ProductInfo
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
			this.txtProductName = new System.Windows.Forms.TextBox();
			this.txtProductImagePath = new System.Windows.Forms.TextBox();
			this.txtProductPrice = new System.Windows.Forms.TextBox();
			this.btnSubmit = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.browseButton = new System.Windows.Forms.Button();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.SuspendLayout();
			// 
			// txtProductName
			// 
			this.txtProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.txtProductName.Location = new System.Drawing.Point(211, 121);
			this.txtProductName.Multiline = true;
			this.txtProductName.Name = "txtProductName";
			this.txtProductName.Size = new System.Drawing.Size(146, 33);
			this.txtProductName.TabIndex = 0;
			// 
			// txtProductImagePath
			// 
			this.txtProductImagePath.Location = new System.Drawing.Point(211, 202);
			this.txtProductImagePath.Multiline = true;
			this.txtProductImagePath.Name = "txtProductImagePath";
			this.txtProductImagePath.Size = new System.Drawing.Size(336, 33);
			this.txtProductImagePath.TabIndex = 1;
			// 
			// txtProductPrice
			// 
			this.txtProductPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.txtProductPrice.Location = new System.Drawing.Point(546, 121);
			this.txtProductPrice.Multiline = true;
			this.txtProductPrice.Name = "txtProductPrice";
			this.txtProductPrice.Size = new System.Drawing.Size(139, 33);
			this.txtProductPrice.TabIndex = 4;
			// 
			// btnSubmit
			// 
			this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.btnSubmit.Location = new System.Drawing.Point(261, 275);
			this.btnSubmit.Name = "btnSubmit";
			this.btnSubmit.Size = new System.Drawing.Size(175, 45);
			this.btnSubmit.TabIndex = 5;
			this.btnSubmit.Text = "Add Product";
			this.btnSubmit.UseVisualStyleBackColor = true;
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.label1.Location = new System.Drawing.Point(63, 121);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(142, 25);
			this.label1.TabIndex = 6;
			this.label1.Text = "Product Name:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.label2.Location = new System.Drawing.Point(406, 121);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(134, 25);
			this.label2.TabIndex = 7;
			this.label2.Text = "Product Price:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.label3.Location = new System.Drawing.Point(73, 202);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(115, 25);
			this.label3.TabIndex = 8;
			this.label3.Text = "Image path:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(222, 34);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(286, 42);
			this.label4.TabIndex = 9;
			this.label4.Text = "Product Details";
			// 
			// browseButton
			// 
			this.browseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			this.browseButton.Location = new System.Drawing.Point(553, 202);
			this.browseButton.Name = "browseButton";
			this.browseButton.Size = new System.Drawing.Size(92, 35);
			this.browseButton.TabIndex = 10;
			this.browseButton.Text = "Browse";
			this.browseButton.UseVisualStyleBackColor = true;
			this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
			// 
			// openFileDialog
			// 
			this.openFileDialog.FileName = "openFileDialog";
			// 
			// ProductInfo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.ClientSize = new System.Drawing.Size(732, 415);
			this.Controls.Add(this.browseButton);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnSubmit);
			this.Controls.Add(this.txtProductPrice);
			this.Controls.Add(this.txtProductImagePath);
			this.Controls.Add(this.txtProductName);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ProductInfo";
			this.Text = "Product Info";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtProductName;
		private System.Windows.Forms.TextBox txtProductImagePath;
		private System.Windows.Forms.TextBox txtProductPrice;
		private System.Windows.Forms.Button btnSubmit;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button browseButton;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
	}
}