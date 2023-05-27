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
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace IPO2_Pokemon_Pokedex
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class DetallesPokemonPage : Page
    {
        Pokemon pk;

        public DetallesPokemonPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            pk = e.Parameter as Pokemon;
            Paragraph myParagraph = new Paragraph();
            Run myRun = new Run();
            myRun.Text = pk.details;

            myParagraph.Inlines.Add(myRun);
            txtDescripcion.Blocks.Add(myParagraph);
            txtName.Text = pk.name;
            txtType.Text=pk.type.Nombre;
            txtVida.Text = "Vida: "+Convert.ToString(pk.hp);
            txtAtaque.Text = "Ataque: " + Convert.ToString(pk.attack);
            txtDefensa.Text = "Defensa: " + Convert.ToString(pk.defense);
            txtVelAtaque.Text = "Velocidad de Ataque: " + Convert.ToString(pk.speedAttack);
            txtVelDefensa.Text = "Velelocidad de Defensa: " + Convert.ToString(pk.speedDefense);
            txtRapidez.Text = "Rapidez: " + Convert.ToString(pk.speed);

            imgType.Source = new BitmapImage(pk.type.IconoUri);
            imgPokemon.Source = pk.icon;
        }

        private void btnVerPokemon_Click(object sender, RoutedEventArgs e)
        {
            Frame DetallesPokemonVistaGeneralPage = (Frame)this.Parent;
            DetallesPokemonVistaGeneralPage.Navigate(typeof(DetallesPokemonVistaGeneralPage), pk);
        }
    }

    

}
