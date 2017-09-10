using Ex04.Menus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Test
{
    internal class SpaceCounterItem : IExecutable
    {

        private static int CountCharOccurancesInString(string i_Str, char i_CharToCount)
        {
            int CharCount = 0;
            foreach (char ch in i_Str)
            {
                if (ch == i_CharToCount)
                {
                    CharCount++;
                }
            }
            return CharCount;
        }

        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("Please Enter a sentence, and we will count the number of spaces in it for you!");

            string inputtedSentence = Console.ReadLine();
            int numOfSpaces = CountCharOccurancesInString(inputtedSentence, ' ');

            Console.WriteLine("The number of spaces in your string is: {0}", numOfSpaces.ToString());
            TestLogic.printPressAnyKeyToContinue();
        }

      
    }
}
