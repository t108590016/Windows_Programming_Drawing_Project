using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework6
{
    public class DrawCommand : ICommand
    {
        Shape _shape;
        Model _model;
        public DrawCommand(Model model, Shape shape)
        {
            _shape = shape;
            _model = model;
        }

        //執行
        public void Execute()
        {
            if (_shape != null)
                _model.DrawShape(_shape);
        }

        //不執行
        public void Recover()
        {
            _model.DeleteShape();
        }
    }
}
