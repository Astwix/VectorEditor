using Line;
using SDK;

namespace FiguresTest.Stubs
{
    class LineFigureStub : LineFigure
    {
        public LineSettings LineSettings
        {
            get => _lineSettings;
            set => _lineSettings = value;
        }

        public PointsSettings PointsSettings
        {
            get => _pointsSettings;
            set => _pointsSettings = value;
        }
    }

}
