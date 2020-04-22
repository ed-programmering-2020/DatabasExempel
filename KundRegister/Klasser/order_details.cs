using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KundRegister.Klasser
{
	class order_details
	{
		// Variabelista 
		int OrderID;
		int ProductID;  //Primary key
		double UnitPrice;
		int Quantity;
		double Discount;


		// Datarad till objekt via Konstruktör 
		// Datarad till objekt via Konstruktör 
		public order_details(DataRow dr)
		{
			OrderID = (int)dr["OrderID"];
			ProductID = (int)dr["ProductID"];
			UnitPrice = (double)dr["UnitPrice"];
			Quantity = (int)dr["Quantity"];
			Discount = (double)dr["Discount"];
		}

		// metod för radera detta objekt
		public string GetDeleteQuery()
		{
			return "DELETE from order_details WHERE ProductID = '" + this.ProductID + "'";
		}

	}
}
