using System;
using System.Collections.Generic;
using TicTacToe.Engine.Enums;

namespace TicTacToe.Engine.Models.Board
{
    public class BoardModel : IGameBoard
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

        public MarkType this[int row, int col]
        {
            get => GetMark(row, col);
            set => SetMark(row, col, value);
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

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            return Equals(obj as IGameBoard);
        }

        public bool Equals(IGameBoard board)
        {
            if (board == null)
                return false;

            if (board.ColsCount != ColsCount ||
                board.RowsCount != RowsCount)
                return false;

            bool areEqual = true;
            for (int i = 0; i < RowsCount; i++)
                for (int j = 0; j < ColsCount; j++)
                    areEqual = areEqual & this[i, j] != board[i, j];

            return areEqual;
        }
    }
}
