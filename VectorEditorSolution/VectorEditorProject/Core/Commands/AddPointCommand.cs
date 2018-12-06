using System;
using System.Drawing;
using VectorEditorProject.Figures;

namespace VectorEditorProject.Core.Commands
{
    class AddPointCommand : BaseCommand
    {
        private Guid _guid = Guid.Empty;
        private Point _point;
        private ControlUnit _controlUnit;

        /// <summary>
        /// Команда добавления точки
        /// </summary>
        /// <param name="fugure">Фигура</param>
        /// <param name="point">Точка</param>
        /// <param name="controlUnit">controlUnit</param>
        public AddPointCommand(BaseFigure fugure, Point point, ControlUnit controlUnit)
        {
            _guid = fugure.guid;
            _point = point;
            _controlUnit = controlUnit;
        }

        /// <summary>
        /// Действие
        /// </summary>
        public override void Do()
        {
            _controlUnit.GetDocument().GetFigure(_guid)?.PointsSettings.AddPoint(_point);
        }

        /// <summary>
        /// Отмена
        /// </summary>
        public override void Undo()
        {
            _controlUnit.GetDocument().GetFigure(_guid)?.PointsSettings.DeletePoint(_point);
        }
    }
}
