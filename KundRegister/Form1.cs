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
using MySql.Data.MySqlClient;
using KundRegister.Klasser;

namespace KundRegister
{
	public partial class Form1 : Form
	{
		string connectionString =
				"SERVER=localhost;DATABASE=programmering2;UID=elev;PASSWORD=jordgubb;";

		public Form1()
		{
			InitializeComponent();
			
		}

		private void button1_Click(object sender, EventArgs e)
		{
			MySqlConnection connection;  // objekt i library MySql.Data.MySqlClient

			//alla connection data i en enda sträng
			
		

			connection = new MySqlConnection(connectionString);
			connection.Open();

			string sqlsats = "Select Kund_ID,FirmaNamn,Omsattning from kunder";
			lblSQLsats.Text = sqlsats;
			//Skapa SQL-kommando
			MySqlCommand cmd = new MySqlCommand(sqlsats, connection);

			//Skapa data reader och utför kommando
			MySqlDataAdapter dataReader = new MySqlDataAdapter(sqlsats, connection);
			DataTable dt = new DataTable();
			dataReader.Fill(dt);

			DataRow dr = dt.Rows[0];
			

			kunder tbknd = new kunder(dr);

			dataGridView1.DataSource = dt;

			connection.Close();
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
						
		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{

		}

		private void lblSQLsats_Click(object sender, EventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{
		kunder ralf = new kunder();
			lblSQLsats.Text = (ralf.GetUpdateQuery());
		}
	}
}
