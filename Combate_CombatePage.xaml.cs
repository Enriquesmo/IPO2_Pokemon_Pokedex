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
using Windows.UI.Xaml.Media.Imaging;
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

        public double vidaNueva;
        public double energiaNueva;
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

        private void Btn_Ataque1_Click(object sender, RoutedEventArgs e) // Terminado
        {
            notificarAtaqueTrasPulsarBoton(Btn_Ataque1);
            realizarAtaque(1);
        }
        private void Btn_Ataque2_Click(object sender, RoutedEventArgs e) // Terminado
        {
            notificarAtaqueTrasPulsarBoton(Btn_Ataque2);
            realizarAtaque(2);
        }
        private void Btn_Ataque3_Click(object sender, RoutedEventArgs e) // Terminado
        {
            notificarAtaqueTrasPulsarBoton(Btn_Ataque3);
            realizarAtaque(3);
        }
        private void Btn_Ataque4_Click(object sender, RoutedEventArgs e) // Terminado
        {
            notificarAtaqueTrasPulsarBoton(Btn_Ataque4);
            realizarAtaque(4);
        }
        private void btn_EmpezarCombate_Click(object sender, RoutedEventArgs e) // Terminado
        {
            ImgFondo_Pokemons = Fondo;
            btn_EmpezarCombate.IsEnabled = false;
            btn_EmpezarCombate.Visibility = Visibility.Collapsed;
            estadoBotones(true);
            cambiarNombresBotones(PokemonJugador1);
            crearPokemonsIniciales();
            cicloCombate();
        }
        private void Image_Pocion_De_Vida_Izquierda_PointerReleased(object sender, PointerRoutedEventArgs e) // Terminado
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
        private void Image_Pocion_De_Energia_Izquierda_PointerReleased(object sender, PointerRoutedEventArgs e) // Terminado
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
        private void Image_Pocion_De_Vida_Derecha_PointerReleased(object sender, PointerRoutedEventArgs e) // Terminado
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
        private void Image_Pocion_De_Energia_Derecha_PointerReleased(object sender, PointerRoutedEventArgs e) // Terminado
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
            modo_de_juego = Padre.modo_de_juego;
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
                    ImgFondo_Botones.Source = new BitmapImage(new Uri("ms-appx:///Assets/fondo_movimientos1.jpg"));
                }
                else if (accionPokemon2 == true)
                {
                    TextBlock_TurnoDelJugador.Text = "Turno del jugador 2: " + PokemonJugador2;
                    ImgFondo_Botones.Source = new BitmapImage(new Uri("ms-appx:///Assets/fondo_movimientos2.jpg"));
                }

                // Si se está en modo P1 vs IA, se elige un ataque aleatorio para el Jugador 2, es decir, la IA
                if (modo_de_juego == "IA" && accionPokemon2 == true)
                {
                    estadoBotones(false);
                    await Task.Delay(1000);
                    Random ataqueAleatorio = new Random();
                    int numeroAleatorio = ataqueAleatorio.Next(1, 5);
                    switch (numeroAleatorio) {
                        case 1:
                            Btn_Ataque1_Click(null, null);
                            break;
                        case 2:
                            Btn_Ataque2_Click(null, null);
                            break;
                        case 3:
                            Btn_Ataque3_Click(null, null);
                            break;
                        case 4:
                            Btn_Ataque4_Click(null, null);
                            break;
                    }
                }
                // Espera a que se presione uno de los ataques disponibles
                await EsperarBotonPresionado();
                Boton_presionado = false;
                estadoBotones(false);

                // Espera de 8 segundos a que se realicen correctamente todos los ataques
                await Task.Delay(8000);
                TextBlock_MensajeCombate.Text = "";
                estadoBotones(true);

                if (accionPokemon1 == true)
                {
                    // Cambiamos de turno al del Pokemon del Jugador2
                    cambiarNombresBotones(PokemonJugador2);
                    accionPokemon1 = false;
                    accionPokemon2 = true;
                }
                else if (accionPokemon2 == true)
                {
                    // Cambiamos de turno al del Pokemon del Jugador1
                    cambiarNombresBotones(PokemonJugador1);
                    accionPokemon1 = true;
                    accionPokemon2 = false;
                }
                // Tras realizar el ataque, actualizamos los valores de vida y energia de los pokemon
                actualizarVidaYEnergia();
            }
            // Aqui el combate ha terminado
            estadoBotones(false);
            PonerResultado();
        }

        /************************************************************************************************/

        /*Metodos Auxiliares*/

        public void realizarAtaque(int numeroDeAtaque) // Terminado
        {
            if (accionPokemon1 == true)// Pokemons de la Derecha
            {
                switch (PokemonJugador1)
                {
                    case "Sandshrew":
                        if(numeroDeAtaque == 1)
                        {
                            UserControl_Sandshrew_Derecha_P1.realizarAtaque1();
                            restarEnergia(UserControl_Sandshrew_Derecha_P1.energiaAtaque1);
                            restarVida(UserControl_Sandshrew_Derecha_P1.danoAtaque1);
                        }
                        else if (numeroDeAtaque == 2)
                        {
                            UserControl_Sandshrew_Derecha_P1.realizarAtaque2();
                            restarEnergia(UserControl_Sandshrew_Derecha_P1.energiaAtaque2);
                            restarVida(UserControl_Sandshrew_Derecha_P1.danoAtaque2);
                        }
                        else if (numeroDeAtaque == 3)
                        {
                            UserControl_Sandshrew_Derecha_P1.realizarAtaque3();
                            restarEnergia(UserControl_Sandshrew_Derecha_P1.energiaAtaque3);
                            restarVida(UserControl_Sandshrew_Derecha_P1.danoAtaque3);
                        }
                        else if (numeroDeAtaque == 4)
                        {
                            UserControl_Sandshrew_Derecha_P1.realizarAtaque4();
                            restarEnergia(UserControl_Sandshrew_Derecha_P1.energiaAtaque4);
                            restarVida(UserControl_Sandshrew_Derecha_P1.danoAtaque4);
                        }
                        break;
                    case "Snorlax":
                        if (numeroDeAtaque == 1)
                        {
                            UserControl_Snorlax_Derecha_P1.realizarAtaque1();
                            restarEnergia(UserControl_Snorlax_Derecha_P1.energiaAtaque1);
                            restarVida(UserControl_Snorlax_Derecha_P1.danoAtaque1);
                        }
                        else if (numeroDeAtaque == 2)
                        {
                            UserControl_Snorlax_Derecha_P1.realizarAtaque2();
                            restarEnergia(UserControl_Snorlax_Derecha_P1.energiaAtaque2);
                            restarVida(UserControl_Snorlax_Derecha_P1.danoAtaque2);
                        }
                        else if (numeroDeAtaque == 3)
                        {
                            UserControl_Snorlax_Derecha_P1.realizarAtaque3();
                            restarEnergia(UserControl_Snorlax_Derecha_P1.energiaAtaque3);
                            restarVida(UserControl_Snorlax_Derecha_P1.danoAtaque3);
                        }
                        else if (numeroDeAtaque == 4)
                        {
                            UserControl_Snorlax_Derecha_P1.realizarAtaque4();
                            restarEnergia(UserControl_Snorlax_Derecha_P1.energiaAtaque4);
                            restarVida(UserControl_Snorlax_Derecha_P1.danoAtaque4);
                        }
                        break;
                    case "Darumaka":
                        if (numeroDeAtaque == 1)
                        {
                            UserControl_Darumaka_Derecha_P1.realizarAtaque1();
                            restarEnergia(UserControl_Darumaka_Derecha_P1.energiaAtaque1);
                            restarVida(UserControl_Darumaka_Derecha_P1.danoAtaque1);
                        }
                        else if (numeroDeAtaque == 2)
                        {
                            UserControl_Darumaka_Derecha_P1.realizarAtaque2();
                            restarEnergia(UserControl_Darumaka_Derecha_P1.energiaAtaque2);
                            restarVida(UserControl_Darumaka_Derecha_P1.danoAtaque2);
                        }
                        else if (numeroDeAtaque == 3)
                        {
                            UserControl_Darumaka_Derecha_P1.realizarAtaque3();
                            restarEnergia(UserControl_Darumaka_Derecha_P1.energiaAtaque3);
                            restarVida(UserControl_Darumaka_Derecha_P1.danoAtaque3);
                        }
                        else if (numeroDeAtaque == 4)
                        {
                            UserControl_Darumaka_Derecha_P1.realizarAtaque4();
                            restarEnergia(UserControl_Darumaka_Derecha_P1.energiaAtaque4);
                            restarVida(UserControl_Darumaka_Derecha_P1.danoAtaque4);
                        }
                        break;

                    case "Raichu":
                        if (numeroDeAtaque == 1)
                        {
                            UserControl_Raichu_Derecha_P1.realizarAtaque1();
                            restarEnergia(UserControl_Raichu_Derecha_P1.energiaAtaque1);
                            restarVida(UserControl_Raichu_Derecha_P1.danoAtaque1);
                        }
                        else if (numeroDeAtaque == 2)
                        {
                            UserControl_Raichu_Derecha_P1.realizarAtaque2();
                            restarEnergia(UserControl_Raichu_Derecha_P1.energiaAtaque2);
                            restarVida(UserControl_Raichu_Derecha_P1.danoAtaque2);
                        }
                        else if (numeroDeAtaque == 3)
                        {
                            UserControl_Raichu_Derecha_P1.realizarAtaque3();
                            restarEnergia(UserControl_Raichu_Derecha_P1.energiaAtaque3);
                            restarVida(UserControl_Raichu_Derecha_P1.danoAtaque3);
                        }
                        else if (numeroDeAtaque == 4)
                        {
                            UserControl_Raichu_Derecha_P1.realizarAtaque4();
                            restarEnergia(UserControl_Raichu_Derecha_P1.energiaAtaque4);
                            restarVida(UserControl_Raichu_Derecha_P1.danoAtaque4);
                        }

                        break;
                }
            }
            if (accionPokemon2 == true) // Izquierda
            {
                switch (PokemonJugador2)
                {
                    case "Sandshrew":
                        if (numeroDeAtaque == 1)
                        {
                            UserControl_Sandshrew_Izquierda_P2_IA.realizarAtaque1();
                            restarEnergia(UserControl_Sandshrew_Izquierda_P2_IA.energiaAtaque1);
                            restarVida(UserControl_Sandshrew_Izquierda_P2_IA.danoAtaque1);
                        }
                        else if (numeroDeAtaque == 2)
                        {
                            UserControl_Sandshrew_Izquierda_P2_IA.realizarAtaque2();
                            restarEnergia(UserControl_Sandshrew_Izquierda_P2_IA.energiaAtaque2);
                            restarVida(UserControl_Sandshrew_Izquierda_P2_IA.danoAtaque2);
                        }
                        else if (numeroDeAtaque == 3)
                        {
                            UserControl_Sandshrew_Izquierda_P2_IA.realizarAtaque3();
                            restarEnergia(UserControl_Sandshrew_Izquierda_P2_IA.energiaAtaque3);
                            restarVida(UserControl_Sandshrew_Izquierda_P2_IA.danoAtaque3);
                        }
                        else if (numeroDeAtaque == 4)
                        {
                            UserControl_Sandshrew_Izquierda_P2_IA.realizarAtaque4();
                            restarEnergia(UserControl_Sandshrew_Izquierda_P2_IA.energiaAtaque4);
                            restarVida(UserControl_Sandshrew_Izquierda_P2_IA.danoAtaque4);
                        }
                        break;
                    case "Snorlax":
                        if (numeroDeAtaque == 1)
                        {
                            UserControl_Snorlax_Izquierda_P2_IA.realizarAtaque1();
                            restarEnergia(UserControl_Snorlax_Izquierda_P2_IA.energiaAtaque1);
                            restarVida(UserControl_Snorlax_Izquierda_P2_IA.danoAtaque1);
                        }
                        else if (numeroDeAtaque == 2)
                        {
                            UserControl_Snorlax_Izquierda_P2_IA.realizarAtaque2();
                            restarEnergia(UserControl_Snorlax_Izquierda_P2_IA.energiaAtaque2);
                            restarVida(UserControl_Snorlax_Izquierda_P2_IA.danoAtaque2);
                        }
                        else if (numeroDeAtaque == 3)
                        {
                            UserControl_Snorlax_Izquierda_P2_IA.realizarAtaque3();
                            restarEnergia(UserControl_Snorlax_Izquierda_P2_IA.energiaAtaque3);
                            restarVida(UserControl_Snorlax_Izquierda_P2_IA.danoAtaque3);
                        }
                        else if (numeroDeAtaque == 4)
                        {
                            UserControl_Snorlax_Izquierda_P2_IA.realizarAtaque4();
                            restarEnergia(UserControl_Snorlax_Izquierda_P2_IA.energiaAtaque4);
                            restarVida(UserControl_Snorlax_Izquierda_P2_IA.danoAtaque4);
                        }
                        break;
                    case "Darumaka":
                        if (numeroDeAtaque == 1)
                        {
                            UserControl_Darumaka_Izquierda_P2_IA.realizarAtaque1();
                            restarEnergia(UserControl_Darumaka_Izquierda_P2_IA.energiaAtaque1);
                            restarVida(UserControl_Darumaka_Izquierda_P2_IA.danoAtaque1);
                        }
                        else if (numeroDeAtaque == 2)
                        {
                            UserControl_Darumaka_Izquierda_P2_IA.realizarAtaque2();
                            restarEnergia(UserControl_Darumaka_Izquierda_P2_IA.energiaAtaque2);
                            restarVida(UserControl_Darumaka_Izquierda_P2_IA.danoAtaque2);
                        }
                        else if (numeroDeAtaque == 3)
                        {
                            UserControl_Darumaka_Izquierda_P2_IA.realizarAtaque3();
                            restarEnergia(UserControl_Darumaka_Izquierda_P2_IA.energiaAtaque3);
                            restarVida(UserControl_Darumaka_Izquierda_P2_IA.danoAtaque3);
                        }
                        else if (numeroDeAtaque == 4)
                        {
                            UserControl_Darumaka_Izquierda_P2_IA.realizarAtaque4();
                            restarEnergia(UserControl_Darumaka_Izquierda_P2_IA.energiaAtaque4);
                            restarVida(UserControl_Darumaka_Izquierda_P2_IA.danoAtaque4);
                        }
                        break;

                    case "Raichu":
                        if (numeroDeAtaque == 1)
                        {
                            UserControl_Raichu_Izquierda_P2_IA.realizarAtaque1();
                            restarEnergia(UserControl_Raichu_Izquierda_P2_IA.energiaAtaque1);
                            restarVida(UserControl_Raichu_Izquierda_P2_IA.danoAtaque1);
                        }
                        else if (numeroDeAtaque == 2)
                        {
                            UserControl_Raichu_Izquierda_P2_IA.realizarAtaque2();
                            restarEnergia(UserControl_Raichu_Izquierda_P2_IA.energiaAtaque2);
                            restarVida(UserControl_Raichu_Izquierda_P2_IA.danoAtaque2);
                        }
                        else if (numeroDeAtaque == 3)
                        {
                            UserControl_Raichu_Izquierda_P2_IA.realizarAtaque3();
                            restarEnergia(UserControl_Raichu_Izquierda_P2_IA.energiaAtaque3);
                            restarVida(UserControl_Raichu_Izquierda_P2_IA.danoAtaque3);
                        }
                        else if (numeroDeAtaque == 4)
                        {
                            UserControl_Raichu_Izquierda_P2_IA.realizarAtaque4();
                            restarEnergia(UserControl_Raichu_Izquierda_P2_IA.energiaAtaque4);
                            restarVida(UserControl_Raichu_Izquierda_P2_IA.danoAtaque4);
                        }
                        break;
                }
            }
        }
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
            Image_LooserDerecha.Visibility = Visibility.Collapsed;
            Image_WinnerIzquierda.Visibility = Visibility.Collapsed;
            Image_WinnerDerecha.Visibility = Visibility.Collapsed;
            Image_LooserIzquierda.Visibility = Visibility.Collapsed;
        }
        public void comprobarDarumaka(String ladoDelCampo) // Terminado
        {
            if (ladoDelCampo.Equals("D"))
            {
                UserControl_Darumaka_Derecha_P1.IsEnabled = true;
                UserControl_Darumaka_Derecha_P1.Visibility = Visibility.Visible;
                UserControl_Darumaka_Derecha_P1.Vida = ProgressBar_Vida_Derecha.Value;
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
        public void restarEnergia(double valor) // Terminado
        {
            if (accionPokemon1 == true)
            {
                dtTimeEnergiaDerecha = new DispatcherTimer();
                energiaNueva = ProgressBar_Energia_Derecha.Value - valor;
                dtTimeEnergiaDerecha.Interval = TimeSpan.FromMilliseconds(1);
                dtTimeEnergiaDerecha.Tick += DisminuirEnergiaDerecha;
                dtTimeEnergiaDerecha.Start();
            }
            else if (accionPokemon2 == true)
            {
                dtTimeEnergiaIzquierda = new DispatcherTimer();
                energiaNueva = ProgressBar_Energia_Izquierda.Value - valor;
                dtTimeEnergiaIzquierda.Interval = TimeSpan.FromMilliseconds(1);
                dtTimeEnergiaIzquierda.Tick += DisminuirEnergiaIzquierda;
                dtTimeEnergiaIzquierda.Start();
            }
        }
        public void restarVida(double valor) // Terminado
        {
            if (accionPokemon1 == true)
            {
                dtTimeVidaIzquierda = new DispatcherTimer();
                vidaNueva = ProgressBar_Vida_Izquierda.Value - valor;
                dtTimeVidaIzquierda.Interval = TimeSpan.FromMilliseconds(1);
                dtTimeVidaIzquierda.Tick += DisminuirVidaIzquierda;
                dtTimeVidaIzquierda.Start();
            }
            else if (accionPokemon2 == true)
            {
                dtTimeVidaDerecha = new DispatcherTimer();
                vidaNueva = ProgressBar_Vida_Derecha.Value - valor;
                dtTimeVidaDerecha.Interval = TimeSpan.FromMilliseconds(1);
                dtTimeVidaDerecha.Tick += DisminuirVidaDerecha;
                dtTimeVidaDerecha.Start();
            }
        }
        public void actualizarVidaYEnergia() // Terminado
        {
            // Condicionales para poder actualizar el pokemon elegido por el P1
            switch (PokemonJugador1)
            {
                case "Sandshrew":
                    actualizarSandshrew("D");
                    break;

                case "Snorlax":
                    actualizarSnorlax("D");
                    break;

                case "Darumaka":
                    actualizarDarumaka("D");
                    break;

                case "Raichu":
                    actualizarRaichu("D");
                    break;
            }

            // Condicionales para poder actualizar el pokemon elegido por la IA o el P2
            switch (PokemonJugador2)
            {
                case "Sandshrew":
                    actualizarSandshrew("I");
                    break;

                case "Snorlax":
                    actualizarSnorlax("I");
                    break;

                case "Darumaka":
                    actualizarDarumaka("I");
                    break;

                case "Raichu":
                    actualizarRaichu("I");
                    break;
            }
        }
        public void actualizarDarumaka(String ladoDelCampo) // Terminado
        {
            if (ladoDelCampo.Equals("D"))
            {
                UserControl_Darumaka_Derecha_P1.Vida = ProgressBar_Vida_Derecha.Value;
                UserControl_Darumaka_Derecha_P1.Energia = ProgressBar_Energia_Derecha.Value;
            }
            else if (ladoDelCampo.Equals("I"))
            {
                UserControl_Darumaka_Izquierda_P2_IA.Vida = ProgressBar_Vida_Izquierda.Value;
                UserControl_Darumaka_Izquierda_P2_IA.Energia = ProgressBar_Energia_Izquierda.Value;
            }
        }
        public void actualizarSandshrew(String ladoDelCampo) // Terminado
        {
            if (ladoDelCampo.Equals("D"))
            {
                UserControl_Sandshrew_Derecha_P1.Vida = ProgressBar_Vida_Derecha.Value;
                UserControl_Sandshrew_Derecha_P1.Energia = ProgressBar_Energia_Derecha.Value;
            }
            else if (ladoDelCampo.Equals("I"))
            {
                UserControl_Sandshrew_Izquierda_P2_IA.Vida = ProgressBar_Vida_Izquierda.Value;
                UserControl_Sandshrew_Izquierda_P2_IA.Energia = ProgressBar_Energia_Izquierda.Value;
            }
        }
        public void actualizarSnorlax(String ladoDelCampo) // Terminado
        {
            if (ladoDelCampo.Equals("D"))
            {
                UserControl_Snorlax_Derecha_P1.Vida = ProgressBar_Vida_Derecha.Value;
                UserControl_Snorlax_Derecha_P1.Energia = ProgressBar_Energia_Derecha.Value;
            }
            else if (ladoDelCampo.Equals("I"))
            {
                UserControl_Snorlax_Izquierda_P2_IA.Vida = ProgressBar_Vida_Izquierda.Value;
                UserControl_Snorlax_Izquierda_P2_IA.Energia = ProgressBar_Energia_Izquierda.Value;
            }
        }
        public void actualizarRaichu(String ladoDelCampo) // Terminado
        {
            if (ladoDelCampo.Equals("D"))
            {
                UserControl_Raichu_Derecha_P1.Vida = ProgressBar_Vida_Derecha.Value;
                UserControl_Raichu_Derecha_P1.Energia = ProgressBar_Energia_Derecha.Value;
            }
            else if (ladoDelCampo.Equals("I"))
            {
                UserControl_Raichu_Izquierda_P2_IA.Vida = ProgressBar_Vida_Izquierda.Value;
                UserControl_Raichu_Izquierda_P2_IA.Energia = ProgressBar_Energia_Izquierda.Value;
            }
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
        private void DisminuirVidaIzquierda(object sender, object e) // Terminado
        {
            this.ProgressBar_Vida_Izquierda.Value -= 0.4;
            if (ProgressBar_Vida_Izquierda.Value <= vidaNueva)
            {
                this.dtTimeVidaIzquierda.Stop();
            }
        }
        private void DisminuirEnergiaIzquierda(object sender, object e) // Terminado
        {
            this.ProgressBar_Energia_Izquierda.Value -= 0.4;
            if (ProgressBar_Energia_Izquierda.Value <= energiaNueva)
            {
                this.dtTimeEnergiaIzquierda.Stop();
            }
        }
        private void DisminuirVidaDerecha(object sender, object e) // Terminado
        {
            this.ProgressBar_Vida_Derecha.Value -= 0.4;
            if (ProgressBar_Vida_Derecha.Value <= vidaNueva)
            {
                this.dtTimeVidaDerecha.Stop();
            }
        }
        private void DisminuirEnergiaDerecha(object sender, object e) // Terminado
        {
            this.ProgressBar_Energia_Derecha.Value -= 0.4;
            if (ProgressBar_Energia_Derecha.Value <= energiaNueva)
            {
                this.dtTimeEnergiaDerecha.Stop();
            }
        }
        private void PonerResultado() // Terminado
        {
            if (ProgressBar_Vida_Derecha.Value <= 0)
            {
                Image_LooserDerecha.Visibility = Visibility.Visible;
                Image_WinnerIzquierda.Visibility = Visibility.Visible;
            }
            else if (ProgressBar_Vida_Izquierda.Value <= 0)
            {
                Image_WinnerDerecha.Visibility = Visibility.Visible;
                Image_LooserIzquierda.Visibility = Visibility.Visible;
            }
        }
    }
}
