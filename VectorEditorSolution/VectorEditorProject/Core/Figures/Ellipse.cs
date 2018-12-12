using VectorEditorProject.Core.Figures.Utility;

namespace VectorEditorProject.Core.Figures
{
    class Ellipse : FilledBaseFigure
    {
        /// <summary>
        /// Конструктор "Эллипс"
        /// </summary>
        public Ellipse()
        {
            _lineSettings = new LineSettings();
            _pointsSettings = new PointsSettings(2);
            _fillSettings = new FillSettings();
        }
    }
}
