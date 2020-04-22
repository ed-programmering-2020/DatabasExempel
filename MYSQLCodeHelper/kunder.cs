using MySql.Data.MySqlClient;
using System.Data;

namespace MYSQLCodeHelper {

    public class kunder {



        public kunder() { }  // tom standardkonstruktör

        // Variabelista 
        string kund_id;  //Primary key
        string firmanamn;
        string kontaktnamn;
        string kontakttitel;
        string address;
        string stad;
        string region;
        string postnummer;
        string land;
        string telefon;
        string fax;
        int omsattning;


        // Datarad till objekt via Konstruktör 
        public kunder(DataRow dr) {
            Kund_ID = (string)dr["Kund_ID"];
            FirmaNamn = (string)dr["FirmaNamn"];
            KontaktNamn = (string)dr["KontaktNamn"];
            KontaktTitel = (string)dr["KontaktTitel"];
            Address = (string)dr["Address"];
            Stad = (string)dr["Stad"];
            Region = (string)dr["Region"];
            PostNummer = (string)dr["PostNummer"];
            Land = (string)dr["Land"];
            Telefon = (string)dr["Telefon"];
            Fax = (string)dr["Fax"];
            Omsattning = (int)dr["Omsattning"];
        }

        // metod för radera detta objekt
        public MySqlCommand GetDeleteQuery() {
            MySqlCommand command = new MySqlCommand();
            command.CommandText = "DELETE from kunder WHERE Kund_ID = @Kund_ID";
            command.Parameters.AddWithValue("@Kund_ID", Kund_ID);
            return command;
        }

        // metod för updatera detta objekt
        public MySqlCommand GetUpdateQuery() {
            MySqlCommand command = new MySqlCommand();
            command.CommandText = " UPDATE kunder SET Kund_ID = @Kund_ID, FirmaNamn = @FirmaNamn, KontaktNamn = @KontaktNamn, KontaktTitel = @KontaktTitel, Address = @Address, Stad = @Stad, Region = @Region, PostNummer = @PostNummer, Land = @Land, Telefon = @Telefon, Fax = @Fax, Omsattning = @OmsattningWHERE Kund_ID = @Kund_ID"; command.Parameters.AddWithValue("@Kund_ID", Kund_ID);
            command.Parameters.AddWithValue("@FirmaNamn", FirmaNamn);
            command.Parameters.AddWithValue("@KontaktNamn", KontaktNamn);
            command.Parameters.AddWithValue("@KontaktTitel", KontaktTitel);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Stad", Stad);
            command.Parameters.AddWithValue("@Region", Region);
            command.Parameters.AddWithValue("@PostNummer", PostNummer);
            command.Parameters.AddWithValue("@Land", Land);
            command.Parameters.AddWithValue("@Telefon", Telefon);
            command.Parameters.AddWithValue("@Fax", Fax);
            command.Parameters.AddWithValue("@Omsattning", Omsattning);
            return command;
        }

        // metod för insert detta objekt i DB
        public MySqlCommand GetInsertQuery() {
            MySqlCommand command = new MySqlCommand();
            command.CommandText = "INSERT INTO kunder (Kund_ID, FirmaNamn, KontaktNamn, KontaktTitel, Address, Stad, Region, PostNummer, Land, Telefon, Fax, Omsattning ) Values (@Kund_ID, @FirmaNamn, @KontaktNamn, @KontaktTitel, @Address, @Stad, @Region, @PostNummer, @Land, @Telefon, @Fax, @Omsattning)"; command.Parameters.AddWithValue("@Kund_ID", Kund_ID);
            command.Parameters.AddWithValue("@FirmaNamn", FirmaNamn);
            command.Parameters.AddWithValue("@KontaktNamn", KontaktNamn);
            command.Parameters.AddWithValue("@KontaktTitel", KontaktTitel);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Stad", Stad);
            command.Parameters.AddWithValue("@Region", Region);
            command.Parameters.AddWithValue("@PostNummer", PostNummer);
            command.Parameters.AddWithValue("@Land", Land);
            command.Parameters.AddWithValue("@Telefon", Telefon);
            command.Parameters.AddWithValue("@Fax", Fax);
            command.Parameters.AddWithValue("@Omsattning", Omsattning);
            return command;
        }


        // Getter och Setter
        public string Kund_ID { get { return kund_id; } set { kund_id = value; } }
        public string FirmaNamn { get { return firmanamn; } set { firmanamn = value; } }
        public string KontaktNamn { get { return kontaktnamn; } set { kontaktnamn = value; } }
        public string KontaktTitel { get { return kontakttitel; } set { kontakttitel = value; } }
        public string Address { get { return address; } set { address = value; } }
        public string Stad { get { return stad; } set { stad = value; } }
        public string Region { get { return region; } set { region = value; } }
        public string PostNummer { get { return postnummer; } set { postnummer = value; } }
        public string Land { get { return land; } set { land = value; } }
        public string Telefon { get { return telefon; } set { telefon = value; } }
        public string Fax { get { return fax; } set { fax = value; } }
        public int Omsattning { get { return omsattning; } set { omsattning = value; } }
    }
}