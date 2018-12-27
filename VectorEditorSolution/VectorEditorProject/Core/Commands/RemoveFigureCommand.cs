using System;
using System.Collections.Generic;
using VectorEditorProject.Core.Figures;

namespace VectorEditorProject.Core.Commands
{
    [Serializable]
    public class RemoveFigureCommand : CommandBase
    {
        [field: NonSerialized] public ControlUnit ControlUnit { get; set; }
        private IReadOnlyList<FigureBase> _figures;

        public RemoveFigureCommand(ControlUnit controlUnit, FigureBase figure)
        {
            ControlUnit = controlUnit;
            _figures = new List<FigureBase>() { figure };
        }

        public RemoveFigureCommand(ControlUnit controlUnit, IReadOnlyList<FigureBase> figures)
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

        /// <summary>
        /// Получить хэш-код
        /// </summary>
        /// <returns>Хэш</returns>
        public override int GetHashCode()
        {
            int hash = -1;
            foreach (var figure in _figures)
            {
                hash = hash + figure.GetHashCode();
            }

            return hash;
        }
    }
}
