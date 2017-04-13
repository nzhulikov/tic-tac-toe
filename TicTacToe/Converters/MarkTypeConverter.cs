using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using TicTacToe.Engine.Enums;

namespace TicTacToe.Converters
{
    internal class MarkTypeConverter : IValueConverter
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
