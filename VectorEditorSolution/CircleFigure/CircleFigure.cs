using System;
using System.Drawing;
using SDK;

namespace Circle
{
    /// <summary>
    /// Круг
    /// </summary>
    [Serializable]
    public class CircleFigure : FilledFigureBase
    {
        /// <summary>
        /// Конструктор "Круг"
        /// </summary>
        public CircleFigure()
        {
            _lineSettings = new LineSettings();
            _pointsSettings = new PointsSettings(2);
            _fillSettings = new FillSettings();
        }

        /// <summary>
        /// Получить границы фигуры
        /// </summary>
        /// <returns></returns>
        public override Rectangle GetBorderRectangle()
        {
            if (PointsSettings.GetPoints().Count < 2)
            {
                new Rectangle();
            }

            Point leftTopPoint = Point.Round(_pointsSettings.LeftTopPointF());
            Point rightBottomPoint =
                Point.Round(_pointsSettings.RightBottomPointF());

            int deltaX = Math.Abs(leftTopPoint.X - rightBottomPoint.X);
            int deltaY = Math.Abs(leftTopPoint.Y - rightBottomPoint.Y);
            int distance = Math.Max(deltaX, deltaY);

            return new Rectangle(leftTopPoint.X, leftTopPoint.Y,
                distance, distance);
        }

        public override string GetFigureName()
        {
            return "Circle";
        }
    }
}
