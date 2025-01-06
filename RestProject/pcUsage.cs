using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Exceptions;
using System.Windows.Forms.DataVisualization.Charting;
using System.Collections.Generic; // Include this namespace


namespace RestProject
{
	public partial class pcUsage : Form
	{
		private Chart usageChart;
		public pcUsage()
		{
			InitializeComponent();
			SetupDataGridView(); // Setup the DataGridView when the form is initialized
			LoadDataIntoDataGridView(); // Load data into the DataGridView
			UpdateMostUsedComputerPanel(); // Update statistics panel for most used computer

			// Initialize ComboBox and add options
			comboBox.Items.AddRange(new object[] { "1 Day", "1 Week", "1 Month"
			});
			comboBox.SelectedIndex = 0; // Default to "1 Day"
			comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged; // Hook up event

			InitializeChart();
			UpdateChartData();
		}

		public string connectionString = (@"Data Source=EDONB;Initial Catalog=pcmag;Integrated Security=True");

		private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			LoadDataIntoDataGridView(); 
			UpdateMostUsedComputerPanel();
			UpdateChartData();
		}
		private void InitializeChart()
		{
			// Initialize and configure the Chart control
			usageChart = new Chart
			{
				Location = new Point(800, 100),
				Size = new Size(700, 700)
			};

			ChartArea chartArea = new ChartArea
			{
				Name = "UsageChartArea"
			};
			usageChart.ChartAreas.Add(chartArea);

			// Add a series to the chart
			Series series = new Series
			{
				Name = "AverageUsage",
				ChartType = SeriesChartType.Column, // Bar chart for average usage
				XValueType = ChartValueType.String, // Computer IDs as string
				YValueType = ChartValueType.Double // Average usage as double
			};
			usageChart.Series.Add(series);

			// Add legend
			Legend legend = new Legend
			{
				Name = "UsageLegend"
			};
			usageChart.Legends.Add(legend);

			// Configure AxisX ScrollBar
			usageChart.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
			usageChart.ChartAreas[0].AxisX.ScrollBar.BackColor = Color.LightGray; // Set scroll bar backcolor

			// Add the chart to the form
			this.Controls.Add(usageChart);
		}
		private void UpdateChartData()
		{
			if (comboBox.SelectedItem == null) return;

			string selectedPeriod = comboBox.SelectedItem.ToString();
			DataTable pcUsageData = GetPCUsageData(selectedPeriod); // Get data based on ComboBox selection

			// Calculate average usage time for each computer
			Dictionary<int, double> averageUsage = new Dictionary<int, double>();

			foreach (DataRow row in pcUsageData.Rows)
			{
				int computerId = Convert.ToInt32(row["ComputerId"]);

				// Check if TotalTime is DBNull before converting
				double totalTime = row["TotalTime"] != DBNull.Value ? Convert.ToDouble(row["TotalTime"]) : 0.0;

				averageUsage[computerId] = totalTime / GetUsageCount(computerId, selectedPeriod); // Calculate average
			}

			// Update chart data
			usageChart.Series["AverageUsage"].Points.Clear();
			foreach (var entry in averageUsage)
			{
				usageChart.Series["AverageUsage"].Points.AddXY($"Computer {entry.Key}", entry.Value);
			}
		}
		private int GetUsageCount(int computerId, string period)
		{
			string dateCondition = "";

			if (period == "1 Day")
			{
				dateCondition = "WHERE StartTime >= DATEADD(day, -1, GETDATE())";
			}
			else if (period == "1 Week")
			{
				dateCondition = "WHERE StartTime >= DATEADD(week, -1, GETDATE())";
			}
			else if (period == "1 Month")
			{
				dateCondition = "WHERE StartTime >= DATEADD(month, -1, GETDATE())";
			}

			string query = $@"
            SELECT COUNT(*) AS UsageCount
            FROM PCUsage
            {dateCondition}
            AND ComputerId = @ComputerId";

			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand(query, conn);
				cmd.Parameters.AddWithValue("@ComputerId", computerId);
				conn.Open();
				return (int)cmd.ExecuteScalar();
			}
		}
			private DataTable GetPCUsageData(string period)
		{
			string dateCondition = "";

			if (period == "1 Day")
			{
				dateCondition = "WHERE StartTime >= DATEADD(day, -1, GETDATE())";
			}
			else if (period == "1 Week")
			{
				dateCondition = "WHERE StartTime >= DATEADD(week, -1, GETDATE())";
			}
			else if (period == "1 Month")
			{
				dateCondition = "WHERE StartTime >= DATEADD(month, -1, GETDATE())";
			}
			else if (period.Contains("to"))
			{
				string[] dates = period.Split(new string[] { " to " }, StringSplitOptions.None);
				dateCondition = $"WHERE StartTime BETWEEN '{dates[0]}' AND '{dates[1]}'";
			}

			string query = $@"
        SELECT 
            ComputerId, 
			SUM(TotalTime) AS TotalTime,
			SUM(Earnings) AS Earnings 
        FROM PCUsage
        {dateCondition} 
        GROUP BY ComputerId";

			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				SqlDataAdapter da = new SqlDataAdapter(query, conn);
				DataTable dt = new DataTable();
				da.Fill(dt);
				return dt;
			}
		}


		private void LoadDataIntoDataGridView()
		{


			// Check if comboBox is not null and an item is selected
			if (comboBox != null && comboBox.SelectedItem != null)
			{
				string selectedFilter = comboBox.SelectedItem.ToString(); // Get selected filter
				DataTable pcUsageData = GetPCUsageData(selectedFilter); // Get aggregated data based on filter
				dataGridView1.DataSource = pcUsageData; // Bind the DataTable directly to the DataGridView
			}
		}


		private void SetupDataGridView()
		{
			// Clear existing columns to prevent duplication
			dataGridView1.Columns.Clear();

			// Define columns with appropriate headers and data bindings
			dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
			{
				Name = "ComputerId",
				HeaderText = "Computer ID",
				DataPropertyName = "ComputerId"
			});
			dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
			{
				Name = "TotalTime",
				HeaderText = "Total Time (mins)",
				DataPropertyName = "TotalTime"
			});
			dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
			{
				Name = "Earnings",
				HeaderText = "Earnings ($)",
				DataPropertyName = "Earnings"
			});

			// Customize appearance and formatting
			dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
			dataGridView1.EnableHeadersVisualStyles = false;
			dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
			dataGridView1.GridColor = Color.LightGray;
			dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
			dataGridView1.RowsDefaultCellStyle.BackColor = Color.White;
			dataGridView1.RowsDefaultCellStyle.SelectionBackColor = Color.DeepSkyBlue;
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
        AND EndTime IS NOT NULL
        ORDER BY EndTime DESC";

			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand(query, conn);
				cmd.Parameters.AddWithValue("@ComputerId", computerId);

				SqlDataAdapter da = new SqlDataAdapter(cmd);
				DataTable dt = new DataTable();
				da.Fill(dt);

				if (dt.Rows.Count > 0)
				{
					return dt.Rows[0];
				}
				return null;
			}
		}

