using System;
using System.Collections.Generic;
using VectorEditorProject.Core;
using VectorEditorProject.Core.States;

namespace VectorEditorTest.Stubs
{
    /// <summary>
    /// Стаб EditContext
    /// </summary>
    class EditContextStub : EditContext
    {
        /// <summary>
        /// Стаб EditContext
        /// </summary>
        /// <param name="controlUnit"></param>
        public EditContextStub(IControlUnit controlUnit) : base(controlUnit)
        {
        }

        /// <summary>
        /// Список выделенных фигур
        /// </summary>
        public List<Guid> SelectedFigures
        {
            get { return _selectedFigures; }
            //set { _selectedFigures = value; }
        }

        /// <summary>
        /// Активное состояние
        /// </summary>
        public StateBase ActiveState
        {
            get { return _activeState; }
            set { _activeState = value; }
        }

        /// <summary>
        /// ControlUnit
        /// </summary>
        public IControlUnit ControlUnit
        {
            get { return _controlUnit; }
        }

        /// <summary>
        /// Guid активной фигуры
        /// </summary>
        public Guid ActiveFigureGuid
        {
            get { return _activeFigureGuid; }
        }
    }
}
