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
using System.IO.IsolatedStorage;
using System.IO;
using System.Xml.Serialization;
using StrefaKibicaGeek.Models;
using StrefaKibicaGeek.Respositories;
using System.Collections.Generic;

namespace StrefaKibicaGeek.Modules
{
    public class ObjectsPresistor
    {
        private IsolatedStorageFile AppIsolatedDirectory;
        private const String VenuesDirectoryName = "VenuesDirectory"; 
        private const String VenuesFileName = "VenuesPersistance.xml";
        private readonly String VenuesFullDirectory;

        public ObjectsPresistor()
        {
            AppIsolatedDirectory = IsolatedStorageFile.GetUserStoreForApplication();
            VenuesFullDirectory = VenuesDirectoryName + "\\" + VenuesFileName;
        }

        public void DoCreateDirectory()
        {
            if (AppIsolatedDirectory != null)
            {
                if (!AppIsolatedDirectory.DirectoryExists(VenuesDirectoryName))
                    AppIsolatedDirectory.CreateDirectory(VenuesDirectoryName);
            }
        }

        public void DoDeleteDirectory()
        {
            if (AppIsolatedDirectory != null)
            {
                if (AppIsolatedDirectory.DirectoryExists(VenuesDirectoryName))
                    AppIsolatedDirectory.DeleteDirectory(VenuesDirectoryName);
            }
        }

        public void DoCreateVenuesFile()
        {
            if (AppIsolatedDirectory != null)
            {
                if (!AppIsolatedDirectory.FileExists(VenuesFullDirectory))
                    AppIsolatedDirectory.CreateFile(VenuesFullDirectory);
            }
        }

        public void DoDeleteVenuesFile()
        {
            if (AppIsolatedDirectory != null)
            {
                if (AppIsolatedDirectory.FileExists(VenuesFullDirectory))
                    AppIsolatedDirectory.DeleteFile(VenuesFullDirectory);
            }
        }

        public void DoPresistVenues(List<Venue> MiniVenueToPresist)
        {
            using (var myFileStream = new IsolatedStorageFileStream(VenuesFullDirectory, FileMode.OpenOrCreate,
                FileAccess.Write, AppIsolatedDirectory))
            {
                    XmlSerializer OXmlSerializer = new XmlSerializer(typeof(List<Venue>));
                    OXmlSerializer.Serialize(myFileStream, MiniVenueToPresist);
                    myFileStream.Close();
            }
        }

        public List<Venue> DoLoadPresistedVenues()
        {
            List<Venue> TempMiniVenue = null;

            if (AppIsolatedDirectory.FileExists(VenuesFullDirectory))
            {
                using (var myFileStream = new IsolatedStorageFileStream(VenuesFullDirectory, FileMode.OpenOrCreate, FileAccess.Read, AppIsolatedDirectory))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(List<Venue>));
                    TempMiniVenue = xml.Deserialize(myFileStream) as List<Venue>;
                    myFileStream.Close();
                }
            }

            return TempMiniVenue;
        }

        public void DoPresistVenues(List<Venue> MiniVenueToPresist, String FileName)
        {
            using (var myFileStream = new IsolatedStorageFileStream(VenuesDirectoryName + "\\" + FileName + ".xml", FileMode.OpenOrCreate,
                FileAccess.Write, AppIsolatedDirectory))
            {
                XmlSerializer OXmlSerializer = new XmlSerializer(typeof(List<Venue>));
                OXmlSerializer.Serialize(myFileStream, MiniVenueToPresist);
                myFileStream.Close();
            }
        }

        public List<Venue> DoLoadPresistedVenues(String FileName)
        {
            List<Venue> TempMiniVenue = null;

            using (var myFileStream = new IsolatedStorageFileStream(VenuesDirectoryName + "\\" + FileName + ".xml", FileMode.OpenOrCreate, FileAccess.Read, AppIsolatedDirectory))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Venue>));
                TempMiniVenue = xml.Deserialize(myFileStream) as List<Venue>;
                myFileStream.Close();
            }

            return TempMiniVenue;
        }

        public void ClearDirectories()
        {
            DoDeleteVenuesFile();
            DoDeleteDirectory();
        }
    }
}
