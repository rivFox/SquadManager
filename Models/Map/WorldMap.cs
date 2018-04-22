using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Drawing;

namespace ZarzadzeniaOddzialamiNET.Models
{
    [Serializable]
    public class WorldMap : IDrawable
    {
        public int SizeX { set; get; }
        public int SizeY { set; get; }

        public List<MapObject> _Map = new List<MapObject>();
        public WorldMap() { }
        public WorldMap(int x, int y)
        {
            SizeX = x;
            SizeY = y;
        }

        public void AddObject(MapObject obj)
        {
            if(_Map.Contains(obj))
            {
                throw new Exception("This object already exists.");
            }

            _Map.Add(obj);
        }

        public void Draw()
        {
            bool empty = true;
            for (int iy = 0; iy < SizeX; iy++)
            {
                for (int ix = 0; ix < SizeY; ix++)
                {
                    
                    Console.Write("[");
                    foreach(MapObject obj in _Map)
                    {
                        if(obj.PositionX == ix && obj.PositionY == iy)
                        {
                            Console.ForegroundColor = obj.Color;
                            Console.Write(obj.Symbol);
                            Console.ForegroundColor = ConsoleColor.White;
                            empty = false;
                            break;
                        }
                    }
                    if(empty)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        empty = true;
                    }
                    Console.Write("]");
                }
                Console.WriteLine();
            }
        }
    }
}
