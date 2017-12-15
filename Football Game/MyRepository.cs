﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Football_Game;
using Football_Game.TimeFolder;

namespace GameFootball
{
    public class MyRepository
    {
        public int countForAcceleration = 0;

        public int BallSpeedY = 7;

        public int PlusBallSpeedY1 = 2;
        public int PlusBallSpeedY2 = 7;
        public int PlusBallSpeedY3 = 13;
        public int PlusBallSpeedY4 = 20;

        public int BallSpeedX = 12;

        const int PlusBallSpeedXClone = 12;
        public int PlusBallSpeedX1 = 9;
        public int PlusBallSpeedX2 = 16;
        public int PlusBallSpeedX3 = 20;
        public int PlusBallSpeedX4 = 26;
        public int PlayerSpeed = 9;

        Random r = new Random();
        AbstractTeam team1 = new TeamPlayer();
        AbstractTeam team2;
        public AbstractTime Time; //= new Timer60(0,0);
        Ball aBall = new Ball();

        int countForlabel;
        int playerNameLetters = 0;

        string goallabel1 = "SCORED A SCREAMER!";
        string goallabel2 = "SCORED A GOLASO!!!";
        string goallabel3 = "WITH A BANGER!!!";
        string goallabel4 = "FOUND BACK OF THE NET!!!";

        string toScoreString;

        public List<Footballer> FirstTeam;
        public List<Footballer> SecondTeam;
        public List<string> WhoScoredList=new List<string>();

        public MyRepository()
        {
            team2 = new CompTeam();
            SecondTeam = new List<Footballer>
            {
                new Footballer("Kostyan",0),
                new Footballer("Mihan",0),
                new Footballer("Fedya",0),
                new Footballer("Igor-Mudak",0),
                new Footballer("Artyom",0),
                new Footballer("Dima",0),
                new Footballer("Leha",0),
                new Footballer("Kirill",0),
                new Footballer("Lut",0),
                new Footballer("Sanya",0),
                new Footballer("Desinov Valentin",0)
            };
            Time = new Timer90(0, 0);
            FirstTeam = new List<Footballer>
            {
                new Footballer("SevaGoal",0),
                new Footballer("Arina",0),
                new Footballer("Anton",0),
                new Footballer("Natasha",0),
                new Footballer("Liza",0),
                new Footballer("Jama",0),
                new Footballer("Pstygo",0),
                new Footballer("Meis",0),
                new Footballer("Valentin",0),
                new Footballer("Shava",0),
                new Footballer("Misha",0)
            };
            team1.Squad = FirstTeam;

        }

        public void BallMooving(PictureBox ball)
        {
            aBall.BallMove(ball, BallSpeedX, BallSpeedY);
        }

        public void CollisionWithBorders(PictureBox bottom, PictureBox top, PictureBox topLeft, PictureBox bottomLeft, PictureBox topRight, PictureBox bottomRight, PictureBox ball)
        {
            if (ball.Bounds.IntersectsWith(bottom.Bounds))
                BallSpeedY = -Math.Abs(BallSpeedY);

            if (ball.Bounds.IntersectsWith(top.Bounds))
                BallSpeedY = Math.Abs(BallSpeedY);

            if (ball.Bounds.IntersectsWith(topRight.Bounds) || ball.Bounds.IntersectsWith(bottomRight.Bounds))
                BallSpeedX = -Math.Abs(BallSpeedX);

            if (ball.Bounds.IntersectsWith(topLeft.Bounds) || ball.Bounds.IntersectsWith(bottomLeft.Bounds))
                BallSpeedX = Math.Abs(BallSpeedX);
        }
        public void DoLabelAnimation(int count, Label goalscoredLabel, Label whoscoredLabel)
        {
            if (count % 200 != 0)
            {
                if (count % 2 == 0)
                {
                    goalscoredLabel.ForeColor = Color.Red;
                    whoscoredLabel.ForeColor = Color.Red;
                }
                else
                {
                    goalscoredLabel.ForeColor = Color.Yellow;
                    whoscoredLabel.ForeColor = Color.Yellow;
                }
            }
            else
            {
                goalscoredLabel.Visible = false;
                whoscoredLabel.Visible = false;
            }
        }
        public void TeamsReset(List<Footballer> squad,PictureBox ball)
        {
            foreach (var player in squad)
            {
                player.positionOnTheScreen.Location = new Point(player.X_PositionInitial, player.Y_PositionInitial);
                ball.Location = new Point(500, 350);
            }
        }

