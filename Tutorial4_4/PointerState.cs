using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework6
{
    class PointerState : IState
    {    
        Point _firstPoint;
        //按下滑鼠
        public void PressPointer(Point point, Model model)
        {
            model.ChooseShape(point);
            _firstPoint = new Point(point);
        }

        //移動滑鼠
        public void MovePointer(Point point, Model model)
        {
            model.MoveShape(point);
            model.ChooseShape(point);
        }

        //放開滑鼠
        public void ReleasePointer(Point point, Model model)
        {
            if (!_firstPoint.Equal(point))
                model.ExecuteMoveCommand();
        }
    }
}
