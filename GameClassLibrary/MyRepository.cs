﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Football_Game;
using Football_Game.TimeFolder;
using System.IO;
using Classes;
using System.Resources;

namespace Football_Game
{
    public class MyRepository
    {
        //public int countForAcceleration = 0;
        public int BallSpeedY = 9;

        public int PlusBallSpeedY1 = 2;
        public int PlusBallSpeedY2 = 9;
        public int PlusBallSpeedY3 = 13;
        public int PlusBallSpeedY4 = 20;

        public int BallSpeedX = 12;

        public int PlusBallSpeedXClone = 12;
        public int PlusBallSpeedX1 = 9;
        public int PlusBallSpeedX2 = 16;
        public int PlusBallSpeedX3 = 20;
        public int PlusBallSpeedX4 = 26;
        public int PlayerSpeed = 9;

        public int labelcount = 0;
        public int AddedTime = 0;

        Random r = new Random();
        public AbstractTeam team1 = new TeamPlayer();
        public AbstractTeam team2;
        public AbstractTime Time; //= new Timer60(0,0);
        Ball aBall = new Ball();

        int countForlabel;
        int playerNameLetters = 0;

        string goallabel1 = "SCORED A SCREAMER!";
        string goallabel2 = "SCORED A GOLASO!!!";
        string goallabel3 = "WITH A BANGER!!!";
        string goallabel4 = "FOUND BACK OF THE NET!!!";

        public string FirstTeamColor;
        public string SecondTeamColor;

        string toScoreString;

        public bool StatisticShown = false;
        public static bool GameEnded = false;
        public static bool isPausePressed = false;
        public bool GoalNowScored = false;
        bool LabelsMoved;
        static bool FinalWhistlePlayed;

        public List<Footballer> FirstTeam;
        public List<Footballer> SecondTeam;
        public List<string> WhoScoredList=new List<string>();

        public List<string> ScoredFirstTeam = new List<string>();
        public List<string> ScoredSecondTeam = new List<string>();

        public List<string> MatchStatList = new List<string>();
        public List<int> Speeds;
        public Match match;

