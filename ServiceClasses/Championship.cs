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
                for (int i=0; i<Repository.Cnt; i++)
                {
                    Team t = Repository.GetTeam(new Repository().TeamsId[i]);
                    
                    t.Name = new Repository().TeamNames[i];
                    t.MyTeam = t.Name == myTeam;
                    t.UserId = UserId;
                    context.Teams.Add(t);
                    context.SaveChanges();
                }
            }
        }
    }
}
