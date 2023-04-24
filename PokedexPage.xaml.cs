using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace IPO2_Pokemon_Pokedex
{
    /// <summary>
    /// Página dedicada a la funcionalidad de la pokedex
    /// 
    /// Hecho por:
    /// Enrique Sánchez-Migallón Ochoa
    /// Javier Santos Sanz
    /// Alonso Crespo Fernández
    /// Felipe Alcázar Gómez
    /// </summary>

    public sealed partial class PokedexPage : Page
    {
        /************************************************************************************************/

        /*Inicializacion de las variables globales*/

        public ArrayList pokemonList;
        Pokemon pk;

        /************************************************************************************************/

        /*Inicializacion de la pagina PokedexPage*/
        public PokedexPage()
        {
            this.InitializeComponent();
            createPokemonList();
            lvAux.ItemsSource = pokemonList;
            Raichu.verFormaPokedex(false);
            Sandshrew.verFormaPokedex(false);
            Darumaka.verFormaPokedex(false);
            Snorlax.verFormaPokedex(false);
        }

        /************************************************************************************************/

        /*Botones de la propia pagina*/



        /************************************************************************************************/

        /*Metodos funcionales en la pagina*/



        /************************************************************************************************/

        /*Metodos Auxiliares*/
        public ArrayList createPokemonList()
        {
            pokemonList = new ArrayList
            {
                new Pokemon(01, "Snorlax", DatosTipoDePokemon.Normal, 20, 100, 50, 230, 10, 30, 40, new BitmapImage(new Uri("ms-appx:///Assets/Snorlax.png")) ,"A Snorlax le encanta dormir y comer: este corpulento Pokémon se vuelve gruñón si no come sus casi 400 kg de comida diaria. Después de picotear un poco, siempre se echa una siesta. Su estómago es a prueba de bombas y puede comer alimentos mohosos o en mal estado sin sufrir ni un solo problema digestivo.\n\nCon sus más de 460 kg de peso, son los Pokémon más pesados de los que se tiene noticia hasta la fecha."),
                new Pokemon(02, "Raichu", DatosTipoDePokemon.Eléctrico, 45, 100, 90, 150, 60, 80, 120, new BitmapImage(new Uri("ms-appx:///Assets/Raichu.png")), "Este Pokémon es un gran roedor bípedo. Tiene un pelaje anaranjado, una cola oscura y gruesa como un cable de tendido eléctrico que termina en forma de rayo y totalmente plana, que además puede soportar grandes cargas. Tiene un vientre de tono claro y unos mofletes amarillos, que producen la energía eléctrica que se conduce a la cola de Raichu para ser liberada en forma de potentes ataques tipo eléctrico.\n\nSus orejas son grandes y están parcialmente enrolladas. Almacena la carga acumulada en sus mejillas, exactamente igual a su preevolución Pikachu."),
                new Pokemon(03, "Darumaka", DatosTipoDePokemon.Fuego, 30, 100, 30, 90, 40, 120, 80, new BitmapImage(new Uri("ms-appx:///Assets/Daru.png")), "Darumaka está basado en un muñeco Daruma y en un mono. Su cuerpo es pequeño y redondo, con tonos rojos y amarillos.\r\n\r\nLa llama que arde en su interior es la fuente de su poder y no para quieto si arden las llamas de su estómago. Si el fuego mengua, se sume en un estado de sopor de inmediato. De hecho, cuando se dispone a dormir, retrae sus piernas y sus brazos, y reduce la llama de su interior a 600 ºC para relajarse."),
                new Pokemon(04, "Sandshrew", DatosTipoDePokemon.Tierra, 62, 100, 65, 130, 35, 130, 90, new BitmapImage (new Uri("ms-appx:///Assets/Sandshrew.png")), "El entorno natural de Sandshrew son los lugares profundos bajo tierra en localizaciones áridas con muy poca humedad, siendo los desiertos el ejemplo más claro, aunque también se encuentra en praderas secas. Elige este hábitat para mantenerse seco, mientras que la arena le provee con un buen camuflaje.\r\n\r\nCuando es molestado, la primera reacción de defensa es instantáneamente enrollar su cuerpo hasta convertirlo en una bola, dejando sólo su fuerte piel expuesta (comparable al sistema de defensa de erizos, armadillos y pangolines). Cuando se enrolla de esta manera, Sandshrew tiene el potencial de resistir varios ataques y caer desde una gran altura sin dañarse y siendo capaz de rebotar.")
            };


            return pokemonList;
        }

        private void MostrarPokemon(object sender, SelectionChangedEventArgs e)
        {
            pk = (Pokemon)pokemonList[lvAux.SelectedIndex];
            txtlvl.Text = "LVL. " + Convert.ToString(pk.level);
            txtType.Text = Convert.ToString(pk.type);
            txtHP.Text = "HP: " + Convert.ToString(pk.hp);
            txtAttack.Text = "Ataque: " + Convert.ToString(pk.attack);
            txtDefense.Text = "Defensa: " + Convert.ToString(pk.defense);
            imgType.Source = new BitmapImage(pk.type.IconoUri);

            var selectedIndex = lvAux.SelectedIndex;
            double position = selectedIndex * stackAux.Children.ElementAt(selectedIndex).ActualSize.Y;
            lvPokemon.ChangeView(null, position, null);
        }

        private void lvPokemon_GotFocus(object sender, RoutedEventArgs e)
        {
            lvAux.Focus(FocusState.Programmatic);
        }

        private void mostrarDetalles(object sender, RoutedEventArgs e)
        {
            Frame PokedexFrame = (Frame)this.Parent;
            PokedexFrame.Navigate(typeof(DetallesPokemonPage), pk);
        }
    }
}
