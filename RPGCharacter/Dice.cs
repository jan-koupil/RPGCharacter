using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacter
{
    class Dice
    {
        Random Rnd;
        readonly int SideCnt;       
        public Dice(Random rnd, int sides = 6)
        {
            this.Rnd = rnd;
            this.SideCnt = sides;
        }
        public int Throw()
        {
            return Rnd.Next(SideCnt) + 1;
        }
    }
}
