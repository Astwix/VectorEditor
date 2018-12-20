using System;

namespace VectorEditorProject.Core.Commands
{
    [Serializable]
    public abstract class BaseCommand
    {
        public abstract void Do();
        public abstract void Undo();
    }
}
