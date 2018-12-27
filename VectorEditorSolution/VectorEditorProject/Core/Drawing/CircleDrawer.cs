using System;
using System.Drawing;
using VectorEditorProject.Core.Figures;
using VectorEditorProject.Core.Figures.Utility;

namespace VectorEditorProject.Core.Drawing
{
    public class CircleDrawer : DrawerBase
    {
        /// <summary>
        /// Рисование круга
        /// </summary>
        /// <param name="figure">Фигура, которую рисуем (круг)</param>
        /// <param name="graphics">Объект graphics, на котором рисуем</param>
        public override void DrawFigure(FigureBase figure, Graphics graphics)
        {
            if (figure.PointsSettings.GetPoints().Count == 2)
            {
                // Приведение типа к заливным фигурам
                FilledFigureBase filledBaseFigure = figure as FilledFigureBase;
                if (filledBaseFigure == null)
                {
                    return;
                }

                var leftTopPoint = FigureEditor.LeftTopPointF(figure);
                var rightBottomPoint = FigureEditor.RightBottomPointF(figure);

                float deltaX = Math.Abs(leftTopPoint.X - rightBottomPoint.X);
                float deltaY = Math.Abs(leftTopPoint.Y - rightBottomPoint.Y);
                float distance = Math.Max(deltaX, deltaY);

                Brush brush = new SolidBrush(filledBaseFigure.FillSettings.Color);
                graphics.FillEllipse(brush, leftTopPoint.X,
                    leftTopPoint.Y, distance, distance);

                Pen pen = new Pen(filledBaseFigure.LineSettings.
                    Color, filledBaseFigure.LineSettings.Width);
                pen.DashStyle = filledBaseFigure.LineSettings.Style;
                
                graphics.DrawEllipse(pen, leftTopPoint.X,
                    leftTopPoint.Y, distance, distance);

                brush.Dispose();
                pen.Dispose();
            }
        }
    }
}
