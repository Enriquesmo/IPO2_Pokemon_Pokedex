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

    public sealed partial class Seleccion_CombatePage : Page
    {
        /************************************************************************************************/

        /*Inicializacion de las variables globales*/

        public String PokemonJugador1;
        public String PokemonJugador2;
        public Boolean eleccionPokemon1 = false;
        public Boolean eleccionPokemon2 = false;
        public String modo_de_juego;
        CombatePage Padre;


        /************************************************************************************************/

        /*Inicializacion de la pagina CombatePage*/
        public Seleccion_CombatePage()
        {
            this.InitializeComponent();
            deshabilitar_Ocultar_FormaPokedex_Pokemons_DerYizq();
        }

        /************************************************************************************************/

        /*Botones de la propia pagina*/
        private void Ir_A_La_Siguiente_Pagina_Click(object sender, RoutedEventArgs e)
        {
            // Boton que sirve para poder pasar a la seleccion de escenario
            Frame EscenarioFrame = (Frame)this.Parent;
            EscenarioFrame.Navigate(typeof(Escenario_CombatePage), this);
        }

        private void Btn_Sandshrew_Click(object sender, RoutedEventArgs e)
        {
            SeleccionarSandshrew();

        }
        private void SeleccionarSandshrew()
        {
            if (eleccionPokemon1 == false)
            {
                comprobarSandshrew("I");
            }
            else if (eleccionPokemon2 == false)
            {
                comprobarSandshrew("D");
            }
            seleccionPokemon("Sandshrew");
        }
        private void Btn_Raichu_Click(object sender, RoutedEventArgs e)
        {
            SeleccionarRaichu();
        }
        private void SeleccionarRaichu()
        {
            if (eleccionPokemon1 == false)
            {
                comprobarRaichu("I");
            }
            else if (eleccionPokemon2 == false)
            {
                comprobarRaichu("D");
            }
            seleccionPokemon("Raichu");
        }
        private void Btn_Darumaka_Click(object sender, RoutedEventArgs e)
        {
            SeleccionarDarumaka();
        }
        private void SeleccionarDarumaka()
        {
            if (eleccionPokemon1 == false)
            {
                comprobarDarumaka("I");
            }
            else if (eleccionPokemon2 == false)
            {
                comprobarDarumaka("D");
            }
            seleccionPokemon("Darumaka");
        }
        private void Btn_Snorlarx_Click(object sender, RoutedEventArgs e)
        {
            SeleccionarSnorlax();
        }
        private void SeleccionarSnorlax()
        {
            if (eleccionPokemon1 == false)
            {
                comprobarSnorlax("I");
            }
            else if (eleccionPokemon2 == false)
            {
                comprobarSnorlax("D");
            }
            seleccionPokemon("Snorlax");
        }

        /************************************************************************************************/

        /*Metodos funcionales en la pagina*/

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Metodo que sirve para heredar atributos de la page anterior
            base.OnNavigatedTo(e);
            Padre = (CombatePage)e.Parameter;
            modo_de_juego = Padre.modo_de_Juego;
        }

        /************************************************************************************************/

        /*Metodos Auxiliares*/

        public void seleccionPokemon(String nombre)
        {
            if (eleccionPokemon1 == false)
            {
                PokemonJugador1 = nombre;
                eleccionPokemon1 = true;
            }
            else if (eleccionPokemon2 == false)
            {
                PokemonJugador2 = nombre;
                eleccionPokemon2 = true;
            }
        }
        public void deshabilitar_Ocultar_FormaPokedex_Pokemons_DerYizq() // Terminado
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
            }
            else if (ladoDelCampo.Equals("I"))
            {
                UserControl_Darumaka_Izquierda_P2_IA.IsEnabled = true;
                UserControl_Darumaka_Izquierda_P2_IA.Visibility = Visibility.Visible;
            }
        }
        public void comprobarSandshrew(String ladoDelCampo) 
        {
            if (ladoDelCampo.Equals("D"))
            {
                UserControl_Sandshrew_Derecha_P1.IsEnabled = true;
                UserControl_Sandshrew_Derecha_P1.Visibility = Visibility.Visible;
            }
            else if (ladoDelCampo.Equals("I"))
            {
                UserControl_Sandshrew_Izquierda_P2_IA.IsEnabled = true;
                UserControl_Sandshrew_Izquierda_P2_IA.Visibility = Visibility.Visible;
            }
        }
        public void comprobarSnorlax(String ladoDelCampo) 
        {
            if (ladoDelCampo.Equals("D"))
            {
                UserControl_Snorlax_Derecha_P1.IsEnabled = true;
                UserControl_Snorlax_Derecha_P1.Visibility = Visibility.Visible;
            }
            else if (ladoDelCampo.Equals("I"))
            {
                UserControl_Snorlax_Izquierda_P2_IA.IsEnabled = true;
                UserControl_Snorlax_Izquierda_P2_IA.Visibility = Visibility.Visible;
            }
        }
        public void comprobarRaichu(String ladoDelCampo) 
        {
            if (ladoDelCampo.Equals("D"))
            {
                UserControl_Raichu_Derecha_P1.IsEnabled = true;
                UserControl_Raichu_Derecha_P1.Visibility = Visibility.Visible;
            }
            else if (ladoDelCampo.Equals("I"))
            {
                UserControl_Raichu_Izquierda_P2_IA.IsEnabled = true;
                UserControl_Raichu_Izquierda_P2_IA.Visibility = Visibility.Visible;
            }
        }

        private void Btn_Aleatorio_Click(object sender, RoutedEventArgs e)
        {
            Random Ran = new Random();
            int NumPokemon = Ran.Next(1,5);
            switch (NumPokemon)
            {
                case 1:
                    SeleccionarDarumaka();
                    break;

                case 2:
                    SeleccionarRaichu();
                    break;

                case 3:
                    SeleccionarSandshrew();
                    break;

                case 4:
                    SeleccionarSnorlax();
                    break;
            }
        }

        private void Btn_Reverse_Click(object sender, RoutedEventArgs e)
        {
            if (eleccionPokemon2)
            {
                eleccionPokemon2 = false;
                switch (PokemonJugador2)
                {
                    case "Snorlax":
                        UserControl_Snorlax_Derecha_P1.IsEnabled = false;
                        UserControl_Snorlax_Derecha_P1.Visibility = Visibility.Collapsed;
                        break;
                    case "Darumaka":
                        UserControl_Darumaka_Derecha_P1.IsEnabled = false;
                        UserControl_Darumaka_Derecha_P1.Visibility = Visibility.Collapsed;
                        break;
                    case "Raichu":
                        UserControl_Raichu_Derecha_P1.IsEnabled = false;
                        UserControl_Raichu_Derecha_P1.Visibility = Visibility.Collapsed;
                        break;
                    case "Sandshrew":
                        UserControl_Sandshrew_Derecha_P1.IsEnabled = false;
                        UserControl_Sandshrew_Derecha_P1.Visibility = Visibility.Collapsed;
                        break;
                }
            }
            else if (eleccionPokemon1)
            {
                eleccionPokemon1 = false;
                eleccionPokemon2 = false;
                switch (PokemonJugador1)
                {
                    case "Snorlax":
                        UserControl_Snorlax_Izquierda_P2_IA.IsEnabled = false;
                        UserControl_Snorlax_Izquierda_P2_IA.Visibility = Visibility.Collapsed;
                        break;
                    case "Darumaka":
                        UserControl_Darumaka_Izquierda_P2_IA.IsEnabled = false;
                        UserControl_Darumaka_Izquierda_P2_IA.Visibility = Visibility.Collapsed;
                        break;
                    case "Raichu":
                        UserControl_Raichu_Izquierda_P2_IA.IsEnabled = false;
                        UserControl_Raichu_Izquierda_P2_IA.Visibility = Visibility.Collapsed;
                        break;
                    case "Sandshrew":
                        UserControl_Sandshrew_Izquierda_P2_IA.IsEnabled = false;
                        UserControl_Sandshrew_Izquierda_P2_IA.Visibility = Visibility.Collapsed;
                        break;
                }
            }
        }
    }
}
