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
using MES.Library.Mvvm;
using Autofac;
using Autofac.Util;
using StrefaKibicaGeek.Messages;
using MES.Library.Mvvm.Attributes;
using StrefaKibicaGeek.Retreivers;
using System.ComponentModel;
using StrefaKibicaGeek.Models;
using StrefaKibicaGeek.Respositories;

namespace StrefaKibicaGeek.Views
{
    public partial class PlacesView : PhoneApplicationPage,  INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool IsPopulated = false;

        /// <summary>
        /// Purpose: Public FirePropertChanged [Function] in order to be called/fired when any property had changed.
        /// </summary>
        /// <param name="PropertyName">Property Name</param>
        public void FirePropertyChanged(String PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

        public List<Venue> Venues
        {
            set;
            get;
        }

        public PlacesView()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(OnViewLoaded);
        }

        private void OnViewLoaded(object sender, RoutedEventArgs e)
        {
            this.Venues = new List<Venue>();

            this.DataContext = this;

            App.MManager.SubscribeByMessageTypeAndCondition<ViewsMessage>
                (
                this,
                new Predicate<object>
                    (
                    (Msg) => { return ((ViewsMessage)Msg).CurrentAction == ViewsAction.RetrievePlaces; }
                    )
                );

            listDisplay.SelectionChanged += (Subsender, Sube) =>
            {
                Place.Text = (listDisplay.SelectedValue as Venue).Name;
                App.AutoFacContainer.Resolve<VenuesRespository>().VenueChosen = (listDisplay.SelectedValue as Venue).Name;


                App.MManager.PublishMessageByType<ViewsMessage>
                  (
                  new ViewsMessage()
                  {
                      CurrentAction = ViewsAction.UpdateEventCreation
                  }
                  );
            };
        }

        [ReceiveMessage(true)]
        public void ReceiveMessage(object Message)
        {
            if (!IsPopulated)
            {
                IsPopulated = true;

                App.AutoFacContainer.Resolve<VenuesRespository>().AfterFilterVenues.Clear();

                // Purpose: Fetching all of the objects from a presisted file
                new VenuesRvr().DoFetchAllVenuesDataFromDummyModel();

                Venues = App.AutoFacContainer.Resolve<VenuesRespository>().AfterFilterVenues;

                FirePropertyChanged("Venues");
            }
        }
    }
}