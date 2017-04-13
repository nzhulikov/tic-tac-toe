using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace TicTacToe.Converters
{
    /// <summary>
    /// Конвертер данных о ячейке в виде (DataGridCellInfo, DataGrid) в значение CellPosition.
    /// Обратное конвертирование не поддерживается.
    /// </summary>
    internal class CellGridInfoToPositionConverter : IMultiValueConverter
    {
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
        
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
