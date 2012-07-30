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
using StrefaKibicaGeek.ViewModel;

namespace StrefaKibicaGeek.Views
{
    public partial class FriendsEventsView : PhoneApplicationPage
    {
        public FriendsEventsView()
        {
            InitializeComponent();

            this.Loaded += (sender, e) =>
            {
                listDisplay.Items.Add
                    (
                    new EventInfo()
                    {
                        FriendName = "Daniel Mccawley",
                        EventName = "Blackburn vs. Arsenal FC",
                        EventDate = DateTime.Now.AddDays(73),
                        Description = "StrefaKibica with old friends",
                        Place = "Restoran Maju, Seksyen 7, Shah Alam"
                    }
                    );

                listDisplay.Items.Add
                    (
                    new EventInfo()
                    {
                        FriendName = "Bennie Feingold",
                        EventName = "Stoke City FC vs. Chelsea",
                        EventDate = DateTime.Now.AddDays(95),
                        Description = "Restoran dinner watch StrefaKibica",
                        Place = "Seksyen 7"
                    }
                    );

                listDisplay.Items.Add
                        (
                        new EventInfo()
                        {
                            FriendName = "Raul Hughey",
                            EventName = "Swansea FC vs. Everton",
                            EventDate = DateTime.Now.AddDays(65),
                            Description = "StrefaKibica with friends",
                            Place = "Seksyen 8"
                        }
                        );
            };
        }
    }
}