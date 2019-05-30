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

        /// <summary>
        /// Имя фигуры
        /// </summary>
        /// <returns></returns>
        public override string FigureName
        {
            get { return "Line"; }
        }
    }
}
