using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework6
{
    class MoveCommand : ICommand
    {
        Shape _shape;
        Model _model;
        Point _point;
        Point _firstPoint;
        public MoveCommand(Model model, Shape shape, Point point, Point firstPoint)
        {
            _shape = shape;
            _model = model;
            _point = new Point(point);
            _firstPoint = new Point(firstPoint);
        }

        //執行
        public void Execute()
        {
            _model.MoveShape(_shape, _point);
        }

        //不執行
        public void Recover()
        {
            _model.MoveShape(_shape, _firstPoint);
        }
    }
}
