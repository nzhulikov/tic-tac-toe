using TicTacToe.Engine.Enums;

namespace TicTacToe.Engine.Players
{
    /// <summary>
    /// Ответ на запрос хода
    /// </summary>
    public class PlayResponse
    {
        /// <summary>
        /// Доска после хода
        /// </summary>
        public MarkType[,] Board { get; set; }

        /// <summary>
        /// Проверка, победил ли игрок, запросивший ход
        /// </summary>
        public GameState Result { get; set; }

        /// <summary>
        /// Проверка, валидный ли был ход в запросе
        /// </summary>
        public bool IsValidMove { get; set; }
    }
}
