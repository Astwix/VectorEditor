using System.Collections.Generic;
using VectorEditorProject.Core.Figures;

namespace VectorEditorProject.Core.Commands
{
    public class AddFigureCommand : BaseCommand
    {
        private ControlUnit _controlUnit;
        private IReadOnlyList<BaseFigure> _figures;

        /// <summary>
        /// Конструктор создания команды
        /// </summary>
        /// <param name="controlUnit">Control Unit</param>
        /// <param name="figure">Фигура</param>
        public AddFigureCommand(ControlUnit controlUnit, BaseFigure figure)
        {
            _controlUnit = controlUnit;
            _figures = new List<BaseFigure>() {figure};
        }

        public AddFigureCommand(ControlUnit controlUnit, IReadOnlyList<BaseFigure> figures)
        {
            _controlUnit = controlUnit;
            _figures = figures;
        }

        /// <summary>
        /// Делай
        /// </summary>
        public override void Do()
        {
            foreach (var figure in _figures)
            {
                _controlUnit.GetDocument().AddFigure(figure);
            }
        }

        /// <summary>
        /// Отмена
        /// </summary>
        public override void Undo()
        {
            foreach (var figure in _figures)
            {
                _controlUnit.GetDocument().DeleteFigure(figure);
            }
        }
    }
}
