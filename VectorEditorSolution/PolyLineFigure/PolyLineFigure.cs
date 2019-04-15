using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDK;

namespace PolyLineFigure
{
    /// <summary>
    /// Полилиния
    /// </summary>
    [Serializable]
    public class PolyLineFigure : FigureBase
    {
        /// <summary>
        /// Конструктор "Полилиния"
        /// </summary>
        public PolyLineFigure()
        {
            _lineSettings = new LineSettings();
            _pointsSettings = new PointsSettings();
        }

        public override string GetFigureName()
        {
            return "PolyLine";
        }
    }
}
