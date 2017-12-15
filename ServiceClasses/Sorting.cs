using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;

namespace ServiceClasses
{
    public class Sorting
    {
        public static void SortByGoals(List<Player>players)
        {
            for (int i=0; i<players.Count; i++)
            {
                for (int j=1; j<players.Count; j++)
                {
                    if (players[j].Goals>players[j-1].Goals)
                    {
                        var temp = players[j];
                        players[j] = players[j - 1];
                        players[j - 1] = temp;
                    }
                }
            }
        }
        public static List<Team> Sort(List<Team>teams)
        {
            for (int i=0; i<teams.Count; i++)
            {
                for (int j=1; j<teams.Count; j++)
                {
                    if (teams[j].Points>teams[j-1].Points)
                    {
                        var temp = teams[j];
                        teams[j] = teams[j - 1];
                        teams[j - 1] = temp;
                    }
                }
            }
            for (int i=0; i<teams.Count; i++)
            {
                teams[i].Position = i + 1;
            }
            return teams;
        }
    }
}
