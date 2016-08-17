using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Facebook;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using System.Globalization;

namespace UI_Unit
{
    public partial class MainForm : Form
    {
        private User m_LoggedInUser;
        private FacebookFunctions fbFunc;
        private FriendFinder findFriends;
        private TaggedFriends taggedPhotosWithFriends;
        public delegate void DelegateCloseFetchForm();

        public MainForm(User i_user, DelegateCloseFetchForm i_closingMethod)
        {
            InitializeComponent();
            m_LoggedInUser = i_user;
            initApplicationData();
            i_closingMethod.Invoke();
        }

        private void initApplicationData()
        {
            initPersonalDetailsFromFB();
            fbFunc = new FacebookFunctions(tabPageFacebookFunction, m_LoggedInUser);
            findFriends = new FriendFinder(tabPageMatchFriends, m_LoggedInUser);
            taggedPhotosWithFriends = new TaggedFriends(tabPageTaggedWithFriends, m_LoggedInUser);
            fbFunc.facebookFunctionInit();
            findFriends.friendFinderInit();
            taggedPhotosWithFriends.TaggedFriendsInPhotosInit();
        }

        private void initPersonalDetailsFromFB()
        {
            this.Height = panelTabHolder.Bottom + 50;
            groupBoxPersonalDetails.Visible = true;
            fetchUserInfo();
            buttonLogIn.Visible = false;
        }

        private void fetchUserInfo()
        {
            pictureBoxProfileImage.LoadAsync(m_LoggedInUser.PictureNormalURL);
            labelName.Text = m_LoggedInUser.Name;
            labelGender.Text = m_LoggedInUser.Gender.ToString();
            labelDOB.Text = m_LoggedInUser.Birthday;
            labelEmail.Text = m_LoggedInUser.Email;
        }
    }
}
