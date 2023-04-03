using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
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
    /// Página dedicada a la funcionalidad de Acerca de, la cual consiste en dar los datos de los desarrolladores del proyecto
    /// 
    /// Hecho por:
    /// Enrique Sánchez-Migallón Ochoa
    /// Javier Santos Sanz
    /// Alonso Crespo Fernández
    /// Felipe Alcázar Gómez
    /// </summary>

    /************************************************************************************************/

    /*Inicializacion de las variables globales*/



    /************************************************************************************************/
    public sealed partial class Acerca_De : Page
    {
        /************************************************************************************************/

        /*Inicializacion de la pagina CombatePage*/
        public Acerca_De()
        {
            this.InitializeComponent();
            ApplicationView.GetForCurrentView().VisibleBoundsChanged
             += UcRatingText_VisibleBoundsChanged;
        }

        /************************************************************************************************/

        /*Botones de la propia pagina*/
        private void UcRatingText_VisibleBoundsChanged(ApplicationView sender, object args)
        {
            var Width =
            ApplicationView.GetForCurrentView().VisibleBounds.Width;
            if (Width >= 600)
            {
                RelativePanel.SetBelow(tbPokemon, null);
                RelativePanel.SetRightOf(tbPokemon, rcStars);
                RelativePanel.SetAlignVerticalCenterWith(tbPokemon, rcStars);
                RelativePanel.SetAlignVerticalCenterWithPanel(rcStars, true);
            }
            else
            {
                RelativePanel.SetRightOf(tbPokemon, null);
                RelativePanel.SetBelow(tbPokemon, rcStars);
                RelativePanel.SetAlignVerticalCenterWith(tbPokemon, null);
                RelativePanel.SetAlignVerticalCenterWithPanel(rcStars, false);
            }
        }

        /************************************************************************************************/

        /*Metodos funcionales en la pagina*/



        /************************************************************************************************/

        /*Metodos Auxiliares*/


    }
}
