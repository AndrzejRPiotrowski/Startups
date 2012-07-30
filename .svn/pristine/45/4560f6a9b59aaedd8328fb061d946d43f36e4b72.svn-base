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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using StrefaKibicaGeek.Model;
using MES.Library.Mvvm;

using Autofac;
using Autofac.Util;

namespace StrefaKibicaGeek.SvcProvider
{
    public class FriendsListService
    {
        private FacebookClient RFBClient;
        private String FetchString = "/me/friends";

        public class FriendListEventArg : EventArgs
        {
            public FriendListEventArg(ObservableCollection<ProfileInfo> list)
            {
                this.List = list;
            }

            public ObservableCollection<ProfileInfo> List { get; private set; }
        }

        public event EventHandler<FriendListEventArg> FriendListUpdated;
        private void OnFriendListUpdated(ObservableCollection<ProfileInfo> list)
        {
            var e = FriendListUpdated;
            if (e != null)
            {
                e(this, new FriendListEventArg(list));
            }
        }

        public void GetFriendsList()
        {
            RFBClient = new FacebookClient(FBAuthenticationService.AccessToken);
            RFBClient.GetCompleted += new EventHandler<FacebookApiEventArgs>(OnGetFriendsCompleted);
            RFBClient.GetAsync(FetchString);
        }

        private void OnGetFriendsCompleted(object sender, FacebookApiEventArgs e)
        {
            RFBClient.GetCompleted -= new EventHandler<FacebookApiEventArgs>(OnGetFriendsCompleted);

            if (e.Error == null)
            {
#if !DEBUG
                Stopwatch OStop = new Stopwatch();
                Console.WriteLine("Friends Fetching Started ..");
                OStop.Start();
#endif
                var result = (IDictionary<string, object>)e.GetResultData();

                //JsonArray ResultsArray = null;
                //JsonObject ResultsObject = e.GetResultData() as JsonObject;
                ObservableCollection<ProfileInfo> FriendList = new ObservableCollection<ProfileInfo>();
                List<string> ids = new List<string>();

                //if (Verifier.Verify(ResultsObject, "data"))
                //    ResultsArray = ResultsObject["data"] as JsonArray;
                var dataItem = (JsonArray)result["data"];
                foreach (JsonObject item in dataItem)
                {
                    FriendList.Add(new ProfileInfo(item));
                }
                foreach (var item in FriendList)
                {
                    ids.Add(item.ID);
                }

                OnFriendListUpdated(FriendList);


#if !DEBUG
                Console.WriteLine("Friends Fetching Finished in " + OStop.ElapsedMilliseconds);
                OStop.Stop();
#endif

                App.MManager.PublishMessageByType<FriendListMessage>(new FriendListMessage()
                {
                    FriendIDList = ids
                });
            }
            else
            {
            }

        }


    }
}
