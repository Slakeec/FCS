using GameFootball;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Game
{
    public class Player2Team : AbstractTeam
    {
        public const int player2Speed = 9;

        public override void TeamMovingDown(List<Footballer> sqw)
        {
            foreach (var player in sqw)
            {
                player.positionOnTheScreen.Location = new System.Drawing.Point(player.positionOnTheScreen.Location.X, player.positionOnTheScreen.Location.Y + player2Speed);
            }
        }

        public override void TeamMovingUp(List<Footballer> sqw)
        {
            foreach (var player in sqw)
            {
                player.positionOnTheScreen.Location = new System.Drawing.Point(player.positionOnTheScreen.Location.X, player.positionOnTheScreen.Location.Y - player2Speed);
            }
        }
    }
}
