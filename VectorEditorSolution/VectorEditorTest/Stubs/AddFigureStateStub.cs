using VectorEditorProject.Core;
using VectorEditorProject.Core.States;

namespace VectorEditorTest.Stubs
{
    /// <summary>
    /// Стаб AddFigureState
    /// </summary>
    class AddFigureStateStub : AddFigureState
    {
        /// <summary>
        /// Стаб AddFigureState
        /// </summary>
        /// <param name="controlUnit"></param>
        /// <param name="editContext"></param>
        public AddFigureStateStub(IControlUnit controlUnit, 
            IEditContext editContext) : base(controlUnit, editContext)
        {
        }

        /// <summary>
        /// Поле ControlUnit
        /// </summary>
        public IControlUnit ControlUnit
        {
            get => _controlUnit;
        }

        /// <summary>
        /// Поле EditContext
        /// </summary>
        public IEditContext EditContext
        {
            get => _editContext;
        }
    }
}
