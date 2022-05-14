using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using homework6;

namespace DrawingForm.PresentationModel
{
    class WindowsFormsGraphicsAdaptor : IGraphics
    {
        const int DOT_RADIUS = 3;
        const int DOT_DIAMETER = DOT_RADIUS * 2;
        const int ALPHA = 255;
        const int RED = 255;
        const int GREEN = 255;
        const int BLUE = 255;
        Graphics _graphics;
        public WindowsFormsGraphicsAdaptor(System.Drawing.Graphics graphics)
        {
            this._graphics = graphics;
        }

        public Graphics Graphics
        {
            get
            {
                return _graphics;
            }
            set
            {
                this._graphics = value;
            }
        }

        //畫點
        public void DrawDot(Brush brush, Pen pen, homework6.Point point, homework6.Point widthAndHeight)
        {
            _graphics.DrawEllipse(pen, (float)point.X, (float)point.Y, (float)widthAndHeight.X, (float)widthAndHeight.Y);
            _graphics.FillEllipse(brush, (float)point.X, (float)point.Y, (float)widthAndHeight.X, (float)widthAndHeight.Y);
        }

        //是否被選取
        public void IsChosen(float firstDimension, float secondDimension, float width, float height)
        {
            Pen pen = new Pen(Color.Red);
            pen.DashPattern = new float[] { 4.0F, 2.0F, 1.0F, 3.0F };
            _graphics.DrawRectangle(pen, firstDimension, secondDimension, width, height);
            SolidBrush solidBrush = new SolidBrush(Color.FromArgb(ALPHA, RED, GREEN, BLUE));
            DrawDot(solidBrush, Pens.Black, new homework6.Point(firstDimension - DOT_RADIUS, secondDimension - DOT_RADIUS), new homework6.Point(DOT_DIAMETER, DOT_DIAMETER));
            DrawDot(solidBrush, Pens.Black, new homework6.Point(firstDimension + width - DOT_RADIUS, secondDimension - DOT_RADIUS), new homework6.Point(DOT_DIAMETER, DOT_DIAMETER));
            DrawDot(solidBrush, Pens.Black, new homework6.Point(firstDimension + width - DOT_RADIUS, secondDimension + height - DOT_RADIUS), new homework6.Point(DOT_DIAMETER, DOT_DIAMETER));
            DrawDot(solidBrush, Pens.Black, new homework6.Point(firstDimension - DOT_RADIUS, secondDimension + height - DOT_RADIUS), new homework6.Point(DOT_DIAMETER, DOT_DIAMETER));
        }

        //清除全部
        public void ClearAll()
        {
            // OnPaint時會自動清除畫面，因此不需實作
        }

        //畫橢圓
        public void DrawEllipse(Ellipse ellipse, bool isChosen)
        {
            float firstDimension = (float)ellipse.UpperLeft.X;
            float secondDimension = (float)ellipse.UpperLeft.Y;
            float width = (float)ellipse.GetWidth();
            float height = (float)ellipse.GetHeight();
            _graphics.FillEllipse(Brushes.YellowGreen, firstDimension, secondDimension, width, height);
            _graphics.DrawEllipse(Pens.Black, firstDimension, secondDimension, width, height);
            if (isChosen)
                IsChosen(firstDimension, secondDimension, width, height);
        }

        //畫方形
        public void DrawRectangle(homework6.Rectangle rectangle, bool isChosen)
        {
            float firstDimension = (float)rectangle.UpperLeft.X;
            float secondDimension = (float)rectangle.UpperLeft.Y;
            float width = (float)rectangle.GetWidth();
            float height = (float)rectangle.GetHeight();
            _graphics.FillRectangle(Brushes.Yellow, firstDimension, secondDimension, width, height);
            _graphics.DrawRectangle(Pens.Black, firstDimension, secondDimension, width, height);
            if (isChosen)
                IsChosen(firstDimension, secondDimension, width, height);
        }

        //畫線
        public void DrawLine(homework6.Point firstPoint, homework6.Point secondPoint)
        {
            float firstDimensionX = (float)firstPoint.X;
            float firstDimensionY = (float)firstPoint.Y;
            float secondDimensionX = (float)secondPoint.X;
            float secondDimensionY = (float)secondPoint.Y;
            _graphics.DrawLine(Pens.Black, firstDimensionX, firstDimensionY, secondDimensionX, secondDimensionY);
        }
    }
}
