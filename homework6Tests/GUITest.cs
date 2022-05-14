using homework6;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Threading.Tasks;

namespace homework6Tests
{
    [TestClass]
    public class GUITest
    {
        private Robot _robot;
        private string targetAppPath;
        private const string FORM = "Form1";
        /// <summary>
        /// Launches the Calculator
        /// </summary>
        // init
        [TestInitialize]
        public void Initialize()
        {
            var projectName = "DrawingFormTests";
            string solutionPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
            targetAppPath = Path.Combine(solutionPath, projectName, "bin", "Debug", "DrawingFormTest.lnk");
            _robot = new Robot(targetAppPath, FORM);
        }


        /// <summary>
        /// Closes the launched program
        /// </summary>
        [TestCleanup()]
        public void Cleanup()
        {
            _robot.CleanUp();
        }

        //測試畫圖與刪除
        [TestMethod()]
        public void DrawAndClear()
        {
            _robot.ClickButton("Ellipse");
            _robot.ClickAndHoldCanvas("_canvas", new Point(400, 130), new Point(300, 300));
            _robot.ClickButton("Rectangle");
            _robot.ClickAndHoldCanvas("_canvas", new Point(800, 130), new Point(300, 300));
            _robot.ClickButton("Line");
            _robot.ClickAndHoldCanvas("_canvas", new Point(600, 300), new Point(400, 0));
            _robot.ClickCanvas("_canvas", new Point(600, 250));
            Assert.AreEqual("SELECTED: Ellipse(399,130,699,429)", _robot.GetText("_selectedDetail"));
            _robot.ClickCanvas("_canvas", new Point(1000, 200));
            Assert.AreEqual("SELECTED: Rectangle(799,130,1099,429)", _robot.GetText("_selectedDetail"));
            _robot.ClickCanvas("_canvas", new Point(750, 279));
            _robot.Sleep(1);
            _robot.ClickButton("Clear");
            _robot.Sleep(1);
        }

