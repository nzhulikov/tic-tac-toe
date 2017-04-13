using System;
using System.Collections.Generic;
using TicTacToe.Engine.Enums;

namespace TicTacToe.Engine.VictoryValidators
{
    /// <summary>
    /// Проверка комбинаций на поле размером 3х3 
    /// согласно страндартным правилам игры "Крестики-Нолики"
    /// </summary>
    public class StandardVictoryValidator : IVictoryValidator
    {
        /// <summary>
        /// Количество клеток в ряду для победы
        /// </summary>
        public int WinningCount { get; } = 3;

        public GameState Check(MarkType[,] board, MarkType checkMark)
        {
            bool isDraw = true;
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
                    else if (isDraw && board[i, j] == MarkType.None)
                    {
                        isDraw = false;
                    }
                    else
                    {
                        countHorizontal[i] = 0;
                        countVertical[j] = 0;
                    }

                    if (countHorizontal[i] == WinningCount || countVertical[j] == WinningCount)
                        return GameState.Victory;
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
                    return GameState.Victory;
            }

            return isDraw ? GameState.Draw : GameState.Playing;
        }
    }
}
