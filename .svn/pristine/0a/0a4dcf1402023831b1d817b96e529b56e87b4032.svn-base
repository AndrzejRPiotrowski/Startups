using System;
using System.Linq;
using System.Net;
using System.IO;
using System.Collections.Generic;

namespace ScheduleParser
{
    public class MatchRetriever
    {
        public List<Match> Matches { get; set; }
        private string euro = "http://www.goalzz.com/main.aspx?c=3730&stage=1&sch=true";
        private string english = "http://www.goalzz.com/main.aspx?c=7425&stage=1&smonth=2011";

        public MatchRetriever()
        {
            Matches = new List<Match>();
        }

        public List<Match> RetrieveMatches(string team, int month, string league)
        {
            WebRequest web=null;
            if(league.Equals("Euro"))
                web = WebRequest.Create("http://www.goalzz.com/main.aspx?c=3730&stage=1&sch=true");
            else if (league.Equals("English"))
            {
                string m="";
                if (month <= 9 && month > 7)
                    m = english + '0' + month.ToString();
                else if (month > 9)
                    m = english + month.ToString();
                else
                    return Matches;
                web = WebRequest.Create(m);
            }

            HttpWebResponse response = (HttpWebResponse)web.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string[] bh = { };
            while (!reader.EndOfStream)
            {
                string text = reader.ReadLine();
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
                        cur = new DateTime(int.Parse(bh[2])+1, int.Parse(bh[1]), int.Parse(bh[0]), int.Parse(words[4].Substring(1, 2)), int.Parse(words[4].Substring(4, 2)), 0);
                        if((first!=team && second!=team) || (DateTime.Now>cur))
                            continue;
                        Match match = new Match();
                        match.First = first;
                        match.Second = second;                
                        match.Date = cur;                        
                        Matches.Add(match);
                    }
                }
            }
            reader.Close();
            dataStream.Close();
            response.Close();

            return Matches;
        }

        public List<Match> GetMatches(string choice, string team)
        {
            if (choice.Equals("English"))
            {
                for (int index = 0; index <= 2; index++)
                {
                   
                    if (DateTime.Now.Month == 6)
                    {
                        RetrieveMatches(team, DateTime.Now.Month + 2 + index, choice);
                    }
                    else if (DateTime.Now.Month == 7)
                    {
                        RetrieveMatches(team, DateTime.Now.Month + 1 + index, choice);
                    }
                    else
                        RetrieveMatches(team, DateTime.Now.Month + index, choice);

                }
            }
            else if (choice.Equals("Euro"))
            {
                
                RetrieveMatches(team, DateTime.Now.Month, choice);                
            }

            return Matches;
        }

    }
}
