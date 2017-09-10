using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem : Item, IExecutable
    {
        private readonly List<Item> r_MenuItems;
        private readonly MenuItem r_Root;

        public MenuItem(string i_Text, MenuItem i_Root) : base(i_Text)
        {
            r_MenuItems = new List<Item>();
            r_Root = i_Root;
        }

        public List<Item> MenuItems
        {
            get
            {
                return r_MenuItems;
            }
        }

        public MenuItem Root
        {
            get
            {
                return r_Root;
            }
        }

        public MenuItem AddMenuItem(string i_Text)
        {
            MenuItem menuToAdd = new MenuItem(i_Text, this);
            MenuItems.Add(menuToAdd);
            
            return menuToAdd;
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
            bool validInput;

            do
            {
                displayMenu();
                userChoice = Console.ReadLine();
                tryParseSucceed = int.TryParse(userChoice, out chosenOption);
                validInput = checkValidInput(chosenOption);

                if (!tryParseSucceed)
                {
                    Console.WriteLine("Illegal input! please try again.");
                }
                else if (validInput)
                {
                    if (chosenOption == 0)
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

            }
            while (!tryParseSucceed);

            MenuItems[chosenOption].Execute();
        }

        private void displayMenu()
        {
            int countItemsInMenu;

            Console.Clear();
            countItemsInMenu = 0;

            Console.WriteLine("-- [{0}] --", this.ItemText);
            Console.WriteLine("[{0] - [{1}]", countItemsInMenu, generateExitOrBackString());
            countItemsInMenu++;

            foreach (Item item in MenuItems)
            {
                Console.WriteLine("[{0}] - [{1}]", countItemsInMenu, item.ToString());
                countItemsInMenu++;
            }
        }

        private string generateExitOrBackString()
        {
            string exitOrBack = string.Empty;

            if (Root != null)
            {
                exitOrBack = "Back";
            }
            else
            {
                exitOrBack = "Exit";
            }

            return exitOrBack;
        }
        
        private bool checkValidInput(int i_UserChoice)
        {
            return i_UserChoice >= 0 && i_UserChoice <= this.MenuItems.Count;
        }
    }
}