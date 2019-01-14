using System;
using System.Drawing;
using VectorEditorProject.Core.Figures.Utility;

namespace VectorEditorProject.Core.Figures
{
    /// <summary>
    /// Круг
    /// </summary>
    [Serializable]
    class Circle : FilledFigureBase
    {
        /// <summary>
        /// Конструктор "Круг"
        /// </summary>
        public Circle()
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

            Point leftTopPoint = Point.Round(FigureEditor.LeftTopPointF(this));
            Point rightBottomPoint =
                Point.Round(FigureEditor.RightBottomPointF(this));

            int deltaX = Math.Abs(leftTopPoint.X - rightBottomPoint.X);
            int deltaY = Math.Abs(leftTopPoint.Y - rightBottomPoint.Y);
            int distance = Math.Max(deltaX, deltaY);

            return new Rectangle(leftTopPoint.X, leftTopPoint.Y,
                distance, distance);
        }
    }
}
