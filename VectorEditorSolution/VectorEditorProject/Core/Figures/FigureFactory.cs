using System;
using System.Drawing;

namespace VectorEditorProject.Core.Figures
{
    /// <summary>
    /// Фабрика фигур
    /// </summary>
    public class FigureFactory
    {
        /// <summary>
        /// Создание фигуры
        /// </summary>
        /// <param name="figureType">Тип фигуры из перечисления</param>
        /// <returns>Новый объект фигуры как базовый тип (Base)</returns>
        public FigureBase CreateFigure(Utility.Figures figureType)
        {
            switch (figureType)
            {
                case Utility.Figures.Line:
                    return new Line();
                    break;

                case Utility.Figures.PolyLine:
                    return new PolyLine();
                    break;

                case Utility.Figures.Polygon:
                    return new Polygon();
                    break;

                case Utility.Figures.Circle:
                    return new Circle();
                    break;

                case Utility.Figures.Ellipse:
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
        public FilledFigureBase CreateFilledFigure(Utility.Figures figureType)
        {
            switch (figureType)
            {
                case Utility.Figures.Polygon:
                    return new Polygon();
                    break;

                case Utility.Figures.Circle:
                    return new Circle();
                    break;

                case Utility.Figures.Ellipse:
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
        /// <returns>Копия фигуры</returns>
        public FigureBase CopyFigure(FigureBase figure)
        {
            var copy = (FigureBase) Activator.CreateInstance(figure.GetType());
            copy.guid = figure.guid;
            foreach (var point in figure.PointsSettings.GetPoints())
            {
                copy.PointsSettings.AddPoint(new PointF(point.X, point.Y));
            }

            copy.LineSettings.Color = figure.LineSettings.Color;
            copy.LineSettings.Style = figure.LineSettings.Style;
            copy.LineSettings.Width = figure.LineSettings.Width;

            if (figure is FilledFigureBase filledFigure && copy is FilledFigureBase filledCopy)
            {
                filledCopy.FillSettings.Color = filledFigure.FillSettings.Color;
            }

            return copy;
        }
    }
}
