﻿using System;
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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Practice2_IPO
{
    public sealed partial class PokemonSnorlax : UserControl
    {
        public Double currentSpellAmount = 0;
        public Double currentHealthAmount = 0;
        DispatcherTimer clock;

        private DispatcherTimer cooldownTimer = new DispatcherTimer();
        private Button myButton;
        public double Vida
        {
            get { return this.barHP.Value; }
            set { this.barHP.Value = value; }
        }

        public double Spell
        {
            get { return this.barSpell.Value; }
            set { this.barSpell.Value = value; }
        }

        public ImageSource FondoSource {
            get { return this.imgBackground.Source; }
            set { this.imgBackground.Source = value; } 
        }

        public void verFondo(bool ver)
        {
            if (ver) imgBackground.Visibility = Visibility.Visible;
            else imgBackground.Visibility = Visibility.Collapsed;
        }

        public void verFormaPokedex(bool ver)
        {
            if (ver)
            {
                barHP.Visibility = Visibility.Collapsed;
                barSpell.Visibility = Visibility.Collapsed;
                imgHealthIRestore.Visibility = Visibility.Collapsed;
                imgManaPotion.Visibility = Visibility.Collapsed;
                imgMana.Visibility = Visibility.Collapsed;
                imgHealthIcon.Visibility = Visibility.Collapsed;
                btnDormir.Visibility = Visibility.Collapsed;
                btnBodySlam.Visibility = Visibility.Collapsed;
                btnEnfado.Visibility = Visibility.Collapsed;
                btnHipnotizar.Visibility = Visibility.Collapsed;
                txtCoolDown.Visibility = Visibility.Collapsed;
                txtName.Visibility = Visibility.Collapsed;
            }
            else {
                barHP.Visibility = Visibility.Visible;
                barSpell.Visibility = Visibility.Visible;
                imgHealthIRestore.Visibility = Visibility.Visible;
                imgManaPotion.Visibility = Visibility.Visible;
                imgMana.Visibility = Visibility.Visible;
                imgHealthIcon.Visibility = Visibility.Visible;
                btnDormir.Visibility = Visibility.Visible;
                btnBodySlam.Visibility = Visibility.Visible;
                btnEnfado.Visibility = Visibility.Visible;
                btnHipnotizar.Visibility = Visibility.Visible;
                txtCoolDown.Visibility = Visibility.Visible;
                txtName.Visibility = Visibility.Visible;
            }
        }

        public Boolean comprobarEstadoCritico()
        {
            Boolean estadoCritico=false;

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

        public PokemonSnorlax()
        {
            this.InitializeComponent();
            currentSpellAmount = Spell;
            currentHealthAmount = Vida;

            Storyboard sb = (Storyboard)this.Resources["sbMoverBrazos"];
            sb.AutoReverse = true;
            sb.RepeatBehavior = RepeatBehavior.Forever;
            sb.Begin();

            Storyboard sb2 = (Storyboard)this.Resources["sbSaltar"];
            sb2.AutoReverse = true;
            sb2.Begin();

            myButton = (Button)this.FindName("btnBodySlam");

            cooldownTimer.Interval = TimeSpan.FromSeconds(5);
            cooldownTimer.Tick += CooldownTimer_Tick;
        }

        private void CooldownTimer_Tick(object sender, object e)
        {
            // Enable the button and stop the timer
            myButton.IsEnabled = true;
            cooldownTimer.Stop();
            txtCoolDown.Visibility = Visibility.Visible;
            enableAllSpells();
            comprobarEstadoCritico();
        }

        private void imgHealthIconRestorePointerReleased(object sender, PointerRoutedEventArgs e)
        {
            clock = new DispatcherTimer();
            clock.Interval = TimeSpan.FromMilliseconds(100);
            currentHealthAmount = this.barHP.Value;
            clock.Tick += increaseHealth; //When a tick appears we increase the total health. We use += to add that specific tic functionlality
            clock.Start();
            imgHealthIRestore.Opacity = 0.2;
        }


        private void imgManaPotion_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            clock = new DispatcherTimer();
            clock.Interval = TimeSpan.FromMilliseconds(100);
            currentSpellAmount = this.barSpell.Value;
            clock.Tick += increaseSpell; //When a tick appears we increase the total health. We use += to add that specific tic functionlality
            clock.Start();
            imgManaPotion.Opacity = 0.2;
        }

        private void increaseHealth(object sender, object e)
        {
            barHP.Value += 0.2;
            if (barHP.Value >= 100 || barHP.Value >= currentHealthAmount + 10)
            {
                clock.Stop();
                imgHealthIRestore.Opacity = 1;
                comprobarEstadoCritico();
            }
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

        private void btnDormir_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            Storyboard sbDormir = (Storyboard)this.Resources["sbDormir"];
            sbDormir.Begin();
            clock = new DispatcherTimer();
            if (this.barSpell.Value - 2 >= 0)
            {
                this.barSpell.Value = this.barSpell.Value - 2;
                currentSpellAmount = this.barSpell.Value;
                clock.Interval = TimeSpan.FromMilliseconds(100);
                clock.Tick += increaseSpell;
                clock.Start();
                disableAllSpells();
            }

        }

        private void increaseSpell(object sender, object e)
        {
            barSpell.Value += 0.2;
            if (barSpell.Value >= 100 || barSpell.Value >= currentSpellAmount + 10)
            {
                imgManaPotion.Opacity = 1;
                clock.Stop();
                enableAllSpells();
            }
        }

        private void increaseHealthEnfado(object sender, object e)
        {
            barHP.Value += 0.2;
            if (barHP.Value >= 100 || barHP.Value >= currentHealthAmount + 10)
            {
                clock.Stop();
                enableAllSpells();
            }
        }


        private void disableAllSpells()
        {
            btnDormir.IsEnabled = false;
            btnBodySlam.IsEnabled = false;
            btnEnfado.IsEnabled = false;
            btnHipnotizar.IsEnabled = false;
            txtCoolDown.Visibility = Visibility.Collapsed;
        }

        private void enableAllSpells()
        {
            btnDormir.IsEnabled = true;
            btnBodySlam.IsEnabled = true;
            btnEnfado.IsEnabled = true;
            btnHipnotizar.IsEnabled = true;
            txtCoolDown.Visibility = Visibility.Visible;
        }

        private void btnBodySlam_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            if (!(this.barSpell.Value - 5 <= 0))
            {
                disableAllSpells();
                Storyboard sbBodySlam = (Storyboard)this.Resources["sbBodySlam"];
                sbBodySlam.Begin();
                this.barSpell.Value = this.barSpell.Value - 5;
                // Disable the button and start the timer
                cooldownTimer.Start();
            }

        }

        private void btnEnfado_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            clock = new DispatcherTimer();
            if (!(this.barSpell.Value - 5 <= 0))
            {
                disableAllSpells();
                currentHealthAmount = this.barHP.Value;
                Storyboard sbBodySlam = (Storyboard)this.Resources["sbEnfado"];
                sbBodySlam.Begin();
                this.barSpell.Value = this.barSpell.Value - 10;
                // Disable the button and start the timer
                clock.Interval = TimeSpan.FromMilliseconds(100);
                clock.Tick += increaseHealthEnfado;
                clock.Start();
                cooldownTimer.Start();
            }
        }

        private void btnHipnotizar_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            if (!(this.barSpell.Value - 5 <= 0))
            {
                disableAllSpells();
                Storyboard sbHipnotizar = (Storyboard)this.Resources["sbHipnotizar"];
                sbHipnotizar.Begin();
                this.barSpell.Value = this.barSpell.Value - 5;
                // Disable the button and start the timer
                cooldownTimer.Start();
            }
        }
    }
}
