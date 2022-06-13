using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMonsters
{
    internal class ConsoleMon
    {
        internal string monsterType;
        internal int health;
        internal int energy;
        internal string name;
        internal Elements weakness;
        internal List<Skill> skills = new List<Skill>();

        internal ConsoleMon()
        {

        }

        internal ConsoleMon(ConsoleMon consoleMon)
        {
            this.health = consoleMon.health;
            this.energy = consoleMon.energy;
            this.name = consoleMon.name;
            this.weakness = consoleMon.weakness;
            foreach(Skill skill in consoleMon.skills)
            {
                Skill copy = new Skill(skill);
                this.skills.Add(copy);
            }
        }

        internal void TakeDamage(int damage)
        {
            health = health - damage;
        }

        internal void DepleteEnergy(int energy)
        {
            this.energy = this.energy - energy;
        }
    }
}
