using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
