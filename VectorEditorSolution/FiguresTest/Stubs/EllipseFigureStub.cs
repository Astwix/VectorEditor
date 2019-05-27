using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ellipse;
using SDK;

namespace FiguresTest.Stubs
{
    class EllipseFigureStub : EllipseFigure
    {
        public LineSettings LineSettings
        {
            get => _lineSettings;
            set => _lineSettings = value;
        }

        public FillSettings FillSettings
        {
            get => _fillSettings;
            set => _fillSettings = value;
        }

        public PointsSettings PointsSettings
        {
            get => _pointsSettings;
            set => _pointsSettings = value;
        }
    }
}
