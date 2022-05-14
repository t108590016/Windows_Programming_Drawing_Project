using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework6
{
    interface IState
    {
        //按下滑鼠
        void PressPointer(Point point, Model model);
        //移動滑鼠
        void MovePointer(Point point, Model model);
        //放開滑鼠
        void ReleasePointer(Point point, Model model);
    }
}
