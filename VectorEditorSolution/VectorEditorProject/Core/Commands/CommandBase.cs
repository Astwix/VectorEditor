using System;

namespace VectorEditorProject.Core.Commands
{
    /// <summary>
    /// Базовая команда
    /// </summary>
    [Serializable]
    public abstract class CommandBase
    {
        public abstract void Do();
        public abstract void Undo();
    }
}
