using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Linq;
using Windows.ApplicationModel.Resources.Core;
using Windows.Foundation;
using Windows.Globalization;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;


namespace IPO2_Pokemon_Pokedex
{
    /// <summary>
    /// Página principal del programa, gestiona todo el menu principal junto con sus opciones.
    /// 
    /// Proyecto realizado por:
    /// Enrique Sánchez-Migallón Ochoa
    /// Javier Santos Sanz
    /// Alonso Crespo Fernández
    /// Felipe Alcázar Gómez
    /// </summary>

    public sealed partial class MainPage : Page
    {
        /************************************************************************************************/

        /*Inicializacion de las variables globales*/

        public MediaElement mediaElement;

        /************************************************************************************************/

        /*Inicializacion de la pagina MainPage*/

        public MainPage() // Terminado
        {
            this.InitializeComponent();
            mediaElement = new MediaElement();

            // Lineas utilizadas para el cambio de idioma
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += opcionVolver;
            FrameMain.Navigate(typeof(InicioPage), this);
            sView_Abajo_Principal.DisplayMode = SplitViewDisplayMode.CompactInline;
            sView_Abajo_Principal.IsPaneOpen = true;
            string lang = ApplicationLanguages.PrimaryLanguageOverride;
            if (lang == "es")
            {
                Switch_Idioma.IsOn= false;
                ApplicationLanguages.PrimaryLanguageOverride = "es-ES";
            }
            else
            {
                Switch_Idioma.IsOn = true;
                ApplicationLanguages.PrimaryLanguageOverride = "en-GB";
            }

            // Estas lineas sirven para que cuando se redimensione la ventana se adapte, además de hacer un tamaño minimo
            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(320, 320));
            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBoundsChanged += MainPage_VisibleBoundsChanged;

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
            darBienvenida();
        }

        /************************************************************************************************/

        /*Botones de la propia Página*/

        private void btn_Inicio_Click(object sender, RoutedEventArgs e) // Terminado
        {
            // Este boton sirve para que aparezca la pagina de "Inicio"
            FrameMain.Navigate(typeof(InicioPage), this);
            sView_Abajo_Principal.IsPaneOpen = false;
            sView_Abajo_Principal.DisplayMode = SplitViewDisplayMode.CompactOverlay;
        }
        private void btn_Pokedex_Click(object sender, RoutedEventArgs e) // Terminado
        {
            // Este boton sirve para que aparezca la pagina de "Pokedex"
            FrameMain.Navigate(typeof(PokedexPage), this); // Este this es para que se le pase como parámetro a la pagina creada, la pagina anterior
            sView_Abajo_Principal.IsPaneOpen = false;
            sView_Abajo_Principal.DisplayMode = SplitViewDisplayMode.CompactOverlay;
        }
        private void btn_CombatePokemon_Click(object sender, RoutedEventArgs e) // Terminado
        {
            // Este boton sirve para que aparezca la pagina de "CombatePokemon"
            FrameMain.Navigate(typeof(CombatePage), this); // Este this es para que se le pase como parámetro a la pagina creada, la pagina anterior
            sView_Abajo_Principal.IsPaneOpen = false;
            sView_Abajo_Principal.DisplayMode = SplitViewDisplayMode.CompactOverlay;
        }
        private void btn_AcercaDe_Click(object sender, RoutedEventArgs e) // Terminado
        {
            // Este boton sirve para que aparezca la pagina de "Acerca De"
            FrameMain.Navigate(typeof(Acerca_De), this); // Este this es para que se le pase como parámetro a la pagina creada, la pagina anterior
            sView_Abajo_Principal.IsPaneOpen = false;
            sView_Abajo_Principal.DisplayMode = SplitViewDisplayMode.CompactOverlay;
        }
        private void Btn_Menu_Click(object sender, RoutedEventArgs e) // Terminado
        {
            // Este boton sirve para que el boton de las Tres rallitas de arriba a la izquierda oculte o haga aparecer el menu
            sView_Abajo_Principal.IsPaneOpen = !sView_Abajo_Principal.IsPaneOpen;
        }
        private void SymbolIcon_Inicio_PointerReleased(object sender, PointerRoutedEventArgs e) // Terminado
        {
            // Este boton sirve para que aparezca la pagina de "Inicio"
            FrameMain.Navigate(typeof(InicioPage), this);
            sView_Abajo_Principal.IsPaneOpen = false;
            sView_Abajo_Principal.DisplayMode = SplitViewDisplayMode.CompactOverlay;
        }
        private void SymbolIcon_Pokedex_PointerReleased(object sender, PointerRoutedEventArgs e) // Terminado
        {
            // Este Icono sirve para que aparezca la pagina de "Pokedex"
            FrameMain.Navigate(typeof(PokedexPage), this); // Este this es para que se le pase como parámetro a la pagina creada, la pagina anterior
            sView_Abajo_Principal.IsPaneOpen = false;
            sView_Abajo_Principal.DisplayMode = SplitViewDisplayMode.CompactOverlay;
        }
        private void SymbolIcon_Combate_PointerReleased(object sender, PointerRoutedEventArgs e) // Terminado
        {
            // Este Icono sirve para que aparezca la pagina de "CombatePokemon"
            FrameMain.Navigate(typeof(CombatePage), this); // Este this es para que se le pase como parámetro a la pagina creada, la pagina anterior
            sView_Abajo_Principal.IsPaneOpen = false;
            sView_Abajo_Principal.DisplayMode = SplitViewDisplayMode.CompactOverlay;
        }
        private void SymbolIcon_AcercaDe_PointerReleased(object sender, PointerRoutedEventArgs e) // Terminado
        {
            // Este Icono sirve para que aparezca la pagina de "Acerca De"
            FrameMain.Navigate(typeof(Acerca_De), this); // Este this es para que se le pase como parámetro a la pagina creada, la pagina anterior
            sView_Abajo_Principal.IsPaneOpen = false;
            sView_Abajo_Principal.DisplayMode = SplitViewDisplayMode.CompactOverlay;
        }
        private void Switch_Idioma_Toggled(object sender, RoutedEventArgs e)
        {
            if (Switch_Idioma.IsOn)
            {
                ApplicationLanguages.PrimaryLanguageOverride = "en-GB";
                btn_Inicio.Content = "Main";
                btn_CombatePokemon.Content = "Pokemon Combat";
                btn_AcercaDe.Content = "About Us";
                Switch_Idioma.Header = "Languaje";
                Switch_Lector_De_Voz.Header = "Voice Reader";
            }
            else
            {
                ApplicationLanguages.PrimaryLanguageOverride = "es-ES";
                btn_Inicio.Content = "Inicio";
                btn_CombatePokemon.Content = "Combate Pokemon";
                btn_AcercaDe.Content = "Acerca De";
                Switch_Idioma.Header = "Idioma";
                Switch_Lector_De_Voz.Header = "Lector de Voz";
            }
            ResourceContext.GetForViewIndependentUse().Reset();
            FrameMain.Navigate(typeof(InicioPage), this);
            sView_Abajo_Principal.IsPaneOpen = false;
            sView_Abajo_Principal.DisplayMode = SplitViewDisplayMode.CompactOverlay;
        }
        private async void Switch_Lector_De_Voz_Toggled(object sender, RoutedEventArgs e) // Terminado
        {
            if (Switch_Lector_De_Voz.IsOn)
            {
                var synth = new Windows.Media.SpeechSynthesis.SpeechSynthesizer();
                Windows.Media.SpeechSynthesis.SpeechSynthesisStream stream = await
                synth.SynthesizeTextToStreamAsync("Lector de Voz Activado.");
                mediaElement.SetSource(stream, stream.ContentType);
                mediaElement.Play();
                IniciarEscuchaEnfoque();
            }
            else
            {
                var synth = new Windows.Media.SpeechSynthesis.SpeechSynthesizer();
                Windows.Media.SpeechSynthesis.SpeechSynthesisStream stream = await
                synth.SynthesizeTextToStreamAsync("Lector de Voz Desactivado.");
                mediaElement.SetSource(stream, stream.ContentType);
                mediaElement.Play();
                DetenerEscuchaEnfoque();
            }
        }

