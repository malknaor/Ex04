using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Test
{
    class TestLogic
    {
        private const string k_VersionNumber = "15.3.4.0";

        internal static void CountSpacesInString()
        {
            Console.Clear();
            Console.WriteLine("Please enter a sentence, We will count the number of spaces in it for you!");

            string inputtedSentence = Console.ReadLine();
            int numOfSpaces = CountCharOccurancesInString(inputtedSentence, ' ');

            Console.WriteLine("The number Of spaces in your string is {0}", numOfSpaces.ToString());
            PressAnyKeyToContinue();
        }

        private static void PressAnyKeyToContinue()
        {
            Console.WriteLine("Enter any key to go back to the previous menu");
            Console.ReadKey();
            Console.Clear();
        }

        private static int CountCharOccurancesInString(string i_Str, char i_CharToCount)
        {
            int CharCount = 0;
            foreach (char ch in i_Str)
            {
                if(ch == i_CharToCount)
                {
                    CharCount++;
                }
            }
            return CharCount;
        }
     
        public static void ShowVersion()
        {
            Console.Clear();
            Console.WriteLine("The current Version is: {0}", GetVersionNumber());
            PressAnyKeyToContinue();
            
        }

        private static string GetVersionNumber()
        {
            return k_VersionNumber;
        }

        internal static void ShowTime()
        {
            Console.Clear();
            Console.WriteLine("The current Time is: {0}", DateTime.Now.ToString("T"));
            PressAnyKeyToContinue();
            return;
        }

        internal static void ShowDate()
        {
            Console.Clear();
            Console.WriteLine("The current date is: {0}", DateTime.Now.Date.ToString("D"));
            PressAnyKeyToContinue();
            return;
        }
    }
}
