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
        private MainMenu mainMenu;

        // First Sub Menu.
        private SubMenuItem m_VersionAndSpacesSubMenu;
        private ActionMenuItem m_CountSpaces; // Rename to CountSpacesActionMenu (and the rest too)?
        private ActionMenuItem m_ShowVersion;

        //Second Sub Menu.
        private SubMenuItem m_ShowDateAndTime;
        private ActionMenuItem m_ShowDate;
        private ActionMenuItem m_ShowTime;

        public MenuWithDelegates()
        {
            buildMenuHierarchy(); // And set menu names also... Better name or split to methods.
            addMethodsAndListeners(); // Bad name.
            
            //Menu is now configured by the user (programmer), and can now be shown.                         
            mainMenu.Show();

            // This code should be inside of the MainMenu Class somehow.
            Console.WriteLine("Thank You For Using Our App!! Hope to see u again :)");
            Console.ReadKey();
        }

        private void addMethodsAndListeners()
        {
            // Maybe should not be void?
            m_CountSpaces.SelectedAction += TestLogic.CountSpacesInString;
            m_ShowVersion.SelectedAction += TestLogic.ShowVersion;

            m_ShowDate.SelectedAction += TestLogic.ShowDate;
            m_ShowTime.SelectedAction += TestLogic.ShowTime;

            m_VersionAndSpacesSubMenu.Add(m_CountSpaces);
            m_VersionAndSpacesSubMenu.Add(m_ShowVersion);
            mainMenu.Add(m_VersionAndSpacesSubMenu);

            m_ShowDateAndTime.Add(m_ShowDate);
            m_ShowDateAndTime.Add(m_ShowTime);
            mainMenu.Add(m_ShowDateAndTime);
        }

        private void buildMenuHierarchy()
        {
            mainMenu = new MainMenu("This is The Main Menu!!!");

            m_VersionAndSpacesSubMenu = new SubMenuItem("Version and Spaces");
            m_CountSpaces = new ActionMenuItem("Count Spaces");
            m_ShowVersion = new ActionMenuItem("Show Version");

            m_ShowDateAndTime = new SubMenuItem("Show Date And Time");
            m_ShowDate = new ActionMenuItem("Show Date");
            m_ShowTime = new ActionMenuItem("Show Time");
        }
    }
}