        /************************************************************************************************/

        /*Metodos funcionales en la ventana*/

        private void MainPage_VisibleBoundsChanged(Windows.UI.ViewManagement.ApplicationView sender, object args) // Terminado
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

        // Los siguientes Metodos son los utilizados en el lector de voz
        // Para que el lector lea un elemento, hay que agegarle esta propiedad: AutomationProperties.Name=""
        // Dentro de las comillas, le ponemos lo que va a leer el lector

        private void IniciarEscuchaEnfoque() // Terminado
        {
            UIElement root = Window.Current.Content;
            root.GotFocus += ElementoPosicionado;
        }
        private async void ElementoPosicionado(object sender, RoutedEventArgs e) // Terminado
        {
            var synth = new Windows.Media.SpeechSynthesis.SpeechSynthesizer();
            var focusedElement = FocusManager.GetFocusedElement() as FrameworkElement;

            if (focusedElement != null)
            {
                string texto = AutomationProperties.GetName(focusedElement);
                if (!string.IsNullOrEmpty(texto))
                {
                    Windows.Media.SpeechSynthesis.SpeechSynthesisStream stream = await synth.SynthesizeTextToStreamAsync(texto);
                    MediaElement mediaElement = new MediaElement();
                    mediaElement.SetSource(stream, stream.ContentType);
                    mediaElement.Play();
                }
            }
        }
        private void DetenerEscuchaEnfoque() // Terminado
        {
            UIElement root = Window.Current.Content;
            root.GotFocus -= ElementoPosicionado;
        }

        /************************************************************************************************/

        /*Metodos Auxiliares*/

        private async void darBienvenida() // Terminado
        {
            var synth = new Windows.Media.SpeechSynthesis.SpeechSynthesizer();
            Windows.Media.SpeechSynthesis.SpeechSynthesisStream stream = await
            synth.SynthesizeTextToStreamAsync("Bienvenido a IPOkemon, si necesitas ayuda, consulta Ajustes.");
            mediaElement.SetSource(stream, stream.ContentType);
            mediaElement.Play();
        }
        private void opcionVolver(object sender, BackRequestedEventArgs e) // Terminado
        {
            // Este metodo sirve para que el boton de hacia atras vuelva tras la primera accion, ademas que lo hace aparecer
            if (FrameMain.BackStack.Any())
            {
                FrameMain.GoBack();
            }
        }

    }
}
