using VectorEditorProject.Core;
using VectorEditorProject.Core.States;

namespace VectorEditorTest.Stubs
{
    class AddPointStateStub : AddPointState
    {
        public AddPointStateStub(IControlUnit controlUnit, 
            EditContext editContext) : base(controlUnit, editContext)
        {
        }

        public bool IsMousePressed
        {
            get => _isMousePressed;
            set => _isMousePressed = value;
        }

        public IEditContext EditContext
        {
            get => _editContext;
        }

        public IControlUnit ControlUnit
        {
            get => _controlUnit;
        }

        public DrawerFactory DrawerFactory
        {
            get => _drawerFactory;
        }
    }
}
