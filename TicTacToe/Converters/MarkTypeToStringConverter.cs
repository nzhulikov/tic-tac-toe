using System;
using System.Windows.Data;
using TicTacToe.Engine.Enums;

namespace TicTacToe.Converters
{
    /// <summary>
    /// Конвертер отметки клетки в её строковое представление.
    /// Обратная операция не поддерживается.
    /// </summary>
    internal class MarkTypeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            if (targetType != typeof(String))
                throw new InvalidOperationException("Результат должен быть String");

            switch ((MarkType) value)
            {
                case MarkType.Cross:
                    return "X";
                case MarkType.Nought:
                    return "O";
                default:
                    return String.Empty;
            }
        }
        
        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
