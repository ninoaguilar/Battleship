using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using battleship;

namespace battleTest
{
    [TestClass]
    public class GameControllerText
    {
        [TestMethod]
        public void TestGameControllerConstructorDefault()
        {
            GameController gc=new GameController();
            Assert.AreEqual(gc.getPlayerTurn(), 1);
            Assert.AreEqual(gc.isGameOver(), false);
        }
        [TestMethod]
        public void TestGameControllerConstructor()
        {
            GameController gc = new GameController(2);
            Assert.AreEqual(gc.getPlayerTurn(), 2);
            Assert.AreEqual(gc.isGameOver(), false);
        }
        [TestMethod]
        public void TestGameControllerPassTurn()
        {
            GameController gc = new GameController();
            gc.passTurn();
            Assert.AreEqual(gc.getPlayerTurn(), 2);
            gc.passTurn();
            Assert.AreEqual(gc.getPlayerTurn(), 1);
        }
        [TestMethod]
        public void TestGameControllerSetGameOver()
        {
            GameController gc = new GameController();
            gc.setGameOver(true);
            Assert.AreEqual(gc.isGameOver(), true);
        }
        [TestMethod]
        public void TestGameControllerResetGame()
        {
            GameController gc = new GameController(2);
            gc.setGameOver(true);
            gc.resetGame();
            Assert.AreEqual(gc.getPlayerTurn(), 1);
            Assert.AreEqual(gc.isGameOver(), false);
        }

    }
}
