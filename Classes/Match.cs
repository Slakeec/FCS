using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Classes
{
    public class Match
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int userId;
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        [JsonProperty("teamOne")]
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
        [JsonProperty("playersOne")]
        private List<Player>playersOne;
        public List<Player>PlayersOne 
        {
            get { return playersOne; }
            set { playersOne = value; }
        }
        [JsonProperty("scorersOne")]
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
        [JsonProperty("teamTwo")]
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
        [JsonProperty("playersTwo")]
        private List<Player> playersTwo;
        public List<Player> PlayersTwo
        {
            get { return playersTwo; }
            set { playersTwo = value; }
        }
        [JsonProperty("scorersTwo")]
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
        private int round;
        public int Round
        {
            get { return round; }
            set { round = value; }
        }

        public Match(Team team1, Team team2, List<Player>players1, List<Player>players2, int round)
        {
            this.TeamOne = team1;
            this.TeamTwo = team2;
            this.PlayersOne = players1;
            this.PlayersTwo = players2;
            this.ScorersOne = new List<string>();
            this.ScorersTwo = new List<string>();
            this.GoalTeamOne = 0;
            this.goalTeamTwo = 0;
            this.Round = round;
        }
        public Match(Team team1, Team team2, List<Player>players1, List<Player>players2,
            int goal1, int goal2, int round, int userId)
        {
            this.UserId = userId;
            this.Round = round;
            this.TeamOne = team1;
            this.TeamTwo = team2;
            this.PlayersOne = players1;
            this.PlayersTwo = players2;
            this.GoalTeamOne = goal1;
            this.GoalTeamTwo = goal2;
        }
        public string Score
        {
            get { return $"{GoalTeamOne}:{GoalTeamTwo}"; }
        }
        public Match()
        {

        }


    }
}
