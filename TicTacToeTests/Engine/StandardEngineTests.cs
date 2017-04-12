using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe.Engine;
using TicTacToe.Engine.Players;
using TicTacToe.Engine.Models.Board;
using TicTacToe.Engine.Enums;

namespace TicTacToeTests.Engine
{
    [TestClass]
    public class StandardEngineTests
    {
        private StandardEngine target;

        [TestMethod]
        public void TestNewGame()
        {
            target = new StandardEngine();

            var board = target.NewGame();

            Assert.AreEqual(3, board.ColsCount);
            Assert.AreEqual(3, board.RowsCount);
        }

        [TestMethod]
        public void TestPlay()
        {
            target = new StandardEngine();

            var board = target.NewGame();

            PlayRequest req = new PlayRequest() { Board = board.AsArray(), Row = 0, Col = 0 };
            PlayResponse res = target.Play(req);

            CollectionAssert.AreEquivalent(new MarkType[,]
            {
                { MarkType.Cross, MarkType.None, MarkType.None },
                { MarkType.None, MarkType.None, MarkType.None },
                { MarkType.None, MarkType.None, MarkType.None }
            }, res.Board);

            req = new PlayRequest() { Board = res.Board, Row = 1, Col = 1 };
            res = target.Play(req);

            CollectionAssert.AreEquivalent(new MarkType[,]
            {
                { MarkType.Cross, MarkType.None, MarkType.None },
                { MarkType.None, MarkType.Nought, MarkType.None },
                { MarkType.None, MarkType.None, MarkType.None }
            }, res.Board);

            req = new PlayRequest() { Board = res.Board, Row = 2, Col = 2 };
            res = target.Play(req);

            CollectionAssert.AreEquivalent(new MarkType[,]
            {
                { MarkType.Cross, MarkType.None, MarkType.None },
                { MarkType.None, MarkType.Nought, MarkType.None },
                { MarkType.None, MarkType.None, MarkType.Cross }
            }, res.Board);
        }
    }
}
