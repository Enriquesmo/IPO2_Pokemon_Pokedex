﻿using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace IPO2_Pokemon_Pokedex
{
    /// <summary>
    /// Página dedicada a la seleccion de los pokemon que van a combatir.
    /// 
    /// Proyecto realizado por:
    /// Enrique Sánchez-Migallón Ochoa
    /// Javier Santos Sanz
    /// Alonso Crespo Fernández
    /// Felipe Alcázar Gómez
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

        /*Inicializacion de la pagina Seleccion_CombatePage*/

        public Seleccion_CombatePage() // Terminado
        {
            this.InitializeComponent();
            deshabilitar_Ocultar_FormaPokedex_Pokemons_DerYizq();
        }

        /************************************************************************************************/

        /*Botones de la propia pagina*/

        private void Ir_A_La_Siguiente_Pagina_Click(object sender, RoutedEventArgs e) // Terminado
        {
            // Boton que sirve para poder pasar a la seleccion de escenario
            if (eleccionPokemon2)
            {
                Frame EscenarioFrame = (Frame)this.Parent;
                EscenarioFrame.Navigate(typeof(Escenario_CombatePage), this);
            }
        }
        private void Btn_Sandshrew_Click(object sender, RoutedEventArgs e) // Terminado
        {
            SeleccionarSandshrew();
        }
        private void Btn_Raichu_Click(object sender, RoutedEventArgs e) // Terminado
        {
            SeleccionarRaichu();
        }
        private void Btn_Darumaka_Click(object sender, RoutedEventArgs e) // Terminado
        {
            SeleccionarDarumaka();
        }
        private void Btn_Snorlarx_Click(object sender, RoutedEventArgs e) // Terminado
        {

            SeleccionarSnorlarx();
        }
        private void Btn_Aleatorio_Click(object sender, RoutedEventArgs e) // Terminado
        {
            Random Ran = new Random();
            int NumPokemon = Ran.Next(1, 5);
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
                    SeleccionarSnorlarx();
                    break;
            }
        }
        private void Btn_Reverse_Click(object sender, RoutedEventArgs e) // Terminado
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

        /************************************************************************************************/

        /*Metodos funcionales en la pagina*/

        protected override void OnNavigatedTo(NavigationEventArgs e) // Terminado
        {
            // Metodo que sirve para heredar atributos de la page anterior
            base.OnNavigatedTo(e);
            Padre = (CombatePage)e.Parameter;
            modo_de_juego = Padre.modo_de_Juego;
        }

        /************************************************************************************************/

        /*Metodos Auxiliares*/

        public void seleccionPokemon(String nombre) // Terminado
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
        public void comprobarDarumaka(String ladoDelCampo) // Terminado
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
        public void comprobarSandshrew(String ladoDelCampo) // Terminado
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
        public void comprobarSnorlax(String ladoDelCampo) // Terminado
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
        public void comprobarRaichu(String ladoDelCampo) // Terminado
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
        private void SeleccionarSnorlarx() // Terminado
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
        private void SeleccionarDarumaka() // Terminado
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
        private void SeleccionarRaichu() // Terminado
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
        private void SeleccionarSandshrew() // Terminado
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
    }
}
