using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Facebook;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;


namespace UI_Unit
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            loginAndInit();
        }

        private static void loginAndInit()
        {
            LoginResult result = FacebookService.Connect("EAAEPjJzL7fYBAPigcTI3eMQJTTcvQxUZAVztME0BkJKpMldZBK3FezesgNgBXr47pjC9dx82O0u1xDpBdqaZB94OEyNcsvJKgLIrrYVE5R2UlUGbB4WjGWRRV61cSStti2BoM8rr7dEunBAbjwC9O1jQk7jzpUZD");
            //LoginResult result = FacebookService.Login("298571577159158",
            //    "public_profile",
            //    "user_education_history",
            //    "user_birthday",
            //    "user_actions.video",
            //    "user_actions.news",
            //    "user_actions.music",
            //    "user_actions.fitness",
            //    "user_actions.books",
            //    "user_about_me",
            //    "user_friends",
            //    "publish_actions",
            //    "user_events",

            //    "user_games_activity",
            //    //"user_groups" (This permission is only available for apps using Graph API version v2.3 or older.)
            //    "user_hometown",
            //    "user_likes",
            //    "user_location",
            //    "user_managed_groups",
            //    "user_photos",
            //    "user_posts",
            //    "user_relationships",
            //    "user_relationship_details",
            //    "user_religion_politics",

            //    //"user_status" (This permission is only available for apps using Graph API version v2.3 or older.)
            //    "user_tagged_places",
            //    "user_videos",
            //    "user_website",
            //    "user_work_history",
            //    "read_custom_friendlists",

            //    // "read_mailbox", (This permission is only available for apps using Graph API version v2.3 or older.)
            //    "read_page_mailboxes",
            //    // "read_stream", (This permission is only available for apps using Graph API version v2.3 or older.)
            //    // "manage_notifications", (This permission is only available for apps using Graph API version v2.3 or older.)
            //    "manage_pages",
            //    "publish_pages",
            //    "publish_actions",

            //    "rsvp_event"
            //    );
            // These are NOT the complete list of permissions. Other permissions for example:
            // "user_birthday", "user_education_history", "user_hometown", "user_likes","user_location","user_relationships","user_relationship_details","user_religion_politics", "user_videos", "user_website", "user_work_history", "email","read_insights","rsvp_event","manage_pages"
            // The documentation regarding facebook login and permissions can be found here: 
            // https://developers.facebook.com/docs/facebook-login/permissions#reference


            if (!string.IsNullOrEmpty(result.AccessToken))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                FormFetchingData formFetchingData = new FormFetchingData();
                formFetchingData.Show();
                Application.Run(new MainForm(result.LoggedInUser, formFetchingData.Close));
            }
            else
            {
                MessageBox.Show(result.ErrorMessage);
            }
        }
    }
}
