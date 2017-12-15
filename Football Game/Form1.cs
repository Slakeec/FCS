using System;
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

        int imagecount=0, timer1count=0, timerfortimecount = 0;
        int labelcount = 0;
        int FirstTeamScore=0;
        public bool isUpPressed, isDownPressed, isUpArrowPressed, isDownArrowPressed;

        public FootballGameForm()
        {
            InitializeComponent();
        }

        private void FootballGameForm_Load(object sender, EventArgs e)
        {
            PictureBoxesFirstTeam = new List<PictureBox> { Goalkeeper, CentrDef1, CentrDef2, Mid1, Mid2, Mid3, Mid4, Mid5, leftForw, centralForw, rightForw };
            PlayerSQW = MyRep.FirstTeam;
            for (int i = 0; i < PlayerSQW.Count ; i++)
            {
                PlayerSQW[i] = new Footballer(PlayerSQW[i].Name,PlayerSQW[i].GoalsScored, PictureBoxesFirstTeam[i], PictureBoxesFirstTeam[i].Location.X, PictureBoxesFirstTeam[i].Location.Y);
            }
            PictuteBoxesSecondTeam = new List<PictureBox> { GoalKeeperTeam2, centrDef1Team2, centrDef2Team2, Mid1Team2, Mid2Team2, Mid3Team2, Mid4Team2, Mid5Team2, leftForwTeam2, centralForwTeam2, rightForwTeam2 };
            Player2SQW = MyRep.SecondTeam;
            for (int i = 0; i < Player2SQW.Count; i++)
            {
                Player2SQW[i] = new Footballer(Player2SQW[i].Name, Player2SQW[i].GoalsScored, PictuteBoxesSecondTeam[i], PictuteBoxesSecondTeam[i].Location.X, PictuteBoxesSecondTeam[i].Location.Y);
            }         

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1count++;
            //aBall.Location = new Point(aBall.Location.X + MyRep.BallSpeedX, aBall.Location.Y + MyRep.BallSpeedY);
            MyRep.BallMooving(aBall);
            MyRep.CollisionWithBorders(bottomPictBox, highBoundPictBox, leftHighPictBox, leftBottomPictBox, rightHighPictBox, rightBottomPictBox, aBall);
            MyRep.PlayerTeamMoving(PlayerSQW, isUpPressed, isDownPressed);
            MyRep.CollisionWithPlayers(aBall,PlayerSQW,isUpPressed,isDownPressed);
            MyRep.FirstTeamGoalScored(aBall, secondTeamGoal, PlayerSQW, goalLabel, whoScoredLabel, scoredGoalLabel, ref FirstTeamScore, listViewWhoScored);
            MyRep.Player2TeamMoving(Player2SQW, isUpArrowPressed, isDownArrowPressed);
            if (timer1count % 5 == 0)
            {
                MyRep.AccelerationXChangeToNormal();
            }
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

        private void checktimer_Tick(object sender, EventArgs e)
        {
        }

        private void TimeTimer_Tick(object sender, EventArgs e)
        {
        }

        private void BottomPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void TimerForTime_Tick(object sender, EventArgs e)
        {
            timerfortimecount++;
            MyRep.Time.TimeGoing(labelMin, labelSec, labelSecSec,labelDoubleDot);

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
