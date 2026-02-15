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

            Console.WriteLine("Artisten:");
            string artistName = Console.ReadLine();
            Console.WriteLine("Album:");
            string albumName = Console.ReadLine();
            Console.WriteLine("Genre:");
            string genreName = Console.ReadLine();
            Console.WriteLine("Utgivningsdatum/år:");
            int releaseYear = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Betyg 1-10:");
            int personalRating = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Samlingsnamn:");
            string collectionName = Console.ReadLine();
            string insertQuery = "INSERT INTO RECORDS(ArtistName,AlbumName,GenreName,ReleaseYear,PersonalRating,CollectionName) VALUES('" + artistName + "','" + albumName + "','" + genreName + "'," + releaseYear + "," + personalRating + ",'" + collectionName + "')";
            SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);
            insertCommand.ExecuteNonQuery();
            Console.WriteLine("Servern har mottagit informationen!");
        }
    }
}
