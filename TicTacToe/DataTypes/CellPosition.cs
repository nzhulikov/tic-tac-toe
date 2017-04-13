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
        public int Row { get; set; }
        public int Column { get; set; }

        public CellPosition(int row, int col)
        {
            this.Row = row;
            this.Column = col;
        }
    }
}
