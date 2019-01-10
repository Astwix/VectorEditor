using System;
using VectorEditorProject.Core.Figures.Utility;

namespace VectorEditorProject.Core.Figures
{
    /// <summary>
    /// Многоугольник
    /// </summary>
    [Serializable]
    public class Polygon : FilledFigureBase
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
