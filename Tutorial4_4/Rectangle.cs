using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework6
{
    public class Rectangle : Shape
    {
        const string SHAPE_NAME = "Rectangle";

        public Rectangle()
        {
            this._firstPoint = new Point();
            this._secondPoint = new Point();
            _shapeName = SHAPE_NAME;
        }
        public Rectangle(Point firstPoint, Point secondPoint)
        {
            this.FirstPoint = firstPoint;
            this.SecondPoint = secondPoint;
            _shapeName = SHAPE_NAME;
        }

        //畫圖
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawRectangle(this, _isChosen);
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
