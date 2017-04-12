using System.Windows.Input;
using TicTacToe.Engine;

namespace TicTacToe.ViewModels
{
    public class GameControlsViewModel
    {
        internal IGameEngine GameEngine { get; private set; }

        public bool GameStarted { get; set; }

        public ICommand StartGameCommand { get; set; }

        public GameControlsViewModel()
        {
        }

        public void StartGame()
        {
            this.GameEngine = new StandardEngine();
            GameStarted = true;
        }
    }
}
