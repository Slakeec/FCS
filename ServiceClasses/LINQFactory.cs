using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;

namespace ServiceClasses
{
    public class LINQFactory
    {
        public static List<string> GetMyMatch(int userId, int round)
        {
            using (var context = new Context())
            {
                int number = context.Teams.First(t => t.UserId == userId && t.MyTeam == true).Number;
                int sop = Repository.Cnt + 1 - number;
                for (int j=1; j<round; j++)
                {
                    if (sop==Repository.Cnt)
                    {
                        sop = 1;
                    }
                    sop++;
                }
                if (sop==number)
                {
                    sop = Repository.Cnt;
                }
                string name1 = context.Teams.First(t => t.UserId == userId && t.MyTeam == true).Name;
                string name2 = context.Teams.First(t => t.UserId == userId && t.Number == sop).Name;
                return new List<string>
                {
                    name1,name2
                };
            }
        }
        public static bool IsLogin(string login)
        {
            using (var context = new Context())
            {
                return context.Users.Any(u => u.Login == login);
            }
        }
        public static bool IsLoginAndPassword(string login, string password)
        {
            using (var context = new Context())
            {
                string p = Hashing.HashPaswword(password);
                return context.Users.Any(u => u.Login == login && u.Password == p);
            }
        }
        public static bool HasACareer(string login)
        {
            using (var context = new Context())
            {
                int id = context.Users.First(u => u.Login == login).Id;
                return context.Teams.Any(t => t.UserId == id);
            }
        }
        public static int GetUserIdByLogin(string login)
        {
            using (var context = new Context())
            {
                int id = context.Users.First(u => u.Login == login).Id;
                return id;
            }
        }
        public static List<Team> GetTeamsByUser(int userID)
        {
            using (var context = new Context())
            {
                return context.Teams.Where(t => t.UserId == userID).ToList();
            }
        }
        public static Team GetTeamByUserAndNumber(int userId, int number)
        {
            using (var context = new Context())
            {
                return context.Teams.First(t => t.UserId == userId && t.Number == number);
            }
        }
        public static List<Player> GetPlayersByTeam(int teamId)
        {
            using (var context = new Context())
            {
                return context.Players.Where(p => p.TeamId == teamId).ToList();
            }
        }
        public static bool IsMyTeam(int teamId)
        {
            using (var context = new Context())
            {
                return context.Teams.First(t => t.Id == teamId).MyTeam;
            }
        }
        public static void TeamWin(int teamId)
        {
            using (var context = new Context())
            {
                context.Teams.First(t => t.Id == teamId).Games++;
                context.Teams.First(t => t.Id == teamId).Points += 3;
                context.SaveChanges();
            }
        }
        public static void TeamDraw(int teamId)
        {
            using (var context = new Context())
            {
                context.Teams.First(t => t.Id == teamId).Games++;
                context.Teams.First(t => t.Id == teamId).Points += 1;
                context.SaveChanges();
            }
        }
        public static void TeamLose(int teamId)
        {
            using (var context = new Context())
            {
                context.Teams.First(t => t.Id == teamId).Games++;
                context.SaveChanges();
            }
        }
        public static void PlayerGame(int playerId)
        {
            using (var context = new Context())
            {
                context.Players.First(p => p.Id == playerId).Games++;
                context.SaveChanges();
            }
        }
        public static void PlayerScore(int playerId)
        {
            using (var context = new Context())
            {
                context.Players.First(p => p.Id == playerId).Goals++;
                context.SaveChanges();
            }
        }
        public static int Round(int userId)
        {
            using (var context = new Context())
            {
                return context.Teams.First(t => t.UserId == userId).Games + 1;
            }
        }
        public static void PlayerScoreByName(string name, int teamId)
        {
            using (var context = new Context())
            {
                context.Players.First(p => p.Name == name && p.TeamId==teamId).Goals++;
                context.SaveChanges();
            }
        }
        public static void MakeMatch(int team1, int team2, List<int>players1, List<int>players2,
             int goal1, int goal2, int round, int userId)
        {
            using (var context = new Context())
            {
                string name1 = LINQFactory.GetTeamNameById(team1);
                string name2 = LINQFactory.GetTeamNameById(team2);
                context.Matches.Add(new Match(team1, team2, players1, players2, goal1, goal2, round, userId, name1, name2));
                context.SaveChanges();
            }
        }
        public static List<Match> GetResults(int userId, int round)
        {
            using (var context = new Context())
            {
                return context.Matches.Where(m => m.UserId == userId && m.Round == round).ToList();
            }
        }
        public static List<int> GetPlayersId(int teamId)
        {
            using (var context = new Context())
            {
                List<Player> players = context.Players.Where(p => p.TeamId == teamId).ToList();
                List<int> ans = new List<int>();
                for (int i=0; i<players.Count; i++)
                {
                    ans.Add(players[i].Id);
                }
                return ans;
            }

        }
        public static int GetRatingById(int teamId)
        {
            using (var context = new Context())
            {
                return context.Teams.First(t => t.Id == teamId).Rating;
            }
        }
        public static List<Player> GetPlayersById(List<int>ids)
        {
            using (var context = new Context())
            {
                List<Player> players = new List<Player>();
                foreach (int id in ids)
                {
                    Player p = context.Players.First(pl => pl.Id == id);
                    players.Add(p);
                }
                return players;
            }
        }
        public static List<string> GetNamesById(List<int> ids)
        {
            using (var context = new Context())
            {
                List<string> players = new List<string>();
                foreach (int id in ids)
                {
                    string p = context.Players.First(pl => pl.Id == id).Name;
                    players.Add(p);
                }
                return players;
            }
        }
        public static string GetTeamNameById(int teamId)
        {
            using (var context = new Context())
            {
                return context.Teams.First(t => t.Id == teamId).Name;
            }
        }
        public static void RatingCalculator(int teamId1, int teamId2, int result)
        {
            using (var context = new Context())
            {
                if (result==1)
                {
                    int rating1 = context.Teams.First(t => t.Id == teamId1).Rating;
                    int rating2 = context.Teams.First(t => t.Id == teamId2).Rating;
                    int plus = (int)Math.Round(75.0 * rating2 / rating1);
                    context.Teams.First(t => t.Id == teamId1).Rating += plus;
                    context.SaveChanges();
                }
                if (result == 0)
                {
                    int rating1 = context.Teams.First(t => t.Id == teamId1).Rating;
                    int rating2 = context.Teams.First(t => t.Id == teamId2).Rating;
                    int plus = rating1 == rating2 ? 0 :
                               rating1 > rating2 ? (int)Math.Round(37.5 * rating2 / rating1) :
                               (int)Math.Round(-37.5 * rating2 / rating1);
                    context.Teams.First(t => t.Id == teamId1).Rating += plus;
                    context.SaveChanges();
                }
                if (result==-1)
                {
                    int rating1 = context.Teams.First(t => t.Id == teamId1).Rating;
                    int rating2 = context.Teams.First(t => t.Id == teamId2).Rating;
                    int plus = (int)Math.Round(-75.0 * rating1 / rating2);
                    context.Teams.First(t => t.Id == teamId1).Rating += plus;
                    context.SaveChanges();
                }
            }
        }
        public static int GetPointsById(int userId)
        {
            using (var context = new Context())
            {
                return context.Teams.First(t => t.UserId == userId && t.MyTeam == true).Points;
            }
        }
        public static string GetPhoto(int userId, string name)
        {
            using (var context = new Context())
            {
                return context.Teams.First(t => t.UserId == userId && t.Name == name).Picture;
            }
        }
    }
}
