using PolyLine;
using SDK;

namespace FiguresTest.Stubs
{
    class PolyLineFigureStub : PolyLineFigure
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
