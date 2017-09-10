namespace Ex04.Menus.Delegates
{

    public abstract class MenuItem
    {
        private string m_Name;
        internal string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        public MenuItem(string i_Name)
        {
            m_Name = i_Name;
        }

        protected internal abstract void ExecuteMenuSelection();
    }
}