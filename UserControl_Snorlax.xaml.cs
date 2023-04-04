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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

/// <summary>
/// User control dedicado al pokemon Snorlax
/// Felipe Alcázar Gómez
/// </summary>

namespace IPO2_Pokemon_Pokedex
{
    public sealed partial class UserControl_Snorlax : UserControl
    {
        /************************************************************************************************/

        /*Inicializacion de las variables globales*/

        public Double currentSpellAmount = 0;
        public Double currentHealthAmount = 0;
        private bool verVida = true;
        private bool verEnergia = true;
        private bool verFondo = true;
        private bool verNombreyBotones = true;

        private Button myButton;

        /************************************************************************************************/

        /*Inicializacion de la pagina UserControl_Snorlax*/

        public UserControl_Snorlax()
        {
            this.InitializeComponent();
            currentSpellAmount = Energia;
            currentHealthAmount = Vida;

            Storyboard sb = (Storyboard)this.Resources["sbMoverBrazos"];
            sb.AutoReverse = true;
            sb.RepeatBehavior = RepeatBehavior.Forever;
            sb.Begin();

            Storyboard sb2 = (Storyboard)this.Resources["sbSaltar"];
            sb2.AutoReverse = true;
            sb2.Begin();

            myButton = (Button)this.FindName("btnBodySlam");

        }

        /************************************************************************************************/

        /*Variables y Metodos para el UserControl*/

