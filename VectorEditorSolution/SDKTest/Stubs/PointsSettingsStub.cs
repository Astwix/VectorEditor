using System.Collections.Generic;
using System.Drawing;
using SDK;

namespace SDKTest.Stubs
{
    class PointsSettingsStub : PointsSettings
    {
        public PointsSettingsStub(int limit = 0) : base(limit)
        {
        }

        public List<PointF> Points
        {
            get => _points;
        }

        public int LimitPoint
        {
            get => _limitPoint;
        }
    }
}
