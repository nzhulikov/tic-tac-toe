namespace TicTacToe
{
    /// <summary>
    /// Представляет собой игрока
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Отметка игрока
        /// </summary>
        public CellMark Mark { get; private set; }

        /// <summary>
        /// Имя игрока
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Конструктор-инициализатор по умолчанию
        /// </summary>
        /// <param name="name">Имя игрока</param>
        /// <param name="mark">Отметка игрока</param>
        public Player(string name, CellMark mark)
        {
            this.Name = name;
            this.Mark = mark;
        }
    }
}
