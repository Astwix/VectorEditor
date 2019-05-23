using System;
using System.Collections.Generic;
using SDK;

namespace VectorEditorProject.Core.Commands
{
    /// <summary>
    /// Команда добавления фигуры
    /// </summary>
    [Serializable]
    public class AddFigureCommand : CommandBase
    {
        /// <summary>
        /// Control Unit
        /// </summary>
        [field: NonSerialized]
        public IControlUnit ControlUnit { get; set; }

        /// <summary>
        /// Список фигур, доступный только для чтения
        /// </summary>
        private readonly IReadOnlyList<FigureBase> _figures;

        /// <summary>
        /// Конструктор создания команды
        /// </summary>
        /// <param name="controlControlUnit">Control ControlUnit</param>
        /// <param name="figure">Фигура</param>
        public AddFigureCommand(IControlUnit controlControlUnit, 
            FigureBase figure)
        {
            ControlUnit = controlControlUnit;
            _figures = new List<FigureBase>()
            {
                figure
            };
        }

        /// <summary>
        /// Конструктор создания команды
        /// </summary>
        /// <param name="controlControlUnit">Control ControlUnit</param>
        /// <param name="figures">Фигуры</param>
        public AddFigureCommand(IControlUnit controlControlUnit,
            IReadOnlyList<FigureBase> figures)
        {
            ControlUnit = controlControlUnit;
            _figures = figures;
        }

        /// <summary>
        /// Действие
        /// </summary>
        public override void Do()
        {
            foreach (var figure in _figures)
            {
                ControlUnit.GetDocument()
                    .AddFigure(figure.CopyFigure());
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
