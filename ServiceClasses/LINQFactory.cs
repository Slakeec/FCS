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
            }
        }
        public static void TeamDraw(int teamId)
        {
            using (var context = new Context())
            {
                context.Teams.First(t => t.Id == teamId).Games++;
                context.Teams.First(t => t.Id == teamId).Points += 1;
            }
        }
        public static void TeamLose(int teamId)
        {
            using (var context = new Context())
            {
                context.Teams.First(t => t.Id == teamId).Games++;
            }
        }
        public static void PlayerGame(int playerId)
        {
            using (var context = new Context())
            {
                context.Players.First(p => p.Id == playerId).Games++;
            }
        }
        public static void PlayerScore(int playerId)
        {
            using (var context = new Context())
            {
                context.Players.First(p => p.Id == playerId).Goals++;
            }
        }
        public static int Round(int userId)
        {
            using (var context = new Context())
            {
                return context.Teams.First(t => t.UserId == userId).Games + 1;
            }
        }
        public static void PlayerScoreByName(string name)
        {
            using (var context = new Context())
            {
                context.Players.First(p => p.Name == name).Goals++;
            }
        }
    }
}
