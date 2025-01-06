using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RestProject
{
	public partial class ChangeCostForm : Form
	{
		public ChangeCostForm()
		{
			InitializeComponent();
		}

		private void ChangeCostForm_Load(object sender, EventArgs e)
		{
			decimal pricePerHour = 0;
			string query = "SELECT SettingValue FROM Settings WHERE SettingKey = 'PricePerHour'";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand(query, connection);
				connection.Open();
				pricePerHour = (decimal)command.ExecuteScalar();
			}

			// Set the value once when the form loads
			numericUpDown.Value = pricePerHour;
		}
		private void applyBtn_Click(object sender, EventArgs e)
		{
			decimal newPricePerHour = numericUpDown.Value;
			UpdatePricePerHourInDatabase(newPricePerHour);
			MessageBox.Show("Settings have been applied successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
			this.Close();
		}
		public string connectionString = (@"Data Source=EDONB;Initial Catalog=pcmag;Integrated Security=True");
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
			return pricePerHour;
		}
		public void UpdatePricePerHourInDatabase(decimal newPrice)
		{

			string query = "UPDATE Settings SET SettingValue = @Price WHERE SettingKey = 'PricePerHour'";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand(query, connection);
				command.Parameters.AddWithValue("@Price", newPrice);
				connection.Open();
				command.ExecuteNonQuery();
			}
		}
	}
}

