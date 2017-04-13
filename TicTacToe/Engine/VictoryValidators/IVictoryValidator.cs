using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Engine.Enums;

namespace TicTacToe.Engine.VictoryValidators
{
    internal interface IVictoryValidator
    {
        GameState Check(Enums.MarkType[,] board, Enums.MarkType checkMark);
    }
}
