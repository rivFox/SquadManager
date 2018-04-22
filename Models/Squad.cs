using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Drawing;

namespace ZarzadzeniaOddzialamiNET.Models
{
    [Serializable]
    public abstract class Squad : MapObject
    {
        public List<Unit> Units = new List<Unit>();
        public int LimitOfUnits { get; set; }
        public Squad() { }
        public Squad(int limitOfUnits)
        {
            LimitOfUnits = limitOfUnits;
        }

        public void AddUnit(Unit unit)
        {
            if(Units.Count < LimitOfUnits)
            {
                Units.Add(unit);
            }
        }

        public void MinusUnit(int id)
        {
            if (Units.Count > 0 && id < Units.Count)
            {
                Units.RemoveAt(id);
            }
            else
            {
                throw new Exception("This army is empty or ID is incorrect.");
            }
        }

        public void ChangeLimitOfUnits(int limitOfUnits)
        {
            if(limitOfUnits > Units.Count)
            {
                LimitOfUnits = limitOfUnits;
            }
            else
            {
                throw new Exception("Changing the limit of units is impossible.");
            }
        }

        public new void Draw()
        {
            //Console.Write("__________\n");
            base.Draw();
        }
    }
}
