using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using System.Reflection;

namespace UI_Unit
{
    class TabPageContainer
    {
        protected TabPage m_myTab;
        protected User m_loggedInUser;

        public TabPageContainer(TabPage i_tab, User i_user)
        {
            m_myTab = i_tab;
            m_loggedInUser = i_user;
        }

        protected void InitializeComponent()
        { 
            PropertyInfo[] properties = this.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (PropertyInfo prop in properties)
            {
                Control[] tabControl = m_myTab.Controls.Find(prop.Name, true);
                prop.SetValue(this, tabControl[0], null);
            }
        }

    }
}
