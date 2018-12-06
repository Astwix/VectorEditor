namespace VectorEditorProject.Figures
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
    }
}
