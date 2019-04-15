using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDK;

namespace PolygonFigure
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
