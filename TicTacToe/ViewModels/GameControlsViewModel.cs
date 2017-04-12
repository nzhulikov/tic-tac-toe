using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TicTacToe.Engine;

namespace TicTacToe.ViewModels
{
    public class GameControlsViewModel
    {
        internal IGameEngine GameEngine { get; private set; }
        public bool GameStarted { get; set; }

        public ICommand StartGameCommand { get; set; }

        internal GameControlsViewModel()
        {
        }

        public void StartGame()
        {
            this.GameEngine = new StandardEngine();
            GameStarted = true;
        }
    }
}
