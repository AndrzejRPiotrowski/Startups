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
using StrefaKibicaGeek.Messages;
using MES.Library.Mvvm.Attributes;

namespace StrefaKibicaGeek.Views
{
    public partial class TeamsView : PhoneApplicationPage
    {
        List<String> Teams = new List<String>();

        bool IsPopulated = false;

        public TeamsView()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(OnViewLoaded);
        }

        private void OnViewLoaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = this;

            App.MManager.SubscribeByMessageTypeAndCondition<ViewsMessage>
                (
                this,
                new Predicate<object>
                    (
                    (Msg) => { return ((ViewsMessage)Msg).CurrentAction == ViewsAction.RetrieveTeams; }
                    )
                );

            listDisplay.SelectionChanged += (Subsender, Sube) =>
                {
                    Team.Text = listDisplay.SelectedValue as String;

                    App.MManager.PublishMessageByType<ViewsMessage>
                        (
                        new ViewsMessage()
                        {
                            CurrentAction = ViewsAction.RetrieveMatches,
                            MessageObject = listDisplay.SelectedValue as String
                        }
                        );

                    App.MManager.PublishMessageByType<ViewsMessage>
                      (
                      new ViewsMessage()
                      {
                          CurrentAction = ViewsAction.UpdateEventCreation
                      }
                      );
                };

            Teams.Add("Arsenal FC");
            Teams.Add("Aston Villa");
            Teams.Add("Blackburn Rovers FC");
            Teams.Add("Bolton Wanderers");
            Teams.Add("Chelsea FC");
            Teams.Add("Everton FC");
            Teams.Add("Fulham FC");
            Teams.Add("Liverpool");
            Teams.Add("Manchester City");
            Teams.Add("Manchester United");
            Teams.Add("Newcastle United FC");
            Teams.Add("Norwich City");
            Teams.Add("Queens Park Rangers");
            Teams.Add("Stoke City FC");
            Teams.Add("Sunderland");
            Teams.Add("Swansea City AFC");
            Teams.Add("Tottenham Hotspur");
            Teams.Add("West Bromwich Albion FC");
            Teams.Add("Wigan Athletic");
            Teams.Add("Wolverhampton Wanderers FC");

            ReceiveMessage("");
        }

        [ReceiveMessage(true)]
        public void ReceiveMessage(object Message)
        {
            if (!IsPopulated)
            {
                IsPopulated = true;

                for (int i = 0; i < Teams.Count; i++)
                    listDisplay.Items.Add(Teams[i]);
            }
        }
    }
}