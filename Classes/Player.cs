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
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string surname;
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        private int goals;
        public int Goals
        {
            get { return goals; }
            set { goals = value; }
        }

        private int teamId;
        public int TeamId
        {
            get { return teamId; }
            set { teamId = value; }
        }
        public Player(string name, string surname, int goals, int idTeam)
        {
            this.Name = name;
            this.Surname = surname;
            this.Goals = goals;
            this.TeamId = idTeam;
        }
        public Player()
        {
                //
        }
    }
}
