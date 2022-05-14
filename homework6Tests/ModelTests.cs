using Microsoft.VisualStudio.TestTools.UnitTesting;
using homework6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using homework6Tests;
using System.IO;

namespace homework6.Tests
{
    [TestClass()]
    public class ModelTests
    {
        Model _model;
        //初始化
        [TestInitialize()]
        public void Initialize()
        {
            _model = new Model();
        }

        //測試PressPointer
        [TestMethod()]
        public void PressPointerTest()
        {
            _model.Type = ShapeFactory.ShapeType.Ellipse;
            _model.PressPointer(new homework6.Point(0, 0));
            Assert.AreEqual(0, _model.GetShape.GetFirstX());
            Assert.AreEqual(0, _model.GetShape.GetFirstY());
        }

        //測試MovePointer
        [TestMethod()]
        public void MovePointerTest()
        {
            _model.Type = ShapeFactory.ShapeType.Ellipse;
            _model.PressPointer(new homework6.Point(0, 0));
            _model.MovePointer(new homework6.Point(100, 250));
            Assert.AreEqual(0, _model.GetShape.UpperLeft.X);
            Assert.AreEqual(0, _model.GetShape.UpperLeft.Y);
            Assert.AreEqual(100, _model.GetShape.BottomRight.X);
            Assert.AreEqual(250, _model.GetShape.BottomRight.Y);
            _model.Type = ShapeFactory.ShapeType.Rectangle;
            _model.PressPointer(new homework6.Point(100, 39));
            _model.MovePointer(new homework6.Point(50, 20));
            Assert.AreEqual(50, _model.GetShape.UpperLeft.X);
            Assert.AreEqual(20, _model.GetShape.UpperLeft.Y);
            Assert.AreEqual(100, _model.GetShape.BottomRight.X);
            Assert.AreEqual(39, _model.GetShape.BottomRight.Y);
        }

        //測試ReleasePointer
        [TestMethod()]
        public void ReleasePointerTest()
        {
            _model.Type = ShapeFactory.ShapeType.Ellipse;
            _model.PressPointer(new homework6.Point(0, 0));
            _model.ReleasePointer(new homework6.Point(100, 250));
            Assert.AreEqual(1, _model.GetShapes.GetCount());
            Assert.AreEqual(0, _model.GetShapes.IndexAt(0).UpperLeft.X);
            Assert.AreEqual(0, _model.GetShapes.IndexAt(0).UpperLeft.Y);
            Assert.AreEqual(100, _model.GetShapes.IndexAt(0).BottomRight.X);
            Assert.AreEqual(250, _model.GetShapes.IndexAt(0).BottomRight.Y);
            _model.Type = ShapeFactory.ShapeType.Rectangle;
            _model.PressPointer(new homework6.Point(100, 39));
            _model.ReleasePointer(new homework6.Point(50, 20));
            Assert.AreEqual(2, _model.GetShapes.GetCount());
            Assert.AreEqual(50, _model.GetShapes.IndexAt(1).UpperLeft.X);
            Assert.AreEqual(20, _model.GetShapes.IndexAt(1).UpperLeft.Y);
            Assert.AreEqual(100, _model.GetShapes.IndexAt(1).BottomRight.X);
            Assert.AreEqual(39, _model.GetShapes.IndexAt(1).BottomRight.Y);
            _model.Type = ShapeFactory.ShapeType.Line;
            _model.PressPointer(new homework6.Point(50, 125));
            _model.ReleasePointer(new homework6.Point(75, 25));
            Assert.AreEqual(3, _model.GetShapes.GetCount());
            _model.Type = ShapeFactory.ShapeType.None;
            _model.PressPointer(new homework6.Point(50, 125));
            Assert.AreEqual("SELECTED: Ellipse(0,0,100,250)", _model.SelectedDetail);
            _model.PressPointer(new homework6.Point(70, 30));
            Assert.AreEqual("SELECTED: Rectangle(50,20,100,39)", _model.SelectedDetail);
        }

