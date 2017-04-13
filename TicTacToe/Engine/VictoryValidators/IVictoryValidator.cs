using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Engine.Enums;

namespace TicTacToe.Engine.VictoryValidators
{
    /// <summary>
    /// Валидатор победных комбинаций
    /// </summary>
    internal interface IVictoryValidator
    {
        /// <summary>
        /// Проверка игрового поля на наличие победных комбинаций
        /// </summary>
        /// <param name="board">Игровое поле</param>
        /// <param name="checkMark">Отметка для проверки</param>
        /// <returns>Новое игровое состояние</returns>
        GameState Check(MarkType[,] board, MarkType checkMark);
    }
}
