using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace RestProject
{
	public class ComputerTimer
	{
		public bool IsRunning { get; private set; }
		public Timer Timer { get; private set; }
		public TimeSpan TimeElapsed { get; private set; }
		public bool TimerRunning { get; private set; }
		public Button BtnStart { get; private set; }
		public Button BtnStop { get; private set; }
		public Button BtnReset { get; private set; }
		public Label LblTimer { get; private set; }
		public Label LblPrice { get; private set; }
		public PictureBox PictureBox { get; private set; }
		private pcManagment parentForm;


		private const double CostPerMinute = 0.016;
		private double additionalPrice = 0;
		public int ComputerId; // Add ComputerId for database operations
		public string connectionString = @"Data Source=EDONB;Initial Catalog=pcmag;Integrated Security=True"; // Replace with your actual connection string
		private Label lblInfo; // New field for lblInfo

		// Add a reference to the parent form
		public decimal GetPricePerHourFromDatabase()
		{
			decimal pricePerHour = 0;

			string query = "SELECT SettingValue FROM Settings WHERE SettingKey = 'PricePerHour'";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand(query, connection);
				connection.Open();
				pricePerHour = (decimal)command.ExecuteScalar();
			}

			return pricePerHour / 60;
		}

		public ComputerTimer(Button btnStart, Button btnStop, Button btnReset, Label lblTimer, Label lblPrice, PictureBox pictureBox, int computerId, pcManagment parent)
		{
			btnStart.Click += (sender, e) => StartTimer(sender, e); // Ensure this is only added once
			btnStop.Click += (sender, e) => StopTimer(sender, e);
			btnReset.Click += (sender, e) => ResetTimer(computerId);

			Timer = new Timer();
			Timer.Interval = 1000; // 1 second
			Timer.Tick += TimerTick;
			TimeElapsed = TimeSpan.Zero;
			TimerRunning = false;

			parentForm = parent; // Set the reference to the parent form
			BtnStart = btnStart;
			BtnStop = btnStop;
			BtnReset = btnReset;
			LblTimer = lblTimer;
			LblPrice = lblPrice;
			PictureBox = pictureBox;
			ComputerId = computerId; // Initialize ComputerId

			// Ensure this is not adding duplicate handlers
			UpdateTimerLabel();
			UpdatePriceLabel();
		}

		private void TimerTick(object sender, EventArgs e)
		{
			TimeElapsed = TimeElapsed.Add(TimeSpan.FromSeconds(1));
			UpdateTimerLabel();
			UpdatePriceLabel();
			UpdateLabel(); // Add this to update lblInfo dynamically
		}
		private void UpdateTimerLabel()
		{
			if (LblTimer.InvokeRequired)
			{
				LblTimer.BeginInvoke(new Action(UpdateTimerLabel));
				return;
			}
			LblTimer.Text = TimeElapsed.ToString(@"hh\:mm\:ss");

		}

		private void UpdatePriceLabel()
		{
			if (LblPrice.InvokeRequired)
			{
				LblPrice.BeginInvoke(new Action(UpdatePriceLabel));
				return;
			}

			// Calculate the total price based on time and any stored additional price
			double totalMinutes = TimeElapsed.TotalMinutes;
			double totalCost = (totalMinutes * CostPerMinute) + additionalPrice; // Include additional price

			LblPrice.Text = totalCost.ToString("C2");
		}
		// Method to add a product price to the total
		public void AddPrice(double newPrice)
		{
			// Update the additional price
			additionalPrice += newPrice; // Add to the existing additional price

			// Refresh the price label immediately
			UpdatePriceLabel();
			UpdateLabel();
		}
		public void SetInfoLabel(Label label)
		{
			lblInfo = label;

			// Use Invoke if needed
			if (lblInfo.InvokeRequired)
			{
				lblInfo.Invoke((MethodInvoker)delegate
				{
					UpdateLabel();
				});
			}
			else
			{
				UpdateLabel();
			}
		}

		private void UpdateLabel()
		{
			// Ensure lblInfo is not null before updating it
			if (lblInfo == null)
			{
				return; // Exit the method if lblInfo is null
			}

			string totalMinutes = TimeElapsed.ToString(@"hh\:mm\:ss");
			double totMins = TimeElapsed.TotalMinutes;
			double totalCost = (totMins * CostPerMinute) + additionalPrice;
			if (lblInfo.InvokeRequired)
			{
				lblInfo.Invoke((MethodInvoker)delegate
				{
					lblInfo.Text = $"Computer {ComputerId} - Time: {totalMinutes:F2} h, Price: {totalCost:C2}";
				});
			}
			else
			{
				lblInfo.Text = $"Computer {ComputerId} - Time: {totalMinutes:F2} h, Price: {totalCost:C2}";
			}
		}
		private void StartTimer(object sender, EventArgs e)
		{

			if (!TimerRunning)
			{
				Timer.Start();
				TimerRunning = true;



				// Call AddActiveComputer method in the parent form
				parentForm.AddActiveComputer(ComputerId, (int)TimeElapsed.TotalMinutes, (decimal)(TimeElapsed.TotalMinutes * CostPerMinute));

				PictureBox.Invoke((MethodInvoker)(() =>
				{
					PictureBox.BackColor = Color.Green;
				}));
				InsertStartTimeIntoDatabase(); // Insert start time into the database
			}
		}

		private void StopTimer(object sender, EventArgs e)
		{

			if (TimerRunning)
			{
				Timer.Stop();
				TimerRunning = false;

				PictureBox.Invoke((MethodInvoker)(() =>
				{
					PictureBox.BackColor = Color.Red;
				}));
			}
		}

		private void ResetTimer(int computerId)
		{
			if (TimerRunning)
			{
				Timer.Stop();
				TimerRunning = false;

			}
			UpdateEndTimeInDatabase(); // Update end time and calculate total in the database
			TimeElapsed = TimeSpan.Zero;
			additionalPrice = 0; // Reset additional price to 0
			UpdateTimerLabel();
			UpdatePriceLabel();

			PictureBox.Invoke((MethodInvoker)(() =>
			{
				PictureBox.BackColor = SystemColors.Control;
			}));

			// Remove the computer panel from the parent form
			parentForm.RemoveComputerPanel(computerId); // This will remove the panel from the parent form
		}


		// Method to insert the start time into the PCUsage table
		private void InsertStartTimeIntoDatabase()
		{
			string insertQuery = "INSERT INTO PCUsage (ComputerId, StartTime) VALUES (@ComputerId, @StartTime)";

			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand(insertQuery, conn);
				cmd.Parameters.AddWithValue("@ComputerId", ComputerId);
				cmd.Parameters.AddWithValue("@StartTime", DateTime.Now);

				conn.Open();
				cmd.ExecuteNonQuery();
				conn.Close();
			}
		}

		private void UpdateEndTimeInDatabase()
		{
			string updateQuery = @"
				UPDATE PCUsage
				SET EndTime = @EndTime, 
					TotalTime = DATEDIFF(MINUTE, StartTime, @EndTime), 
					Earnings = (DATEDIFF(MINUTE, StartTime, @EndTime) * @CostPerMinute) + @additionalPrice
				WHERE ComputerId = @ComputerId AND EndTime IS NULL";

			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand(updateQuery, conn);
				DateTime endTime = DateTime.Now;

				cmd.Parameters.AddWithValue("@ComputerId", ComputerId);
				cmd.Parameters.AddWithValue("@EndTime", endTime);
				cmd.Parameters.AddWithValue("@CostPerMinute", CostPerMinute);
				cmd.Parameters.AddWithValue("@AdditionalPrice", additionalPrice); // pass additional price

				conn.Open();
				cmd.ExecuteNonQuery();
				conn.Close();
			}
		}
	}
}
