using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Classes
{
    public class Repository
    {
        private List<int> teamsId;
        public List<int> TeamsId
        {
            get { return teamsId; }
            set { teamsId = value; }
        }
        private List<string>teamNames;
        public List<string>TeamNames
        {
            get { return teamNames; }
            set { teamNames = value; }
        }
        private List<int> teamRatings;
        public List<int> TeamRatings 
        {
            get { return teamRatings; }
            set { teamRatings = value; }
        }
        private List<string> colors;
        public List<string> Colors
        {
            get { return colors; }
            set { colors = value; }
        }

        private static int cnt = 16;
        public static int Cnt
        {
            get { return cnt; }
            set { cnt = value; }
        }
        private List<string> time;
        public List<string> Time
        {
            get { return time; }
            set { time = value; }
        }

        public static Team GetTeam(int TeamId)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    //f0e05ec6c77f4a3bbb0b345c9f0d99aa token
                    string Baseurl = " http://api.football-data.org/v1/teams/";
                    String EndUrl = "/players";
                    String url = Baseurl + TeamId + EndUrl;
                    string result = client.GetStringAsync(url).Result;
                    return JsonConvert.DeserializeObject<Team>(result);
                }
            }
            catch(Exception)
            {
                return null;
                
            }
            
        }
        public static string GetTeamPicture(int TeamId)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    //f0e05ec6c77f4a3bbb0b345c9f0d99aa token
                    client.DefaultRequestHeaders.Add("x-auth-token", "f0e05ec6c77f4a3bbb0b345c9f0d99aa");
                    string Baseurl = " http://api.football-data.org/v1/teams/";
                    
                    String url = Baseurl + TeamId;
                    string result = client.GetStringAsync(url).Result;
                    Team pictureExample= JsonConvert.DeserializeObject<Team>(result);
                    return pictureExample.Picture;
                }
            }
            catch (Exception)
            {
                return null;

            }

        }

        public List<Team> GetTeamList()
        {
            List<Team> ans = new List<Team>();
            for (int i=0; i<TeamsId.Count; i++)
            {
                Team t = GetTeam(TeamsId[i]);
                if (t==null)
                {
                    return null;
                }
                t.Name = TeamNames[i];
                ans.Add(t);
            }
            return ans;
        }
        public Repository()
        {
            TeamsId = new List<int>
            {
                57,61,62,64,65,66,73,78,81,86,94,95,98,100,108,109
            };
            TeamNames = new List<string>
            {
                "Arsenal","Chelsea","Everton","Liverpool","Manchester City","Manchester United","Tottenham","Atletico Madrid",
                "Barselona","Real Madrid", "Villyereal","Valencia","Milan","Roma","Inter","Juventus"
            };
            TeamRatings = new List<int>
            {
                1800,2000,1200,1800,2700,2300,1700,2000,2700,3000,1000,2000,1500,2300,2300,2500
            };
            Colors = new List<string>
            {
                "Gold","Orange","Maroon","Blue","Black"
            };
            Time = new List<string>
            {
                "60","90","180"
            };
        }
    }
}
