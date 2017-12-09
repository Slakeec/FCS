using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Repository
    {
        private List<string> teams;
        public List<string> Teams
        {
            get { return teams; }
            set { teams = value; }
        }
        public Repository()
        {
            this.Teams = new List<string>
            {
                "Arsenal",
                "Chelsea",
                "Manchester United",
                "Manchester City",
                "Liverpool",
                "Barselona",
                "Real Madrid",
                "Atletiko Madrid",
                "Bayern Munchen",
                "Borussia Dortmund",
                "Juventus",
                "Napoli",
                "Roma",
                "Inter",
                "PSG",
                "Monaco",
                "CSKA",
                "Zenit",
                "Spartak",
                "Lokomotiv"
            };
        }
    }
}
