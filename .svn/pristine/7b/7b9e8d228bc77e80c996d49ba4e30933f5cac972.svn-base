using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Globalization;

/*
 // using System.Globalization;

// fetch the en-GB culture
CultureInfo ukCulture = new CultureInfo("en-GB");
// pass the DateTimeFormat information to DateTime.Parse
DateTime myDateTime = DateTime.Parse("18/09/2004",ukCulture.DateTimeFormat);
 */


namespace Parser
{
    class ParserOlipic :IParser
    {
        private const string filePath = @"F:\strefa\trunk\StrefaKibica\Parser\icaltoxls.csv";

        private DataBaseEntity.DataBase _data = new DataBaseEntity.DataBase();

        public void Start()
        {
            using (var sr = new StreamReader(filePath))
            {
                string line;

                sr.ReadLine();
                while ((line = sr.ReadLine()) != null)
                {

                    var splited = line.Split(',');

                    var name = splited[3].Split(':')[0].Trim('"');
                    var disciplineID = _data.ParserAddDisciple(name);

                    CultureInfo ukCulture = new CultureInfo("en-GB");
                    DateTime DateStart = DateTime.Parse(splited[1].Trim('"'), ukCulture.DateTimeFormat);
                    DateTime DateEnd = DateTime.Parse(splited[2].Trim('"'), ukCulture.DateTimeFormat);

                    _data.ParserAddEvent(splited[3].Trim('"'), DateStart, DateEnd, disciplineID);
                }
                
                var i = 0;
            }

        }
    }
}
