using System.Collections.Generic;
using SDK;
using VectorEditorProject.Core;
using VectorEditorProject.Core.Commands;

namespace VectorEditorTest.Stubs
{
    /// <summary>
    /// Стаб AddFigureCommand
    /// </summary>
    class AddFigureCommandStub : AddFigureCommand
    {
        /// <summary>
        /// Стаб AddFigureCommand
        /// </summary>
        /// <param name="controlControlUnit">ControlUnit</param>
        /// <param name="figure">Фигура</param>
        public AddFigureCommandStub(IControlUnit controlControlUnit, 
            FigureBase figure) : base(controlControlUnit, figure)
        {
        }

        /// <summary>
        /// Стаб AddFigureCommand
        /// </summary>
        /// <param name="controlControlUnit">ControlUnit</param>
        /// <param name="figures">Список фигур</param>
        public AddFigureCommandStub(IControlUnit controlControlUnit, 
            IReadOnlyList<FigureBase> figures) : base(controlControlUnit, figures)
        {
        }

        /// <summary>
        /// Список фигур
        /// </summary>
        public IReadOnlyList<FigureBase> Figures
        {
            get => _figures;
        }
    }
}
