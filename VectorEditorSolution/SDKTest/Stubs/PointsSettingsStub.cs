using System.Collections.Generic;
using System.Drawing;
using SDK;

namespace SDKTest.Stubs
{
    /// <summary>
    /// Стаб класса PointsSettings
    /// </summary>
    class PointsSettingsStub : PointsSettings
    {
        /// <summary>
        /// Стаб класса PointsSettings
        /// </summary>
        /// <param name="limit">Лимит точек</param>
        public PointsSettingsStub(int limit = 0) : base(limit)
        {
        }

        /// <summary>
        /// Список точек
        /// </summary>
        public List<PointF> Points
        {
            get => _points;
        }

        /// <summary>
        /// Лимит точек
        /// </summary>
        public int LimitPoint
        {
            get => _limitPoint;
        }
    }
}
