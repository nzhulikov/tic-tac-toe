using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TicTacToe
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Player crossPlayer;
        private Player noughtPlayer;

        private GameMatch currentMatch;

        /// <summary>
        /// Текущий игрок, ход которого ожидается в данный момент
        /// </summary>
        public Player CurrentPlayer { get; private set; }

        /// <summary>
        /// Конструктор игрового окна. Тут же создает новую игру.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            NewGame();
        }

        // Обработка нажатия кнопки
        private void ButtonClicked(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            btn.Content = MarkToString(CurrentPlayer.Mark);

            var row = Grid.GetRow(btn);
            var col = Grid.GetColumn(btn);
            MakeMove(row, col);

            btn.Content = GetContent(row, col);
        }

        // Новая игра
        private void NewGame()
        {
            crossPlayer = new Player("Крестики", CellMark.Cross);
            noughtPlayer = new Player("Нолики", CellMark.Nought);

            NewMatch();
        }

        // Новый матч
        private void NewMatch()
        {
            currentMatch = new GameMatch(3 , 3);
            currentMatch.GameOver += OnMatchOver;
            CurrentPlayer = crossPlayer;
            ClearView();
        }

        // Сделать ход в указанном месте
        private void MakeMove(int row, int col)
        {
            if (currentMatch.SetMark(row, col, CurrentPlayer.Mark))
                CurrentPlayer = GetNextPlayer();
        }

        // Получить значение строки для указанной клетки
        private string GetContent(int row, int col) => MarkToString(currentMatch.GetMark(row, col));

        // Преобразовать значение отметки в строку для отображения
        private string MarkToString(CellMark mark)
        {
            switch (mark)
            {
                case CellMark.Cross:
                    return "X";
                case CellMark.Nought:
                    return "O";
                default:
                    return String.Empty;
            }
        }

        // Узнать следующего игрока
        private Player GetNextPlayer()
        {
            return 
                CurrentPlayer == crossPlayer ? 
                noughtPlayer : crossPlayer;
        }

        // Обработать событие окончания матча
        private void OnMatchOver(GameMatch sender, GameOverEventArgs gameEvent)
        {
            switch (gameEvent.Winner)
            {
                case CellMark.Cross:
                    MessageBox.Show($"Игрок {crossPlayer.Name} победил!");
                    break;
                case CellMark.Nought:
                    MessageBox.Show($"Игрок {noughtPlayer.Name} победил!");
                    break;
                case CellMark.None:
                    MessageBox.Show($"Ничья.");
                    break;
            }
            
            NewMatch();
        }

        // Очистка отображения игрового поля
        private void ClearView()
        {
            foreach (var btn in MainGrid.Children.OfType<Button>())
                btn.Content = MarkToString(CellMark.None);
        }
    }
}
