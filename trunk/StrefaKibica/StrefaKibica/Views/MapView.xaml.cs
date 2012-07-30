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
using Microsoft.Phone.Controls.Maps;

namespace StrefaKibicaGeek.Views
{
    public partial class MapView : PhoneApplicationPage
    {
        public MapView()
        {
            InitializeComponent();

            this.Loaded += (sender, e) =>
                {
                    Pushpin pin = new Pushpin();
                    pin.Height = 10;
                    pin.Width = 10;
                    pin.Background = new SolidColorBrush(Colors.Blue);
                    pin.Location = new System.Device.Location.GeoCoordinate(3.064153, 101.48303);
                    MapControl.Children.Add(pin);

                    Pushpin pin1 = new Pushpin();
                    pin1.Height = 10;
                    pin1.Width = 10;
                    pin.Background = new SolidColorBrush(Colors.Magenta);
                    pin1.Location = new System.Device.Location.GeoCoordinate(3.064432, 101.692843);
                    MapControl.Children.Add(pin1);
                    
                };
        }
    }
}