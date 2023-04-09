using System.Linq;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace IPO2_Pokemon_Pokedex
{
    /// <summary>
    /// Página principal del programa, gestiona todo el menu principal junto con sus opciones.
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

    public sealed partial class MainPage : Page
    {

        /************************************************************************************************/

        /*Inicializacion de la pagina MainPage*/
        public MainPage()
        {
            this.InitializeComponent();
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += opcionVolver;
            FrameMain.Navigate(typeof(InicioPage), this);
            sView_Abajo_Principal.DisplayMode = SplitViewDisplayMode.CompactInline;
            sView_Abajo_Principal.IsPaneOpen = true;

            // Estas lineas sirven para que cuando se redimensione la ventana se adapte, además de hacer un tamaño minimo
            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(320, 320));
            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBoundsChanged += MainPage_VisibleBoundsChanged;

        }

        /************************************************************************************************/

        /*Botones de la propia Página*/

        private void btn_Inicio_Click(object sender, RoutedEventArgs e) // Hecho
        {
            // Este boton sirve para que aparezca la pagina de "Inicio"
            FrameMain.Navigate(typeof(InicioPage), this);
            sView_Abajo_Principal.IsPaneOpen = false;
            sView_Abajo_Principal.DisplayMode = SplitViewDisplayMode.CompactOverlay;
        }
        private void btn_Pokedex_Click(object sender, RoutedEventArgs e) // Hecho
        {
            // Este boton sirve para que aparezca la pagina de "Pokedex"
            FrameMain.Navigate(typeof(PokedexPage), this); // Este this es para que se le pase como parámetro a la pagina creada, la pagina anterior
            sView_Abajo_Principal.IsPaneOpen = false;
            sView_Abajo_Principal.DisplayMode = SplitViewDisplayMode.CompactOverlay;
        }
        private void btn_CombatePokemon_Click(object sender, RoutedEventArgs e) // Hecho
        {
            // Este boton sirve para que aparezca la pagina de "CombatePokemon"
            FrameMain.Navigate(typeof(CombatePage), this); // Este this es para que se le pase como parámetro a la pagina creada, la pagina anterior
            sView_Abajo_Principal.IsPaneOpen = false;
            sView_Abajo_Principal.DisplayMode = SplitViewDisplayMode.CompactOverlay;
        }
        private void btn_AcercaDe_Click(object sender, RoutedEventArgs e) // Hecho
        {
            // Este boton sirve para que aparezca la pagina de "Acerca De"
            FrameMain.Navigate(typeof(Acerca_De), this); // Este this es para que se le pase como parámetro a la pagina creada, la pagina anterior
            sView_Abajo_Principal.IsPaneOpen = false;
            sView_Abajo_Principal.DisplayMode = SplitViewDisplayMode.CompactOverlay;
        }
        private void Btn_Menu_Click(object sender, RoutedEventArgs e) // Hecho
        {
            // Este boton sirve para que el boton de las Tres rallitas de arriba a la izquierda oculte o haga aparecer el menu
            sView_Abajo_Principal.IsPaneOpen = !sView_Abajo_Principal.IsPaneOpen;
        }
        private void opcionVolver(object sender, BackRequestedEventArgs e) // Hecho
        {
            // Este metodo sirve para que el boton de hacia atras vuelva tras la primera accion, ademas que lo hace aparecer
            if (FrameMain.BackStack.Any())
            {
                FrameMain.GoBack();
            }
        }
        private void SymbolIcon_Inicio_PointerReleased(object sender, PointerRoutedEventArgs e) // Hecho
        {
            // Este boton sirve para que aparezca la pagina de "Inicio"
            FrameMain.Navigate(typeof(InicioPage), this);
            sView_Abajo_Principal.IsPaneOpen = false;
            sView_Abajo_Principal.DisplayMode = SplitViewDisplayMode.CompactOverlay;
        }
        private void SymbolIcon_Pokedex_PointerReleased(object sender, PointerRoutedEventArgs e) // Hecho
        {
            // Este Icono sirve para que aparezca la pagina de "Pokedex"
            FrameMain.Navigate(typeof(PokedexPage), this); // Este this es para que se le pase como parámetro a la pagina creada, la pagina anterior
            sView_Abajo_Principal.IsPaneOpen = false;
            sView_Abajo_Principal.DisplayMode = SplitViewDisplayMode.CompactOverlay;
        }
        private void SymbolIcon_Combate_PointerReleased(object sender, PointerRoutedEventArgs e) // Hecho
        {
            // Este Icono sirve para que aparezca la pagina de "CombatePokemon"
            FrameMain.Navigate(typeof(CombatePage), this); // Este this es para que se le pase como parámetro a la pagina creada, la pagina anterior
            sView_Abajo_Principal.IsPaneOpen = false;
            sView_Abajo_Principal.DisplayMode = SplitViewDisplayMode.CompactOverlay;
        }
        private void SymbolIcon_AcercaDe_PointerReleased(object sender, PointerRoutedEventArgs e) // Hecho
        {
            // Este Icono sirve para que aparezca la pagina de "Acerca De"
            FrameMain.Navigate(typeof(Acerca_De), this); // Este this es para que se le pase como parámetro a la pagina creada, la pagina anterior
            sView_Abajo_Principal.IsPaneOpen = false;
            sView_Abajo_Principal.DisplayMode = SplitViewDisplayMode.CompactOverlay;
        }

        /************************************************************************************************/

        /*Metodos funcionales en la ventana*/

        private void MainPage_VisibleBoundsChanged(Windows.UI.ViewManagement.ApplicationView sender, object args) // Hecho
        {
            // Este metodo lo que hace es hacer que el menu lateral se redimensione conforme vaya ajustandose el tamaño de la ventana
            var Width =
           Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBounds.Width;
            if (Width >= 720)
            {
                sView_Abajo_Principal.DisplayMode = SplitViewDisplayMode.CompactInline;
                sView_Abajo_Principal.IsPaneOpen = true;
            }
            else if (Width >= 360)
            {
                sView_Abajo_Principal.DisplayMode = SplitViewDisplayMode.CompactOverlay;
                sView_Abajo_Principal.IsPaneOpen = false;
            }
            else
            {
                sView_Abajo_Principal.DisplayMode = SplitViewDisplayMode.Overlay;
                sView_Abajo_Principal.IsPaneOpen = false;
            }
        }

        /************************************************************************************************/

        /*Metodos Auxiliares*/


    }
}
