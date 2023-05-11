using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;

/// <summary>
/// User control dedicado al pokemon Darumaka
/// Javier Santos Sanz
/// </summary>

namespace IPO2_Pokemon_Pokedex
{
    public sealed partial class UserControl_Darumaka : UserControl
    {
        /************************************************************************************************/

        /*Inicializacion de las variables globales*/

        DispatcherTimer dtTimeHealth;
        DispatcherTimer dtTimeEnergy;
        public Storyboard _sbSudorCD;
        public Storyboard _sbSudorCI;
        public Storyboard _sbSudorI;
        public Storyboard _sbSudorD;
        public Storyboard _sbDescanso;

        private Double health;
        private Double energy;



        /************************************************************************************************/

        /*Inicializacion de la pagina UserControl_Darumaka*/

        public UserControl_Darumaka()
        {
            this.InitializeComponent();
            health = pbHealth.Value;
            energy = pbEnergy.Value;
        }

        /************************************************************************************************/

        /*Variables y Metodos para el UserControl*/

        private bool verVida = true;
        private bool verEnergia = true;
        private bool verFondo = true;
        private bool verNombreyBotones = true;
        public string nombreAtaque1 = "Proteccion";
        public string nombreAtaque2 = "Descanso";
        public string nombreAtaque3 = "Tumba Rocas";
        public string nombreAtaque4 = "Llamarada";
        public double energiaAtaque1 = 10;
        public double energiaAtaque2 = 10;
        public double energiaAtaque3 = 10;
        public double energiaAtaque4 = 10;
        public double danoAtaque1 = 0;
        public double danoAtaque2 = 0;
        public double danoAtaque3 = 30;
        public double danoAtaque4 = 40;
        public double Vida
        {
            get { return health; }
            set { pbHealth.Value = value; }
        }
        public double Energia
        {
            get { return energy; }
            set { pbEnergy.Value = value; }
        }
        public bool VerVida
        {
            get { return verVida; }
            set
            {
                this.verVida = value;
                if (!verVida) this.GridPadre.RowDefinitions[0].Height = new GridLength(0);
                else this.GridPadre.RowDefinitions[0].Height = new GridLength(100,
                GridUnitType.Star);
            }
        }
        public bool VerEnergia
        {
            get { return verEnergia; }
            set
            {
                this.verEnergia = value;
                if (!verEnergia) this.GridPadre.RowDefinitions[1].Height = new GridLength(0);
                else this.GridPadre.RowDefinitions[1].Height = new GridLength(100,
                GridUnitType.Star);
            }
        }
        public bool VerFondo
        {
            get { return verFondo; }
            set
            {
                this.verFondo = value;
                if (!verFondo) this.imFondo.Opacity = 0;
                else this.imFondo.Opacity = 100;
            }
        }
        public bool VerNombreyBotones
        {
            get { return verNombreyBotones; }
            set
            {
                this.verNombreyBotones = value;
                if (!verNombreyBotones) this.GridPadre.RowDefinitions[3].Height = new GridLength(0);
                else this.GridPadre.RowDefinitions[3].Height = new GridLength(100,
                GridUnitType.Star);
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
            if (ReducirEnergía())
            {
                Storyboard sbProteger = (Storyboard)this.Resources["Proteger"];
                if (_sbDescanso != null) { _sbDescanso.Stop(); }
                sbProteger.Begin();
            }
        }
        public void realizarAtaque2()
        {
            _sbDescanso = (Storyboard)this.Resources["Descanso"];
            _sbDescanso.RepeatBehavior = RepeatBehavior.Forever;
            _sbDescanso.AutoReverse = true;
            _sbDescanso.Begin();
            //Regenerate();
            //EnergyRegeneration();
        }
        public void realizarAtaque3()
        {
            if (ReducirEnergía())
            {
                Storyboard sbTumbarocas = (Storyboard)this.Resources["Tumbarocas"];
                if (_sbDescanso != null) { _sbDescanso.Stop(); }
                sbTumbarocas.Begin();
            }
        }
        public void realizarAtaque4()
        {
            if (ReducirEnergía())
            {
                Storyboard sbLlamarada = (Storyboard)this.Resources["Llamarada"];
                if (_sbDescanso != null) { _sbDescanso.Stop(); }
                sbLlamarada.Begin();
            }
        }
        public void herirPokemon(double Dano)
        {
            if (this.pbHealth.Value > 0.0)
            {
                if (this.pbHealth.Value <= 10.0)
                {
                    this.pbHealth.Value = 0.0;
                    imgEspiralI.Visibility = Visibility.Visible;
                    imgEspiralD.Visibility = Visibility.Visible;
                    PupilaIzquierda.Visibility = Visibility.Collapsed;
                    Pupila_Derecha.Visibility = Visibility.Collapsed;
                }
                else
                {
                    this.pbHealth.Value -= Dano;
                }

                if (this.pbHealth.Value <= 10.0)
                {
                    imgTiritaD.Visibility = Visibility.Visible;
                }
                else if (this.pbHealth.Value <= 20.0)
                {
                    imgTiritaI.Visibility = Visibility.Visible;
                }
                else if (this.pbHealth.Value <= 30.0)
                {
                    imgTiritaC.Visibility = Visibility.Visible;
                }
            }
        }

        /************************************************************************************************/

        /*Botones y metodos de la propia Página*/
        public void CambiarFondo(String URI)
        {
            this.imFondo.Source = new BitmapImage(new Uri(@URI));
        }

        private void usePotionRed(object sender, PointerRoutedEventArgs e)
        {
            Regenerate();
        }
        private void Regenerate()
        {
            dtTimeHealth = new DispatcherTimer();
            dtTimeHealth.Interval = TimeSpan.FromMilliseconds(100);
            dtTimeHealth.Tick += increaseHealth;
            dtTimeHealth.Start();
            this.imRPotion.Opacity = 0.5;
            btLlamarada.IsEnabled = false;
            btTumbarocas.IsEnabled = false;
            btProteccion.IsEnabled = false;

            imgTiritaC.Visibility = Visibility.Collapsed;
            imgTiritaD.Visibility = Visibility.Collapsed;
            imgTiritaI.Visibility = Visibility.Collapsed;

            imgEspiralD.Visibility = Visibility.Collapsed;
            imgEspiralI.Visibility = Visibility.Collapsed;
            Pupila_Derecha.Visibility = Visibility.Visible;
            PupilaIzquierda.Visibility = Visibility.Visible;
        }
        private void increaseHealth(object sender, object e)
        {
            this.pbHealth.Value += 2.0;
            if (this.pbHealth.Value >= 100)
            {
                this.dtTimeHealth.Stop();
                this.imRPotion.Opacity = 1;
                btLlamarada.IsEnabled = true;
                btTumbarocas.IsEnabled = true;
                btProteccion.IsEnabled = true;
            }
        }
        private void btProteccion_Click(object sender, RoutedEventArgs e)
        {
            realizarAtaque1();

        }
        private void btDescanso_Click(object sender, RoutedEventArgs e)
        {
            realizarAtaque2();
        }
        private void btTumbarocas_Click(object sender, RoutedEventArgs e)
        {
            realizarAtaque3();
        }
        private void btLlamarada_Click(object sender, RoutedEventArgs e)
        {
            realizarAtaque4();
        }
        private Boolean ReducirEnergía()
        {
            if (pbEnergy.Value >= 10.0)
            {
                pbEnergy.Value -= 10.0;

                if (pbEnergy.Value <= 10.00)
                {
                    _sbSudorCI = (Storyboard)this.Resources["sbSudorCI"];
                    _sbSudorCI.RepeatBehavior = RepeatBehavior.Forever;
                    _sbSudorCI.Begin();
                }
                else if (pbEnergy.Value <= 20.00)
                {
                    _sbSudorCD = (Storyboard)this.Resources["sbSudorCD"];
                    _sbSudorCD.RepeatBehavior = RepeatBehavior.Forever;
                    _sbSudorCD.Begin();
                }
                else if (pbEnergy.Value <= 30.00)
                {
                    _sbSudorI = (Storyboard)this.Resources["sbSudorI"];
                    _sbSudorI.RepeatBehavior = RepeatBehavior.Forever;
                    _sbSudorI.Begin();
                }

                else if (pbEnergy.Value <= 40.00)
                {
                    _sbSudorD = (Storyboard)this.Resources["sbSudorD"];
                    _sbSudorD.RepeatBehavior = RepeatBehavior.Forever;
                    _sbSudorD.Begin();
                }
                return true;
            }
            return false;
        }
        private void InfligirDano(object sender, PointerRoutedEventArgs e)
        {
            herirPokemon(10.00);
        }
        private void UseEnergyPotion(object sender, PointerRoutedEventArgs e)
        {
            EnergyRegeneration();
        }
        private void EnergyRegeneration()
        {
            dtTimeEnergy = new DispatcherTimer();
            dtTimeEnergy.Interval = TimeSpan.FromMilliseconds(100);
            dtTimeEnergy.Tick += increaseEnergy;
            dtTimeEnergy.Start();
            this.imYPotion.Opacity = 0.5;
            if (_sbSudorI != null) { _sbSudorI.Stop(); }
            if (_sbSudorCI != null) { _sbSudorCI.Stop(); }
            if (_sbSudorCD != null) { _sbSudorCD.Stop(); }
            if (_sbSudorD != null) { _sbSudorD.Stop(); }
        }
        private void increaseEnergy(object sender, object e)
        {
            this.pbEnergy.Value += 2.0;
            if (pbEnergy.Value >= 100)
            {
                this.dtTimeEnergy.Stop();
                this.imYPotion.Opacity = 1;
            }
        }

    }
}
