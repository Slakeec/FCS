using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Football_Game
{
     public abstract class AbstractTime
    {

        public int Min { get; set; }
        public int Sec { get; set; }
        public int Speed{ get; set; }

        public AbstractTime(int min, int sec, int speed)
        {
            Min = min;
            Sec = sec;
            Speed = speed;
        }
        public void TimerItself(Label min, Label sec, Label secsec, Label dots)
        {
        }

        public virtual void TimeGoing(List<Label> labelsTime,int firstScore, int secondScore, Timer timer, ref int minsAdd, string FirstTeamName, string SecondTeamName)
        {
            Label min = labelsTime[0];
            Label sec = labelsTime[1];
            Label secsec = labelsTime[2];
            Label dots = labelsTime[3];
            Label addedTime = labelsTime[4];
            Label gameOverlabel = labelsTime[5];
            Label winningTeam = labelsTime[6];

            if (Min == 88)
            {
                minsAdd = Math.Min(9, firstScore + secondScore);
                addedTime.Text = $"+{minsAdd} min";
                addedTime.Visible = true;
            }

            Sec += Speed;
            if (Sec == 60)
            {
                Sec = 0;
                Min++;
            }
            if (Min < 10)
                min.Text = "0" + Min.ToString();
            else
                min.Text = Min.ToString();
            int st = Sec / 10;
            int ss = Sec % 10;
            sec.Text = st.ToString();
            secsec.Text = ss.ToString();

            if (Sec % 5 == 0)
            {
                dots.Visible = false;
            }
            else
            {
                dots.Visible = true;
            }

            if (Min == 90+minsAdd)
            {
                timer.Enabled = false;
                gameOverlabel.Text = "GAME OVER";
                gameOverlabel.Visible = true;
                if (firstScore > secondScore)
                {
                    winningTeam.Text = FirstTeamName;
                }
                else if (firstScore == secondScore)
                {
                    winningTeam.Text = "DRAW";
                }
                else
                {
                    winningTeam.Text = SecondTeamName;
                }
                winningTeam.Visible = true;
            }
        }
    }
}
