using Line;
using SDK;

namespace FiguresTest.Stubs
{
    /// <summary>
    /// Стаб класса LineFigure
    /// </summary>
    class LineFigureStub : LineFigure
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
        /// Настройки точек
        /// </summary>
        public PointsSettings PointsSettings
        {
            get => _pointsSettings;
            set => _pointsSettings = value;
        }
    }

}
