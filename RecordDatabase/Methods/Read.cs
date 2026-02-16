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
            int rad = 0;
            SqlConnection sqlConnection;
            string connectionString = @"Data Source=MAX-DATOR;Initial Catalog=Vinyls;Integrated Security=True;";
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            String displayQuery = "SELECT * FROM RECORDS";
            SqlCommand viewCommand = new SqlCommand(displayQuery, sqlConnection);
            SqlDataReader dataReader = viewCommand.ExecuteReader();
            while (dataReader.Read())
            {
                //Console.WriteLine("");
                //Console.WriteLine("Artist:" + dataReader.GetValue(1));
                //Console.WriteLine("Album:" + dataReader.GetValue(2));
                //Console.WriteLine("Genre:" + dataReader.GetValue(3));
                //Console.WriteLine("Utgivningsår:" + dataReader.GetValue(4));
                //Console.WriteLine("Betyg 1-10:" + dataReader.GetValue(5));
                //Console.WriteLine("Samlingsnamn:" + dataReader.GetValue(6));
                //Console.WriteLine("");
                rad++;

                Console.WriteLine("=======================================");
                Console.WriteLine("POST #" + rad);
                Console.WriteLine("---------------------------------------");

                Console.WriteLine(" ARTIST ............ : " + dataReader.GetValue(1));
                Console.WriteLine(" ALBUM ............. : " + dataReader.GetValue(2));
                Console.WriteLine(" GENRE ............. : " + dataReader.GetValue(3));
                Console.WriteLine(" UTGIVNINGSÅR ...... : " + dataReader.GetValue(4));
                Console.WriteLine(" BETYG (1-10) ...... : " + dataReader.GetValue(5));
                Console.WriteLine(" SAMLINGSNAMN ...... : " + dataReader.GetValue(6));

                Console.WriteLine("=======================================");
                Console.WriteLine();
                Console.WriteLine(">> TRYCK TANGENT FÖR NÄSTA POST  |  ESC = AVBRYT");

                var key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Escape)
                    break;

                Console.Clear();
                Console.WriteLine("MAX SYSTEM v1.0  - DATASCAN");
                Console.WriteLine("LÄSER NÄSTA POST...");
                Console.WriteLine();
            }
            dataReader.Close();
        }

    }
}
