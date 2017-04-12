using TicTacToe.Engine.Enums;

namespace TicTacToe.Engine.Models.Board
{
    public static class GameBoardExtensions
    {
        public static MarkType[,] AsArray(this IGameBoard board)
        {
            var arr = new MarkType[board.RowsCount, board.ColsCount];

            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                    arr[i, j] = board[i, j];

            return arr;
        }
    }
}
