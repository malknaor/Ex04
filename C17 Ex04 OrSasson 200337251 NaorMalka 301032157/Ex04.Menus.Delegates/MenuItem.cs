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




















    //internal class Employee
    //{
    //    private bool m_IsSick;
    //    private string m_ID;

    //    public delegate void Notifier<T>(T i_Param);
    //    public event Notifier<string> BecameSick;

    //    public Employee(string i_ID)
    //    {
    //        m_ID = i_ID;
    //      //  m_IsSick = i_IsSick;
    //    }


    //    private void doWhenSick()
    //    {
    //        m_IsSick = true;
    //        OnBecameSick();
    //    }

    //    // Unlike other frameworks (like js) this method does not deal with event, but activates the sick notifier, it notifies..
    //    protected virtual void OnBecameSick()
    //    {
    //        if (BecameSick != null)
    //        {
    //            BecameSick.Invoke(m_ID);
    //        }
    //    }


    //}
}