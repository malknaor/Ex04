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
            bool userQuit = false;
            Console.Clear();

            if (menuIsEmpty())
            { // Menu should have at least one item in order to exist...
                throw new ArgumentOutOfRangeException("Cannot Select Empty Menu!");
            }

            // Main loop of the menu.
            while (!userQuit)
            {
                displayCurrentMenuLevel();
                int userSelection = getSelectedItem();
                runUserSelection(userSelection, out userQuit);
                Console.Clear();
            }

        }

        private void runUserSelection(int i_MenuItemIndex, out bool userQuit)
        {
            userQuit = false;

            if (i_MenuItemIndex == 0) // This is stupid, again - the enum will take care of it.
            {
                userQuit = true;
            }
            else
            {
                r_MenuItems[i_MenuItemIndex - 1].Execute(); // Maybe this method should be smart enough to quit itself.
            }
        }

        private int getSelectedItem()
        {
            string userSelectionStr = Console.ReadLine();

            while (!validateInputtedSelection(userSelectionStr))
            {
                showInvalidInputMessage();
                displayCurrentMenuLevel();
                userSelectionStr = Console.ReadLine();
            }
            return int.Parse(userSelectionStr);
        }

        private void showInvalidInputMessage()
        {
            Console.Clear();
            Console.WriteLine(
@"Invalid Input! Try again.
Press any key to go back to the previous menu.");
            Console.ReadLine();
            Console.Clear();
        }

        private bool validateInputtedSelection(string i_StrToValidate)
        {
            int userSelectionAsInt;

            bool isInputInteger = int.TryParse(i_StrToValidate, out userSelectionAsInt);
            bool isMenuIndexInRange = userSelectionAsInt >= 0 && userSelectionAsInt <= r_MenuItems.Count;

            return isInputInteger && isMenuIndexInRange;
        }

        private bool menuIsEmpty()
        {
            return r_MenuItems.Count == 0;
        }

        private void displayCurrentMenuLevel()
        {
            printMenuTitle();
            printCurrentMenuItems();
            askToSelectItem();
        }

        private void askToSelectItem()
        {
            Console.WriteLine("Please enter your desired option from the menu.");
        }
        private void printCurrentMenuItems()
        {
            int idx = 1;

            foreach (Item menuItem in r_MenuItems)
            {
                Console.WriteLine("[{0}] - {1}", idx.ToString(), menuItem.ItemText);
                idx++;
            }

            Console.WriteLine("[0] - {0}", generateExitOrBackString());
        }

        private void printMenuTitle()
        {
            StringBuilder sb = new StringBuilder();
            Console.WriteLine(ItemText);
            foreach (char ch in ItemText)
            {
                sb.Append("-");
            }
            Console.WriteLine(sb);
        }

        private void displayMenu()
        {
            int countItemsInMenu;

            Console.Clear();
            countItemsInMenu = 1;
            string exitOrBack = string.Empty;

            if (Root != null)
            {
                exitOrBack = "Back";
            }
            else
            {
                exitOrBack = "Exit";
            }

            Console.WriteLine("-- [{0}] --", this.ItemText);
           
            foreach (Item item in MenuItems)
            {
                Console.WriteLine("[{0}] - [{1}]", countItemsInMenu, item.ToString());
                countItemsInMenu++;
            }

            Console.WriteLine("[0] - [{0}]", exitOrBack);
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