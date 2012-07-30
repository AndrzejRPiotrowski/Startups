using System;
using System.Linq;
using System.Net;
using System.IO;
using System.Collections.Generic;
using StrefaKibicaGeek.Models;

namespace StrefaKibica.Models
{
    public class MatchRetriever
    {
        public List<Match> Matches = new List<Match>();
        private string euro = "http://www.goalzz.com/main.aspx?c=3730&stage=1&sch=true";
        private string english = "http://www.goalzz.com/main.aspx?c=7425&stage=1&smonth=2011";
        private string choice, team;
        public string rtext;
        public MatchRetriever()
        {

        }


        public void RetrieveMatches(string team, int month, string league)
        {
            this.choice = league;
            this.team = team;
            string[] bh = { };
            StringReader reader = new StringReader(rtext);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string text = line;
                DateTime cur;
                if (text.Contains("dh(") || text.Contains("mc("))
                {
                    char[] trimChars = { '(', ')', ';' };
                    string format1 = text.Trim(trimChars);
                    string format2 = format1.Remove(0, 3);
                    string[] words = format2.Split(',');
                    if (text[0] == 'd' && text[1] == 'h')
                    {
                        bh = words;
                    }
                    else if (text[0] == 'm' && text[1] == 'c')
                    {
                        string first = words[7].Trim('"');
                        string second = words[12].Trim('"');
                        cur = new DateTime(int.Parse(bh[2]) + 1, int.Parse(bh[1]), int.Parse(bh[0]), int.Parse(words[4].Substring(1, 2)), int.Parse(words[4].Substring(4, 2)), 0);
                        if ((first != team && second != team))
                            continue;
                        Match match = new Match();
                        match.First = first;
                        match.Second = second;
                        match.Date = cur;
                        Matches.Add(match);
                    }
                }
            }
        }


        public void GetMatches(string choice, string team)
        {
            RetrieveMatches(team, DateTime.Now.Month, choice);

        }
        //do what ever 
        //with using e.Result
    }
}
