using System;

namespace VectorEditorProject.Core.Commands
{
    [Serializable]
    public abstract class CommandBase
    {
        public abstract void Do();
        public abstract void Undo();
    }
}
