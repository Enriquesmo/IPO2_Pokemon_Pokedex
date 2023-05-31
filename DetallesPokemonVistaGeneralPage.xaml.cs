using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Navigation;

namespace IPO2_Pokemon_Pokedex
{
    /// <summary>
    /// Página dedicada a mostrar una Demo de las habilidades del pokemon seleccionado.
    /// 
    /// Proyecto realizado por:
    /// Enrique Sánchez-Migallón Ochoa
    /// Javier Santos Sanz
    /// Alonso Crespo Fernández
    /// Felipe Alcázar Gómez
    /// </summary>
    
    public sealed partial class DetallesPokemonVistaGeneralPage : Page
    {

        /************************************************************************************************/

        /*Inicializacion de las variables globales*/

        Pokemon pk;

        /************************************************************************************************/

        /*Inicializacion de la pagina DetallesPokemonVistaGeneralPage*/
        
        public DetallesPokemonVistaGeneralPage() // Terminado
        {
            this.InitializeComponent();
        }

        /************************************************************************************************/

        /*Botones de la propia pagina*/



        /************************************************************************************************/

        /*Metodos funcionales en la pagina*/

        protected override void OnNavigatedTo(NavigationEventArgs e) // Terminado
        {
            pk = e.Parameter as Pokemon;
            Paragraph myParagraph = new Paragraph();
            Run myRun = new Run();
            myRun.Text = pk.details;
            switch (pk.name)
            {
                case "Snorlax":
                    userControlSnorlax.Visibility = Visibility.Visible;
                    break;
                case "Darumaka":
                    userControlDarumaka.Visibility = Visibility.Visible;
                    break;
                case "Raichu":
                    userControlRaichu.Visibility = Visibility.Visible;
                    break;
                case "Sandshrew":
                    userControlSandshrew.Visibility = Visibility.Visible;
                    break;
            }
        }

        /************************************************************************************************/

        /*Metodos Auxiliares*/

    }
}
