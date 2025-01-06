using System;
using System.Drawing;
using System.Windows.Forms;

namespace RestProject
{
	public partial class ReportOptionsForm : Form
	{
		public string SelectedReportPeriod { get; private set; } // To hold the selected period

		public ReportOptionsForm()
		{
			InitializeComponent();
			SetupForm();
		}
		private void SetupForm()
		{
			// Initialize ComboBox for selecting report period
			ComboBox comboBoxPeriod = new ComboBox();
			comboBoxPeriod.DropDownStyle = ComboBoxStyle.DropDownList; // Make ComboBox non-editable
			comboBoxPeriod.Items.AddRange(new object[] { "1 Day", "1 Week", "1 Month" });
			comboBoxPeriod.SelectedIndex = 0; // Default to "1 Day"
			comboBoxPeriod.Location = new Point(20, 45);
			comboBoxPeriod.Size = new Size(150, 30); // Increased size of ComboBox
			comboBoxPeriod.Font = new Font(comboBoxPeriod.Font.FontFamily, 10); // Set bigger font size
			Controls.Add(comboBoxPeriod);

			// Initialize Generate button
			Button btnGenerate = new Button();
			btnGenerate.Text = "Generate Report";
			btnGenerate.Location = new Point(200, 35); // Adjusted position
			btnGenerate.Size = new Size(135, 45); // Increased size of button
			btnGenerate.Font = new Font(btnGenerate.Font.FontFamily, 10); // Set bigger font size
			btnGenerate.Click += (s, e) =>
			{
					SelectedReportPeriod = comboBoxPeriod.SelectedItem.ToString();

				this.DialogResult = DialogResult.OK; // Indicate the form was closed successfully
				this.Close(); // Close the form
			};
			Controls.Add(btnGenerate);
		}
    }
}
