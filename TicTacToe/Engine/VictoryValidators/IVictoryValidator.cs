using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Engine.VictoryValidators
{
    internal interface IVictoryValidator
    {
        bool Check(Enums.MarkType[,] board, Enums.MarkType checkMark);
    }
}
