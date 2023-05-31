using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace IPO2_Pokemon_Pokedex
{
    /// <summary>
    /// Página dedicada al selector de modo del combate pokemon.
    /// 
    /// Proyecto realizado por:
    /// Enrique Sánchez-Migallón Ochoa
    /// Javier Santos Sanz
    /// Alonso Crespo Fernández
    /// Felipe Alcázar Gómez
    /// </summary>

    public sealed partial class CombatePage : Page
    {
        /************************************************************************************************/

        /*Inicializacion de las variables globales*/

        public string modo_de_Juego;

        /************************************************************************************************/

        /*Inicializacion de la pagina CombatePage*/

        public CombatePage() // Terminado
        {
            this.InitializeComponent();
        }

        /************************************************************************************************/

        /*Botones de la propia pagina*/

        private void Ir_A_La_Siguiente_Pagina1_Click(object sender, RoutedEventArgs e) // Terminado
        {
            // Continuar el combate en modo P1 vs P2
            modo_de_Juego = "VS";
            Frame CombateFrame = (Frame)this.Parent;
            CombateFrame.Navigate(typeof(Seleccion_CombatePage), this);
        }
        private void Ir_A_La_Siguiente_Pagina2_Click(object sender, RoutedEventArgs e) // Terminado
        {
            // Continuar el combate en modo P1 vs IA
            modo_de_Juego = "IA";
            Frame CombateFrame = (Frame)this.Parent;
            CombateFrame.Navigate(typeof(Seleccion_CombatePage), this);
        }

        /************************************************************************************************/

        /*Metodos funcionales en la pagina*/



        /************************************************************************************************/

        /*Metodos Auxiliares*/

    }
}