        public void FirstTeamGoalScored(PictureBox ball, PictureBox goal, List<Footballer> squad, Label goalScoredLabel, Label whoScoredLabel, Label scoredLabel, ref int teamScore, ListView whoScoredListView)
        {
            
            countForlabel = r.Next(1, 5);
            if (ball.Bounds.IntersectsWith(goal.Bounds))
            {
                teamScore++;
                team1.GoalsScored = teamScore;
                TeamsReset(squad, ball);
                
                foreach (var player in squad)
                {
                    if (player.LastTouch == true)
                    {
                        player.GoalsScored++;
                        player.LastGoalTime = Time.Min;
                        toScoreString = $"{player.LastGoalTime}' {player.Name}  {team1.GoalsScored}-0 ";
                        WhoScoredList.Add(toScoreString);
                        foreach (var str in WhoScoredList)
                        {
                            if (toScoreString.Length > 21)
                            {
                                whoScoredListView.Font = new System.Drawing.Font("Cambria", 10);
                            }
                        }
                        whoScoredListView.Items.Add(toScoreString);

                        if (countForlabel == 1)
                        {
                            scoredLabel.Text = goallabel1;
                        }
                        if (countForlabel == 2)
                        {
                            scoredLabel.Text = goallabel2;
                        }
                        if (countForlabel==3)
                        {
                            scoredLabel.Text = goallabel3;
                        }
                        if (countForlabel == 4)
                        {
                            scoredLabel.Text = goallabel4;
                        }
                        goalScoredLabel.Visible = true;                        
                        whoScoredLabel.Text = $"{player.Name}";
                        whoScoredLabel.Visible = true;
                        scoredLabel.Visible = true;
                    }
                }
            }

        }

        public void AccelerationXChangeToNormal()
        {
            if (BallSpeedX > 0)
            {
                if (BallSpeedX != PlusBallSpeedXClone)
                {
                    if (BallSpeedX < PlusBallSpeedXClone)
                        BallSpeedX++;

                    if (BallSpeedX > PlusBallSpeedXClone)
                        BallSpeedX--;
                }
            }
            if (BallSpeedX < 0)
            {
                if (BallSpeedX != -PlusBallSpeedXClone)
                {
                    if (BallSpeedX < -PlusBallSpeedXClone)
                        BallSpeedX++;

                    if (BallSpeedX > PlusBallSpeedXClone)
                        BallSpeedX--;
                }
            }
        }

