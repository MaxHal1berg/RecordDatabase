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
            string connectionString = @"Data Source=MAX-DATOR;Initial Catalog=Vinyls;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Read.Get();
                connection.Open();

                Console.WriteLine("=======================================");
                Console.WriteLine("Skriv in artistens namn:");
                Console.WriteLine("=======================================");
                string artist = Console.ReadLine();

                Console.WriteLine("=======================================");
                Console.WriteLine("Skriv in albumets namn:");
                Console.WriteLine("=======================================");
                string album = Console.ReadLine();

                string deleteQuery = @"DELETE FROM Records 
                               WHERE ArtistName = @Artist 
                               AND AlbumName = @Album";

                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@Artist", artist);
                    command.Parameters.AddWithValue("@Album", album);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                        Console.WriteLine("Skivan togs bort!");
                    else
                        Console.WriteLine("Ingen matchande skiva hittades.");
                }
            }
        }
    }
}
