using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu 
    {
        private readonly MenuItem m_MenuRoot;

        public MainMenu()
        {
            m_MenuRoot = new MenuItem("Main Menu", null);
        }

        public MenuItem MenuRoot
        {
            get
            {
                return m_MenuRoot;
            }
        }

        public void Show()
        {
            MenuRoot.RunMenu();
        }
    }
}
