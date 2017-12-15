using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;

namespace ServiceClasses
{
    public class LINQStat
    {
        public static List<string> GetTeamInfo(int userID, string teamName)
        {
            using (var context = new Context())
            {
                Team t = context.Teams.First(team => team.UserId == userID && team.Name == teamName);
                if (t == null)
                {
                    return null;
                }
                int max = context.Players.Where(player => player.TeamId == t.Id).Max(pl => pl.Goals);
                Player p = context.Players.First(pl => pl.TeamId == t.Id && pl.Goals == max);
                return new List<string>
                {
                    $"Team Name: {t.Name}",
                    $"Team Games: {t.Games}",
                    $"Team Points: {t.Points}",
                    $"Team Top scorer {p.Name} - {p.Goals} goals"
                };
            }
        }
        //public static List<string> GetPlayerInfo(int userID, string playerName)
        //{
        //    using (var context = new Context())
        //    {
        //        Player p = context.Players.First(player => player.Name == playerName)
        //    }
        //}
    }
}
