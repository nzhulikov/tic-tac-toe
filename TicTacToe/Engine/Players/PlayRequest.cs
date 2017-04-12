using System.Collections.Generic;

namespace TicTacToe.Engine.Players
{
    public class PlayRequest
    {
        public IList<IList<Enums.MarkType>> Board { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
    }
}
