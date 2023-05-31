using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace IPO2_Pokemon_Pokedex
{
    /// <summary>
    /// Página dedicada a la seleccion del escenario del combate pokemon.
    /// 
    /// Proyecto realizado por:
    /// Enrique Sánchez-Migallón Ochoa
    /// Javier Santos Sanz
    /// Alonso Crespo Fernández
    /// Felipe Alcázar Gómez
    /// </summary>

    public sealed partial class Escenario_CombatePage : Page
    {
        /************************************************************************************************/

        /*Inicializacion de las variables globales*/

        public String PokemonJugador1;
        public String PokemonJugador2;
        public string modo_de_juego;
        Seleccion_CombatePage Padre;
        public Image Fondo;

        /************************************************************************************************/

        /*Inicializacion de la pagina Escenario_CombatePage*/

        public Escenario_CombatePage() // Terminado
        {
            this.InitializeComponent();
        }

        /************************************************************************************************/

        /*Botones de la propia pagina*/

        private void Ir_A_La_Siguiente_Pagina_Click(object sender, RoutedEventArgs e) // Terminado
        {
            // Boton que sirve para poder pasar al combate pokemon en si
            Frame CombateFrame = (Frame)this.Parent;
            CombateFrame.Navigate(typeof(Combate_CombatePage), this);
        }
        private void Click_CambiarEscenario(object sender, RoutedEventArgs e) // Terminado
        {
            // Boton que sirve para que, cuando se pulse un boton de los de abajo, poder cambiar el escenario y mostrarlo arriba
            Button BotonConFondo = sender as Button;
            Image FondoSelecionado = BotonConFondo.Content as Image;
            Img_Ejemplo.Source = FondoSelecionado.Source;
            Ir_A_La_Siguiente_Pagina.IsEnabled = true;
            Fondo = FondoSelecionado;
        }

        /************************************************************************************************/

        /*Metodos funcionales en la pagina*/

        protected override void OnNavigatedTo(NavigationEventArgs e) // Terminado
        {
            // Metodo que sirve para heredar atributos de la page anterior
            base.OnNavigatedTo(e);
            Padre = (Seleccion_CombatePage)e.Parameter;
            PokemonJugador1 = Padre.PokemonJugador1;
            PokemonJugador2 = Padre.PokemonJugador2;
            modo_de_juego = Padre.modo_de_juego;
        }

        /************************************************************************************************/

        /*Metodos Auxiliares*/

    }
}
