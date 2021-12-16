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

        private void btn_CreatePlayer_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Methods.AllPlayers.Add(Methods.CreatePlayer(tb_CreatePlayer_Name.Text,tb_CreatePlayer_Surname.Text));
            dg_PlayersMenu.ItemsSource = null;
            Methods.LoadPlayers();
            dg_PlayersMenu.ItemsSource=Methods.AllPlayers;
        }
    }
}
