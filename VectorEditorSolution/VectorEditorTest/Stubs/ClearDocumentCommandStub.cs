using System.Collections.Generic;
using SDK;
using VectorEditorProject.Core;
using VectorEditorProject.Core.Commands;

namespace VectorEditorTest.Stubs
{
    /// <summary>
    /// Стаб ClearDocumentCommand
    /// </summary>
    class ClearDocumentCommandStub : ClearDocumentCommand
    {
        /// <summary>
        /// Стаб ClearDocumentCommand
        /// </summary>
        /// <param name="controlUnit">controlUnit</param>
        public ClearDocumentCommandStub(IControlUnit controlUnit) : base(controlUnit)
        {
        }

        /// <summary>
        /// Резервный список фигур
        /// </summary>
        public List<FigureBase> BackUpFigures
        {
            get => _backUpFigures;
        }
    }

}
