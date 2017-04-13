﻿using System.ComponentModel;
using TicTacToe.Engine;

namespace TicTacToe.ViewModels
{
    public class GameWindowViewModel
    {
        public GameBoardViewModel GameBoardViewModel { get; private set; }
        public GameControlsViewModel GameControlsViewModel { get; private set; }

        internal GameWindowViewModel()
        {
            this.GameControlsViewModel = new GameControlsViewModel();
            this.GameBoardViewModel = new GameBoardViewModel(this.GameControlsViewModel);
        }
    }
}