        public void DoBallAcceleration(bool isUpPressed,bool isDownPressed)
        {
            countForAcceleration = r.Next(1, 9);
            if (BallSpeedX > 0)
            {
                if (isUpPressed)
                {
                    if (BallSpeedY > 0 || BallSpeedY<0)
                    {
                        if (countForAcceleration == 1)
                        {
                            BallSpeedY = -Math.Abs(PlusBallSpeedY1);
                            BallSpeedX = PlusBallSpeedXClone;
                        }
                        else if (countForAcceleration == 2)
                        {
                            BallSpeedY = -Math.Abs(PlusBallSpeedY2);
                            BallSpeedX = PlusBallSpeedXClone;
                        }
                        else if (countForAcceleration == 3)
                        {
                            BallSpeedY = -Math.Abs(PlusBallSpeedY3);
                            BallSpeedX = PlusBallSpeedXClone;
                        }
                        else if (countForAcceleration == 4)
                        {
                            BallSpeedY = -Math.Abs(PlusBallSpeedY4);
                            BallSpeedX = PlusBallSpeedXClone;
                        }
                        else if (countForAcceleration == 5)
                        {
                            BallSpeedY = -Math.Abs(PlusBallSpeedY2);
                            BallSpeedX = PlusBallSpeedX1;
                        }
                        else if (countForAcceleration == 6)
                        {
                            BallSpeedY = -Math.Abs(PlusBallSpeedY2);
                            BallSpeedX = PlusBallSpeedX2;
                        }
                        else if (countForAcceleration == 7)
                        {
                            BallSpeedY = -Math.Abs(PlusBallSpeedY2);
                            BallSpeedX = PlusBallSpeedX3;
                        }
                        else if (countForAcceleration == 8)
                        {
                            BallSpeedY = -Math.Abs(PlusBallSpeedY2);
                            BallSpeedX = PlusBallSpeedX4;
                        }
                    }
                   
                }
                if (isDownPressed)
                {
                    if (BallSpeedY < 0 || BallSpeedY>0)
                    {
                        if (countForAcceleration == 1)
                        {
                            BallSpeedY = Math.Abs(PlusBallSpeedY1);
                            BallSpeedX = PlusBallSpeedXClone;
                        }
                        else if (countForAcceleration == 2)
                        {
                            BallSpeedY = Math.Abs(PlusBallSpeedY2);
                            BallSpeedX = PlusBallSpeedXClone;
                        }
                        else if (countForAcceleration == 3)
                        {
                            BallSpeedY = Math.Abs(PlusBallSpeedY3);
                            BallSpeedX = PlusBallSpeedXClone;
                        }
                        else if (countForAcceleration == 4)
                        {
                            BallSpeedY = Math.Abs(PlusBallSpeedY4);
                            BallSpeedX = PlusBallSpeedXClone;
                        }
                        else if (countForAcceleration == 5)
                        {
                            BallSpeedY = Math.Abs(PlusBallSpeedY2);
                            BallSpeedX = PlusBallSpeedX1;
                        }
                        else if (countForAcceleration == 6)
                        {
                            BallSpeedY = Math.Abs(PlusBallSpeedY2);
                            BallSpeedX = PlusBallSpeedX2;
                        }
                        else if (countForAcceleration == 7)
                        {
                            BallSpeedY = Math.Abs(PlusBallSpeedY2);
                            BallSpeedX = PlusBallSpeedX3;
                        }
                        else if (countForAcceleration == 8)
                        {
                            BallSpeedY = Math.Abs(PlusBallSpeedY2);
                            BallSpeedX = PlusBallSpeedX4;
                        }
                    }

                }
                if (isUpPressed == false && isDownPressed == false)
                {
                    if (countForAcceleration == 1)
                        BallSpeedX = PlusBallSpeedX1;
                    else if (countForAcceleration == 2)
                        BallSpeedX = PlusBallSpeedX2;
                    else if (countForAcceleration == 3)
                        BallSpeedX = PlusBallSpeedX3;
                    else if (countForAcceleration == 4)
                        BallSpeedX = PlusBallSpeedX4;
                }
            }
            if (BallSpeedX < 0)
            {
                BallSpeedX = Math.Abs(BallSpeedX);
                if (isUpPressed)
                {
                    if (BallSpeedY > 0 || BallSpeedY<0)
                    {
                        if (countForAcceleration == 1)
                        {
                            BallSpeedY = -Math.Abs(PlusBallSpeedY1);
                            BallSpeedX = PlusBallSpeedXClone;
                        }
                        else if (countForAcceleration == 2)
                        {
                            BallSpeedY = -Math.Abs(PlusBallSpeedY2);
                            BallSpeedX = PlusBallSpeedXClone;
                        }
                        else if (countForAcceleration == 3)
                        {
                            BallSpeedY = -Math.Abs(PlusBallSpeedY3);
                            BallSpeedX = PlusBallSpeedXClone;
                        }
                        else if (countForAcceleration == 4)
                        {
                            BallSpeedY = -Math.Abs(PlusBallSpeedY4);
                            BallSpeedX = PlusBallSpeedXClone;
                        }
                        else if (countForAcceleration == 5)
                        {
                            BallSpeedY = -Math.Abs(PlusBallSpeedY2);
                            BallSpeedX = PlusBallSpeedX1;
                        }
                        else if (countForAcceleration == 6)
                        {
                            BallSpeedY = -Math.Abs(PlusBallSpeedY2);
                            BallSpeedX = PlusBallSpeedX2;
                        }
                        else if (countForAcceleration == 7)
                        {
                            BallSpeedY = -Math.Abs(PlusBallSpeedY2);
                            BallSpeedX = PlusBallSpeedX3;
                        }
                        else if (countForAcceleration == 8)
                        {
                            BallSpeedY = -Math.Abs(PlusBallSpeedY2);
                            BallSpeedX = PlusBallSpeedX4;
                        }
                    }
                }
                if (isDownPressed)
                {
                    if (BallSpeedY < 0 || BallSpeedY>0)
                    {
                        if (countForAcceleration == 1)
                        {
                            BallSpeedY = Math.Abs(PlusBallSpeedY1);
                            BallSpeedX = PlusBallSpeedXClone;
                        }
                        else if (countForAcceleration == 2)
                        {
                            BallSpeedY = Math.Abs(PlusBallSpeedY2);
                            BallSpeedX = PlusBallSpeedXClone;
                        }
                        else if (countForAcceleration == 3)
                        {
                            BallSpeedY = Math.Abs(PlusBallSpeedY3);
                            BallSpeedX = PlusBallSpeedXClone;
                        }
                        else if (countForAcceleration == 4)
                        {
                            BallSpeedY = Math.Abs(PlusBallSpeedY4);
                            BallSpeedX = PlusBallSpeedXClone;
                        }
                        else if (countForAcceleration == 5)
                        {
                            BallSpeedY = Math.Abs(PlusBallSpeedY2);
                            BallSpeedX = PlusBallSpeedX1;
                        }
                        else if (countForAcceleration == 6)
                        {
                            BallSpeedY = Math.Abs(PlusBallSpeedY2);
                            BallSpeedX = PlusBallSpeedX2;
                        }
                        else if (countForAcceleration == 7)
                        {
                            BallSpeedY = Math.Abs(PlusBallSpeedY2);
                            BallSpeedX = PlusBallSpeedX3;
                        }
                        else if (countForAcceleration == 8)
                        {
                            BallSpeedY = Math.Abs(PlusBallSpeedY2);
                            BallSpeedX = PlusBallSpeedX4;
                        }
                    }
                }
            }                        
        }

