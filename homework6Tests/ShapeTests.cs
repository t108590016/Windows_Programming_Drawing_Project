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
    public class ShapeTests
    {
        Shape _shape;
        //初始化
        [TestInitialize()]
        public void Initialize()
        {
            _shape = new Rectangle();
        }

        //測試Draw
        [TestMethod()]
        public void DrawTest()
        {
            _shape.Draw(new TestGraphic());
        }

        //測試GetFirstX
        [TestMethod()]
        public void GetFirstXTest()
        {
            _shape.FirstPoint = new Point(100, 100);
            _shape.SecondPoint = new Point(100, 100);
            Assert.AreEqual(100, _shape.GetFirstX());
        }

        //測試GetFirstY
        [TestMethod()]
        public void GetFirstYTest()
        {
            _shape.FirstPoint = new Point(100, 100); 
            _shape.SecondPoint = new Point(100, 100);
            Assert.AreEqual(100, _shape.GetFirstY());
        }

        //測試GetSecondX
        [TestMethod()]
        public void GetSecondXTest()
        {
            _shape.FirstPoint = new Point(100, 100);
            _shape.SecondPoint = new Point(100, 100);
            Assert.AreEqual(100, _shape.GetSecondX());
        }

        //測試GetSecondY
        [TestMethod()]
        public void GetSecondYTest()
        {
            _shape.FirstPoint = new Point(100, 100);
            _shape.SecondPoint = new Point(100, 100);
            Assert.AreEqual(100, _shape.GetSecondY());
        }

        //測試GetWidth
        [TestMethod()]
        public void GetWidthTest()
        {
            _shape.FirstPoint = new Point(200, 200);
            _shape.SecondPoint = new Point(100, 100);
            Assert.AreEqual(100, _shape.GetWidth());
        }

        //測試GetHeight
        [TestMethod()]
        public void GetHeightTest()
        {
            _shape.FirstPoint = new Point(200, 200);
            _shape.SecondPoint = new Point(100, 100);
            Assert.AreEqual(100, _shape.GetHeight());
        }

        //測試IsInShape
        [TestMethod()]
        public void IsInShapeTest()
        {
            _shape.FirstPoint = new Point(200, 200);
            _shape.SecondPoint = new Point(100, 100);
            Assert.IsTrue(_shape.IsInShape(new Point(150, 150)));
            Assert.IsFalse(_shape.IsInShape(new Point(50, 50)));
        }

        //測試ToString
        [TestMethod()]
        public void ToStringTest()
        {
            _shape.FirstPoint = new Point(200, 200);
            _shape.SecondPoint = new Point(100, 100);
            _shape.IsChosen = true;
            Assert.AreEqual("Rectangle(100,100,200,200)", _shape.ToString());
        }

        //測試GetCenterPoint
        [TestMethod()]
        public void GetCenterPointTest()
        {
            _shape.FirstPoint = new Point(200, 200);
            _shape.SecondPoint = new Point(100, 100);
            Assert.AreEqual(150, _shape.GetCenterPoint().X);
            Assert.AreEqual(150, _shape.GetCenterPoint().Y);
        }

        //測試GetRelativePosition
        [TestMethod()]
        public void GetRelativePositionTest()
        {
            _shape.FirstPoint = new Point(200, 200);
            _shape.SecondPoint = new Point(100, 100);
            Assert.AreEqual(0, _shape.GetRelativePosition(new Point(150, 150)).X);
            Assert.AreEqual(0, _shape.GetRelativePosition(new Point(150, 150)).Y);
        }
    }
}