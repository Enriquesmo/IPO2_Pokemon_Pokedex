using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
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

        DispatcherTimer dtTimeVidaIzquierda;
        DispatcherTimer dtTimeEnergiaIzquierda;
        DispatcherTimer dtTimeVidaDerecha;
        DispatcherTimer dtTimeEnergiaDerecha;
        public Boolean accionPokemon1;
        public Boolean accionPokemon2;
        public Boolean Boton_presionado;

        /************************************************************************************************/

        /*Inicializacion de la pagina CombatePage*/

        public Combate_CombatePage()
        {
            this.InitializeComponent();
            deshabilitar_Ocultar_FormaPokedex_Pokemons_DerYizq();
            estadoBotones(false);
            accionPokemon1 = true;
            accionPokemon2 = false;
            Boton_presionado = false;
        }

        /************************************************************************************************/

        /*Botones de la propia pagina*/

        private void Btn_Ataque1_Click(object sender, RoutedEventArgs e)
        {
            notificarAtaqueTrasPulsarBoton(Btn_Ataque1);
            //realizarAtaque1();
        }
        private void Btn_Ataque2_Click(object sender, RoutedEventArgs e)
        {
            notificarAtaqueTrasPulsarBoton(Btn_Ataque2);
            //realizarAtaque2();
        }
        private void Btn_Ataque3_Click(object sender, RoutedEventArgs e)
        {
            notificarAtaqueTrasPulsarBoton(Btn_Ataque3);
            //realizarAtaque3();
        }
        private void Btn_Ataque4_Click(object sender, RoutedEventArgs e)
        {
            notificarAtaqueTrasPulsarBoton(Btn_Ataque4);
            //realizarAtaque4();
        }
        private void btn_EmpezarCombate_Click(object sender, RoutedEventArgs e)
        {
            ImgFondo_Pokemons = Fondo;
            btn_EmpezarCombate.IsEnabled = false;
            btn_EmpezarCombate.Visibility = Visibility.Collapsed;
            estadoBotones(true);
            crearPokemonsIniciales();
            cambiarNombresBotones(PokemonJugador1);
            cicloCombate();
        }
        private void Image_Pocion_De_Vida_Izquierda_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            if (ProgressBar_Vida_Izquierda.Value > 0)
            {
                dtTimeVidaIzquierda = new DispatcherTimer();
                dtTimeVidaIzquierda.Interval = TimeSpan.FromMilliseconds(10); // Esto lo he cambiado para que se vea más fluido, deberia ser 100 milisegundos
                dtTimeVidaIzquierda.Tick += aumentarVidaIzquierda;
                dtTimeVidaIzquierda.Start();
                this.Image_Pocion_De_Vida_Izquierda.Opacity = 0.5;
            }
        }
        private void Image_Pocion_De_Energia_Izquierda_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            if (ProgressBar_Energia_Izquierda.Value > 0)
            {
                dtTimeEnergiaIzquierda = new DispatcherTimer();
                dtTimeEnergiaIzquierda.Interval = TimeSpan.FromMilliseconds(10); // Esto lo he cambiado para que se vea más fluido, deberia ser 100 milisegundos
                dtTimeEnergiaIzquierda.Tick += aumentarEnergiaIzquierda;
                dtTimeEnergiaIzquierda.Start();
                this.Image_Pocion_De_Energia_Izquierda.Opacity = 0.5;
            }
        }
        private void Image_Pocion_De_Vida_Derecha_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            if (ProgressBar_Vida_Derecha.Value > 0)
            {
                dtTimeVidaDerecha = new DispatcherTimer();
                dtTimeVidaDerecha.Interval = TimeSpan.FromMilliseconds(10); // Esto lo he cambiado para que se vea más fluido, deberia ser 100 milisegundos
                dtTimeVidaDerecha.Tick += aumentarVidaDerecha;
                dtTimeVidaDerecha.Start();
                this.Image_Pocion_De_Vida_Derecha.Opacity = 0.5;
            }
        }
        private void Image_Pocion_De_Energia_Derecha_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            if (ProgressBar_Energia_Derecha.Value > 0)
            {
                dtTimeEnergiaDerecha = new DispatcherTimer();
                dtTimeEnergiaDerecha.Interval = TimeSpan.FromMilliseconds(10); // Esto lo he cambiado para que se vea más fluido, deberia ser 100 milisegundos
                dtTimeEnergiaDerecha.Tick += aumentarEnergiaDerecha;
                dtTimeEnergiaDerecha.Start();
                this.Image_Pocion_De_Energia_Derecha.Opacity = 0.5;
            }
        }

        /************************************************************************************************/

        /*Metodos funcionales en la pagina*/
        protected override void OnNavigatedTo(NavigationEventArgs e) // Terminado
        {
            base.OnNavigatedTo(e);
            Padre = (Escenario_CombatePage)e.Parameter;
            PokemonJugador1 = Padre.PokemonJugador1;
            PokemonJugador2 = Padre.PokemonJugador2;
            ImgFondo_Pokemons.Source = Padre.Fondo.Source;
        }
        private async Task EsperarBotonPresionado() // Terminado
        {
            while (!Boton_presionado)
            {
                await Task.Delay(100); //espera 100 milisegundos antes de verificar la variable de nuevo
            }
        }
        public async void cicloCombate() // Terminado
        {
            // Ciclo del combate
            while (ProgressBar_Vida_Derecha.Value > 0 && ProgressBar_Vida_Izquierda.Value > 0)
            {
                if (accionPokemon1 == true)
                {
                    TextBlock_TurnoDelJugador.Text = "Turno del jugador 1: " + PokemonJugador1;
                }
                else if (accionPokemon2 == true)
                {
                    TextBlock_TurnoDelJugador.Text = "Turno del jugador 2: " + PokemonJugador2;
                }

                // Espera a que se presione uno de los ataques disponibles
                await EsperarBotonPresionado();
                Boton_presionado = false;
                estadoBotones(false);

                // Espera de 5 segundos a que se realicen correctamente todos los ataques
                await Task.Delay(5000);
                TextBlock_MensajeCombate.Text = "";
                estadoBotones(true);

                if (accionPokemon1 == true)
                {
                    cambiarNombresBotones(PokemonJugador2);
                    accionPokemon1 = false;
                    accionPokemon2 = true;
                }
                else if (accionPokemon2 == true)
                {
                    cambiarNombresBotones(PokemonJugador1);
                    accionPokemon2 = false;
                    accionPokemon1 = true;
                }
            }
        }

        /************************************************************************************************/

        /*Metodos Auxiliares*/

        /*public void realizarAtaque1() // Terminado
        {
            if (accionPokemon1 == true)// Pokemons de la Derecha
            {
                switch (PokemonJugador1)
                {
                    case "Sandshrew":
                        UserControl_Sandshrew_Derecha_P1.realizarAtaque1();
                        break;

                    case "Snorlax":
                        UserControl_Snorlax_Derecha_P1.realizarAtaque1();
                        break;

                    case "Darumaka":
                        UserControl_Darumaka_Derecha_P1.realizarAtaque1();
                        break;

                    case "Raichu":
                        UserControl_Raichu_Derecha_P1.realizarAtaque1();
                        break;
                }
            }
            else if (accionPokemon2 == true) // Izquierda
            {
                switch (PokemonJugador2)
                {
                    case "Sandshrew":
                        UserControl_Sandshrew_Izquierda_P2_IA.realizarAtaque1();
                        break;

                    case "Snorlax":
                        UserControl_Snorlax_Izquierda_P2_IA.realizarAtaque1();
                        break;

                    case "Darumaka":
                        UserControl_Darumaka_Izquierda_P2_IA.realizarAtaque1();
                        break;

                    case "Raichu":
                        UserControl_Raichu_Izquierda_P2_IA.realizarAtaque1();
                        break;
                }
            }
        }
        public void realizarAtaque2() // Terminado
        {
            if (accionPokemon1 == true)// Pokemons de la Derecha
            {
                switch (PokemonJugador1)
                {
                    case "Sandshrew":
                        UserControl_Sandshrew_Derecha_P1.realizarAtaque2();
                        break;

                    case "Snorlax":
                        UserControl_Snorlax_Derecha_P1.realizarAtaque2();
                        break;

                    case "Darumaka":
                        UserControl_Darumaka_Derecha_P1.realizarAtaque2();
                        break;

                    case "Raichu":
                        UserControl_Raichu_Derecha_P1.realizarAtaque2();
                        break;
                }
            }
            else if (accionPokemon2 == true) // Izquierda
            {
                switch (PokemonJugador2)
                {
                    case "Sandshrew":
                        UserControl_Sandshrew_Izquierda_P2_IA.realizarAtaque2();
                        break;

                    case "Snorlax":
                        UserControl_Snorlax_Izquierda_P2_IA.realizarAtaque2();
                        break;

                    case "Darumaka":
                        UserControl_Darumaka_Izquierda_P2_IA.realizarAtaque2();
                        break;

                    case "Raichu":
                        UserControl_Raichu_Izquierda_P2_IA.realizarAtaque2();
                        break;
                }
            }
        }
        public void realizarAtaque3() // Terminado
        {
            if (accionPokemon1 == true)// Pokemons de la Derecha
            {
                switch (PokemonJugador1)
                {
                    case "Sandshrew":
                        UserControl_Sandshrew_Derecha_P1.realizarAtaque3();
                        break;

                    case "Snorlax":
                        UserControl_Snorlax_Derecha_P1.realizarAtaque3();
                        break;

                    case "Darumaka":
                        UserControl_Darumaka_Derecha_P1.realizarAtaque3();
                        break;

                    case "Raichu":
                        UserControl_Raichu_Derecha_P1.realizarAtaque3();
                        break;
                }
            }
            else if (accionPokemon2 == true) // Izquierda
            {
                switch (PokemonJugador2)
                {
                    case "Sandshrew":
                        UserControl_Sandshrew_Izquierda_P2_IA.realizarAtaque3();
                        break;

                    case "Snorlax":
                        UserControl_Snorlax_Izquierda_P2_IA.realizarAtaque3();
                        break;

                    case "Darumaka":
                        UserControl_Darumaka_Izquierda_P2_IA.realizarAtaque3();
                        break;

                    case "Raichu":
                        UserControl_Raichu_Izquierda_P2_IA.realizarAtaque3();
                        break;
                }
            }
        }
        public void realizarAtaque4() // Terminado
        {
            if (accionPokemon1 == true)// Pokemons de la Derecha
            {
                switch (PokemonJugador1)
                {
                    case "Sandshrew":
                        UserControl_Sandshrew_Derecha_P1.realizarAtaque4();
                        break;

                    case "Snorlax":
                        UserControl_Snorlax_Derecha_P1.realizarAtaque4();
                        break;

                    case "Darumaka":
                        UserControl_Darumaka_Derecha_P1.realizarAtaque4();
                        break;

                    case "Raichu":
                        UserControl_Raichu_Derecha_P1.realizarAtaque4();
                        break;
                }
            }
            else if (accionPokemon2 == true) // Izquierda
            {
                switch (PokemonJugador2)
                {
                    case "Sandshrew":
                        UserControl_Sandshrew_Izquierda_P2_IA.realizarAtaque4();
                        break;

                    case "Snorlax":
                        UserControl_Snorlax_Izquierda_P2_IA.realizarAtaque4();
                        break;

                    case "Darumaka":
                        UserControl_Darumaka_Izquierda_P2_IA.realizarAtaque4();
                        break;

                    case "Raichu":
                        UserControl_Raichu_Izquierda_P2_IA.realizarAtaque4();
                        break;
                }
            }
        }*/
        public void notificarAtaqueTrasPulsarBoton(Button btn) // Terminado
        {
            Boton_presionado = true;
            if (accionPokemon1 == true)
            {
                TextBlock_MensajeCombate.Text = PokemonJugador1 + " ha utilizando el ataque " + btn.Content;
            }
            else if (accionPokemon2 == true)
            {
                TextBlock_MensajeCombate.Text = PokemonJugador2 + " ha utilizando el ataque " + btn.Content;
            }
        }
        public void cambiarNombresBotones(String NombreDelPokemon) // Terminado
        {
            switch (NombreDelPokemon)
            {
                case "Sandshrew":
                    Btn_Ataque1.Content = UserControl_Sandshrew_Derecha_P1.nombreAtaque1;
                    Btn_Ataque2.Content = UserControl_Sandshrew_Derecha_P1.nombreAtaque2;
                    Btn_Ataque3.Content = UserControl_Sandshrew_Derecha_P1.nombreAtaque3;
                    Btn_Ataque4.Content = UserControl_Sandshrew_Derecha_P1.nombreAtaque4;
                    break;

                case "Snorlax":
                    Btn_Ataque1.Content = UserControl_Snorlax_Derecha_P1.nombreAtaque1;
                    Btn_Ataque2.Content = UserControl_Snorlax_Derecha_P1.nombreAtaque2;
                    Btn_Ataque3.Content = UserControl_Snorlax_Derecha_P1.nombreAtaque3;
                    Btn_Ataque4.Content = UserControl_Snorlax_Derecha_P1.nombreAtaque4;
                    break;

                case "Darumaka":
                    Btn_Ataque1.Content = UserControl_Darumaka_Derecha_P1.nombreAtaque1;
                    Btn_Ataque2.Content = UserControl_Darumaka_Derecha_P1.nombreAtaque2;
                    Btn_Ataque3.Content = UserControl_Darumaka_Derecha_P1.nombreAtaque3;
                    Btn_Ataque4.Content = UserControl_Darumaka_Derecha_P1.nombreAtaque4;
                    break;

                case "Raichu":
                    Btn_Ataque1.Content = UserControl_Raichu_Derecha_P1.nombreAtaque1;
                    Btn_Ataque2.Content = UserControl_Raichu_Derecha_P1.nombreAtaque2;
                    Btn_Ataque3.Content = UserControl_Raichu_Derecha_P1.nombreAtaque3;
                    Btn_Ataque4.Content = UserControl_Raichu_Derecha_P1.nombreAtaque4;
                    break;
            }
        }
        public void crearPokemonsIniciales() // Terminado
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
            else if(ladoDelCampo.Equals("I"))
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
        public void estadoBotones(Boolean estado) // Terminado
        {
            Btn_Ataque1.IsEnabled = estado;
            Btn_Ataque2.IsEnabled = estado;
            Btn_Ataque3.IsEnabled = estado;
            Btn_Ataque4.IsEnabled = estado;
        }
        private void aumentarVidaIzquierda(object sender, object e) // Terminado
        {
            this.ProgressBar_Vida_Izquierda.Value += 0.2;
            if (ProgressBar_Vida_Izquierda.Value >= 100)
            {
                this.dtTimeVidaIzquierda.Stop();
                this.Image_Pocion_De_Vida_Izquierda.Opacity = 0;
            }
        }
        private void aumentarEnergiaIzquierda(object sender, object e) // Terminado
        {
            this.ProgressBar_Energia_Izquierda.Value += 0.2;
            if (ProgressBar_Energia_Izquierda.Value >= 100)
            {
                this.dtTimeEnergiaIzquierda.Stop();
                this.Image_Pocion_De_Energia_Izquierda.Opacity = 1;
            }
        }
        private void aumentarVidaDerecha(object sender, object e) // Terminado
        {
            this.ProgressBar_Vida_Derecha.Value += 0.2;
            if (ProgressBar_Vida_Derecha.Value >= 100)
            {
                this.dtTimeVidaDerecha.Stop();
                this.Image_Pocion_De_Vida_Derecha.Opacity = 0;
            }
        }
        private void aumentarEnergiaDerecha(object sender, object e) // Terminado
        {
            this.ProgressBar_Energia_Derecha.Value += 0.2;
            if (ProgressBar_Energia_Derecha.Value >= 100)
            {
                this.dtTimeEnergiaDerecha.Stop();
                this.Image_Pocion_De_Energia_Derecha.Opacity = 1;
            }
        }

    }
}
