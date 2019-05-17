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
        public Equipable RightHand { get; private set; }
        public Equipable LeftHand { get; private set; }

        private int DefenceBase
        {
            get {
                if (LeftHand == null || !(LeftHand is Shield))
                    return 0;
                else
                    return ((Shield)LeftHand).Defence; }
        }

        private AttackData AttackBase
        {
            get
            {
                AttackData result = new AttackData();

                if (RightHand == null || !( RightHand is Weapon))
                    return result;
                else
                {
                    result.Attack = ((Weapon)RightHand).Attack;
                    result.Damage = ((Weapon)RightHand).Damage;
                    return result;
                }
            }
        }

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
        public AttackData AttackRoll()
        {
            AttackData result = this.AttackBase;
            result.Attack += this.BattleDice.Throw();
            return result;
        }
        private int DefenceRoll()
        {
            return this.BattleDice.Throw();
        }
        public string Defence(AttackData attackRoll)
        {
            int defenceRoll = DefenceRoll() + DefenceBase;
            // porovná attack a defence
            if (attackRoll.Attack > defenceRoll)
            {
                // případně odmaže životy
                int dmg = attackRoll.Attack - defenceRoll + attackRoll.Damage;
                dmg = Math.Max(dmg, 1);
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

        public bool Equip(Equipable item)
        {
            // když je v pravé obouručka, nelze
            if (RightHand != null && RightHand.TwoHanded)
                return false;

            // když není ruka prázdná, nelze
            // když beru zbraň, pak do pravé
            if (item is Weapon)
            {
                if (RightHand == null)
                {
                    RightHand = item;
                    return true;
                }
            }
            // když beru štít, pak do levé
            else if (item is Shield)
            {
                // když je obouruční a nejsou prázdné obě, nelze
                if (LeftHand == null)
                {
                    LeftHand = item;
                    return true;
                }
            }

            return false; // nastalo něco, kdy nelze vybavit            

        }

        public void Rejuvenate()
        {
            this.HP = this.MaxHP;
        }

    }
}
