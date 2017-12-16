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
        private string teamName1;
        public string TeamName1
        {
            get { return teamName1; }
            set { teamName1 = value; }
        }
        private string teamName2;
        public string TeamName2
        {
            get { return teamName2; }
            set { teamName2 = value; }
        }

        [JsonProperty("teamOne")]
        private int teamOne;
        public int TeamOne
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
        private List<int>playersOne;
        public List<int>PlayersOne 
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
        private int teamTwo;
        public int TeamTwo
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
        private List<int> playersTwo;
        public List<int> PlayersTwo
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

        public Match(int team1, int team2, List<int>players1, List<int>players2, int round, string teamName1, string teamName2)
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
            this.TeamName1 = teamName1;
            this.TeamName2 = teamName2;
        }
        public Match(int team1, int team2, List<int>players1, List<int>players2,
            int goal1, int goal2, int round, int userId, string name1, string name2)
        {
            this.UserId = userId;
            this.Round = round;
            this.TeamOne = team1;
            this.TeamTwo = team2;
            this.PlayersOne = players1;
            this.PlayersTwo = players2;
            this.GoalTeamOne = goal1;
            this.GoalTeamTwo = goal2;
            this.TeamName1 = name1;
            this.TeamName2 = name2;
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
