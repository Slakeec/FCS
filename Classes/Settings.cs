using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Settings
    {
        private int time;
        public int Time
        {
            get { return time; }
            set { time = value; }
        }
        private int level;
        public int Level
        {
            get { return level; }
            set { level = value; }
        }
        public Settings(int tm, int l)
        {
            this.Time = tm;
            this.level = l;
        }
        public Settings()
        {
            this.time = 90;
            this.level = 1;
        }
    }
}
