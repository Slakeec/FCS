using GameFootball;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Football_Game
{
    public class Player2Team : AbstractTeam
    {
        public const int player2Speed = 11;

        public Player2Team()
        {

        }

        public Player2Team(string name, List<Footballer> sqw)
        {
            Name = name;
            Squad = sqw;
        }

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

        public override void TeamMovingUp()
        {
            foreach (var player in Squad)
            {
                player.positionOnTheScreen.Location = new System.Drawing.Point(player.positionOnTheScreen.Location.X, player.positionOnTheScreen.Location.Y - player2Speed);
            }
        }
        public override void TeamMovingDown()
        {
            foreach (var player in Squad)
            {
                player.positionOnTheScreen.Location = new System.Drawing.Point(player.positionOnTheScreen.Location.X, player.positionOnTheScreen.Location.Y + player2Speed);

            }
        }
        public override void CollisionWithBall(PictureBox Ball, bool isUpPressed, bool isDownPressed, ref int BallSpeedX, ref int BallSpeedY, List<int> Speeds)
        {
            foreach (var player in Squad)
            {
                if (Ball.Bounds.IntersectsWith(player.positionOnTheScreen.Bounds))
                {
                    foreach (var playerToTouch in Squad)
                    {
                        if (player == playerToTouch)
                        {
                            playerToTouch.LastTouch = true;
                        }
                        else
                        {
                            playerToTouch.LastTouch = false;
                        }
                    }
                    DoBallAccelerationForRightTeam(isUpPressed, isDownPressed, ref BallSpeedX, ref BallSpeedY, Speeds);
                }
            }
            base.CollisionWithBall(Ball, isUpPressed, isDownPressed, ref BallSpeedX,ref BallSpeedY, Speeds);
        }
    }
}
    

