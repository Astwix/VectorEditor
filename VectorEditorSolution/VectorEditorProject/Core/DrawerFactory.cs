using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SDK;
using StructureMap;

namespace VectorEditorProject.Core
{
    /// <summary>
    /// Фабрика рисования
    /// </summary>
    public class DrawerFactory
    {
        /// <summary>
        /// Словарь тип фигуры -> конкретное рисование
        /// </summary>
        private readonly Dictionary<string, DrawerBase> _typeToDrawerBaseMap
            = new Dictionary<string, DrawerBase>();

        /// <summary>
        /// Конструктор фабрики фигур
        /// </summary>
        public DrawerFactory()
        {
            foreach (var drawer in DI.getInstance().Container.GetAllInstances<DrawerBase>())
            {
                _typeToDrawerBaseMap.Add(drawer.GetType().Assembly.GetName().Name, drawer);
            }
        }

        /// <summary>
        /// Рисование фигур
        /// </summary>
        /// <param name="baseFigure">Фигура</param>
        /// <param name="graphics">Графика</param>
        public void DrawFigure(FigureBase baseFigure, Graphics graphics)
        {
            _typeToDrawerBaseMap[baseFigure.GetType().Assembly.GetName().Name]
                .DrawFigure(baseFigure, graphics);
        }

        /// <summary>
        /// Рисование границы фигуры
        /// </summary>
        /// <param name="baseFigure">Базовая фигура</param>
        /// <param name="graphics">Графика</param>
        public void DrawBorder(FigureBase baseFigure, Graphics graphics)
        {
            _typeToDrawerBaseMap[baseFigure.GetType().Assembly.GetName().Name].
                DrawBorder(baseFigure, graphics);
        }

        /// <summary>
        /// Рисование холста
        /// </summary>
        /// <param name="documentSize">Размер документа</param>
        /// <param name="graphics">Графика</param>
        /// <param name="documentColor">Цвет документа</param>
        public void DrawCanvas(Color documentColor, Size documentSize,
            Graphics graphics)
        {
            Brush brush = new SolidBrush(documentColor);

            graphics.FillRectangle(brush,
                new RectangleF(new PointF(0, 0), documentSize));

            brush.Dispose();
        }
    }
}
