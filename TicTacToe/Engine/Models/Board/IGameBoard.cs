using System.Collections.Generic;
using TicTacToe.Engine.Enums;

namespace TicTacToe.Engine.Models.Board
{
    /// <summary>
    /// Интерфейс игрового поля
    /// </summary>
    public interface IGameBoard
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
        /// Индексер для доступа к клеткам игрового поля
        /// </summary>
        /// <param name="row">Строка</param>
        /// <param name="col">Столбец</param>
        MarkType this[int row, int col] { get; set; }

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
