using System;
using VectorEditorProject.Figures.Utility;

namespace VectorEditorProject.Figures
{
    public abstract class BaseFigure
    {
        public Guid guid = Guid.NewGuid();

        protected LineSettings _lineSettings;
        protected PointsSettings _pointsSettings;

        public LineSettings LineSettings { get => _lineSettings; set => _lineSettings = value; }
        public PointsSettings PointsSettings { get => _pointsSettings; }


    }
}
