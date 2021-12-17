using ClassLib;
using System.Windows;
using TournamentManager.Pages;

namespace TournamentManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            frame_Main.Content = new MainMenu();
            Methods.LoadPlayers();
            Methods.LoadTournaments();

        }

        private void btn_PlayerMenu_Click(object sender, RoutedEventArgs e)
        {
            frame_Main.Content = new PlayersMenu();
        }

        private void btn_MainMenu_Click(object sender, RoutedEventArgs e)
        {
            frame_Main.Content = new MainMenu();
        }

        private void btn_TournamentsMenu_Click(object sender, RoutedEventArgs e)
        {
            frame_Main.Content = new TournamentsMenu();
        }
    }
}
