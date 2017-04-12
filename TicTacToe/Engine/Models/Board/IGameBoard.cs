using System.Collections.Generic;
using TicTacToe.Engine.Enums;

namespace TicTacToe.Engine.Models.Board
{
    /// <summary>
    /// Интерфейс игровой доски
    /// </summary>
    internal interface IGameBoard
    {
        /// <summary>
        /// Количество строк
        /// </summary>
        int RowsCount { get; }

        /// <summary>
        /// Количество столбцов
        /// </summary>
        int ColsCount { get; }

        /// <summary>
        /// Пометить указанную клетку
        /// </summary>
        /// <param name="row">Строка</param>
        /// <param name="col">Столбец</param>
        /// <param name="mark">Отметка</param>
        void SetMark(int row, int col, MarkType mark);

        /// <summary>
        /// Узнать отметку в указанной клетке
        /// </summary>
        /// <param name="row">Строка</param>
        /// <param name="col">Столбец</param>
        /// <returns>Отметка</returns>
        MarkType GetMark(int row, int col);

        /// <summary>
        /// Очистить игровое поле
        /// </summary>
        void Clear();
    }
}
