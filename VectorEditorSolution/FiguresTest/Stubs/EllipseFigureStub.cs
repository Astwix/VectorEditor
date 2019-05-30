using Ellipse;
using SDK;

namespace FiguresTest.Stubs
{
    /// <summary>
    /// Стаб класса CircleFigure
    /// </summary>
    class EllipseFigureStub : EllipseFigure
    {
        /// <summary>
        /// Настройки линии
        /// </summary>
        public LineSettings LineSettings
        {
            get => _lineSettings;
            set => _lineSettings = value;
        }

        /// <summary>
        /// Настройки заливки
        /// </summary>
        public FillSettings FillSettings
        {
            get => _fillSettings;
            set => _fillSettings = value;
        }

        /// <summary>
        /// Настройки точек
        /// </summary>
        public PointsSettings PointsSettings
        {
            get => _pointsSettings;
            set => _pointsSettings = value;
        }
    }
}
