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
            string connectionString = @"Data Source=MAX-DATOR;Initial Catalog=Vinyls;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Read.Get();
                connection.Open();

                Console.WriteLine("Vilken skiva vill du uppdatera?");
                Console.Write("Artist: ");
                string searchArtist = Console.ReadLine();

                Console.WriteLine("Album: ");
                string searchAlbum = Console.ReadLine();

                string selectQuery = @"SELECT * FROM Records 
                               WHERE ArtistName = @Artist 
                               AND AlbumName = @Album";

                Guid vinylID;

                string artistName, albumName, genreName, collectionName;
                int releaseYear, personalRating;

                using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
                {
                    selectCommand.Parameters.AddWithValue("@Artist", searchArtist);
                    selectCommand.Parameters.AddWithValue("@Album", searchAlbum);

                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            Console.WriteLine("Ingen skiva hittades. ");
                            return;
                        }

                        vinylID = (Guid)reader["VinylID"];
                        artistName = reader["ArtistName"].ToString();
                        albumName = reader["AlbumName"].ToString();
                        genreName = reader["GenreName"].ToString();
                        releaseYear = (int)reader["ReleaseYear"];
                        personalRating = (int)reader["PersonalRating"];
                        collectionName = reader["CollectionName"].ToString();
                    }
                }

                Console.WriteLine("\nTryck Enter för att behålla nuvarande värde. \n");

                Console.WriteLine($"Artist ({artistName}): ");
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                    artistName = input;
                
                Console.WriteLine($"Album ({albumName}): ");
                input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                    albumName = input;

                Console.WriteLine($"Genre ({genreName}): ");
                input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                    genreName = input;

                Console.WriteLine($"Är som skivan släpptes ({releaseYear}): ");
                input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                    releaseYear = Convert.ToInt32(input);

                Console.WriteLine($"Personligt betyg ({personalRating}): ");
                input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                    personalRating = Convert.ToInt32(input);

                Console.WriteLine($"Samlingsnamn ({collectionName}): ");
                input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                    collectionName = input;

                string updateQuery = @"UPDATE Records 
                               SET ArtistName = @ArtistName, 
                                   AlbumName = @AlbumName, 
                                   GenreName = @GenreName, 
                                   ReleaseYear = @ReleaseYear, 
                                   PersonalRating = @PersonalRating, 
                                   CollectionName = @CollectionName
                               WHERE VinylID = @VinylID";

                using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                {
                    updateCommand.Parameters.AddWithValue("@ArtistName", artistName);
                    updateCommand.Parameters.AddWithValue("@AlbumName", albumName);
                    updateCommand.Parameters.AddWithValue("@GenreName", genreName);
                    updateCommand.Parameters.AddWithValue("@ReleaseYear", releaseYear);
                    updateCommand.Parameters.AddWithValue("@PersonalRating", personalRating);
                    updateCommand.Parameters.AddWithValue("@CollectionName", collectionName);
                    updateCommand.Parameters.AddWithValue("@VinylID", vinylID);
                    int rowsAffected = updateCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        Console.WriteLine("Skivan uppdaterades!");
                    else
                        Console.WriteLine("Något gick fel. Skivan uppdaterades inte.");
                }
                
                Console.WriteLine("\nSkivan är nu uppdaterad!");
            }
        }
    }
}
