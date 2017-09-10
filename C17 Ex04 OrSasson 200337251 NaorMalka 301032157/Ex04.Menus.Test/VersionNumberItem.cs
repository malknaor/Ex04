using Ex04.Menus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Test
{
    internal class VersionNumberItem : IExecutable
    {
        private const string k_VersionNumber = "15.3.4.0";
      
        private static string GetVersionNumber()
        {
            return k_VersionNumber;
        }

        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("The current Version is: {0}", GetVersionNumber());
            TestLogic.printPressAnyKeyToContinue();
        }
    }
}
