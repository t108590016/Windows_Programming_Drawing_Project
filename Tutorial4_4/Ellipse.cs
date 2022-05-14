using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework6
{
    public class Ellipse : Shape
    {
        const string SHAPE_NAME = "Ellipse";
        const int AVERAGE = 2;
        public Ellipse()
        {
            this._firstPoint = new Point();
            this._secondPoint = new Point();
            _shapeName = SHAPE_NAME;
        }

        public Ellipse(Point firstPoint, Point secondPoint)
        {
            this.FirstPoint = firstPoint;
            this.SecondPoint = secondPoint;
            _shapeName = SHAPE_NAME;
        }
        //畫圖
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawEllipse(this, _isChosen);
        }

        //指定的點是否在圖形裡
        public override bool IsInShape(Point point)
        {
            double relativeX = this.GetRelativePosition(point).X;
            double relativeY = this.GetRelativePosition(point).Y;
            double width = this.GetHeight() / AVERAGE;
            double height = this.GetWidth() / AVERAGE;
            if (Math.Pow(relativeX, AVERAGE) / Math.Pow(width, AVERAGE) + Math.Pow(relativeY, AVERAGE) / Math.Pow(height, AVERAGE) <= 1)
                return true;
            return false;
        }

        //移動
        public override void MoveShapeByOffset(Point point)
        {
            Point firstPoint = new Point(this.UpperLeft);
            Point secondPoint = new Point(this.BottomRight);
            this.FirstPoint = new Point(firstPoint.X + point.X, firstPoint.Y + point.Y);
            this.SecondPoint = new Point(secondPoint.X + point.X, secondPoint.Y + point.Y);
        }

        //移動圖形
        public override void MoveShape(Point point)
        {
            double width = this.GetWidth();
            double height = this.GetHeight();
            this.FirstPoint = new Point(point);
            this.SecondPoint = new Point(point.X + width, point.Y + height);
        }
    }
}
