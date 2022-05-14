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
    public class LineTests
    {
        //測試constructor
        [TestMethod()]
        public void LineTest()
        {
            Line line = new Line();
            Assert.AreEqual(0, line.GetFirstX());
            Assert.AreEqual(0, line.GetFirstY());
            Assert.AreEqual(0, line.GetSecondX());
            Assert.AreEqual(0, line.GetSecondY());
        }

        //測試constructor
        [TestMethod()]
        public void LineTest1()
        {
            Rectangle rectangle = new Rectangle();
            Ellipse ellipse = new Ellipse();
            Line line = new Line(rectangle, ellipse);
            Assert.AreEqual(0, line.GetFirstX());
            Assert.AreEqual(0, line.GetFirstY());
            Assert.AreEqual(0, line.GetSecondX());
            Assert.AreEqual(0, line.GetSecondY());
        }

        //測試Draw
        [TestMethod()]
        public void DrawTest()
        {
            Line line = new Line();
            Rectangle rectangle = new Rectangle(new Point(100, 100), new Point(300, 300));
            Ellipse ellipse = new Ellipse(new Point(400, 400), new Point(500, 500));
            line.FirstShape = rectangle;
            line.SecondShape = ellipse;
            line.Draw(new TestGraphic());
            Assert.AreEqual(200, line.GetFirstX());
            Assert.AreEqual(200, line.GetFirstY());
            Assert.AreEqual(450, line.GetSecondX());
            Assert.AreEqual(450, line.GetSecondY());
        }

        //測試MoveShapeByOffset
        [TestMethod()]
        public void MoveShapeByOffsetTest()
        {
            Line line = new Line();
            Rectangle rectangle = new Rectangle(new Point(100, 100), new Point(300, 300));
            Ellipse ellipse = new Ellipse(new Point(400, 400), new Point(500, 500));
            line.FirstShape = rectangle;
            line.SecondShape = ellipse;
            line.Draw(new TestGraphic());
            line.MoveShapeByOffset(new Point(300, 300));
            Assert.AreEqual(200, line.GetFirstX());
            Assert.AreEqual(200, line.GetFirstY());
            Assert.AreEqual(450, line.GetSecondX());
            Assert.AreEqual(450, line.GetSecondY());
        }

        //測試MoveShape
        [TestMethod()]
        public void MoveShapeTest()
        {
            Line line = new Line();
            Rectangle rectangle = new Rectangle(new Point(100, 100), new Point(300, 300));
            Ellipse ellipse = new Ellipse(new Point(400, 400), new Point(500, 500));
            line.FirstShape = rectangle;
            line.SecondShape = ellipse;
            line.Draw(new TestGraphic());
            line.MoveShape(new Point(300, 300));
            Assert.AreEqual(200, line.GetFirstX());
            Assert.AreEqual(200, line.GetFirstY());
            Assert.AreEqual(450, line.GetSecondX());
            Assert.AreEqual(450, line.GetSecondY());
        }
    }
}