using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.DataTypes
{
    /// <summary>
    /// Положение клетки на игровом поле
    /// </summary>
    public struct CellPosition
    {
        /// <summary>
        /// Строка
        /// </summary>
        public int Row { get; set; }

        /// <summary>
        /// Столбец
        /// </summary>
        public int Column { get; set; }

        public CellPosition(int row, int col)
        {
            this.Row = row;
            this.Column = col;
        }
    }
}
