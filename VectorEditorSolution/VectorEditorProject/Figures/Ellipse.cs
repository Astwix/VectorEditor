using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorEditorProject.Figures.Utility;

namespace VectorEditorProject.Figures
{
    class Ellipse : FilledBaseFigure
    {
        /// <summary>
        /// Конструктор "Эллипс"
        /// </summary>
        public Ellipse()
        {
            _lineSettings = new LineSettings();
            _pointsSettings = new PointsSettings(2);
            _fillSettings = new FillSettings();
        }
    }
}
