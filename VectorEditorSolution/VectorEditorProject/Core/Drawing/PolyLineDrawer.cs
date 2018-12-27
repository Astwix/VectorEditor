using System.Drawing;
using System.Linq;
using VectorEditorProject.Core.Figures;

namespace VectorEditorProject.Core.Drawing
{
    public class PolyLineDrawer : DrawerBase
    {
        /// <summary>
        /// Рисование полилинии
        /// </summary>
        /// <param name="figure">Объект, который рисуем (полилиния)</param>
        /// <param name="graphics">Объект graphics, на котором рисуем</param>
        public override void DrawFigure(FigureBase figure, Graphics graphics)
        {
            if (figure.PointsSettings.GetPoints().Count() >= 2)
            {
                Pen pen = new Pen(figure.LineSettings.Color, figure.LineSettings.Width);
                pen.DashStyle = figure.LineSettings.Style;
                graphics.DrawLines(pen, figure.PointsSettings.GetPoints().ToArray());

                pen.Dispose();
            }
        }
    }
}
