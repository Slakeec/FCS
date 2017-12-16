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
        public static List<Player> GetSquadFromName(string name)
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
            return players;
        }
        public static List<string> GetNames(List<Player>players)
        {
            List<string> ans = new List<string>();
            List<Player> keepers = new List<Player>();
            List<Player> defenders = new List<Player>();
            List<Player> midfields = new List<Player>();
            List<Player> forward = new List<Player>();
            foreach (var player in players)
            {
                if (player.Position == "Keeper")
                {
                    keepers.Add(player);
                }
                else if (player.Position.Split('-').Last() == "Back")
                {
                    defenders.Add(player);
                }
                else if (player.Position.Split(' ').Last() == "Midfield")
                {
                    midfields.Add(player);
                }
                else
                {
                    forward.Add(player);
                }
            }
            while (midfields.Count < 5)
            {
                Player p = defenders.Last();
                defenders.Remove(p);
                midfields.Add(p);
            }
            Random rand = new Random();
            int ind = rand.Next(keepers.Count);
            ans.Add(keepers[ind].Name);
            int[] D = new int[defenders.Count];
            for (int j = 0; j < D.Length; j++)
            {
                D[j] = 0;
            }
            for (int i = 0; i < 2; i++)
            {
                while (true)
                {
                    ind = rand.Next(defenders.Count);
                    if (D[ind] == 0)
                    {
                        ans.Add(defenders[ind].Name);
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
                        ans.Add(midfields[ind].Name);
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
                        ans.Add(forward[ind].Name);
                        F[ind] = 1;
                        break;
                    }
                }
            }
            return ans;
        }
    }
}
