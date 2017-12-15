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
                Team t = context.Teams.FirstOrDefault(team => team.UserId == userID && team.Name == teamName);
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
        public static List<string> GetPlayerInfo(int userID, string playerName)
        {
            using (var context = new Context())
            {
                List<Team> teams = context.Teams.Where(t => t.UserId == userID).ToList();
                foreach (var team in teams)
                {
                    Player p = context.Players.FirstOrDefault(player => player.Name == playerName && player.TeamId==team.Id);
                    if (p!=null)
                    {
                        return new List<string>
                        {
                            $"Player name - {p.Name}",
                            $"Player nationality - {p.Nationlity}",
                            $"Player position - {p.Position}",
                            $"Player goals - {p.Goals}"
                        };
                    }
                }
                return null;
            }
        }
        public static List<string> GetTopScorers(int userId)
        {
            using (var context = new Context())
            {
                List<string> ans = new List<string>();
                List<Team> teams = context.Teams.Where(t => t.UserId == userId).ToList();
                List<Player> players = new List<Player>();
                foreach (var team in teams)
                {
                    List<Player> tPlayers = context.Players.Where(p => p.TeamId == team.Id).ToList();
                    foreach (var player in tPlayers)
                    {
                        players.Add(player);
                    }
                }
                Sorting.SortByGoals(players);
                foreach (var player in players)
                {
                    ans.Add($"{player.Name} - {player.Goals} goals");
                }
                return ans;
            }
        }
    }
}
