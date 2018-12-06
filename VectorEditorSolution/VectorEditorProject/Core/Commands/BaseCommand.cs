namespace VectorEditorProject.Core.Commands
{
    public abstract class BaseCommand
    {
        public abstract void Do();
        public abstract void Undo();
    }
}
