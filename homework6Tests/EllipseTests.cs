using Microsoft.VisualStudio.TestTools.UnitTesting;
using homework6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using homework6Tests;

namespace homework6.Tests
{
    [TestClass()]
    public class EllipseTests
    {
        //測試constructor
        [TestMethod()]
        public void EllipseTest()
        {
            Ellipse ellipse = new Ellipse();
            Assert.AreEqual(0, ellipse.GetFirstX());
            Assert.AreEqual(0, ellipse.GetFirstY());
        }

        //測試constructor
        [TestMethod()]
        public void EllipseTest1()
        {
            Ellipse ellipse = new Ellipse(new Point(0, 0), new Point(100, 100));
            Assert.AreEqual(0, ellipse.GetFirstX());
            Assert.AreEqual(0, ellipse.GetFirstY());
            Assert.AreEqual(100, ellipse.GetSecondX());
            Assert.AreEqual(100, ellipse.GetSecondY());
            Assert.AreEqual(100, ellipse.GetWidth());
            Assert.AreEqual(100, ellipse.GetHeight());
        }

        //測試Draw
        [TestMethod()]
        public void DrawTest()
        {
            Ellipse ellipse = new Ellipse();
            ellipse.Draw(new TestGraphic());
        }

        //測試IsInShape
        [TestMethod()]
        public void IsInShapeTest()
        {
            Ellipse ellipse = new Ellipse(new Point(0, 0), new Point(100, 100));
            Point point = new Point(50, 50);
            Assert.IsTrue(ellipse.IsInShape(point));
            point = new Point(101, 100);
            Assert.IsFalse(ellipse.IsInShape(point));
        }

        //測試ToString
        [TestMethod()]
        public void ToStringTest()
        {
            Ellipse ellipse = new Ellipse(new Point(200, 200), new Point(100, 100));
            ellipse.IsChosen = true;
            Assert.AreEqual("Ellipse(100,100,200,200)", ellipse.ToString());
        }

        //測試GetCenterPoint
        [TestMethod()]
        public void GetCenterPointTest()
        {
            Ellipse ellipse = new Ellipse(new Point(200, 200), new Point(100, 100));
            Assert.AreEqual(150, ellipse.GetCenterPoint().X);
            Assert.AreEqual(150, ellipse.GetCenterPoint().Y);
        }

        //測試MoveShapeByOffset
        [TestMethod()]
        public void MoveShapeByOffsetTest()
        {
            Ellipse ellipse = new Ellipse(new Point(200, 200), new Point(100, 100));
            ellipse.MoveShapeByOffset(new Point(200, 200));
            Assert.AreEqual(300, ellipse.GetFirstX());
            Assert.AreEqual(300, ellipse.GetFirstY());
            Assert.AreEqual(400, ellipse.GetSecondX());
            Assert.AreEqual(400, ellipse.GetSecondY());
        }

        //測試MoveShape
        [TestMethod()]
        public void MoveShapeTest()
        {
            Ellipse ellipse = new Ellipse(new Point(200, 200), new Point(100, 100));
            ellipse.MoveShape(new Point(300, 300)); 
            Assert.AreEqual(300, ellipse.GetFirstX());
            Assert.AreEqual(300, ellipse.GetFirstY());
            Assert.AreEqual(400, ellipse.GetSecondX());
            Assert.AreEqual(400, ellipse.GetSecondY());
        }
    }
}