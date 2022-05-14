using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Media;
using homework6;
using System;

namespace DrawingApp.PresentationModel
{
    class WindowsStoreGraphicsAdaptor : IGraphics
    {
        const int COLLECTION = 10;
        const int DOT_RADIUS = 3;
        const int DOT_DIAMETER = DOT_RADIUS * 2;
        Canvas _canvas;
        public WindowsStoreGraphicsAdaptor(Canvas canvas)
        {
            this._canvas = canvas;
        }

        //清除全部
        public void ClearAll()
        {
            _canvas.Children.Clear();
        }

        //畫點
        public void DrawDot(float firstDimension, float secondDimension, float width, float height)
        {
            Windows.UI.Xaml.Shapes.Ellipse ellipse = new Windows.UI.Xaml.Shapes.Ellipse();
            ellipse.Height = height;
            ellipse.Width = width;
            ellipse.Stroke = new SolidColorBrush(Colors.Black);
            ellipse.Margin = new Windows.UI.Xaml.Thickness(firstDimension, secondDimension, 0, 0);
            ellipse.Fill = new SolidColorBrush(Colors.White);
            _canvas.Children.Add(ellipse);
        }

        //是否被選取
        public void IsChosen(float firstDimension, float secondDimension, float width, float height)
        {
            Windows.UI.Xaml.Shapes.Rectangle rectangle = new Windows.UI.Xaml.Shapes.Rectangle();
            rectangle.Height = height;
            rectangle.Width = width;
            rectangle.Stroke = new SolidColorBrush(Colors.Red);
            DoubleCollection collection = new DoubleCollection();
            collection.Add(COLLECTION);
            collection.Add(COLLECTION);
            rectangle.StrokeDashArray = collection;
            rectangle.Margin = new Windows.UI.Xaml.Thickness(firstDimension, secondDimension, 0, 0);
            _canvas.Children.Add(rectangle); 
            DrawDot(firstDimension - DOT_RADIUS, secondDimension - DOT_RADIUS, DOT_DIAMETER, DOT_DIAMETER);
            DrawDot(firstDimension + width - DOT_RADIUS, secondDimension - DOT_RADIUS, DOT_DIAMETER, DOT_DIAMETER);
            DrawDot(firstDimension + width - DOT_RADIUS, secondDimension + height - DOT_RADIUS, DOT_DIAMETER, DOT_DIAMETER);
            DrawDot(firstDimension - DOT_RADIUS, secondDimension + height - DOT_RADIUS, DOT_DIAMETER, DOT_DIAMETER);
        }

        //畫線
        public void DrawEllipse(homework6.Ellipse inputEllipse, bool isChosen)
        {
            Windows.UI.Xaml.Shapes.Ellipse ellipse = new Windows.UI.Xaml.Shapes.Ellipse();
            ellipse.Height = inputEllipse.GetHeight();
            ellipse.Width = inputEllipse.GetWidth();
            ellipse.Stroke = new SolidColorBrush(Colors.Black);
            ellipse.Margin = new Windows.UI.Xaml.Thickness(inputEllipse.UpperLeft.X, inputEllipse.UpperLeft.Y, 0, 0);
            ellipse.Fill = new SolidColorBrush(Colors.Green);
            _canvas.Children.Add(ellipse);
            if (isChosen)
                IsChosen((float)inputEllipse.UpperLeft.X, (float)inputEllipse.UpperLeft.Y, (float)ellipse.Width, (float)ellipse.Height);
        }

        //畫線
        public void DrawLine(homework6.Point firstPoint, homework6.Point secondPoint)
        {
            Windows.UI.Xaml.Shapes.Line line = new Windows.UI.Xaml.Shapes.Line();
            line.X1 = firstPoint.X;
            line.Y1 = firstPoint.Y;
            line.X2 = secondPoint.X;
            line.Y2 = secondPoint.Y;
            line.Stroke = new SolidColorBrush(Colors.Black);
            _canvas.Children.Add(line);
        }

        //畫方形
        public void DrawRectangle(homework6.Rectangle inputRectangle, bool isChosen)
        {
            Windows.UI.Xaml.Shapes.Rectangle rectangle = new Windows.UI.Xaml.Shapes.Rectangle();
            rectangle.Height = inputRectangle.GetHeight();
            rectangle.Width = inputRectangle.GetWidth();
            rectangle.Stroke = new SolidColorBrush(Colors.Black);
            rectangle.Margin = new Windows.UI.Xaml.Thickness(inputRectangle.GetFirstX(), inputRectangle.GetFirstY(), 0, 0);
            rectangle.Fill = new SolidColorBrush(Colors.Yellow);
            _canvas.Children.Add(rectangle);
            if (isChosen)
                IsChosen((float)inputRectangle.UpperLeft.X, (float)inputRectangle.UpperLeft.Y, (float)rectangle.Width, (float)rectangle.Height);
        }
    }
}
