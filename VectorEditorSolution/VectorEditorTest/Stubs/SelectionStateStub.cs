using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorEditorProject.Core;
using VectorEditorProject.Core.States;

namespace VectorEditorTest.Stubs
{
    class SelectionStateStub : SelectionState
    {
        public SelectionStateStub(IControlUnit controlUnit, 
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

        public int BeginX
        {
            get => _beginX;
            set => _beginX = value;
        }

        public int BeginY
        {
            get => _beginY;
            set => _beginY = value;
        }

        public bool IsMousePressed
        {
            get => _isMousePressed;
            set => _isMousePressed = value;
        }

        public Rectangle SelectionRectangle
        {
            get => _selectionRectangle;
            set => _selectionRectangle = value;
        }

        
    }
}
