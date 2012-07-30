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
using StrefaKibicaGeek.SvcProvider;
using System.Collections.Generic;
using MES.Library.Mvvm;

using Autofac;
using Autofac.Util;

namespace StrefaKibicaGeek.ViewModel
{
    public class EventListVM : ViewModelBase
    {
        ObservableCollection<Event> list = new ObservableCollection<Event>();
        MyEventsService svc = null;
        //FriendsEventsService svcF2 = null;
        Dictionary<string, FriendsEventsService> friendRtvrSvcs = new Dictionary<string, FriendsEventsService>();

        public ObservableCollection<Event> EventList
        {
            get
            {
                return list;
            }
        }

        public Action<Action> UIAction { get; set; }

        public string NumberOfEvents
        {
            get { return list.Count.ToString(); }
        }


        public EventListVM()
        {
            list.Add(new Event() { Name = "Loading...", Description = "Please wait..." });

            App.MManager.SubscribeByMessageType<FriendListMessage>(this);
        }

        [MES.Library.Mvvm.Attributes.ReceiveMessage(true)]
        public void messageReceived(object msg)
        {
            var m = msg as FriendListMessage;
            if (m != null)
            {
                foreach (var item in m.FriendIDList)
                {
                    var svcF2 = new FriendsEventsService(item); //m.FriendIDList[0]);
                    svcF2.EventListUpdated += new EventHandler<EventListEventArg>(svcF2_EventListUpdated);

                    friendRtvrSvcs.Add(item, svcF2);

                    svcF2.GetEventsList();
                }
            }
        }
        
        public void RetrieveEvents()
        {
            svc = new MyEventsService();
            svc.EventListUpdated += new EventHandler<EventListEventArg>(svc_EventListUpdated);
            svc.GetEventsList();

        }

        void svcF2_EventListUpdated(object sender, EventListEventArg e)
        {
            UIAction(() => updateDataSource(e.List));
            //App.Current.RootVisual.Dispatcher.BeginInvoke(() => updateDataSource(e.List));
            //updateDataSource(e.List);
            if (friendRtvrSvcs.ContainsKey(e.ID))
                friendRtvrSvcs[e.ID].EventListUpdated -= new EventHandler<EventListEventArg>(svcF2_EventListUpdated);
        }

        void svc_EventListUpdated(object sender, EventListEventArg e)
        {
            UIAction(() => updateDataSource(e.List));
            //App.Current.RootVisual.Dispatcher.BeginInvoke(() => updateDataSource(e.List));
            //updateDataSource(e.List);
            svc.EventListUpdated -= new EventHandler<EventListEventArg>(svc_EventListUpdated);
        }

        static object lck = new object();
        void updateDataSource(ObservableCollection<Event> list)
        {
            lock (lck)
            {
                foreach (var item in list)
                {
                    if (filterEvent(item))
                        this.EventList.Add(item);
                }
            }
        }

        private bool filterEvent(Event e)
        {
            var name = e.Name;
            if (name.ToLower().Contains("vs") ||
                name.ToLower().Contains("vs."))
                return true;

            return false;
        }
    }
}
