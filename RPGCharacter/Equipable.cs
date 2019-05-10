using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacter
{
    abstract class Equipable : Item
    {
        public bool TwoHanded { get; private set; }

        protected Equipable(string name, bool twoHanded) : base(name)
        {
            TwoHanded = twoHanded;
        }
    }
}