        public double Vida
        {
            get { return this.barHP.Value; }
            set { this.barHP.Value = value; }
        }
        public double Energia
        {
            get { return this.barSpell.Value; }
            set { this.barSpell.Value = value; }
        }
        public bool VerVida
        {
            get { return verVida; }
            set
            {
                this.verVida = value;
                if (!verVida)
                {
                    this.GridApp.RowDefinitions[0].Height = new GridLength(0);
                }
                else
                {
                    this.GridApp.RowDefinitions[0].Height = new GridLength(10, GridUnitType.Star);
                }
            }
        }
        public bool VerEnergia
        {
            get { return verEnergia; }
            set
            {
                this.verEnergia = value;
                if (!verEnergia) this.GridApp.RowDefinitions[1].Height = new GridLength(0);
                else this.GridApp.RowDefinitions[1].Height = new GridLength(10,
               GridUnitType.Star);
            }
        }
        public bool VerFondo
        {
            get { return verFondo; }
            set
            {
                this.verFondo = value;
                if (!verFondo) this.imgBackground.Opacity = 0;
                else this.imgBackground.Opacity = 100;
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
                    this.GridApp.RowDefinitions[2].Height = new GridLength(0);
                    this.GridApp.RowDefinitions[4].Height = new GridLength(0);
                }
                else
                {
                    this.GridApp.RowDefinitions[2].Height = new GridLength(100, GridUnitType.Star);
                    this.GridApp.RowDefinitions[4].Height = new GridLength(100, GridUnitType.Star);
                }
            }
        }
        public ImageSource FondoSource
        {
            get { return this.imgBackground.Source; }
            set { this.imgBackground.Source = value; }
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
        public void realizarAtaque1()
        {
            Boolean sePuede = restarBarraEnergia(20);
            if (sePuede == true)
            {
                Storyboard sbDormir = (Storyboard)this.Resources["sbDormir"];
                sbDormir.Begin();
            }
        }
        public void realizarAtaque2()
        {
            Boolean sePuede = restarBarraEnergia(20);
            if (sePuede == true)
            {
                Storyboard sbBodySlam = (Storyboard)this.Resources["sbBodySlam"];
                sbBodySlam.Begin();
            }
        }
        public void realizarAtaque3()
        {
            Boolean sePuede = incrementarBarraVida(20);
            if (sePuede == true)
            {
                Storyboard enfado = (Storyboard)this.Resources["sbEnfado"];
                enfado.Begin();
            }
        }
        public void realizarAtaque4()
        {
            Boolean sePuede = restarBarraEnergia(20);
            if (sePuede == true)
            {
                Storyboard sbHipnotizar = (Storyboard)this.Resources["sbHipnotizar"];
                sbHipnotizar.Begin();
            }
        }
        public void herirPokemon(double damage)
        {
            restarBarraVida(damage);
        }

        /************************************************************************************************/

        /*Botones y metodos de la propia Página*/

        private void restarBarraVida(double valorARestar) // Terminado
        {
            this.barHP.Value -= valorARestar;
            this.imgHealthIcon.Opacity = 1;
        }
        private Boolean restarBarraEnergia(int valorARestar) // Terminado
        {
            Boolean sePuede = false;
            if (barSpell.Value >= valorARestar)
            {
                this.barSpell.Value -= valorARestar;
                this.imgMana.Opacity = 1;
                sePuede = true;
            }
            return sePuede;
        }

        private Boolean incrementarBarraVida(int valorASumar) // Terminado
        {
            Boolean sePuede = false;
            if (barHP.Value + valorASumar >= 100)
            {
                this.barHP.Value = 100;
                this.imgHealthIcon.Opacity = 1;
                sePuede = true;
            }
            else
            {
                this.barHP.Value += valorASumar;
                this.imgHealthIcon.Opacity = 1;
                sePuede = true;
            }
            return sePuede;
        }

        private Boolean incrementarBarraSpell(int valorASumar) // Terminado
        {
            Boolean sePuede = false;
            if (barSpell.Value + valorASumar >= 100)
            {
                this.barSpell.Value = 100;
                this.imgMana.Opacity = 1;
                sePuede = true;
            }
            else
            {
                this.barSpell.Value += valorASumar;
                this.imgMana.Opacity = 1;
                sePuede = true;
            }
            return sePuede;
        }

        public Boolean comprobarEstadoCritico()
        {
            Boolean estadoCritico = false;

            Storyboard sb = (Storyboard)this.Resources["sbCritico"];
            Storyboard sb2 = (Storyboard)this.Resources["sbPocaVida"];
            if (Vida <= 30)
            {
                sb.RepeatBehavior = RepeatBehavior.Forever;
                sb.Begin();
                sb2.RepeatBehavior = RepeatBehavior.Forever;
                sb2.Begin();
                estadoCritico = true;
            }
            else
            {
                sb.Stop();
                sb2.Stop();
            }

            return estadoCritico;
        }
        private void imgHealthIconRestorePointerReleased(object sender, PointerRoutedEventArgs e)
        {
            incrementarBarraVida(20);
        }
        private void imgManaPotion_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            incrementarBarraSpell(20);
        }
        private void pathOjoIzq_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            Storyboard sb = (Storyboard)this.pathOjoIzq.Resources["animarOjoIzqKey"];
            sb.Begin();
        }
        private void pathOjoDer_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            Storyboard sb = (Storyboard)this.pathOjoDer.Resources["animarOjoDerKey"];
            sb.Begin();
        }
        private void pathCuerpo_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            DoubleAnimation da = new DoubleAnimation();
            Storyboard sb = new Storyboard();
            sb.Duration = new Duration(TimeSpan.FromMilliseconds(300));
            sb.Children.Add(da);
            sb.BeginTime = TimeSpan.FromSeconds(0);
            pathCuerpo.RenderTransform = (Transform)new ScaleTransform();
            Storyboard.SetTarget(da, pathCuerpo.RenderTransform);
            Storyboard.SetTargetProperty(da, "ScaleY");
            da.From = 1;
            da.To = 1.1;
            sb.AutoReverse = true;
            sb.RepeatBehavior = new RepeatBehavior(3);
            sb.Begin();

        }

        private void btnDormir_Click(object sender, RoutedEventArgs e)
        {
            Boolean sePuede = restarBarraEnergia(20);
            if (sePuede == true)
            {
                Storyboard sbDormir = (Storyboard)this.Resources["sbDormir"];
                sbDormir.Begin();
            }
        }

        private void btnBodySlam_Click(object sender, RoutedEventArgs e)
        {
            Boolean sePuede = restarBarraEnergia(20);
            if (sePuede == true)
            {
                Storyboard sbBodySlam = (Storyboard)this.Resources["sbBodySlam"];
                sbBodySlam.Begin();
            }
        }

        private void btnEnfado_Click(object sender, RoutedEventArgs e)
        {
            Boolean sePuede = incrementarBarraVida(20);
            if (sePuede == true)
            {
                Storyboard enfado = (Storyboard)this.Resources["sbEnfado"];
                enfado.Begin();
            }
        }

        private void btnHipnotizar_Click(object sender, RoutedEventArgs e)
        {
            Boolean sePuede = restarBarraEnergia(20);
            if (sePuede == true)
            {
                Storyboard sbHipnotizar = (Storyboard)this.Resources["sbHipnotizar"];
                sbHipnotizar.Begin();
            }
        }
    }
}