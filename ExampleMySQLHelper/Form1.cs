using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExampleMySQLHelper {
	public partial class Form1 : Form {

		string ConnString = "SERVER=localhost;DATABASE=programmering2;UID=elev;PASSWORD=jordgubb;";

		List<kunder> AllaKunder;

		public Form1() {
			InitializeComponent();
			AllaKunder = new List<kunder>();
		}

		private void button1_Click(object sender, EventArgs e) {
			
		MySqlConnection connection = new MySqlConnection(ConnString);
			connection.Open();
			
			MySqlCommand cmd = kunder.getAll();	 //statisk metod
			MySqlDataAdapter datAdapt = new MySqlDataAdapter();
			datAdapt.SelectCommand=cmd;
			cmd.Connection = connection; 
			DataTable dt = new DataTable();
			datAdapt.Fill(dt);

			

			foreach (DataRow row in dt.Rows) {
				AllaKunder.Add(new kunder(row));
			}
			listBox1.DataSource = AllaKunder;
			connection.Close();
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
			kunder k = (kunder)listBox1.SelectedItem;

			MySqlConnection connection = new MySqlConnection(ConnString);
			connection.Open();

			k.Omsattning = 0; 

			MySqlCommand cmd =  k.GetUpdateCommand();
			cmd.Connection = connection;
			cmd.ExecuteNonQuery();
			connection.Close();

			
		}

		private void button2_Click(object sender, EventArgs e) {

			kunder k = new kunder();
			k.FirmaNamn = "Raffes Korvkiosk";
			k.Kund_ID = "RAFFE";
			k.Omsattning = 1000; 
			MySqlConnection connection = new MySqlConnection(ConnString);
			connection.Open();
			MySqlCommand cmd = k.GetInsertCommand(); 
			cmd.Connection = connection;
			try {
				cmd.ExecuteNonQuery();
			}
			catch(MySqlException exc){
				MessageBox.Show(exc.Message); 
			}
			connection.Close();



		}
	}
}
