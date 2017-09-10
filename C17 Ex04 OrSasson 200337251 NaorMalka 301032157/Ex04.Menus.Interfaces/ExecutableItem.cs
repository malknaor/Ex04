using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    internal class ExecutableItem : Item , IExecutable
    {
        private readonly IExecutable m_Executable;

        public ExecutableItem(string i_Text, IExecutable i_Executable) : base(i_Text)
        {
            m_Executable = i_Executable;
        }

        public override void Execute()
        {
            m_Executable.Execute();
        }
    }
}