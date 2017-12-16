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
        public const int playerSpeed = 11;


        public TeamPlayer()
        {

        }

        public TeamPlayer(string name,List<Footballer> team) : base(team)
        {
            Name = name;
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

        public override void TeamMovingUp()
        {
            throw new NotImplementedException();
        }

        public override void TeamMovingDown()
        {
            throw new NotImplementedException();
        }
    }
}