private DataRow GetMostUsedComputer(string period)
{
    string dateCondition = "";
    if (period == "1 Day")
    {
        dateCondition = "StartTime >= DATEADD(day, -1, GETDATE())";
    }
    else if (period == "1 Week")
    {
        dateCondition = "StartTime >= DATEADD(week, -1, GETDATE())";
    }
    else if (period == "1 Month")
    {
        dateCondition = "StartTime >= DATEADD(month, -1, GETDATE())";
    }

            string query = $@"
        SELECT TOP 1 
            ComputerId, 
            SUM(TotalTime) AS TotalTime, 
            SUM(Earnings) AS Earnings
        FROM PCUsage
        WHERE EndTime IS NOT NULL
        {(string.IsNullOrEmpty(dateCondition) ? "" : "AND " + dateCondition)}
        GROUP BY ComputerId
        ORDER BY TotalTime DESC";

    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        SqlDataAdapter da = new SqlDataAdapter(query, conn);
        DataTable dt = new DataTable();
        da.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            return dt.Rows[0];
        }
        return null;
    }
}

		private void UpdateMostUsedComputerPanel()
		{
			// Use the default value from ComboBox or specify "1 Day" as the default period
			string selectedPeriod = comboBox?.SelectedItem?.ToString() ?? "1 Day";
			DataRow mostUsedComputer = GetMostUsedComputer(selectedPeriod);

			if (mostUsedComputer != null)
			{
				lblComputerId.Text = $"Computer ID: {mostUsedComputer["ComputerId"]}";
				lblTotalTime.Text = $"Total Time: {mostUsedComputer["TotalTime"]} mins";
				lblEarnings.Text = $"Earnings: ${Convert.ToDecimal(mostUsedComputer["Earnings"]):0.00}";
			}
		}
		private void chart1_Click(object sender, EventArgs e)
		{
			// Chart click event, if needed
		}
		private void generateReport_Click(object sender, EventArgs e)
		{
			ReportOptionsForm reportOptionsForm = new ReportOptionsForm();
			if (reportOptionsForm.ShowDialog() == DialogResult.OK)
			{
				string selectedPeriod = reportOptionsForm.SelectedReportPeriod;

				// Generate the report based on the selected period
				GenerateReport(selectedPeriod);
			}

		}
		private void GenerateReport(string period)
		{
			DataTable reportData;
			string dateCondition = "";

			if (period == "1 Day")
			{
				dateCondition = "WHERE StartTime >= DATEADD(day, -1, GETDATE())";
			}
			else if (period == "1 Week")
			{
				dateCondition = "WHERE StartTime >= DATEADD(week, -1, GETDATE())";
			}
			else if (period == "1 Month")
			{
				dateCondition = "WHERE StartTime >= DATEADD(month, -1, GETDATE())";
			}
			else if (period.Contains("to"))
			{
				string[] dates = period.Split(new string[] { " to " }, StringSplitOptions.None);
				dateCondition = $"WHERE StartTime BETWEEN '{dates[0]}' AND '{dates[1]}'";
			}

			string query = $@"
        SELECT 
            ComputerId, 
			SUM(TotalTime) AS TotalTime,
			SUM(Earnings) AS Earnings 
        FROM PCUsage
        {dateCondition} 
        GROUP BY ComputerId";

			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				SqlDataAdapter da = new SqlDataAdapter(query, conn);
				reportData = new DataTable();
				da.Fill(reportData);
			}

			// Generate PDF
			GeneratePdfReport(reportData, period);
		}

		private void GeneratePdfReport(DataTable reportData, string period)
		{
			string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"PCUsageReport_{DateTime.Now:yyyyMMddHHmmss}.pdf");

			try
			{
				using (PdfWriter writer = new PdfWriter(filePath))
				{
					using (PdfDocument pdf = new PdfDocument(writer))
					{
						Document document = new Document(pdf);
						document.Add(new Paragraph($"PC Usage Report ({period})").SetFontSize(18).SetBold());

						Table table = new Table(UnitValue.CreatePercentArray(new float[] { 1, 2, 2 }))
							.SetWidth(UnitValue.CreatePercentValue(100));

						table.AddHeaderCell("Computer ID");
						table.AddHeaderCell("Total Time (mins)");
						table.AddHeaderCell("Earnings ($)");

						foreach (DataRow row in reportData.Rows)
						{
							table.AddCell(row["ComputerId"].ToString());

							// Handle DBNull for Total Time
							var totalTimeValue = row["TotalTime"];
							string totalTime = totalTimeValue != DBNull.Value ? Convert.ToDecimal(totalTimeValue).ToString() : "0";
							table.AddCell(totalTime);

							// Handle DBNull for Earnings
							var earningsValue = row["Earnings"];
							string earnings = earningsValue != DBNull.Value ? Convert.ToDecimal(earningsValue).ToString("0.00") : "0";
							table.AddCell(earnings);
						}

						document.Add(table);
					}
				}

				MessageBox.Show($"Report generated and saved to {filePath}", "Report Generated", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (PdfException pdfEx)
			{
				MessageBox.Show($"PDF Exception: {pdfEx.Message}\n{pdfEx.StackTrace}", "PDF Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (Exception ex)
			{
				MessageBox.Show($"An error occurred while generating the report: {ex.Message}\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void comboBox_SelectedIndexChanged_1(object sender, EventArgs e)
		{

		}
	}
}
