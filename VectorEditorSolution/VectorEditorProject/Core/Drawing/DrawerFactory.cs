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
        /// Рисование линии
        /// </summary>
        private DrawerBase _lineDrawer;

        /// <summary>
        /// Рисование полилинии
        /// </summary>
        private DrawerBase _polyLineDrawer;

        /// <summary>
        /// Рисование полигона
        /// </summary>
        private DrawerBase _polygonDrawer;

        /// <summary>
        /// Рисование круга
        /// </summary>
        private DrawerBase _circleDrawer;

        /// <summary>
        /// Рисование эллипса
        /// </summary>
        private DrawerBase _ellipseDrawer;

        /// <summary>
        /// Словарь тип фигуры -> конкретныое рисование
        /// </summary>
        Dictionary<Type, DrawerBase> typeToDrawerBaseMap = null;

        /// <summary>
        /// Конструктор фабрики фигур
        /// </summary>
        public DrawerFactory()
        {
            typeToDrawerBaseMap = new Dictionary<Type, DrawerBase>();

            _lineDrawer = new LineDrawer();
            _polyLineDrawer = new PolyLineDrawer();
            _polygonDrawer = new PolygonDrawer();
            _circleDrawer = new CircleDrawer();
            _ellipseDrawer = new EllipseDrawer();

            typeToDrawerBaseMap.Add(typeof(Line), _lineDrawer);
            typeToDrawerBaseMap.Add(typeof(PolyLine), _polyLineDrawer);
            typeToDrawerBaseMap.Add(typeof(Polygon), _polygonDrawer);
            typeToDrawerBaseMap.Add(typeof(Circle), _circleDrawer);
            typeToDrawerBaseMap.Add(typeof(Ellipse), _ellipseDrawer);
        }

        /// <summary>
        /// Рисование фигур
        /// </summary>
        /// <param name="baseFigure">Фигура</param>
        /// <param name="graphics">Графика</param>
        public void DrawFigure(FigureBase baseFigure, Graphics graphics)
        {
            typeToDrawerBaseMap[baseFigure.GetType()].DrawFigure(baseFigure,
                    graphics);
        }

        /// <summary>
        /// Рисование границы
        /// </summary>
        /// <param name="baseFigure">Базовая фигура</param>
        /// <param name="graphics">Графика</param>
        public void DrawBorder(FigureBase baseFigure, Graphics graphics)
        {
            typeToDrawerBaseMap[baseFigure.GetType()].DrawBorder(baseFigure,
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
