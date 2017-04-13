using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe.Engine.VictoryValidators;
using TicTacToe.Engine.Enums;

namespace TicTacToeTests
{
    [TestClass]
    public class StandardVictoryValidatorTests
    {
        private StandardVictoryValidator target;

        [TestMethod]
        public void TestCheck_Vertical()
        {
            target = new StandardVictoryValidator();

            var boards = new[]
            {
                new MarkType[,]
                {
                    { MarkType.Cross, MarkType.Nought, MarkType.None },
                    { MarkType.Cross, MarkType.Nought, MarkType.None },
                    { MarkType.Cross, MarkType.None, MarkType.None }
                },
                new MarkType[,]
                 {
                    { MarkType.None, MarkType.Cross, MarkType.Nought },
                    { MarkType.None, MarkType.Cross, MarkType.Nought },
                    { MarkType.None, MarkType.Cross, MarkType.None }
                 },
                new MarkType[,]
                 {
                    { MarkType.Nought, MarkType.None, MarkType.Cross },
                    { MarkType.Nought, MarkType.None, MarkType.Cross },
                    { MarkType.None, MarkType.None, MarkType.Cross }
                 }
            };

            foreach (var board in boards)
            {
                Assert.IsTrue(target.Check(board, MarkType.Cross) == GameState.Victory);
                Assert.IsFalse(target.Check(board, MarkType.Nought) == GameState.Victory);
            }
        }

        [TestMethod]
        public void TestCheck_Horizontal()
        {
            target = new StandardVictoryValidator();
            var boards = new[]
            {
                new MarkType[,]
                {
                    { MarkType.Cross, MarkType.Cross, MarkType.Cross },
                    { MarkType.Nought, MarkType.Nought, MarkType.None },
                    { MarkType.None, MarkType.None, MarkType.None }
                },
                new MarkType[,]
                 {
                    { MarkType.None, MarkType.None, MarkType.None },
                    { MarkType.Cross, MarkType.Cross, MarkType.Cross },
                    { MarkType.None, MarkType.Nought, MarkType.Nought },
                 },
                new MarkType[,]
                 {
                    { MarkType.Nought, MarkType.Nought, MarkType.None },
                    { MarkType.None, MarkType.None, MarkType.None },
                    { MarkType.Cross, MarkType.Cross, MarkType.Cross },
                 }
            };

            foreach (var board in boards)
            {
                Assert.IsTrue(target.Check(board, MarkType.Cross) == GameState.Victory);
                Assert.IsFalse(target.Check(board, MarkType.Nought) == GameState.Victory);
            }
        }

        [TestMethod]
        public void TestCheck_Diagonals()
        {
            target = new StandardVictoryValidator();
            var boards = new[]
            {
                new MarkType[,]
                {
                    { MarkType.Cross, MarkType.None, MarkType.Nought },
                    { MarkType.None, MarkType.Cross, MarkType.None },
                    { MarkType.Nought, MarkType.None, MarkType.Cross }
                },
                new MarkType[,]
                 {
                    { MarkType.Nought, MarkType.None, MarkType.Cross },
                    { MarkType.None, MarkType.Cross, MarkType.None },
                    { MarkType.Cross, MarkType.None, MarkType.Nought }
                 }
            };

            foreach (var board in boards)
            {
                Assert.IsTrue(target.Check(board, MarkType.Cross) == GameState.Victory);
                Assert.IsFalse(target.Check(board, MarkType.Nought) == GameState.Victory);
            }
        }

        [TestMethod]
        public void TestCheck_Draw()
        {
            target = new StandardVictoryValidator();

            var board = new MarkType[,]
            {
                { MarkType.Cross, MarkType.Nought, MarkType.Cross },
                { MarkType.Cross, MarkType.Nought, MarkType.Cross },
                { MarkType.Nought, MarkType.Cross, MarkType.Nought }
            };

            Assert.IsTrue(target.Check(board, MarkType.Cross) == GameState.Draw);
            Assert.IsTrue(target.Check(board, MarkType.Nought) == GameState.Draw);
        }
    }
}
