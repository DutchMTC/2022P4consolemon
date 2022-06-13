using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMonsters
{
    internal class ConsoleMonArena
    {
        internal void DoBattle(ConsoleMon a, ConsoleMon b)
        {
            Random random = new Random();
            while (a.health != 0 || b.health != 0)
            {
                if ((a.health >= 0) || (b.health >= 0))
                {
                    int xa = random.Next(0, a.skills.Count);
                    Skill skilla = a.skills[xa];
                    skilla.UseOn(b, a);
                    Console.WriteLine(a.monsterType + " used " + skilla.name + " on " + b.monsterType);
                    Console.WriteLine(b.monsterType + " has " + b.health + "HP left!");
                    Console.ReadLine();
                    int xb = random.Next(0, b.skills.Count);
                    Skill skillb = b.skills[xb];
                    skillb.UseOn(a, b);
                    Console.WriteLine(b.monsterType + " used " + skillb.name + " on " + a.monsterType);
                    Console.WriteLine(a.monsterType + " has " + a.health + "HP left!");
                    Console.ReadLine();
                }
                if (a.health <= 0)
                {
                    Console.WriteLine(b.monsterType + " wins!");
                    break;
                }
                if (b.health <= 0)
                {
                    Console.WriteLine(a.monsterType + " wins!");
                    break;
                }
            }
            

        }
    }
}
