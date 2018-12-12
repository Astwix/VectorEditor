using VectorEditorProject.Core.Figures.Utility;

namespace VectorEditorProject.Core.Figures
{
    class Line : BaseFigure
    {
        /// <summary>
        /// Конструктор "Линия"
        /// </summary>
        public Line()
        {
            _lineSettings = new LineSettings();
            _pointsSettings = new PointsSettings(2);
        }
    }
}
