using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using StrefaKibicaGeek.SvcProvider;
using StrefaKibicaGeek.Messages;

namespace StrefaKibicaGeek.Views
{
    public partial class FacebookLoginView : PhoneApplicationPage
    {
        FBAuthenticationService fbAuth;

        public FacebookLoginView()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(Page1_Loaded);
        }

        void webBrowser1_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (fbAuth == null)
                return;

            var suc = fbAuth.ParseResponse(e.Uri);

            if (!suc.HasValue)
                return;

            if (suc.Value)
            {
                // access token is retrieved
                //   use the access token to enquire other services
                //this.NavigationService.Navigate(new Uri("/PivotPage1.xaml", UriKind.Relative));
                App.MManager.PublishMessageByType<ViewsMessage>
                     (
                     new ViewsMessage()
                     {
                         CurrentAction = ViewsAction.RetrieveFriends
                     }
                     );
            }
        }

        void Page1_Loaded(object sender, RoutedEventArgs e)
        {
            fbAuth = new FBAuthenticationService();
            var url = fbAuth.GetLoginUrl();
            this.webBrowser1.Navigate(url);
            this.webBrowser1.Navigated += new EventHandler<System.Windows.Navigation.NavigationEventArgs>(webBrowser1_Navigated);
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}