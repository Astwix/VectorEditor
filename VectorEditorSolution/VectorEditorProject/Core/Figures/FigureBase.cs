using System;
using System.Drawing;
using VectorEditorProject.Core.Figures.Utility;

namespace VectorEditorProject.Core.Figures
{
    [Serializable]
    public abstract class FigureBase
    {
        public Guid guid = Guid.NewGuid();

        protected LineSettings _lineSettings;
        protected PointsSettings _pointsSettings;

        public LineSettings LineSettings { get => _lineSettings; set => _lineSettings = value; }
        public PointsSettings PointsSettings { get => _pointsSettings; }

        /// <summary>
        /// Получить границы фигуры
        /// </summary>
        /// <returns></returns>
        public virtual Rectangle GetBorderRectangle()
        {
            if (PointsSettings.GetPoints().Count < 2)
            {
                new Rectangle();
            }

            Point leftTopPoint = Point.Round(FigureEditor.LeftTopPointF(this));
            Point rightBottomPoint = Point.Round(FigureEditor.RightBottomPointF(this));
            
            return new Rectangle(leftTopPoint.X, leftTopPoint.Y, 
                rightBottomPoint.X - leftTopPoint.X, rightBottomPoint.Y - leftTopPoint.Y);
        }

        /// <summary>
        /// Получить хэш-код
        /// </summary>
        /// <returns>Хэш</returns>
        public override int GetHashCode()
        {
            return _lineSettings.GetHashCode() + _pointsSettings.GetHashCode();
        }
    }
}
