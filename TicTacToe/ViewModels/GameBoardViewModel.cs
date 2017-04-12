using System.Collections.ObjectModel;
using TicTacToe.Engine.Enums;
using TicTacToe.Engine.Models.Board;
using System.Windows.Input;
using TicTacToe.Engine.Players;

namespace TicTacToe.ViewModels
{
    public class GameBoardViewModel
    {
        private GameControlsViewModel _controls;
        private ObservableCollection<ObservableCollection<MarkType>> ticTacToeBoard;

        public ICommand MakeMoveCommand { get; private set; }
        public bool PlayerWon { get; private set; }

        internal GameBoardViewModel(GameControlsViewModel _controls)
        {
            PlayerWon = false;
        }

        private void InitializeTicTacToeBoard(IGameBoard boardModel)
        {
            ticTacToeBoard = new ObservableCollection<ObservableCollection<MarkType>>();
            for (int i = 0; i < boardModel.RowsCount; i++)
            {
                var convertedRow = new ObservableCollection<MarkType>();
                for (int j = 0; j < boardModel.ColsCount; j++)
                {
                    convertedRow.Add(boardModel.GetMark(i, j));
                }
                ticTacToeBoard.Add(convertedRow);
            }
        }

        private void MakeMove(int[] pos)
        {
            if (ticTacToeBoard[pos[1]][pos[0]] == MarkType.None)
            {
                PlayRequest request = new PlayRequest();
                PlayResponse response = _controls.GameEngine.Play(request);
                PlayerWon = response.PlayerWon;
            }
        }
    }
}
