using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMonsters
{
    internal class Skill
    {
        internal int damage;
        internal int energyCost;
        internal string name;
        internal Elements element;
        internal Skill()
        {

        }

        internal Skill(Skill skill)
        {
            this.damage = skill.damage;
            this.energyCost = skill.energyCost;
            this.name = skill.name;
            this.element = skill.element;
        }

        internal void UseOn(ConsoleMon target, ConsoleMon caster)
        {
            caster.DepleteEnergy(energyCost);
            target.TakeDamage(damage);
        }
    }

    internal enum Elements
    {
        Water,
        Fire,
        Ice,
        Grass
    }
}
