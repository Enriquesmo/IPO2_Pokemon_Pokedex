using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace IPO2_Pokemon_Pokedex
{
    /// <summary>
    /// Página dedicada a la funcionalidad del combate pokemon
    /// 
    /// Hecho por:
    /// Enrique Sánchez-Migallón Ochoa
    /// Javier Santos Sanz
    /// </summary>

    public sealed partial class Combate_CombatePage : Page
    {
        /************************************************************************************************/

        /*Inicializacion de las variables globales*/

        public String PokemonJugador1;
        public String PokemonJugador2;
        public string modo_de_juego;
        Escenario_CombatePage Padre;
        public Image Fondo;


        /************************************************************************************************/

        /*Inicializacion de la pagina CombatePage*/

        public Combate_CombatePage()
        {
            this.InitializeComponent();
            deshabilitar_Ocultar_FormaPokedex_Pokemons_DerYizq();
            estadoBotones(false);
        }

        /************************************************************************************************/

        /*Botones de la propia pagina*/

        private void Btn_Ataque1_Click(object sender, RoutedEventArgs e)
        {
            deshabilitar_Ocultar_FormaPokedex_Pokemons_DerYizq();
            comprobarDarumaka("D");
            comprobarDarumaka("I");
        }
        private void Btn_Ataque2_Click(object sender, RoutedEventArgs e)
        {
            deshabilitar_Ocultar_FormaPokedex_Pokemons_DerYizq();
            comprobarSandshrew("D");
            comprobarSandshrew("I");
        }
        private void Btn_Ataque3_Click(object sender, RoutedEventArgs e)
        {
            deshabilitar_Ocultar_FormaPokedex_Pokemons_DerYizq();
            comprobarSnorlax("D");
            comprobarSnorlax("I");
        }
        private void Btn_Ataque4_Click(object sender, RoutedEventArgs e)
        {
            deshabilitar_Ocultar_FormaPokedex_Pokemons_DerYizq();
            comprobarRaichu("D");
            comprobarRaichu("I");
        }
        private void btn_EmpezarCombate_Click(object sender, RoutedEventArgs e)
        {
            ImgFondo_Pokemons = Fondo;
            btn_EmpezarCombate.IsEnabled = false;
            btn_EmpezarCombate.Visibility = Visibility.Collapsed;
            estadoBotones(true);
            crearPokemonsIniciales();
        }

        /************************************************************************************************/

        /*Metodos funcionales en la pagina*/

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Padre = (Escenario_CombatePage)e.Parameter;
            PokemonJugador1 = Padre.PokemonJugador1;
            PokemonJugador2 = Padre.PokemonJugador2;
            ImgFondo_Pokemons.Source = Padre.Fondo.Source;
        }

        /************************************************************************************************/

        /*Metodos Auxiliares*/

        public void crearPokemonsIniciales()
        {
            // Condicionales para poder crear el pokemon elegido por el P1
            switch (PokemonJugador1)
            {
                case "Sandshrew":
                    comprobarSandshrew("D");
                    break;

                case "Snorlax":
                    comprobarSnorlax("D");
                    break;

                case "Darumaka":
                    comprobarDarumaka("D");
                    break;

                case "Raichu":
                    comprobarRaichu("D");
                    break;
            }

            // Condicionales para poder crear el pokemon elegido por la IA o el P2
            switch (PokemonJugador2)
            {
                case "Sandshrew":
                    comprobarSandshrew("I");
                    break;

                case "Snorlax":
                    comprobarSnorlax("I");
                    break;

                case "Darumaka":
                    comprobarDarumaka("I");
                    break;

                case "Raichu":
                    comprobarRaichu("I");
                    break;
            }
        }
        public void deshabilitar_Ocultar_FormaPokedex_Pokemons_DerYizq()
        {
            UserControl_Darumaka_Derecha_P1.IsEnabled = false;
            UserControl_Darumaka_Derecha_P1.Visibility = Visibility.Collapsed;
            UserControl_Darumaka_Derecha_P1.verFormaPokedex(false);
            UserControl_Darumaka_Izquierda_P2_IA.IsEnabled = false;
            UserControl_Darumaka_Izquierda_P2_IA.Visibility = Visibility.Collapsed;
            UserControl_Darumaka_Izquierda_P2_IA.verFormaPokedex(false);
            UserControl_Raichu_Derecha_P1.IsEnabled = false;
            UserControl_Raichu_Derecha_P1.Visibility = Visibility.Collapsed;
            UserControl_Raichu_Derecha_P1.verFormaPokedex(false);
            UserControl_Raichu_Izquierda_P2_IA.IsEnabled = false;
            UserControl_Raichu_Izquierda_P2_IA.Visibility = Visibility.Collapsed;
            UserControl_Raichu_Izquierda_P2_IA.verFormaPokedex(false);
            UserControl_Sandshrew_Derecha_P1.IsEnabled = false;
            UserControl_Sandshrew_Derecha_P1.Visibility = Visibility.Collapsed;
            UserControl_Sandshrew_Derecha_P1.verFormaPokedex(false);
            UserControl_Sandshrew_Izquierda_P2_IA.IsEnabled = false;
            UserControl_Sandshrew_Izquierda_P2_IA.Visibility = Visibility.Collapsed;
            UserControl_Sandshrew_Izquierda_P2_IA.verFormaPokedex(false);
            UserControl_Snorlax_Derecha_P1.IsEnabled = false;
            UserControl_Snorlax_Derecha_P1.Visibility = Visibility.Collapsed;
            UserControl_Snorlax_Derecha_P1.verFormaPokedex(false);
            UserControl_Snorlax_Izquierda_P2_IA.IsEnabled = false;
            UserControl_Snorlax_Izquierda_P2_IA.Visibility = Visibility.Collapsed;
            UserControl_Snorlax_Izquierda_P2_IA.verFormaPokedex(false);
        }
        public void comprobarDarumaka(String ladoDelCampo)
        {
            if (ladoDelCampo.Equals("D"))
            {
                UserControl_Darumaka_Derecha_P1.IsEnabled = true;
                UserControl_Darumaka_Derecha_P1.Visibility = Visibility.Visible;
                //UserControl_Darumaka_Derecha_P1.VerVida = true;
                //UserControl_Darumaka_Derecha_P1.VerEnergia = true;
            }
            else
            {
                UserControl_Darumaka_Izquierda_P2_IA.IsEnabled = true;
                UserControl_Darumaka_Izquierda_P2_IA.Visibility = Visibility.Visible;
                //UserControl_Darumaka_Izquierda_P2_IA.VerVida = true;
                //UserControl_Darumaka_Izquierda_P2_IA.VerEnergia = true;
            }
        }
        public void comprobarSandshrew(String ladoDelCampo)
        {
            if (ladoDelCampo.Equals("D"))
            {
                UserControl_Sandshrew_Derecha_P1.IsEnabled = true;
                UserControl_Sandshrew_Derecha_P1.Visibility = Visibility.Visible;
                //UserControl_Sandshrew_Derecha_P1.VerVida = true;
                //UserControl_Sandshrew_Derecha_P1.VerEnergia = true;
            }
            else
            {
                UserControl_Sandshrew_Izquierda_P2_IA.IsEnabled = true;
                UserControl_Sandshrew_Izquierda_P2_IA.Visibility = Visibility.Visible;
                //UserControl_Sandshrew_Izquierda_P2_IA.VerVida = true;
                //UserControl_Sandshrew_Izquierda_P2_IA.VerEnergia = true;
            }
        }
        public void comprobarSnorlax(String ladoDelCampo)
        {
            if (ladoDelCampo.Equals("D"))
            {
                UserControl_Snorlax_Derecha_P1.IsEnabled = true;
                UserControl_Snorlax_Derecha_P1.Visibility = Visibility.Visible;
                //UserControl_Snorlax_Derecha_P1.VerVida = true;
                //UserControl_Snorlax_Derecha_P1.VerEnergia = true;
            }
            else
            {
                UserControl_Snorlax_Izquierda_P2_IA.IsEnabled = true;
                UserControl_Snorlax_Izquierda_P2_IA.Visibility = Visibility.Visible;
                //UserControl_Snorlax_Izquierda_P2_IA.VerVida = true;
                //UserControl_Snorlax_Izquierda_P2_IA.VerEnergia = true;
            }
        }
        public void comprobarRaichu(String ladoDelCampo)
        {
            if (ladoDelCampo.Equals("D"))
            {
                UserControl_Raichu_Derecha_P1.IsEnabled = true;
                UserControl_Raichu_Derecha_P1.Visibility = Visibility.Visible;
                //UserControl_Raichu_Derecha_P1.VerVida = true;
                //UserControl_Raichu_Derecha_P1.VerEnergia = true;
            }
            else
            {
                UserControl_Raichu_Izquierda_P2_IA.IsEnabled = true;
                UserControl_Raichu_Izquierda_P2_IA.Visibility = Visibility.Visible;
                //UserControl_Raichu_Izquierda_P2_IA.VerVida = true;
                //UserControl_Raichu_Izquierda_P2_IA.VerEnergia = true;
            }
        }
        public void estadoBotones(Boolean estado)
        {
            Btn_Ataque1.IsEnabled = estado;
            Btn_Ataque2.IsEnabled = estado;
            Btn_Ataque3.IsEnabled = estado;
            Btn_Ataque4.IsEnabled = estado;
        }
    }
}
