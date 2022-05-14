using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework6
{
    public interface IGraphics
    {
        //清除所有
        void ClearAll();
        
        //畫橢圓
        void DrawEllipse(Ellipse ellipse, bool isChosen);
        
        //畫方形
        void DrawRectangle(Rectangle rectangle, bool isChosen);

        //畫線
        void DrawLine(Point firstPoint, Point secondPoint);
    }
}
