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
            if(a.health != 0 || b.health != 0)
            {
                int xa = random.Next(0, a.skills.Count);
                Skill skilla = a.skills[xa];
                skilla.UseOn(b, a);
                Console.WriteLine(a + " used " + skilla + " on " + b);
                Console.WriteLine(b + " has " + b.health + "HP left!");
                int xb = random.Next(0, b.skills.Count);
                Skill skillb = a.skills[xb];
                skillb.UseOn(b, a);
                Console.WriteLine(b + " used " + skilla + " on " + a);
                Console.WriteLine(a + " has " + a.health + "HP left!");
            }
            else if (a.health <= 0)
            {
                Console.WriteLine(b + " wins!");
            }else if (b.health <= 0)
            {
                Console.WriteLine(a + " wins!");
            }

        }
    }
}
