using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;


namespace UI_Unit
{
    class FacebookFunctions : TabPageContainer
    {
        private ListBox listBoxStatus { get; set; }
        private RichTextBox richTextBoxPostMessege { get; set; }
        private Button buttonLikePost { get; set; }
        private Button buttonPostMessegeOnWall { get; set; }

        public FacebookFunctions(TabPage i_Tab, User i_user) : 
            base(i_Tab, i_user)
        {
            InitializeComponent();
            listBoxStatus.DisplayMember = "Message";
            buttonLikePost.Click += onButtonLikePostClick;
            buttonPostMessegeOnWall.Click += onButtonPostMessegeClick;
        }

        public void facebookFunctionInit()
        {
            UpdateStatusPosts();
        }

        private void UpdateStatusPosts()
        {
            listBoxStatus.Items.Clear();
            foreach (Post post in m_loggedInUser.Posts)
            {
                if (post.Message != null)
                {
                    listBoxStatus.Items.Add(post);
                }
            }
        }

        private void onButtonPostMessegeClick(object sender, EventArgs e)
        {
            postStatus();
        }

        private void postStatus()
        {
            Status postedStatus = m_loggedInUser.PostStatus(richTextBoxPostMessege.Text);
            listBoxStatus.Items.Insert(0, postedStatus);
            MessageBox.Show("Status posted!");
            richTextBoxPostMessege.Clear();
        }

        private void onButtonLikePostClick(object sender, EventArgs e)
        {
            likeStatus();
        }

        private void likeStatus()
        {
            (listBoxStatus.SelectedItem as PostedItem).Like();
        }
    }

}
