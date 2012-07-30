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

namespace StrefaKibicaGeek.Models
{
    public class Venue
    {
        public String ID
        { set; get; }

        public String Name
        { set; get; }

        public int PeopleBeenHere
        { set; get; }

        public int CheckinsNumber
        { set; get; }

        public int NoOfTips
        { set; get; }

        public VenueLocation VenueLoc
        { set; get; }

        public List<VenueTip> VenueTips
        { set; get; }

        public List<String> VenueTags
        { set; get; }

        public List<VenueCategory> VenueCategories
        { set; get; }

        public List<VenueTip> RelevantVenueTips
        { set; get; }

        public Venue()
        {
        }

        public Venue
            (
            String ID, 
            String Name, 
            int PeopleBeenHere, 
            int CheckinsNumber, 
            VenueLocation VenueLoc, 
            List<VenueCategory> VenueCategories = null,
            List<VenueTip> VenueTips = null,
            List<String> VenueTags = null
            )
        {
            RelevantVenueTips = new List<VenueTip>();

            this.ID = ID;
            this.Name = Name;
            this.PeopleBeenHere = PeopleBeenHere;
            this.CheckinsNumber = CheckinsNumber;
            this.VenueLoc = VenueLoc;
            this.VenueTips = VenueTips;
            this.VenueTags = VenueTags;
            this.VenueCategories = VenueCategories;

            if (this.VenueTips != null)
                NoOfTips = this.VenueTips.Count;

            //for (int i = 0; i < 100; i++)
            //    VenueTips.Add(new VenueTip() { TipText = i.ToString() });
        }

        ~Venue()
        {}
    }
}
