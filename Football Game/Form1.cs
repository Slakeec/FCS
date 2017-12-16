﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameFootball
{
    public partial class FootballGameForm : Form
    {
        MyRepository MyRep=new MyRepository();
        List<Footballer> PlayerSQW;
       // AbstractTeam FirstTeam = new TeamPlayer();
        List<PictureBox> PictureBoxesFirstTeam;

        List<Footballer> Player2SQW;
        List<PictureBox> PictuteBoxesSecondTeam;
        Dictionary<int, PictureBox> Player2PictBoxes = new Dictionary<int, PictureBox>();

        List<PictureBox> PictureLines;
        Dictionary<int, PictureBox> PictureBoxesLines = new Dictionary<int, PictureBox>();

        List<Label> TimeLabels;

        int imagecount=0, timer1count=0, timerfortimecount = 0;
        int labelcount = 0;
        int FirstTeamScore=0,SecondTeamScore=0;
        public bool isUpPressed, isDownPressed, isUpArrowPressed, isDownArrowPressed;

        public FootballGameForm()
        {
            InitializeComponent();
        }

        private void FootballGameForm_Load(object sender, EventArgs e)
        {
            firstTeamLabel.Text = MyRep.team1.Name;
            secondTeamLabel.Text = MyRep.team2.Name;
            PictureBoxesFirstTeam = new List<PictureBox> { Goalkeeper, CentrDef1, CentrDef2, Mid1, Mid2, Mid3, Mid4, Mid5, leftForw, centralForw, rightForw };
            PlayerSQW = MyRep.FirstTeam;
            for (int i = 0; i < PlayerSQW.Count; i++)
            {
                PlayerSQW[i] = new Footballer(PlayerSQW[i].Name, PlayerSQW[i].GoalsScored, PictureBoxesFirstTeam[i], PictureBoxesFirstTeam[i].Location.X, PictureBoxesFirstTeam[i].Location.Y);
            }
            PictuteBoxesSecondTeam = new List<PictureBox> { GoalKeeperTeam2, centrDef1Team2, centrDef2Team2, Mid1Team2, Mid2Team2, Mid3Team2, Mid4Team2, Mid5Team2, leftForwTeam2, centralForwTeam2, rightForwTeam2 };
            Player2SQW = MyRep.SecondTeam;
            for (int i = 0; i < Player2SQW.Count; i++)
            {
                Player2SQW[i] = new Footballer(Player2SQW[i].Name, Player2SQW[i].GoalsScored, PictuteBoxesSecondTeam[i], PictuteBoxesSecondTeam[i].Location.X, PictuteBoxesSecondTeam[i].Location.Y);
                Player2PictBoxes.Add(i, PictuteBoxesSecondTeam[i]);
            }

            PictureLines = new List<PictureBox> { gorizontalLine, gorizontalLine2, verticalLine, verticalLine2, verticalLine3 };
            for (int i = 0; i < PictureLines.Count; i++)
            {
                PictureBoxesLines.Add(i, PictureLines[i]);
            }

            TimeLabels = new List<Label> { labelMin, labelSec, labelSecSec, labelDoubleDot, labelAddedTime,goalLabel, whoScoredLabel };
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1count++;
            if (TimerForTime.Enabled)
            {
                MyRep.BallMooving(aBall);
                MyRep.TeamGoalScored(aBall, secondTeamGoal, PlayerSQW, firstTeamGoal, Player2SQW, goalLabel, whoScoredLabel, scoredGoalLabel, ref FirstTeamScore, ref SecondTeamScore, listViewWhoScored);
                MyRep.PlayerTeamMoving(PlayerSQW, isUpPressed, isDownPressed);
                MyRep.Player2TeamMoving(Player2SQW, isUpArrowPressed, isDownArrowPressed);
                MyRep.CompTeamMoving(Player2SQW, Player2PictBoxes, PictureBoxesLines, aBall);
                if (timer1count % 5 == 0)
                {
                    MyRep.AccelerationXChangeToNormal();
                }
            }
            else
            {
                MyRep.TeamsLeaving();
            }

        }
        private void checktimer_Tick(object sender, EventArgs e)
        {
            MyRep.CollisionWithBorders(bottomPictBox, highBoundPictBox, leftHighPictBox, leftBottomPictBox, rightHighPictBox, rightBottomPictBox, aBall);
            MyRep.CollisionWithPlayers(aBall, PlayerSQW, isUpPressed, isDownPressed);
            MyRep.CollisionWithRightTeam(aBall, isUpArrowPressed, isDownArrowPressed);
        }
        private void ChangImage_timer_Tick(object sender, EventArgs e)
        {
            imagecount++;
            if (imagecount % 2 == 0)
                aBall.Image = Football_Game.Properties.Resources.Ball1;
            else
                aBall.Image = Football_Game.Properties.Resources.MyBall2;

            if (goalLabel.Visible)
            {
                firstTeamScoreLabel.Text = FirstTeamScore.ToString();
                secondTeamScoreLabel.Text = SecondTeamScore.ToString();
                timer1.Enabled = false;
                labelcount++;     
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
                    labelcount = 0;
                    goalLabel.Visible = false;
                    whoScoredLabel.Visible = false;
                    scoredGoalLabel.Visible = false;
                }
            }
        }
        private void TimerForTime_Tick(object sender, EventArgs e)
        {
            timerfortimecount++;
            MyRep.TimeShowing(TimeLabels,FirstTeamScore,SecondTeamScore,TimerForTime);

        }

        private void TimeTimer_Tick(object sender, EventArgs e)
        {
        }


        private void BottomPictureBox_Click(object sender, EventArgs e)
        {

        }


        private void aBall_Click(object sender, EventArgs e)
        {

        }


        private void FootballGameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                isUpPressed = true;
            }
            if (e.KeyCode == Keys.S)
            {
                isDownPressed = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                isUpArrowPressed = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                isDownArrowPressed = true;
            }
        }


        private void FootballGameForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                isUpPressed = false;
            }
            if (e.KeyCode == Keys.S)
            {
                isDownPressed = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                isUpArrowPressed = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                isDownArrowPressed = false;
            }

        }
    }
}
