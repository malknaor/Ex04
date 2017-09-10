using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    class MenuWithInterfaces
    {
        private readonly MainMenu r_MainMenu;
        //// First Sub Menu.
        //private readonly SubMenuItem r_VersionAndSpacesSubMenu;
        //private readonly ActionMenuItem r_CountSpacesActionMenu; // Rename to CountSpacesActionMenu (and the rest too)?
        //private readonly ActionMenuItem r_ShowVersionActionMenu;

        ////Second Sub Menu.
        //private readonly SubMenuItem r_ShowDateAndTimeSubMenu;
        //private readonly ActionMenuItem r_ShowDateActionMenuItem;
        //private readonly ActionMenuItem r_ShowTimeActionMenuItem;


        public MenuWithInterfaces()
        {
            r_MainMenu = new MainMenu();
            MenuItem subMenuToAdd = null;
            //first menu option
            subMenuToAdd = MainMenu.MenuRoot.AddMenuItem("Version and Spaces");
            subMenuToAdd.AddExecutableItem("Count Spaces", );
            subMenuToAdd.AddExecutableItem("Show Version", );

            //second menu option
            //MainMenu.MenuRoot.AddMenuItem("Show Date And Time");
            subMenuToAdd = MainMenu.MenuRoot.AddMenuItem("Show Date and Time");
            subMenuToAdd.AddExecutableItem("Show Date", );
            subMenuToAdd.AddExecutableItem("Show Time", );
        }

        public MainMenu MainMenu
        {
            get
            {
                return r_MainMenu;
            }
        }
    }


}
