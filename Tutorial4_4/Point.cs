using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework6
{
    public class Point
    {
        private double _x;
        private double _y;
        public Point()
        {
            _x = 0;
            _y = 0;
        }

        public Point(double firstDimension, double secondDimension)
        {
            _x = firstDimension;
            _y = secondDimension;
        }

        public Point(Point newPoint)
        {
            this.X = newPoint.X;
            this.Y = newPoint.Y;
        }

        public double X
        {
            get
            {
                return _x;
            }
            set
            {
                this._x = value;
            }
        }

        public double Y
        {
            get
            {
                return _y;
            }
            set
            {
                this._y = value;
            }
        }

        //回傳x座標的差
        public double GetDifferenceX(Point anotherPoint)
        {
            return (this.X - anotherPoint.X);
        }

        //回傳y座標的差
        public double GetDifferenceY(Point anotherPoint)
        {
            return (this.Y - anotherPoint.Y);
        }

        //回傳該點是否合法
        public bool IsValid()
        {
            return this._x >= 0 & this._y >= 0;
        }

        //回傳相對位置
        public Point GetRelativePosition(Point referencePoint)
        {
            return new Point(this.X - referencePoint.X, this.Y - referencePoint.Y);
        }

        //回傳兩點是否相同
        public bool Equal(Point point)
        {
            return (this.X == point.X) && (this.Y == point.Y);
        }
    }
}
