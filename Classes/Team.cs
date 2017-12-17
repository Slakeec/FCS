using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Team
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        [JsonProperty("crestUrl")]
        private string picture;
        public string Picture
        {
            get { return picture; }
            set { picture = value; }
        }

        [JsonProperty("count")]
        private int count;

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        [JsonProperty("players")]
        private List<Player> players;

        public List<Player> Players
        {
            get { return players; }
            set { players = value; }
        }

        private int games;
        public int Games
        {
            get { return games; }
            set { games = value; }
        }
        private int points;
        public int Points
        {
            get { return points; }
            set { points = value; }
        }
        private bool myTeam;
        public bool MyTeam
        {
            get { return myTeam; }
            set { myTeam = value; }
        }
        private int userId;
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        private int number;
        public int Number
        {
            get { return number; }
            set { number = value; }
        }
        private int position;
        public int Position
        {
            get { return position; }
            set { position = value; }
        }
        private int rating;
        public int Rating
        {
            get { return rating; }
            set { rating = value; }
        }


        public Team(string name, int count, List<Player> players)
        {
            this.Name = name;
            this.MyTeam = false;
            this.Games = 0;
            this.Points = 0;
            this.Count = count;
            this.Players = players;
        }
        public Team(int count, List<Player>players) : this("", count, players)
        {
            
        }
        public Team()
        {

        }
    }
}
