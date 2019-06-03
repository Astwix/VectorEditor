using System;
using System.Drawing;
using SDK;

namespace VectorEditorProject.Core.Commands
{
    /// <summary>
    /// Команда добавления точки
    /// </summary>
    [Serializable]
    public class AddPointCommand : CommandBase
    {
        /// <summary>
        /// GUID фигуры
        /// </summary>
        protected readonly Guid _guid = Guid.Empty;

        /// <summary>
        /// Точка
        /// </summary>
        protected readonly PointF _point;

        /// <summary>
        /// Control Unit
        /// </summary>
        [field: NonSerialized]
        public IControlUnit ControlUnit { get; set; }

        /// <summary>
        /// Команда добавления точки
        /// </summary>
        /// <param name="figure">Фигура</param>
        /// <param name="point">Точка</param>
        /// <param name="controlUnit">controlUnit</param>
        public AddPointCommand(FigureBase figure, PointF point,
            IControlUnit controlUnit)
        {
            _guid = figure.guid;
            _point = point;
            ControlUnit = controlUnit;
        }

        /// <summary>
        /// Действие
        /// </summary>
        public override void Do()
        {
            ControlUnit.GetDocument()
                .GetFigure(_guid)
                ?.PointsSettings.AddPoint(_point);
        }

        /// <summary>
        /// Отмена
        /// </summary>
        public override void Undo()
        {
            ControlUnit.GetDocument()
                .GetFigure(_guid)
                ?.PointsSettings.DeletePoint(_point);
        }

        /// <summary>
        /// Получить хэш-код
        /// </summary>
        /// <returns>Хэш</returns>
        public override int GetHashCode()
        {
            return _guid.GetHashCode() + _point.GetHashCode();
        }
    }
}
