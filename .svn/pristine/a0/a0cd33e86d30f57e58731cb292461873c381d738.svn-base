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
using System.Windows.Navigation;
using StrefaKibica.Models;
using StrefaKibicaGeek.Models;
using StrefaKibicaGeek.Messages;
using MES.Library.Mvvm.Attributes;
using StrefaKibicaGeek.Respositories;

using Autofac;
using Autofac.Util;

namespace StrefaKibicaGeek.Views
{
    public partial class MatchesView : PhoneApplicationPage
    {
        private EventHandler<System.Windows.Navigation.NavigationEventArgs> w_Navigated;
        // Constructor

        String ChoiceA = String.Empty;
        String ChoiceB = String.Empty;

        public MatchesView()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(OnViewLoaded);
        }

        void OnViewLoaded(object sender, RoutedEventArgs e)
        {

            this.DataContext = this;

            App.MManager.SubscribeByMessageTypeAndCondition<ViewsMessage>
                (
                this,
                new Predicate<object>
                    (
                    (Msg) => { return ((ViewsMessage)Msg).CurrentAction == ViewsAction.RetrieveMatches; }
                    )
                );

            listDisplay.SelectionChanged += (Subsender, Sube) =>
            {
                if (listDisplay.SelectedValue != null)
                {
                    Match.Text = (listDisplay.SelectedValue as Match).First + " vs. " + (listDisplay.SelectedValue as Match).Second;
                    App.AutoFacContainer.Resolve<VenuesRespository>().MatchChosen = (listDisplay.SelectedValue as Match).First + " vs. " + (listDisplay.SelectedValue as Match).Second;
                    App.AutoFacContainer.Resolve<VenuesRespository>().MatchDateChosen = (listDisplay.SelectedValue as Match).Date.ToString();

                    App.MManager.PublishMessageByType<ViewsMessage>
                      (
                      new ViewsMessage()
                      {
                          CurrentAction = ViewsAction.UpdateEventCreation
                      }
                      );
                }

                App.MManager.PublishMessageByType<ViewsMessage>
                    (
                    new ViewsMessage()
                    {
                        CurrentAction = ViewsAction.RetrievePlaces
                    }
                    );

                App.MManager.PublishMessageByType<ViewsMessage>
                    (
                    new ViewsMessage()
                    {
                        CurrentAction = ViewsAction.RetrieveFriends
                    }
                    );

                App.MManager.PublishMessageByType<ViewsMessage>
                    (
                    new ViewsMessage()
                    {
                        CurrentAction = ViewsAction.RetrieveMyEvents
                    }
                    );

                App.MManager.PublishMessageByType<ViewsMessage>
                     (
                     new ViewsMessage()
                     {
                         CurrentAction = ViewsAction.RetrieveFriendsEvents
                     }
                     );
            };
        }

        private void RetrieveMatches(String ArgA, String ArgB)
        {
            ChoiceA = ArgA;
            ChoiceB = ArgB;

            if (ArgA == "Euro")
                webBrowser1.Navigate(new Uri("http://www.goalzz.com/main.aspx?c=3730&stage=1&sch=true"));
            else if (ArgA == "English")
            {
                string add = "";
                if (DateTime.Now.Month == 6)
                {
                    add = (DateTime.Now.Month + 2).ToString();
                }
                else if (DateTime.Now.Month == 7)
                {
                    add = (DateTime.Now.Month + 1).ToString();
                }
                else
                    add = (DateTime.Now.Month).ToString();
                string browse = "http://www.goalzz.com/main.aspx?c=7425&stage=1&smonth=2011" + "0" + add;
                webBrowser1.Navigate(new Uri(browse));
            }
        }

        private void webBrowser1_Navigated(object sender, NavigationEventArgs e)
        {
            MatchRetriever ret = new MatchRetriever();
            var w = sender as WebBrowser;
            ret.rtext = w.SaveToString();
            string choice = ChoiceA;
            string team = ChoiceB;

            //m.Matches = new List<Match>();
            ret.GetMatches(choice, team);

            foreach (Match k in ret.Matches)
                listDisplay.Items.Add(k);
        }

        [ReceiveMessage(true)]
        public void ReceiveMessage(object Message)
        {
            int Count = listDisplay.Items.Count;

            for (int i = 0; i < Count; i++)
                listDisplay.Items.RemoveAt(listDisplay.Items.Count - 1);

            ViewsMessage Msg = ((ViewsMessage)Message);

            RetrieveMatches("English", Msg.MessageObject as String);
        }
    }
}