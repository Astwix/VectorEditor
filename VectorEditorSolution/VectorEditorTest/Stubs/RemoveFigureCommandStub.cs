using System.Collections.Generic;
using SDK;
using VectorEditorProject.Core;
using VectorEditorProject.Core.Commands;

namespace VectorEditorTest.Stubs
{
    class RemoveFigureCommandStub : RemoveFigureCommand
    {
        public RemoveFigureCommandStub(IControlUnit controlUnit, 
            FigureBase figure) : base(controlUnit, figure)
        {
        }

        public RemoveFigureCommandStub(IControlUnit controlUnit, 
            IReadOnlyList<FigureBase> figures) : base(controlUnit, figures)
        {
        }

        public IReadOnlyList<FigureBase> Figures
        {
            get => _figures;
        }
    }
}
