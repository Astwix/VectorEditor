﻿using Circle;
using SDK;

namespace FiguresTest.Stubs
{
    class CircleFigureStub : CircleFigure
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
