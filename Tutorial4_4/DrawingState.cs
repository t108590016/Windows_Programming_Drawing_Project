using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework6
{
    class DrawingState : IState
    {
        //按下滑鼠
        public void PressPointer(Point point, Model model)
        {
            model.CreateShape(point);
        }

        //移動滑鼠
        public void MovePointer(Point point, Model model)
        {
            model.SetSecondPoint(point);
        }

        //放開滑鼠
        public void ReleasePointer(Point point, Model model)
        {
            model.CreateShape(point);
            model.ExecuteCommand();
            model.Type = ShapeFactory.ShapeType.None;
        }
    }
}
