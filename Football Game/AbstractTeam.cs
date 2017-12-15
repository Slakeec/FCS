using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFootball
{
    public abstract class AbstractTeam
    {
        public string Name { get; set; }
        public List<Footballer> Squad { get; set; }
        public int GoalsScored { get; set; }
        //public int movingspeed { get; set; }

        public abstract void TeamMovingUp(List<Footballer> sqw);
        public abstract void TeamMovingDown(List<Footballer> sqw);

        public AbstractTeam()
        {

        }
        public AbstractTeam(string name, List<Footballer> team, int goals)
        {
            Name = name;
            Squad = team;
            GoalsScored = goals;
        }
        public AbstractTeam(List<Footballer> team)
        {
            Squad = team;
        }

    }
}
