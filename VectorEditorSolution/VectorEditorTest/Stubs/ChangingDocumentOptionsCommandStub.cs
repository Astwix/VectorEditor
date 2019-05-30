using System.Drawing;
using VectorEditorProject.Core;
using VectorEditorProject.Core.Commands;

namespace VectorEditorTest.Stubs
{
    class ChangingDocumentOptionsCommandStub : ChangingDocumentOptionsCommand
    {
        public ChangingDocumentOptionsCommandStub(IControlUnit controlUnit, 
            Document newOptions) : base(controlUnit, newOptions)
        {
        }

        public Size NewSize
        {
            get => _newSize;
        }

        public Size BackUpSize
        {
            get => _backUpSize;
        }

        public Color NewColor
        {
            get => _newColor;
        }

        public Color BackUpColor
        {
            get => _backUpColor;
        }

        public string NewName
        {
            get => _newName;
        }

        public string BackUpName
        {
            get => _backUpName;
        }
    }

}
