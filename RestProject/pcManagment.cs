using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;


namespace RestProject
{
	public partial class pcManagment : Form
	{
		private const int NumberOfComputers = 12;
		private int computerId;
		private int totalTime;
		private decimal earnings;
		private List<Panel> activeComputerPanels; 
		private ComputerTimer[] computerTimers;
		public string connectionString = (@"Data Source=EDONB;Initial Catalog=pcmag;Integrated Security=True");

		public pcManagment()
		{

			InitializeComponent();
			InitializeTimer();
			foreach (Control control in this.Controls)
			{
				if (control is Panel panel)
				{
					panel.DoubleClick += Panel_DoubleClick;
				}
			}
			activeComputerPanels = new List<Panel>(); 
		}
		private ComputerTimer GetComputerTimerById(int computerId)
		{
			foreach (var timer in computerTimers)
			{
				if (timer != null && timer.ComputerId == computerId) 
				{
					return timer;
				}
			}
			return null; 
		}

		public void InitializeTimer()
		{
			computerTimers = new ComputerTimer[NumberOfComputers + 1];
			computerTimers[1] = new ComputerTimer(btnStart, btnStop, btnReset, lblTimer, lblPrice, pictureBox1, 1, this);
			computerTimers[2] = new ComputerTimer(btnStart1, btnStop1, btnReset1, lblTimer1, lblPrice1, pictureBox2, 2, this);
			computerTimers[3] = new ComputerTimer(btnStart2, btnStop2, btnReset2, lblTimer2, lblPrice2, pictureBox3, 3, this);
			computerTimers[4] = new ComputerTimer(btnStart3, btnStop3, btnReset3, lblTimer3, lblPrice3, pictureBox4, 4, this);
			computerTimers[5] = new ComputerTimer(btnStart4, btnStop4, btnReset4, lblTimer4, lblPrice4, pictureBox5, 5, this);
			computerTimers[6] = new ComputerTimer(btnStart5, btnStop5, btnReset5, lblTimer5, lblPrice5, pictureBox6, 6, this);
			computerTimers[7] = new ComputerTimer(btnStart6, btnStop6, btnReset6, lblTimer6, lblPrice6, pictureBox7, 7, this);
			computerTimers[8] = new ComputerTimer(btnStart7, btnStop7, btnReset7, lblTimer7, lblPrice7, pictureBox8, 8, this);
			computerTimers[9] = new ComputerTimer(btnStart8, btnStop8, btnReset8, lblTimer8, lblPrice8, pictureBox9, 9, this);
			computerTimers[10] = new ComputerTimer(btnStart9, btnStop9, btnReset9, lblTimer9, lblPrice9, pictureBox10, 10, this);
			computerTimers[11] = new ComputerTimer(btnStart10, btnStop10, btnReset10, lblTimer10, lblPrice10, pictureBox11, 11, this);
			computerTimers[12] = new ComputerTimer(btnStart11, btnStop11, btnReset11, lblTimer11, lblPrice11, pictureBox12, 12, this);
		}
		System.Windows.Forms.Timer realTimeTimer = new System.Windows.Forms.Timer();
		private void pcManagment_Load(object sender, EventArgs e)
		{
			InitializeRealTimeClock();
		}
		private void InitializeRealTimeClock()
		{
			realTimeTimer.Interval = 1000;
			realTimeTimer.Tick += new EventHandler(UpdateDateTime);
			realTimeTimer.Start();
		}

