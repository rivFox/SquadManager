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
    public class MapObject : IDrawable
    {
        public int PositionX { set; get; }
        public int PositionY { set; get; }
        public char Symbol { set; get; }
        public ConsoleColor Color { set; get; }
        public MapObject() { Color = ConsoleColor.DarkGreen; }
        public MapObject(int x = 0, int y = 0, char symbol = ' ', ConsoleColor color = ConsoleColor.DarkGreen)
        {
            PositionX = x;
            PositionY = y;
            Symbol = symbol;
            Color = color;
        }

        public void ChangePosition(int x, int y)
        {
            PositionX = x;
            PositionY = y;
        }

        public void Draw()
        {
            Console.Write($"[{PositionX},{PositionY}]");
        }
    }
}
