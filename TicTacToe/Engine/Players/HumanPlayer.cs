using TicTacToe.Engine.Enums;
using TicTacToe.Engine.VictoryValidators;

namespace TicTacToe.Engine.Players
{
    internal class HumanPlayer : IPlayer
    {
        public MarkType Mark { get; set; }

        public HumanPlayer(MarkType mark)
        {
            this.Mark = mark;
        }

        public PlayResponse Play(PlayRequest request, IVictoryValidator victoryValidator)
        {
            PlayResponse response = new PlayResponse();

            if (CanPlay(request))
            {
                request.Board[request.Row][request.Col] = Mark;
                response.Board = request.Board;
            }

            response.PlayerWon = victoryValidator.Check(request.Board, Mark);

            return response;
        }

        public bool CanPlay(PlayRequest request) => request.Board[request.Row][request.Col] == MarkType.None;
    }
}
