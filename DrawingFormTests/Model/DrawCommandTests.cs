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
    public class DrawCommandTests
    {
        Shape _shape;
        Model _model;

        //初始化
        [TestInitialize()]
        public void Initialize()
        {
            _model = new Model();
            _shape = new Rectangle();
        }

        //測試Constructor
        [TestMethod()]
        public void DrawCommandTest()
        {
            DrawCommand drawCommand = new DrawCommand(_model, _shape);
        }

        //測試Execute
        [TestMethod()]
        public void ExecuteTest()
        {
            DrawCommand drawCommand = new DrawCommand(_model, _shape);
            Assert.AreEqual(0, _model.GetShapes.GetCount());
            drawCommand.Execute();
            Assert.AreEqual(1, _model.GetShapes.GetCount());
        }
        
        //測試UnExecute
        [TestMethod()]
        public void UnExecuteTest()
        {
            DrawCommand drawCommand = new DrawCommand(_model, _shape);
            Assert.AreEqual(0, _model.GetShapes.GetCount());
            drawCommand.Execute();
            Assert.AreEqual(1, _model.GetShapes.GetCount());
            drawCommand.Recover();
            Assert.AreEqual(0, _model.GetShapes.GetCount());
        }
    }
}