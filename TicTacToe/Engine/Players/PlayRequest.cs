using TicTacToe.Engine.Enums;

namespace TicTacToe.Engine.Players
{
    public class PlayRequest
    {
        public MarkType[,] Board { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
    }
}
