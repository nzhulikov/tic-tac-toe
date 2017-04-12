using System.Collections.Generic;
using TicTacToe.Engine.Enums;

namespace TicTacToe.Engine.VictoryValidators
{
    class StandardVictoryValidator : IVictoryValidator
    {
        public bool Check(IList<IList<MarkType>> board, MarkType checkMark)
        {
            bool CheckVertical()
            {
                return false;
            }

            bool CheckHorizontal()
            {
                return false;
            }

            bool CheckDiagonals()
            {
                return false;
            }

            return CheckVertical() || 
                CheckHorizontal() ||
                CheckDiagonals();
        }
    }
}
