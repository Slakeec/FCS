using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameFootball
{
    public abstract class AbstractTeam
    {
        public string Name { get; set; }
        public List<Footballer> Squad { get; set; }
        public int GoalsScored { get; set; }
        public int AllTouches { get; set; }
        public int GoalKeeperTouches { get; set; }
        public int TotalShots { get; set; }

        public virtual void TeamMovingUp(List<Footballer> sqw)
        { }
        public abstract void TeamMovingUp();
        public virtual void TeamMovingDown(List<Footballer> sqw)
        { }
        public abstract void TeamMovingDown();
        public virtual void WholeTeamMoving(List<Footballer> sqw, Dictionary<int, PictureBox> Players, Dictionary<int, PictureBox> lines, PictureBox Ball)
        { }

        public void DoBallAccelerationForRightTeam(bool isUpPressed, bool isDownPressed,ref int BallSpeedX, ref int BallSpeedY,List<int> Speeds)
        {
            int MinusBallSpeedXClone = -Speeds[0];
            int MinusBallSpeedX1 = -Speeds[1];
            int MinusBallSpeedX2 = -Speeds[2];
            int MinusBallSpeedX3 = -Speeds[3];
            int MinusBallSpeedX4 = -Speeds[4];
            int PlusBallSpeedY1 = Speeds[5];
            int PlusBallSpeedY2 = Speeds[6];
            int PlusBallSpeedY3 = Speeds[7];
            int PlusBallSpeedY4 = Speeds[8];

            int countForAcceleration = (new Random()).Next(1, 9);

            if (isUpPressed)
            {
                    if (countForAcceleration == 1)
                    {
                        BallSpeedY = -Math.Abs(PlusBallSpeedY1);
                        BallSpeedX = MinusBallSpeedXClone;
                    }
                    else if (countForAcceleration == 2)
                    {
                        BallSpeedY = -Math.Abs(PlusBallSpeedY2);
                        BallSpeedX = MinusBallSpeedXClone;
                    }
                    else if (countForAcceleration == 3)
                    {
                        BallSpeedY = -Math.Abs(PlusBallSpeedY3);
                        BallSpeedX = MinusBallSpeedXClone;
                    }
                    else if (countForAcceleration == 4)
                    {
                        BallSpeedY = -Math.Abs(PlusBallSpeedY4);
                        BallSpeedX = MinusBallSpeedXClone;
                    }
                    else if (countForAcceleration == 5)
                    {
                        BallSpeedY = -Math.Abs(PlusBallSpeedY2);
                        BallSpeedX = MinusBallSpeedX1;
                    }
                    else if (countForAcceleration == 6)
                    {
                        BallSpeedY = -Math.Abs(PlusBallSpeedY2);
                        BallSpeedX = MinusBallSpeedX2;
                    }
                    else if (countForAcceleration == 7)
                    {
                        BallSpeedY = -Math.Abs(PlusBallSpeedY2);
                        BallSpeedX = MinusBallSpeedX3;
                    }
                    else if (countForAcceleration == 8)
                    {
                        BallSpeedY = -Math.Abs(PlusBallSpeedY2);
                        BallSpeedX = MinusBallSpeedX4;
                    }
                
            }
            if (isDownPressed)
            {

                    if (countForAcceleration == 1)
                    {
                        BallSpeedY = Math.Abs(PlusBallSpeedY1);
                        BallSpeedX = MinusBallSpeedXClone;
                    }
                    else if (countForAcceleration == 2)
                    {
                        BallSpeedY = Math.Abs(PlusBallSpeedY2);
                        BallSpeedX = MinusBallSpeedXClone;
                    }
                    else if (countForAcceleration == 3)
                    {
                        BallSpeedY = Math.Abs(PlusBallSpeedY3);
                        BallSpeedX = MinusBallSpeedXClone;
                    }
                    else if (countForAcceleration == 4)
                    {
                        BallSpeedY = Math.Abs(PlusBallSpeedY4);
                        BallSpeedX = MinusBallSpeedXClone;
                    }
                    else if (countForAcceleration == 5)
                    {
                        BallSpeedY = Math.Abs(PlusBallSpeedY2);
                        BallSpeedX = MinusBallSpeedX1;
                    }
                    else if (countForAcceleration == 6)
                    {
                        BallSpeedY = Math.Abs(PlusBallSpeedY2);
                        BallSpeedX = MinusBallSpeedX2;
                    }
                    else if (countForAcceleration == 7)
                    {
                        BallSpeedY = Math.Abs(PlusBallSpeedY2);
                        BallSpeedX = MinusBallSpeedX3;
                    }
                    else if (countForAcceleration == 8)
                    {
                        BallSpeedY = Math.Abs(PlusBallSpeedY2);
                        BallSpeedX = MinusBallSpeedX4;
                    }
                
            }

            if (isUpPressed == false && isDownPressed == false)
            {
                if (countForAcceleration == 1)
                    BallSpeedX = MinusBallSpeedX1;
                else if (countForAcceleration == 2)
                    BallSpeedX = MinusBallSpeedX2;
                else if (countForAcceleration == 3)
                    BallSpeedX = MinusBallSpeedX3;
                else if (countForAcceleration == 4)
                    BallSpeedX = MinusBallSpeedX4;
            }
        }

        public virtual void CollisionWithBall(PictureBox Ball, bool isUpPressed, bool isDownPressed, ref int BallSpeedX, ref int BallSpeedY, List<int> Speeds)
        {
            foreach (var player in Squad)
            {
                if (Ball.Bounds.IntersectsWith(player.positionOnTheScreen.Bounds))
                {
                    if (Ball.Bounds.IntersectsWith(Squad[0].positionOnTheScreen.Bounds))
                    {
                        GoalKeeperTouches++;
                    }
                    if (Ball.Bounds.IntersectsWith(Squad[8].positionOnTheScreen.Bounds) || Ball.Bounds.IntersectsWith(Squad[9].positionOnTheScreen.Bounds) || Ball.Bounds.IntersectsWith(Squad[10].positionOnTheScreen.Bounds))
                    {
                        TotalShots++;
                    }
                    AllTouches++;
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
                    DoBallAccelerationForRightTeam(isUpPressed, isDownPressed, ref BallSpeedX,ref BallSpeedY, Speeds);
                }
            }
        }
        public virtual void TeamLeavingDown(int compspeed)
        {
            foreach (var player in Squad)
            {
                player.positionOnTheScreen.Location = new System.Drawing.Point(player.positionOnTheScreen.Location.X, player.positionOnTheScreen.Location.Y + compspeed);
            }
        }

        public AbstractTeam()
        {
            AllTouches = 0;
            GoalKeeperTouches = 0;
            TotalShots = 0;
        }
        public AbstractTeam(string name, List<Footballer> team, int goals) 
        {
            AllTouches = 0;
            GoalKeeperTouches = 0;
            TotalShots = 0;
            Name = name;
            Squad = team;
            GoalsScored = goals;
        }
        public AbstractTeam(List<Footballer> team)
        {
            AllTouches = 0;
            GoalKeeperTouches = 0;
            TotalShots = 0;
            Squad = team;
        }

    }
}
