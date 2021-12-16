using System.Windows.Controls;
using ClassLib;
using System.Collections;
using System.Collections.Generic;

namespace TournamentManager.Pages
{
    /// <summary>
    /// Interaction logic for PlayersMenu.xaml
    /// </summary>
    public partial class PlayersMenu : Page
    {
        public PlayersMenu()
        {
            InitializeComponent();
            dg_PlayersMenu.ItemsSource = Methods.AllPlayers;
        }
    }
}
