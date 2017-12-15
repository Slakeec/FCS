using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameFootball
{
    public class Footballer
    {
        public string Name { get; set; }
        public PictureBox positionOnTheScreen { get; set; }
        public int X_PositionInitial { get; set; }
        public int Y_PositionInitial { get; set; }
        public string Position { get; set; }
        public bool LastTouch { get; set; }
        public int GoalsScored { get; set; }
        public int LastGoalTime { get; set; }

        public Footballer(string name, int goalsscored, PictureBox pictbx, int Xposition, int Yposition)
        {
            Name = name;
            GoalsScored = goalsscored;
            this.positionOnTheScreen = pictbx;
            X_PositionInitial = Xposition;
            Y_PositionInitial = Yposition;
        }
        public Footballer(string name, int goalsscored)
        {
            Name = name;
            GoalsScored = goalsscored;
        }
    }
}
