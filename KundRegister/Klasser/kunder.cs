using System.Data;

namespace KundRegister.Klasser 
{

	public class kunder
	{

		// Variabelista 
		string Kund_ID;  //Primary key
		string FirmaNamn;
		string KontaktNamn;
		string KontaktTitel;
		string Address;
		string Stad;
		string Region;
		string PostNummer;
		string Land;
		string Telefon;
		string Fax;
		int Omsattning;


		// Datarad till objekt via Konstruktör 
		public kunder(DataRow dr)
		{
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
		public string GetDeleteQuery()
		{
			return "DELETE from kunder WHERE Kund_ID = '" + this.Kund_ID + "'";
		}


		// metod för updatera detta objekt
		public string GetUpdateQuery()
		{
			return " UPDATE kunder SET Kund_ID = '" + this.Kund_ID + "', FirmaNamn = '" + this.FirmaNamn + "', KontaktNamn = '" + this.KontaktNamn + "', KontaktTitel = '" + this.KontaktTitel + "', Address = '" + this.Address + "', Stad = '" + this.Stad + "', Region = '" + this.Region + "', PostNummer = '" + this.PostNummer + "', Land = '" + this.Land + "', Telefon = '" + this.Telefon + "', Fax = '" + this.Fax + "', Omsattning = '" + this.Omsattning + "' WHERE Kund_ID = '" + this.Kund_ID + "'";
		}

		// metod för insert detta objekt i DB
		public string GetInsertQuery()
		{
			return " INSERT INTO kunder (Kund_ID, FirmaNamn, KontaktNamn, KontaktTitel, Address, Stad, Region, PostNummer, Land, Telefon, Fax, Omsattning ) Values ('" + this.Kund_ID + "', '" + this.FirmaNamn + "', '" + this.KontaktNamn + "', '" + this.KontaktTitel + "', '" + this.Address + "', '" + this.Stad + "', '" + this.Region + "', '" + this.PostNummer + "', '" + this.Land + "', '" + this.Telefon + "', '" + this.Fax + "', '" + this.Omsattning + "')";
		}
	}
}