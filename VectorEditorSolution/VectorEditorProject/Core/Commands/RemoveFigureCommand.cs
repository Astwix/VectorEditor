using System;
using System.Collections.Generic;
using VectorEditorProject.Core.Figures;

namespace VectorEditorProject.Core.Commands
{
    [Serializable]
    public class RemoveFigureCommand : BaseCommand
    {
        [field: NonSerialized] public ControlUnit ControlUnit { get; set; }
        private IReadOnlyList<BaseFigure> _figures;

        public RemoveFigureCommand(ControlUnit controlUnit, BaseFigure figure)
        {
            ControlUnit = controlUnit;
            _figures = new List<BaseFigure>() { figure };
        }

        public RemoveFigureCommand(ControlUnit controlUnit, IReadOnlyList<BaseFigure> figures)
        {
            ControlUnit = controlUnit;
            _figures = figures;
        }

        /// <summary>
        /// Делай
        /// </summary>
        public override void Undo()
        {
            foreach (var figure in _figures)
            {
                ControlUnit.GetDocument().AddFigure(figure);
            }
        }

        /// <summary>
        /// Отмена
        /// </summary>
        public override void Do()
        {
            foreach (var figure in _figures)
            {
                ControlUnit.GetDocument().DeleteFigure(figure);
            }
        }
    }
}
