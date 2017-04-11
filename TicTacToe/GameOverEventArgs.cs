﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    /// <summary>
    /// Данные об оконченной игре
    /// </summary>
    public class GameOverEventArgs: EventArgs
    {
        /// <summary>
        /// Победитель
        /// </summary>
        public CellMark Winner { get; private set; }

        /// <summary>
        /// Конструктор-инициализатор
        /// </summary>
        /// <param name="winner">Победитель</param>
        public GameOverEventArgs(CellMark winner)
        {
            this.Winner = winner;
        }
    }
}
