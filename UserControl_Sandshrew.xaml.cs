using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
/// User control dedicado al pokemon Sandshrew
/// Enrique Sánchez-Migallón Ochoa
/// </summary>

namespace IPO2_Pokemon_Pokedex
{
    public sealed partial class UserControl_Sandshrew : UserControl
    {
        /************************************************************************************************/

        /*Inicializacion de las variables globales*/

        DispatcherTimer dtTimeVida;
        DispatcherTimer dtTimeEnergia;

        /************************************************************************************************/

        /*Inicializacion de la pagina UserControl_Sandshrew*/

        public UserControl_Sandshrew() // Terminado
        {
            this.InitializeComponent();
            dtTimeVida = new DispatcherTimer();
            dtTimeEnergia = new DispatcherTimer();
            ocultarElementosExtras();
        }
        
        /************************************************************************************************/

        /*Variables y Metodos para el UserControl*/

        private bool verVida = true;
        private bool verEnergia = true;
        private bool verFondo = true;
        private bool verNombreyBotones = true;
        public double Vida
        {
            get { return this.ProgressBar_Vida.Value; }
            set { this.ProgressBar_Vida.Value = value; }
        }
        public double Energia
        {
            get { return this.ProgressBar_Energia.Value; }
            set { this.ProgressBar_Energia.Value = value; }
        }
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
                if (!verFondo) this.imagenFondo.Opacity = 0;
                else this.imagenFondo.Opacity = 100;
            }
        }
        public bool VerNombreyBotones
        {
            get { return verNombreyBotones; }
            set
            {
                this.verNombreyBotones = value;
                if (!verNombreyBotones)
                {
                    this.Grid_HUD.RowDefinitions[3].Height = new GridLength(0);
                    btn_CuartoAtaque.Visibility = Visibility.Collapsed;
                    btn_SegundoAtaque.Visibility = Visibility.Collapsed;
                    btn_PrimerAtaque.Visibility = Visibility.Collapsed;
                    btn_TercerAtaque.Visibility = Visibility.Collapsed;
                }
                else
                {
                    this.Grid_HUD.RowDefinitions[3].Height = new GridLength(10,GridUnitType.Star);
                    btn_CuartoAtaque.Visibility = Visibility.Visible;
                    btn_SegundoAtaque.Visibility = Visibility.Visible;
                    btn_PrimerAtaque.Visibility = Visibility.Visible;
                    btn_TercerAtaque.Visibility = Visibility.Visible;
                }
            }
        }
        public void verFormaPokedex(bool ver)
        {
            if (ver)
            {
                VerVida = true;
                VerEnergia = true;
                VerFondo = true;
                VerNombreyBotones = true;
                btn_PrimerAtaque.Visibility = Visibility.Visible;
                btn_SegundoAtaque.Visibility = Visibility.Visible;
                btn_TercerAtaque.Visibility = Visibility.Visible;
                btn_CuartoAtaque.Visibility = Visibility.Visible;
                TextBlock_NombrePokemon.Visibility = Visibility.Visible;
                btn_Herir.Visibility = Visibility.Visible;
            }
            else
            {
                VerVida = false;
                VerEnergia = false;
                VerFondo = false;
                VerNombreyBotones = false;
                btn_PrimerAtaque.Visibility = Visibility.Collapsed;
                btn_SegundoAtaque.Visibility = Visibility.Collapsed;
                btn_TercerAtaque.Visibility = Visibility.Collapsed;
                btn_CuartoAtaque.Visibility = Visibility.Collapsed;
                TextBlock_NombrePokemon.Visibility = Visibility.Collapsed;
                btn_Herir.Visibility = Visibility.Collapsed;
            }
        }
        public void realizarAtaque1() // Terminado
        {
            Boolean sePuede = restarBarraEnergia(20);
            if (sePuede == true)
            {
                Storyboard sb = (Storyboard)this.Resources["Ataque1_Arañazo"];
                sb.Begin();
                Ataque1_ImagenArañazo.Visibility = Visibility.Visible;
                opacityElementosExtras();
            }
            else
            {
                animacionNoEnergia();
            }
        }
        public void realizarAtaque2() // Terminado
        {
            Boolean sePuede = restarBarraEnergia(10);
            if (sePuede == true)
            {
                Storyboard sb = (Storyboard)this.Resources["Ataque2_AtaqueArena"];
                Ataque2_Arena1.Visibility = Visibility.Visible;
                Ataque2_Arena2.Visibility = Visibility.Visible;
                Ataque2_Arena3.Visibility = Visibility.Visible;
                Ataque2_Arena4.Visibility = Visibility.Visible;
                sb.Begin();
                opacityElementosExtras();
            }
            else
            {
                animacionNoEnergia();
            }
        }
        public void realizarAtaque3() // Terminado
        {
            Boolean sePuede = restarBarraEnergia(25);
            if (sePuede == true)
            {
                Ataque3_FlechaVenenosa.Visibility = Visibility.Visible;
                Ataque3_BurbujasVeneno.Visibility = Visibility.Visible;
                Storyboard sb = (Storyboard)this.Resources["Ataque3_PicotazoVen"];
                sb.Begin();
                Storyboard sbIzquierdo = (Storyboard)this.Ellipse_Ojo_Izquierdo_Blanco.Resources["ojoIzquierdoMoradoKey"];
                sbIzquierdo.Begin();
                Storyboard sbDerecho = (Storyboard)this.Ellipse_Ojo_Derecho_Blanco.Resources["ojoDerechoMoradoKey"];
                sbDerecho.Begin();
                opacityElementosExtras();
            }
            else
            {
                animacionNoEnergia();
            }
        }
        public void realizarAtaque4() // Terminado
        {
            Boolean sePuede = restarBarraEnergia(40);
            if (sePuede == true)
            {
                Storyboard sb = (Storyboard)this.Resources["Ataque4_Terremoto"];
                sb.Begin();
                Ataque4_Grieta1.Visibility = Visibility.Visible;
                Ataque4_Grieta2.Visibility = Visibility.Visible;
                Ataque4_Grieta3.Visibility = Visibility.Visible;
                Ataque4_Grieta4.Visibility = Visibility.Visible;
                Ataque4_Grieta5.Visibility = Visibility.Visible;
                opacityElementosExtras();
            }
            else
            {
                animacionNoEnergia();
            }
        }
        public void herirPokemon(double damage) // Terminado
        {
            restarBarraVida(damage);
            if (this.ProgressBar_Vida.Value <= 50 && this.ProgressBar_Vida.Value > 25)
            {
                Vida50_Tirita1.Visibility = Visibility.Visible;
                Vida50_Tirita1.Opacity = 100;
                Vida50_Tirita2.Visibility = Visibility.Visible;
                Vida50_Tirita2.Opacity = 100;
                Vida50_Tirita3.Visibility = Visibility.Visible;
                Vida50_Tirita3.Opacity = 100;
            }
            else if (this.ProgressBar_Vida.Value <= 25 && this.ProgressBar_Vida.Value > 0)
            {
                Vida25_Arañazo1.Visibility = Visibility.Visible;
                Vida25_Arañazo1.Opacity = 100;
                Vida25_Arañazo2.Visibility = Visibility.Visible;
                Vida25_Arañazo2.Opacity = 100;
                Vida25_Arañazo3.Visibility = Visibility.Visible;
                Vida25_Arañazo3.Opacity = 100;
                Vida25_Arañazo4.Visibility = Visibility.Visible;
                Vida25_Arañazo4.Opacity = 100;
            }
            else if (this.ProgressBar_Vida.Value <= 0)
            {
                animacionVida0();
                opacityElementosExtras();
            }
        }

        /************************************************************************************************/

        /*Botones de la propia Página*/

        private void Image_Pocion_De_Vida_PointerReleased(object sender, PointerRoutedEventArgs e) // Terminado
        {
            if (ProgressBar_Vida.Value > 0)
            {
                dtTimeVida = new DispatcherTimer();
                dtTimeVida.Interval = TimeSpan.FromMilliseconds(10); // Esto lo he cambiado para que se vea más fluido, deberia ser 100 milisegundos
                dtTimeVida.Tick += increaseHealth;
                dtTimeVida.Start();
                this.Image_Pocion_De_Vida.Opacity = 0.5;
            }
        }
        private void Image_Pocion_De_Energia_PointerReleased(object sender, PointerRoutedEventArgs e) // Terminado
        {
            if (ProgressBar_Vida.Value > 0)
            {
                dtTimeEnergia = new DispatcherTimer();
                dtTimeEnergia.Interval = TimeSpan.FromMilliseconds(10); // Esto lo he cambiado para que se vea más fluido, deberia ser 100 milisegundos
                dtTimeEnergia.Tick += increaseEnergy;
                dtTimeEnergia.Start();
                this.Image_Pocion_De_Energia.Opacity = 0.5;
            }
        }
        private void Btn_PrimerAtaque_Click(object sender, RoutedEventArgs e) // Terminado
        {
            Boolean sePuede = restarBarraEnergia(20);
            if (sePuede == true)
            {
                Storyboard sb = (Storyboard)this.Resources["Ataque1_Arañazo"];
                sb.Begin();
                Ataque1_ImagenArañazo.Visibility = Visibility.Visible;
                opacityElementosExtras();
            }
            else
            {
                animacionNoEnergia();
            }
        }
        private void btn_SegundoAtaque_Click(object sender, RoutedEventArgs e) // Terminado
        {
            Boolean sePuede = restarBarraEnergia(10);
            if (sePuede == true)
            {
                Storyboard sb = (Storyboard)this.Resources["Ataque2_AtaqueArena"];
                Ataque2_Arena1.Visibility = Visibility.Visible;
                Ataque2_Arena2.Visibility = Visibility.Visible;
                Ataque2_Arena3.Visibility = Visibility.Visible;
                Ataque2_Arena4.Visibility = Visibility.Visible;
                sb.Begin();
                opacityElementosExtras();
            }
            else
            {
                animacionNoEnergia();
            }
        }
        private void btn_TercerAtaque_Click(object sender, RoutedEventArgs e) // Terminado
        {
            Boolean sePuede = restarBarraEnergia(25);
            if (sePuede == true)
            {
                Ataque3_FlechaVenenosa.Visibility = Visibility.Visible;
                Ataque3_BurbujasVeneno.Visibility = Visibility.Visible;
                Storyboard sb = (Storyboard)this.Resources["Ataque3_PicotazoVen"];
                sb.Begin();
                Storyboard sbIzquierdo = (Storyboard)this.Ellipse_Ojo_Izquierdo_Blanco.Resources["ojoIzquierdoMoradoKey"];
                sbIzquierdo.Begin();
                Storyboard sbDerecho = (Storyboard)this.Ellipse_Ojo_Derecho_Blanco.Resources["ojoDerechoMoradoKey"];
                sbDerecho.Begin();
                opacityElementosExtras();
            }
            else
            {
                animacionNoEnergia();
            }
        }
        private void btn_CuartoAtaque_Click(object sender, RoutedEventArgs e) // Terminado
        {
            Boolean sePuede = restarBarraEnergia(40);
            if (sePuede == true)
            {
                Storyboard sb = (Storyboard)this.Resources["Ataque4_Terremoto"];
                sb.Begin();
                Ataque4_Grieta1.Visibility = Visibility.Visible;
                Ataque4_Grieta2.Visibility = Visibility.Visible;
                Ataque4_Grieta3.Visibility = Visibility.Visible;
                Ataque4_Grieta4.Visibility = Visibility.Visible;
                Ataque4_Grieta5.Visibility = Visibility.Visible;
                opacityElementosExtras();
            }
            else
            {
                animacionNoEnergia();
            }
        }
        private void btn_Herir_Click(object sender, RoutedEventArgs e) // Terminado
        {
            restarBarraVida(25);
            if (this.ProgressBar_Vida.Value <= 50 && this.ProgressBar_Vida.Value > 25)
            {
                Vida50_Tirita1.Visibility = Visibility.Visible;
                Vida50_Tirita1.Opacity = 100;
                Vida50_Tirita2.Visibility = Visibility.Visible;
                Vida50_Tirita2.Opacity = 100;
                Vida50_Tirita3.Visibility = Visibility.Visible;
                Vida50_Tirita3.Opacity = 100;
            }
            else if (this.ProgressBar_Vida.Value <= 25 && this.ProgressBar_Vida.Value > 0)
            {
                Vida25_Arañazo1.Visibility = Visibility.Visible;
                Vida25_Arañazo1.Opacity = 100;
                Vida25_Arañazo2.Visibility = Visibility.Visible;
                Vida25_Arañazo2.Opacity = 100;
                Vida25_Arañazo3.Visibility = Visibility.Visible;
                Vida25_Arañazo3.Opacity = 100;
                Vida25_Arañazo4.Visibility = Visibility.Visible;
                Vida25_Arañazo4.Opacity = 100;
            }
            else if (this.ProgressBar_Vida.Value <= 0)
            {
                animacionVida0();
                opacityElementosExtras();
            }
        }

        /************************************************************************************************/

        /*Metodos Auxiliares para los botones e imagenes*/

        private void increaseHealth(object sender, object e) // Terminado
        {
            this.ProgressBar_Vida.Value += 0.2;
            if (ProgressBar_Vida.Value >= 25)
            {
                Vida25_Arañazo1.Visibility = Visibility.Collapsed;
                Vida25_Arañazo2.Visibility = Visibility.Collapsed;
                Vida25_Arañazo3.Visibility = Visibility.Collapsed;
                Vida25_Arañazo4.Visibility = Visibility.Collapsed;
            }
            if (ProgressBar_Vida.Value >= 50)
            {
                Vida50_Tirita1.Visibility = Visibility.Collapsed;
                Vida50_Tirita2.Visibility = Visibility.Collapsed;
                Vida50_Tirita3.Visibility = Visibility.Collapsed;
            }
            if (ProgressBar_Vida.Value >= 100)
            {
                this.dtTimeVida.Stop();
                this.Image_Pocion_De_Vida.Opacity = 1;
            }
        }
        private void increaseEnergy(object sender, object e) // Terminado
        {
            this.ProgressBar_Energia.Value += 0.2;
            if (ProgressBar_Energia.Value >= 100)
            {
                this.dtTimeEnergia.Stop();
                this.Image_Pocion_De_Energia.Opacity = 1;
            }
        }
        private Boolean restarBarraEnergia(int valorARestar) // Terminado
        {
            Boolean sePuede = false;
            if (ProgressBar_Energia.Value >= valorARestar)
            {
                this.ProgressBar_Energia.Value -= valorARestar;
                dtTimeEnergia.Stop();
                this.Image_Pocion_De_Energia.Opacity = 1;
                sePuede = true;
            }
            return sePuede;
        }
        private void restarBarraVida(double valorARestar) // Terminado
        {
            this.ProgressBar_Vida.Value -= valorARestar;
            dtTimeVida.Stop();
            this.Image_Pocion_De_Vida.Opacity = 1;
        }
        private void animacionVida0() // Terminado
        {
            Vida0_OjoDerecho.Visibility = Visibility.Visible;
            Vida0_OjoIzquierdo.Visibility = Visibility.Visible;
            Ojo_Derecho.Visibility = Visibility.Collapsed;
            Ojo_Izquierdo.Visibility = Visibility.Collapsed;
            Storyboard sb = (Storyboard)this.Resources["vida0"];
            sb.Begin();
            estadoBotones(false);
        }
        private void ocultarElementosExtras() // Terminado
        {
            Vida50_Tirita1.Visibility = Visibility.Collapsed;
            Vida50_Tirita2.Visibility = Visibility.Collapsed;
            Vida50_Tirita3.Visibility = Visibility.Collapsed;
            Vida25_Arañazo1.Visibility = Visibility.Collapsed;
            Vida25_Arañazo2.Visibility = Visibility.Collapsed;
            Vida25_Arañazo3.Visibility = Visibility.Collapsed;
            Vida25_Arañazo4.Visibility = Visibility.Collapsed;
            Vida0_OjoDerecho.Visibility = Visibility.Collapsed;
            Vida0_OjoIzquierdo.Visibility = Visibility.Collapsed;
            Ataque1_ImagenArañazo.Visibility = Visibility.Collapsed;
            Ataque2_Arena1.Visibility = Visibility.Collapsed;
            Ataque2_Arena2.Visibility = Visibility.Collapsed;
            Ataque2_Arena3.Visibility = Visibility.Collapsed;
            Ataque2_Arena4.Visibility = Visibility.Collapsed;
            Ataque3_FlechaVenenosa.Visibility = Visibility.Collapsed;
            Ataque3_BurbujasVeneno.Visibility = Visibility.Collapsed;
            Ataque4_Grieta1.Visibility = Visibility.Collapsed;
            Ataque4_Grieta2.Visibility = Visibility.Collapsed;
            Ataque4_Grieta3.Visibility = Visibility.Collapsed;
            Ataque4_Grieta4.Visibility = Visibility.Collapsed;
            Ataque4_Grieta5.Visibility = Visibility.Collapsed;
            NoEnergia_Bocadillo.Visibility = Visibility.Collapsed;
        }
        private void opacityElementosExtras() // Terminado
        {
            Ataque1_ImagenArañazo.Opacity = 0;
            Ataque2_Arena1.Opacity = 0;
            Ataque2_Arena2.Opacity = 0;
            Ataque2_Arena3.Opacity = 0;
            Ataque2_Arena4.Opacity = 0;
            Ataque3_FlechaVenenosa.Opacity = 0;
            Ataque3_BurbujasVeneno.Opacity = 0;
            Ataque4_Grieta1.Opacity = 0;
            Ataque4_Grieta2.Opacity = 0;
            Ataque4_Grieta3.Opacity = 0;
            Ataque4_Grieta4.Opacity = 0;
            Ataque4_Grieta5.Opacity = 0;
            NoEnergia_Bocadillo.Opacity = 0;
        }
        private void animacionNoEnergia() // Terminado
        {
            Storyboard sb = (Storyboard)this.Resources["NoEnergía"];
            sb.Begin();
            opacityElementosExtras();
            NoEnergia_Bocadillo.Visibility = Visibility.Visible;
        }
        private void estadoBotones(Boolean estado) // Terminado
        {
            btn_PrimerAtaque.IsEnabled = estado;
            btn_SegundoAtaque.IsEnabled = estado;
            btn_TercerAtaque.IsEnabled = estado;
            btn_CuartoAtaque.IsEnabled = estado;
            btn_Herir.IsEnabled = estado;
        }
    }
}