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
using StrefaKibicaGeek.SvcProvider;
using System.Collections.ObjectModel;
using StrefaKibicaGeek.Model;
using StrefaKibicaGeek.ViewModel;
using MES.Library.Mvvm.Attributes;
using StrefaKibicaGeek.Messages;

namespace StrefaKibicaGeek.Views
{
    public partial class FriendsView : UserControl
    {

        public class Friend
        {
            public String Name
            { set; get; }
        }

        public FriendsView()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(FriendListControl_Loaded);
        }

        void FriendListControl_Loaded(object sender, RoutedEventArgs e)
        {
            App.MManager.SubscribeByMessageTypeAndCondition<ViewsMessage>
                (
                this,
                new Predicate<object>
                    (
                    (Msg) => { return ((ViewsMessage)Msg).CurrentAction == ViewsAction.RetrieveFriends; }
                    )
                );

            List<String> Names = new List<string>()
            {
              "Santiago Mike" ,
"Art Owensby" ,
"Trinidad Venturi" ,
"Dewayne Vassel" ,
"Neville Ginder" ,
"Gaylord Schuck" ,
"Jackie Riffe",
"Ed Kicklighter",
"Modesto Saucedo",
"Pedro Josephs",
"Eddie Manzanares",
"Mason Doss",
"Lawerence Lepine",
"Mack Nicolson",
"Elroy Foran",
"Wm Danley",
"Daniel Mccawley",
"Lyman Bagley",
"Kenton Marron",
"Ike Guzman",
"Lonnie Ardis",
"Carmelo Mainor",
"Raul Hughey",
"Reggie Skyles",
"Donte Murguia",
"Drew Ogan",
"Bennie Feingold",
"Eusebio Ryman",
"Olin Bolds",
"Jerold Copland"
            };

            for (int i = 0; i < Names.Count; i++)
                listDisplay.Items.Add(new Friend() { Name = Names[i] }); ;

        }

        [ReceiveMessage(true)]
        public void ReceiveMessage(object Message)
        {
        }

    }
}
