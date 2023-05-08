using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Linq;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Notifications;
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

    public sealed partial class MainPage : Page
    {
        /************************************************************************************************/

        /*Inicializacion de las variables globales*/



        /************************************************************************************************/

        /*Inicializacion de la pagina MainPage*/
        public MainPage()
        {
            this.InitializeComponent();
            contentFrame.Navigate(typeof(InicioPage), this);

            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += opcionVolver;
            //FrameMain.Navigate(typeof(InicioPage), this);
            //sView_Abajo_Principal.DisplayMode = SplitViewDisplayMode.CompactInline;
            //sView_Abajo_Principal.IsPaneOpen = true;
            nvSample.IsPaneOpen = true;


            // Estas lineas sirven para que cuando se redimensione la ventana se adapte, además de hacer un tamaño minimo
            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(320, 320));
            //Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBoundsChanged += MainPage_VisibleBoundsChanged;

            // Este codigo de ahora sirve para generar la aplicacion y que se puea ejecutar desde la barra del buscador sin tener visual studio abierto
            TileContent content = new TileContent()
            {
                Visual = new TileVisual()
                {
                    TileMedium = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                            {
                                new AdaptiveText()
                                {
                                    Text = "IPOkemon",HintStyle = AdaptiveTextStyle.Subtitle
                                },
                                new AdaptiveText()
                                {
                                    Text = "Un proyecto de IPO2",HintStyle = AdaptiveTextStyle.CaptionSubtle
                                },
                            }
                        }
                    },
                    TileWide = new TileBinding()
                    {
                        Branding = TileBranding.NameAndLogo,
                        DisplayName = "Version 1.0",
                        Content = new TileBindingContentAdaptive()
                        {
                            Children = {
                                new AdaptiveText()
                                {
                                    Text = "IPOkemon",
                                    HintStyle = AdaptiveTextStyle.Subtitle
                                },
                                new AdaptiveText()
                                {
                                    Text = "Un Proyecto de IPO2",HintStyle = AdaptiveTextStyle.CaptionSubtle
                                },
                                new AdaptiveText()
                                {
                                    Text = "Una aplicación sobre Pokemon hecha con tecnología UWP",
                                    HintWrap = true,
                                }
                            }
                        }
                    },
                    TileLarge = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children = {
                                 new AdaptiveText()
                                {
                                 Text = "IPOkemon",
                                HintStyle = AdaptiveTextStyle.Subtitle
                                 },
                                 new AdaptiveText()
                                 {
                                 Text = "Un Proyecto de IPO2",
                                HintStyle = AdaptiveTextStyle.CaptionSubtle
                                 },
                                 new AdaptiveText()
                                {
                            Text = "Una aplicación sobre Pokemon hecha con tecnología UWP",
                            HintStyle = AdaptiveTextStyle.CaptionSubtle
                                 }
                            }
                        }
                    },
                }
            };

            var notification = new TileNotification(content.GetXml());
            notification.ExpirationTime = DateTimeOffset.UtcNow.AddSeconds(30);
            var updater = TileUpdateManager.CreateTileUpdaterForApplication();
            updater.Update(notification);

            // Este codigo sirve para que se cree una notificación nada mas se inicie la aplicación
            NotificaciónSubida(this, null);
            darBienvenida();
        }

        private void NotificaciónSubida(object sender, PointerRoutedEventArgs e)
        {
            new ToastContentBuilder()
            .AddArgument("action", "Favoritos")
            .AddArgument("conversationId", 9813)
            .AddText("Raichu ha evolucionado")
            .AddText("Puedes ver más información en IPOkemon")
            .AddInlineImage(new Uri("ms-appx:///Assets/Raichu.png"))
            .AddAppLogoOverride(new Uri("ms-appx:///Assets/IconoAplicación.png"), ToastGenericAppLogoCrop.Circle)
            .AddButton(new ToastButton()
            .SetContent("Enviar")
            .AddArgument("action","reply")
            )
            .Show();
        }

        private async void darBienvenida()
        {
            MediaElement mediaElement = new MediaElement();
            var synth = new Windows.Media.SpeechSynthesis.SpeechSynthesizer();
            Windows.Media.SpeechSynthesis.SpeechSynthesisStream stream = await
            synth.SynthesizeTextToStreamAsync("Bienvenido a IPOkemon, si necesitas ayuda, consulta Ajustes.");
            mediaElement.SetSource(stream, stream.ContentType);
            mediaElement.Play();
        }

        /************************************************************************************************/

        /*Botones de la propia Página*/

        private void nvSample_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected) { }
            else
            {
                var item = args.SelectedItem as NavigationViewItem;

                if (item != null)
                {
                    Type pageType = null;
                    switch (item.Tag)
                    {
                        case "Inicio":
                            pageType = typeof(InicioPage);
                            break;

                        case "Pokedex":
                            pageType = typeof(PokedexPage);
                            break;

                        case "Combate":
                            pageType = typeof(CombatePage);
                            break;

                        case "AcercaDe":
                            pageType = typeof(Acerca_De);
                            break;
                    }
                    if (pageType != null && pageType != contentFrame.CurrentSourcePageType)
                    {
                        contentFrame.Navigate(pageType);
                    }
                }
            }
        }

        private void nvSample_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            if (contentFrame.BackStack.Any())
            {
                contentFrame.GoBack();
            }
        }

        //private void btn_Inicio_Click(object sender, RoutedEventArgs e) // Hecho
        //{
        //    // Este boton sirve para que aparezca la pagina de "Inicio"
        //    FrameMain.Navigate(typeof(InicioPage), this);
        //    sView_Abajo_Principal.IsPaneOpen = false;
        //    sView_Abajo_Principal.DisplayMode = SplitViewDisplayMode.CompactOverlay;
        //}
        //private void btn_Pokedex_Click(object sender, RoutedEventArgs e) // Hecho
        //{
        //    // Este boton sirve para que aparezca la pagina de "Pokedex"
        //    FrameMain.Navigate(typeof(PokedexPage), this); // Este this es para que se le pase como parámetro a la pagina creada, la pagina anterior
        //    sView_Abajo_Principal.IsPaneOpen = false;
        //    sView_Abajo_Principal.DisplayMode = SplitViewDisplayMode.CompactOverlay;
        //}
        //private void btn_CombatePokemon_Click(object sender, RoutedEventArgs e) // Hecho
        //{
        //    // Este boton sirve para que aparezca la pagina de "CombatePokemon"
        //    FrameMain.Navigate(typeof(CombatePage), this); // Este this es para que se le pase como parámetro a la pagina creada, la pagina anterior
        //    sView_Abajo_Principal.IsPaneOpen = false;
        //    sView_Abajo_Principal.DisplayMode = SplitViewDisplayMode.CompactOverlay;
        //}
        //private void btn_AcercaDe_Click(object sender, RoutedEventArgs e) // Hecho
        //{
        //    // Este boton sirve para que aparezca la pagina de "Acerca De"
        //    FrameMain.Navigate(typeof(Acerca_De), this); // Este this es para que se le pase como parámetro a la pagina creada, la pagina anterior
        //    sView_Abajo_Principal.IsPaneOpen = false;
        //    sView_Abajo_Principal.DisplayMode = SplitViewDisplayMode.CompactOverlay;
        //}
        //private void Btn_Menu_Click(object sender, RoutedEventArgs e) // Hecho
        //{
        //    // Este boton sirve para que el boton de las Tres rallitas de arriba a la izquierda oculte o haga aparecer el menu
        //    sView_Abajo_Principal.IsPaneOpen = !sView_Abajo_Principal.IsPaneOpen;
        //}
        private void opcionVolver(object sender, BackRequestedEventArgs e) // Hecho
        {
            // Este metodo sirve para que el boton de hacia atras vuelva tras la primera accion, ademas que lo hace aparecer
            if (contentFrame.BackStack.Any())
            {
                contentFrame.GoBack();
            }
        }
        //private void SymbolIcon_Inicio_PointerReleased(object sender, PointerRoutedEventArgs e) // Hecho
        //{
        //    // Este boton sirve para que aparezca la pagina de "Inicio"
        //    FrameMain.Navigate(typeof(InicioPage), this);
        //    sView_Abajo_Principal.IsPaneOpen = false;
        //    sView_Abajo_Principal.DisplayMode = SplitViewDisplayMode.CompactOverlay;
        //}
        //private void SymbolIcon_Pokedex_PointerReleased(object sender, PointerRoutedEventArgs e) // Hecho
        //{
        //    // Este Icono sirve para que aparezca la pagina de "Pokedex"
        //    FrameMain.Navigate(typeof(PokedexPage), this); // Este this es para que se le pase como parámetro a la pagina creada, la pagina anterior
        //    sView_Abajo_Principal.IsPaneOpen = false;
        //    sView_Abajo_Principal.DisplayMode = SplitViewDisplayMode.CompactOverlay;
        //}
        //private void SymbolIcon_Combate_PointerReleased(object sender, PointerRoutedEventArgs e) // Hecho
        //{
        //    // Este Icono sirve para que aparezca la pagina de "CombatePokemon"
        //    FrameMain.Navigate(typeof(CombatePage), this); // Este this es para que se le pase como parámetro a la pagina creada, la pagina anterior
        //    sView_Abajo_Principal.IsPaneOpen = false;
        //    sView_Abajo_Principal.DisplayMode = SplitViewDisplayMode.CompactOverlay;
        //}
        //private void SymbolIcon_AcercaDe_PointerReleased(object sender, PointerRoutedEventArgs e) // Hecho
        //{
        //    // Este Icono sirve para que aparezca la pagina de "Acerca De"
        //    FrameMain.Navigate(typeof(Acerca_De), this); // Este this es para que se le pase como parámetro a la pagina creada, la pagina anterior
        //    sView_Abajo_Principal.IsPaneOpen = false;
        //    sView_Abajo_Principal.DisplayMode = SplitViewDisplayMode.CompactOverlay;
        //}

        /************************************************************************************************/

        /*Metodos funcionales en la ventana*/

        //private void MainPage_VisibleBoundsChanged(Windows.UI.ViewManagement.ApplicationView sender, object args) // Hecho
        //{
        //    // Este metodo lo que hace es hacer que el menu lateral se redimensione conforme vaya ajustandose el tamaño de la ventana
        //    var Width =
        //   Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBounds.Width;
        //    if (Width >= 720)
        //    {
        //        sView_Abajo_Principal.DisplayMode = SplitViewDisplayMode.CompactInline;
        //        sView_Abajo_Principal.IsPaneOpen = true;
        //    }
        //    else if (Width >= 360)
        //    {
        //        sView_Abajo_Principal.DisplayMode = SplitViewDisplayMode.CompactOverlay;
        //        sView_Abajo_Principal.IsPaneOpen = false;
        //    }
        //    else
        //    {
        //        sView_Abajo_Principal.DisplayMode = SplitViewDisplayMode.Overlay;
        //        sView_Abajo_Principal.IsPaneOpen = false;
        //    }
        //}

        /************************************************************************************************/

        /*Metodos Auxiliares*/


    }
}
