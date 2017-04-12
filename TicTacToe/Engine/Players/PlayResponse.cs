using TicTacToe.Engine.Enums;

namespace TicTacToe.Engine.Players
{
    public class PlayResponse
    {
        public MarkType[,] Board { get; set; }
        public bool PlayerWon { get; set; }
    }
}
