using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Input;
using TicTacToe.Engine;
using TicTacToe.Engine.Enums;

namespace TicTacToe.ViewModels
{
    /// <summary>
    /// Модель представления компонентов управления
    /// </summary>
    public class GameControlsViewModel : ViewModelBase
    {
        /// <summary>
        /// Игровой движок
        /// </summary>
        internal IGameEngine GameEngine { get; private set; }

        /// <summary>
        /// Начать игру
        /// </summary>
        public ICommand StartGameCommand { get; set; }

        private bool gameStarted;

        /// <summary>
        /// Флаг начатой игры
        /// </summary>
        public bool GameStarted
        {
            get => gameStarted;
            set
            {
                gameStarted = value;
                RaisePropertyChanged(nameof(GameStarted));
            }
        }

        /// <summary>
        /// Инициализация модели представления компонентов управления
        /// </summary>
        public GameControlsViewModel()
        {
            this.gameStarted = false;
            this.GameEngine = new StandardEngine();
            StartGameCommand = new RelayCommand(this.StartGame);
            GameEngine.GameOver += OnGameOver;
        }

        /// <summary>
        /// Начать игру
        /// </summary>
        public void StartGame()
        {
            GameStarted = true;
        }

        /// <summary>
        /// Обработчик завершенной игры
        /// </summary>
        /// <param name="state">Исход</param>
        /// <param name="winner">Победитель</param>
        private void OnGameOver(GameState state, MarkType winner)
        {
            GameStarted = false;
            MessageBox.Show(winner.ToString(), state.ToString());
        }
    }
}
