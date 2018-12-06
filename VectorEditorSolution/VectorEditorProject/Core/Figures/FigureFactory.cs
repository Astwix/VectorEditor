namespace VectorEditorProject.Figures
{
    public class FigureFactory
    {
        /// <summary>
        /// Перечисление фигур (без заливки)
        /// </summary>
        public enum Figures
        {
            Line,
            PolyLine
        }

        /// <summary>
        /// Перечисление фигур с заливкой
        /// </summary>
        public enum FilledFigures
        {
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

                default:
                    return null;
            }
        }

        /// <summary>
        /// Создание фигуры (с заливкой)
        /// </summary>
        /// <param name="figureType">Тип фигуры из перечисления</param>
        /// <returns>Возвращает новый объект фигуры как базовый тип (FilledBase)</returns>
        public FilledBaseFigure CreateFilledFigure(FilledFigures figureType)
        {
            switch (figureType)
            {
                case FilledFigures.Polygon:
                    return new Polygon();
                    break;

                case FilledFigures.Circle:
                    return new Circle();
                    break;

                case FilledFigures.Ellipse:
                    return new Ellipse();
                    break;

                default:
                    return null;
            }
        }
    }
}
