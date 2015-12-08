using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using battleship;

namespace battleTest
{
    [TestClass]
    public class GameboardTest
    {
        [TestMethod]
        public void TestGameboardConstructor()
        {
            Gameboard gb = new Gameboard();
            //check that boards are created
            for (int i = 0; i < 10; i++) { 
                for (int j = 0; j < 10; j++)
                {
                    Assert.AreNotEqual(gb.playerGrid[i][j], null);
                    Assert.AreNotEqual(gb.enemyGrid[i][j], null);
                }
            }

            //check x and y locations
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Assert.AreEqual(gb.playerGrid[i][j].getXLoc(), i);
                    Assert.AreEqual(gb.playerGrid[i][j].getXLoc(), j);
                    Assert.AreEqual(gb.enemyGrid[i][j].getXLoc(), i);
                    Assert.AreEqual(gb.enemyGrid[i][j].getXLoc(), j);
                }
            }
        }

        [TestMethod]
        public void TestGameboardReset()
        {
            Gameboard gb = new Gameboard();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    gb.playerGrid[i][j].setState(State.hit);
                }
            }
            gb.resetBoard();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Assert.AreEqual(gb.playerGrid[i][j].getSquareState(), State.empty);
                }
            }
        }    
    }
}
