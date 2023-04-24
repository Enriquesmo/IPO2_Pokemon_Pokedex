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
            IconoUri = new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, iconoPath));
        }
        public override string ToString()
        {
            return this.Nombre;
        }
    }

    public static class DatosTipoDePokemon
    {
        public static readonly InfoTipoDePokemon Normal = new InfoTipoDePokemon("Normal", "assets/images/Pokemon_Type_Icon_Normal.png");
        public static readonly InfoTipoDePokemon Fuego = new InfoTipoDePokemon("Fuego", "assets/images/Pokemon_Type_Icon_Normal.png");
        public static readonly InfoTipoDePokemon Agua = new InfoTipoDePokemon("Agua", "assets/images/Pokemon_Type_Icon_Normal.png");
        public static readonly InfoTipoDePokemon Planta = new InfoTipoDePokemon("Planta", "assets/images/Pokemon_Type_Icon_Normal.png");
        public static readonly InfoTipoDePokemon Eléctrico = new InfoTipoDePokemon("Eléctrico", "assets/images/Pokemon_Type_Icon_Normal.png");
        public static readonly InfoTipoDePokemon Hielo = new InfoTipoDePokemon("Hielo", "assets/images/Pokemon_Type_Icon_Normal.png");
        public static readonly InfoTipoDePokemon Lucha = new InfoTipoDePokemon("Lucha", "assets/images/Pokemon_Type_Icon_Normal.png");
        public static readonly InfoTipoDePokemon Veneno = new InfoTipoDePokemon("Veneno", "assets/images/Pokemon_Type_Icon_Normal.png");
        public static readonly InfoTipoDePokemon Tierra = new InfoTipoDePokemon("Tierra", "assets/images/Pokemon_Type_Icon_Normal.png");
        public static readonly InfoTipoDePokemon Volador = new InfoTipoDePokemon("Volador", "assets/images/Pokemon_Type_Icon_Normal.png");
        public static readonly InfoTipoDePokemon Psíquico = new InfoTipoDePokemon("Psíquico", "assets/images/Pokemon_Type_Icon_Normal.png");  
        public static readonly InfoTipoDePokemon Insecto = new InfoTipoDePokemon("Insecto", "assets/images/Pokemon_Type_Icon_Normal.png");
        public static readonly InfoTipoDePokemon Roca = new InfoTipoDePokemon("Roca", "assets/images/Pokemon_Type_Icon_Normal.png");
        public static readonly InfoTipoDePokemon Fantasma = new InfoTipoDePokemon("Fantasma", "assets/images/Pokemon_Type_Icon_Normal.png");
        public static readonly InfoTipoDePokemon Siniestro = new InfoTipoDePokemon("Siniestro", "assets/images/Pokemon_Type_Icon_Normal.png");
        public static readonly InfoTipoDePokemon Dragón = new InfoTipoDePokemon("Dragón", "assets/images/Pokemon_Type_Icon_Normal.png");
        public static readonly InfoTipoDePokemon Acero = new InfoTipoDePokemon("Acero", "assets/images/Pokemon_Type_Icon_Normal.png");
        public static readonly InfoTipoDePokemon Hada = new InfoTipoDePokemon("Hada", "assets/images/Pokemon_Type_Icon_Normal.png");
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
