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

namespace StrefaKibicaGeek.Views
{
    public class EventInfo
    {
        public String FriendName
        { set; get; }

        public String EventName
        { set; get; }

        public DateTime EventDate
        { set; get; }

        public String Place
        { set; get; }

        public String Description
        { set; get; }
    }

    public partial class MyEventsView : PhoneApplicationPage
    {

        public MyEventsView()
        {
            InitializeComponent();

            this.Loaded += (sender, e) =>
                {
                    listDisplay.Items.Add
                        (
                        new EventInfo() 
                        {
                            EventName = "Arsenal FC vs. Manchester City",
                            EventDate = DateTime.Now.AddDays(73),
                            Description = "StrefaKibica with old friends",
                            Place ="Restoran Maju, Seksyen 7, Shah Alam"
                        }
                        );

                    listDisplay.Items.Add
                        (
                        new EventInfo()
                        {
                            EventName = "Manchester United FC vs. Sunderland",
                            EventDate = DateTime.Now.AddDays(95),
                            Description = "Restoran dinner watch StrefaKibica",
                            Place = "Seksyen 7"
                        }
                        );

                    listDisplay.Items.Add
                            (
                            new EventInfo()
                            {
                                EventName = "Chelsea FC vs. Liverpool",
                                EventDate = DateTime.Now.AddDays(65),
                                Description = "StrefaKibica with friends",
                                Place = "Seksyen 8"
                            }
                            );
                };
        }
    }
}