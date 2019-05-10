using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacter
{
    abstract class Item
    {
        public string Name { get; protected set; }

        int Weight;
        int Volume;

        protected Item (string name)
        {
            Name = name;
        }
    }
}
