using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorEditorProject.Figures;

namespace VectorEditorProject.Core.Figures.Utility
{
    public static class FigureEditor
    {
        /// <summary>
        /// Нахождение левой верхней точки фигуры
        /// </summary>
        /// <param name="figure">Фигура</param>
        /// <returns></returns>
        public static PointF LeftTopPointF(BaseFigure figure)
        {
            var result = figure.PointsSettings.GetPoints()[0];
            foreach (var point in figure.PointsSettings.GetPoints())
            {
                result.X = Math.Min(result.X, point.X);
                result.Y = Math.Min(result.Y, point.Y);
            }

            return result;
        }

        /// <summary>
        /// Нахождение левой верхней точки всех фигур
        /// </summary>
        /// <param name="figures">Список фигур</param>
        /// <returns></returns>
        public static PointF LeftTopPointF(IReadOnlyList<BaseFigure> figures)
        {
            var result = figures[0].PointsSettings.GetPoints().First();
            foreach (var figure in figures)
            {
                foreach (var point in figure.PointsSettings.GetPoints())
                {
                    result.X = Math.Min(result.X, point.X);
                    result.Y = Math.Min(result.Y, point.Y);
                }
            }

            return result;
        }

        /// <summary>
        /// Нахождение правой нижней точки фигуры
        /// </summary>
        /// <param name="figure">Фигура</param>
        /// <returns></returns>
        public static PointF RightBottomPointF(BaseFigure figure)
        {
            var result = figure.PointsSettings.GetPoints()[0];
            foreach (var point in figure.PointsSettings.GetPoints())
            {
                result.X = Math.Max(result.X, point.X);
                result.Y = Math.Max(result.Y, point.Y);
            }

            return result;
        }

        /// <summary>
        /// Нахождение правой нижней точки всех фигур
        /// </summary>
        /// <param name="figures">Список фигур</param>
        /// <returns></returns>
        public static PointF RightBottomPointF(IReadOnlyList<BaseFigure> figures)
        {
            var result = figures[0].PointsSettings.GetPoints().First();
            foreach (var figure in figures)
            {
                foreach (var point in figure.PointsSettings.GetPoints())
                {
                    result.X = Math.Max(result.X, point.X);
                    result.Y = Math.Max(result.Y, point.Y);
                }
            }

            return result;
        }
    }
}
