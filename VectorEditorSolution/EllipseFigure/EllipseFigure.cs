using System;
using SDK;

namespace Ellipse
{
    /// <summary>
    /// Эллипс
    /// </summary>
    [Serializable]
    public class EllipseFigure : FilledFigureBase
    {
        /// <summary>
        /// Конструктор "Эллипс"
        /// </summary>
        public EllipseFigure()
        {
            _lineSettings = new LineSettings();
            _pointsSettings = new PointsSettings(2);
            _fillSettings = new FillSettings();
        }

        public override string GetFigureName()
        {
            return "Ellipse";
        }
    }
}
