using VectorEditorProject.Core;
using VectorEditorProject.Core.States;

namespace VectorEditorTest.Stubs
{
    class AddFigureStateStub : AddFigureState
    {
        public AddFigureStateStub(IControlUnit controlUnit, 
            IEditContext editContext) : base(controlUnit, editContext)
        {
        }

        public IControlUnit ControlUnit
        {
            get => _controlUnit;
        }

        public IEditContext EditContext
        {
            get => _editContext;
        }
    }
}
