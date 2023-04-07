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
    public sealed partial class Combate_CombatePage : Page
    {
        /************************************************************************************************/

        /*Inicializacion de la pagina CombatePage*/
        Escenario_CombatePage Padre;
        public Combate_CombatePage()
        {
            this.InitializeComponent();
            
        }
        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Padre = (Escenario_CombatePage)e.Parameter;
        }

        /************************************************************************************************/

        /*Botones de la propia pagina*/



        /************************************************************************************************/

        /*Metodos funcionales en la pagina*/



        /************************************************************************************************/

        /*Metodos Auxiliares*/


    }
}
