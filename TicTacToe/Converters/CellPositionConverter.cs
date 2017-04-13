using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace TicTacToe.Converters
{
    /// <summary>
    /// Конвертер данных о ячейке в виде (DataGridCellInfo, DataGrid) в положение соответствующей клетки на игровом поле
    /// </summary>
    internal class CellPositionConverter : IMultiValueConverter
    {
        /// <summary>
        /// Конвертировать (DataGridCellInfo, DataGrid) в CellPosition
        /// </summary>
        /// <returns>Положение клетки на игровом поле, соответствующей ячейке в сетке данных</returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values != null && values.Length == 2)
            {
                DataGridCellInfo cellInfo = (DataGridCellInfo) values[0];
                DataGrid grid = (DataGrid) values[1];

                DataGridRow gridRow = (DataGridRow) grid.ItemContainerGenerator.ContainerFromItem(cellInfo.Item);

                return new DataTypes.CellPosition (cellInfo.Column == null ? 0 : cellInfo.Column.DisplayIndex, 
                    gridRow == null ? 0 : gridRow.GetIndex());
            }

            return null;
        }

        /// <summary>
        /// Обратное конвертирование не реализовано.
        /// </summary>
        /// <exception cref="NotImplementedException">Неподдерживаемая операция</exception>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
