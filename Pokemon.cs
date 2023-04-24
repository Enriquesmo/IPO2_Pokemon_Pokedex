using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace IPO2_Pokemon_Pokedex
{
    public enum TipoDePokemon
    {
        Normal,
        Fuego,
        Agua,
        Planta,
        Eléctrico,
        Hielo,
        Lucha,
        Veneno,
        Tierra,
        Volador,
        Psíquico,
        Insecto,
        Roca,
        Fantasma,
        Siniestro,
        Dragón,
        Acero,
        Hada
    }


    public struct InfoTipoDePokemon
    {
        public string Nombre { get; }
        public Uri IconoUri { get; }

        public InfoTipoDePokemon(string nombre, string iconoPath)
        {
            Nombre = nombre;
            IconoUri = new Uri("ms-appx:///Assets/"+ iconoPath);
        }
        public override string ToString()
        {
            return this.Nombre;
        }
    }

    public static class DatosTipoDePokemon
    {
        public static readonly InfoTipoDePokemon Normal = new InfoTipoDePokemon("Normal", "Pokemon_Type_Icon_Normal.png");
        public static readonly InfoTipoDePokemon Fuego = new InfoTipoDePokemon("Fuego", "Pokemon_Type_Icon_Fire.png");
        public static readonly InfoTipoDePokemon Agua = new InfoTipoDePokemon("Agua", "Pokemon_Type_Icon_Water.png");
        public static readonly InfoTipoDePokemon Planta = new InfoTipoDePokemon("Planta", "Pokemon_Type_Icon_Grass.png");
        public static readonly InfoTipoDePokemon Eléctrico = new InfoTipoDePokemon("Eléctrico", "Pokemon_Type_Icon_Electric.png");
        public static readonly InfoTipoDePokemon Hielo = new InfoTipoDePokemon("Hielo", "Pokemon_Type_Icon_Ice.png");
        public static readonly InfoTipoDePokemon Lucha = new InfoTipoDePokemon("Lucha", "Pokemon_Type_Icon_Fighting.png");
        public static readonly InfoTipoDePokemon Veneno = new InfoTipoDePokemon("Veneno", "Pokemon_Type_Icon_Poison.png");
        public static readonly InfoTipoDePokemon Tierra = new InfoTipoDePokemon("Tierra", "Pokemon_Type_Icon_Ground.png");
        public static readonly InfoTipoDePokemon Volador = new InfoTipoDePokemon("Volador", "Pokemon_Type_Icon_Flying.png");
        public static readonly InfoTipoDePokemon Psíquico = new InfoTipoDePokemon("Psíquico", "Pokemon_Type_Icon_Psychic.png");
        public static readonly InfoTipoDePokemon Insecto = new InfoTipoDePokemon("Insecto", "Pokemon_Type_Icon_Bug.png");
        public static readonly InfoTipoDePokemon Roca = new InfoTipoDePokemon("Roca", "Pokemon_Type_Icon_Rock.png");
        public static readonly InfoTipoDePokemon Fantasma = new InfoTipoDePokemon("Fantasma", "Pokemon_Type_Icon_Ghost.png");
        public static readonly InfoTipoDePokemon Siniestro = new InfoTipoDePokemon("Siniestro", "Pokemon_Type_Icon_Dark.png");
        public static readonly InfoTipoDePokemon Dragón = new InfoTipoDePokemon("Dragón", "Pokemon_Type_Icon_Dragon.png");
        public static readonly InfoTipoDePokemon Acero = new InfoTipoDePokemon("Acero", "Pokemon_Type_Icon_Steel.png");
        public static readonly InfoTipoDePokemon Hada = new InfoTipoDePokemon("Hada", "Pokemon_Type_Icon_Fairy.png");
    }


        internal class Pokemon
    {
        private const string DEFAULT_NAME="POKEMON_DEFAULT";
        private const int DEFAULT_ID = 999;
        public int id { get; set; }
        public string name { get; set; }
        public InfoTipoDePokemon type { get; set;}
        public int level { get; set; }
        public int hp { get; set; }
        public int attack { get; set; }
        public int defense { get; set; }
        public int speedAttack { get; set; }
        public int speedDefense { get; set; }
        public int speed { get; set; }
        public String details { get; set; }
        public BitmapImage icon { get; set; }

        public Pokemon()
        {
            this.id = DEFAULT_ID;
            this.name = DEFAULT_NAME;
            this.type = DatosTipoDePokemon.Normal;
        }

        public Pokemon(int id, string name, InfoTipoDePokemon type)
        {
            this.id = id;
            this.name = name;
            this.type = type;
        }

        public Pokemon(int id, string name, InfoTipoDePokemon type, int level, int hp, int attack, int defense, int speedAttack, int speedDefense, int speed, BitmapImage icon, string details)
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
            this.details = details;
            this.icon = icon;
        }
    }
}
