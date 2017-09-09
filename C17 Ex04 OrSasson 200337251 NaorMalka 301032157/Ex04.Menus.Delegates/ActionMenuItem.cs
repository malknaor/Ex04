using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Delegates
{
    public class ActionMenuItem : MenuItem
    {
        public event Action SelectedAction;

        public ActionMenuItem(string i_Name) : base(i_Name)
        {
        }

        internal  void RunSelectedAction()
        {
            OnActionSelected();
        }

        protected virtual void OnActionSelected()
        {
            if (SelectedAction != null)
            {
                SelectedAction.Invoke();
            }
        }

        protected internal override void ExecuteMenuSelection()
        {
            OnActionSelected();
        }
    }
}