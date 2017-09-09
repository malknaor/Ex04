using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Delegates
{
    // Maybe Clearing the screen and watiing for user to hit key should be here in this class??
    // Causes me to duplicate code in the TestLogic class.
    public class SubMenuItem : MenuItem
    {
        private const string k_AbortCurrentMenu = "Back";

        private readonly List<MenuItem> r_MenuItemsList;
        protected List<MenuItem> MenuItemsList
        {
            get { return r_MenuItemsList; }
        }
    
        // Better names...
        public SubMenuItem(string i_Name, string i_AbortOption = k_AbortCurrentMenu) : base(i_Name)
        {
            r_MenuItemsList = new List<MenuItem>();
        }

        public void Add(MenuItem i_MenuItem)
        {
            r_MenuItemsList.Add(i_MenuItem);
        }

        protected internal override void ExecuteMenuSelection()
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
                int userSelection = GetSelectedItem();
                runUserSelection(userSelection, out userQuit);
                Console.Clear();
            }
          
        }

        private void runUserSelection(int i_MenuItemIdx, out bool userQuit)
        {
            userQuit = false;

            if (i_MenuItemIdx == 0) // This is stupid, again - the enum will take care of it.
            {
                userQuit = true;
            }
            else
            {
                r_MenuItemsList[i_MenuItemIdx - 1].ExecuteMenuSelection(); // Maybe this method should be smart enough to quit itself.
            }
        }

        private bool ValidateInputtedSelection(string i_StrToValidate)
        {
            int userSelectionAsInt;

            bool isInteger = int.TryParse(i_StrToValidate, out userSelectionAsInt);
            bool isSelectionInRange = userSelectionAsInt >= 0 && userSelectionAsInt <= r_MenuItemsList.Count;

            return isInteger && isSelectionInRange;
        }

        private int GetSelectedItem()
        {
            string userSelectionStr = Console.ReadLine();

            while (!ValidateInputtedSelection(userSelectionStr))
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
            Console.WriteLine("Invalid Input!");
            Console.WriteLine("Press any key to go back to the previous menu.");
            Console.ReadLine();
            Console.Clear();
        }

        private void askToSelectItem()
        {
            Console.WriteLine("Please Enter your desired option from the menu.");
        }

        private void displayCurrentMenuLevel()
        {
            printMenuTitle();
            printCurrentMenuItems();
            askToSelectItem();
        }

        private void printMenuTitle()
        {
            Console.WriteLine(Name);
            Console.WriteLine("-------------------------");
        }

        private void printCurrentMenuItems()
        {
            int idx = 1;

            foreach (MenuItem menuItem in r_MenuItemsList)
            {
                Console.WriteLine("[{0}] - {1}", idx.ToString(), menuItem.Name);
                idx++;
            }
            Console.WriteLine("[0] - {0}", getAbortCurrentMenuText());
        }

        virtual protected internal string getAbortCurrentMenuText()
        {
            return k_AbortCurrentMenu;
        }

        private bool menuIsEmpty()
        {
            return r_MenuItemsList.Count == 0;
        }
    }

}
