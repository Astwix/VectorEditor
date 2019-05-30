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
        [TestCase(typeof(LineFigure), typeof(LineDrawer))]
        [TestCase(typeof(PolyLineFigure), typeof(PolyLineDrawer))]
        [TestCase(typeof(CircleFigure), typeof(CircleDrawer))]
        [TestCase(typeof(EllipseFigure), typeof(EllipseDrawer))]
        [TestCase(typeof(PolygonFigure), typeof(PolygonDrawer))]
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
