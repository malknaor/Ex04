using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    internal class MenuItem : Item , IExecutable
    {
        private readonly List<Item> m_MenuItems;
        private readonly MenuItem m_Root; // This will enable us to have the back option and if NULL will exit.

        public MenuItem(string i_Text, MenuItem i_Root) : base(i_Text)
        {
            m_MenuItems = new List<Item>();
            m_Root = i_Root;
        }

        internal List<Item> MenuItems
        {
            get
            {
                return m_MenuItems;
            }
        }

        internal MenuItem Root
        {
            get
            {
                return m_Root;
            }
        }

        public void AddMenuItem(string i_Text)
        {
            MenuItems.Add(new MenuItem(i_Text, this));
        }

        public void AddExecutableItem(string i_Text, IExecutable i_Executable)
        {
            MenuItems.Add(new ExecutableItem(i_Text, i_Executable));
        }

        public override void Execute()
        {
            RunMenu();
        }

        public void RunMenu()
        {
            int chosenOption;
            string userChoice = string.Empty;
            bool tryParseSucceed = false;

            do
            {
                displayMenu();
                userChoice = Console.ReadLine();
                tryParseSucceed = int.TryParse(userChoice, out chosenOption);

                if (!tryParseSucceed)
                {
                    Console.WriteLine("Illegal input! please try again.");
                }
                else if (chosenOption == 0)
                {
                    if (Root != null)
                    {
                        Root.RunMenu();
                    }
                    else
                    {
                        Environment.Exit(Environment.ExitCode); // Need to check again 
                    }
                }
                
            }
            while (!tryParseSucceed);

            MenuItems[chosenOption].Execute();
        }

        internal void displayMenu()
        {
            int countItemsInMenu;

            Console.Clear();
            countItemsInMenu = 0;

            Console.WriteLine("{0}.{1}", countItemsInMenu, generateExitOrBackString());
            foreach (Item item in MenuItems)
            {
                Console.WriteLine("{0}.{1}", countItemsInMenu, item.ToString());
                countItemsInMenu++;
            }
        }

        private string generateExitOrBackString()
        {
            return Root != null ? "Back" : "Exit";
        }

        //internal int getUserInput()
        //{

        //}
    }
}