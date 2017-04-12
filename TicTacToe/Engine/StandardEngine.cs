using System;
using TicTacToe.Engine.Models.Board;
using TicTacToe.Engine.Players;
using TicTacToe.Engine.VictoryValidators;

namespace TicTacToe.Engine
{
    internal class StandardEngine : IGameEngine
    {
        private IVictoryValidator victoryValidator;

        private IPlayer firstPlayer;
        private IPlayer secondPlayer;
        private IPlayer currentPlayer;

        private IPlayer NextPlayer => ((currentPlayer != null) && currentPlayer.Equals(firstPlayer)) ? secondPlayer : firstPlayer;

        public StandardEngine()
        {
            victoryValidator = new StandardVictoryValidator();
        }

        public PlayResponse Play(PlayRequest request)
        {
            PlayResponse response = currentPlayer.Play(request, victoryValidator);
            currentPlayer = NextPlayer;

            return response;
        }

        public IGameBoard NewGame(int boardLength)
        {
            firstPlayer = new HumanPlayer(Enums.MarkType.Cross);
            secondPlayer = new HumanPlayer(Enums.MarkType.Nought);
            currentPlayer = firstPlayer;
            return new BoardModel(boardLength);
        }
    }
}
