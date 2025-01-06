using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;


namespace RestProject
{
	public partial class Form2 : Form
	{
		public Form2()
		{
			InitializeComponent();
		}

		SqlConnection conn = new SqlConnection(@"Data Source=EDONB;Initial Catalog=pcmag;Integrated Security=True");

		private void button1_Click(object sender, EventArgs e)
		{
			String username, password;
			username = userInput.Text;
			password = passInput.Text;

			try
			{
				String query = "SELECT * FROM LoginTab where username = '"+userInput.Text+"' AND password = '"+passInput.Text+"'";
				SqlDataAdapter sda = new SqlDataAdapter(query, conn);
				DataTable dtable = new DataTable();
				sda.Fill(dtable);
				if(dtable.Rows.Count > 0)
				{
					username = userInput.Text;
					password = passInput.Text;

					ballina ball = new ballina();
					ball.Show();

				}
				else
				{
					MessageBox.Show("invalid login details","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
					userInput.Clear();
					passInput.Clear();
					userInput.Focus();
				}
			}
			catch
			{
				MessageBox.Show("Error");
			}
			finally
			{
				conn.Close();
			}
		}
		private void button2_Click(object sender, EventArgs e)
		{
			newAccount newAcc = new newAccount();
			newAcc.ShowDialog();
		}
	}
}
