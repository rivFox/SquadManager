using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Drawing;

namespace ZarzadzeniaOddzialamiNET.Models
{
    [Serializable]
    public class Person : IDrawable
    {
        public string Name { get; set; }
        public int MaxHealthPoints { get; set; }
        public int HealthPoints { get; set; }
        public bool isDead = false;
        public Person() { }
        public Person(string name, int health, int maxHealth)
        {
            SetName(name);
            MaxHealthPoints = maxHealth;
            if(health > maxHealth)
            {
                HealthPoints = maxHealth;
            }
            else
            {
                HealthPoints = health;
            }        
        }

        public void SetName(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Name is incorrect.");
            }

            Name = name;
        }

        public void AddHP(int addHP)
        {   
            if(isDead)
            {
                return;
            }

            HealthPoints += addHP;
            if (HealthPoints > MaxHealthPoints)
            {
                HealthPoints = MaxHealthPoints;
            }
        }

        public void AddDamage(int damage)
        {
            if (isDead)
            {
                return;
            }

            HealthPoints -= damage;
            if(HealthPoints < 0)
            {
                Die();
            }
        }

        public void Draw()
        {
            if(!isDead)
            {
                Console.Write($"{Name} [{HealthPoints}/{MaxHealthPoints}]");
            }
            else
            {
                Console.Write($"{Name} [Dead]");
            }
        }

        public void Die()
        {
            isDead = true;
        }
    }
}
