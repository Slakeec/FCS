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
        int imagecount=0, timer1count=0, timerfortimecount = 0;
        int labelcount = 0;
        int FirstTeamScore=0;
        public bool isUpPressed, isDownPressed;

        public FootballGameForm()
        {
            InitializeComponent();
            PlayerSQW = new List<Footballer>
            {
                new Footballer("SevaGoal",Goalkeeper,Goalkeeper.Location.X,Goalkeeper.Location.Y),
                new Footballer("Arina",CentrDef1,CentrDef1.Location.X,CentrDef1.Location.Y),
                new Footballer("Anton",CentrDef2,CentrDef2.Location.X,CentrDef2.Location.Y),
                new Footballer("Natasha",Mid1,Mid1.Location.X, Mid1.Location.Y),
                new Footballer("Liza",Mid2,Mid2.Location.X,Mid2.Location.Y),
                new Footballer("Jama",Mid3,Mid3.Location.X,Mid3.Location.Y),
                new Footballer("Pstygo",Mid4,Mid4.Location.X, Mid4.Location.Y),
                new Footballer("Meis",Mid5,Mid5.Location.X,Mid5.Location.Y),
                new Footballer("Valentin",leftForw,leftForw.Location.X,leftForw.Location.Y),
                new Footballer("Shava",centralForw,centralForw.Location.X,centralForw.Location.Y),
                new Footballer("Misha",rightForw,rightForw.Location.X,rightForw.Location.Y)
            };
            
                  
        }

        private void FootballGameForm_Load(object sender, EventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1count++;
            //aBall.Location = new Point(aBall.Location.X + MyRep.BallSpeedX, aBall.Location.Y + MyRep.BallSpeedY);
            MyRep.BallMooving(aBall);
            MyRep.CollisionWithBorders(bottomPictBox, highBoundPictBox, leftHighPictBox, leftBottomPictBox, rightHighPictBox, rightBottomPictBox, aBall);
            MyRep.PlayerTeamMoving(PlayerSQW, isUpPressed, isDownPressed);
            MyRep.CollisionWithPlayers(aBall,PlayerSQW,isUpPressed,isDownPressed);
            MyRep.FirstTeamGoalScored(aBall, secondTeamGoal, PlayerSQW, goalLabel, whoScoredLabel, scoredGoalLabel, ref FirstTeamScore);
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

        private void PlayerTimer_Tick(object sender, EventArgs e)
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
            if (e.KeyCode == Keys.Up)
            {
                isUpPressed = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                isDownPressed = true;
            }
        }


        private void FootballGameForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                isUpPressed = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                isDownPressed = false;
            }

        }
    }
}
