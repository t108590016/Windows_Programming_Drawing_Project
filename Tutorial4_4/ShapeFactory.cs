using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework6
{
    public class ShapeFactory
    {
        public enum ShapeType
        {
            Rectangle,
            Ellipse,
            Line,
            None
        }
        
        //建立Shape
        public Shape CreateShape(ShapeType type)
        {
            switch (type)
            {
                case ShapeType.Rectangle:
                    return new Rectangle();
                case ShapeType.Ellipse:
                    return new Ellipse();
                case ShapeType.Line:
                    return new Line();
                case ShapeType.None:
                    break;
            }
            return null;
        }
    }
}
