using System;
using System.Collections.Generic;
using System.Drawing;
using VectorEditorProject.Core.Figures;

namespace VectorEditorProject.Core.Drawing
{
    /// <summary>
    /// Фабрика рисования
    /// </summary>
    public class DrawerFactory
    {
        /// <summary>
        /// Словарь тип фигуры -> конкретное рисование
        /// </summary>
        private readonly Dictionary<Type, DrawerBase> _typeToDrawerBaseMap = null;

        /// <summary>
        /// Конструктор фабрики фигур
        /// </summary>
        public DrawerFactory()
        {
            _typeToDrawerBaseMap = new Dictionary<Type, DrawerBase>
            {
                {typeof(Line), new LineDrawer()},
                {typeof(PolyLine), new PolyLineDrawer()},
                {typeof(Polygon), new PolygonDrawer()},
                {typeof(Circle), new CircleDrawer()},
                {typeof(Ellipse), new EllipseDrawer()}
            };

        }

        /// <summary>
        /// Рисование фигур
        /// </summary>
        /// <param name="baseFigure">Фигура</param>
        /// <param name="graphics">Графика</param>
        public void DrawFigure(FigureBase baseFigure, Graphics graphics)
        {
            _typeToDrawerBaseMap[baseFigure.GetType()].DrawFigure(baseFigure,
                    graphics);
        }

        /// <summary>
        /// Рисование границы фигуры
        /// </summary>
        /// <param name="baseFigure">Базовая фигура</param>
        /// <param name="graphics">Графика</param>
        public void DrawBorder(FigureBase baseFigure, Graphics graphics)
        {
            _typeToDrawerBaseMap[baseFigure.GetType()].DrawBorder(baseFigure,
                    graphics);
        }

        /// <summary>
        /// Рисование холста
        /// </summary>
        /// <param name="document">Документ</param>
        /// <param name="graphics">Графика</param>
        public void DrawCanvas(Document document, Graphics graphics)
        {
            Brush brush = new SolidBrush(document.Color);

            graphics.FillRectangle(brush,
                new RectangleF(new PointF(0, 0), document.Size));

            brush.Dispose();
        }
    }
}
