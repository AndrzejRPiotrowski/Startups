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
using Facebook;
using System.Collections.ObjectModel;
using StrefaKibicaGeek.Model;
using System.Collections.Generic;

namespace StrefaKibicaGeek.SvcProvider
{
    public class FriendsEventsService
    {
        private FacebookClient RFBClient;
        private String FetchString = "/{0}/events";

        public string ID { get; set; }

        public event EventHandler<EventListEventArg> EventListUpdated;

        public FriendsEventsService(string id)
        {
            this.ID = id;
        }

        private void OnEventListUpdated(ObservableCollection<Event> list)
        {
            var e = EventListUpdated;
            if (e != null)
            {
                e(this, new EventListEventArg(ID, list));
            }
        }

        public void GetEventsList()
        {
            string fetchStr = string.Format(FetchString, ID);

            RFBClient = new FacebookClient(FBAuthenticationService.AccessToken);
            RFBClient.GetCompleted += new EventHandler<FacebookApiEventArgs>(OnGetEventsCompleted);
            RFBClient.GetAsync(fetchStr);
        }

        private void OnGetEventsCompleted(object sender, FacebookApiEventArgs e)
        {
            RFBClient.GetCompleted -= new EventHandler<FacebookApiEventArgs>(OnGetEventsCompleted);

            if (e.Error == null)
            {
#if !DEBUG
                Stopwatch OStop = new Stopwatch();
                Console.WriteLine("Friends Fetching Started ..");
                OStop.Start();
#endif
                var result = (IDictionary<string, object>)e.GetResultData();

                ObservableCollection<Event> FriendList = new ObservableCollection<Event>();

                //if (Verifier.Verify(ResultsObject, "data"))
                //    ResultsArray = ResultsObject["data"] as JsonArray;
                var dataItem = (JsonArray)result["data"];
                foreach (JsonObject item in dataItem)
                {
                    FriendList.Add(new Event(item));
                }

                OnEventListUpdated(FriendList);
#if !DEBUG
                Console.WriteLine("Friends Fetching Finished in " + OStop.ElapsedMilliseconds);
                OStop.Stop();
#endif

                //FinishedEvents.NotifyFriendsDataFinished(true, FriendList);
            }
            else
            {
                //FinishedEvents.NotifyFriendsDataFinished(false, null);
            }

        }
    }

}
