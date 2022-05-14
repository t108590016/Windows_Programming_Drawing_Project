using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework6
{
    abstract public class Shape
    {
        const string SELECTED = "SELECTED: ";
        const string LEFT = "(";
        const string RIGHT = ")";
        const string COMMA = ",";
        protected Point _firstPoint = new Point();
        protected Point _secondPoint = new Point();
        protected bool _isChosen = false;
        protected string _shapeName = "";
        protected bool _isLine = false;

        public string ShapeName
        {
            get
            {
                return _shapeName;
            }
        }

        public bool IsLine
        {
            get
            {
                return _isLine;
            }
        }

        public Point FirstPoint
        {
            get
            {
                return _firstPoint;
            }
            set
            {
                this._firstPoint = new Point(value);
            }
        }

        public Point SecondPoint
        {
            get
            {
                return _secondPoint;
            }
            set
            {
                _secondPoint = value;
                //this._firstPoint = new Point(Math.Min(value.X, x), Math.Min(value.Y, y));
                //this._secondPoint = new Point(Math.Max(value.X, x), Math.Max(value.Y, y));
            }
        }

        public Point UpperLeft
        {
            get
            {
                return new Point(Math.Min(_firstPoint.X, _secondPoint.X), Math.Min(_firstPoint.Y, _secondPoint.Y));
            }
        }
        public Point BottomRight
        {
            get
            {
                return new Point(Math.Max(_firstPoint.X, _secondPoint.X), Math.Max(_firstPoint.Y, _secondPoint.Y));
            }
        }
        public bool IsChosen
        {
            get
            {
                return _isChosen;
            }
            set
            {
                _isChosen = value;
            }
        }

        //回傳相對位置的X
        public Point GetRelativePosition(Point point)
        {
            return point.GetRelativePosition(GetCenterPoint());
        }

        //畫圖
        public abstract void Draw(IGraphics graphics);

        //回傳第一個點的X
        public double GetFirstX()
        {
            return this.UpperLeft.X;
        }

        //回傳第一個點的Y
        public double GetFirstY()
        {
            return this.UpperLeft.Y;
        }

        //回傳第二個點的X
        public double GetSecondX()
        {
            return this.BottomRight.X;
        }

        //回傳第二個點的Y
        public double GetSecondY()
        {
            return this.BottomRight.Y;
        }

        //回傳寬
        public double GetWidth()
        {
            return this.BottomRight.GetDifferenceX(UpperLeft);
        }

        //回傳高
        public double GetHeight()
        {
            return this.BottomRight.GetDifferenceY(UpperLeft);
        }

        //指定的點是否在圖形裡
        public virtual bool IsInShape(Point point)
        {
            if (this.GetFirstX() <= point.X && this.GetFirstY() <= point.Y && this.GetSecondX() >= point.X && this.GetSecondY() >= point.Y)
                return true;
            return false;
        }

        //如果被選取，回傳資訊
        public override string ToString()
        {
            return _shapeName + LEFT + (int)UpperLeft.X + COMMA + (int)UpperLeft.Y + COMMA + (int)BottomRight.X + COMMA + (int)BottomRight.Y + RIGHT;
        }

        //回傳中心點
        public Point GetCenterPoint()
        {
            const int AVERAGE = 2;
            return new Point((GetFirstX() + GetSecondX()) / AVERAGE, (GetFirstY() + GetSecondY()) / AVERAGE);
        }

        //移動圖形
        public abstract void MoveShapeByOffset(Point point);

        //移動圖形
        public abstract void MoveShape(Point point);
    }
}
