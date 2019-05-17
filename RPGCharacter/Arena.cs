using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacter
{
    class Arena
    {
        Character _char1;
        Character _char2;
        IReporter reporter;

        public Character Winner
        {
            get
            {
                if (_char1.IsAlive && _char2.IsAlive)
                    return null;

                return _char1.IsAlive ? _char1 : _char2; 
            }
        }

        public Arena(Character char1, Character char2, IReporter reporter)
        {
            this._char1 = char1;
            this._char2 = char2;
            this.reporter = reporter;
            reporter.Report($"The final battle {_char1.Name} vs. {_char2.Name} begins");
            ReportStatus();
            reporter.Separator();
        }

        private void ReportStatus()
        {
            reporter.Report($"{_char1.Name} has {_char1.HP} hit points, {_char2.Name} has {_char2.HP} hit points");
        }

        public void Round()
        {
            Character attacker;
            Character defender;
            //hod na iniciativu
            if (Initiative() == 1)
            {
                attacker = _char1;
                defender = _char2;
            }
            else
            {
                attacker = _char2;
                defender = _char1;
            }

            //utok prvniho
            Exchange(attacker, defender);

            //utok druheho
            if (defender.IsAlive)
                Exchange(defender, attacker);

            ReportStatus();
            reporter.Separator();
        }

        // returns 1 if, first wins initiative, else 2
        private int Initiative()
        {
            int init1;
            int init2;

            do
            {
                init1 = _char1.InitiativeRoll();
                init2 = _char2.InitiativeRoll();
                string message = $"Initiative: {_char1.Name} rolls {init1}, {_char2.Name} rolls {init2}, ";
                if (init1 > init2)
                    message += $"{_char1.Name} wins.";
                else if (init2 > init1)
                    message += $"{_char2.Name} wins.";
                else
                    message += "it is a draw.";

                reporter.Report(message);
            } while (init1 == init2);

            
            return init1 > init2 ? 1 : 2;
        }

        private void Exchange(Character attacker, Character defender)
        {
            string result = defender.Defence(attacker.AttackRoll());
            reporter.Report(result);
        }

        public void Restart()
        {
            _char1.Rejuvenate();
            _char2.Rejuvenate();
        }
    }
}
