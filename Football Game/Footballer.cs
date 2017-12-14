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
        public TeamPlayer Team { get; set; }

        public Footballer(string name,PictureBox pictbx, int Xposition, int Yposition)
        {
            X_PositionInitial = Xposition;
            Y_PositionInitial = Yposition;
            Name = name;
            this.positionOnTheScreen = pictbx;
        }
    }
}
