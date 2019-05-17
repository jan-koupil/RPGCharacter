using System;
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
            Character char2 = new Character("Ambrož", 156, dice6, dice20);

            char1.Equip(new Weapon("Morningstar", 3, 4, false));
            char1.Equip(new Shield("Wooden shield", 3));

            char2.Equip(new Weapon("Heavy club", 9, -2, true));


            //Arena arena = new Arena(char1, char2, new ConsoleReporter());
            //while (char1.IsAlive && char2.IsAlive)
            //{
            //    arena.Round();
            //}

            int repeat = 5000;

            Arena arena = new Arena(char1, char2, new BlackHoleReporter());
            int char1Wins = 0;
            int char2Wins = 0;

            for (int i = 0; i < repeat; i++)
            {
                arena.Restart();

                while (char1.IsAlive && char2.IsAlive)
                {
                    arena.Round();
                }
                if (arena.Winner == char1)
                    char1Wins++;
                else
                    char2Wins++;
            }

            Console.WriteLine($"{char1.Name} wins in {(double) char1Wins / repeat * 100}% cases.");
            
            Console.ReadKey();

        }
    }
}
