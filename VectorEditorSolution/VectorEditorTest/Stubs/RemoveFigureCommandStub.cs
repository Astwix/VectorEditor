using System.Collections.Generic;
using SDK;
using VectorEditorProject.Core;
using VectorEditorProject.Core.Commands;

namespace VectorEditorTest.Stubs
{
    /// <summary>
    /// Стаб RemoveFigureCommand
    /// </summary>
    class RemoveFigureCommandStub : RemoveFigureCommand
    {
        /// <summary>
        /// Стаб RemoveFigureCommand
        /// </summary>
        /// <param name="controlUnit">ControlUnit</param>
        /// <param name="figure">Фигура</param>
        public RemoveFigureCommandStub(IControlUnit controlUnit, 
            FigureBase figure) : base(controlUnit, figure)
        {
        }

        /// <summary>
        /// Стаб RemoveFigureCommand
        /// </summary>
        /// <param name="controlUnit">ControlUnit</param>
        /// <param name="figures">Список фигур</param>
        public RemoveFigureCommandStub(IControlUnit controlUnit, 
            IReadOnlyList<FigureBase> figures) : base(controlUnit, figures)
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
