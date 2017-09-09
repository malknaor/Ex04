using System;

namespace Ex04.Menus.Delegates
{
    public sealed class MainMenu : SubMenuItem
    {
        private const string k_AbortCurrentMenu = "Quit"; // Make enum out of this. Quit and Back.
     
        // Nothing is above the mainMenu in Hierarchy. Hence, This class is sealed. 
        public MainMenu(string i_MenuItemName) : base (i_MenuItemName, k_AbortCurrentMenu)
        {
        }
        
        public void Show()
        { 
            ExecuteMenuSelection();
            showExitMessage();
     
        }

        private void showExitMessage()
        {
            Console.WriteLine("Thank You For Using Our App!! Hope to see u again :)");
            Console.ReadKey();
        }

        override protected internal string getAbortCurrentMenuText()
        {
            return k_AbortCurrentMenu;
        }
    }
}