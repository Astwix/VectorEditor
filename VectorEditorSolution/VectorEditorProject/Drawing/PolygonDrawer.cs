using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorEditorProject.Figures;

namespace VectorEditorProject.Drawing
{
    public class PolygonDrawer : BaseDrawer
    {
        /// <summary>
        /// Рисование многоугольника
        /// </summary>
        /// <param name="figure">Объект, который рисуем (многоугольник)</param>
        /// <param name="graphics">Объект graphics, на котором рисуем</param>
        public override void DrawFigure(BaseFigure figure, Graphics graphics)
        {
            if (figure.PointsSettings.GetPoints().Count >= 3)
            {
                Pen pen = new Pen(figure.LineSettings.Color, figure.LineSettings.Width);
                pen.DashStyle = figure.LineSettings.Style;
                graphics.DrawPolygon(pen, figure.PointsSettings.GetPoints().ToArray());

                pen.Dispose();
            }
        }
    }
}
