using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Input;
using TicTacToe.Engine;
using TicTacToe.Engine.Enums;

namespace TicTacToe.ViewModels
{
    public class GameControlsViewModel : ViewModelBase
    {
        internal IGameEngine GameEngine { get; private set; }

        public ICommand StartGameCommand { get; set; }

        private bool gameStarted;
        public bool GameStarted
        {
            get => gameStarted;
            set
            {
                gameStarted = value;
                RaisePropertyChanged(nameof(GameStarted));
            }
        }

        public GameControlsViewModel()
        {
            this.gameStarted = false;
            this.GameEngine = new StandardEngine();
            StartGameCommand = new RelayCommand(this.StartGame);
            GameEngine.GameOver += OnGameOver;
        }

        public void StartGame()
        {
            GameStarted = true;
        }

        private void OnGameOver(GameState state, MarkType winner)
        {
            GameStarted = false;
            MessageBox.Show(winner.ToString(), state.ToString());
        }
    }
}
