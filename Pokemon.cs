using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IPO2_Pokemon_Pokedex
{
    public enum Pokemon_Type
    {
        Normal,
        Fire,
        Water,
        Grass,
        Electric,
        Ice,
        Fighting,
        Poison,
        Ground,
        Flying,
        Psychic,
        Bug,
        Rock,
        Ghost,
        Dark,
        Dragon,
        Steel,
        Fairy
    }

    internal class Pokemon
    {
        private const string DEFAULT_NAME="POKEMON_DEFAULT";
        private const int DEFAULT_ID = 999;
        public int id { get; set; }
        public string name { get; set; }
        public Pokemon_Type type { get; set;}
        public int level { get; set; }
        public int hp { get; set; }
        public int attack { get; set; }
        public int defense { get; set; }
        public int speedAttack { get; set; }
        public int speedDefense { get; set; }
        public int speed { get; set; }

        public Pokemon()
        {
            this.id = DEFAULT_ID;
            this.name = DEFAULT_NAME;
            this.type = Pokemon_Type.Normal;
        }

        public Pokemon(int id, string name, Pokemon_Type type)
        {
            this.id = id;
            this.name = name;
            this.type = type;
        }

        public Pokemon(int id, string name, Pokemon_Type type, int level, int hp, int attack, int defense, int speedAttack, int speedDefense, int speed)
        {
            this.id = id;
            this.name = name;
            this.type = type;
            this.level = level;
            this.hp = hp;
            this.attack = attack;
            this.defense = defense;
            this.speedAttack = speedAttack;
            this.speedDefense = speedDefense;
            this.speed = speed;
        }
    }
}
