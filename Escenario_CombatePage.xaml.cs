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

        /*Inicializacion de la pagina CombatePage*/
        public Escenario_CombatePage()
        {
            this.InitializeComponent();
        }

        /************************************************************************************************/

        /*Botones de la propia pagina*/
        private void Ir_A_La_Siguiente_Pagina_Click(object sender, RoutedEventArgs e)
        {
            // Boton que sirve para poder pasar al combate pokemon en si
            Frame CombateFrame = (Frame)this.Parent;
            CombateFrame.Navigate(typeof(Combate_CombatePage), this);
        }

        private void Click_CambiarEscenario(object sender, RoutedEventArgs e)
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

        protected override void OnNavigatedTo(NavigationEventArgs e)
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
