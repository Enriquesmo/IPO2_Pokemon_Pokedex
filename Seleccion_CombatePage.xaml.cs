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
        public String modo_de_juego;
        CombatePage Padre;


        /************************************************************************************************/

        /*Inicializacion de la pagina CombatePage*/
        public Seleccion_CombatePage()
        {
            this.InitializeComponent();
            UC_Pokemon_Iz.verFormaPokedex(false);
            UC_Pokemon_De.verFormaPokedex(false);
        }

        /************************************************************************************************/

        /*Botones de la propia pagina*/
        private void Ir_A_La_Siguiente_Pagina_Click(object sender, RoutedEventArgs e)
        {
            // Boton que sirve para poder pasar a la seleccion de escenario
            PokemonJugador1 = "Snorlax";
            PokemonJugador2 = "Raichu";
            Frame EscenarioFrame = (Frame)this.Parent;
            EscenarioFrame.Navigate(typeof(Escenario_CombatePage), this);
        }

        private void Btn_Sandshrew_Click(object sender, RoutedEventArgs e)
        {

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


    }
}
