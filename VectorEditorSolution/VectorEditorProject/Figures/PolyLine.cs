using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorEditorProject.Figures.Utility;

namespace VectorEditorProject.Figures
{
    class PolyLine : BaseFigure
    {
        /// <summary>
        /// Конструктор "Полилиния"
        /// </summary>
        public PolyLine()
        {
            _lineSettings = new LineSettings();
            _pointsSettings = new PointsSettings();
        }
    }
}
