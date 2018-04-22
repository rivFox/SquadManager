using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Drawing;
using ZarzadzeniaOddzialamiNET.Models;

namespace ZarzadzeniaOddzialamiNET
{
    [Serializable]
    public class Army : Squad
    {
        public Hero Hero { set; get; }

        public Army() {}
        public Army(Hero hero, int limitOfUnits) : base(limitOfUnits)
        {
            Hero = hero;
        }

        public new void Draw()
        {
            base.Draw();
            Console.Write($"Army of ");
            Hero.Draw();
            Console.Write(":\n");
            for (int i = 0; i < Units.Count; i++)
            {
                Console.Write($"[{i}]");
                Units[i].Draw();
                Console.Write("\n");
            }
            Console.Write("__________\n");
        }

        public void MoveUnitToOtherArmy(int unitID, Army army)
        {
            if (unitID < Units.Count)
            {
                if (army.Units.Count < army.LimitOfUnits)
                {
                    army.AddUnit(Units[unitID]);
                    MinusUnit(unitID);
                }
                else
                {
                    throw new Exception($"This army is full.[{army.Units.Count}/{army.LimitOfUnits}]");
                }
            }
            else
            {
                throw new Exception("This unitID is incorrect.");
            }
        }
    }
}
