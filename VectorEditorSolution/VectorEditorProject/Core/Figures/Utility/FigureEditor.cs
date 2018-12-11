using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

        /// <summary>
        /// Попала ли фигура в выделение
        /// </summary>
        /// <param name="figure">Фигура</param>
        /// <param name="rectangle">Прямоугольник выделения</param>
        /// <returns></returns>
        public static bool IsFigureInRectangle(BaseFigure figure, RectangleF rectangle)
        {
            foreach (var point in figure.PointsSettings.GetPoints())
            {
                if (point.X <= rectangle.X) // левая граница выделения
                {
                    return false;
                }

                if (point.X >= rectangle.X + rectangle.Width) // правая граница выделения
                {
                    return false;
                }

                if (point.Y <= rectangle.Y) // верхняя граница выделения
                {
                    return false;
                }

                if (point.Y >= rectangle.Y + rectangle.Height) // нижняя граница выделения
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Метод для соразмерного (пропорционального) изменения фигур
        /// </summary>
        /// <param name="figures">Фигуры</param>
        /// <param name="newSize">Новая область</param>
        public static void EditFiguresSize(IReadOnlyList<BaseFigure> figures, RectangleF newSize)
        {
            var leftTopPoint = LeftTopPointF(figures);
            var rightBottomPoint = RightBottomPointF(figures);

            var rectangleWidth = rightBottomPoint.X - leftTopPoint.X;
            var rectangleHeight = rightBottomPoint.Y - leftTopPoint.Y;

            foreach (var figure in figures)
            {
                var points = figure.PointsSettings.GetPoints().ToArray();
                for (int i = 0; i < points.Length; i++)
                {
                    PointF newPoint = new PointF();

                    newPoint.X = newSize.X + newSize.Width * 
                                 ((points[i].X - leftTopPoint.X) / rectangleWidth);
                    newPoint.Y = newSize.Y + newSize.Height 
                                 * ((points[i].Y - leftTopPoint.Y) / rectangleHeight);

                    figure.PointsSettings.ReplacePoint(i, newPoint);
                }
            }
        }

        /// <summary>
        /// Метод для соразмерного (пропорционального) изменения фигуры
        /// </summary>
        /// <param name="figure">Фигура</param>
        /// <param name="newSize">Новая область</param>
        public static void EditFiguresSize(BaseFigure figure, RectangleF newSize)
        {
            var leftTopPoint = LeftTopPointF(figure);
            var rightBottomPoint = RightBottomPointF(figure);

            var rectangleWidth = rightBottomPoint.X - leftTopPoint.X;
            var rectangleHeight = rightBottomPoint.Y - leftTopPoint.Y;

            var points = figure.PointsSettings.GetPoints().ToArray();
            for (int i = 0; i < points.Length; i++)
            {
                PointF newPoint = new PointF();

                newPoint.X = newSize.X + newSize.Width *
                             ((points[i].X - leftTopPoint.X) / rectangleWidth);
                newPoint.Y = newSize.Y + newSize.Height
                             * ((points[i].Y - leftTopPoint.Y) / rectangleHeight);

                figure.PointsSettings.ReplacePoint(i, newPoint);
            }
        }

        /// <summary>
        /// Расчет расстояния между точками
        /// </summary>
        /// <param name="point1">Первая точка</param>
        /// <param name="point2">Вторая точка</param>
        /// <returns>Расстояние между точками</returns>
        public static float DistanceBetweenPoints(PointF point1, PointF point2)
        {
            float deltaX = Math.Abs(point1.X - point2.X);
            float deltaY = Math.Abs(point1.Y - point2.Y);

            return (float)Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
        }
    }
}
