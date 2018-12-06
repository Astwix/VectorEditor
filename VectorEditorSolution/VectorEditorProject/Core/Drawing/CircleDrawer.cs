using System;
using System.Drawing;
using System.Linq;
using VectorEditorProject.Figures;

namespace VectorEditorProject.Drawing
{
    public class CircleDrawer : BaseDrawer
    {
        /// <summary>
        /// Рисование круга
        /// </summary>
        /// <param name="figure">Фигура, которую рисуем (круг)</param>
        /// <param name="graphics">Объект graphics, на котором рисуем</param>
        public override void DrawFigure(BaseFigure figure, Graphics graphics)
        {
            if (figure.PointsSettings.GetPoints().Count == 2)
            {
                // Приведение типа к заливным фигурам
                FilledBaseFigure filledBaseFigure = figure as FilledBaseFigure;
                if (filledBaseFigure == null)
                {
                    return;
                }

                var points = filledBaseFigure.PointsSettings.GetPoints();
                int deltaX = Math.Abs(points.First().X - points.Last().X);
                int deltaY = Math.Abs(points.First().Y - points.Last().Y);
                int distance = Math.Max(deltaX, deltaY);

                Brush brush = new SolidBrush(filledBaseFigure.FillSettings.Color);
                graphics.FillEllipse(brush, points.First().X,
                    points.First().Y, distance, distance);

                Pen pen = new Pen(filledBaseFigure.LineSettings.
                    Color, filledBaseFigure.LineSettings.Width);
                pen.DashStyle = filledBaseFigure.LineSettings.Style;
                
                graphics.DrawEllipse(pen, points.First().X,
                    points.First().Y, distance, distance);

                brush.Dispose();
                pen.Dispose();
            }
        }
    }
}
