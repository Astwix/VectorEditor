using System;
using System.Collections.Generic;
using VectorEditorProject.Core.Figures;

namespace VectorEditorProject.Core.Commands
{
    /// <summary>
    /// Команда удаления фигур
    /// </summary>
    [Serializable]
    public class RemoveFigureCommand : CommandBase
    {
        /// <summary>
        /// Control Unit
        /// </summary>
        [field: NonSerialized] public ControlUnit ControlUnit { get; set; }

        /// <summary>
        /// Список фигур (доступный только для чтения)
        /// </summary>
        private IReadOnlyList<FigureBase> _figures;

        /// <summary>
        /// Конструктор команды удаления фигуры
        /// </summary>
        /// <param name="controlUnit">Control Unit</param>
        /// <param name="figure">Фигура</param>
        public RemoveFigureCommand(ControlUnit controlUnit, FigureBase figure)
        {
            ControlUnit = controlUnit;
            _figures = new List<FigureBase>() { figure };
        }

        /// <summary>
        /// Конструктор команды удаления фигур
        /// </summary>
        /// <param name="controlUnit">Control Unit</param>
        /// <param name="figures">Фигуры</param>
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
                ControlUnit.GetDocument().DeleteFigure(figure.guid);
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
