using System;
using System.Collections.Generic;
using System.Linq;
using SDK;

namespace VectorEditorProject.Core.Commands
{
    /// <summary>
    /// Команда изменения фигур
    /// </summary>
    [Serializable]
    public class FiguresChangingCommand : CommandBase
    {
        /// <summary>
        /// Control Unit
        /// </summary>
        [field: NonSerialized]
        public IControlUnit ControlUnit { get; set; }

        /// <summary>
        /// Старые значения
        /// </summary>
        protected readonly List<FigureBase> _oldValues = new List<FigureBase>();

        /// <summary>
        /// Новые значения
        /// </summary>
        protected readonly List<FigureBase> _newValues = new List<FigureBase>();

        /// <summary>
        /// Конструктор команды изменения фигур
        /// </summary>
        /// <param name="controlUnit">Control Unit</param>
        /// <param name="newValues">Новые значения</param>
        public FiguresChangingCommand(IControlUnit controlUnit,
            List<FigureBase> newValues)
        {
            ControlUnit = controlUnit;

            foreach (var figure in newValues)
            {
                var original = ControlUnit.GetDocument()
                    .GetFigure(figure.guid);
                _oldValues.Add(original.CopyFigure());
                _newValues.Add(figure.CopyFigure());
            }
        }

        /// <summary>
        /// Конструктор команды изменения фигуры
        /// </summary>
        /// <param name="controlUnit">Control Unit</param>
        /// <param name="newValues">Новые значения</param>
        public FiguresChangingCommand(IControlUnit controlUnit,
            FigureBase newValues)
        {
            ControlUnit = controlUnit;

            var original = ControlUnit.GetDocument().GetFigure(newValues.guid);
            _oldValues.Add(original.CopyFigure());
            _newValues.Add(newValues.CopyFigure());
        }

        /// <summary>
        /// Действие
        /// </summary>
        public override void Do()
        {
            AcceptValues(_newValues);
        }

        /// <summary>
        /// Отмена
        /// </summary>
        public override void Undo()
        {
            AcceptValues(_oldValues);
        }

        /// <summary>
        /// Применить изменения к параметрам фигур
        /// </summary>
        /// <param name="values">Изменения</param>
        private void AcceptValues(List<FigureBase> values)
        {
            foreach (var figure in values)
            {
                // применение параметров линии
                var original = ControlUnit.GetDocument()
                    .GetFigure(figure.guid);
                original.LineSettings.Color = figure.LineSettings.Color;
                original.LineSettings.Style = figure.LineSettings.Style;
                original.LineSettings.Width = figure.LineSettings.Width;

                // применение заливки
                if (original is FilledFigureBase originalFilled &&
                    figure is FilledFigureBase filledFigure)
                {
                    originalFilled.FillSettings.Color =
                        filledFigure.FillSettings.Color;
                }

                // применение изменений точек
                var points = figure.PointsSettings.GetPoints()
                    .ToArray();
                for (var i = 0;
                    i < points.Length;
                    i++)
                {
                    original.PointsSettings.ReplacePoint(i,
                        points[i]);
                }
            }
        }

        /// <summary>
        /// Получить хэш-код
        /// </summary>
        /// <returns>Хэш</returns>
        public override int GetHashCode()
        {
            int hash = -1;
            foreach (var newValue in _newValues)
            {
                hash = hash + newValue.GetHashCode();
            }

            foreach (var oldValue in _oldValues)
            {
                hash = hash + oldValue.GetHashCode();
            }

            return hash;
        }
    }
}
