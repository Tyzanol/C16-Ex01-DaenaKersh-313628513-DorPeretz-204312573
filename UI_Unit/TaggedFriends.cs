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
    class TaggedFriends : TabPageContainer
    {
        private ListView listTaggedFriendsAfterFilter { get; set; }
        private CheckedListBox checkedListBoxFriends { get; set; }

        public TaggedFriends(TabPage i_Tab, User i_user) : 
            base(i_Tab, i_user)
        {
            InitializeComponent();
            fillFriendList();
            updateTaggedInPhotos();
            checkedListBoxFriends.ItemCheck += onCheckedListBoxFriendsItemCheck;
        }

        public void TaggedFriendsInPhotosInit()
        {
            listTaggedFriendsAfterFilter.Columns.Add("Photos", listTaggedFriendsAfterFilter.Width - 40);
            listTaggedFriendsAfterFilter.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void updateTaggedInPhotos()
        {
            listTaggedFriendsAfterFilter.Items.Clear();
            ImageList taggedFriendsPhotos = new ImageList();
            taggedFriendsPhotos.ImageSize = new Size(60, 60);

            FacebookObjectCollection<PhotoTag> taggsInPhotos;
            int runningIndex;
            foreach (Photo curPhoto in m_loggedInUser.PhotosTaggedIn)
            {
                taggsInPhotos = curPhoto.Tags;

                if (areAllChosenFriendsTagged(taggsInPhotos, checkedListBoxFriends.CheckedItems))
                {
                    taggedFriendsPhotos.Images.Add(curPhoto.ImageNormal);
                }
            }
            listTaggedFriendsAfterFilter.SmallImageList = taggedFriendsPhotos;
            runningIndex = 0;
            foreach (var curPhoto in taggedFriendsPhotos.Images)
            {
                listTaggedFriendsAfterFilter.Items.Add("", runningIndex++);
            }

        }

        private bool areAllChosenFriendsTagged(FacebookObjectCollection<PhotoTag> iTags, CheckedListBox.CheckedItemCollection iChosenFriends)
        {
            foreach (User chosenFriend in iChosenFriends)
            {
                bool isTagged = false;
                foreach (PhotoTag tag in iTags)
                {
                    if (tag.User.Name == chosenFriend.Name)
                    {
                        isTagged = true;
                    }
                }
                if (!isTagged)
                {
                    return false;
                }
            }
            return true;
        }


        private void fillFriendList()
        {
            foreach (User friends in m_loggedInUser.Friends)
            {
                checkedListBoxFriends.Items.Add(friends);
            }
            checkedListBoxFriends.DisplayMember = "Name";
        }

        private void onCheckedListBoxFriendsItemCheck(object sender, ItemCheckEventArgs e)
        {
            m_myTab.BeginInvoke((MethodInvoker)(() => updateTaggedInPhotos()));

        }

    }
}
