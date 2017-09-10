using Ex04.Menus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Test
{
    internal class ShowDateItem: IExecutable
    {
        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("The current date is: {0}", DateTime.Now.Date.ToString("D"));
            TestLogic.printPressAnyKeyToContinue();
            return;
        }
    }
}