        //測試畫雪人
        [TestMethod()]
        public void RedoAndUndo()
        {
            _robot.ClickButton("Rectangle");
            _robot.ClickAndHoldCanvas("_canvas", new Point(600, 50), new Point(100, 80));
            _robot.ClickButton("Undo");
            _robot.ClickButton("Redo");
            _robot.ClickCanvas("_canvas", new Point(650, 50));
            Assert.AreEqual("SELECTED: Rectangle(599,49,699,130)", _robot.GetText("_selectedDetail"));
            _robot.Sleep(1);
            _robot.ClickButton("Clear");
            _robot.Sleep(1);
        }
        //測試畫雪人
        [TestMethod()]
        public void DrawSnowman()
        {
            _robot.ClickButton("Rectangle");
            _robot.ClickAndHoldCanvas("_canvas", new Point(600, 50), new Point(100, 80));
            _robot.ClickButton("Rectangle");
            _robot.ClickAndHoldCanvas("_canvas", new Point(570, 130), new Point(160, 20));
            _robot.ClickButton("Ellipse");
            _robot.ClickAndHoldCanvas("_canvas", new Point(600, 130), new Point(100, 100));
            _robot.ClickButton("Ellipse");
            _robot.ClickAndHoldCanvas("_canvas", new Point(620, 150), new Point(20, 20));
            _robot.ClickButton("Ellipse");
            _robot.ClickAndHoldCanvas("_canvas", new Point(660, 150), new Point(20, 20));
            _robot.ClickButton("Rectangle");
            _robot.ClickAndHoldCanvas("_canvas", new Point(640, 180), new Point(20, 20));
            _robot.ClickButton("Ellipse");
            _robot.ClickAndHoldCanvas("_canvas", new Point(570, 220), new Point(160, 160));
            _robot.ClickButton("Ellipse");
            _robot.ClickAndHoldCanvas("_canvas", new Point(640, 250), new Point(20, 20));
            _robot.ClickButton("Ellipse");
            _robot.ClickAndHoldCanvas("_canvas", new Point(640, 280), new Point(20, 20));
            _robot.ClickButton("Rectangle");
            _robot.ClickAndHoldCanvas("_canvas", new Point(560, 180), new Point(10, 120));
            _robot.ClickButton("Rectangle");
            _robot.ClickAndHoldCanvas("_canvas", new Point(730, 180), new Point(10, 120));
            _robot.ClickButton("Undo");
            _robot.ClickButton("Redo");
            _robot.ClickAndHoldCanvas("_canvas", new Point(650, 60), new Point(100, 0));
            _robot.ClickButton("Save");
            _robot.ClickButton("OK");
            _robot.Sleep(5);
            _robot.ClickButton("Clear");
            _robot.ClickButton("Load");
            _robot.Sleep(5);
            _robot.ClickCanvas("_canvas", new Point(550, 50));
            Assert.AreEqual("SELECTED: Rectangle(499,49,599,130)", _robot.GetText("_selectedDetail"));
            _robot.ClickCanvas("_canvas", new Point(575, 130));
            Assert.AreEqual("SELECTED: Rectangle(569,130,729,149)", _robot.GetText("_selectedDetail"));
            _robot.ClickCanvas("_canvas", new Point(630, 140));
            Assert.AreEqual("SELECTED: Ellipse(599,130,699,229)", _robot.GetText("_selectedDetail"));
            _robot.ClickCanvas("_canvas", new Point(630, 150));
            Assert.AreEqual("SELECTED: Ellipse(619,149,639,169)", _robot.GetText("_selectedDetail"));
            _robot.ClickCanvas("_canvas", new Point(670, 150));
            Assert.AreEqual("SELECTED: Ellipse(659,149,679,169)", _robot.GetText("_selectedDetail"));
            _robot.ClickCanvas("_canvas", new Point(645, 180));
            Assert.AreEqual("SELECTED: Rectangle(639,179,659,199)", _robot.GetText("_selectedDetail"));
            _robot.ClickCanvas("_canvas", new Point(600, 260));
            Assert.AreEqual("SELECTED: Ellipse(569,220,729,379)", _robot.GetText("_selectedDetail"));
            _robot.ClickCanvas("_canvas", new Point(645, 255));
            Assert.AreEqual("SELECTED: Ellipse(639,250,659,269)", _robot.GetText("_selectedDetail"));
            _robot.ClickCanvas("_canvas", new Point(645, 285));
            Assert.AreEqual("SELECTED: Ellipse(639,280,659,299)", _robot.GetText("_selectedDetail"));
            _robot.ClickCanvas("_canvas", new Point(565, 180));
            Assert.AreEqual("SELECTED: Rectangle(559,179,569,299)", _robot.GetText("_selectedDetail"));
            _robot.ClickCanvas("_canvas", new Point(735, 180));
            Assert.AreEqual("SELECTED: Rectangle(729,179,739,299)", _robot.GetText("_selectedDetail"));
            _robot.Sleep(1);
            _robot.ClickButton("Clear"); 
            _robot.Sleep(1);
        }

        //測試移動
        [TestMethod]
        public void Move()
        {
            _robot.ClickButton("Ellipse");
            _robot.ClickAndHoldCanvas("_canvas", new Point(400, 130), new Point(300, 300));
            _robot.ClickButton("Rectangle");
            _robot.ClickAndHoldCanvas("_canvas", new Point(800, 130), new Point(300, 300));
            _robot.ClickButton("Line");
            _robot.ClickAndHoldCanvas("_canvas", new Point(600, 300), new Point(400, 0));
            _robot.ClickAndHoldCanvas("_canvas", new Point(500, 200), new Point(100, 100));
            _robot.ClickCanvas("_canvas", new Point(800, 500));
            Assert.AreEqual("SELECTED: Ellipse(599,330,899,629)", _robot.GetText("_selectedDetail"));
            _robot.Sleep(1);
        }
    }
}
;