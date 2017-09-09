using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Menus.Delegates;

namespace Ex04.Menus.Test
{
    public class MenuWithDelegates
    {
        private readonly MainMenu r_MainMenu;

        // First Sub Menu.
        private readonly SubMenuItem r_VersionAndSpacesSubMenu;
        private readonly ActionMenuItem r_CountSpacesActionMenu; // Rename to CountSpacesActionMenu (and the rest too)?
        private readonly ActionMenuItem r_ShowVersionActionMenu;

        //Second Sub Menu.
        private readonly SubMenuItem r_ShowDateAndTimeSubMenu;
        private readonly ActionMenuItem r_ShowDateActionMenuItem;
        private readonly ActionMenuItem r_ShowTimeActionMenuItem;

        public MenuWithDelegates()
        {
            r_MainMenu = new MainMenu("Welcome to the Main Menu!");

            r_VersionAndSpacesSubMenu = new SubMenuItem("Version and Spaces");
            r_CountSpacesActionMenu = new ActionMenuItem("Count Spaces");
            r_ShowVersionActionMenu = new ActionMenuItem("Show Version");

            r_ShowDateAndTimeSubMenu = new SubMenuItem("Show Date And Time");
            r_ShowDateActionMenuItem = new ActionMenuItem("Show Date");
            r_ShowTimeActionMenuItem = new ActionMenuItem("Show Time");
        
            addMethodsAndListeners(); // Bad name.
            
            //Menu is now configured by the user (programmer), and can now be shown.                         
            r_MainMenu.Show();
        }

        private void addMethodsAndListeners()
        {
            // "Connect" methods to menu items.
            r_CountSpacesActionMenu.SelectedAction += TestLogic.CountSpacesInString;
            r_ShowVersionActionMenu.SelectedAction += TestLogic.ShowVersion;
            r_ShowDateActionMenuItem.SelectedAction += TestLogic.ShowDate;
            r_ShowTimeActionMenuItem.SelectedAction += TestLogic.ShowTime;

            // Adding 1st Sub menu.
            r_VersionAndSpacesSubMenu.Add(r_CountSpacesActionMenu);
            r_VersionAndSpacesSubMenu.Add(r_ShowVersionActionMenu);
            r_MainMenu.Add(r_VersionAndSpacesSubMenu);

            // Adding 2nd Sub menu.
            r_ShowDateAndTimeSubMenu.Add(r_ShowDateActionMenuItem);
            r_ShowDateAndTimeSubMenu.Add(r_ShowTimeActionMenuItem);
            r_MainMenu.Add(r_ShowDateAndTimeSubMenu);
        }
    }
}
