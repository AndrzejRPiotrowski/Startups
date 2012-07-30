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
using StrefaKibicaGeek.Respositories;

using Autofac;
using Autofac.Util;

namespace StrefaKibicaGeek.Views
{
    public partial class EventCreationView : PhoneApplicationPage
    {
        public EventCreationView()
        {
            InitializeComponent();

            this.Loaded += (sender, e) =>
                {
                    App.MManager.SubscribeByMessageTypeAndCondition<ViewsMessage>
                        (
                        this,
                        new Predicate<object>
                            (
                            (Msg) => { return ((ViewsMessage)Msg).CurrentAction == ViewsAction.UpdateEventCreation; }
                            )
                        );
                };
        }


        [ReceiveMessage(true)]
        public void ReceiveMessage(object Message)
        {
            MatchChosen.Text = App.AutoFacContainer.Resolve<VenuesRespository>().MatchChosen;
            MatchDateChosen.Text = App.AutoFacContainer.Resolve<VenuesRespository>().MatchDateChosen;
            EventVenueChosen.Text = App.AutoFacContainer.Resolve<VenuesRespository>().VenueChosen;
        }
    }
}