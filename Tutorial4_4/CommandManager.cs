using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework6
{
    public class CommandManager
    {
        const string REDO_EXCEPTION = "Cannot Redo exception\n";
        const string UNDO_EXCEPTION = "Cannot Undo exception\n";
        Stack<ICommand> _undo = new Stack<ICommand>();
        Stack<ICommand> _redo = new Stack<ICommand>();

        //執行
        public void Execute(ICommand command)
        {
            command.Execute();
            _undo.Push(command);
            _redo.Clear();
        }

        //復原
        public void Undo()
        {
            if (_undo.Count <= 0)
                throw new Exception(UNDO_EXCEPTION);
            ICommand command = _undo.Pop();
            _redo.Push(command);
            command.Recover();
        }

        //回到下一步
        public void Redo()
        {
            if (_redo.Count <= 0)
                throw new Exception(REDO_EXCEPTION);
            ICommand command = _redo.Pop();
            _undo.Push(command);
            command.Execute();
        }

        //清除
        public void Clear()
        {
            _undo.Clear();
            _redo.Clear();
        }

        public bool IsRedoEnabled
        {
            get
            {
                return _redo.Count != 0;
            }
        }

        public bool IsUndoEnabled
        {
            get
            {
                return _undo.Count != 0;
            }
        }

    }
}
