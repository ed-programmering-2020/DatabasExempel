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

namespace MYSQLCodeHelper
{
	public partial class Form1 : Form
	{

		MySqlConnection connection;
		MySqlDataReader dataReader = null;
		string nl = Environment.NewLine;
		string primaryName, primaryType; 
		Dictionary<string, string> replacements =null; 
		public Form1()
		{
			InitializeComponent();
			replacements = new Dictionary<string, string>();

			replacements.Add("System.String", "string");
			replacements.Add("System.Int32", "int");
			replacements.Add("System.Int16", "int");
			replacements.Add("System.Decimal", "double");
			replacements.Add("System.Double", "double"); 
			replacements.Add("System.DateTime", "DateTime");
			replacements.Add("System.UInt64", "bool");
			replacements.Add("System.UInt32", "int");
			//replacements.Add()
			tbxConnectString.Text = Properties.Settings.Default.ConnectionString;
			tbxNamespace.Text = Properties.Settings.Default.Usernamespace;
		}

		private void btnConnect_Click(object sender, EventArgs e)
		{
			connection = new MySqlConnection(tbxConnectString.Text);
			connection.Open();

			string sqlsats = "SHOW Tables";
			//Skapa SQL-kommando
			MySqlCommand cmd = new MySqlCommand(sqlsats, connection);
			dataReader = cmd.ExecuteReader();
			
			while(dataReader.Read() ){
				lstbTables.Items.Add(dataReader.GetString(0));
			}
			dataReader.Close();
			connection.Close();

			

		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			Properties.Settings.Default.ConnectionString = tbxConnectString.Text;
			Properties.Settings.Default.Usernamespace = tbxNamespace.Text;
			Properties.Settings.Default.Save();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			
		}

		private void Form1_Load(object sender, EventArgs e) {

		}

		private void button1_Click_1(object sender, EventArgs e) {
			Form2 f2 = new Form2();
			kunder k = new kunder() { FirmaNamn = "Raffes korvkiosk", Kund_ID = "RAFFE" };
			
			f2.ReadOnlyProps = new List<string>() { "Kund_ID", "Omsattning" };
			f2.SelectedObject = k;
			if (DialogResult.OK == f2.ShowDialog()) {
				MessageBox.Show("OK");
			}
			else MessageBox.Show("NOPE");
		}

