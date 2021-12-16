﻿using System.Windows;
using TournamentManager.Pages;
using System.Windows.Shapes;
using System.Windows.Navigation;
using ClassLib;
using System.Collections;
using System.Collections.Generic;

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
            
        }

        private void btn_PlayerMenu_Click(object sender, RoutedEventArgs e)
        {
            frame_Main.Content = new PlayersMenu();
        }

        private void btn_MainMenu_Click(object sender, RoutedEventArgs e)
        {
            frame_Main.Content = new MainMenu();
        }
    }
}
