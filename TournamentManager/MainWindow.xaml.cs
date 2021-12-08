using ClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TournamentManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Player> Players = new List<Player>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Load_Click(object sender, RoutedEventArgs e)
        {
            Players = SQLiteDataAccess.LoadPlayers();
            DG_PlayerList.ItemsSource = Players;
            //DG_PlayerList
        }
    }
}
