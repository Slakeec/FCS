using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceClasses
{
    public class RandomMusic
    {
        public static string GetRandomMusic()
        {
            return $"../../Resources/Music/{(new Random()).Next(6)}.wav";
        }
    }
}
