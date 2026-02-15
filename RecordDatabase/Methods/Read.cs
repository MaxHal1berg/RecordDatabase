using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordDatabase.Methods
{
    internal class Read
    {
        public static void Get() 
        {
            SqlConnection sqlConnection;
            string connectionString = @"Data Source=MAX-DATOR;Initial Catalog=Vinyls;Integrated Security=True;";
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            String displayQuery = "SELECT * FROM RECORDS";
            SqlCommand viewCommand = new SqlCommand(displayQuery, sqlConnection);
            SqlDataReader dataReader = viewCommand.ExecuteReader();
            while (dataReader.Read())
            {
                Console.WriteLine("");
                Console.WriteLine("ID:" + dataReader.GetValue(0));
                Console.WriteLine("Artist:" + dataReader.GetValue(1));
                Console.WriteLine("Album:" + dataReader.GetValue(2));
                Console.WriteLine("Genre:" + dataReader.GetValue(3));
                Console.WriteLine("Utgivningsår:" + dataReader.GetValue(4));
                Console.WriteLine("Betyg 1-10:" + dataReader.GetValue(5));
                Console.WriteLine("Samlingsnamn:" + dataReader.GetValue(6));
                Console.WriteLine("");
            }
            dataReader.Close();
        }

    }
}
