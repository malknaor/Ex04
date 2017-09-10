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
        private readonly ShowDateItem r_Date;
        private readonly ShowTimeItem r_Time;
        private readonly SpaceCounterItem r_SpaceCount;
        private readonly VersionNumberItem r_Version;

        public MenuWithInterfaces()
        {
            r_MainMenu = new MainMenu();
            MenuItem subMenuToAdd = null;
            r_Date = new ShowDateItem();
            r_Time = new ShowTimeItem();
            r_SpaceCount = new SpaceCounterItem();
            r_Version = new VersionNumberItem();

            subMenuToAdd = MainMenu.MenuRoot.AddMenuItem("Version and Spaces");
            subMenuToAdd.AddExecutableItem("Count Spaces", r_SpaceCount);
            subMenuToAdd.AddExecutableItem("Show Version", r_Version);

            subMenuToAdd = MainMenu.MenuRoot.AddMenuItem("Show Date and Time");
            subMenuToAdd.AddExecutableItem("Show Date", r_Time);
            subMenuToAdd.AddExecutableItem("Show Time", r_Date);

            MainMenu.Show();
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