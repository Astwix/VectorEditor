using System.Collections.Generic;
using SDK;
using VectorEditorProject.Core;
using VectorEditorProject.Core.Commands;

namespace VectorEditorTest.Stubs
{
    class AddFigureCommandStub : AddFigureCommand
    {
        public AddFigureCommandStub(IControlUnit controlControlUnit, FigureBase figure) 
            : base(controlControlUnit, figure)
        {
        }

        public AddFigureCommandStub(IControlUnit controlControlUnit, 
            IReadOnlyList<FigureBase> figures) : base(controlControlUnit, figures)
        {
        }

        public IReadOnlyList<FigureBase> Figures
        {
            get => _figures;
        }
    }
}
