using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using battleship;

namespace battleTest
{
    [TestClass]
    public class AIPlayerTest
    {
        [TestMethod]
        public void InitialAISetup()
        {
            AIPlayer computer = new AIPlayer();
            Assert.IsTrue(computer.Name == "Computer");
        }

        [TestMethod]
        public void GuessShot()
        {
            Gameboard Board;
            GridButton[][] enemyGridButtons = new GridButton[10][];
            GameController controller = new GameController();

        }
    }
}
