using MySql.Data.MySqlClient;
using System.Data;
using System;
namespace MYSQLCodeHelper {

    public class orders {



        public orders() { }  // tom standardkonstruktör

        // Variabelista 
        int orderid;  //Primary key
        string customerid;
        int employeeid;
        DateTime orderdate;
        DateTime requireddate;
        DateTime shippeddate;
        int shipvia;
        double freight;
        string shipname;
        string shipaddress;
        string shipcity;
        string shipregion;
        string shippostalcode;
        string shipcountry;


        public static MySqlCommand getAll() {
            MySqlCommand command = new MySqlCommand();
            command.CommandText = " Select * from orders";
            return command;
        }


        // Datarad till objekt via Konstruktör 
        public orders(DataRow dr) {
            OrderID = dr["OrderID"] == DBNull.Value ? OrderID = 0 : (int)dr["OrderID"];
            CustomerID = dr["CustomerID"] == DBNull.Value ? CustomerID = "" : (string)dr["CustomerID"];
            EmployeeID = dr["EmployeeID"] == DBNull.Value ? EmployeeID = 0 : (int)dr["EmployeeID"];
            OrderDate = dr["OrderDate"] == DBNull.Value ? OrderDate = Convert.ToDateTime("01/01/1900") : (DateTime)dr["OrderDate"];
            RequiredDate = dr["RequiredDate"] == DBNull.Value ? RequiredDate = Convert.ToDateTime("01/01/1900") : (DateTime)dr["RequiredDate"];
            ShippedDate = dr["ShippedDate"] == DBNull.Value ? ShippedDate = Convert.ToDateTime("01/01/1900") : (DateTime)dr["ShippedDate"];
            ShipVia = dr["ShipVia"] == DBNull.Value ? ShipVia = 0 : (int)dr["ShipVia"];
            ShipName = dr["ShipName"] == DBNull.Value ? ShipName = "" : (string)dr["ShipName"];
            ShipAddress = dr["ShipAddress"] == DBNull.Value ? ShipAddress = "" : (string)dr["ShipAddress"];
            ShipCity = dr["ShipCity"] == DBNull.Value ? ShipCity = "" : (string)dr["ShipCity"];
            ShipRegion = dr["ShipRegion"] == DBNull.Value ? ShipRegion = "" : (string)dr["ShipRegion"];
            ShipPostalCode = dr["ShipPostalCode"] == DBNull.Value ? ShipPostalCode = "" : (string)dr["ShipPostalCode"];
            ShipCountry = dr["ShipCountry"] == DBNull.Value ? ShipCountry = "" : (string)dr["ShipCountry"];
        }

        // todo: rätt ToString för att fylla listboxar mm)
        public override string ToString() { return "Not implemented yet"; }

        // metod för radera detta objekt
        public MySqlCommand GetDeleteCommand() {
            MySqlCommand command = new MySqlCommand();
            command.CommandText = "DELETE from orders WHERE OrderID = @OrderID";
            command.Parameters.AddWithValue("@OrderID", OrderID);
            return command;
        }

        // metod för updatera detta objekt
        public MySqlCommand GetUpdateCommand() {
            MySqlCommand command = new MySqlCommand();
            command.CommandText = " UPDATE orders SET OrderID = @OrderID, CustomerID = @CustomerID, EmployeeID = @EmployeeID, OrderDate = @OrderDate, RequiredDate = @RequiredDate, ShippedDate = @ShippedDate, ShipVia = @ShipVia, Freight = @Freight, ShipName = @ShipName, ShipAddress = @ShipAddress, ShipCity = @ShipCity, ShipRegion = @ShipRegion, ShipPostalCode = @ShipPostalCode, ShipCountry = @ShipCountry WHERE OrderID = @OrderID"; command.Parameters.AddWithValue("@OrderID", OrderID);
            command.Parameters.AddWithValue("@CustomerID", CustomerID);
            command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            command.Parameters.AddWithValue("@OrderDate", OrderDate);
            command.Parameters.AddWithValue("@RequiredDate", RequiredDate);
            command.Parameters.AddWithValue("@ShippedDate", ShippedDate);
            command.Parameters.AddWithValue("@ShipVia", ShipVia);
            command.Parameters.AddWithValue("@Freight", Freight);
            command.Parameters.AddWithValue("@ShipName", ShipName);
            command.Parameters.AddWithValue("@ShipAddress", ShipAddress);
            command.Parameters.AddWithValue("@ShipCity", ShipCity);
            command.Parameters.AddWithValue("@ShipRegion", ShipRegion);
            command.Parameters.AddWithValue("@ShipPostalCode", ShipPostalCode);
            command.Parameters.AddWithValue("@ShipCountry", ShipCountry);
            return command;
        }

        // metod för insert detta objekt i DB
        public MySqlCommand GetInsertCommand() {
            MySqlCommand command = new MySqlCommand();
            command.CommandText = "INSERT INTO orders (OrderID, CustomerID, EmployeeID, OrderDate, RequiredDate, ShippedDate, ShipVia, Freight, ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, ShipCountry ) Values (@OrderID, @CustomerID, @EmployeeID, @OrderDate, @RequiredDate, @ShippedDate, @ShipVia, @Freight, @ShipName, @ShipAddress, @ShipCity, @ShipRegion, @ShipPostalCode, @ShipCountry)"; command.Parameters.AddWithValue("@OrderID", OrderID);
            command.Parameters.AddWithValue("@CustomerID", CustomerID);
            command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            command.Parameters.AddWithValue("@OrderDate", OrderDate);
            command.Parameters.AddWithValue("@RequiredDate", RequiredDate);
            command.Parameters.AddWithValue("@ShippedDate", ShippedDate);
            command.Parameters.AddWithValue("@ShipVia", ShipVia);
            command.Parameters.AddWithValue("@Freight", Freight);
            command.Parameters.AddWithValue("@ShipName", ShipName);
            command.Parameters.AddWithValue("@ShipAddress", ShipAddress);
            command.Parameters.AddWithValue("@ShipCity", ShipCity);
            command.Parameters.AddWithValue("@ShipRegion", ShipRegion);
            command.Parameters.AddWithValue("@ShipPostalCode", ShipPostalCode);
            command.Parameters.AddWithValue("@ShipCountry", ShipCountry);
            return command;
        }


        // Getter och Setter
        public int OrderID { get { return orderid; } set { orderid = value; } }
        public string CustomerID { get { return customerid; } set { customerid = value; } }
        public int EmployeeID { get { return employeeid; } set { employeeid = value; } }
        public DateTime OrderDate { get { return orderdate; } set { orderdate = value; } }
        public DateTime RequiredDate { get { return requireddate; } set { requireddate = value; } }
        public DateTime ShippedDate { get { return shippeddate; } set { shippeddate = value; } }
        public int ShipVia { get { return shipvia; } set { shipvia = value; } }
        public double Freight { get { return freight; } set { freight = value; } }
        public string ShipName { get { return shipname; } set { shipname = value; } }
        public string ShipAddress { get { return shipaddress; } set { shipaddress = value; } }
        public string ShipCity { get { return shipcity; } set { shipcity = value; } }
        public string ShipRegion { get { return shipregion; } set { shipregion = value; } }
        public string ShipPostalCode { get { return shippostalcode; } set { shippostalcode = value; } }
        public string ShipCountry { get { return shipcountry; } set { shipcountry = value; } }
    }
}