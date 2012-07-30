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
using System.Collections.Generic;

using Autofac;
using Autofac.Util;

using StrefaKibicaGeek.Models;
using StrefaKibicaGeek.Respositories;
using StrefaKibicaGeek.Retreivers;
using System.IO.IsolatedStorage;
using System.IO;

namespace StrefaKibicaGeek.Modules
{
    public class VenuesGenerator
    {
        private const double DistanceDifference = 0.0118D; // long, lat equal to almost 1004 meters
        private const double Radius = 750; // Searching in a radius of 750 meters

        private Point OrigLocation;
        private Point ToSearchLocation;
        private List<Point> ToSearchLocations;
        private List<String> FoodKeywords;

        VenuesRvr Rvr = new VenuesRvr();

        public VenuesGenerator()
        {
            ToSearchLocations = new List<Point>();
            FoodKeywords = new List<String>()
                { 
                    "restaurant",
                    "cafe"
                };

            //,
            //        "makan",
            //        "makanan", 
            //        "food",
            //        "coffee",
            //        "café"
        }

        public void DoSearchAllVenues(Point SearchLocation)
        {
            this.OrigLocation = SearchLocation;
            this.ToSearchLocation = SearchLocation;

            // Purpose: To search each of the locations based on each keyword.
            GetAllVenuesSingleLocation();
        }

        private void GetAllLocationsAround()
        {
            if (OrigLocation.X == 0 || OrigLocation.Y == 0)
                return;

            double Distance = DistanceDifference / 2;

            ToSearchLocations.Add(new Point(OrigLocation.X + Distance, OrigLocation.Y));
            ToSearchLocations.Add(new Point(OrigLocation.X - Distance, OrigLocation.Y));
            ToSearchLocations.Add(new Point(OrigLocation.X, OrigLocation.Y + Distance));
            ToSearchLocations.Add(new Point(OrigLocation.X, OrigLocation.Y - Distance));

            ToSearchLocations.Add(new Point(OrigLocation.X + Distance, OrigLocation.Y + Distance));
            ToSearchLocations.Add(new Point(OrigLocation.X - Distance, OrigLocation.Y + Distance));
            ToSearchLocations.Add(new Point(OrigLocation.X - Distance, OrigLocation.Y - Distance));
            ToSearchLocations.Add(new Point(OrigLocation.X + Distance, OrigLocation.Y - Distance));
        }

        private void GetAllVenuesSeveralLocations()
        {
            if (ToSearchLocations.Count > 0)
            {
                for (int i = 0; i < FoodKeywords.Count; i++)
                    for (int j = 0; j < ToSearchLocations.Count; j++)
                        new VenuesRvr().DoFetchMiniVenuesData(Radius, ToSearchLocations[j], FoodKeywords[i]);
            }
        }

        private void GetAllVenuesSingleLocation()
        {
            if (ToSearchLocation.X == 0 || ToSearchLocation.Y == 0)
                throw new Exception("Location X or Y provided is equal to zero.");

            for (int i = 0; i < FoodKeywords.Count; i++)
                new VenuesRvr().DoFetchMiniVenuesData(Radius, OrigLocation, FoodKeywords[i]);
        }

        private void GetAllVenuesFromDummyModel()
        {
        }

        #region "Utility Functions"

        #endregion

        ~VenuesGenerator()
        {}
    }
}
