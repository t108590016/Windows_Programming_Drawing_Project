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
    public class ShapeFactoryTests
    {
        ShapeFactory factory = new ShapeFactory();
        
        //測試CreateShape
        [TestMethod()]
        public void CreateShapeTest()
        {
            ShapeFactory.ShapeType type ;
            type = ShapeFactory.ShapeType.Rectangle;
            Assert.AreEqual("Rectangle", factory.CreateShape(type).ShapeName);
            type = ShapeFactory.ShapeType.Ellipse;
            Assert.AreEqual("Ellipse", factory.CreateShape(type).ShapeName);
            type = ShapeFactory.ShapeType.Line;
            Assert.AreEqual("Line", factory.CreateShape(type).ShapeName);
            type = ShapeFactory.ShapeType.None;
            factory.CreateShape(type);
        }
    }
}