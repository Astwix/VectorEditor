using System;
using System.Collections.Generic;
using VectorEditorProject.Core.Figures;

namespace VectorEditorProject.Core.Commands
{
    [Serializable]
    public class AddFigureCommand : BaseCommand
    {
        [field: NonSerialized] public ControlUnit ControlUnit { get; set; }
        private IReadOnlyList<BaseFigure> _figures;

        /// <summary>
        /// Конструктор создания команды
        /// </summary>
        /// <param name="controlControlUnit">Control ControlUnit</param>
        /// <param name="figure">Фигура</param>
        public AddFigureCommand(ControlUnit controlControlUnit, BaseFigure figure)
        {
            ControlUnit = controlControlUnit;
            _figures = new List<BaseFigure>() {figure};
        }

        public AddFigureCommand(ControlUnit controlControlUnit, IReadOnlyList<BaseFigure> figures)
        {
            ControlUnit = controlControlUnit;
            _figures = figures;
        }

        /// <summary>
        /// Делай
        /// </summary>
        public override void Do()
        {
            foreach (var figure in _figures)
            {
                ControlUnit.GetDocument().AddFigure(figure);
            }
        }

        /// <summary>
        /// Отмена
        /// </summary>
        public override void Undo()
        {
            foreach (var figure in _figures)
            {
                ControlUnit.GetDocument().DeleteFigure(figure);
            }
        }
    }
}
