using VectorEditorProject.Figures.Utility;

namespace VectorEditorProject.Figures
{
    class Circle : FilledBaseFigure
    {
        /// <summary>
        /// Конструктор "Круг"
        /// </summary>
        public Circle()
        {
            _lineSettings = new LineSettings();
            _pointsSettings = new PointsSettings(2);
            _fillSettings = new FillSettings();
        }
    }
}
