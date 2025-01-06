using System;
using System.Windows.Forms;

namespace RestProject
{
	public partial class ballina : Form
	{
		public ballina()
		{
			InitializeComponent();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			pcManagment pcManagment = new pcManagment();
			pcManagment.ShowDialog();
		}

		private void button7_Click(object sender, EventArgs e)
		{
			Form2 form2 = new Form2();
			form2.ShowDialog();
			this.Close();

		}

		private void button5_Click(object sender, EventArgs e)
		{
			//settings settings = new settings();
			//settings.ShowDialog();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			pcUsage pcusage = new pcUsage();
			pcusage.Show();
		}

		private void pictureBox2_Click(object sender, EventArgs e)
		{
			pcUsage pcusage = new pcUsage();
			pcusage.Show();
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			pcManagment pcManagment = new pcManagment();
			pcManagment.ShowDialog();
		}
	}
}
