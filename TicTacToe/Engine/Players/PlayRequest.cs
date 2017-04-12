using TicTacToe.Engine.Enums;

namespace TicTacToe.Engine.Players
{
    /// <summary>
    /// Запрос хода
    /// </summary>
    public class PlayRequest
    {
        /// <summary>
        /// Текущая доска
        /// </summary>
        public MarkType[,] Board { get; set; }

        /// <summary>
        /// Строка хода
        /// </summary>
        public int Row { get; set; }

        /// <summary>
        /// Столбец хода
        /// </summary>
        public int Col { get; set; }
    }
}
