using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorEditorProject.Figures;

namespace VectorEditorProject.Drawing
{
    public class LineDrawer : BaseDrawer
    {
        /// <summary>
        /// Рисование линии
        /// </summary>
        /// <param name="figure">Объект, который рисуем (линия)</param>
        /// <param name="graphics">Объект graphics, на котором рисуем</param>
        public override void DrawFigure(BaseFigure figure, Graphics graphics)
        {
            if (figure.PointsSettings.GetPoints().Count() == 2)
            {
                Pen pen = new Pen(figure.LineSettings.Color);
                pen.Width = figure.LineSettings.Width;
                pen.DashStyle = figure.LineSettings.Style;
                graphics.DrawLine(pen, figure.PointsSettings.GetPoints().First(), figure.PointsSettings.GetPoints().Last());

                pen.Dispose();
            }
        }
    }
}
