using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Linq;
using System.Collections.ObjectModel;
using TicTacToe.Engine.Enums;
using TicTacToe.Engine.Models.Board;
using System.Windows.Input;
using TicTacToe.Engine.Players;
using System.ComponentModel;

namespace TicTacToe.ViewModels
{
    using ObservableBoard = ObservableCollection<ObservableCollection<MarkType>>;
    using ObservableBoardColumn = ObservableCollection<MarkType>;

    /// <summary>
    /// Модель представления для игрового поля
    /// </summary>
    public class GameBoardViewModel : ViewModelBase
    {
        private GameControlsViewModel gameControls;

        private ObservableBoard ticTacToeBoard;

        /// <summary>
        /// Игровое поле
        /// </summary>
        public ObservableBoard TicTacToeBoard
        {
            get { return ticTacToeBoard; }
            set
            {
                ticTacToeBoard = value;
                RaisePropertyChanged(nameof(TicTacToeBoard));
            }
        }

        private GameState gameState;

        /// <summary>
        /// Состояние игры
        /// </summary>
        public GameState GameState
        {
            get => gameState;
            set
            {
                if (gameState != value)
                {
                    gameState = value;
                    RaisePropertyChanged(nameof(GameState));
                }
            }
        }

        /// <summary>
        /// Сделать ход
        /// </summary>
        public ICommand MakeMoveCommand { get; private set; }

        /// <summary>
        /// Инициализация модели представления игрового поля
        /// </summary>
        /// <param name="gameControls">Модель представления управляющих компонентов</param>
        internal GameBoardViewModel(GameControlsViewModel gameControls)
        {
            MakeMoveCommand = new RelayCommand<DataTypes.CellPosition>(MakeMove);

            ticTacToeBoard = new ObservableBoard();
            gameState = GameState.None;

            this.gameControls = gameControls;
            gameControls.GameEngine.BoardChanged += OnMoveCompleted;
            gameControls.PropertyChanged += OnGameStarted;
        }

        /// <summary>
        /// Инициализировать источник данных
        /// </summary>
        /// <param name="boardModel">Игровое поле</param>
        private void SetObservableData(IGameBoard boardModel)
        {
            TicTacToeBoard.Clear();
            for (int j = 0; j < boardModel.ColsCount; j++)
            {
                var convertedColumn = new ObservableBoardColumn();
                for (int i = 0; i < boardModel.RowsCount; i++)
                {
                    convertedColumn.Add(boardModel.GetMark(i, j));
                }
                TicTacToeBoard.Add(convertedColumn);
            }
        }

        /// <summary>
        /// Конвертировать источник данных в двумерный массив клеток
        /// </summary>
        /// <param name="observableData">Источник данных</param>
        /// <returns>Двумерный массив клеток</returns>
        private MarkType[,] ConvertObservableDataToArray(ObservableBoard observableData)
        {
            var convertedData = new MarkType[observableData.Count, observableData.First().Count];
            for (int j = 0; j < convertedData.GetLength(0); j++)
                for (int i = 0; i < convertedData.GetLength(1); i++)
                    convertedData[j, i] = observableData[i][j];
            return convertedData;
        }

        /// <summary>
        /// Сделать ход в указанной клетке
        /// </summary>
        /// <param name="pos">Положение клетки</param>
        private void MakeMove(DataTypes.CellPosition pos)
        {
            if (!TicTacToeBoard.Any())
                return;

            if (GameState == GameState.Playing && TicTacToeBoard[pos.Column][pos.Row] == MarkType.None)
            {
                PlayRequest request = new PlayRequest()
                {
                    Board = ConvertObservableDataToArray(ticTacToeBoard),
                    Row = pos.Row,
                    Col = pos.Column
                };
                PlayResponse response = gameControls.GameEngine.Play(request);
                GameState = response.Result;
            }
        }

        /// <summary>
        /// Обработчик совершенного хода
        /// </summary>
        /// <param name="row">Строка с новой меткой</param>
        /// <param name="col">Столбец с новой меткой</param>
        /// <param name="newMark"></param>
        private void OnMoveCompleted(int row, int col, MarkType newMark)
        {
            TicTacToeBoard[col][row] = newMark;
        }

        /// <summary>
        /// Обработчик старта игры
        /// </summary>
        private void OnGameStarted(object sender, PropertyChangedEventArgs e)
        {
            if (!e.PropertyName.Equals(nameof(GameControlsViewModel.GameStarted)))
                return;

            var emitterControls = sender as GameControlsViewModel;

            if (emitterControls == null)
                return;

            if (emitterControls.GameStarted == true)
            {
                SetObservableData(gameControls.GameEngine.NewGame());
                GameState = GameState.Playing;
            }
        }
    }
}
