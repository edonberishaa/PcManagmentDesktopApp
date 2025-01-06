using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RestProject
{
	public partial class removeProduct : Form
	{
		public string connectionString = @"Data Source=EDONB;Initial Catalog=pcmag;Integrated Security=True"; // Your connection string

		public removeProduct()
		{
			InitializeComponent();
			LoadProductsIntoComboBox();
		}
		private void LoadProductsIntoComboBox()
		{
			string query = "SELECT ProductName FROM Products";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand(query, connection);
				connection.Open();
				SqlDataReader reader = command.ExecuteReader();
				while (reader.Read())
				{
					// Add each product name to the ComboBox
					comboBox.Items.Add(reader["ProductName"].ToString());
				}
				connection.Close();
			}
		}
		private void btnSubmit_Click(object sender, EventArgs e)
		{
			if (comboBox.SelectedItem != null)
			{
				string selectedProductName = comboBox.SelectedItem.ToString();
				RemoveProductFromDatabase(selectedProductName);
			}
			else
			{
				MessageBox.Show("Please select a product to remove.");
			}
		}
		private void RemoveProductFromDatabase(string productName)
		{
			string query = "DELETE FROM Products WHERE ProductName = @ProductName";

			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					SqlCommand command = new SqlCommand(query, connection);
					command.Parameters.AddWithValue("@ProductName", productName);

					connection.Open();
					int rowsAffected = command.ExecuteNonQuery();
					connection.Close();

					if (rowsAffected > 0)
					{
						MessageBox.Show("Product removed successfully!");
						comboBox.Items.Remove(productName); // Remove the product from ComboBox after deletion
					}
					else
					{
						MessageBox.Show("No product found with the given name.");
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error removing product: " + ex.Message);
			}
		}
	}
}