        //測試Clear
        [TestMethod()]
        public void ClearTest()
        {
            _model.Type = ShapeFactory.ShapeType.Ellipse;
            _model.PressPointer(new homework6.Point(0, 0));
            _model.ReleasePointer(new homework6.Point(100, 250));
            _model.Type = ShapeFactory.ShapeType.Rectangle;
            _model.PressPointer(new homework6.Point(100, 39));
            _model.ReleasePointer(new homework6.Point(50, 20));
            Assert.AreEqual(2, _model.GetShapes.GetCount());
            _model.Clear();
            Assert.AreEqual(0, _model.GetShapes.GetCount());
        }

        //測試Draw
        [TestMethod()]
        public void DrawTest()
        {
            TestGraphic graphic = new TestGraphic();
            Assert.AreEqual(0, _model.GetShapes.GetCount());
            _model.Type = ShapeFactory.ShapeType.Ellipse;
            _model.PressPointer(new homework6.Point(0, 0));
            _model.Draw(graphic);
            _model.ReleasePointer(new homework6.Point(100, 100));
            _model.Draw(graphic);
            _model.Type = ShapeFactory.ShapeType.Rectangle;
            _model.PressPointer(new homework6.Point(100, 39));
            _model.Draw(graphic);
            _model.ReleasePointer(new homework6.Point(50, 20));
            _model.Type = ShapeFactory.ShapeType.Line;
            _model.PressPointer(new homework6.Point(50, 50));
            _model.Draw(graphic);
            _model.ReleasePointer(new homework6.Point(75, 30));
            _model.Draw(graphic);
            Assert.AreEqual(3, _model.GetShapes.GetCount());
        }

        //測試NotifyModelChanged
        [TestMethod()]
        public void NotifyModelChangedTest()
        {
            bool triggered = false;
            _model._modelChanged += delegate { triggered = true; };
            _model.PressPointer(new Point(10, 10));
            Assert.IsTrue(triggered);
        }

        //測試Undo
        [TestMethod()]
        public void UndoTest()
        {
            Assert.AreEqual(0, _model.GetShapes.GetCount());
            _model.Type = ShapeFactory.ShapeType.Ellipse;
            _model.PressPointer(new homework6.Point(0, 0));
            _model.ReleasePointer(new homework6.Point(100, 250));
            Assert.IsTrue(_model.IsUndoEnabled);
            _model.Type = ShapeFactory.ShapeType.Ellipse;
            _model.PressPointer(new homework6.Point(0, 0));
            _model.ReleasePointer(new homework6.Point(100, 250));
            Assert.AreEqual(2, _model.GetShapes.GetCount());
            _model.Undo();
            _model.Undo();
            Assert.IsFalse(_model.IsUndoEnabled);
            Assert.AreEqual(0, _model.GetShapes.GetCount());
        }

        //測試DrawShape
        [TestMethod()]
        public void DrawShapeTest()
        {
            Assert.AreEqual(0, _model.GetShapes.GetCount());
            Rectangle rectangle = new Rectangle(new Point(0, 0), new Point(100, 100));
            _model.DrawShape(rectangle);
            Assert.AreEqual(1, _model.GetShapes.GetCount());
        }

        //測試DeleteShape
        [TestMethod()]
        public void DeleteShapeTest()
        {
            Assert.AreEqual(0, _model.GetShapes.GetCount());
            Rectangle rectangle = new Rectangle(new Point(0, 0), new Point(100, 100));
            _model.DrawShape(rectangle);
            Assert.AreEqual(1, _model.GetShapes.GetCount());
            _model.DeleteShape();
            Assert.AreEqual(0, _model.GetShapes.GetCount());
        }

