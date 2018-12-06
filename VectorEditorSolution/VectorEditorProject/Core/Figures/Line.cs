using VectorEditorProject.Figures.Utility;

namespace VectorEditorProject.Figures
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
