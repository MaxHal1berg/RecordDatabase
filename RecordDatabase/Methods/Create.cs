using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordDatabase.Methods
{
    internal class Create
    {
        public static void Post()
        {
            SqlConnection sqlConnection;
            string connectionString = @"Data Source=MAX-DATOR;Initial Catalog=Vinyls;Integrated Security=True;";
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            Console.WriteLine("=======================================");
            Console.WriteLine("Artisten:");
            Console.WriteLine("=======================================");
            string artistName = Console.ReadLine();
            Console.WriteLine("=======================================");
            Console.WriteLine("Album:");
            Console.WriteLine("=======================================");
            string albumName = Console.ReadLine();
            Console.WriteLine("=======================================");
            Console.WriteLine("Genre:");
            Console.WriteLine("=======================================");
            string genreName = Console.ReadLine();
            Console.WriteLine("=======================================");
            Console.WriteLine("Utgivningsdatum/år:");
            Console.WriteLine("=======================================");
            int releaseYear = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("=======================================");
            Console.WriteLine("Betyg 1-10:");
            Console.WriteLine("=======================================");
            int personalRating = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("=======================================");
            Console.WriteLine("Samlingsnamn:");
            Console.WriteLine("=======================================");
            string collectionName = Console.ReadLine();
            string insertQuery = "INSERT INTO RECORDS(ArtistName,AlbumName,GenreName,ReleaseYear,PersonalRating,CollectionName) VALUES('" + artistName + "','" + albumName + "','" + genreName + "'," + releaseYear + "," + personalRating + ",'" + collectionName + "')";
            SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);
            insertCommand.ExecuteNonQuery();
            Console.WriteLine("Servern har mottagit informationen!");
        }
    }
}
