using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using StrefaKibicaGeek.Model;

namespace StrefaKibicaGeek.SvcProvider
{
    public class EventListEventArg : EventArgs
    {
        public EventListEventArg(string id, ObservableCollection<Event> list)
        {
            this.List = list;
            this.ID = id;
        }

        public ObservableCollection<Event> List { get; private set; }
        public string ID { get; private set; }
    }

    public class NewEventEventArg : EventArgs
    {
        public NewEventEventArg(string id)
        {
            this.ID = id;
        }

        public string ID { get; private set; }
    }

}
