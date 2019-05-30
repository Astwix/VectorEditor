using System.Collections.Generic;
using SDK;
using VectorEditorProject.Core;
using VectorEditorProject.Core.Commands;

namespace VectorEditorTest.Stubs
{
    class ClearDocumentCommandStub : ClearDocumentCommand
    {
        public ClearDocumentCommandStub(IControlUnit controlUnit) : base(controlUnit)
        {
        }

        public List<FigureBase> BackUpFigures
        {
            get => _backUpFigures;
        }
    }

}
