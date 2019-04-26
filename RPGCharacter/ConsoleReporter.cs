using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacter
{
    class ConsoleReporter : IReporter
    {
        public void Report(string message)
        {
            Console.WriteLine(message);
        }
    }
}
