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
    public class RectangleTests
    {
        //測試constructor
        [TestMethod()]
        public void RectangleTest()
        {
            Rectangle rectangle = new Rectangle();
            Assert.AreEqual(0, rectangle.GetFirstX());
            Assert.AreEqual(0, rectangle.GetFirstY());
        }

        //測試constructor
        [TestMethod()]
        public void RectangleTest1()
        {
            Rectangle rectangle = new Rectangle(new Point(200, 200), new Point(100, 100));
            Assert.AreEqual(100, rectangle.GetFirstX());
            Assert.AreEqual(100, rectangle.GetFirstY());
            Assert.AreEqual(200, rectangle.GetSecondX());
            Assert.AreEqual(200, rectangle.GetSecondY());
            Assert.AreEqual(100, rectangle.GetWidth());
            Assert.AreEqual(100, rectangle.GetHeight());
            rectangle.SecondPoint = rectangle.FirstPoint;
            rectangle.FirstPoint = new Point(50, 50);
            Assert.AreEqual(50, rectangle.GetFirstX());
            Assert.AreEqual(50, rectangle.GetFirstY());
            Assert.AreEqual(200, rectangle.GetSecondX());
            Assert.AreEqual(200, rectangle.GetSecondY());
        }

        //測試Draw
        [TestMethod()]
        public void DrawTest()
        {
            Rectangle rectangle = new Rectangle();
            rectangle.Draw(new TestGraphic());
        }

        //測試IsInShape
        [TestMethod()]
        public void IsInShapeTest()
        {
            Rectangle rectangle = new Rectangle(new Point(200, 200), new Point(100, 100));
            Point point = new Point(120, 150);
            Assert.IsTrue(rectangle.IsInShape(point));
            point = new Point(99, 100);
            Assert.IsFalse(rectangle.IsInShape(point));
        }

        //測試ToString
        [TestMethod()]
        public void ToStringTest()
        {
            Rectangle rectangle = new Rectangle(new Point(200, 200), new Point(100, 100));
            rectangle.IsChosen = true;
            Assert.AreEqual("Rectangle(100,100,200,200)", rectangle.ToString());
        }

        //測試GetCenterPoint
        [TestMethod()]
        public void GetCenterPointTest()
        {
            Rectangle rectangle = new Rectangle(new Point(200, 200), new Point(100, 100));
            Assert.AreEqual(150, rectangle.GetCenterPoint().X);
            Assert.AreEqual(150, rectangle.GetCenterPoint().Y);
        }

        //測試MoveShapeByOffset
        [TestMethod()]
        public void MoveShapeByOffsetTest()
        {
            Rectangle rectangle = new Rectangle(new Point(200, 200), new Point(100, 100));
            rectangle.MoveShapeByOffset(new Point(200, 200));
            Assert.AreEqual(300, rectangle.FirstPoint.X);
            Assert.AreEqual(300, rectangle.FirstPoint.Y);
        }

        //測試MoveShape
        [TestMethod()]
        public void MoveShapeTest()
        {
            Rectangle rectangle = new Rectangle(new Point(200, 200), new Point(100, 100));
            rectangle.MoveShape(new Point(300, 300));
            Assert.AreEqual(300, rectangle.FirstPoint.X);
            Assert.AreEqual(300, rectangle.FirstPoint.Y);
        }
    }
}