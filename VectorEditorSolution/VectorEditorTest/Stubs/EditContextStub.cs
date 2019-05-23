using System;
using System.Collections.Generic;
using VectorEditorProject.Core;
using VectorEditorProject.Core.States;

namespace VectorEditorTest.Stubs
{
    class EditContextStub : EditContext
    {
        public EditContextStub(IControlUnit controlUnit) : base(controlUnit)
        {
        }

        public List<Guid> SelectedFigures
        {
            get { return _selectedFigures; }
            //set { _selectedFigures = value; }
        }

        public StateBase ActiveState
        {
            get { return _activeState; }
            set { _activeState = value; }
        }

        public IControlUnit ControlUnit
        {
            get { return _controlUnit; }
        }

        public Guid ActiveFigureGuid
        {
            get { return _activeFigureGuid; }
        }
    }
}
