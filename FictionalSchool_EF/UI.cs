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
            Console.WriteLine("" +
                "1. Förnamn stigande \n" +
                "2. Förnamn fallande \n" +
                "3. Efternamn stigande \n" +
                "4. Efternamn fallande");
        }
        public static void ErrorMessage()
        {
            Console.WriteLine("Du måste välja ett nummer från listan.");
        }
        public static void BackToMainMessage()
        {
            Console.WriteLine("\nTryck enter för att återgå till huvudmenyn.");
        }
        public static void ExitMessage()
        {
            Console.WriteLine("\nProgrammet avslutas...");
            Console.ReadKey();
        }
        public static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("===|| Meny ||===\n");
            Console.WriteLine("" +
                "1. Hämta alla elever \n" +
                "2. Hämta alla elever från en viss klass \n" +
                "3. Lägg tíll ny personal \n" +
                "4. Avsluta");

            int userInput;
            while (!int.TryParse(Console.ReadLine(), out userInput) || userInput < 1 || userInput > 4)
            {
                UI.ErrorMessage();
            }
            switch (userInput)
            {
                case 1:
                    FSContent.PrintAllStudents();
                    break;
                case 2:
                    FSContent.PrintAllStudents();
                    break;
                case 3:
                    FSContent.PrintAllStudents();
                    break;
                case 4:
                    ExitMessage();
                    break;
            }

        }
    }
}
