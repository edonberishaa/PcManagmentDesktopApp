using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RestProject
{
	public partial class newAccount : Form
	{
		public newAccount()
		{
			InitializeComponent();
		}

			private void createBtn_Click(object sender, EventArgs e)
			{
				string username = userInput.Text;
				string password = passInput.Text;
				// SQL query to insert user data into the database
				string query = "INSERT INTO LoginTab (username, password) VALUES (@username, @password)";
			SqlConnection conn = new SqlConnection(@"Data Source=EDONB;Initial Catalog=pcmag;Integrated Security=True");

			// Establish connection and command
			using (conn)
				{
					using (SqlCommand cmd = new SqlCommand(query, conn))
					{
						// Add parameters to prevent SQL injection
						cmd.Parameters.AddWithValue("@Username", username);
						cmd.Parameters.AddWithValue("@Password", password);

						// Open connection and execute query
						try
						{
							conn.Open();
							int rowsAffected = cmd.ExecuteNonQuery();
							if (rowsAffected > 0)
							{
								MessageBox.Show("User signed up successfully!");
							Form2 form2 = new Form2();
							form2.ShowDialog();
								userInput.Text = "";
								passInput.Text = "";
							}
						}
						catch (Exception ex)
						{
							MessageBox.Show("Error: " + ex.Message);
						}
					}
				}
			}
		private void newAccount_Load(object sender, EventArgs e)
		{
			userInput.Focus();
		}

        private void userInput_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
