using VectorEditorProject.Core;
using VectorEditorProject.Core.States;

namespace VectorEditorTest.Stubs
{
    /// <summary>
    /// Стаб AddPointState
    /// </summary>
    class AddPointStateStub : AddPointState
    {
        /// <summary>
        /// Стаб AddPointState
        /// </summary>
        /// <param name="controlUnit">controlUnit</param>
        /// <param name="editContext">editContext</param>
        public AddPointStateStub(IControlUnit controlUnit, 
            EditContext editContext) : base(controlUnit, editContext)
        {
        }

        /// <summary>
        /// Поле IsMousePressed
        /// </summary>
        public bool IsMousePressed
        {
            get => _isMousePressed;
            set => _isMousePressed = value;
        }

        /// <summary>
        /// Поле EditContext
        /// </summary>
        public IEditContext EditContext
        {
            get => _editContext;
        }

        /// <summary>
        /// Поле ControlUnit
        /// </summary>
        public IControlUnit ControlUnit
        {
            get => _controlUnit;
        }

        /// <summary>
        /// Поле DrawerFactory
        /// </summary>
        public DrawerFactory DrawerFactory
        {
            get => _drawerFactory;
        }
    }
}
