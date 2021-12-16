using ClassLib;
using System.Windows.Controls;

namespace TournamentManager.Pages
{
    /// <summary>
    /// Interaction logic for TournamentsMenu.xaml
    /// </summary>
    public partial class TournamentsMenu : Page
    {
        public TournamentsMenu()
        {
            InitializeComponent();
            for (int i = 0; i < Methods.AllPlayers.Count; i++)
            {
                CB_AllPlayers.Items.Add($"{Methods.AllPlayers[i].Name} {Methods.AllPlayers[i].Surname}");
            }
            dg_Tournaments.ItemsSource = Methods.Tournaments;
            dg_SelectedPlayers.ItemsSource = Methods.ChosenPlayers;
        }

        private void btn_CreateTournament_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Methods.CreateTournament(tb_TournamentName.Text, Methods.ChosenPlayers);
            Methods.ChosenPlayers.Clear();
        }
    }
}
