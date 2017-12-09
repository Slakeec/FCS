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
        public Team(string name, bool myTeam)
        {
            this.Name = name;
            this.Games = 0;
            this.Points = 0;
            this.MyTeam = myTeam;
        }
        public Team()
        {

        }
    }
}
