using Football_Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Football_Game
{
    public partial class FootballGameForm : Form
    {
        public MyRepository MyRep = new MyRepository();
        List<Footballer> PlayerSQW;
        List<PictureBox> PictureBoxesFirstTeam;

        List<Footballer> Player2SQW;
        List<PictureBox> PictuteBoxesSecondTeam;
        Dictionary<int, PictureBox> Player2PictBoxes = new Dictionary<int, PictureBox>();

        List<PictureBox> PictureLines;
        Dictionary<int, PictureBox> PictureBoxesLines = new Dictionary<int, PictureBox>();

        List<Label> TimeLabels;

        List<Label> TeamsLabels;

        int imagecount = 0, timer1count = 0;
        int FirstTeamScore=0,SecondTeamScore=0;
        bool isUpPressed, isDownPressed, isUpArrowPressed, isDownArrowPressed;

        public FootballGameForm(string name1, string name2, List<string> players1, List<string> players2,
                            int time, int difficulty, bool isMulti, List<string> FirstScoredPlayers, List<string> SecondScoredPlayers,
                            string color1,string color2)
        {
            MyRep = new MyRepository(name1, name2, players1, players2, time, difficulty, isMulti, FirstScoredPlayers,SecondScoredPlayers,
                                    color1, color2);
            InitializeComponent();

        }
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

            TimeLabels = new List<Label> { labelMin, labelSec, labelSecSec, labelDoubleDot, labelAddedTime,goalLabel, scoredGoalLabel };
            TeamsLabels = new List<Label> { firstTeamLabel, firstTeamScoreLabel, slashLabel, secondTeamScoreLabel, secondTeamLabel, goalLabel,whoScoredLabel,scoredGoalLabel };
            MyRep.ColorsForTeams(PlayerSQW, Player2SQW);
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
                if (MyRepository.GameEnded)
                {
                    MyRep.TeamsLeaving();
                    MyRep.ShowStatistics(listViewMatchStat, TeamsLabels);
                    MyRep.GameEnd(goalLabel,scoredGoalLabel);
                    MyRep.WhoScoredMethod(PlayerSQW, Player2SQW);
                    pictureBoxPause.Visible = false;
                }
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
            if (!MyRepository.GameEnded)
            {
                MyRep.LabelAnimation(TeamsLabels, timer1, imagecount);
            }
        }

        private void TimerForTime_Tick(object sender, EventArgs e)
        {
            MyRep.TimeShowing(TimeLabels,FirstTeamScore,SecondTeamScore,TimerForTime);

        }
        private void goalLabel_Click(object sender, EventArgs e)
        {

        }

        private void whoScoredLabel_Click(object sender, EventArgs e)
        {

        }

        private void scoredGoalLabel_Click(object sender, EventArgs e)
        {

        }

        private void firstTeamLabel_Click(object sender, EventArgs e)
        {

        }

        private void firstTeamScoreLabel_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void pictureBoxPause_DoubleClick(object sender, EventArgs e)
        {
            //PressPause(timer1, TimerForTime, pictureBoxPause);
        }

        private void pictureBoxPause_Click(object sender, EventArgs e)
        {
            //MyRepository.PressPause(timer1, TimerForTime, pictureBoxPause);
            if (!MyRepository.isPausePressed)
            {
                pictureBoxPause.Image = Football_Game.Properties.Resources.PlayIcon;
                timer1.Enabled = false;
                TimerForTime.Enabled = false;
                MyRepository.isPausePressed = true;
            }
            else
            {
                pictureBoxPause.Image = Football_Game.Properties.Resources.PauseIcon;
                timer1.Enabled = true;
                TimerForTime.Enabled = true;
                MyRepository.isPausePressed = false;
            }

        }

        private void FootballGameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!MyRepository.GameEnded)
            {
                if (MessageBox.Show("Вы уверены что хотите закрыть приложение? \nЗакрытие программы во время игры ведет к техническому поражению", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
                    e.Cancel = true;
                else
                    e.Cancel = false;

                   MyRep.TechLoose();
            }
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
