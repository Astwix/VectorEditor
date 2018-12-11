using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using VectorEditorProject.Core.Figures.Utility;
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
            if (figure.PointsSettings.GetPoints().Count >= 2)
            {
                FilledBaseFigure filledBaseFigure = figure as  FilledBaseFigure;
                if (filledBaseFigure == null)
                {
                    return;
                }

                Brush brush = new SolidBrush(filledBaseFigure.FillSettings.Color);
                graphics.FillPolygon(brush, filledBaseFigure.PointsSettings.GetPoints().ToArray());

                Pen pen = new Pen(filledBaseFigure.LineSettings.Color, filledBaseFigure.LineSettings.Width);
                pen.DashStyle = filledBaseFigure.LineSettings.Style;
                graphics.DrawPolygon(pen, filledBaseFigure.PointsSettings.GetPoints().ToArray());

                brush.Dispose();
                pen.Dispose();
            }
        }

        /// <summary>
        /// Рисование границы
        /// </summary>
        /// <param name="figure">Фигура</param>
        /// <param name="graphics"></param>
        public override void DrawBorder(BaseFigure figure, Graphics graphics)
        {
            if (figure.PointsSettings.GetPoints().Count >= 2)
            {
                var leftTopPoint = FigureEditor.LeftTopPointF(figure);
                var rightBottomPoint = FigureEditor.RightBottomPointF(figure);

                Pen pen = new Pen(Color.Black);
                pen.DashStyle = DashStyle.Dash;
                graphics.DrawRectangle(pen, leftTopPoint.X, leftTopPoint.Y,
                    rightBottomPoint.X - leftTopPoint.X, rightBottomPoint.Y - leftTopPoint.Y);

                pen.Dispose();
            }
        }
    }
}
