﻿using System;
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
using System.Windows.Shapes;

namespace TicTacToe.Views
{
    /// <summary>
    /// Логика взаимодействия для TicTacToeGameWindow.xaml
    /// </summary>
    public partial class GameWindowView : Window
    {
        public GameWindowView(ViewModels.GameWindowViewModel gameWindowViewModel)
        {
            DataContext = gameWindowViewModel;
            InitializeComponent();
        }
    }
}
