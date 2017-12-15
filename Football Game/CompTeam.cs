using GameFootball;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Game
{
    public class CompTeam : AbstractTeam
    {
        public int CompSpeed { get; set; }

        public CompTeam()
        {

        }

        public CompTeam(int compSpeed, List<Footballer> team) : base(team)
        {
            Squad = team;
            CompSpeed = compSpeed;
        }
        public override void TeamMovingDown(List<Footballer> sqw)
        {
            foreach (var player in sqw)
            {
                player.positionOnTheScreen.Location = new System.Drawing.Point(player.positionOnTheScreen.Location.X, player.positionOnTheScreen.Location.Y + CompSpeed);
            }
        }

        public override void TeamMovingUp(List<Footballer> sqw)
        {
            foreach (var player in sqw)
            {
                player.positionOnTheScreen.Location = new System.Drawing.Point(player.positionOnTheScreen.Location.X, player.positionOnTheScreen.Location.Y - CompSpeed);
            }
        }
    }
}
