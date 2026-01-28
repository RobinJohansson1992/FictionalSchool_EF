using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FictionalSchool_EF
{
    internal class UI
    {
        public static void PrintStudentsUI()
        {
            Console.WriteLine("Visa elever:");
            Console.WriteLine("1. Förnamn stigande \n2. Förnamn fallande \n3. Efternamn stigande \n4. Efternamn fallande");
        }
        public static void ErrorMessage()
        {
            Console.WriteLine("Du måste välja ett nummer från listan.");
        }
    }
}
