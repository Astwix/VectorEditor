using System;
using System.Collections.Generic;
using VectorEditorProject.Core.Figures;

namespace VectorEditorProject.Core.Commands
{
    [Serializable]
    public class AddFigureCommand : CommandBase
    {
        [field: NonSerialized] public ControlUnit ControlUnit { get; set; }
        private IReadOnlyList<FigureBase> _figures;

        /// <summary>
        /// Конструктор создания команды
        /// </summary>
        /// <param name="controlControlUnit">Control ControlUnit</param>
        /// <param name="figure">Фигура</param>
        public AddFigureCommand(ControlUnit controlControlUnit, FigureBase figure)
        {
            ControlUnit = controlControlUnit;
            _figures = new List<FigureBase>() {figure};
        }

        public AddFigureCommand(ControlUnit controlControlUnit, IReadOnlyList<FigureBase> figures)
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