		private void lstbTables_SelectedIndexChanged(object sender, EventArgs e)
		{
			string table = lstbTables.SelectedItem.ToString();

			connection = new MySqlConnection(tbxConnectString.Text);
			connection.Open();

			string getPrimary = "SHOW COLUMNS FROM " + table; 
			MySqlCommand cmd = new MySqlCommand(getPrimary, connection);
			
			dataReader = cmd.ExecuteReader();

			while (dataReader.Read())
			{
				if (dataReader["Key"].Equals("PRI")) {
					primaryName = dataReader.GetString("Field");

					if (dataReader.GetString("Type").StartsWith("varchar")) {
						primaryType = "string";
					} else {
						primaryType = "int";
					}

				}
			}
			dataReader.Close();
			tbxResult.Text = primaryName + ":" + primaryType;

			string sqlsats = "SELECT * from  " + table + " LIMIT 1";
			//Skapa SQL-kommando
			cmd = new MySqlCommand(sqlsats, connection);
			dataReader = cmd.ExecuteReader();

			var columns = new List<string>();
			var columnsLow = new List<string>();
			for (int i = 0; i < dataReader.FieldCount; i++) {
				columns.Add(dataReader.GetName(i));
				columnsLow.Add(dataReader.GetName(i).ToLower());
			}

				tbxResult.Clear();
			tbxResult.AppendText("using MySql.Data.MySqlClient;" + nl);
			tbxResult.AppendText("using System.Data;" + nl); 
			tbxResult.AppendText("using System;" + nl);
			tbxResult.AppendText("namespace " + tbxNamespace.Text + nl + "{");
			tbxResult.AppendText(nl + nl);
			tbxResult.AppendText("public class " + table + nl + "{" + nl + nl);
			tbxResult.AppendText(nl + nl);
			tbxResult.AppendText("public " + table + "(){}  // tom standardkonstruktör");
			tbxResult.AppendText(nl + nl);     
			
			//Variabellista
			List<string> GetSet = new List<string>();

			tbxResult.AppendText("// Variabelista " + nl);
			foreach (string s in columns)
			{
				tbxResult.AppendText(replacements[dataReader.GetFieldType(s).ToString()] + " " + s.ToLower() + ";");
				GetSet.Add("public " + replacements[dataReader.GetFieldType(s).ToString()] + " "
				+ s + "{ get { return " + s.ToLower() + "; }  set {" + s.ToLower() + " = value;} }");
				if (s.Equals(primaryName))
					tbxResult.AppendText("  //Primary key" + nl);
				else
					tbxResult.AppendText(nl);

			}

			tbxResult.AppendText(nl + nl);

			tbxResult.AppendText("public static MySqlCommand getAll() {" + nl);
			tbxResult.AppendText("MySqlCommand command = new MySqlCommand();" + nl);
			tbxResult.AppendText("command.CommandText = \" Select * from " + table + "\";" + nl);
			tbxResult.AppendText("return command;" + nl + "}" + nl);
			tbxResult.AppendText(nl + nl);
			// Row to object
			tbxResult.AppendText("// Datarad till objekt via Konstruktör " + nl);
			tbxResult.AppendText("public " + table + "(DataRow dr){ " + nl);
			foreach (string s in columns) {
				string conv = replacements[dataReader.GetFieldType(s).ToString()];

				// KontaktTitel =  dr["KontaktTitel"] == DBNull.Value ? KontaktTitel = "" : (string)dr["KontaktTitel"];
				//
				if (conv == "DateTime")
					tbxResult.AppendText("\t" + s + "\t= " + "dr[\"" + s + "\"] == DBNull.Value ? " + s + "= Convert.ToDateTime(\"01/01/1900\") \t: (" + conv + ") dr[\"" + s + "\"];" + nl);

					

				if (conv == "int")
					tbxResult.AppendText("\t" + s + "\t= " + "dr[\"" + s + "\"] == DBNull.Value ? " + s + "= 0 \t: (" + conv + ") dr[\"" + s + "\"];" + nl);


				if (conv == "string")
				tbxResult.AppendText("\t" + s + "\t= " + "dr[\"" + s + "\"] == DBNull.Value ? " + s + "= \"\" \t: (" + conv + ") dr[\"" + s + "\"];" + nl);
			}
			tbxResult.AppendText("}");

			tbxResult.AppendText(nl + nl);
			tbxResult.AppendText("// todo: rätt ToString för att fylla listboxar mm)" + nl);
			tbxResult.AppendText("public override string ToString() { return \"Not implemented yet\";}");
			tbxResult.AppendText(nl + nl);



			tbxResult.AppendText("// metod för radera detta objekt" + nl);
			tbxResult.AppendText("public MySqlCommand GetDeleteCommand(){" + nl);
			tbxResult.AppendText("MySqlCommand command = new MySqlCommand();" + nl);
			tbxResult.AppendText("command.CommandText = \"DELETE from " + table + " WHERE " + primaryName + " = @" + primaryName +"\";" + nl );
			tbxResult.AppendText(" command.Parameters.AddWithValue(\"@" + primaryName + "\", " + primaryName + "); " + nl);
			tbxResult.AppendText("return command; " + nl + "\t}");


			tbxResult.AppendText(nl + nl);
			tbxResult.AppendText("// metod för updatera detta objekt" + nl);
			tbxResult.AppendText("public MySqlCommand GetUpdateCommand(){" + nl);
			tbxResult.AppendText("MySqlCommand command = new MySqlCommand();" +nl);
			tbxResult.AppendText("command.CommandText = \" UPDATE " + table + " SET ");

			int count = 0;
			foreach (string c in columns) {
				count++;
				if (count == columns.Count)
					tbxResult.AppendText(c + " = @"  + c );
				else
					tbxResult.AppendText(c + " = @" + c +", ");
			}
			tbxResult.AppendText(" WHERE " + primaryName + " = @" + primaryName + "\";" );
			foreach (string c in columns) {

				tbxResult.AppendText(" command.Parameters.AddWithValue(\"@" + c + "\", " + c + "); " + nl) ;
			}
			tbxResult.AppendText("return command; " + nl + "\t}");


				// generera GetInsertQuery
				tbxResult.AppendText(nl + nl);
			tbxResult.AppendText("// metod för insert detta objekt i DB" + nl);
			tbxResult.AppendText("public MySqlCommand GetInsertCommand(){" + nl);
			tbxResult.AppendText("MySqlCommand command = new MySqlCommand();" + nl);
			tbxResult.AppendText("command.CommandText = \"INSERT INTO " + table + " (");
			tbxResult.AppendText(String.Join(", ", columns.ToArray()) + " ) Values (");
			count = 0;
			foreach (string c in columns) { 
			count++;
			if (count == columns.Count)
				tbxResult.AppendText("@" + c +")\";");
				else
					tbxResult.AppendText("@" + c + ", ");
			}
			foreach (string c in columns) {

				tbxResult.AppendText(" command.Parameters.AddWithValue(\"@" + c + "\", " + c + "); " + nl);
			}
			tbxResult.AppendText("return command; " + nl + "\t}"+ nl + nl);

			tbxResult.AppendText( nl + "// Getter och Setter" + nl);
			foreach (string s in GetSet){
				tbxResult.AppendText(s + nl); 
			}

			tbxResult.AppendText( "}" + nl + "}"); 


					connection.Close();
		}
	}
}
