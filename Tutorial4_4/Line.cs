using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework6
{
    public class Line : Shape
    {
        const string SHAPE_NAME = "Line";
        Shape _firstShape;
        Shape _secondShape;
        public Line(Shape firstShape, Shape secondShape)
        {
            _firstShape = firstShape;
            _secondShape = secondShape;
            _isLine = true;
            _shapeName = SHAPE_NAME;
        }

        public Line()
        {
            _firstPoint = new Point();
            _secondPoint = new Point();
            _isLine = true;
            _shapeName = SHAPE_NAME;
        }

        public Shape FirstShape
        {
            set
            {
                _firstShape = value;
            }
        }
        public Shape SecondShape
        {
            set
            {
                _secondShape = value;
            }
        }

        //畫圖
        public override void Draw(IGraphics graphics)
        {
            if (_firstShape != null && _secondShape != null)
            {
                FirstPoint = _firstShape.GetCenterPoint();
                SecondPoint = _secondShape.GetCenterPoint();
            }
            graphics.DrawLine(this.FirstPoint, this.SecondPoint);
        }

        //移動
        public override void MoveShapeByOffset(Point point)
        {
        }

        //移動圖形
        public override void MoveShape(Point point)
        {
        }
    }
}
