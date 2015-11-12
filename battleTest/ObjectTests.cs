using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using battleship;

namespace battleTest
{
    [TestClass]
    public class ShotResultTests
    {
        [TestMethod]
        public void TestShotResultDefaultConstructor()
        {
            ShotResult shotResult = new ShotResult();
            Assert.IsTrue(shotResult.getState().Equals(State.miss));
        }

        [TestMethod]
        public void TestShotResultNonDefaultConstructor()
        {
            ShotResult shotResult = new ShotResult(State.hit);
            Assert.IsTrue(shotResult.getState().Equals(State.hit));
        }

        [TestMethod]
        public void TestShotResultGettersAndSetters()
        {
            ShotResult shotResult = new ShotResult();
            shotResult.setState(State.miss);
            Assert.IsTrue(shotResult.getState().Equals(State.miss));
        }
    }

    [TestClass]
    public class ShotTests
    {
        [TestMethod]
        public void TestShotDefaultConstructor()
        {
            Shot shot = new Shot();
            Square square = new Square();
            Assert.IsTrue(shot.getTarget().getXLoc() == square.getXLoc());
            Assert.IsTrue(shot.getTarget().getYLoc() == square.getYLoc());
            Assert.IsTrue(shot.getTarget().getSquareState() == square.getSquareState());
        }

        [TestMethod]
        public void TestShotNonDefaultConstructor()
        {
            Square square = new Square();
            Shot shot = new Shot(square);
            Assert.IsTrue(shot.getTarget() == square);
        }

        [TestMethod]
        public void TestShotGettersAndSetters()
        {
            Shot shot = new Shot();
            Square square = new Square();
            shot.setTarget(square);
            Assert.IsTrue(shot.getTarget().getXLoc() == square.getXLoc());
            Assert.IsTrue(shot.getTarget().getYLoc() == square.getYLoc());
            Assert.IsTrue(shot.getTarget().getSquareState() == square.getSquareState());
        }
    }
}
