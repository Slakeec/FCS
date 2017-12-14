using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameFootball
{
    public class TeamPlayer : AbstractTeam
    {
        //public string Name { get; set; }
        //public List<Footballer> Squad { get; set; }
        public const int playerSpeed = 9;

        public TeamPlayer()
        {

        }

        public TeamPlayer(List<Footballer> team) : base(team)
        {
            Squad = team;
        }

        public override void TeamMovingUp(List<Footballer> sqw)
        {
            foreach (var player in sqw)
            {
                player.positionOnTheScreen.Location = new System.Drawing.Point(player.positionOnTheScreen.Location.X, player.positionOnTheScreen.Location.Y - playerSpeed);
            }
        }
        public override void TeamMovingDown(List<Footballer> sqw)
        {
            foreach (var player in sqw)
            {
                player.positionOnTheScreen.Location = new System.Drawing.Point(player.positionOnTheScreen.Location.X, player.positionOnTheScreen.Location.Y + playerSpeed);
            }
        }

        
        //public TeamPlayer() : base
        //{
        //    Squad = playerTeam;
        //}
    }
}