        public MyRepository(string name1, string name2, List<string>players1, List<string>players2,
                            int time, int difficulty, bool isMulti, List<string> FirstScoredPlayers, 
                            List<string> SecondScoredPlayers, string FirstColor, string SecondColor)
        {
            ScoredFirstTeam = FirstScoredPlayers;
            ScoredSecondTeam= SecondScoredPlayers;
            FirstTeam = new List<Footballer>();
            foreach (var player in players1)
            {
                FirstTeam.Add(new Footballer(player, 0));
            }
            SecondTeam = new List<Footballer>();
            foreach (var player in players2)
            {
                SecondTeam.Add(new Footballer(player, 0));
            }
            team1 = new TeamPlayer(name1, FirstTeam);
            if (isMulti)
            {
                team2 = new Player2Team(name2, SecondTeam);
            }
            else
            {
                team2 = new CompTeam(name2, difficulty*2, SecondTeam);
            }
            if (time==60)
            {
                Time = new Timer60(0, 0);
            }
            else if (time==90)
            {
                Time = new Timer90(0, 0);
            }
            else
            {
                Time = new Timer180(0, 0); 
            }
            FirstTeamColor = FirstColor;
            SecondTeamColor = SecondColor;
            
            Speeds = new List<int> { PlusBallSpeedXClone, PlusBallSpeedX1, PlusBallSpeedX2, PlusBallSpeedX3, PlusBallSpeedX4, PlusBallSpeedY1, PlusBallSpeedY2, PlusBallSpeedY3, PlusBallSpeedY4 };
        }
        public MyRepository(List<string> players1, List<string> players2)
        {

            //FirstTeam = new List<Footballer>();
            //foreach (var player in players1)
            //{
            //    FirstTeam.Add(new Footballer(player, 0));
            //}
            //SecondTeam = new List<Footballer>();
            //foreach (var player in players2)
            //{
            //    SecondTeam.Add(new Footballer(player, 0));
            //}

        }
        public MyRepository()
        {
            FirstTeam = new List<Footballer>
            {
                new Footballer("1",0),
                new Footballer("2",0),
                new Footballer("3",0),
                new Footballer("4",0),
                new Footballer("5",0),
                new Footballer("6",0),
                new Footballer("7",0),
                new Footballer("8",0),
                new Footballer("9",0),
                new Footballer("10",0),
                new Footballer("11",0)
            };
            SecondTeam = new List<Footballer>
            {
                new Footballer("1(2)",0),
                new Footballer("2(2)",0),
                new Footballer("3(2)",0),
                new Footballer("4(2)",0),
                new Footballer("5(2)",0),
                new Footballer("6(2)",0),
                new Footballer("7(2)",0),
                new Footballer("8(2)",0),
                new Footballer("9(2)",0),
                new Footballer("10(2)",0),
                new Footballer("11(2)",0)
            };
            team1 = new TeamPlayer("Chelsea", FirstTeam);
            team2 = new Player2Team("Arsenal", SecondTeam);
            Time = new Timer60(0, 0);
            Speeds = new List<int> { PlusBallSpeedXClone, PlusBallSpeedX1, PlusBallSpeedX2, PlusBallSpeedX3, PlusBallSpeedX4, PlusBallSpeedY1, PlusBallSpeedY2, PlusBallSpeedY3, PlusBallSpeedY4 };
        }
        public MyRepository(string FirstTeamName, string SecondTeamName,List<string> players1, List<string> players2, int time) : this(players1,players2)
        {
            //team1 = new TeamPlayer(FirstTeamName, FirstTeam);
            //team2 = new Player2Team(SecondTeamName, SecondTeam);
            //if (time == 60)
            //{
            //    Time = new Timer60(0, 0);
            //}
            //else if (time == 90)
            //{
            //    Time = new Timer90(0, 0);
            //}
            //else
            //{
            //    Time = new Timer180(0, 0);
            //}
        }
        public MyRepository(Match match, List<string>players1, List<string>players2, Settings settings) : this(players1,players2)
        {
            //this.match = match;
            //if (settings.Time==60)
            //{
            //    Time = new Timer60(0, 0);
            //}
            //else if (settings.Time==90)
            //{
            //    Time = new Timer90(0, 0);
            //}
            //else
            //{
            //    Time = new Timer180(0, 0);
            //}
            
            //team1 = new TeamPlayer(match.TeamName1, FirstTeam);
            //team2 = new CompTeam(match.TeamName2,settings.Level*2,SecondTeam);

        }

        public void ColorsForTeams(List<Footballer> FirstTeam, List<Footballer>SecondTeam)
        {
            if (FirstTeamColor == "Black")
            {
                foreach (var player in FirstTeam)
                {
                    player.positionOnTheScreen.BackColor = Color.Black;
                }
            }
            if (FirstTeamColor == "Gold")
            {
                foreach (var player in FirstTeam)
                {
                    player.positionOnTheScreen.BackColor = Color.Gold;
                }
            }
            if (FirstTeamColor == "Maroon")
            {
                foreach (var player in FirstTeam)
                {
                    player.positionOnTheScreen.BackColor = Color.Maroon;
                }
            }
            if (FirstTeamColor == "Blue")
            {
                foreach (var player in FirstTeam)
                {
                    player.positionOnTheScreen.BackColor = Color.DarkBlue;
                }
            }
            if (FirstTeamColor == "Orange")
            {
                foreach (var player in FirstTeam)
                {
                    player.positionOnTheScreen.BackColor = Color.Orange;
                }
            }
            if (SecondTeamColor == "Black")
            {
                foreach (var player in SecondTeam)
                {
                    player.positionOnTheScreen.BackColor = Color.Black;
                }
            }
            if (SecondTeamColor == "Gold")
            {
                foreach (var player in SecondTeam)
                {
                    player.positionOnTheScreen.BackColor = Color.Gold;
                }
            }
            if (SecondTeamColor == "Maroon")
            {
                foreach (var player in SecondTeam)
                {
                    player.positionOnTheScreen.BackColor = Color.Maroon;
                }
            }
            if (SecondTeamColor == "Blue")
            {
                foreach (var player in SecondTeam)
                {
                    player.positionOnTheScreen.BackColor = Color.DarkBlue;
                }
            }
            if (SecondTeamColor == "Orange")
            {
                foreach (var player in SecondTeam)
                {
                    player.positionOnTheScreen.BackColor = Color.Orange;
                }
            }
        }
        public void BallMooving(PictureBox ball)
        {
            aBall.BallMove(ball, BallSpeedX, BallSpeedY);
        }

