using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Match
    {
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
        private List<Player>playersOne;
        public List<Player>PlayersOne 
        {
            get { return playersOne; }
            set { playersOne = value; }
        }
        private List<string> scorersOne;
        public List<string> ScorersOne
        {
            get { return scorersOne; }
            set { scorersOne = value; }
        }
        private int formOne;
        public int FormOne
        {
            get { return formOne; }
            set { formOne = value; }
        }

        private Team teamTwo;
        public Team TeamTwo
        {
            get { return teamTwo; }
            set { teamTwo = value; }
        }
        private int goalTeamTwo;
        public int GoalTeamTwo
        {
            get { return goalTeamTwo; }
            set { goalTeamTwo = value; }
        }
        private List<Player> playersTwo;
        public List<Player> PlayersTwo
        {
            get { return playersTwo; }
            set { playersTwo = value; }
        }
        private List<string> scorersTwo;
        public List<string> ScorersTwo
        {
            get { return scorersTwo; }
            set { scorersTwo = value; }
        }
        private int formTwo;
        public int FormTwo
        {
            get { return formTwo; }
            set { formTwo = value; }
        }
        public Match(Team team1, Team team2, List<Player>players1, List<Player>players2)
        {
            this.TeamOne = team1;
            this.TeamTwo = team2;
            this.PlayersOne = players1;
            this.PlayersTwo = players2;
        }
        public Match()
        {

        }


    }
}
