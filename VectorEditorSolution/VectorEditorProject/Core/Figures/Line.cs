using System;
using VectorEditorProject.Core.Figures.Utility;

namespace VectorEditorProject.Core.Figures
{
    /// <summary>
    /// Линия
    /// </summary>
    [Serializable]
    public class Line : FigureBase
    {
        /// <summary>
        /// Конструктор "Линия"
        /// </summary>
        public Line()
        {
            _lineSettings = new LineSettings();
            _pointsSettings = new PointsSettings(2);
        }
    }
}
