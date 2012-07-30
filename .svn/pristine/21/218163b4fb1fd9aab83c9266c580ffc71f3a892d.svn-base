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
using StrefaKibicaGeek.Extensions;

using Facebook;


namespace StrefaKibicaGeek.Model
{
    //    id	The event ID   generic access_token, user_events or friends_events
    //string //owner	
    //The profile that created the event
    //generic access_token, user_events or friends_events
    //object containing id and name fields
    //name	
    //The event title
    //generic access_token, user_events or friends_events
    //string
    //description	
    //The long-form description of the event
    //generic access_token, user_events or friends_events
    //string
    //start_time	
    //The start time of the event, as you want it to be displayed on facebook
    //generic access_token, user_events or friends_events
    //string containing an ISO-8601 formatted date/time or a UNIX timestamp; if it contains a time zone (not recommended), it will be converted to Pacific time before being stored and displayed
    //end_time	
    //The end time of the event, as you want it to be displayed on facebook
    //generic access_token, user_events or friends_events
    //string containing an ISO-8601 formatted date/time or a UNIX timestamp; if it contains a time zone (not recommended), it will be converted to Pacific time before being stored and displayed
    //location	
    //The location for this event
    //generic access_token, user_events or friends_events
    //string
    //venue	
    //The location of this event
    //generic access_token, user_events or friends_events
    //object containing one or more of the following fields: id, street, city, state, zip, country, latitude, and longitude fields
    //privacy	
    //The visibility of this event
    //generic access_token, user_events or friends_events
    //string containing 'OPEN', 'CLOSED', or 'SECRET'
    //updated_time	
    //The last time the event was updated
    //generic access_token, user_events or friends_events
    //string containing ISO-8601 date-time
    public class Event
    {
        public string ID { get; set; }

        public string OwnerName { get; set; }
        public string OwnerID { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Time { get { return StartTime + " - " + EndTime; } }

        public string Location { get; set; }
        public string Privacy { get; set; }
        public string UpdatedTime { get; set; }

        //public string VenueID { get; set; }
        public string VenueStreet { get; set; }
        public string VenueCity { get; set; }
        public string VenueState { get; set; }
        public string VenueZip { get; set; }
        public string VenueCountry { get; set; }
        public string VenueLat { get; set; }
        public string VenueLong { get; set; }

        public Event()
        {
            Name = ID = OwnerName = OwnerID = Description = string.Empty;
            StartTime = EndTime = Location = Privacy = UpdatedTime = string.Empty;
            VenueStreet = VenueCity = VenueState = VenueZip = VenueCountry = VenueLat = VenueLong = string.Empty;
        }

        public Event(JsonObject ProfileData)
        {
            if (ProfileData != null)
            {
                if (Verifier.Verify(ProfileData, "name"))
                    this.Name = ProfileData["name"] as String;
                if (Verifier.Verify(ProfileData, "id"))
                    this.ID = ProfileData["id"] as String;
                if (Verifier.Verify(ProfileData, "description"))
                    this.Description = ProfileData["description"] as String;
                if (Verifier.Verify(ProfileData, "start_time"))
                    this.StartTime = ProfileData["start_time"] as String;
                if (Verifier.Verify(ProfileData, "end_time"))
                    this.EndTime = ProfileData["end_time"] as String;

                if (Verifier.Verify(ProfileData, "location"))
                    this.Location = ProfileData["location"] as String;
                // venue
                if (Verifier.Verify(ProfileData, "venue"))
                {
                    var venue = ProfileData["venue"] as JsonObject;
                    if (venue != null)
                    {
                        if (Verifier.Verify(ProfileData, "street"))
                            this.VenueStreet = ProfileData["street"] as String;
                        if (Verifier.Verify(ProfileData, "city"))
                            this.VenueCity = ProfileData["city"] as String;
                        if (Verifier.Verify(ProfileData, "state"))
                            this.VenueState = ProfileData["state"] as String;
                        if (Verifier.Verify(ProfileData, "zip"))
                            this.VenueZip = ProfileData["zip"] as String;
                        if (Verifier.Verify(ProfileData, "country"))
                            this.VenueCountry = ProfileData["country"] as String;
                        if (Verifier.Verify(ProfileData, "latitude"))
                            this.VenueLat = ProfileData["latitude"] as String;
                        if (Verifier.Verify(ProfileData, "longitude"))
                            this.VenueLong = ProfileData["longitude"] as String;
                    }
                }


            }

        }

    }
}