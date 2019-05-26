using System.IO;
using SDK;
using VectorEditorProject.Core.Commands;

namespace VectorEditorProject.Core
{
    public interface IControlUnit
    {
        IEditContext EditContext { get; set; }

        void Copy();
        void Delete();
        void Deserialize(Stream stream);
        void Do();
        string GetActiveFigureType();
        FillSettings GetActiveFillSettings();
        LineSettings GetActiveLineSettings();
        IDocument GetDocument();
        bool IsFileHaveUnsavedChanges();
        void Paste();
        void Reset();
        void Serialize(Stream stream);
        void StoreCommand(CommandBase command);
        void Undo();
        void UpdateCanvas();
        void UpdatePropertyGrid();
    }
}