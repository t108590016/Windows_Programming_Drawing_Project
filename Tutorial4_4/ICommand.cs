using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework6
{
    public interface ICommand
    {
        //執行
        void Execute();
        
        //不執行
        void Recover();
    }
}
