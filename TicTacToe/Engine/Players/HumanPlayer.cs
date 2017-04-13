using TicTacToe.Engine.Enums;
using TicTacToe.Engine.VictoryValidators;

namespace TicTacToe.Engine.Players
{
    /// <summary>
    /// Игрок-человек
    /// </summary>
    internal class HumanPlayer : IPlayer
    {
        public MarkType Mark { get; set; }

        public HumanPlayer(MarkType mark)
        {
            this.Mark = mark;
        }

        public PlayResponse Play(PlayRequest request, IVictoryValidator victoryValidator)
        {
            PlayResponse response = new PlayResponse() { IsValidMove = false };

            if (CanPlay(request))
            {
                request.Board[request.Row, request.Col] = Mark;
                response.Board = request.Board;
                response.Result = victoryValidator.Check(request.Board, Mark);
                response.IsValidMove = true;
            }

            return response;
        }

        public bool CanPlay(PlayRequest request) => request.Board[request.Row, request.Col] == MarkType.None;
    }
}
