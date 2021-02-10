using System;
using System.Collections.Generic;
using System.Text;

namespace BanasTutorial
{
    class Battle
    {
        public static void StartFight(Warrior warrior1, Warrior warrior2)
        {
            while (true)
            {
                if (GetAttackResult(warrior1, warrior2) == "Game Over")
                {
                    Console.WriteLine();
                    break;
                }
                if (GetAttackResult(warrior2, warrior1) == "Game Over")
                {
                    Console.WriteLine();
                    break;
                }
            }
        }

        public static string GetAttackResult(Warrior attacker, Warrior blocker)
        {
            double AttackAmt = attacker.Attack();
            double blockAmt = blocker.Block();

            double dmgDealt = AttackAmt - blockAmt;

            if (dmgDealt > 0)
            {
                blocker.Health -= dmgDealt;
            }
            else dmgDealt = 0;

            Console.WriteLine($"{attacker.Name} attacks {blocker.Name} for {dmgDealt} damage.");

            Console.WriteLine($"{blocker.Name} has {blocker.Health} health.\n");

            if (blocker.Health <= 0)
            {
                Console.WriteLine($"{blocker.Name} has died.");
                return "Game Over";
            }
            else return "Fight ON!";

        }
    }
}
