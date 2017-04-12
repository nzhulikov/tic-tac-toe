﻿using System;
using System.Collections.Generic;
using TicTacToe.Engine.Enums;

namespace TicTacToe.Engine.Models.Board
{
    internal class BoardModel : IGameBoard
    {
        private MarkType[,] board;

        public int RowsCount { get; private set; }
        public int ColsCount { get; private set; }

        /// <summary>
        /// Конструктор квадратного игрового поля
        /// </summary>
        /// <param name="boardLength">Длина поля</param>
        public BoardModel(int boardLength)
        {
            RowsCount = boardLength;
            ColsCount = boardLength;
            InitializeBoard();
        }

        public void SetMark(int row, int col, MarkType mark)
        {
            board[row, col] = mark;
        }

        public MarkType GetMark(int row, int col)
        {
            return board[row, col];
        }

        public void Clear()
        {
            for (int i = 0; i < board.GetLength(0); i++)
                for (int j = 0; j < board.GetLength(1); j++)
                    board[i, j] = MarkType.None;
        }

        private void InitializeBoard()
        {
            board = new MarkType[RowsCount, ColsCount];
            Clear();
        }
    }
}
