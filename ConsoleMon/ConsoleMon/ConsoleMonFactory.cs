using ConsoleMonsters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleMonsters.Loaders
{
    class ConsoleMonData
    {
        internal string monsterLine;
        internal string skillLine;
    }
    class ConsoleMonFactory
    {
        private Dictionary<string, ConsoleMonData> templates = new Dictionary<string, ConsoleMonData>();

        public void Load(string datafile)
        {
            //lees je regels in 
            string[] lines = File.ReadAllLines(datafile);

            for (int i = 0; i < lines.Length; i += 2)
            {
                ConsoleMonData data = new ConsoleMonData();
                //zet monsterLine (regel1) & skillLine (regel2)
                data.monsterLine = lines[i];
                data.skillLine = lines[i + 1];

                //split monsterline op ',' en pak de eerste, dit zou je monsterType moeten zijn
                string monsterType = data.monsterLine.Split(',')[0];

                //even toevoegen
                templates.Add(monsterType, data);

            }

        }

        private ConsoleMon MakeConsoleMon(ConsoleMonData data)
        {
            ConsoleMon temp = new ConsoleMon();
            //split de monsterLine uit data weer op ','
            string[] properties = data.monsterLine.Split(",");


           //zet nu de onderste fields met data 
            temp.monsterType = properties[0];
            temp.health = int.Parse(properties[2]);
            temp.weakness = LoadElement(properties[6]);


            //nu de skills, OOF!
            string[] skillSep = data.skillLine.Split(';');
            //nu hebben we de verschillende skills in strings in skillSep (bv skillSep[0] is de data van de eerste skill)

            for (int i = 1; i < skillSep.Length; i++)
            {
                Skill skill = LoadSkill(skillSep[i]);

                //voeg nu skill van hierboven toe aan de skills van temp
                temp.skills.Add(skill);
            }
            return temp;
        }
        private Skill LoadSkill(string skillstring)
        {
            string[] split = skillstring.Split(',');
            Skill skill = new Skill()
            {
                name = split[0],
                damage = int.Parse(split[2]),
                energyCost = int.Parse(split[4]),
                element = LoadElement(split[6])
            };
            return skill;

        }


        //misschien dat jouw enum niet Element heet, dan even Element vervangen door jouw naam
        private static Elements LoadElement(string split)
        {
            return (Elements)Enum.Parse(typeof(Elements), split);
        }

        //30 may 2022 12:26 aangepast
        internal ConsoleMon Make(string monstertype)
        {
            return MakeConsoleMon(templates[monstertype]);
        }
    }
}