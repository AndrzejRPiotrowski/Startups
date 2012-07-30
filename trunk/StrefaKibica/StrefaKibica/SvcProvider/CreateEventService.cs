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
    public enum EventPrivacy
    {
        OPEN, CLOSED, SECRET
    }

    public class CreateEventService
    {
        private FacebookClient RFBClient;
        private String FetchString = "/me/events";

        public event EventHandler<NewEventEventArg> NewEventCreated;

        private void OnNewEventCreated(string id)
        {
            var e = NewEventCreated;
            if (e != null)
            {
                e(this, new NewEventEventArg(id)); 
            }
        }

        private static string privacyToString(EventPrivacy ep)
        {
            switch (ep)
            {
                case EventPrivacy.OPEN:
                    return "OPEN";
                case EventPrivacy.CLOSED:
                    return "CLOSED";
                case EventPrivacy.SECRET:
                    return "SECRET";
            }
            return "OPEN";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">Name of event</param>
        /// <param name="description">Description</param>
        /// <param name="startTime">Start Time, UNIX format= 2012-06-14T12:22:23</param>
        /// <param name="endTime">End Time, not needde</param>
        /// <param name="location">Location</param>
        /// <param name="privacy">Privacy type</param>
        public void CreateEvent(string name, string description, string startTime, string endTime, string location, EventPrivacy privacy)
        {
            RFBClient = new FacebookClient(FBAuthenticationService.AccessToken);
            RFBClient.PostCompleted += new EventHandler<FacebookApiEventArgs>(RFBClient_PostCompleted);


            RFBClient.PostAsync(FetchString, new
            {
                name = name,
                start_time = startTime,
                end_time = endTime,
                description = description,
                location = location,
                privacy_type = privacyToString(privacy)
            });
        }

        void RFBClient_PostCompleted(object sender, FacebookApiEventArgs e)
        {
            RFBClient.PostCompleted -= new EventHandler<FacebookApiEventArgs>(RFBClient_PostCompleted);
            if (e.Error == null)
            {
#if !DEBUG
                Stopwatch OStop = new Stopwatch();
                Console.WriteLine("Friends Fetching Started ..");
                OStop.Start();
#endif
                var result = (IDictionary<string, object>)e.GetResultData();
                //if (Verifier.Verify(ResultsObject, "data"))
                //    ResultsArray = ResultsObject["data"] as JsonArray;
                var id = result["id"] as string;

                OnNewEventCreated(id);
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
