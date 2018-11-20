using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorEditorProject.Figures;

namespace VectorEditorProject.Drawing
{
    public class EllipseDrawer : BaseDrawer
    {
        /// <summary>
        /// Рисование эллипса
        /// </summary>
        /// <param name="figure">Объект, который рисуем (эллипс)</param>
        /// <param name="graphics">Объект graphics, на котором рисуем</param>
        public override void DrawFigure(BaseFigure figure, Graphics graphics)
        {
            if (figure.PointsSettings.GetPoints().Count == 2)
            {
                Pen pen = new Pen(figure.LineSettings.Color, figure.LineSettings.Width);
                pen.DashStyle = figure.LineSettings.Style;
                var points = figure.PointsSettings.GetPoints();
                int deltaX = Math.Abs(points.First().X - points.Last().X);
                int deltaY = Math.Abs(points.First().Y - points.Last().Y);
                graphics.DrawEllipse(pen, points.First().X, 
                    points.First().Y, deltaX, deltaY);

                pen.Dispose();
            }
        }
    }
}
