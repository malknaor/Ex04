using Ex04.Menus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Test
{
    internal class ShowTimeItem : IExecutable
    {
        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("The current Time is: {0}", DateTime.Now.ToString("T"));
            TestLogic.printPressAnyKeyToContinue();
            return;
        }
    }
}
