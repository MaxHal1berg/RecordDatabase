using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using RecordDatabase.Methods;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using RecordDatabase.Frontend;

namespace RecordDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection sqlConnection;
            string connectionString = @"Data Source=MAX-DATOR;Initial Catalog=Vinyls;Integrated Security=True;";
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            try
            {
                //Anslutning till Servern via connection string
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Åtkomst beviljad!");
                string svar;
                do
                {
                    Choices.Toptext();
                    //Console.WriteLine("Välj ett av alternativen i listan:");
                    //Console.WriteLine("1, för att lägga till en skiva i biblioteket");
                    //Console.WriteLine("2, för att hämta alla skivor i biblioteket");
                    //Console.WriteLine("3, för att uppdatera information om en skiva");
                    //Console.WriteLine("4, för att ta bort en skiva i biblioteket");
                    //Console.WriteLine("5, för att avsluta");
                    Choices.MenuChoices();
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            //Inmatning mot servern
                            Create.Post();
                            break;
                        case 2:
                            //Få ut alla skivor i bilbioteket i en lista
                            Read.Get();
                            break;
                        case 3:
                            //Skriv över en skiva i biblioteket
                            Update.Overwrite();
                            break; 
                        case 4:
                            //Ta bort en skiva ur biblioteket
                            Delete.Remove();
                            break;
                        case 5:
                            sqlConnection.Close();
                            break;
                        default:
                            Console.WriteLine("Snälla skriv in ett av valen!");
                            break;
                    }
                    Console.WriteLine("Vill du fortsätta?");
                    svar = Console.ReadLine();
                } while (svar != "Nej");


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }


        }
    }
}