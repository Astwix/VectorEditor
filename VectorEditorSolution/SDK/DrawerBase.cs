using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK
{
    /// <summary>
    /// Базовое рисование
    /// </summary>
    public abstract class DrawerBase
    {
        /// <summary>
        /// Рисование фигуры
        /// </summary>
        /// <param name="figure">Фигура</param>
        /// <param name="graphics">Graphics</param>
        public abstract void DrawFigure(FigureBase figure, Graphics graphics);

        /// <summary>
        /// Рисование границы
        /// </summary>
        /// <param name="figure">Фигура</param>
        /// <param name="graphics">Графика</param>
        public virtual void DrawBorder(FigureBase figure, Graphics graphics)
        {
            Pen pen = new Pen(Color.Black);
            pen.DashStyle = DashStyle.Dash;

            graphics.DrawRectangle(pen, figure.GetBorderRectangle());

            pen.Dispose();
        }
    }
}
