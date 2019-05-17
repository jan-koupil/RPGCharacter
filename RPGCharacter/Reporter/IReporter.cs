using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacter
{
    interface IReporter
    {
        void Report(string message);
        void Separator();
    }
}
