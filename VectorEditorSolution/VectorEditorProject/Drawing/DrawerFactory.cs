using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorEditorProject.Figures;

namespace VectorEditorProject.Drawing
{
    public class DrawerFactory
    {
        private BaseDrawer _lineDrawer;
        private BaseDrawer _polyLineDrawer;
        private BaseDrawer _polygonDrawer;
        private BaseDrawer _circleDrawer;
        private BaseDrawer _ellipseDrawer;

        Dictionary<Type, BaseDrawer> drawers = null;

        /// <summary>
        /// Конструктор фабрики фигур
        /// </summary>
        public DrawerFactory()
        {
            drawers = new Dictionary<Type, BaseDrawer>();

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
        public void DrawFigure(BaseFigure baseFigure, Graphics graphics)
        {
            drawers[baseFigure.GetType()].DrawFigure(baseFigure, graphics);
        }
    }
}
