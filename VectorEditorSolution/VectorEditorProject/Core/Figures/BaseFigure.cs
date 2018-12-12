using System;
using VectorEditorProject.Core.Figures.Utility;

namespace VectorEditorProject.Core.Figures
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
