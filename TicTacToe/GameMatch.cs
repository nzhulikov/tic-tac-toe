namespace TicTacToe
{
    /// <summary>
    /// Игровой матч в крестики-нолики
    /// </summary>
    public class GameMatch
    {
        /// <summary>
        /// Обработчик конца игры
        /// </summary>
        /// <param name="sender">Законившийся матч</param>
        /// <param name="gameEvent">Данные о матче</param>
        public delegate void GameOverEvent(GameMatch sender, GameOverEventArgs gameEvent);

        /// <summary>
        /// Событие конца матча
        /// </summary>
        public event GameOverEvent GameOver;

        /// <summary>
        /// Длина игрового поля
        /// </summary>
        public int Side { get; private set; }

        /// <summary>
        /// Минимальное количество клеток в ряду, необходимое для победы
        /// </summary>
        public int WinningCount { get; private set; }

        // Игровое поле
        private CellMark[] state;

        // Счетчик ходов
        private int countMoves;

        /// <summary>
        /// Конструктор для нового матча
        /// </summary>
        /// <param name="side">Длина игрового поля</param>
        /// <param name="winSeries">Клеток для победы</param>
        public GameMatch(int side, int winSeries)
        {
            this.Side = side;
            this.WinningCount = winSeries;
            this.state = CreateEmptyState();
            this.countMoves = 0;
        }

        /// <summary>
        /// Отметить указанную клетку. Если после этого хода игра была закончена, то вызывается событие GameOver
        /// </summary>
        /// <param name="row">Строка</param>
        /// <param name="col">Колонка</param>
        /// <param name="mark">Отметка</param>
        /// <returns>Возвращает true, если клетка была отмечена</returns>
        /// <seealso cref="GameOver"/>
        public bool SetMark(int row, int col, CellMark mark)
        {
            if (this.state[GetIndex(row, col)] != CellMark.None)
                return false;

            this.state[GetIndex(row, col)] = mark;
            countMoves++;

            if (CheckCombinations(row, col))
                GameOver?.Invoke(this, new GameOverEventArgs(mark));
            else if (countMoves == state.Length)
                GameOver?.Invoke(this, new GameOverEventArgs(CellMark.None));

            return true;
        }

        /// <summary>
        /// Получить отметку в указанной клетке
        /// </summary>
        /// <param name="row">Строка</param>
        /// <param name="col">Колонка</param>
        /// <returns>Отметка клетки</returns>
        public CellMark GetMark(int row, int col) => state[GetIndex(row, col)];

        /// <summary>
        /// Проверить комбинации для указанной клетки
        /// </summary>
        /// <param name="row">Строка</param>
        /// <param name="col">Колонка</param>
        /// <returns>Возвращает true, если была найдена выигрышная комбинация</returns>
        private bool CheckCombinations(int row, int col)
        {
            // +1 это включая текущую клетку
            return
                1 + CountAbove(row, col) + CountBelow(row, col) >= WinningCount ||
                1 + CountToLeft(row, col) + CountToRight(row, col) >= WinningCount ||
                1 + CountToUpperLeft(row, col) + CountToLowerRight(row, col) >= WinningCount ||
                1 + CountToLowerLeft(row, col) + CountToUpperRight(row, col) >= WinningCount;
        }

        /// <summary>
        /// Создаёт поле, заполненное клетками без отметок.
        /// </summary>
        /// <returns>Пустое игровое поле</returns>
        /// <seealso cref="CellMark.None"/>
        private CellMark[] CreateEmptyState()
        {
            var clearState = new CellMark[Side * Side];
            for (int i = 0; i < clearState.Length; i++)
                clearState[i] = CellMark.None;
            return clearState;
        }

        /// <summary>
        /// Преобразовывает двумерные координаты в индекс одномерного массива
        /// </summary>
        /// <param name="row">Строка</param>
        /// <param name="col">Столбец</param>
        /// <returns>Возвращает соответствующий индекс в одномерном массиве</returns>
        private int GetIndex(int row, int col) => row * Side + col;

        /// <summary>
        /// Подсчет суммарного количества клеток в ряду справа
        /// </summary>
        /// <param name="row">Строка</param>
        /// <param name="col">Столбец</param>
        /// <returns>Сумма клеток в ряду</returns>
        private int CountToRight(int row, int col)
        {
            int sum = 0;
            int j = col + 1;
            while (j < Side &&
                j < col + WinningCount &&
                this.state[GetIndex(row, j)] == state[GetIndex(row, col)])
            {
                sum++;
                j++;
            }

            return sum;
        }

        /// <summary>
        /// Подсчет суммарного количества клеток в ряду слева
        /// </summary>
        /// <param name="row">Строка</param>
        /// <param name="col">Столбец</param>
        /// <returns>Сумма клеток в ряду</returns>
        private int CountToLeft(int row, int col)
        {
            int sum = 0;
            int j = col - 1;
            while (j >= 0 &&
                j > col - WinningCount &&
                this.state[GetIndex(row, j)] == state[GetIndex(row, col)])
            {
                sum++;
                j--;
            }

            return sum;
        }

        /// <summary>
        /// Подсчет суммарного количества клеток в ряду снизу
        /// </summary>
        /// <param name="row">Строка</param>
        /// <param name="col">Столбец</param>
        /// <returns>Сумма клеток в ряду</returns>
        private int CountBelow(int row, int col)
        {
            int sum = 0;
            int i = row + 1;
            while (i < Side &&
                i < row + WinningCount &&
                this.state[GetIndex(i, col)] == state[GetIndex(row, col)])
            {
                sum++;
                i++;
            }

            return sum;
        }

        /// <summary>
        /// Подсчет суммарного количества клеток в ряду сверху
        /// </summary>
        /// <param name="row">Строка</param>
        /// <param name="col">Столбец</param>
        /// <returns>Сумма клеток в ряду</returns>
        private int CountAbove(int row, int col)
        {
            int sum = 0;
            int i = row - 1;
            while (i >= 0 &&
                i > row - WinningCount &&
                this.state[GetIndex(i, col)] == state[GetIndex(row, col)])
            {
                sum++;
                i--;
            }

            return sum;
        }

        /// <summary>
        /// Подсчет суммарного количества клеток в ряду по диагонали вверх вправо
        /// </summary>
        /// <param name="row">Строка</param>
        /// <param name="col">Столбец</param>
        /// <returns>Сумма клеток в ряду</returns>
        private int CountToUpperRight(int row, int col)
        {
            int sum = 0;
            int i = row - 1;
            int j = col + 1;
            while (i >= 0 &&
                j < Side &&
                j < col + WinningCount &&
                this.state[GetIndex(i, j)] == state[GetIndex(row, col)])
            {
                sum++;
                i--;
                j++;
            }

            return sum;
        }

        /// <summary>
        /// Подсчет суммарного количества клеток в ряду по диагонали вверх влево
        /// </summary>
        /// <param name="row">Строка</param>
        /// <param name="col">Столбец</param>
        /// <returns>Сумма клеток в ряду</returns>
        private int CountToUpperLeft(int row, int col)
        {
            int sum = 0;
            int i = row - 1;
            int j = col - 1;
            while (i >= 0 &&
                j >= 0 &&
                j > col - WinningCount &&
                this.state[GetIndex(i, j)] == state[GetIndex(row, col)])
            {
                sum++;
                i--;
                j--;
            }

            return sum;
        }

        /// <summary>
        /// Подсчет суммарного количества клеток в ряду по диагонали вниз вправо
        /// </summary>
        /// <param name="row">Строка</param>
        /// <param name="col">Столбец</param>
        /// <returns>Сумма клеток в ряду</returns>
        private int CountToLowerRight(int row, int col)
        {
            int sum = 0;
            int i = row + 1;
            int j = col + 1;
            while (i < Side &&
                j < Side &&
                j < col + WinningCount &&
                this.state[GetIndex(i, j)] == state[GetIndex(row, col)])
            {
                sum++;
                i++;
                j++;
            }

            return sum;
        }

        /// <summary>
        /// Подсчет суммарного количества клеток в ряду по диагонали вниз влево
        /// </summary>
        /// <param name="row">Строка</param>
        /// <param name="col">Столбец</param>
        /// <returns>Сумма клеток в ряду</returns>
        private int CountToLowerLeft(int row, int col)
        {
            int sum = 0;
            int i = row + 1;
            int j = col - 1;
            while (i < Side &&
                j >= 0 &&
                j > col - WinningCount &&
                this.state[GetIndex(i, j)] == state[GetIndex(row, col)])
            {
                sum++;
                i++;
                j--;
            }

            return sum;
        }
    }
}
