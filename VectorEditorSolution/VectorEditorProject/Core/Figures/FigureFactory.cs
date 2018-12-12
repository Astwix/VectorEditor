using System;
using System.Drawing;

namespace VectorEditorProject.Core.Figures
{
    public class FigureFactory
    {
        /// <summary>
        /// Перечисление фигур
        /// </summary>
        public enum Figures
        {
            Line,
            PolyLine,
            Polygon,
            Circle,
            Ellipse
        }

        /// <summary>
        /// Создание фигуры
        /// </summary>
        /// <param name="figureType">Тип фигуры из перечисления</param>
        /// <returns>Возвращает новый объект фигуры как базовый тип (Base)</returns>
        public BaseFigure CreateFigure(Figures figureType)
        {
            switch (figureType)
            {
                case Figures.Line:
                    return new Line();
                    break;

                case Figures.PolyLine:
                    return new PolyLine();
                    break;

                case Figures.Polygon:
                    return new Polygon();
                    break;

                case Figures.Circle:
                    return new Circle();
                    break;

                case Figures.Ellipse:
                    return new Ellipse();
                    break;

                default:
                    return null;
            }
        }

        /// <summary>
        /// Создание фигуры (с заливкой)
        /// </summary>
        /// <param name="figureType">Тип фигуры из перечисления</param>
        /// <returns>Возвращает новый объект фигуры как базовый тип (FilledBase)</returns>
        public FilledBaseFigure CreateFilledFigure(Figures figureType)
        {
            switch (figureType)
            {
                case Figures.Polygon:
                    return new Polygon();
                    break;

                case Figures.Circle:
                    return new Circle();
                    break;

                case Figures.Ellipse:
                    return new Ellipse();
                    break;

                default:
                    return null;
            }
        }

        /// <summary>
        /// Копирование фигуры
        /// </summary>
        /// <param name="figure">Фигура</param>
        /// <returns>Возвращает копию фигуры</returns>
        public BaseFigure CopyFigure(BaseFigure figure)
        {
            var copy = (BaseFigure) Activator.CreateInstance(figure.GetType());
            copy.guid = figure.guid;
            foreach (var point in figure.PointsSettings.GetPoints())
            {
                copy.PointsSettings.AddPoint(new PointF(point.X, point.Y));
            }

            copy.LineSettings.Color = figure.LineSettings.Color;
            copy.LineSettings.Style = figure.LineSettings.Style;
            copy.LineSettings.Width = figure.LineSettings.Width;

            if (figure is FilledBaseFigure filledFigure && copy is FilledBaseFigure filledCopy)
            {
                filledCopy.FillSettings.Color = filledFigure.FillSettings.Color;
            }

            return copy;
        }
    }
}
