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

namespace StrefaKibicaGeek.ViewModel
{
    public class FriendListVM : ViewModelBase
    {
        ObservableCollection<ProfileInfo> list = new ObservableCollection<ProfileInfo>();

        public ObservableCollection<ProfileInfo> FriendList
        {
            get
            {
                return list;
            }
        }

        public string NumberOfFriends
        {
            get { return list.Count.ToString(); }
        }

        public string Beta { get { return "This is dummy"; } }

        public FriendListVM()
        {
            list.Add(new ProfileInfo() { Name = "Loading...", ID = "Please wait..." });
        }

    }
}
