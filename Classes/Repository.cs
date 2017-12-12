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
        private List<int> teams;
        public List<int> Teams
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
            this.Teams = new List<int>
            {
                57,61,62,64,65,66,73,78,81,86,94,95,98,100,108,109
            };
        }
    }
}
