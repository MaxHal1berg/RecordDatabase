using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordDatabase.Methods
{
    internal class Delete
    {
        public static void Remove() 
        {
            SqlConnection sqlConnection;
            string connectionString = @"Data Source=DESKTOP-KILJFHC;Initial Catalog=Vinyls;Integrated Security=True;TrustServerCertificate=True";
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            Console.WriteLine("Skriv in ID för skivan du vill ta bort!");
            int vinyl_ID = Convert.ToInt32(Console.ReadLine());
            string deleteQuery = "DELETE FROM RECORDS WHERE VinylID = " + vinyl_ID + "";
            SqlCommand deleteCommand = new SqlCommand(deleteQuery, sqlConnection);
            deleteCommand.ExecuteNonQuery();
            Console.WriteLine("Då var den skivan borttagen!");
        }
    }
}
