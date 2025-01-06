using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RestProject
{
	public partial class ProductInfo : Form
	{
		// Connection string to your SQL Server database
		public string connectionString = @"Data Source=EDONB;Initial Catalog=pcmag;Integrated Security=True";
		private orders _ordersForm;
		public ProductInfo(orders ordersForm)
		{
			InitializeComponent();
			_ordersForm = ordersForm;
		}

		// Submit button click event
		private void btnSubmit_Click(object sender, EventArgs e)
		{
			string productName = txtProductName.Text;
			string productPriceText = txtProductPrice.Text;
			string productImagePath = txtProductImagePath.Text;

			decimal productPrice;
			if (decimal.TryParse(productPriceText, out productPrice))
			{
				AddProduct(productName, productPrice, productImagePath);
				MessageBox.Show("Product added successfully!");

				// Reload products in the Orders form
				//_ordersForm.LoadProducts();

				this.Close(); // Close ProductInfo form after submission
			}
			else
			{
				MessageBox.Show("Please enter a valid price.");
			}
		}

		// Method to add product to the database
		private void AddProduct(string productName, decimal productPrice, string productImagePath)
		{
			string query = "INSERT INTO Products (ProductName, ProductPrice, ProductImagePath) " +
						   "VALUES (@ProductName, @ProductPrice, @ProductImagePath)";

			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					SqlCommand command = new SqlCommand(query, connection);
					command.Parameters.AddWithValue("@ProductName", productName);
					command.Parameters.AddWithValue("@ProductPrice", productPrice);
					command.Parameters.AddWithValue("@ProductImagePath", productImagePath);

					connection.Open();
					int rowsAffected = command.ExecuteNonQuery();

					if (rowsAffected > 0)
					{
						MessageBox.Show("Product added to the database successfully.");
					}
					else
					{
						MessageBox.Show("No rows were inserted.");
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error adding product to database: " + ex.Message);
			}
		}

		// Browse button click event to load an image file
		private void browseButton_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();

			// Set filters to show image files only
			openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

			// Show the dialog and check if the user selected a file
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				// Get the selected file path
				string imagePath = openFileDialog.FileName;

				// Set the file path to the text box
				txtProductImagePath.Text = imagePath;
			}
		}
	}
}
