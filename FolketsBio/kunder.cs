using MySql.Data.MySqlClient;
using System.Data;
using System;
namespace FolketsBio {

	public class kunder {



		public kunder() { }  // tom standardkonstruktör

		// Variabelista 
		int id;  //Primary key
		string namn;
		DateTime lastlog;


		public static MySqlCommand getAll() {
			MySqlCommand command = new MySqlCommand();
			command.CommandText = " Select * from kunder";
			return command;
		}


		// Datarad till objekt via Konstruktör 
		public kunder(DataRow dr) {
			ID = dr["ID"] == DBNull.Value ? ID = 0 : (int)dr["ID"];
			Namn = dr["Namn"] == DBNull.Value ? Namn = "" : (string)dr["Namn"];
			LastLog = dr["LastLog"] == DBNull.Value ? LastLog = Convert.ToDateTime("01/01/1900") : (DateTime)dr["LastLog"];
		}

		// todo: rätt ToString för att fylla listboxar mm)
		public override string ToString() { return this.namn + "\t( ID: " + this.ID + ")" ; }

		// metod för radera detta objekt
		public MySqlCommand GetDeleteCommand() {
			MySqlCommand command = new MySqlCommand();
			command.CommandText = "DELETE from kunder WHERE ID = @ID";
			command.Parameters.AddWithValue("@ID", ID);
			return command;
		}

		// metod för updatera detta objekt
		public MySqlCommand GetUpdateCommand() {
			MySqlCommand command = new MySqlCommand();
			command.CommandText = " UPDATE kunder SET ID = @ID, Namn = @Namn, LastLog = @LastLog WHERE ID = @ID"; command.Parameters.AddWithValue("@ID", ID);
			command.Parameters.AddWithValue("@Namn", Namn);
			command.Parameters.AddWithValue("@LastLog", LastLog);
			return command;
		}

		// metod för insert detta objekt i DB
		public MySqlCommand GetInsertCommand() {
			MySqlCommand command = new MySqlCommand();
			command.CommandText = "INSERT INTO kunder (ID, Namn, LastLog ) Values (@ID, @Namn, @LastLog)"; command.Parameters.AddWithValue("@ID", ID);
			command.Parameters.AddWithValue("@Namn", Namn);
			command.Parameters.AddWithValue("@LastLog", LastLog);
			return command;
		}


		// Getter och Setter
		public int ID { get { return id; } set { id = value; } }
		public string Namn { get { return namn; } set { namn = value; } }
		public DateTime LastLog { get { return lastlog; } set { lastlog = value; } }
	}
}