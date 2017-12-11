using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class Match
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string score;

        public string Score
        {
            get { return score; }
            set { score = value; }
        }

        private Team teamOne;

        public Team TeamOne
        {
            get { return teamOne; }
            set { teamOne = value; }
        }
        private int goalTeamOne;

        public int GoalTeamOne
        {
            get { return goalTeamOne; }
            set { goalTeamOne = value; }
        }

        private Team teamTwo;

        public Team TeamTwo
        {
            get { return teamTwo; }
            set { teamOne = value; }
        }
        private int goalTeamTwo;

        public int GoalTeamTwo
        {
            get { return goalTeamTwo; }
            set { goalTeamTwo = value; }
        }



    }
}
