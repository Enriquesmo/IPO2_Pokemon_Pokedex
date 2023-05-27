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

    public sealed partial class CombatePage : Page
    {
        /************************************************************************************************/

        /*Inicializacion de las variables globales*/

        public string modo_de_Juego;

        /************************************************************************************************/

        /*Inicializacion de la pagina CombatePage*/
        public CombatePage()
        {
            this.InitializeComponent();
        }

        /************************************************************************************************/

        /*Botones de la propia pagina*/
        private void Ir_A_La_Siguiente_Pagina1_Click(object sender, RoutedEventArgs e)
        {
            // Continuar el combate en modo P1 vs P2
            modo_de_Juego = "VS";
            Frame CombateFrame = (Frame)this.Parent;
            CombateFrame.Navigate(typeof(Seleccion_CombatePage), this);
        }

        private void Ir_A_La_Siguiente_Pagina2_Click(object sender, RoutedEventArgs e)
        {
            // Continuar el combate en modo P1 vs IA
            modo_de_Juego = "IA";
            Frame CombateFrame = (Frame)this.Parent;
            CombateFrame.Navigate(typeof(Seleccion_CombatePage), this);
        }

        /************************************************************************************************/

        /*Metodos funcionales en la pagina*/



        /************************************************************************************************/

        /*Metodos Auxiliares*/


    }
}
