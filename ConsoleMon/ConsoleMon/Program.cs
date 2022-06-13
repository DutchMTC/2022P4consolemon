using ConsoleMonsters.Loaders;
using System;

namespace ConsoleMonsters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleMonFactory factory = new ConsoleMonFactory();
            ConsoleMonArena arena = new ConsoleMonArena();
            factory.Load(@"C:\School\L1P4\GD\ConsoleMon\ConsoleMon\ConsoleMon\monsterdata.txt");
            ConsoleMon a = factory.Make("EnterMon");
            ConsoleMon b = factory.Make("NewLineMon");
            arena.DoBattle(a, b);
            Skill attack = new Skill()
            {
                damage = 10,
                energyCost = 2,
                name = "attack",
                element = Elements.Water
            };

            Skill copyVanAttack = new Skill(attack);
        }
    }
}
