using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDK;

namespace PolyLineFigure
{
    /// <summary>
    /// Рисование полилинии
    /// </summary>
    public class PolyLineDrawer : DrawerBase
    {
        /// <summary>
        /// Рисование фигуры - полилиния
        /// </summary>
        /// <param name="figure">Объект, который рисуем (полилиния)</param>
        /// <param name="graphics">Объект graphics, на котором рисуем</param>
        public override void DrawFigure(FigureBase figure, Graphics graphics)
        {
            if (figure.PointsSettings.GetPoints().Count() >= 2)
            {
                Pen pen = new Pen(figure.LineSettings.Color,
                    figure.LineSettings.Width);
                pen.DashStyle = figure.LineSettings.Style;
                graphics.DrawLines(pen,
                    figure.PointsSettings.GetPoints().ToArray());

                pen.Dispose();
            }
        }
    }
}
