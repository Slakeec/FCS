using GameFootball;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Football_Game
{
    public class CompTeam : AbstractTeam
    {
        public int CompSpeed { get; set; }
        public bool isMovingUp { get; set; }
        public bool isMovingDown { get; set; }

        public CompTeam()
        {

        }

        public CompTeam(string name,int compSpeed, List<Footballer> team) : base(team)
        {
            Name = name;
            Squad = team;
            CompSpeed = compSpeed;
        }
       
       

        public override void TeamMovingUp()
        {
            foreach (var player in Squad)
            {
                player.positionOnTheScreen.Location = new System.Drawing.Point(player.positionOnTheScreen.Location.X, player.positionOnTheScreen.Location.Y - CompSpeed);
            }
            isMovingUp = true;
            isMovingDown = false;
        }

        public override void TeamMovingDown()
        {
            foreach (var player in Squad)
            {
                player.positionOnTheScreen.Location = new System.Drawing.Point(player.positionOnTheScreen.Location.X, player.positionOnTheScreen.Location.Y + CompSpeed);
            }
            isMovingDown = true;
            isMovingUp = false;
        }
        public override void WholeTeamMoving(List<Footballer> sqw, Dictionary<int, PictureBox> Players, Dictionary<int, PictureBox> lines, PictureBox Ball)
        {
            if (Ball.Location.Y < lines[0].Location.Y)
            {
                if (Ball.Location.X < lines[2].Location.X)
                {
                    if (Ball.Location.Y < sqw[10].positionOnTheScreen.Location.Y)
                    {
                        TeamMovingUp();
                    }
                    else
                    {
                        TeamMovingDown();
                    }
                }
                if (Ball.Location.X > lines[2].Location.X && Ball.Location.X < lines[3].Location.X)
                {
                    if (Ball.Location.Y < sqw[3].positionOnTheScreen.Location.Y)
                    {
                        TeamMovingUp();
                    }
                    else
                    {
                        TeamMovingDown();
                    }
                }
                if (Ball.Location.X > lines[3].Location.X && Ball.Location.X < lines[4].Location.X)
                {
                    if (Ball.Location.Y < sqw[1].positionOnTheScreen.Location.Y)
                    {
                        TeamMovingUp();
                    }
                    else
                    {
                        TeamMovingDown();
                    }
                }
            }
            if (Ball.Location.Y > lines[0].Location.Y && Ball.Location.Y < lines[1].Location.Y)
            {
                if (Ball.Location.X < lines[2].Location.X)
                {
                    if (Ball.Location.Y < sqw[9].positionOnTheScreen.Location.Y)
                    {
                        TeamMovingUp();
                    }
                    else
                    {
                        TeamMovingDown();
                    }
                }
                if (Ball.Location.X > lines[2].Location.X && Ball.Location.X < lines[3].Location.X)
                {
                    if (Ball.Location.Y < sqw[5].positionOnTheScreen.Location.Y)
                    {
                        TeamMovingUp();
                    }
                    else
                    {
                        TeamMovingDown();
                    }
                }

            }
            if (Ball.Location.Y > lines[1].Location.Y)
            {
                if (Ball.Location.X < lines[2].Location.X)
                {
                    if (Ball.Location.Y < sqw[8].positionOnTheScreen.Location.Y)
                    {
                        TeamMovingUp();
                    }
                    else
                    {
                        TeamMovingDown();
                    }
                }
                if (Ball.Location.X > lines[2].Location.X && Ball.Location.X < lines[3].Location.X)
                {
                    if (Ball.Location.Y < sqw[7].positionOnTheScreen.Location.Y)
                    {
                        TeamMovingUp();
                    }
                    else
                    {
                        TeamMovingDown();
                    }
                }
                if (Ball.Location.X > lines[3].Location.X && Ball.Location.X < lines[4].Location.X)
                {
                    if (Ball.Location.Y < sqw[2].positionOnTheScreen.Location.Y)
                    {
                        TeamMovingUp();
                    }
                    else
                    {
                        TeamMovingDown();
                    }
                }
            }

            if (Ball.Location.X > lines[4].Location.X || (Ball.Location.Y > lines[0].Location.Y && Ball.Location.Y < lines[1].Location.Y && Ball.Location.X > lines[3].Location.X && Ball.Location.X < lines[4].Location.X))
            {
                if (lines[0].Location.Y < sqw[0].positionOnTheScreen.Location.Y && lines[1].Location.Y > sqw[0].positionOnTheScreen.Location.Y + sqw[0].positionOnTheScreen.Height)
                {
                    if (Ball.Location.Y < sqw[0].positionOnTheScreen.Location.Y)
                    {
                        TeamMovingUp();
                    }
                    else
                    {
                        TeamMovingDown();
                    }
                }
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
                    DoBallAccelerationForRightTeam(isMovingUp, isMovingDown, ref BallSpeedX, ref BallSpeedY, Speeds);
                }
            }
            base.CollisionWithBall(Ball, isUpPressed, isDownPressed, ref BallSpeedX, ref BallSpeedY, Speeds);
        }
    }
}
