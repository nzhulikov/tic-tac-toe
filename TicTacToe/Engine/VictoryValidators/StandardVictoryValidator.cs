using System.Collections.Generic;
using TicTacToe.Engine.Enums;

namespace TicTacToe.Engine.VictoryValidators
{
    public class StandardVictoryValidator : IVictoryValidator
    {
        public int WinningCount { get; set; } = 3;

        public bool Check(MarkType[,] board, MarkType checkMark)
        {
            int[] countVertical = new int[board.GetLength(0)];
            int[] countHorizontal = new int[board.GetLength(1)];
            int countDiagonal = 0;
            int countReversedDiagonal = 0;

            // Алгоритм поиска решения с использованием однократного прохода
            for (int i = 0;
                i < board.GetLength(0);
                i++)
            {
                for (int j = 0;
                    j < board.GetLength(1);
                    j++)
                {
                    if (board[i, j].Equals(checkMark))
                    {
                        countHorizontal[i]++;
                        countVertical[j]++;
                    }
                    else
                    {
                        countHorizontal[i] = 0;
                        countVertical[j] = 0;
                    }

                    if (countHorizontal[i] == WinningCount || countVertical[j] == WinningCount)
                        return true;
                }

                if (board[i, i].Equals(checkMark))
                    countDiagonal++;
                else
                    countDiagonal = 0;

                if (board[(board.GetLength(0) - 1) - i, i].Equals(checkMark))
                    countReversedDiagonal++;
                else
                    countReversedDiagonal = 0;

                if (countDiagonal == WinningCount || countReversedDiagonal == WinningCount)
                    return true;
            }

            return false;
        }
    }
}
