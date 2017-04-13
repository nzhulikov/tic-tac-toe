using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Engine.Enums
{
    /// <summary>
    /// Состояние игры
    /// </summary>
    public enum GameState
    {
        /// <summary>
        /// Не определено
        /// </summary>
        None,
        /// <summary>
        /// В процессе
        /// </summary>
        Playing,
        /// <summary>
        /// Есть победитель
        /// </summary>
        Victory,
        /// <summary>
        /// Ничья
        /// </summary>
        Draw
    }
}
