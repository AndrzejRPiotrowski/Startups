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

using Autofac;
using Autofac.Util;

using StrefaKibicaGeek.Retreivers;
using StrefaKibicaGeek.Respositories;
using StrefaKibicaGeek.Models;
using StrefaKibicaGeek.Extensions;
using StrefaKibicaGeek.Modules;
using StrefaKibica.Models;
using MES.Library.Mvvm;
using StrefaKibicaGeek.Messages;

namespace StrefaKibicaGeek
{
    public partial class MainPage : PhoneApplicationPage
    {
        ObjectsPresistor _ObjPresistor;
        VenuesGenerator _VGenerator;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            this.Loaded += (sender, e) =>
                {
                    _ObjPresistor = new ObjectsPresistor();
                    _VGenerator = new VenuesGenerator();


                    new VenuesRvr().DoFetchAllVenuesDataFromDummyModel();

                    // Purpose: Create, Clear directories and files
                    _ObjPresistor.ClearDirectories();
                    _ObjPresistor.DoCreateDirectory();
                    _ObjPresistor.DoCreateVenuesFile();
                };

            this.Tap += (sender, e) =>
                {
                    App.MManager.PublishMessageByType<ViewsMessage>
                        (
                        new ViewsMessage()
                        {
                            CurrentAction = ViewsAction.RetrieveTeams
                        }
                        );
                };
        }



    }
}