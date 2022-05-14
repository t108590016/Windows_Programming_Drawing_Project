using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingForm.PresentationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using homework6;
using DrawingForm;
using System.Windows.Forms;
using System.Drawing;

namespace DrawingForm.PresentationModel.Tests
{
    [TestClass()]
    public class PresentationModelTests
    {
        Model _model;
        PresentationModel _presentationModel;
        //初始化
        [TestInitialize]
        public void Initialize()
        {
            _model = new Model();
            PresentationModel _presentationModel = new PresentationModel(_model);
        }

        //測試Notify
        [TestMethod()]
        public void NotifyTest()
        {
            _presentationModel = new PresentationModel(_model);
            List<string> notifications = new List<string>();
            _presentationModel.PropertyChanged += (o, e) => { notifications.Add(e.PropertyName); };
            _presentationModel.IsClear = true;
            Assert.AreEqual("IsClear", notifications[0]);
            _presentationModel.IsEllipse = true;
            Assert.AreEqual("IsEllipse", notifications[1]);
            _presentationModel.IsRectangle = true;
            Assert.AreEqual("IsRectangle", notifications[2]);
        }
    }
}