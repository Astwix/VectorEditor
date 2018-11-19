using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorEditorProject.Figures.Utility;

namespace VectorEditorProject.Figures
{
    abstract class BaseFigure
    {
        protected LineSettings _lineSettings;
        protected PointsSettings _pointsSettings;

        public LineSettings LineSettings { get => _lineSettings; set => _lineSettings = value; }
        public PointsSettings PointsSettings { get => _pointsSettings; }
    }
}
