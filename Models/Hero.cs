using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Drawing;

namespace ZarzadzeniaOddzialamiNET.Models
{
    [Serializable]
    public class Hero : Person
    {
        public int Leadership { get; set; }
        public Hero() { }
        public Hero(string name, int health, int maxHealth, int leadership) : base(name, health, maxHealth)
        {
            Leadership = leadership;
        }

        public new void Draw()
        {
            base.Draw();
            Console.Write($"({Leadership})");
        }
    }
}
