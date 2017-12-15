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

        public virtual void TimeGoing( Label min, Label sec, Label secsec, Label dots)
        {
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
        }
    }
}
