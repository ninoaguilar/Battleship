using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using battleship;

namespace battleTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsTrue(true);
        }
    }

    [TestClass]
    public class ShotResultObjectTests
    {
        [TestMethod]
        public void TestShotResultObjectDefaultConstructor()
        {
            ShotResultObject shotResultObject = new ShotResultObject();
            Assert.IsTrue(shotResultObject.getState == State.MISS);
        }

        [TestMethod]
        public void TestShotResultObjectNonDefaultConstructor()
        {
            ShotResultObject shotResultObject = new ShotResultObject(State.HIT);
            Assert.IsTrue(shotResultObject.getState == State.HIT);
        }
    }

    [TestClass]
    public class ShotObjectTests
    {
        [TestMethod]
        public void TestShotObjectDefaultConstructor()
        {
            ShotObject shotObject = new ShotObject();
            Square square = new Square();
            Assert.IsTrue(shotObject.getTarget() == sqare);
        }

        [TestMethod]
        public void TestShotObjectNonDefaultConstructor()
        {
            Square square = new Square(3, 4);
            ShotObject shotObject = new ShotObject(square);
            Assert.IsTrue(shotObject.getTarget() == square);
        }
    }
}
