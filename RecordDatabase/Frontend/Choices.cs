using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordDatabase.Frontend
{
    public class Choices
    {
        public static void Toptext()
        {
            Console.WriteLine("Välkommen till Max Hallbergs vinylsamling!");
        }

        public static void MenuChoices() 
        {
            Console.WriteLine("=======================================");
            Console.WriteLine("   MAX Vinyldatabas v1.0   ");
            Console.WriteLine("=======================================");
            Console.WriteLine();
            Console.WriteLine(">> VÄLJ FUNKTION");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("  [1] LÄGG TILL SKIVA");
            Console.WriteLine("  [2] VISA ALLA SKIVOR");
            Console.WriteLine("  [3] UPPDATERA SKIVA");
            Console.WriteLine("  [4] RADERA SKIVA");
            Console.WriteLine("  [5] AVSLUTA SYSTEM");
            Console.WriteLine("---------------------------------------");
            Console.Write("VAL > ");
        }

        public static void Bottomtext()
        {
            Console.WriteLine("Tack för att du använde programmet, ha en trevlig dag!");
        }
    }
}
