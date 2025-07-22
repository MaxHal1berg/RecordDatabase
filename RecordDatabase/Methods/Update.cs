using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordDatabase.Methods
{
    internal class Update
    {
        public static void Overwrite()
        {
            SqlConnection sqlConnection;
            string connectionString = @"Data Source=DESKTOP-KILJFHC;Initial Catalog=Vinyls;Integrated Security=True;TrustServerCertificate=True";
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            int vinyl_ID;
            Console.WriteLine("Skriv in ID för skivan du vill redigera:");
            vinyl_ID = Convert.ToInt32(Console.ReadLine());
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
            string updateQuery = "UPDATE RECORDS SET ArtistName, AlbumName ,GenreName ,ReleaseYear ,PersonalRating , CollectionName '" + artistName + "','" + albumName + "','" + genreName + "'," + releaseYear + "," + personalRating + ",'" + collectionName + "' WHERE VinylID = " + vinyl_ID + "";
            SqlCommand updateCommand = new SqlCommand(updateQuery, sqlConnection);
            updateCommand.ExecuteNonQuery();
            Console.WriteLine("Skivan är nu uppdaterad!");
        }
    }
}
