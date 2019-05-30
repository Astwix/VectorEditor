using System;
using System.Drawing;
using Circle;
using Ellipse;
using Line;
using NUnit.Framework;
using Polygon;
using PolyLine;
using SDK;

namespace FiguresTest
{
    [TestFixture()]
    class DrawersTest
    {
        [TestCase(typeof(LineFigure), typeof(LineDrawer), 
            TestName = "Позитивный результат отрисовки " +
                       "Линии LineDrawer'ом")]
        [TestCase(typeof(PolyLineFigure), typeof(PolyLineDrawer),
            TestName = "Позитивный результат отрисовки " +
                       "Полилинии PolyLineDrawer'ом")]
        [TestCase(typeof(CircleFigure), typeof(CircleDrawer),
            TestName = "Позитивный результат отрисовки " +
                       "Круга CircleDrawer'ом")]
        [TestCase(typeof(EllipseFigure), typeof(EllipseDrawer),
            TestName = "Позитивный результат отрисовки " +
                       "Эллипса EllipseDrawer'ом")]
        [TestCase(typeof(PolygonFigure), typeof(PolygonDrawer),
            TestName = "Позитивный результат отрисовки " +
                       "Многоугольника PolygonDrawer'ом")]
        public void AllDrawersTest(Type figureType, Type drawerType)
        {
            var figure = (FigureBase)Activator.CreateInstance(figureType);
            figure.PointsSettings.AddPoint(new PointF(0, 0));
            figure.PointsSettings.AddPoint(new PointF(10, 10));
            var drawer = (DrawerBase) Activator.CreateInstance(drawerType);

            var bitmap = new Bitmap(10, 10);

            var bitmapBeforeDraw = (Bitmap)bitmap.Clone();
            drawer.DrawFigure(figure, Graphics.FromImage(bitmap));
            var bitmapAfterDraw = (Bitmap)bitmap.Clone();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    var pixelBeforeDraw = bitmapBeforeDraw.GetPixel(i, j);
                    var pixelAfterDraw = bitmapAfterDraw.GetPixel(i, j);
                    if (!pixelBeforeDraw.Equals(pixelAfterDraw))
                    {
                        Assert.Pass();
                    }
                }
            }
            Assert.Fail();
        }
    }

}
