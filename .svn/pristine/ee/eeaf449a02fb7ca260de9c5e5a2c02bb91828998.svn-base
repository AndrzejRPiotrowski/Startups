#define DUMMY

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

using System.Linq;

using SimpleJson.Main;
using StrefaKibicaGeek.Utils;
using StrefaKibicaGeek.Modules;
using System.Collections.Generic;

using Autofac;
using Autofac.Util;

using StrefaKibicaGeek.Models;
using StrefaKibicaGeek.Respositories;
using System.IO;
using System.IO.IsolatedStorage;
using StrefaKibicaGeek.Extensions;
using System.Threading.Tasks;
using System.ComponentModel;

namespace StrefaKibicaGeek.Retreivers
{
    public class VenuesRvr
    {
        private object SyncObj = new object();

        //private const String VENUES_RADIUS = "2000"; // 2000 Meters of radius
        private const String ACCESS_TOKEN = "VJS0WZKKONSIVQZKV1JFILQTVEWFJ1DCCPLRIQVEZD4LJ1UJ";
        private const String ACCESS_TOKEN_1 = "HQHRO1J4OTSQZGZY4X0XEDS0S10XL5WDGVEWX01DSYN1KEJA";
        private const String ACCESS_TOKEN_2 = "GLR043RJPY1UH4J2G2I5FJEVS0DUZVORSSRBUWI0IEVMNLPQ";
        private const String ACCESS_TOKEN_3 = "GLR043RJPY1UH4J2G2I5FJEVS0DUZVORSSRBUWI0IEVMNLPQ";
        private const String ACCESS_TOKEN_4 = "ABDC4AFCDMACV2S4WHU4QWQJHPQOUYAHPGHZERISGOHP0MDG";

        private const String DATE = "20120602";
        private const String INTENT = "browse";
        private const String LIMIT = "30";

        private BackgroundWorker TipsRetrieverWorker;

        public VenuesRvr()
        {
            TipsRetrieverWorker = new BackgroundWorker();
        }

