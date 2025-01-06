using System;
using System.Windows.Forms;

namespace RestProject
{
	public partial class orders : Form
	{
		public double Price { get; private set; }
		public Action<double> OnPriceSelected { get; set; } // Changed to Action<double>
		public string connectionString = @"Data Source=EDONB;Initial Catalog=pcmag;Integrated Security=True"; // Replace with your actual connection string

		public orders()
		{
			InitializeComponent();
		}
		private void pictureCola_Click(object sender, EventArgs e)
		{
			Price = 1.00;
			NotifyPriceSelected();
		}

		private void pictureFanta_Click(object sender, EventArgs e)
		{
			Price = 1.00;
			NotifyPriceSelected();
		}

		private void pictureGolden_Click(object sender, EventArgs e)
		{
			Price = 0.8;
			NotifyPriceSelected();
		}

		private void picturePatos_Click(object sender, EventArgs e)
		{
			Price = 0.5;
			NotifyPriceSelected();
		}

		private void picturePopkek_Click(object sender, EventArgs e)
		{
			Price = 0.5;
			NotifyPriceSelected();
		}

		private void pictureWater_Click(object sender, EventArgs e)
		{
			Price = 0.5;
			NotifyPriceSelected();
		}


		private void NotifyPriceSelected()
		{
			MessageBox.Show($"Product selected. Price: {Price:C}");
			if (OnPriceSelected != null)
			{
				OnPriceSelected(Price);
			}
			else
			{
				MessageBox.Show("No handler for OnPriceSelected");
			}
		}

		private void kryptonButton_Click(object sender, EventArgs e)
		{
			// Notify the selected price when the button is clicked
			NotifyPriceSelected();
		}
		private void kryptonPriceSelect_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Ensure the ComboBox has a selected item
			if (kryptonPriceSelect.SelectedItem != null)
			{
				string value = kryptonPriceSelect.SelectedItem.ToString();
				if (double.TryParse(value, out double parsedPrice))
				{
					Price = parsedPrice; // Set the Price based on ComboBox selection
				}
				else
				{
					MessageBox.Show("Invalid price selected from ComboBox.");
				}
			}
		}

		private void addRemoveProductToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ProductInfo productInfoForm = new ProductInfo(this);  // Pass the Orders form instance
			productInfoForm.ShowDialog();
		}

		private void removeProductToolStripMenuItem_Click(object sender, EventArgs e)
		{
			removeProduct remove = new removeProduct();
			remove.ShowDialog();
		}
	}
}