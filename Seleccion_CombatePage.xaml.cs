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

    /************************************************************************************************/

    /*Inicializacion de las variables globales*/



    /************************************************************************************************/
    public sealed partial class Seleccion_CombatePage : Page
    {
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

        }

        private void Btn_Sandshrew_Click(object sender, RoutedEventArgs e)
        {

        }


        /************************************************************************************************/

        /*Metodos funcionales en la pagina*/



        /************************************************************************************************/

        /*Metodos Auxiliares*/


    }
}