        public void TimeShowing(List<Label> timeLabels, int firstscore, int secondScore,Timer time)
        {
            Time.TimeGoing(timeLabels, firstscore, secondScore, time, ref AddedTime, team1.Name,team2.Name);
            timeLabels[3].Visible = true;
            
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

        public void TeamsReset(List<Footballer> squad,PictureBox ball, List<Footballer> squad2)
        {
            foreach (var player in squad)
            {
                player.positionOnTheScreen.Location = new Point(player.X_PositionInitial, player.Y_PositionInitial);
            }
            foreach (var player in squad2)
            {
                player.positionOnTheScreen.Location = new Point(player.X_PositionInitial, player.Y_PositionInitial);
            }
                ball.Location = new Point(630, 350);
        
        }

        public static void FinalWhistle()
        {
            if (!FinalWhistlePlayed)
            {
                System.Media.SoundPlayer sp = new System.Media.SoundPlayer();
                sp.SoundLocation = "../../Resources/finalWhistle.wav";
                sp.Play();
                FinalWhistlePlayed = true;
            }
        }

        public void GameEnd(Label GO, Label winner)
        {
            if (GameEnded==true)
            {               
                if (!LabelsMoved)
                {
                    //gameOverlabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    //gameOverlabel.Font = new System.Drawing.Font("Impact", 30F);
                    //gameOverlabel.ForeColor = System.Drawing.Color.Maroon;
                    //gameOverlabel.Text = "GAME OVER";
                    //gameOverlabel.Visible = true;
                    //if (firstScore > secondScore)
                    //{
                    //    winningTeam.Text = FirstTeamName + " IS THE WINNER";
                    //}
                    //else if (firstScore == secondScore)
                    //{
                    //    winningTeam.Text = "DRAW";
                    //}
                    //else
                    //{
                    //    winningTeam.Text = SecondTeamName + " IS THE WINNER";
                    //}
                    //winningTeam.Font = new System.Drawing.Font("Impact", 30F);
                    //winningTeam.ForeColor = System.Drawing.Color.Black;
                    //gameOverlabel.Location = new Point(gameOverlabel.Location.X + 20, gameOverlabel.Location.Y - 200);
                    //winningTeam.Location = new Point(winningTeam.Location.X, winningTeam.Location.Y - 200);
                    //gameOverlabel.Visible = true;
                    //winningTeam.Visible = true;
                    //GO.Location = new Point(GO.Location.X+20, GO.Location.Y - 200);
                    //winner.Location = new Point(winner.Location.X, winner.Location.Y - 200);
                    //GO.Visible = true;
                    //winner.Visible = true;
                    //LabelsMoved = true;
                }                
            }
        }

        public void TechLoose()
        {
            ScoredFirstTeam.Clear();
            ScoredSecondTeam.Clear();
            for (int i = 0; i < 3; i++)
            {
                ScoredSecondTeam.Add("#");
            }
        }

        public static void PressPause(Timer time1, Timer timeTimer, PictureBox pause)
        {
            if (isPausePressed)
            {
                pause.ImageLocation = "../../Resources/PlayIcon.png";
                time1.Enabled = false;
                timeTimer.Enabled = false;
                isPausePressed = true;
            }
            if (!isPausePressed)
            {
                pause.ImageLocation = "../../Resources/PauseIcon.png";
                time1.Enabled = true;
                timeTimer.Enabled = true;
                isPausePressed = false;
            }
        }

        public void ShowStatistics(ListView MatchStat,List<Label> TeamLabels)
        {
            TeamLabels[2].Visible = false;
            Label firstTeamLabel = TeamLabels[0];
            Label firstTeamScoreLabel = TeamLabels[1];
            Label secondTeamScoreLabel = TeamLabels[3];
            Label secondTeamLabel = TeamLabels[4];

            if (!StatisticShown)
            {
                GameEnded = true;
                firstTeamLabel.Location = new Point(firstTeamLabel.Location.X, firstTeamLabel.Location.Y + 200);
                firstTeamScoreLabel.Location = new Point(firstTeamScoreLabel.Location.X - 120, firstTeamScoreLabel.Location.Y + 250);
                firstTeamScoreLabel.Font = new Font("Britannic Bold", 100F);
                secondTeamLabel.Location = new Point(secondTeamLabel.Location.X+40, secondTeamLabel.Location.Y + 200);
                secondTeamScoreLabel.Font = new Font("Britannic Bold", 100F);
                secondTeamScoreLabel.Location = new Point(secondTeamScoreLabel.Location.X + 75, secondTeamScoreLabel.Location.Y + 250);



                MatchStat.Visible = true;
                int AllTouchesAllTeams = team1.AllTouches + team2.AllTouches;
                int firstTeamProcent = (int)Math.Round(100.0 * team1.AllTouches / AllTouchesAllTeams);
                int secondTeamProcent = 100 - firstTeamProcent;
                string Possession = $"       {firstTeamProcent}%       -       {secondTeamProcent}%";
                string Saves;
                string ShortsOnTarget;
                string TotalShots;
                if (team1.GoalKeeperTouches.ToString().Length>1)
                {
                    Saves = $"           {team1.GoalKeeperTouches}       -        {team2.GoalKeeperTouches}      ";
                }
                else
                {
                    Saves = $"             {team1.GoalKeeperTouches}        -       {team2.GoalKeeperTouches}      ";
                }
                string TotalPasses;
                if (team1.AllTouches.ToString().Length > 2)
                {
                    TotalPasses = $"           {team1.AllTouches}      -      {team2.AllTouches}      ";
                }
                else
                {
                    TotalPasses = $"            {team1.AllTouches}      -      {team2.AllTouches}      ";
                }
                if (team1.TotalShots.ToString().Length > 1)
                {
                    TotalShots = $"               {team1.TotalShots}      -      {team2.TotalShots}      ";
                }
                else
                {
                    TotalShots = $"                {team1.TotalShots}      -      {team2.TotalShots}      ";
                }
                if ((team2.GoalKeeperTouches + team1.GoalsScored).ToString().Length > 1)
                {
                    ShortsOnTarget = $"              {team2.GoalKeeperTouches + team1.GoalsScored}      -      {team1.GoalKeeperTouches + team2.GoalsScored}      ";
                }
                else
                {
                    ShortsOnTarget = $"               {team2.GoalKeeperTouches + team1.GoalsScored}      -      {team1.GoalKeeperTouches + team2.GoalsScored}      ";
                }
                MatchStat.ForeColor = Color.Maroon;
                MatchStat.BackColor = Color.PaleGreen;
                MatchStat.Items.Add("            POSSESSION      ");
                MatchStat.Items.Add(Possession);
                MatchStat.Items.Add("      GOALKEEPER SAVES      ");
                MatchStat.Items.Add(Saves);
                MatchStat.Items.Add("          TOTAL PASSES      ");
                MatchStat.Items.Add(TotalPasses);
                MatchStat.Items.Add("           TOTAL SHOTS      ");
                MatchStat.Items.Add(TotalShots);
                MatchStat.Items.Add("        SHOTS ON TARGET     ");
                MatchStat.Items.Add(ShortsOnTarget);
                StatisticShown = true;
            }



        }

        public void LabelAnimation(List<Label> TeamLabels, Timer timer1)
        {
            Label firstTeamScoreLabel = TeamLabels[1];
            Label secondTeamScoreLabel = TeamLabels[3];
            Label goalLabel = TeamLabels[5];
            Label whoScoredLabel = TeamLabels[6];
            Label scoredGoalLabel = TeamLabels[7];
            if (GoalNowScored)
            {
                labelcount++;
                firstTeamScoreLabel.Text = team1.GoalsScored.ToString();
                secondTeamScoreLabel.Text = team2.GoalsScored.ToString();
                timer1.Enabled = false;
                if (labelcount % 30 != 0)
                {
                    if (labelcount % 2 == 0)
                    {
                        goalLabel.ForeColor = Color.Red;
                        whoScoredLabel.ForeColor = Color.Red;
                        scoredGoalLabel.ForeColor = Color.Red;
                    }
                    else
                    {
                        goalLabel.ForeColor = Color.Yellow;
                        scoredGoalLabel.ForeColor = Color.Yellow;
                    }
                }
                else
                {
                    timer1.Enabled = true;
                    GoalNowScored = false;
                    labelcount = 0;
                    goalLabel.Visible = false;
                    whoScoredLabel.Visible = false;
                    scoredGoalLabel.Visible = false;
                }
            }
        }

        public void TeamsLeaving()
        {
            team1.TeamLeavingDown(5);
            team2.TeamLeavingDown(5);
        }

        public void WhoScoredMethod(List<Footballer> squad, List<Footballer> squad2)
        {
            foreach (var player in squad)
            {
                if (player.GoalsScored != 0)
                {
                    player.GoalsScored--;
                    ScoredFirstTeam.Add(player.Name);
                }
            }
            foreach (var player in squad2)
            {
                if (player.GoalsScored != 0)
                {
                    player.GoalsScored--;
                    ScoredSecondTeam.Add(player.Name);
                }
            }
        }

        public void TeamGoalScored(PictureBox ball, PictureBox goal, List<Footballer> squad, PictureBox leftgoal, List<Footballer> squad2,  Label goalScoredLabel, Label whoScoredLabel, Label scoredLabel, ref int teamScore, ref int secondTeamScore, ListView whoScoredListView)
        {
            List<Footballer> ScoredTeam = new List<Footballer>();
            countForlabel = r.Next(1, 5);
            if (ball.Bounds.IntersectsWith(goal.Bounds) || ball.Bounds.IntersectsWith(leftgoal.Bounds))
            {
                System.Media.SoundPlayer sp2 = new System.Media.SoundPlayer();
                sp2.SoundLocation = "../../Resources/goalscored.wav";
                sp2.Play();
                if (ball.Bounds.IntersectsWith(goal.Bounds))
                {
                    
                    ScoredTeam = squad;
                    teamScore++;
                    team1.GoalsScored = teamScore;

                }
                if (ball.Bounds.IntersectsWith(leftgoal.Bounds))
                {
                    ScoredTeam = squad2;
                    secondTeamScore++;
                    team2.GoalsScored = secondTeamScore;
                }

                TeamsReset(squad, ball,squad2);
                
                foreach (var player in ScoredTeam)
                {
                    if (player.LastTouch == true)
                    {
                        GoalNowScored = true;
                        player.GoalsScored++;
                        player.LastGoalTime = Time.Min+1;
                        toScoreString = $"{player.LastGoalTime}' {player.Name}  {team1.GoalsScored}-{team2.GoalsScored}";
                        WhoScoredList.Add(toScoreString);

                        foreach (var str in WhoScoredList)
                        {
                            if (toScoreString.Length > 20)
                            {
                                whoScoredListView.Font = new System.Drawing.Font("Cambria", 9);
                            }
                            if (toScoreString.Length > 25)
                            {
                                whoScoredListView.Font = new System.Drawing.Font("Cambria", 8);
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
            int countForAcceleration = r.Next(1, 9);
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
                    //System.Media.SoundPlayer sp3 = new System.Media.SoundPlayer();
                    //sp3.SoundLocation = "../../Resources/shot.wav";
                    //sp3.Play();
                    if (ball.Bounds.IntersectsWith(sqwad[0].positionOnTheScreen.Bounds))
                    {
                        team1.GoalKeeperTouches++;
                    }
                    if (ball.Bounds.IntersectsWith(sqwad[8].positionOnTheScreen.Bounds) || ball.Bounds.IntersectsWith(sqwad[8].positionOnTheScreen.Bounds) || ball.Bounds.IntersectsWith(sqwad[8].positionOnTheScreen.Bounds))
                    {
                        team1.TotalShots++;
                    }
                    team1.AllTouches++;
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

        public void CollisionWithRightTeam(PictureBox ball, bool isUpPressed, bool isDownPressed)
        {
            team2.CollisionWithBall(ball, isUpPressed, isDownPressed, ref BallSpeedX,ref BallSpeedY, Speeds); 
        }

        public void CompTeamMoving(List<Footballer>sqw, Dictionary<int,PictureBox> Players, Dictionary<int,PictureBox> lines, PictureBox Ball)
        {
            team2.WholeTeamMoving(sqw, Players, lines, Ball);
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
