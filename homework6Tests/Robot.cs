using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Threading;
using System.Windows.Automation;
using System.Windows;
using System.Collections.Generic;
using OpenQA.Selenium;
using System.Windows.Input;
using System.Windows.Forms;
using OpenQA.Selenium.Interactions;
using homework6;

namespace homework6Tests
{
    public class Robot
    {
        const string APPLICATION = "app";
        const string DEVICE_NAME = "deviceName";
        const string DEVICE = "WindowsPC";
        const int TIME_OUT = 5;
        private WindowsDriver<WindowsElement> _driver;
        private Dictionary<string, string> _windowHandles;
        private string _root;
        private const string CONTROL_NOT_FOUND_EXCEPTION = "The specific control is not found!!";
        private const string WIN_APP_DRIVER_URI = "http://127.0.0.1:4723";
        protected WindowsDriver<WindowsElement> _session;

        // constructor
        public Robot(string targetAppPath, string root)
        {
            this.Initialize(targetAppPath, root);
        }

        // initialize
        public void Initialize(string targetAppPath, string root)
        {
            if (_session == null)
            {
                _root = root;
                var options = new AppiumOptions();
                options.AddAdditionalCapability(APPLICATION, targetAppPath);
                options.AddAdditionalCapability(DEVICE_NAME, DEVICE);
                _driver = new WindowsDriver<WindowsElement>(new Uri(WIN_APP_DRIVER_URI), options);
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(TIME_OUT);
                _windowHandles = new Dictionary<string, string>
                {
                    { 
                        _root, _driver.CurrentWindowHandle 
                    }
                };
            }
        }

        // clean up
        public void CleanUp()
        {
            SwitchTo(_root);
            _driver.CloseApp();
            _driver.Dispose();
        }

        // test
        public void SwitchTo(string formName)
        {
            if (_windowHandles.ContainsKey(formName))
                _driver.SwitchTo().Window(_windowHandles[formName]);
            else
                foreach (var windowHandle in _driver.WindowHandles)
                {
                    _driver.SwitchTo().Window(windowHandle);
                    try
                    {
                        _driver.FindElementByAccessibilityId(formName);
                        _windowHandles.Add(formName, windowHandle);
                        return;
                    }
                    catch 
                    {
                    }
                }
        }

        // test
        public void Sleep(Double time)
        {
            Thread.Sleep(TimeSpan.FromSeconds(time));
        }

        //test
        public void ClickAndHoldCanvas(string canvas, homework6.Point offset, homework6.Point moveOffset)
        {
            Actions builder = new Actions(_driver);
            AppiumWebElement canvasElement = _driver.FindElementByAccessibilityId(canvas);
            Actions signature = (Actions)builder.MoveToElement(canvasElement, (int)offset.X, (int)offset.Y).ClickAndHold().MoveByOffset((int)moveOffset.X, (int)moveOffset.Y);
            signature.Perform();
            signature.Release().Build().Perform();
        }

        //test
        public void ClickCanvas(string canvas, homework6.Point point)
        {
            Actions builder = new Actions(_driver);
            AppiumWebElement canvasElement = _driver.FindElementByAccessibilityId(canvas);
            Actions signature = (Actions)builder.MoveToElement(canvasElement, (int)point.X, (int)point.Y).ClickAndHold();
            signature.Perform();
            signature.Release().Build().Perform();
        }

        // test
        public void ClickButton(string name)
        {
            _driver.FindElementByName(name).Click();
        }

        //回傳文字
        public string GetText(string name)
        {
            return _driver.FindElementByAccessibilityId(name).Text;
        }
    }
}
