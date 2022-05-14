using Microsoft.VisualStudio.TestTools.UnitTesting;
using homework6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework6Tests
{
    [TestClass()]
    public class CommandManagerTests
    {
        CommandManager commandManager;
        //初始化
        [TestInitialize()]
        public void Initialize()
        {
            commandManager = new CommandManager();
        }

        //測試Execute
        [TestMethod()]
        public void ExecuteTest()
        {
            Assert.IsFalse(commandManager.IsUndoEnabled);
            commandManager.Execute(new TestCommand());
            Assert.IsTrue(commandManager.IsUndoEnabled);
        }

        //測試Undo
        [TestMethod()]
        public void UndoTest()
        {
            try
            {
                commandManager.Undo();
            }
            catch (Exception exception)
            {
                Assert.IsNotNull(exception);
            }
            Assert.IsFalse(commandManager.IsUndoEnabled);
            commandManager.Execute(new TestCommand());
            commandManager.Execute(new TestCommand());
            commandManager.Execute(new TestCommand());
            Assert.IsTrue(commandManager.IsUndoEnabled);
        }

        //測試Redo
        [TestMethod()]
        public void RedoTest()
        {
            try
            {
                commandManager.Redo();
            }
            catch (Exception exception)
            {
                Assert.IsNotNull(exception);
            }
            Assert.IsFalse(commandManager.IsUndoEnabled);
            commandManager.Execute(new TestCommand());
            commandManager.Execute(new TestCommand());
            commandManager.Execute(new TestCommand());
            commandManager.Undo();
            Assert.IsTrue(commandManager.IsRedoEnabled);
            commandManager.Redo();
            Assert.IsFalse(commandManager.IsRedoEnabled);
        }

        //測試Clear
        [TestMethod()]
        public void ClearTest()
        {
            Assert.IsFalse(commandManager.IsUndoEnabled);
            commandManager.Execute(new TestCommand());
            commandManager.Execute(new TestCommand());
            commandManager.Execute(new TestCommand());
            commandManager.Undo();
            commandManager.Clear();
            Assert.IsFalse(commandManager.IsUndoEnabled);
            Assert.IsFalse(commandManager.IsRedoEnabled);
        }
    }
}