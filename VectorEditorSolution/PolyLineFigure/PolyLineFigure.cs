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

        /// <summary>
        /// Имя фигуры
        /// </summary>
        /// <returns></returns>
        public override string FigureName
        {
            get { return "PolyLine"; }
        }
    }
}
