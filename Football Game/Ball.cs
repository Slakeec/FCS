using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameFootball
{
    public class Ball
    {
        public PictureBox myBall;

        public void BallMove(PictureBox ball, int speedX, int speedY)
        {
            ball.Location = new System.Drawing.Point(ball.Location.X + speedX, ball.Location.Y + speedY);
        }
    }
}
