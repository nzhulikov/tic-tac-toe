namespace TicTacToe.ViewModels
{
    /// <summary>
    /// Модель представления главного окна игры
    /// </summary>
    public class GameWindowViewModel
    {
        /// <summary>
        /// Модель представления игрового поля
        /// </summary>
        public GameBoardViewModel GameBoardViewModel { get; private set; }

        /// <summary>
        /// Модель представления компонентов управления
        /// </summary>
        public GameControlsViewModel GameControlsViewModel { get; private set; }

        /// <summary>
        /// Инициализация моделей представления
        /// </summary>
        internal GameWindowViewModel()
        {
            this.GameControlsViewModel = new GameControlsViewModel();
            this.GameBoardViewModel = new GameBoardViewModel(this.GameControlsViewModel);
        }
    }
}
