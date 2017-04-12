using System;
using TicTacToe.Engine;

namespace TicTacToe
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            ViewModels.GameWindowViewModel gameWindowViewModel = new ViewModels.GameWindowViewModel();
            Views.TicTacToeGameWindow gameWindow = new Views.TicTacToeGameWindow(gameWindowViewModel);
            gameWindow.ShowDialog();
        }
    }
}
