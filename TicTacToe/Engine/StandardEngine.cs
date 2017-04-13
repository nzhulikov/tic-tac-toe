using System;
using TicTacToe.Engine.Models.Board;
using TicTacToe.Engine.Players;
using TicTacToe.Engine.VictoryValidators;

namespace TicTacToe.Engine
{
    /// <summary>
    /// Игровая логика для стандартной игры в крестики-нолики на поле 3 на 3
    /// </summary>
    public class StandardEngine : IGameEngine
    {
        private IVictoryValidator victoryValidator;

        private IPlayer firstPlayer;
        private IPlayer secondPlayer;
        private IPlayer currentPlayer;

        public event GameOverHandler GameOver;
        public event MoveCompletedHandler BoardChanged;

        private IPlayer NextPlayer => ((currentPlayer != null) && currentPlayer.Equals(firstPlayer)) ? secondPlayer : firstPlayer;

        public StandardEngine()
        {
            victoryValidator = new StandardVictoryValidator();
        }

        public PlayResponse Play(PlayRequest request)
        {
            if (currentPlayer == null)
                return null;

            PlayResponse response = currentPlayer.Play(request, victoryValidator);

            if (response.IsValidMove)
            {
                BoardChanged?.Invoke(request.Row, request.Col, currentPlayer.Mark);

                if (response.Result != Enums.GameState.Playing)
                    GameOver?.Invoke(response.Result, response.Result == Enums.GameState.Draw ? Enums.MarkType.None : currentPlayer.Mark);

                currentPlayer = NextPlayer;
            }

            return response;
        }

        public IGameBoard NewGame()
        {
            firstPlayer = new HumanPlayer(Enums.MarkType.Cross);
            secondPlayer = new HumanPlayer(Enums.MarkType.Nought);
            currentPlayer = firstPlayer;
            return new SquareBoard(3);
        }
    }
}
