using System.Collections.Generic;

namespace TicTacToe.Engine.Players
{
    public class PlayResponse
    {
        public IList<IList<Enums.MarkType>> Board { get; set; }
        public bool PlayerWon { get; set; }
    }
}
