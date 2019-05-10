﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacter
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Dice dice20 = new Dice(rnd, 20);
            Dice dice6 = new Dice(rnd);

            Character char1 = new Character("Karel", 100, dice6, dice20);
            Character char2 = new Character("Ambrož", 110, dice6, dice20);

            char1.Equip(new Weapon("Short sword", 4, 1, false));
            char1.Equip(new Shield("Wooden shield", 3));

            char2.Equip(new Weapon("Dragon axe", 7, 0, true));

            Arena arena = new Arena(char1, char2, new ConsoleReporter());
            while (char1.IsAlive && char2.IsAlive)
            {
                arena.Round();
            }

            Console.ReadKey();

        }
    }
}
