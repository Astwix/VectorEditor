using System;
using System.Collections.Generic;
using System.Drawing;
using VectorEditorProject.Core.Figures;

namespace VectorEditorProject.Core.Drawing
{
    public class DrawerFactory
    {
        private DrawerBase _lineDrawer;
        private DrawerBase _polyLineDrawer;
        private DrawerBase _polygonDrawer;
        private DrawerBase _circleDrawer;
        private DrawerBase _ellipseDrawer;

        Dictionary<Type, DrawerBase> drawers = null;

        /// <summary>
        /// Конструктор фабрики фигур
        /// </summary>
        public DrawerFactory()
        {
            drawers = new Dictionary<Type, DrawerBase>();

            _lineDrawer = new LineDrawer();
            _polyLineDrawer = new PolyLineDrawer();
            _polygonDrawer = new PolygonDrawer();
            _circleDrawer = new CircleDrawer();
            _ellipseDrawer = new EllipseDrawer();

            drawers.Add(typeof(Line), _lineDrawer);
            drawers.Add(typeof(PolyLine), _polyLineDrawer);
            drawers.Add(typeof(Polygon), _polygonDrawer);
            drawers.Add(typeof(Circle), _circleDrawer);
            drawers.Add(typeof(Ellipse), _ellipseDrawer);
        }

        /// <summary>
        /// Рисование фигур
        /// </summary>
        /// <param name="baseFigure">Фигура</param>
        /// <param name="graphics">Объект graphics</param>
        public void DrawFigure(FigureBase baseFigure, Graphics graphics)
        {
            drawers[baseFigure.GetType()].DrawFigure(baseFigure, graphics);
        }

        public void DrawBorder(FigureBase baseFigure, Graphics graphics)
        {
            drawers[baseFigure.GetType()].DrawBorder(baseFigure, graphics);
        }

        /// <summary>
        /// Рисование холста
        /// </summary>
        /// <param name="document">Документ</param>
        /// <param name="graphics">Графика</param>
        public void DrawCanvas(Document document, Graphics graphics)
        {
            Brush brush = new SolidBrush(document.Color);

            graphics.FillRectangle(brush, new RectangleF(new PointF(0, 0), document.Size));

            brush.Dispose();
        }
    }
}
