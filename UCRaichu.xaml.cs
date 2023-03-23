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
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace IPokemon23
{
    public sealed partial class UCRaichu : UserControl
    {
        DispatcherTimer miReloj;
        bool bttnVidaActivado = false;
        bool bttnEnergiaActivado = false;
        double valorAtaque1 = 15;
        double valorAtaque2 = 10;
        double valorAtaque3 = 20;
        double valorAtaque4 = 30;
        public UCRaichu()
        {
            this.InitializeComponent();
            miReloj = new DispatcherTimer();
        }

        public double Vida
        {
            get { return this.barraVida.Value; }
            set { this.barraVida.Value = value; }
        }

        public void verBarraVida(bool ver)
        {
            if (ver) this.barraVida.Visibility=Visibility.Visible;
            else this.barraVida.Visibility= Visibility.Collapsed;
        }

        public double Energia
        {
            get { return this.barraEnergia.Value; }
            set { this.barraVida.Value = value; }
        }


        private void DesactivarAtaques()
        {
            bttnAtaque1.IsEnabled = false;
            bttnAtaque2.IsEnabled = false;
            bttnAtaque3.IsEnabled = false;
            bttnAtaque4.IsEnabled = false;
        }

        private void AtaqueCompletado(object sender, object e)
        {
            bttnAtaque1.IsEnabled = true;
            bttnAtaque2.IsEnabled = true;
            bttnAtaque3.IsEnabled = true;
            bttnAtaque4.IsEnabled = true;
        }

        private void ProteccionCompletada(object sender, object e)
        {
            barraEscudo.Value += 20;
            bttnAtaque1.IsEnabled = true;
            bttnAtaque2.IsEnabled = true;
            bttnAtaque3.IsEnabled = true;
            bttnAtaque4.IsEnabled = true;
        }

        private void regenerarVida(object sender, PointerRoutedEventArgs e)
        {
            if (!bttnVidaActivado)
            {
                bttnVidaActivado = true;
                miReloj.Interval = TimeSpan.FromMilliseconds(100);
                miReloj.Tick += subirVida;
                miReloj.Start();
                bttnVida.Opacity = 0.4;
            }
        }

        private void subirVida(object sender, object e)
        {
            barraVida.Value += 0.2;
            if (barraVida.Value >= 100)
            {
                miReloj.Stop();
                bttnVida.Opacity = 1;
                bttnVidaActivado = false;
            }
        }

        private void regenerarEnergia(object sender, PointerRoutedEventArgs e)
        {
            if (!bttnEnergiaActivado)
            {
                bttnEnergiaActivado = true;
                miReloj.Interval = TimeSpan.FromMilliseconds(100);
                miReloj.Tick += subirEnergia;
                miReloj.Start();
                bttnEnergia.Opacity = 0.4;
            }
        }

        private void subirEnergia(object sender, object e)
        {
            barraEnergia.Value += 0.2;
            if (barraEnergia.Value >= 100)
            {
                miReloj.Stop();
                bttnEnergia.Opacity = 1;
                bttnEnergiaActivado = false;
            }
        }

        private void realizarAtaque1(object sender, RoutedEventArgs e)
        {
            if (barraEnergia.Value - valorAtaque1 >= 0)
            {
                barraEnergia.Value -= valorAtaque1;
                DesactivarAtaques();
                Storyboard sb = (Storyboard)this.Resources["ColaFerreaKey"];
                sb.Begin();
            }
            else
            {
                AnimacionEnergiaInsuficiente();
            }

        }

        private void realizarAtaque2(object sender, RoutedEventArgs e)
        {
            if (barraEnergia.Value - valorAtaque2 >= 0)
            {
                barraEnergia.Value -= valorAtaque2;
                DesactivarAtaques();
                Storyboard sb = (Storyboard)this.Resources["PlacajeKey"];
                sb.Begin();
            }
            else
            {
                AnimacionEnergiaInsuficiente();
            }
        }

        private void realizarAtaque3(object sender, RoutedEventArgs e)
        {
            if (barraEnergia.Value - valorAtaque3 >= 0)
            {
                barraEnergia.Value -= valorAtaque3;
                DesactivarAtaques();
                Storyboard sb = (Storyboard)this.Resources["ProteccionKey"];
                sb.Begin();
            }
            else
            {
                AnimacionEnergiaInsuficiente();
            }
        }

        private void realizarAtaque4(object sender, RoutedEventArgs e)
        {
            if (barraEnergia.Value - valorAtaque4 >= 0)
            {
                barraEnergia.Value -= valorAtaque4;
                DesactivarAtaques();
                Storyboard sb = (Storyboard)this.Resources["RayoKey"];
                sb.Begin();
            }
            else
            {
                AnimacionEnergiaInsuficiente();
            }
        }

        private void AnimacionEnergiaInsuficiente()
        {
            Storyboard sb = (Storyboard)this.Resources["EnergiaInsuficienteKey"];
            sb.Begin();
        }

        private void realizarCosquillas(object sender, PointerRoutedEventArgs e)
        {
            Storyboard sb = (Storyboard)this.Resources["CosquillasKey"];
            sb.Begin();
        }

        private void realizarDestello(object sender, PointerRoutedEventArgs e)
        {
            Storyboard sb = (Storyboard)this.Resources["DestelloColaKey"];
            sb.Begin();
        }
    }
}
