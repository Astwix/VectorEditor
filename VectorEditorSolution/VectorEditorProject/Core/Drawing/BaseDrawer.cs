using System.Drawing;
using System.Drawing.Drawing2D;
using VectorEditorProject.Core.Figures;

namespace VectorEditorProject.Core.Drawing
{
    public abstract class BaseDrawer
    {
        public abstract void DrawFigure(BaseFigure figure, Graphics graphics);

        /// <summary>
        /// Рисование границы
        /// </summary>
        /// <param name="figure">Фигура</param>
        /// <param name="graphics"></param>
        public virtual void DrawBorder(BaseFigure figure, Graphics graphics)
        {
            Pen pen = new Pen(Color.Black);
            pen.DashStyle = DashStyle.Dash;

            graphics.DrawRectangle(pen, figure.GetBorderRectangle());

            pen.Dispose();
        }
    }
}
