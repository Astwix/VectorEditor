using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDK;

namespace EllipseFigure
{
    /// <summary>
    /// Эллипс
    /// </summary>
    [Serializable]
    public class EllipseFigure : FilledFigureBase
    {
        /// <summary>
        /// Конструктор "Эллипс"
        /// </summary>
        public EllipseFigure()
        {
            _lineSettings = new LineSettings();
            _pointsSettings = new PointsSettings(2);
            _fillSettings = new FillSettings();
        }

        public override string GetFigureName()
        {
            return "Ellipse";
        }
    }
}
