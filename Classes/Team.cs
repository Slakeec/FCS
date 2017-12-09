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
        private int userId;
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        public Team(string name, bool myTeam, int userID)
        {
            this.Name = name;
            this.Games = 0;
            this.Points = 0;
            this.MyTeam = myTeam;
            this.UserId = userID;
        }
        public Team()
        {

        }
    }
}
