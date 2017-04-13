using TicTacToe.Engine;
using System.Windows;

namespace TicTacToe
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            ViewModels.GameWindowViewModel gameWindowViewModel = new ViewModels.GameWindowViewModel();
            Views.GameWindowView gameWindow = new Views.GameWindowView(gameWindowViewModel);
            gameWindow.ShowDialog();
        }
    }
}
