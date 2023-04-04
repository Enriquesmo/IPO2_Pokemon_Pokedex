using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Linq;
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

/// <summary>
/// User control dedicado al pokemon Raichu
/// Alonso Crespo Fernández
/// </summary>

namespace IPO2_Pokemon_Pokedex
{
    public sealed partial class UserControl_Raichu : UserControl
    {
        /************************************************************************************************/

        /*Inicializacion de las variables globales*/

        DispatcherTimer miReloj;
        bool bttnVidaActivado = false;
        bool bttnEnergiaActivado = false;
        private bool verVida = true;
        private bool verEnergia = true;
        private bool verFondo = true;
        private bool verNombreyBotones = true;
        double valorAtaque1 = 15;
        double valorAtaque2 = 10;
        double valorAtaque3 = 20;
        double valorAtaque4 = 30;

        /************************************************************************************************/

        /*Inicializacion de la pagina UserControl_Raichu*/

        public UserControl_Raichu()
        {
            this.InitializeComponent();
            miReloj = new DispatcherTimer();
        }

        /************************************************************************************************/

        /*Variables y Metodos para el UserControl*/

        public bool VerVida
        {
            get { return verVida; }
            set
            {
                this.verVida = value;
                if (!verVida) this.Grid_HUD.RowDefinitions[0].Height = new GridLength(0);
                else this.Grid_HUD.RowDefinitions[0].Height = new GridLength(10,
               GridUnitType.Star);
            }
        }
        public bool VerEnergia
        {
            get { return verEnergia; }
            set
            {
                this.verEnergia = value;
                if (!verEnergia) this.Grid_HUD.RowDefinitions[1].Height = new GridLength(0);
                else this.Grid_HUD.RowDefinitions[1].Height = new GridLength(10,
               GridUnitType.Star);
            }
        }
        public bool VerFondo
        {
            get { return verFondo; }
            set
            {
                this.verFondo = value;
                if (!verFondo) this.imgFondo.Opacity = 0;
                else this.imgFondo.Opacity = 100;
            }
        }
        public bool VerNombreyBotones
        {
            get { return verNombreyBotones; }
            set
            {
                this.verNombreyBotones = value;
                if (!verNombreyBotones) this.Grid_HUD.RowDefinitions[3].Height = new GridLength(0);
                else this.Grid_HUD.RowDefinitions[3].Height = new GridLength(100,
               GridUnitType.Star);
            }
        }
        public double Vida
        {
            get { return this.barraVida.Value; }
            set { this.barraVida.Value = value; }
        }
        public double Energia
        {
            get { return this.barraEnergia.Value; }
            set { this.barraEnergia.Value = value; }
        }
        public double Escudo
        {
            get { return this.barraEscudo.Value; }
            set { this.barraEscudo.Value = value; }
        }
        public void verFormaPokedex(bool ver)
        {
            if (ver)
            {
                VerVida = true;
                VerEnergia = true;
                VerFondo = true;
                VerNombreyBotones = true;
            }
            else
            {
                VerVida = false;
                VerEnergia = false;
                VerFondo = false;
                VerNombreyBotones = false;
            }
        }
        public void herirPokemon(double damage) // Terminado
        {
            if (Escudo > damage)
                Escudo -= damage;
            else
            {
                double dañoRestante = Escudo - damage;
                Escudo = 0;
                if (Vida > dañoRestante)
                    Vida -= dañoRestante;
                else
                {
                    Vida = 0;
                }

            }
        }
        private void DesactivarAtaques()
        {
            bttnAtaque1.IsEnabled = false;
            bttnAtaque2.IsEnabled = false;
            bttnAtaque3.IsEnabled = false;
            bttnAtaque4.IsEnabled = false;
        }
        public void realizarAtaque1() // Terminado
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
        public void realizarAtaque2() // Terminado
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
        public void realizarAtaque3() // Terminado
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
        public void realizarAtaque4() // Terminado
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

        /************************************************************************************************/

        /*Botones y metodos de la propia Página*/

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