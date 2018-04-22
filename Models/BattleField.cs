using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Drawing;

namespace ZarzadzeniaOddzialamiNET.Models
{
    /*
     * Walak jest w pełni automatyzcna. Zasada działania:
     * 1. Wybierana jest strona konflinku, która zaczyna (wpływ ma statystyla leadership)
     * 2. Losowana jest jednostka, która zadaje obrażenia.
     * 3. Wybierana jest jednostka, której obrażenia zostaną zadane.
     * 4. Powrót do p. 1.
     * 5. W przypadku zabicia wszystkich jednostek jednej z armii, jednostki przeciwnika raz atakują bohatera.
     */
    class BattleField
    {
        public Army FirstArmy;
        public Army SecondArmy;
        public int turn = 0;

        Random rand = new Random();

        public BattleField(Army first, Army second)
        {
            FirstArmy = first;
            SecondArmy = second;
        }

        public void StartBattle()
        {
            while (true)
            {
                turn++;
                Console.Write($"Press any key to move on to next turn!");
                Console.ReadKey();
                Console.Write($"\n#########################\nTurn: {turn} \n");
                if (!CanFight(FirstArmy))
                {
                    Console.Write($"Army of {FirstArmy.Hero.Name} can't fight.\n");
                    LastAttackToHero(SecondArmy, FirstArmy.Hero);
                    break;

                }
                else if (!CanFight(SecondArmy))
                {
                    Console.Write($"Army of {SecondArmy.Hero.Name} can't fight.\n");
                    LastAttackToHero(FirstArmy, SecondArmy.Hero);
                    break;

                }
                else
                {
                    ChooseTheFirstOne();
                }
                FirstArmy.Draw();
                Console.Write("\n");
                SecondArmy.Draw();
            }

            FirstArmy.Draw();
            Console.Write("\n");
            SecondArmy.Draw();
        }

        void ChooseTheFirstOne()
        {
            int sumOfLeadership = FirstArmy.Hero.Leadership + SecondArmy.Hero.Leadership;
            if (rand.Next(sumOfLeadership) < FirstArmy.Hero.Leadership)
            {
                Console.Write($"Army of {FirstArmy.Hero.Name} start first.\n");
                Fight(FirstArmy, SecondArmy);
            }
            else
            {
                Console.Write($"Army of {SecondArmy.Hero.Name} start first.\n");
                Fight(SecondArmy, FirstArmy);
            }
        }

        int chooseUnit(Army army)
        {
            if (!CanFight(army))
            {
                throw new Exception($"All Army of {army.Hero.Name} is dead.");
            }

            int id;
            do
            {
                id = rand.Next(army.Units.Count);
            } while (army.Units[id].isDead);
            return id;
        }

        void Fight(Army first, Army second)
        {
            int idAttacker = chooseUnit(first);
            int idDefender = chooseUnit(second);

            first.Units[idAttacker].Attack(second.Units[idDefender]);

            //TODO: Delete Console.Write
            Console.Write($"{first.Hero.Name}[{idAttacker}] -hit-> {second.Hero.Name}[{idDefender}].\n");
        }

        bool CanFight(Army army)
        {
            for (int i = 0; i < army.Units.Count; i++)
            {
                if (!army.Units[i].isDead)
                {
                    return true;
                }
            }
            return false;
        }

        void LastAttackToHero(Army army, Hero hero)
        {
            for (int i = 0; i < army.Units.Count; i++)
            {
                if (!army.Units[i].isDead)
                {
                    army.Units[i].Attack(hero);
                }
            }
        }
    }
}
