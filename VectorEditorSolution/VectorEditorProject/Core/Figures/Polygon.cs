using VectorEditorProject.Core.Figures.Utility;

namespace VectorEditorProject.Core.Figures
{
    class Polygon : FilledBaseFigure
    {
        /// <summary>
        /// Конструктор "Многоугольник"
        /// </summary>
        public Polygon()
        {
            _lineSettings = new LineSettings();
            _pointsSettings = new PointsSettings();
            _fillSettings = new FillSettings();
        }
    }
}
