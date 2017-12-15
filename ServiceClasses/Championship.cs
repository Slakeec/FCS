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
        public static void CreateChampionship(string myTeam, int UserId)
        {
            using (var context = new Context())
            {
                List<int> draw = MakeDraw();
                for (int i=0; i<Repository.Cnt; i++)
                {
                    Team t = Repository.GetTeam(new Repository().TeamsId[i]);
                    t.Number = draw[i];
                    t.Name = new Repository().TeamNames[i];
                    t.MyTeam = t.Name == myTeam;
                    t.UserId = UserId;
                    context.Teams.Add(t);
                    context.SaveChanges();
                }
            }
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
    }
}
