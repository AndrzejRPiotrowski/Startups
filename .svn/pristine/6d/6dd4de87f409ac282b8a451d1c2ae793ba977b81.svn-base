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
using System.Windows.Media.Imaging;
using Facebook;
using System.Windows.Data;
using StrefaKibicaGeek.Extensions;

namespace StrefaKibicaGeek.Model
{
    public class ProfileInfo
    {

        public String Name { get; set; }
        public String ID { get; set; }
        public String PictureUrl { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        
        //public String Link { get; set; }
        //public String Gender { get; set; }
        //public String Username { get; set; }
        //public String UpdatedTime { get; set; }
        //public String Bio { get; set; }
        //public String Birthday { get; set; }
        //public String Hometown { get; set; }
        //public String Location { get; set; }
        //public String Picture { get; set; }
        //public String Token { get; set; }
        //public String About { get; set; }
        //public String Education { get; set; }
        //public String InterestedIn { get; set; }
        //public String Religion { get; set; }
        //public String Work { get; set; }
        //public BitmapImage Image { get; set; }

        public ProfileInfo()
        {
            Name = ID = FirstName = LastName = PictureUrl = string.Empty;
        }

        public ProfileInfo(JsonObject ProfileData)
        {
            if (ProfileData != null)
            {
                if (Verifier.Verify(ProfileData, "picture"))
                    this.PictureUrl = ProfileData["picture"] as String;
                if (Verifier.Verify(ProfileData, "name"))
                    this.Name = ProfileData["name"] as String;
                if (Verifier.Verify(ProfileData, "id"))
                    this.ID = ProfileData["id"] as String;
                if (Verifier.Verify(ProfileData, "first_name"))
                    this.FirstName = ProfileData["first_name"] as String;
                if (Verifier.Verify(ProfileData, "last_name"))
                    this.LastName = ProfileData["last_name"] as String;

                //if (Verifier.Verify(ProfileData, "link"))
                //    this.PLink = ProfileData["link"] as String;
                //if (Verifier.Verify(ProfileData, "gender"))
                //    this.PGender = ProfileData["gender"] as String;
                //if (Verifier.Verify(ProfileData, "username"))
                //    this.PUsername = ProfileData["username"] as String;
                //if (Verifier.Verify(ProfileData, "updated_time"))
                //    this.PUpdatedTime = ProfileData["updated_time"] as String;
                //if (Verifier.Verify(ProfileData, "bio"))
                //    this.PBio = ProfileData["bio"] as String;
                //if (Verifier.Verify(ProfileData, "birthday"))
                //    this.PBirthday = ProfileData["birthday"] as String;
                ////this.PAbout = ProfileData["about"] as String;
                //if (Verifier.Verify(ProfileData, "religion"))
                //    this.PReligion = ProfileData["religion"] as String;

                //if (PID != null)
                //    PImage = Downloader.FetchImage(PID);

                //this.PHometown = ProfileData.hometown;
                //this.PEducation = ProfileData.education;
                //this.PInterestedIn = ProfileData.interested_in;
                //this.PLocation = ProfileData.location;
                //this.PPicture = ProfileData.id;
            }

        }

    }

    public class ProfileInfoConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ProfileInfo pf = value as ProfileInfo;
            if (pf != null)
            {
                return pf.Name + " " + pf.ID;
            }
            if (value is string)
            {
                return value;
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