		// Update the label with the current date and time every tick
		private void UpdateDateTime(object sender, EventArgs e)
		{
			this.labelDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"); // Customize format as needed
		}
		private bool AreThereComputersRunning()
		{
			for (int i = 1; i <= NumberOfComputers; i++)
			{
				if (computerTimers[i] == null)
				{
					MessageBox.Show($"Computer {i} is null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					continue; // Skip null timers
				}

				// Add debugging to check if the timer is running
				if (computerTimers[i].IsRunning)
				{
					MessageBox.Show($"Computer {i} is running.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return true;
				}
			}
			return false;
		}
		private void PcManagment_FormClosing(object sender, FormClosingEventArgs e)
		{
			bool isComputerStarted = AreThereComputersRunning();

			// Check if any computer is active
			if (isComputerStarted || CheckForNullEndTime())
			{
				var result = MessageBox.Show(
					"There are computers running or there are pending activities with NULL end times. Please stop all PCs before closing! You can't close!?",
					"Warning!",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);

				if (result == DialogResult.OK)
				{
					e.Cancel = true;
				}

			}
		}

		// Method to check for NULL end times in the database
		private bool CheckForNullEndTime()
		{
			bool hasNullEndTime = false;

			string query = "SELECT COUNT(*) FROM PCUsage WHERE EndTime IS NULL";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand(query, connection);

				try
				{
					connection.Open();
					int count = (int)command.ExecuteScalar();
					if (count > 0)
					{
						hasNullEndTime = true;
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("An error occurred while checking the database: " + ex.Message);
				}
			}

			return hasNullEndTime;
		}

		private void ChangeCost_Click(object sender, EventArgs e)
		{
			// Open the ChangeCostForm
			ChangeCostForm changeCostForm = new ChangeCostForm();
			changeCostForm.ShowDialog();
		}
		private void Panel_DoubleClick(object sender, EventArgs e)
		{
			Panel clickedPanel = sender as Panel;

			if (clickedPanel != null)
			{
				computerId = GetComputerIdFromPanel(clickedPanel);

				DataRow usageData = GetLastUsageData(computerId);
				if (usageData != null)
				{
					try
					{
						totalTime = usageData["TotalTime"] != DBNull.Value ? Convert.ToInt32(usageData["TotalTime"]) : 0;
						earnings = usageData["Earnings"] != DBNull.Value ? Convert.ToDecimal(usageData["Earnings"]) : 0;
						// Set up the print document
						SetupPrintDocument();
					}
					catch (Exception ex)
					{
						MessageBox.Show("Error extracting data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				else
				{
					MessageBox.Show("No usage data available for this computer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}
		private DataRow GetLastUsageData(int computerId)
		{
			string query = @"
		SELECT TOP 1 
			ComputerId, 
			DATEDIFF(MINUTE, StartTime, EndTime) AS TotalTime,
			Earnings
		FROM PCUsage
		WHERE ComputerId = @ComputerId
		ORDER BY StartTime DESC";

			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				SqlDataAdapter da = new SqlDataAdapter(query, conn);
				da.SelectCommand.Parameters.AddWithValue("@ComputerId", computerId);
				DataTable dt = new DataTable();
				da.Fill(dt);

				if (dt.Rows.Count > 0)
				{
					return dt.Rows[0];
				}
				return null;
			}
		}

		private int GetComputerIdFromPanel(Panel panel)
		{
			switch (panel.Name)
			{
				case "panel11": return 1;
				case "panel22": return 2;
				case "panel33": return 3;
				case "panel44": return 4;
				case "panel55": return 5;
				case "panel66": return 6;
				case "panel77": return 7;
				case "panel88": return 8;
				case "panel99": return 9;
				case "panel110": return 10;
				case "panel121": return 11;
				case "panel133": return 12;
				default: return 0;
			}
		}
		private PrintDocument printDocument = new PrintDocument();

		private void SetupPrintDocument()
		{
			PrintDocument printDocument = new PrintDocument();

			// Set paper size to 8.5 x 11 inches
			printDocument.DefaultPageSettings.PaperSize = new PaperSize("Letter", 850, 1100);
			printDocument.PrintPage += PrintDocument_PrintPage;

			PrintPreviewDialog previewDialog = new PrintPreviewDialog();
			previewDialog.Document = printDocument;
			previewDialog.ShowDialog();
		}

		private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
		{
			// Define fonts and brushes
			Font headerFont = new Font("Arial", 16, FontStyle.Bold);
			Font subHeaderFont = new Font("Arial", 14, FontStyle.Bold);
			Font bodyFont = new Font("Arial", 12);
			Font footerFont = new Font("Arial", 10, FontStyle.Italic);
			Brush textBrush = Brushes.Black;
			Brush headerBrush = Brushes.DarkBlue;

			// Define margins and positions
			float leftMargin = e.MarginBounds.Left;
			float topMargin = e.MarginBounds.Top;
			float width = e.MarginBounds.Width;
			float height = e.MarginBounds.Height;

			// Draw Header
			e.Graphics.DrawString("MitWare MITROVICE", headerFont, headerBrush, leftMargin, topMargin);
			e.Graphics.DrawString($"Date: {DateTime.Now:dd/MM/yyyy}", bodyFont, textBrush, leftMargin, topMargin + 30);

			// Draw Invoice Details
			float currentY = topMargin + 60;
			e.Graphics.DrawString($"FATURA per Computer ID: {computerId}", subHeaderFont, textBrush, leftMargin, currentY);
			currentY += 30;
			e.Graphics.DrawString($"Koha totale ne minuta: {totalTime} minutes", bodyFont, textBrush, leftMargin, currentY);
			e.Graphics.DrawString($"Qmimi: ${earnings:0.00}", bodyFont, textBrush, leftMargin, currentY + 25);

			// Draw Border
			Pen borderPen = new Pen(Color.Black, 1);
			e.Graphics.DrawRectangle(borderPen, leftMargin, topMargin, width, currentY + 60 - topMargin);

			// Draw Footer
			currentY += 70;
			e.Graphics.DrawString("Thank you for your presence!", footerFont, textBrush, leftMargin, currentY);
			e.Graphics.DrawString("Contact us at info@mitware.com | +383 49 644 580", footerFont, textBrush, leftMargin, currentY + 15);
		}
		private Dictionary<int, Panel> computerPanels = new Dictionary<int, Panel>();

		public void AddActiveComputer(int computerId, int time, decimal price)
		{
			foreach (Control control in panelActiveComputers.Controls)
			{
				if (control.Name == $"ComputerPanel{computerId}")
				{
					MessageBox.Show($"Computer {computerId} is already active.", "Duplicate Computer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
			}

			Panel computerPanel = new Panel
			{
				Height = 70,
				Dock = DockStyle.Top,
				BorderStyle = BorderStyle.FixedSingle,
				Name = $"ComputerPanel{computerId}"
			};

			Button btnOrder = new Button
			{
				Height = 30,
				Font = new Font("Arial", 10),
				Dock = DockStyle.Bottom,
				Text = "Order",
				Tag = computerId
			};
			btnOrder.Click += BtnOrder_Click;
			computerPanel.Controls.Add(btnOrder);

			Label lblInfo = new Label
			{
				Text = $"Computer {computerId}",
				Font = new Font("Arial", 10, FontStyle.Bold),
				TextAlign = ContentAlignment.TopLeft,
				Padding = new Padding(10),
				AutoSize = true
			};
			computerPanel.Controls.Add(lblInfo);

			Label lblTimePrice = new Label
			{
				Text = $"Time: {time} mins, Price: ${price:0.00}",
				Font = new Font("Arial", 10),
				TextAlign = ContentAlignment.BottomLeft, // Align time and price info to the bottom left
				Padding = new Padding(10),
				AutoSize = true // Auto-size label to fit content
			};
			computerPanel.Controls.Add(lblTimePrice);

			computerPanels[computerId] = computerPanel;

			if (computerTimers[computerId] != null)
			{
				computerTimers[computerId].SetInfoLabel(lblInfo);
			}

			panelActiveComputers.Controls.Add(computerPanel);
		}

		public void BtnOrder_Click(object sender, EventArgs e)
		{
			Button clickedButton = (Button)sender;
			int computerId = (int)clickedButton.Tag;
			ShowOrdersForm(computerId);
		}

		public void ShowOrdersForm(int computerId)
		{
			orders ordersForm = new orders();

			// Use a lambda to capture the computerId when the price is selected
			ordersForm.OnPriceSelected = (double newPrice) => UpdatePrice(newPrice, computerId);
			ordersForm.ShowDialog();
		}

		public void UpdatePrice(double newPrice, int computerId)
		{
			ComputerTimer computerTimer = GetComputerTimerById(computerId);

			if (computerTimer != null)
			{
				computerTimer.AddPrice(newPrice);
			}
			else
			{
				MessageBox.Show($"No ComputerTimer found for Computer ID: {computerId}");
			}
		}
		public void RemoveComputerPanel(int computerId)
		{
			if (computerPanels.TryGetValue(computerId, out Panel panelToRemove))
			{
				panelActiveComputers.Controls.Remove(panelToRemove);
				computerPanels.Remove(computerId);
			}
		}
		private void ShowFiscalVoucherDialog(int computerId, int totalTime, decimal earnings)
		{
			DialogResult result = MessageBox.Show(
				$"Do you want to generate a fiscal voucher for Computer {computerId}?",
				"Fiscal Voucher",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				FiscalVoucherForm voucherForm = new FiscalVoucherForm(computerId, totalTime, earnings);
				voucherForm.ShowDialog(); // Show the fiscal voucher form as a dialog
			}
		}

		private void panelActiveComputers_Paint(object sender, PaintEventArgs e)
		{
			AutoScroll = true;
		}
		private void panelActiveComputers_Paint_1(object sender, PaintEventArgs e)
		{
			AutoScroll = true;
		}
		private void changePricePHToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ChangeCostForm chPrice = new ChangeCostForm();
			chPrice.ShowDialog();
		}
	}
}