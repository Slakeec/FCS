using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;
namespace ServiceClasses
{
    public class MultiPlayerServise
    {
        public static List<string> GetSquadFromName(string name)
        {
            int ind = 0;
            for (int i=0; i<Repository.Cnt; i++)
            {
                if ((new Repository()).TeamNames[i]==name)
                {
                    ind = (new Repository()).TeamsId[i];
                }
            }
            List<Player> players = Repository.GetTeam(ind).Players;
            List<string> ans = new List<string>();
            for (int i=0; i<players.Count; i++)
            {
                ans.Add(players[i].Name);
            }
            return ans;
        }
    }
}