        //測試Redo
        [TestMethod()]
        public void RedoTest()
        {
            Assert.AreEqual(0, _model.GetShapes.GetCount());
            _model.Type = ShapeFactory.ShapeType.Ellipse;
            _model.PressPointer(new homework6.Point(0, 0));
            _model.ReleasePointer(new homework6.Point(100, 250));
            _model.Type = ShapeFactory.ShapeType.Ellipse;
            _model.PressPointer(new homework6.Point(0, 0));
            _model.ReleasePointer(new homework6.Point(100, 250));
            Assert.AreEqual(2, _model.GetShapes.GetCount());
            _model.Undo();
            Assert.IsTrue(_model.IsRedoEnabled);
            _model.Redo();
            Assert.IsFalse(_model.IsRedoEnabled);
            Assert.AreEqual(2, _model.GetShapes.GetCount());
            _model.Type = ShapeFactory.ShapeType.None;
            _model.PressPointer(new homework6.Point(50, 125));
            Assert.AreEqual("SELECTED: Ellipse(0,0,100,250)", _model.SelectedDetail);
            _model.ReleasePointer(new homework6.Point(100, 250));
            Assert.AreEqual(2, _model.GetShapes.GetCount());
            _model.Undo();
            Assert.IsTrue(_model.IsRedoEnabled);
            _model.Redo();
            Assert.IsFalse(_model.IsRedoEnabled);
            Assert.AreEqual(2, _model.GetShapes.GetCount());
        }

        //測試Notify
        [TestMethod()]
        public void NotifyTest()
        {
            _model.SelectedDetail = "Test";
        }

        //測試MoveShape()
        [TestMethod()]
        public void MoveShapeTest()
        {
            _model.Type = ShapeFactory.ShapeType.Ellipse;
            _model.PressPointer(new Point(100, 100));
            _model.MovePointer(new Point(200, 200));
            _model.SetSecondPoint(new Point(300, 300));
            Assert.AreEqual(300, _model.GetShape.GetSecondX());
            Assert.AreEqual(300, _model.GetShape.GetSecondY());
            _model.SetSecondPoint(new Point(200, 200));
            _model.ReleasePointer(new Point(200, 200));
            Assert.AreEqual(1, _model.GetShapes.GetCount());
            _model.ExecuteCommand();
            Assert.AreEqual(1, _model.GetShapes.GetCount());
            _model.Type = ShapeFactory.ShapeType.None;
            _model.PressPointer(new Point(100, 100));
            _model.MoveShape(new Point(300, 300));
            Assert.AreEqual(100, _model.GetShapes.IndexAt(0).GetFirstX());
            Assert.AreEqual(100, _model.GetShapes.IndexAt(0).GetFirstY());
            _model.MoveShape(_model.GetShapes.IndexAt(0), new Point(300, 300));
            Assert.AreEqual(300, _model.GetShapes.IndexAt(0).GetFirstX());
            Assert.AreEqual(300, _model.GetShapes.IndexAt(0).GetFirstY());
            _model.MovePointer(new Point(300, 300));
            _model.ReleasePointer(new Point(200, 200));
            _model.Type = ShapeFactory.ShapeType.Line;
            _model.PressPointer(new Point(100, 100));
            _model.MovePointer(new Point(300, 300));
            _model.ReleasePointer(new Point(200, 200)); 
            Assert.AreEqual(1, _model.GetShapes.GetCount());
            _model.ExecuteCommand();
            Assert.AreEqual(1, _model.GetShapes.GetCount());
        }

        //測試WriteAndReadFile()
        [TestMethod()]
        public async Task WriteAndReadFileAsync()
        {
            _model.Clear();
            _model.Type = ShapeFactory.ShapeType.Ellipse;
            _model.PressPointer(new Point(100, 100));
            _model.MovePointer(new Point(200, 200));
            _model.SetSecondPoint(new Point(300, 300));
            Assert.AreEqual(300, _model.GetShape.GetSecondX());
            Assert.AreEqual(300, _model.GetShape.GetSecondY());
            _model.SetSecondPoint(new Point(200, 200));
            _model.ReleasePointer(new Point(200, 200));
            Assert.AreEqual(1, _model.GetShapes.GetCount());
            await Task.Factory.StartNew(() => _model.WriteFile());
            _model.Clear();
            _model.ReadFile();
            Assert.AreEqual(1, _model.GetShapes.GetCount());
        }

    }
}