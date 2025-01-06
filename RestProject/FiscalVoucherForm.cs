using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace RestProject
{
	public partial class FiscalVoucherForm : Form
	{
		private int computerId;
		private int totalTime;
		private decimal earnings;
		private Label lblComputerId;
		private Label lblTotalTime;
		private Label lblEarnings;
		private TextBox txtComputerId;
		private TextBox txtTotalTime;
		private TextBox txtEarnings;
		private Button btnPrint;

		public FiscalVoucherForm(int computerId, int totalTime, decimal earnings)
		{
			InitializeComponent();

			// Store parameters
			this.computerId = computerId;
			this.totalTime = totalTime;
			this.earnings = earnings;

			SetupFormLayout(); // Setup form controls and layout
			LoadVoucherDetails(); // Load voucher details into the form
		}

		private void LoadVoucherDetails()
		{
			txtComputerId.Text = computerId.ToString();
			txtTotalTime.Text = totalTime.ToString();
			txtEarnings.Text = earnings.ToString("0.00");
		}

		private void SetupFormLayout()
		{
			// Form properties
			this.Text = "Fiscal Voucher";
			this.Size = new Size(400, 300);
			this.FormBorderStyle = FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.StartPosition = FormStartPosition.CenterScreen;

			// Label: Computer ID
			lblComputerId = new Label
			{
				Text = "Computer ID:",
				Location = new Point(30, 30),
				AutoSize = true
			};
			this.Controls.Add(lblComputerId);

			// TextBox: Computer ID
			txtComputerId = new TextBox
			{
				Location = new Point(150, 30),
				Size = new Size(200, 20),
				ReadOnly = true  // Make it read-only since it's just for display
			};
			this.Controls.Add(txtComputerId);

			// Label: Total Time
			lblTotalTime = new Label
			{
				Text = "Total Time (mins):",
				Location = new Point(30, 80),
				AutoSize = true
			};
			this.Controls.Add(lblTotalTime);

			// TextBox: Total Time
			txtTotalTime = new TextBox
			{
				Location = new Point(150, 80),
				Size = new Size(200, 20),
				ReadOnly = true  // Make it read-only since it's just for display
			};
			this.Controls.Add(txtTotalTime);

			// Label: Earnings
			lblEarnings = new Label
			{
				Text = "Earnings ($):",
				Location = new Point(30, 130),
				AutoSize = true
			};
			this.Controls.Add(lblEarnings);

			// TextBox: Earnings
			txtEarnings = new TextBox
			{
				Location = new Point(150, 130),
				Size = new Size(200, 20),
				ReadOnly = true  // Make it read-only since it's just for display
			};
			this.Controls.Add(txtEarnings);

			// Button: Print
			btnPrint = new Button
			{
				Text = "Print Voucher",
				Location = new Point(120, 200),
				Size = new Size(150, 30)
			};
			btnPrint.Click += new EventHandler(btnPrint_Click);  // Attach click event handler
			this.Controls.Add(btnPrint);
		}

		private void btnPrint_Click(object sender, EventArgs e)
		{
			try
			{
				PrintDocument printDoc = new PrintDocument();
				printDoc.PrintPage += PrintDoc_PrintPage;  // Attach print event handler
				PrintDialog printDialog = new PrintDialog
				{
					Document = printDoc
				};

				if (printDialog.ShowDialog() == DialogResult.OK)
				{
					printDoc.Print();  // Print if the user clicks OK
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("An error occurred while printing: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
		{
			string city = "Mitrovice";
			e.Graphics.DrawString($"Fiscal Voucher for Computer {computerId}", new Font("Arial", 12), Brushes.Black, new PointF(100, 100));
			e.Graphics.DrawString($"Total Time: {totalTime} mins", new Font("Arial", 12), Brushes.Black, new PointF(100, 130));
			e.Graphics.DrawString($"Earnings: ${earnings:0.00}", new Font("Arial", 12), Brushes.Black, new PointF(100, 160));
			e.Graphics.DrawString($"Vendi: {city}", new Font("Arial", 12), Brushes.Black, new PointF(100, 190));
			e.Graphics.DrawString($"2024", new Font("Arial", 12), Brushes.Black, new PointF(100, 220));
		}

        private void FiscalVoucherForm_Load(object sender, EventArgs e)
        {

        }
    }
}