        public void DoFetchMiniVenuesData(double Radius, Point Location, String QueryKeyword)
        {
            List<Venue> MiniVenues = App.AutoFacContainer.Resolve<VenuesRespository>().PreFilterVenues;

            String FetchingString = String.Format
                (
                "https://api.foursquare.com/v2/venues/search?ll={0}&intent={1}&radius={2}&limit={3}&oauth_token={4}&v={5}&query={6}",
                Location.X.ToString() + "," + Location.Y.ToString(),
                INTENT,
                Radius.ToString(),
                LIMIT,
                ACCESS_TOKEN,
                DATE,
                QueryKeyword
                );

            WebClient RvrWebClient = new WebClient();

            RvrWebClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(
                delegate(object sender, DownloadStringCompletedEventArgs e)
                {
                    if (e.Error == null)
                    {
                        try
                        {
                            Console.WriteLine("Result is {0}", e.Result);

                            JsonObject MainDataObject = SimpleJson.SimpleJson.DeserializeObject(e.Result) as JsonObject;

                            if (Verifier.Verify(MainDataObject, "response"))
                            {
                                JsonObject ResponseObject = MainDataObject["response"] as JsonObject;

                                if (Verifier.Verify(ResponseObject, "venues"))
                                {
                                    JsonArray Venues = ResponseObject["venues"] as JsonArray;

                                    // Purpose: For parsing the venues data
                                    ParseMiniVenues(Venues, MiniVenues);

                                    // Purpose: To remove all of the repeated objects
                                    MiniVenues = MiniVenues.Distinct(new VenuesComparer<Venue>()).ToList<Venue>();

                                    // Purpose: For fetching and populating the detailed venues data based on the venues data retreived
                                    FetchDetailedVenuesData();

                                    // Purpose: For filteration and other purposes
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.Write(ex.Message);
                        }
                    }
                    else
                    {
                    }
                });

            RvrWebClient.DownloadStringAsync(new Uri(FetchingString));
        }

        public void DoFetchAllVenuesDataFromPresistedSource()
        {
            App.AutoFacContainer.Resolve<VenuesRespository>().PreFilterVenues = new ObjectsPresistor().DoLoadPresistedVenues() as List<Venue>;
            FilterAllVenuesByTips();
        }

        public void DoFetchAllVenuesDataFromDummyModel()
        {
            ParseDummyModel();
        }

        #region "Utility Functions"

        private void ParseMiniVenues(JsonArray VenuesData, List<Venue> MiniVenues)
        {
            foreach (JsonObject V in VenuesData)
            {
                int CheckinsCount = 0;
                int UsersCount = 0;

                VenueLocation JsVenueLoc = new VenueLocation();
                List<VenueCategory> JsVenueCategories = new List<VenueCategory>();

                if (Verifier.Verify(V, "stats"))
                {
                    JsonObject Status = V["stats"] as JsonObject;
                    int.TryParse(Status["usersCount"] as String, out UsersCount);
                    int.TryParse(Status["checkinsCount"] as String, out CheckinsCount);
                }

                if (Verifier.Verify(V, "categories"))
                {
                    JsonArray Categories = V["categories"] as JsonArray;

                    foreach (JsonObject C in Categories)
                    {

                        JsVenueCategories.Add(new VenueCategory()
                        {
                            ID = C["id"] as String,
                            Name = C["name"] as String,
                            ShortName = C["shortName"] as String,
                            LongName = C["pluralName"] as String
                        });
                    }
                }

                if (Verifier.Verify(V, "location"))
                {
                    JsonObject Loc = V["location"] as JsonObject;

                    if (Verifier.Verify(Loc, "address"))
                        JsVenueLoc.Address = Loc["address"] as String;

                    if (Verifier.Verify(Loc, "lat"))
                        JsVenueLoc.Latitude = (Double)Loc["lat"];

                    if (Verifier.Verify(Loc, "lng"))
                        JsVenueLoc.Longitude = (Double)Loc["lng"];
                }


                Venue MV = new Venue(
                    V["id"] as String,
                    V["name"] as String,
                    UsersCount,
                    CheckinsCount,
                    JsVenueLoc,
                    JsVenueCategories
                    );

                MiniVenues.Add(MV);
            }
        }

        private void FetchDetailedVenuesData()
        {
            List<Venue> MiniVenues = App.AutoFacContainer.Resolve<VenuesRespository>().PreFilterVenues;

            TipsRetrieverWorker.DoWork += (sender, e) =>
            {
                for (int i = 0; i < MiniVenues.Count; i++)
                {
                    WebClient RvrWebClient = new WebClient();

                    String FetchingString = String.Format
                        (
                        "https://api.foursquare.com/v2/venues/{0}?oauth_token={1}&v={2}",
                        MiniVenues[i].ID,
                        ACCESS_TOKEN,
                        DATE
                        );

                    RvrWebClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(
                        delegate(object Subsender, DownloadStringCompletedEventArgs Sube)
                        {
                            if (Sube.Error == null)
                            {
                                try
                                {
                                    Console.WriteLine("Result is {0}", Sube.Result);

                                    JsonObject MainDataObject = SimpleJson.SimpleJson.DeserializeObject(Sube.Result) as JsonObject;
                                    JsonObject ResponseObject = MainDataObject["response"] as JsonObject;
                                    JsonObject SingleVenue = ResponseObject["venue"] as JsonObject;

                                    if (Verifier.Verify(SingleVenue, "tips"))
                                    {
                                        JsonObject TipsObject = SingleVenue["tips"] as JsonObject;
                                        JsonArray GroupsObject = TipsObject["groups"] as JsonArray;

                                        foreach (JsonObject O in GroupsObject)
                                        {
                                            if (Verifier.Verify(O, "items"))
                                            {
                                                JsonArray TipsItems = O["items"] as JsonArray;

                                                Venue VenueItem = (from Ve in MiniVenues
                                                                   where Ve.ID == SingleVenue["id"] as String
                                                                   select Ve).FirstOrDefault();

                                                foreach (JsonObject T in TipsItems)
                                                {
                                                    VenueItem.VenueTips.Add(new VenueTip() { TipText = T["text"] as String });
                                                }
                                            }
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.Write(ex.Message);
                                }
                            }
                            else
                            {
                            }
                        });

                    RvrWebClient.DownloadStringAsync(new Uri(FetchingString));
                }
            };

            TipsRetrieverWorker.RunWorkerAsync();
        }

        private void FilterAllVenuesByName()
        {
        }

        private void FilterAllVenuesByTags()
        { }

        private void FilterAllVenuesByCategories()
        { }

        private void FilterAllVenuesByTips()
        {
            List<String> Keywords = new List<string>() { "StrefaKibica", "bola", "futsal", "sports", "sport", "match", "league", "goal" };
            List<Venue> PreFilterVenues = App.AutoFacContainer.Resolve<VenuesRespository>().PreFilterVenues;
            List<Venue> AfterFilterVenues = App.AutoFacContainer.Resolve<VenuesRespository>().AfterFilterVenues;

            for (int i = 0; i < PreFilterVenues.Count; i++)
            {
                if (PreFilterVenues[i].VenueTips.Count > 0)
                {
                    for (int j = 0; j < PreFilterVenues[i].VenueTips.Count; j++)
                    {
                        foreach (String S in Keywords)
                        {
                            if (PreFilterVenues[i].VenueTips[j].TipText.Contains(S))
                            {
                                if (!AfterFilterVenues.Contains(PreFilterVenues[i]))
                                {
                                    // Purpose: Adding the relevant venue found
                                    AfterFilterVenues.Add(PreFilterVenues[i]);

                                    // Purpose: Adding the relevant tip to the venue that had just been added
                                    AfterFilterVenues.LastOrDefault().RelevantVenueTips.Add(PreFilterVenues[i].VenueTips[j]);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void ParseDummyModel()
        {
            List<Venue> MiniVenues = App.AutoFacContainer.Resolve<VenuesRespository>().PreFilterVenues;
            FourSquareDataModel M = new FourSquareDataModel();

            for (int i = 0; i < M.VenuesWithTips.Count; i++)
            {
                try
                {
                    if (i != 57)
                    {
                        JsonObject MainDataObject = SimpleJson.SimpleJson.DeserializeObject(M.VenuesWithTips[i]) as JsonObject;
                        JsonObject ResponseObject = MainDataObject["response"] as JsonObject;
                        JsonObject V = ResponseObject["venue"] as JsonObject;


                        int CheckinsCount = 0;
                        int UsersCount = 0;

                        VenueLocation JsVenueLoc = new VenueLocation();
                        List<VenueCategory> JsVenueCategories = new List<VenueCategory>();
                        List<VenueTip> JsVenueTips = new List<VenueTip>();

                        if (Verifier.Verify(V, "tips"))
                        {
                            JsonObject TipsObject = V["tips"] as JsonObject;
                            JsonArray GroupsObject = TipsObject["groups"] as JsonArray;

                            foreach (JsonObject O in GroupsObject)
                            {
                                if (Verifier.Verify(O, "items"))
                                {
                                    JsonArray TipsItems = O["items"] as JsonArray;

                                    foreach (JsonObject T in TipsItems)
                                    {
                                        JsVenueTips.Add(new VenueTip() { TipText = T["text"] as String });
                                    }
                                }
                            }
                        }

                        if (Verifier.Verify(V, "stats"))
                        {
                            JsonObject Status = V["stats"] as JsonObject;
                            int.TryParse(Status["usersCount"] as String, out UsersCount);
                            int.TryParse(Status["checkinsCount"] as String, out CheckinsCount);
                        }

                        if (Verifier.Verify(V, "categories"))
                        {
                            JsonArray Categories = V["categories"] as JsonArray;

                            foreach (JsonObject C in Categories)
                            {
                                JsVenueCategories.Add(new VenueCategory()
                                {
                                    ID = C["id"] as String,
                                    Name = C["name"] as String,
                                    ShortName = C["shortName"] as String,
                                    LongName = C["pluralName"] as String
                                });
                            }
                        }

                        if (Verifier.Verify(V, "location"))
                        {
                            JsonObject Loc = V["location"] as JsonObject;

                            if (Verifier.Verify(V, "address"))
                                JsVenueLoc.Address = Loc["address"] as String;

                            JsVenueLoc.Latitude = (Double)Loc["lat"];
                            JsVenueLoc.Longitude = (Double)Loc["lng"];
                        }

                        Venue MV = new Venue(
                            V["id"] as String,
                            V["name"] as String,
                            UsersCount,
                            CheckinsCount,
                            JsVenueLoc,
                            JsVenueCategories,
                            JsVenueTips
                            );

                        MiniVenues.Add(MV);
                    }
                }
                catch (Exception E)
                {
                    Console.Write(E.Message);
                }
                finally
                { }
            }

            //MiniVenues = MiniVenues.Distinct(new VenuesComparer<Venue>()).ToList();
            FilterAllVenuesByTips();
        }

        //

        #endregion
    }
}


