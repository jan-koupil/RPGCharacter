using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacter
{
    class Character
    {
        public readonly string Name;
        public int MaxHP { get; private set; }
        public int HP { get; private set; }
        private Dice BattleDice;
        private Dice InitiativeDice;

        public bool IsAlive
        {
            get
            {
                return HP > 0;
            }
        }

        public Character (string name, int maxHP, Dice battleDice, Dice initiativeDice)
        {
            this.Name = name;
            this.MaxHP = maxHP;
            this.HP = maxHP;
            this.BattleDice = battleDice;
            this.InitiativeDice = initiativeDice;
        }

        public int InitiativeRoll()
        {
            return this.InitiativeDice.Throw();
        }
        public int AttackRoll()
        {
            return this.BattleDice.Throw();
        }
        private int DefenceRoll()
        {
            return this.BattleDice.Throw();
        }
        public string Defence(int attackRoll)
        {
            int defenceRoll = DefenceRoll();
            // porovná attack a defence
            if (attackRoll > defenceRoll)
            {
                // případně odmaže životy
                int dmg = attackRoll - defenceRoll;
                dmg = Math.Min(dmg, HP);
                HP -= dmg;
                // nedovolí pokles pod nula
                return $"{Name} is hit for {dmg} hit points.";
            }
            else
            {
                return $"{Name} avoids the attack.";
            }
        }

    }
}
