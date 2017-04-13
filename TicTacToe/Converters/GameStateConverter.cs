using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using TicTacToe.Engine.Enums;

namespace TicTacToe.Converters
{
    internal class GameStateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(bool))
                throw new InvalidOperationException("Конечный тип должен быть Boolean");

            var state = (GameState)value;

            return state == GameState.Playing;
        }

        /// <summary>
        /// Обратное конвертирование не реализовано.
        /// </summary>
        /// <exception cref="NotImplementedException">Неподдерживаемая операция</exception>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
