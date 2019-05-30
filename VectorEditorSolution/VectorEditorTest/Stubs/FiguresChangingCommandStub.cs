using System.Collections.Generic;
using SDK;
using VectorEditorProject.Core;
using VectorEditorProject.Core.Commands;

namespace VectorEditorTest.Stubs
{
    class FiguresChangingCommandStub : FiguresChangingCommand
    {
        public FiguresChangingCommandStub(IControlUnit controlUnit, 
            List<FigureBase> newValues) : base(controlUnit, newValues)
        {
        }

        public FiguresChangingCommandStub(IControlUnit controlUnit, 
            FigureBase newValues) : base(controlUnit, newValues)
        {
        }

        public List<FigureBase> NewValues
        {
            get => _newValues;
        }

        public List<FigureBase> OldValues
        {
            get => _oldValues;
        }
    }
}
