using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;

namespace ServiceClasses
{
    public class Championship
    {
        public static bool CreateChampionship(string myTeam, int UserId)
        {
            using (var context = new Context())
            {
                List<int> draw = MakeDraw();
                for (int i=0; i<Repository.Cnt; i++)
                {
                    Team t = Repository.GetTeam(new Repository().TeamsId[i]);
                    if (t==null)
                    {
                        return false;
                    }
                    t.Number = draw[i];
                    t.Name = new Repository().TeamNames[i];
                    t.Rating = new Repository().TeamRatings[i];
                    t.MyTeam = t.Name == myTeam;
                    t.UserId = UserId;
                    context.Teams.Add(t);
                    context.SaveChanges();
                }
            }
            return true;
        }
        public static List<int> MakeDraw()
        {
            List<int> list = new List<int>();
            for (int i=0; i<Repository.Cnt; i++)
            {
                list.Add(i + 1);
            }
            Random r = new Random();
            list = list.OrderBy(x => r.Next()).ToList();
            return list;
        }
        public static List<Match> MakeRoundDraw(int userId, int round)
        {
            List<Match> mathes = new List<Match>();
            int[] D = new int[Repository.Cnt+1];
            for (int i=1; i<D.Length; i++)
            {
                D[i] = 0;
            }
            for (int i=1; i<D.Length; i++)
            {
                if (D[i]==0)
                {
                    int sop = Repository.Cnt + 1 - i;
                    for (int j=1; j<round; j++)
                    {
                        sop++;
                        if (sop==Repository.Cnt)
                        {
                            sop = 1;
                        }
                    }
                    if (sop==i)
                    {
                        sop = Repository.Cnt;
                    }
                    D[sop] = 1;
                    D[i] = 1;
                    Team team1 = LINQFactory.GetTeamByUserAndNumber(userId, i);
                    Team team2 = LINQFactory.GetTeamByUserAndNumber(userId, sop);
                    List<Player> players1 = LINQFactory.GetPlayersByTeam(team1.Id);
                    List<Player> players2 = LINQFactory.GetPlayersByTeam(team2.Id);
                    Match match = new Match(team1, team2, players1, players2, round);
                    mathes.Add(match);

                }
            }
            return mathes;
        }
        public static List<Player> GetSquad(List<Player>players)
        {
            List<Player> ans = new List<Player>();
            List<Player> keepers = new List<Player>();
            List<Player> defenders = new List<Player>();
            List<Player> midfields = new List<Player>();
            List<Player> forward = new List<Player>();
            foreach(var player in players)
            {
                if (player.Position=="Keeper")
                {
                    keepers.Add(player);
                }
                else if (player.Position.Split('-').Last()=="Back")
                {
                    defenders.Add(player);
                }
                else if (player.Position.Split(' ').Last()=="Midfield")
                {
                    midfields.Add(player);
                }
                else
                {
                    forward.Add(player);
                }
            }
            while (midfields.Count<5)
            {
                Player p = defenders.Last();
                defenders.Remove(p);
                midfields.Add(p);
            }
            Random rand = new Random();
            int ind = rand.Next(keepers.Count);
            ans.Add(keepers[ind]);
            int[] D = new int[defenders.Count];
            for (int j = 0; j < D.Length; j++)
            {
                D[j] = 0;
            }
            for (int i=0; i<2; i++)
            {
                while (true)
                {
                    ind = rand.Next(defenders.Count);
                    if (D[ind]==0)
                    {
                        ans.Add(defenders[ind]);
                        D[ind] = 1;
                        break;
                    }
                }
            }
            int[] M = new int[midfields.Count];
            for (int j = 0; j < M.Length; j++)
            {
                M[j] = 0;
            }
            for (int i = 0; i < 5; i++)
            {
                while (true)
                {
                    ind = rand.Next(midfields.Count);
                    if (M[ind] == 0)
                    {
                        ans.Add(midfields[ind]);
                        M[ind] = 1;
                        break;
                    }
                }
            }
            int[] F = new int[forward.Count];
            for (int j = 0; j < F.Length; j++)
            {
                F[j] = 0;
            }
            for (int i = 0; i < 3; i++)
            {
                while (true)
                {
                    ind = rand.Next(forward.Count);
                    if (F[ind] == 0)
                    {
                        ans.Add(forward[ind]);
                        F[ind] = 1;
                        break;
                    }
                }
            }
            return ans;
        }
        public static List<int> GetScorers(List<Player> players, int goals)
        {
            Random rand = new Random();
            List<int> ScorersId = new List<int>();
            for (int i=0; i<goals; i++)
            {
                double k = rand.NextDouble();
                if (k<=0.01)
                {
                    ScorersId.Add(players[0].Id);
                }
                else if (k<=0.04)
                {
                    ScorersId.Add(players[1].Id);
                }
                else if (k<=0.07)
                {
                    ScorersId.Add(players[2].Id);
                }
                else if (k<=0.14)
                {
                    ScorersId.Add(players[3].Id);
                }
                else if (k<=0.21)
                {
                    ScorersId.Add(players[4].Id);
                }
                else if (k<=0.28)
                {
                    ScorersId.Add(players[5].Id);
                }
                else if (k<=0.35)
                {
                    ScorersId.Add(players[6].Id);
                }
                else if (k<=0.42)
                {
                    ScorersId.Add(players[7].Id);
                }
                else if (k<=0.61)
                {
                    ScorersId.Add(players[8].Id);
                }
                else if (k<=0.80)
                {
                    ScorersId.Add(players[9].Id);
                }
                else
                {
                    ScorersId.Add(players[10].Id);
                }
            }
            return ScorersId;
        }
        public static Match playRound(int userId, int round)
        {
            Random rand = new Random();
            List<Match> matches = Championship.MakeRoundDraw(userId, round);
            Match myMatch = new Match();
            for (int i=0; i<matches.Count; i++)
            {
                if (LINQFactory.IsMyTeam(matches[i].TeamOne.Id) || LINQFactory.IsMyTeam(matches[i].TeamTwo.Id))
                {
                    myMatch = matches[i];
                    myMatch.TeamOne.Players = Championship.GetSquad(myMatch.PlayersOne);
                    myMatch.TeamTwo.Players = Championship.GetSquad(myMatch.PlayersTwo);
                }
                else
                {
                    int Rating1 = matches[i].TeamOne.Rating;
                    int Rating2 = matches[i].TeamTwo.Rating;
                    int sumRating = Rating1 + Rating2;
                    int r = rand.Next(sumRating);
                    int goal1 = rand.Next((int)(Math.Round(10.0 * Rating1 / sumRating)));
                    int goal2 = rand.Next((int)(Math.Round(10.0 * Rating2 / sumRating)));
                    if (goal1>goal2)
                    {
                        LINQFactory.TeamWin(matches[i].TeamOne.Id);
                        LINQFactory.TeamLose(matches[i].TeamTwo.Id);
                    }
                    else if (goal1==goal2)
                    {
                        LINQFactory.TeamDraw(matches[i].TeamOne.Id);
                        LINQFactory.TeamDraw(matches[i].TeamTwo.Id);
                    }
                    else
                    {
                        LINQFactory.TeamLose(matches[i].TeamOne.Id);
                        LINQFactory.TeamWin(matches[i].TeamTwo.Id);
                    }
                    List<Player> squad1 = Championship.GetSquad(matches[i].PlayersOne);
                    List<Player> squad2 = Championship.GetSquad(matches[i].PlayersTwo);
                    List<int> Scorers1 = Championship.GetScorers(squad1, goal1);
                    List<int> SCorers2 = Championship.GetScorers(squad2, goal2);
                    LINQFactory.MakeMatch(matches[i].TeamOne, matches[i].TeamTwo,
                                          matches[i].PlayersOne, matches[i].PlayersTwo,
                                          goal1, goal2, round, userId);
                    foreach (var player in squad1)
                    {
                        LINQFactory.PlayerGame(player.Id);
                    }
                    foreach (var player in squad2)
                    {
                        LINQFactory.PlayerGame(player.Id);
                    }
                    foreach (var player in Scorers1)
                    {
                        LINQFactory.PlayerScore(player);
                    }
                    foreach (var player in SCorers2)
                    {
                        LINQFactory.PlayerScore(player);
                    }
                }
            }
            return myMatch;
        }
        public static void SaveMyMatch(Match match, int round, int userId)
        {
            LINQFactory.MakeMatch(match.TeamOne, match.TeamTwo,
                                  match.PlayersOne, match.PlayersTwo,
                                  match.GoalTeamOne, match.GoalTeamTwo,
                                  round, userId);
            if (match.GoalTeamOne>match.GoalTeamTwo)
            {
                LINQFactory.TeamWin(match.TeamOne.Id);
                LINQFactory.TeamLose(match.TeamTwo.Id);
            }
            else if (match.GoalTeamOne==match.GoalTeamTwo)
            {
                LINQFactory.TeamDraw(match.TeamOne.Id);
                LINQFactory.TeamDraw(match.TeamTwo.Id);
            }
            else
            {
                LINQFactory.TeamLose(match.TeamOne.Id);
                LINQFactory.TeamWin(match.TeamTwo.Id);
            }
            foreach (var player in match.PlayersOne)
            {
                LINQFactory.PlayerGame(player.Id);
            }
            foreach (var player in match.PlayersTwo)
            {
                LINQFactory.PlayerGame(player.Id);
            }
            foreach (var name in match.ScorersOne)
            {
                LINQFactory.PlayerScoreByName(name);
            }
            foreach (var name in match.ScorersTwo)
            {
                LINQFactory.PlayerScoreByName(name);
            }
        }
    }
}
