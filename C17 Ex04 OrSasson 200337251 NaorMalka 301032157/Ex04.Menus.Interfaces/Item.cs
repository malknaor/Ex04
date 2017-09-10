using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public abstract class Item
    {
        readonly string m_ItemText;

        public Item(string i_Text)
        {
            m_ItemText = i_Text;
        }

        public string ItemText
        {
            get
            {
                return m_ItemText;
            }
        }
        
        public override string ToString()
        {
            return m_ItemText;
        }

        public abstract void Execute();
    }
}