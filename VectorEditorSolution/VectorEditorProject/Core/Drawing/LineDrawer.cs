using System.Drawing;
using System.Linq;
using VectorEditorProject.Core.Figures;

namespace VectorEditorProject.Core.Drawing
{
    /// <summary>
    /// Рисование линии
    /// </summary>
    public class LineDrawer : DrawerBase
    {
        /// <summary>
        /// Рисование линии
        /// </summary>
        /// <param name="figure">Объект, который рисуем (линия)</param>
        /// <param name="graphics">Объект graphics, на котором рисуем</param>
        public override void DrawFigure(FigureBase figure, Graphics graphics)
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
