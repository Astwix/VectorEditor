using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using VectorEditorProject.Core.Figures;
using VectorEditorProject.Core.Figures.Utility;

namespace VectorEditorProject.Core.Drawing
{
    public class PolyLineDrawer : BaseDrawer
    {
        /// <summary>
        /// Рисование полилинии
        /// </summary>
        /// <param name="figure">Объект, который рисуем (полилиния)</param>
        /// <param name="graphics">Объект graphics, на котором рисуем</param>
        public override void DrawFigure(BaseFigure figure, Graphics graphics)
        {
            if (figure.PointsSettings.GetPoints().Count() >= 2)
            {
                Pen pen = new Pen(figure.LineSettings.Color, figure.LineSettings.Width);
                pen.DashStyle = figure.LineSettings.Style;
                graphics.DrawLines(pen, figure.PointsSettings.GetPoints().ToArray());

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