        public void CollisionWithPlayers(PictureBox ball, List<Footballer> sqwad, bool isUpPressed, bool isDownPressed)
        {
            foreach (var player in sqwad)
            {
                if(ball.Bounds.IntersectsWith(player.positionOnTheScreen.Bounds))
                {
                    foreach (var playerToTouch in sqwad)
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
                    DoBallAcceleration(isUpPressed, isDownPressed);
                }
            }
        }
        public void CompTeamMoving(List<Footballer>sqw, Dictionary<int,PictureBox> Players, Dictionary<int,PictureBox> lines)
        {
            foreach (var k in lines.Keys)
            {
                if (k == 0)
                {
                    foreach (var kk in lines.Keys)
                    {
                        if (kk == 2)
                        {
                            foreach (var kkk in Players.Keys)
                            {
                                if (kkk == 10)
                                {
                                    //if (aBall.myBall.Location.Y < sqw[10].positionOnTheScreen.Location.Y)
                                    //{
                                    //    team2.TeamMovingUp(sqw);
                                    //}
                                    //else
                                    //{
                                    //    team2.TeamMovingDown(sqw);
                                    //}
                                }
                            }
                        }
                    }
                }
            }
        }

        public void Player2TeamMoving(List<Footballer> sqw, bool isupArrowpressed, bool isdownArrowpressed)
        {
            if (isupArrowpressed)
            {
                team2.TeamMovingUp(sqw);
            }

            if (isdownArrowpressed)
            {
                team2.TeamMovingDown(sqw);
            }
        }

        public void PlayerTeamMoving(List<Footballer> sqw, bool isuppressed, bool isdownpressed)
        {
            if (isuppressed)
            {
                team1.TeamMovingUp(sqw);                
            }

            if (isdownpressed)
            {
                team1.TeamMovingDown(sqw);
            }

            //foreach (var player in sqw)
            //{
            //    if (isuppressed)
            //    {
            //        //team1.TeamMovingUp(sqw);
            //        player.positionOnTheScreen.Location = new Point(player.positionOnTheScreen.Location.X, player.positionOnTheScreen.Location.Y - PlayerSpeed);
            //    }

            //    if (isdownpressed)
            //    {
            //        //team1.TeamMovingDown(sqw);
            //        player.positionOnTheScreen.Location = new Point(player.positionOnTheScreen.Location.X, player.positionOnTheScreen.Location.Y + PlayerSpeed);
            //    }
            //}
        }
     }
}
