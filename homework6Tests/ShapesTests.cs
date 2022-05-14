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
    public class ShapesTests
    {
        Shapes _shapes;
        //初始化
        [TestInitialize()]
        public void Initialize()
        {
            _shapes = new Shapes();
        }
        //測試constructor
        [TestMethod()]
        public void ShapesTest()
        {
            Shapes shapes = new Shapes();
            Assert.AreEqual(0, shapes.GetCount());
        }

        //測試Add
        [TestMethod()]
        public void AddTest()
        {
            Assert.AreEqual(0, _shapes.GetCount());
            _shapes.Add(new Rectangle());
            Assert.AreEqual(1, _shapes.GetCount());
        }

        //測試Clear
        [TestMethod()]
        public void ClearTest()
        {
            _shapes.Add(new Rectangle());
            Assert.AreEqual(1, _shapes.GetCount());
            _shapes.Clear();
            Assert.AreEqual(0, _shapes.GetCount());
        }

        //測試IndexAt
        [TestMethod()]
        public void IndexAtTest()
        {
            _shapes.Add(new Rectangle(new Point(123, 234), new Point(234, 345)));
            Assert.AreEqual(123, _shapes.IndexAt(0).GetFirstX());
            Assert.AreEqual(234, _shapes.IndexAt(0).GetFirstY());
            Assert.AreEqual(234, _shapes.IndexAt(0).GetSecondX());
            Assert.AreEqual(345, _shapes.IndexAt(0).GetSecondY());
            Assert.IsNull(_shapes.IndexAt(-1));
        }

        //測試GetShapes
        [TestMethod()]
        public void GetShapesTest()
        {
            Assert.AreEqual(_shapes.GetCount(), _shapes.GetShapes().Count());
        }

        //測試GetCount
        [TestMethod()]
        public void GetCountTest()
        {
            _shapes.Add(new Rectangle(new Point(123, 234), new Point(234, 345)));
            _shapes.Add(new Ellipse(new Point(123, 234), new Point(234, 345)));
            Assert.AreEqual(2, _shapes.GetCount());
        }

        //測試FindShape
        [TestMethod()]
        public void FindShapeTest()
        {
            _shapes.Add(new Rectangle(new Point(123, 234), new Point(234, 345)));
            Assert.AreEqual(0, _shapes.FindShape(new Point(200, 300)));
            Assert.AreEqual(-1, _shapes.FindShape(new Point(400, 500)));
        }

        //測試ToString
        [TestMethod()]
        public void ToStringTest()
        {
            Assert.AreEqual("", _shapes.GetString(-1));
        }

        //RemoveTheLastItem
        [TestMethod()]
        public void RemoveTheLastItemTest()
        {
            _shapes.Add(new Rectangle(new Point(123, 234), new Point(234, 345)));
            int original = _shapes.GetCount();
            _shapes.RemoveTheLastItem();
            int now = _shapes.GetCount();
            Assert.AreEqual(1, original - now);
        }

        //測試Draw
        [TestMethod()]
        public void DrawTest()
        {
            _shapes.Add(new Rectangle(new Point(123, 234), new Point(234, 345)));
            _shapes.Add(new Ellipse(new Point(123, 234), new Point(234, 345)));
            _shapes.Add(new Line());
            _shapes.Add(new Line());
            _shapes.Draw(new TestGraphic());
        }

        //測試ChooseShape
        [TestMethod()]
        public void ChooseShapeTest()
        {
            _shapes.Add(new Rectangle(new Point(123, 234), new Point(234, 345)));
            _shapes.Add(new Ellipse(new Point(123, 234), new Point(234, 345)));
            _shapes.Add(new Line());
            _shapes.Add(new Line());
            Assert.AreEqual("Rectangle(123,234,234,345)", _shapes.ChooseShape(new Point(123, 234)));
        }

        //測試GetShape
        [TestMethod()]
        public void GetShapeTest()
        {
            _shapes.Add(new Rectangle(new Point(123, 234), new Point(234, 345)));
            _shapes.Add(new Ellipse(new Point(123, 234), new Point(234, 345)));
            _shapes.Add(new Line());
            _shapes.Add(new Line());
            Assert.IsNotNull(_shapes.GetShape(new Point(123, 234)));
            Assert.IsNull(_shapes.GetShape(new Point(500, 500)));
        }
    }
}