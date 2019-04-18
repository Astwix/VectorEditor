using System;
using SDK;

namespace Line
{
    /// <summary>
    /// Линия
    /// </summary>
    [Serializable]
    public class LineFigure : FigureBase
    {
        /// <summary>
        /// Конструктор "Линия"
        /// </summary>
        public LineFigure()
        {
            _lineSettings = new LineSettings();
            _pointsSettings = new PointsSettings(2);
        }

        public override string GetFigureName()
        {
            return "Line";
        }
    }
}
