using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace IPO2_Pokemon_Pokedex
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += opcionVolver;
            PokemonSandshrew.VerFondo = false;
            PokemonSandshrew.VerNombre = false;
            PokemonSandshrew.VerVida = false;
            PokemonSandshrew.VerEnergia = false;
        }


        private void btn_Inicio_Click(object sender, RoutedEventArgs e)
        {
            FrameMain.Navigate(typeof(MainPage));
            // ARREGLAR PORQUE SE DUPLICA
        }

        private void btn_Pokedex_Click(object sender, RoutedEventArgs e)
        {
            FrameMain.Navigate(typeof(PokedexPage), this); // Este this es para que se le pase como parámetro a la pagina creada, la pagina anterior
        }

        private void btn_CombatePokemon_Click(object sender, RoutedEventArgs e)
        {
            FrameMain.Navigate(typeof(CombatePage), this); // Este this es para que se le pase como parámetro a la pagina creada, la pagina anterior
        }

        private void btn_AcercaDe_Click(object sender, RoutedEventArgs e)
        {

        }

        /**/
        private void opcionVolver(object sender, BackRequestedEventArgs e)
        {
            if (FrameMain.BackStack.Any())
            {
                FrameMain.GoBack();
            }
            // Que el boton de hacia atras vuelva tras la primera accion
        }
    }
}
