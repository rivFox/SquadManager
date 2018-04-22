using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Drawing;

namespace ZarzadzeniaOddzialamiNET.Models
{
    [Serializable]
    public class GameController
    { 
        public WorldMap WorldMap = new WorldMap(10, 10);
        public List<Hero> Heroes = new List<Hero>();
        public List<Army> Armies = new List<Army>();
        String command;

        ElementOfNature Fire = new ElementOfNature(0, 1f, 4f, 1f, 2f, 0.25f);
        ElementOfNature Wind = new ElementOfNature(1, 0.25f, 1f, 4f, 1f, 2f);
        ElementOfNature Lightning = new ElementOfNature(2, 1f, 1f, 1f, 0.25f, 2f);
        ElementOfNature Earth = new ElementOfNature(3, 4f, 2f, 0.25f, 1f, 0.25f);
        ElementOfNature Water = new ElementOfNature(4, 2f, 4f, 1f, 0.25f, 1f);

        //[XmlElement("Elements")]
        static public List<ElementOfNature> Elements = new List<ElementOfNature>();

        public GameController()
        {
            Elements.Add(Fire);
            Elements.Add(Wind);
            Elements.Add(Lightning);
            Elements.Add(Earth);
            Elements.Add(Water);
        }
        
        public void Help()
        {
            Console.WriteLine("Help - show help."); //Done
            Console.WriteLine("Clear - clear screen.\n"); //Done

            Console.WriteLine("Show Element - show element of nature.\n"); //Testing

            Console.WriteLine("Add Hero - add new hero."); //Done
            Console.WriteLine("ShowHeroes - show list of heroes.\n"); //Done

            Console.WriteLine("Add Army - add new army.");  //Done
            Console.WriteLine("Show Armies - show list of armies."); //Done
            Console.WriteLine("Select Army - select the army.\n"); //Done

            Console.WriteLine("Add Army To Map - ."); //Done
            Console.WriteLine("Show Map - .\n"); //Done

            Console.WriteLine("Start Fight - .\n"); //Done

            Console.WriteLine("Back - .");  //Done
            Console.WriteLine("________ .\n");

        }
        public void Start()
        {
            bool back = false;
            while (!back)
            {
                try
                {
                    command = Console.ReadLine();
                    switch (command)
                    {
                        case "Help":
                            Help();
                            break;
                        case "Clear":
                            ClearScr();
                            break;
                        case "Show Element":
                            ShowElement();
                            break;
                        case "Add Hero":
                            AddHero();
                            break;
                        case "Show Heroes":
                            ShowHeroes();
                            break;
                        case "Add Army":
                            AddArmy();
                            break;
                        case "Show Armies":
                            ShowArmies();
                            break;
                        case "Select Army":
                            ArmyController();
                            break;
                        case "Add Army To Map":
                            AddArmyToMap();
                            break;
                        case "Show Map":
                            ShowMap();
                            break;
                        case "Start Fight":
                            StartFight();
                            break;
                        case "Back":
                            back = true;
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine(e.Message);
                    Console.BackgroundColor = ConsoleColor.Black;
                }

            }
        }

        //ARMIES
        public void ArmyHelp()
        {
            Console.WriteLine("Help - show help."); //Done
            Console.WriteLine("Clear - clear screen.\n"); //Done

            Console.WriteLine("Info - show info about army."); //Done
            Console.WriteLine("Add Unit - add new unit to army."); //Done
            Console.WriteLine("Delete Unit - delete unit from army."); //Done
            Console.WriteLine("Move Unit - move unit to another army.\n"); //Done

            Console.WriteLine("Show Element - show element of nature.\n"); //check up

            Console.WriteLine("Move Army - move the army to another position."); //Testing
            Console.WriteLine("Attack - attack another army.\n"); //Testing

            Console.WriteLine("Show Armies - show list of armies."); //check up
            Console.WriteLine("Show Map - show the World Map.\n"); //check up

            Console.WriteLine("Back - .\n");  //Done
        }
        public void ArmyController()
        {
            if(Armies.Count == 0)
            {
                throw new Exception("No army exist.");
            }

            int armyID;
            do
            {
                Console.Write("Enter a index of Army to control:");
                armyID = Convert.ToInt32(Console.ReadLine());

            } while (armyID > Armies.Count - 1);

            Army selectedArmy = Armies[armyID];

            bool back = false;
            while (!back)
            {
                command = Console.ReadLine();
                switch (command)
                {
                    case "Help":
                        ArmyHelp();
                        break;
                    case "Clear":
                        ClearScr();
                        break;

                    case "Info":
                        selectedArmy.Draw();
                        break;
                    case "Add Unit":
                        AddUnit(selectedArmy);
                        break;
                    case "Delete Unit":
                        DeleteUnit(selectedArmy);
                        break;
                    case "Move Unit":
                        MoveUnit(selectedArmy);
                        break; 
                    case "Show Element":
                        ShowElement();
                        break;
                    case "Move Army":
                        MoveArmy(selectedArmy);
                        break; 
                    case "Attack":
                        Attack(selectedArmy);
                        break;

                    case "Show Armies":
                        ShowArmies();
                        break;
                    case "Show Map":
                        ShowMap();
                        break;
                    case "Back":
                        back = true;
                        break;
                }
            }
        }

        public void AddUnit(Army army)
        {
            Console.Write("Enter a name:");
            String name = Console.ReadLine();

            Console.Write("Enter a health:");
            int health = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter a maxHealth:");
            int maxHealth = Convert.ToInt32(Console.ReadLine());

            int elementID;
            do
            {
                Console.Write("Enter a index element:");
                elementID = Convert.ToInt32(Console.ReadLine());

            } while (elementID > Elements.Count - 1);

            Console.Write("Enter a basic attack:");
            int attack = Convert.ToInt32(Console.ReadLine());
            army.AddUnit(new Unit(name, health, maxHealth, Elements[elementID], attack));

        } 
        public void MoveUnit(Army selectedArmy)
        {
            int unitID;
            do
            {
                Console.Write("Enter a ID of Unit:");
                unitID = Convert.ToInt32(Console.ReadLine());

            } while (unitID > selectedArmy.Units.Count - 1);

            int armyID;
            do
            {
                Console.Write("Enter a ID of Army:");
                armyID = Convert.ToInt32(Console.ReadLine());

            } while (armyID > Armies.Count - 1);

            selectedArmy.MoveUnitToOtherArmy(unitID, Armies[armyID]);
        }
        public void DeleteUnit(Army selectedArmy)
        {
            int unitID;
            do
            {
                Console.Write("Enter a ID of Unit:");
                unitID = Convert.ToInt32(Console.ReadLine());

            } while (unitID > selectedArmy.Units.Count - 1);

            selectedArmy.MinusUnit(unitID);
        } //Testing
        public void MoveArmy(Army selectedArmy)
        {
            int xPos;
            do
            {
                Console.Write("Enter the coordinates X position:");
                xPos = Convert.ToInt32(Console.ReadLine());

            } while (xPos > WorldMap.SizeX || xPos < 0);

            int yPos;
            do
            {
                Console.Write("Enter the coordinates Y position:");
                yPos = Convert.ToInt32(Console.ReadLine());

            } while (yPos > WorldMap.SizeY || yPos < 0);
            selectedArmy.ChangePosition(xPos, yPos);
        }
        public void Attack(Army selectedArmy)
        {
            int secondID;
            do
            {
                Console.Write("Enter a id of enemy army:");
                secondID = Convert.ToInt32(Console.ReadLine());

            } while (secondID > Armies.Count - 1 && secondID != Armies.IndexOf(selectedArmy));

            BattleField Battle = new BattleField(selectedArmy, Armies[secondID]);
            Battle.StartBattle();
        }
        //GENERAL
        public void ClearScr()
        {
            Console.Clear();
        } //Done
        public void AddHero()
        {
            Console.Write("Enter a name:");
            String name = Console.ReadLine();

            Console.Write("Enter a health:");
            int health = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter a maxHealth:");
            int maxHealth = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter a leadership:");
            int leadership = Convert.ToInt32(Console.ReadLine());

            Heroes.Add(new Hero(name, health, maxHealth, leadership));
        } //Done
        public void ShowHeroes()
        {
            Console.Write("|||-=HEROES=-|||\n");
            foreach (Hero hero in Heroes)
            {
                Console.Write($"[{Heroes.IndexOf(hero)}]");
                hero.Draw();
                Console.WriteLine();
            }
        } //Done
        public void AddArmy()
        {
            int heroID;
            do
            {
                Console.Write("Enter a index of Hero:");
                heroID = Convert.ToInt32(Console.ReadLine());

            } while (heroID > Heroes.Count - 1);

            Console.Write("Enter a limit of units:");
            int limitOfUnits = Convert.ToInt32(Console.ReadLine());

            Armies.Add(new Army(Heroes[heroID], limitOfUnits));
        } //Done
        public void ShowArmies()
        {
            Console.Write("|||-=Armies=-|||\n");
            foreach (Army army in Armies)
            {
                Console.Write($"[{Armies.IndexOf(army)}]");
                army.Draw();
                Console.WriteLine();
            }
        } //Done

        public void ShowMap()
        {
            WorldMap.Draw();
        } //TODO
        public void ShowElement()
        {
            Console.Write("0. Fire.\n");
            Console.Write("1. Wind.\n");
            Console.Write("2. Lightning.\n");
            Console.Write("3. Earth.\n");
            Console.Write("4. Water.\n");
        }
        public void AddArmyToMap()
        {
            int armyID;
            do
            {
                Console.Write("Enter a index of Army:");
                armyID = Convert.ToInt32(Console.ReadLine());

            } while (armyID > Armies.Count - 1);

            int xPos;
            do
            {
                Console.Write("Enter the coordinates X position:");
                xPos = Convert.ToInt32(Console.ReadLine());

            } while (xPos > WorldMap.SizeX || xPos < 0);

            int yPos;
            do
            {
                Console.Write("Enter the coordinates Y position:");
                yPos = Convert.ToInt32(Console.ReadLine());

            } while (yPos > WorldMap.SizeY || yPos < 0);
            Armies[armyID].ChangePosition(xPos, yPos);

            char symbol;
            Console.Write("Enter a Symbol of Army:");
            symbol = Convert.ToChar(Console.ReadLine());
            Armies[armyID].Symbol = symbol;


            WorldMap.AddObject(Armies[armyID]);
        }
        public void StartFight()
        {
            int firstID;
            do
            {
                Console.Write("Enter a id of first army:");
                firstID = Convert.ToInt32(Console.ReadLine());

            } while (firstID > Armies.Count - 1);

            int secondID;
            do
            {
                Console.Write("Enter a id of first army:");
                secondID = Convert.ToInt32(Console.ReadLine());

            } while (secondID > Armies.Count - 1 && secondID != firstID);

            BattleField Battle = new BattleField(Armies[firstID], Armies[secondID]);
            Battle.StartBattle();
        }
    }
}
