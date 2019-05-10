using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacter
{
    class Shield : Equipable
    {
        public int Defence { get; private set; }

        public Shield(string name, int defence) : base(name, false)
        {
            Defence = defence;
        }

    }
}
