using System;
using System.Collections.Generic;

namespace OOP_RPG
{
    public class Monster
    {
        private int hp1;
        private int hp2;

        public Monster(string name, int strength, int defense, int hp1, int hp2)
        {
            Name = name;
            Strength = strength;
            Defense = defense;
            this.hp1 = hp1;
            this.hp2 = hp2;
        }

        public string Name { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int OriginalHP { get; set; }
        public int CurrentHP { get; set; }
    }
}