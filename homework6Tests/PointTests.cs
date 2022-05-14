using Microsoft.VisualStudio.TestTools.UnitTesting;
using homework6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework6.Tests
{
    [TestClass()]
    public class PointTests
    {
        //測試constructor
        [TestMethod()]
        public void PointTest()
        {
            Point point = new Point();
            Assert.AreEqual(0, point.X);
            Assert.AreEqual(0, point.Y);
        }

        //測試constructor
        [TestMethod()]
        public void PointTest1()
        {
            Point point = new Point(10, 10);
            Assert.AreEqual((double)10, point.X);
            Assert.AreEqual((double)10, point.Y);
        }

        //測試constructor
        [TestMethod()]
        public void PointTest2()
        {
            Point point = new Point(new Point(10, 10));
            Assert.AreEqual((double)10, point.X);
            Assert.AreEqual((double)10, point.Y);
        }

        //測試GetDifferenceX
        [TestMethod()]
        public void GetDifferenceXTest()
        {
            Point point = new Point(10, 15);
            Point anotherPoint = new Point(0, 0);
            Assert.AreEqual(10, point.GetDifferenceX(anotherPoint));
        }

        //測試GetDifferenceY
        [TestMethod()]
        public void GetDifferenceYTest()
        {
            Point point = new Point(10, 15);
            Point anotherPoint = new Point(0, 0);
            Assert.AreEqual(15, point.GetDifferenceY(anotherPoint));
        }

        //測試IsValid
        [TestMethod()]
        public void IsValidTest()
        {
            Assert.IsTrue(new Point(0, 0).IsValid());
            Assert.IsFalse(new Point(-1, -1).IsValid());
        }

        //測試GetRelativePosition
        [TestMethod()]
        public void GetRelativePositionTest()
        {
            Point origin = new Point(0, 0);
            Point point = new Point(100, 100);
            Point anotherPoint = new Point(200, 100);
            Assert.AreEqual(100, point.GetRelativePosition(origin).X);
            Assert.AreEqual(100, point.GetRelativePosition(origin).Y);
            Assert.AreEqual(-100, origin.GetRelativePosition(point).X);
            Assert.AreEqual(-100, origin.GetRelativePosition(point).Y);
        }
    }
}