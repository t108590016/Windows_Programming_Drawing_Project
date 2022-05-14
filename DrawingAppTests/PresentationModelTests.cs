using System;
using System.Collections.Generic;
using DrawingApp.PresentationModel;
using homework6;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Windows.UI.Xaml.Controls;

namespace DrawingAppTests
{
    [TestClass()]
    public class PresentationModelTests
    {
        Model _model;
        PresentationModel _presentationModel;
        //初始化
        [TestInitialize()]
        public void Initialize()
        {
            _model = new Model();
            PresentationModel _presentationModel = new PresentationModel(_model);
        }

        //測試Constructor
        [TestMethod()]
        public void PresentationModelTest()
        {
            Canvas canvas = new Canvas();
            PresentationModel presentationModel = new PresentationModel(_model);
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
