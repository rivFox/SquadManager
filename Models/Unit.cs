using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Serialization;
using System.Drawing;

namespace ZarzadzeniaOddzialamiNET.Models
{
    [Serializable]
    public class Unit : Person
    {
        public ElementOfNature Element { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public int AttackPower { get; set; }
        public Unit() { }
        public Unit(string name, int health, int maxHealth, ElementOfNature element, int attack, int lvl = 1, int exp = 0) : base(name, health, maxHealth)
        {
            Level = lvl;
            Element = element;
            Experience = exp;
            AttackPower = attack;
        }

        public void Attack(Unit target)
        {
            float damage = AttackPower * Element.getModificator(target.Element.indexOfElement) * Level;
            target.AddDamage((int)damage);
        }
        public void Attack(Hero target)
        {
            float damage = AttackPower * Level;
            target.AddDamage((int)damage);

            AddExp((int)damage);
        }

        public void AddExp(int exp)
        {
            Experience += exp;
            if(Experience >= 100)
            {
                Experience -= 100;
                Level++;
            }
        }

        public new void AddDamage(int damage)
        {
            base.AddDamage((int)(damage / Level));
        }
    }
}
