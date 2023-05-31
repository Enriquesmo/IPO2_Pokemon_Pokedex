using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace IPO2_Pokemon_Pokedex
{
    /// <summary>
    /// Página dedicada a mostrar los detalles del pokemon seleccionado en la anterior página.
    /// 
    /// Proyecto realizado por:
    /// Enrique Sánchez-Migallón Ochoa
    /// Javier Santos Sanz
    /// Alonso Crespo Fernández
    /// Felipe Alcázar Gómez
    /// </summary>
    
    public sealed partial class DetallesPokemonPage : Page
    {
        /************************************************************************************************/

        /*Inicializacion de las variables globales*/

        Pokemon pk;

        /************************************************************************************************/

        /*Inicializacion de la pagina DetallesPokemonPage*/

        public DetallesPokemonPage() // Terminado
        {
            this.InitializeComponent();
        }

        /************************************************************************************************/

        /*Botones de la propia pagina*/

        private void btnVerPokemon_Click(object sender, RoutedEventArgs e) // Terminado
        {
            Frame DetallesPokemonVistaGeneralPage = (Frame)this.Parent;
            DetallesPokemonVistaGeneralPage.Navigate(typeof(DetallesPokemonVistaGeneralPage), pk);
        }

        /************************************************************************************************/

        /*Metodos funcionales en la pagina*/

        protected override void OnNavigatedTo(NavigationEventArgs e) // Terminado
        {
            pk = e.Parameter as Pokemon;
            Paragraph myParagraph = new Paragraph();
            Run myRun = new Run();
            myRun.Text = pk.details;

            myParagraph.Inlines.Add(myRun);
            txtDescripcion.Blocks.Add(myParagraph);
            txtName.Text = pk.name;
            txtType.Text = pk.type.Nombre;
            txtVida.Text = "Vida: " + Convert.ToString(pk.hp);
            txtAtaque.Text = "Ataque: " + Convert.ToString(pk.attack);
            txtDefensa.Text = "Defensa: " + Convert.ToString(pk.defense);
            txtVelAtaque.Text = "Velocidad de Ataque: " + Convert.ToString(pk.speedAttack);
            txtVelDefensa.Text = "Velelocidad de Defensa: " + Convert.ToString(pk.speedDefense);
            txtRapidez.Text = "Rapidez: " + Convert.ToString(pk.speed);

            imgType.Source = new BitmapImage(pk.type.IconoUri);
            imgPokemon.Source = pk.icon;
        }

        /************************************************************************************************/

        /*Metodos Auxiliares*/

    }
}
