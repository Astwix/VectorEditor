using System.Drawing;
using System.Drawing.Drawing2D;
using VectorEditorProject.Core.Figures;

namespace VectorEditorProject.Core.Drawing
{
    public abstract class DrawerBase
    {
        public abstract void DrawFigure(FigureBase figure, Graphics graphics);

        /// <summary>
        /// Рисование границы
        /// </summary>
        /// <param name="figure">Фигура</param>
        /// <param name="graphics"></param>
        public virtual void DrawBorder(FigureBase figure, Graphics graphics)
        {
            Pen pen = new Pen(Color.Black);
            pen.DashStyle = DashStyle.Dash;

            graphics.DrawRectangle(pen, figure.GetBorderRectangle());

            pen.Dispose();
        }
    }
}
