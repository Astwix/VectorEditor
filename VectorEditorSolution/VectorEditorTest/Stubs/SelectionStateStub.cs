using System.Drawing;
using VectorEditorProject.Core;
using VectorEditorProject.Core.States;

namespace VectorEditorTest.Stubs
{
    /// <summary>
    /// Стаб SelectionState
    /// </summary>
    class SelectionStateStub : SelectionState
    {
        /// <summary>
        /// Стаб SelectionState
        /// </summary>
        /// <param name="controlUnit"></param>
        /// <param name="editContext"></param>
        public SelectionStateStub(IControlUnit controlUnit, 
            IEditContext editContext) : base(controlUnit, editContext)
        {
        }

        /// <summary>
        /// Control Unit
        /// </summary>
        public IControlUnit ControlUnit
        {
            get => _controlUnit;
        }

        /// <summary>
        /// Edit Context
        /// </summary>
        public IEditContext EditContext
        {
            get => _editContext;
        }

        /// <summary>
        /// Начальный Х
        /// </summary>
        public int BeginX
        {
            get => _beginX;
            set => _beginX = value;
        }

        /// <summary>
        /// Начальный У
        /// </summary>
        public int BeginY
        {
            get => _beginY;
            set => _beginY = value;
        }

        /// <summary>
        /// Нажата ли клавиша мыши
        /// </summary>
        public bool IsMousePressed
        {
            get => _isMousePressed;
            set => _isMousePressed = value;
        }

        /// <summary>
        /// Прямоугольник выделения
        /// </summary>
        public Rectangle SelectionRectangle
        {
            get => _selectionRectangle;
            set => _selectionRectangle = value;
        }

        
    }
}
