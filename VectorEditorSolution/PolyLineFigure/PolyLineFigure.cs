using System;
using SDK;

namespace PolyLine
{
    /// <summary>
    /// Полилиния
    /// </summary>
    [Serializable]
    public class PolyLineFigure : FigureBase
    {
        /// <summary>
        /// Конструктор "Полилиния"
        /// </summary>
        public PolyLineFigure()
        {
            _lineSettings = new LineSettings();
            _pointsSettings = new PointsSettings();
        }

        public override string GetFigureName()
        {
            return "PolyLine";
        }
    }
}
