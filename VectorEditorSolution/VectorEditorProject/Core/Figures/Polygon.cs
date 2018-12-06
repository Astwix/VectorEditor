using VectorEditorProject.Figures.Utility;

namespace VectorEditorProject.Figures
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
