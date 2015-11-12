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
            Assert.IsTrue(shotResultObject.getState == State.miss);
        }

        [TestMethod]
        public void TestShotResultObjectNonDefaultConstructor()
        {
            ShotResultObject shotResultObject = new ShotResultObject(State.hit);
            Assert.IsTrue(shotResultObject.getState == State.hit);
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
            Assert.IsTrue(shotObject.getTarget() == square);
        }

        [TestMethod]
        public void TestShotObjectNonDefaultConstructor()
        {
            Square square = new Square();
            ShotObject shotObject = new ShotObject(square);
            Assert.IsTrue(shotObject.getTarget() == square);
        }
    }
}
