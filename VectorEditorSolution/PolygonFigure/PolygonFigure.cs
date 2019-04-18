using System;
using SDK;

namespace Polygon
{
    /// <summary>
    /// Многоугольник
    /// </summary>
    [Serializable]
    public class PolygonFigure : FilledFigureBase
    {
        /// <summary>
        /// Конструктор "Многоугольник"
        /// </summary>
        public PolygonFigure()
        {
            _lineSettings = new LineSettings();
            _pointsSettings = new PointsSettings();
            _fillSettings = new FillSettings();
        }

        public override string GetFigureName()
        {
            return "Polygon";
        }
    }
}
