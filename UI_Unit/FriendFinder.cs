using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using System.Globalization;
using System.Drawing;

namespace UI_Unit
{
    class FriendFinder : TabPageContainer
    {
        private ListView listViewFriends { get; set; }
        private NumericUpDown numericUpDownMinAge { get; set; }
        private NumericUpDown numericUpDownMaxAge { get; set; }
        private CheckBox checkBoxOnlySingle { get; set; }
        private CheckBox checkBoxMale { get; set; }
        private CheckBox checkBoxFemale { get; set; }
        private CheckBox checkBoxOnlyInterestedGender { get; set; }
        private Button buttonFilterFriends { get; set; }

        public FriendFinder(TabPage i_Tab, User i_user) : 
            base(i_Tab, i_user)
        {
            InitializeComponent();
            fillViewList(m_loggedInUser.Friends);
            numericUpDownMinAge.ValueChanged += onNumericUpDownMinAgeValueChanged;
            numericUpDownMaxAge.ValueChanged += onNumericUpDownMaxAgeValueChanged;
            buttonFilterFriends.Click += onButtonFilterFriendsClick;

        }

        public void friendFinderInit()
        {
            listViewFriends.Columns.Add("Friends", listViewFriends.Width - 20);
            listViewFriends.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private FacebookObjectCollection<User> filterFriends()
        {
            FacebookObjectCollection<User> chosenFreinds = new FacebookObjectCollection<User>();
            foreach (User userFriend in m_loggedInUser.Friends)
            {
                if (checkIfUserFitsFilter(userFriend))
                    chosenFreinds.Add(userFriend);
            }
            return chosenFreinds;

        }

        private bool checkIfUserFitsFilter(User userFriend)
        {
            bool fitFlag = true;
            int age = calculateAge(userFriend.Birthday);
            if (age < numericUpDownMinAge.Value || age > numericUpDownMaxAge.Value)
            {
                fitFlag = false;
            }
            else if (userFriend.Gender == User.eGender.female && !checkBoxFemale.Checked)
            {
                fitFlag = false;
            }
            else if (userFriend.Gender == User.eGender.male && !checkBoxMale.Checked)
            {
                fitFlag = false;
            }
            else if (checkBoxOnlySingle.Checked &&
                (userFriend.RelationshipStatus == User.eRelationshipStatus.InARelationship ||
                userFriend.RelationshipStatus == User.eRelationshipStatus.InADomesticPartnership ||
                userFriend.RelationshipStatus == User.eRelationshipStatus.Married ||
                userFriend.RelationshipStatus == User.eRelationshipStatus.Enagaged ||
                userFriend.RelationshipStatus == User.eRelationshipStatus.InACivilUnion))
            {
                fitFlag = false;
            }
            else if (m_loggedInUser.Gender.HasValue && checkBoxOnlyInterestedGender.Checked &&
                !userFriend.InterestedIn.Contains<User.eGender>(m_loggedInUser.Gender.Value))
            {
                fitFlag = false;
            }
            return fitFlag;

        }

        private int calculateAge(string birthday)
        {
            DateTime today = DateTime.Today;
            CultureInfo provider = CultureInfo.InvariantCulture;
            DateTime bday = DateTime.ParseExact(birthday, @"mm/dd/yyyy", provider);
            int age = today.Year - bday.Year;

            if (bday > today.AddYears(-age))
                age--;
            return age;
        }

        public void fillViewList(FacebookObjectCollection<User> friends)
        {
            listViewFriends.Items.Clear();
            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(60, 60);
            foreach (User userFriend in friends)
            {
                imageList.Images.Add(userFriend.ImageNormal);
            }

            listViewFriends.SmallImageList = imageList;
            int friendIndex = 0;
            foreach (User userFriend in friends)
            {
                listViewFriends.Items.Add(userFriend.Name, friendIndex++);
            }
        }

        private void onNumericUpDownMinAgeValueChanged(object sender, EventArgs e)
        {
            numericUpDownMaxAge.Minimum = numericUpDownMinAge.Value;
        }

        private void onNumericUpDownMaxAgeValueChanged(object sender, EventArgs e)
        {
            numericUpDownMinAge.Maximum = numericUpDownMaxAge.Value;
        }

        private void onButtonFilterFriendsClick(object sender, EventArgs e)
        {
            FacebookObjectCollection<User> filteredFriends = filterFriends();
            fillViewList(filteredFriends);
        }
    }
}
