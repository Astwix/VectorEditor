using System.Collections.Generic;
using VectorEditorProject.Core.Figures;

namespace VectorEditorProject.Core.Commands
{
    public class RemoveFigureCommand : BaseCommand
    {
        private ControlUnit _controlUnit;
        private IReadOnlyList<BaseFigure> _figures;

        public RemoveFigureCommand(ControlUnit controlUnit, BaseFigure figure)
        {
            _controlUnit = controlUnit;
            _figures = new List<BaseFigure>() { figure };
        }

        public RemoveFigureCommand(ControlUnit controlUnit, IReadOnlyList<BaseFigure> figures)
        {
            _controlUnit = controlUnit;
            _figures = figures;
        }

        /// <summary>
        /// Делай
        /// </summary>
        public override void Undo()
        {
            foreach (var figure in _figures)
            {
                _controlUnit.GetDocument().AddFigure(figure);
            }
        }

        /// <summary>
        /// Отмена
        /// </summary>
        public override void Do()
        {
            foreach (var figure in _figures)
            {
                _controlUnit.GetDocument().DeleteFigure(figure);
            }
        }
    }
}
