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
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                bool end = false;
                String command;
                Console.ForegroundColor = ConsoleColor.White;
                Serializer serializer = new Serializer();
                GameController Game = new GameController();
                while (!end)
                {
                    Console.Clear();

                    Console.Write("Start program!\n");
                    Console.Write("You can:\n");
                    Console.Write("1. Write \"Start\" to start game!\n");
                    Console.Write("2. Write \"New\" to start new game!\n");
                    Console.Write("3. Write \"Save\" to save game!\n");
                    Console.Write("4. Write \"Load\" to load last game!\n");
                    Console.Write("4. Write \"Back\" to exit the game!\n");

                    command = Console.ReadLine();
                    switch (command)
                    {
                        case "Start":
                            Game.Start();
                            break;
                        case "New":
                            Game = new GameController();
                            Game.Start();
                            break;
                        case "Save":
                            serializer.WriteContent(Game, "Save");
                            Console.Write("Game Saved!\n");
                            break;
                        case "Load":
                            Game = serializer.ReadContent("Save");
                            Game.Start();
                            break;
                        case "Back":
                            end = true;
                            break;
                    }

                }
            }
            catch (Exception e)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Coś jebło za mocno - nie powinno. Daj znać! :(");
                Console.WriteLine(e.Message);
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }
    }
}
