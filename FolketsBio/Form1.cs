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

namespace FolketsBio {
	public partial class Form1 : Form {

		string ConnString = "SERVER=localhost;DATABASE=folketsbio;UID=elev;PASSWORD=jordgubb;";

		List<kunder> AllaKunder;
		kunder aktuellKund;


		public Form1() {
			InitializeComponent();
			AllaKunder = new List<kunder>();

		}

		private void button1_Click(object sender, EventArgs e) {

			MySqlConnection connection = new MySqlConnection(ConnString);
			connection.Open();

			MySqlCommand cmd = kunder.getAll();  //statisk metod
			MySqlDataAdapter datAdapt = new MySqlDataAdapter();
			datAdapt.SelectCommand = cmd;
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

			aktuellKund = (kunder)listBox1.SelectedItem;
			int dagar = (DateTime.Now - aktuellKund.LastLog).Days;
			label1.Text = aktuellKund.Namn + "\t lastlog: " + aktuellKund.LastLog.ToShortDateString() + " ( för " + dagar + " dagar  sedan)";

		}
	}
}
