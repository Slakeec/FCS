using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Repository
    {
        private List<string> teams;
        public List<string> Teams
        {
            get { return teams; }
            set { teams = value; }
        }

        static Team GetTeamList(int TeamId)
        {
            using (var client = new HttpClient())
            {
                string Baseurl = " http://api.football-data.org/v1/teams/";
                String EndUrl = "/players";
                String url = Baseurl + TeamId + EndUrl;
                string result = client.GetStringAsync(url).Result;
                return JsonConvert.DeserializeObject<Team>(result);
            }
        }

        
        public Repository()
        {
            this.Teams = new List<string>
            {
                "Arsenal",
                "Chelsea",
                "Manchester United",
                "Manchester City",
                "Liverpool",
                "Barselona",
                "Real Madrid",
                "Atletiko Madrid",
                "Bayern Munchen",
                "Borussia Dortmund",
                "Juventus",
                "Napoli",
                "Roma",
                "Inter",
                "PSG",
                "Monaco",
                "CSKA",
                "Zenit",
                "Spartak",
                "Lokomotiv"
            };
        }
    }
}
