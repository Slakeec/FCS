using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Classes
{
   public class Context: DbContext
    {
        Context() : base("FCSDataBase")
        {
        }

        DbSet<User> Users;
        DbSet<Team> Teams;
        DbSet<Player> Players;
        DbSet<Match> Matches;
        
    }
}
