using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacter
{
    class Weapon : Equipable
    {
        public int Attack { get; private set; }
        public int Damage { get; private set; }

        public Weapon(string name, int attack, int damage = 0, bool twoHanded = false) : base(name, twoHanded)
        {
            Attack = attack;
            Damage = damage;
        }
    }
}
