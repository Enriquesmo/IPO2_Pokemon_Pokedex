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
                new Pokemon(01, "Snorlax", Pokemon_Type.Normal, 20, 100, 50, 230, 10, 30, 40),
                new Pokemon(02, "Raichu", Pokemon_Type.Electric, 45, 100, 90, 150, 60, 80, 120),
                new Pokemon(03, "Darumaka", Pokemon_Type.Normal, 30, 100, 30, 90, 40, 120, 80),
                new Pokemon(04, "Sandshrew", Pokemon_Type.Normal, 62, 100, 65, 130, 35, 130, 90)
            };


            return pokemonList;
        }

        private void Snorlax_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            //TODO: abrir pagina de información especifica del pokemon tras hacer doble click
        }

        private void Raichu_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            //TODO: abrir pagina de información especifica del pokemon tras hacer doble click
        }

        private void Darumaka_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            //TODO: abrir pagina de información especifica del pokemon tras hacer doble click
        }

        private void Sandshrew_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            //TODO: abrir pagina de información especifica del pokemon tras hacer doble click
        }

        private void MostrarPokemon(object sender, SelectionChangedEventArgs e)
        {
            Pokemon pk = (Pokemon)pokemonList[lvAux.SelectedIndex];
            txtlvl.Text = "LVL. " + Convert.ToString(pk.level);

            var selectedIndex = lvAux.SelectedIndex;
            double position = selectedIndex * stackAux.Children.ElementAt(selectedIndex).ActualSize.Y;
            lvPokemon.ChangeView(null, position, null);
        }
    }
}
