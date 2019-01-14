using System.Drawing;
using System.Linq;
using VectorEditorProject.Core.Figures;

namespace VectorEditorProject.Core.Drawing
{
    /// <summary>
    /// Рисование многоугольника
    /// </summary>
    public class PolygonDrawer : DrawerBase
    {
        /// <summary>
        /// Рисование фигуры - многоугольник
        /// </summary>
        /// <param name="figure">Объект, который рисуем (многоугольник)</param>
        /// <param name="graphics">Объект graphics, на котором рисуем</param>
        public override void DrawFigure(FigureBase figure, Graphics graphics)
        {
            if (figure.PointsSettings.GetPoints().Count >= 2)
            {
                FilledFigureBase filledBaseFigure = figure as FilledFigureBase;
                if (filledBaseFigure == null)
                {
                    return;
                }

                Brush brush =
                    new SolidBrush(filledBaseFigure.FillSettings.Color);
                graphics.FillPolygon(brush,
                    filledBaseFigure.PointsSettings.GetPoints().ToArray());

                Pen pen = new Pen(filledBaseFigure.LineSettings.Color,
                    filledBaseFigure.LineSettings.Width);
                pen.DashStyle = filledBaseFigure.LineSettings.Style;
                graphics.DrawPolygon(pen,
                    filledBaseFigure.PointsSettings.GetPoints().ToArray());

                brush.Dispose();
                pen.Dispose();
            }
        }
    }
}
