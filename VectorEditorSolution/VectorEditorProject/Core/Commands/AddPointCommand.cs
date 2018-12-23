using System;
using System.Drawing;
using VectorEditorProject.Core.Figures;

namespace VectorEditorProject.Core.Commands
{
    [Serializable]
    public class AddPointCommand : BaseCommand
    {
        private Guid _guid = Guid.Empty;
        private PointF _point;
        [field: NonSerialized] public ControlUnit ControlUnit { get; set; }

        /// <summary>
        /// Команда добавления точки
        /// </summary>
        /// <param name="figure">Фигура</param>
        /// <param name="point">Точка</param>
        /// <param name="controlUnit">controlUnit</param>
        public AddPointCommand(BaseFigure figure, PointF point, ControlUnit controlUnit)
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
            ControlUnit.GetDocument().GetFigure(_guid)?.PointsSettings.AddPoint(_point);
        }

        /// <summary>
        /// Отмена
        /// </summary>
        public override void Undo()
        {
            ControlUnit.GetDocument().GetFigure(_guid)?.PointsSettings.DeletePoint(_point);
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
