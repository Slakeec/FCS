﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Player
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        [JsonProperty("name")]
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        [JsonProperty("nationality")]
        private string nationlity;

        public string Nationlity
        {
            get { return nationlity; }
            set { nationlity = value; }
        }

        [JsonProperty("marketValue")]
        private string marketPrice;

        public string MarketPrice
        {
            get { return marketPrice; }
            set { marketPrice = value; }
        }

        //[JsonProperty("jerseyNumber")]
        //private int number;
        //public int Number
        //{
        //    get { return number; }
        //    set { number = value; }
        //}

        [JsonProperty("position")]
        private string position;

        public string Position
        {
            get { return position; }
            set { position = value; }
        }

        private int goals;
        public int Goals
        {
            get { return goals; }
            set { goals = value; }
        }
        private int games;
        public int Games
        {
            get { return games; }
            set { games = value; }
        }

        private int teamId;
        public int TeamId
        {
            get { return teamId; }
            set { teamId = value; }
        }
        public Player(string name, string nationality, int idTeam, int number,  string position)
        {
            this.Name = name;            
            this.Goals = 0;
            this.Games = 0;
            this.TeamId = idTeam;
            this.Nationlity = nationality;
            //this.Number = number;
            this.Position = position;
        }
        public Player()
        {
                
        }
    }
}
