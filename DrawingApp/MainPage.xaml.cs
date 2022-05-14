using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using homework6;
using DrawingApp.PresentationModel;
// 空白頁項目範本已記錄在 https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x404

namespace DrawingApp
{
    /// <summary>
    /// 可以在本身使用或巡覽至框架內的空白頁面。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Model _model;
        PresentationModel.PresentationModel _presentationModel;
        public MainPage()
        {
            this.InitializeComponent();
            _model = new Model();
            _presentationModel = new PresentationModel.PresentationModel(_model);
            _canvas.PointerPressed += HandleCanvasPressed;
            _canvas.PointerReleased += HandleCanvasReleased;
            _canvas.PointerMoved += HandleCanvasMoved;
            _rectangle.Click += HandleRectangleButtonClick;
            _ellipse.Click += HandleEllipseButtonClick;
            _line.Click += HandleLineButtonClick;
            _clear.Click += HandleClearButtonClick;
            _redo.Click += RedoHandler;
            _undo.Click += UndoHandler;
            _model._modelChanged += HandleModelChanged;
            _model.Type = ShapeFactory.ShapeType.None;
            this.Bindings.Update();
        }

        //按下_rectangular
        public void HandleRectangleButtonClick(object sender, RoutedEventArgs e)
        {
            _model.Type = ShapeFactory.ShapeType.Rectangle;
            _presentationModel.IsEllipse = true;
            _presentationModel.IsRectangle = false;
            _presentationModel.IsLine = true;
        }

        //按下_ellipse
        public void HandleEllipseButtonClick(object sender, RoutedEventArgs e)
        {
            _model.Type = ShapeFactory.ShapeType.Ellipse;
            _presentationModel.IsEllipse = false;
            _presentationModel.IsRectangle = true;
            _presentationModel.IsLine = true;
        }

        //按下_line
        public void HandleLineButtonClick(object sender, RoutedEventArgs e)
        {
            _model.Type = ShapeFactory.ShapeType.Line;
            _presentationModel.IsEllipse = true;
            _presentationModel.IsRectangle = true;
            _presentationModel.IsLine = false;
        }

        //按下_clear
        private void HandleClearButtonClick(object sender, RoutedEventArgs e)
        {
            _model.Clear();
            _presentationModel.IsClear = true;
            _presentationModel.IsEllipse = true;
            _presentationModel.IsRectangle = true;
            _model.Type = ShapeFactory.ShapeType.None;
            this.Bindings.Update();
        }

        //按下滑鼠
        public void HandleCanvasPressed(object sender, PointerRoutedEventArgs e)
        {
            _model.PressPointer(new homework6.Point(e.GetCurrentPoint(_canvas).Position.X,
            e.GetCurrentPoint(_canvas).Position.Y));
            this.Bindings.Update();
        }

        //放開滑鼠
        public void HandleCanvasReleased(object sender, PointerRoutedEventArgs e)
        {
            _model.ReleasePointer(new homework6.Point(e.GetCurrentPoint(_canvas).Position.X,
            e.GetCurrentPoint(_canvas).Position.Y));
            _presentationModel.IsClear = true;
            _presentationModel.IsEllipse = true;
            _presentationModel.IsRectangle = true;
            _presentationModel.IsLine = true;
            this.Bindings.Update();
            _model.Type = ShapeFactory.ShapeType.None;
        }

        //移動滑鼠
        public void HandleCanvasMoved(object sender, PointerRoutedEventArgs e)
        {
            _model.MovePointer(new homework6.Point(e.GetCurrentPoint(_canvas).Position.X,
            e.GetCurrentPoint(_canvas).Position.Y));
        }

        //model改變時
        public void HandleModelChanged()
        {
            _model.Draw(new WindowsStoreGraphicsAdaptor(_canvas));
        }

        //上一步
        void UndoHandler(object sender, RoutedEventArgs e)
        {
            _model.Undo();
            this.Bindings.Update();
        }

        //下一步
        void RedoHandler(object sender, RoutedEventArgs e)
        {
            _model.Redo();
            this.Bindings.Update();
        }
    }
}
