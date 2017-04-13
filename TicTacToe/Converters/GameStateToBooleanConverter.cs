using System;
using System.Globalization;
using System.Windows.Data;
using TicTacToe.Engine.Enums;

namespace TicTacToe.Converters
{
    /// <summary>
    /// Конвертер игрового состояния в логическое значение. 
    /// Возвращает true, если игра запущена. Обратная конвертация не поддерживается.
    /// </summary>
    internal class GameStateToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(bool))
                throw new InvalidOperationException("Конечный тип должен быть Boolean");

            var state = (GameState)value;

            return state == GameState.Playing;
        }
        
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
