using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Circle;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using SDK;
using VectorEditorProject.Core;
using Assert = NUnit.Framework.Assert;

namespace VectorEditorTest
{
    [TestFixture()]
    class DrawerFactoryTest
    {
        [Test]
        public void ConstructorTest()
        {
            var df = new DrawerFactory();

            int containerParsedCount = DI.getInstance().Container
                .GetAllInstances<DrawerBase>()
                .Count();
            var _typeToDrawerBaseMap =
                (Dictionary<string, DrawerBase>)
                (new PrivateObject(df).GetField("_typeToDrawerBaseMap"));
            int drawerFacadeCreatedCount = _typeToDrawerBaseMap.Count;

            Assert.AreEqual(containerParsedCount, drawerFacadeCreatedCount);
        }

        [Test]
        public void DrawCanvasTest()
        {
            var df = new DrawerFactory();
            var bitmap = new Bitmap(10, 10);

            var bitmapBeforeDraw = (Bitmap)bitmap.Clone();
            df.DrawCanvas(Color.AliceBlue, new Size(10, 10),
                Graphics.FromImage(bitmap));
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

        [Test]
        public void DrawFigureWithRealFigureTest()
        {
            var df = new DrawerFactory();
            FigureBase figure = new CircleFigure();
            figure.PointsSettings.AddPoint(new PointF(0, 0));
            figure.PointsSettings.AddPoint(new PointF(10, 10));
            var bitmap = new Bitmap(10, 10);

            var bitmapBeforeDraw = (Bitmap)bitmap.Clone();
            df.DrawFigure(figure, Graphics.FromImage(bitmap));
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

        [Test]
        public void DrawFigureWithMockTest()
        {
            var df = new DrawerFactory();
            Mock<FigureBase> figureMock = new Mock<FigureBase>();
            Mock<DrawerBase> figureDrawerMock = new Mock<DrawerBase>();
            var _typeToDrawerBaseMap =
                (Dictionary<string, DrawerBase>) (
                    new PrivateObject(df).GetField("_typeToDrawerBaseMap"));
            _typeToDrawerBaseMap.Add(
                figureDrawerMock.Object.GetType().Assembly.GetName().Name,
                figureDrawerMock.Object);

            df.DrawFigure(figureMock.Object,
                Graphics.FromImage(new Bitmap(10, 10)));

            figureDrawerMock.Verify(
                x => x.DrawFigure(It.IsAny<FigureBase>(), It.IsAny<Graphics>()),
                Times.Once);
        }

        [Test]
        public void DrawFigureUnknownDrawerTest()
        {
            var df = new DrawerFactory();
            Mock<FigureBase> figureMock = new Mock<FigureBase>();

            Assert.Throws<KeyNotFoundException>(() =>
            {
                df.DrawFigure(figureMock.Object,
                    Graphics.FromImage(new Bitmap(10, 10)));
            });
        }

        [Test]
        public void DrawBorderWithRealFigureTest()
        {
            var df = new DrawerFactory();
            FigureBase figure = new CircleFigure();
            figure.PointsSettings.AddPoint(new PointF(0, 0));
            figure.PointsSettings.AddPoint(new PointF(10, 10));
            var bitmap = new Bitmap(10, 10);

            var bitmapBeforeDraw = (Bitmap)bitmap.Clone();
            df.DrawBorder(figure, Graphics.FromImage(bitmap));
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

        [Test]
        public void DrawBorderWithMockTest()
        {
            var df = new DrawerFactory();
            Mock<FigureBase> figureMock = new Mock<FigureBase>();
            Mock<DrawerBase> figureDrawerMock = new Mock<DrawerBase>();
            var _typeToDrawerBaseMap =
                (Dictionary<string, DrawerBase>) (
                    new PrivateObject(df).GetField("_typeToDrawerBaseMap"));
            _typeToDrawerBaseMap.Add(
                figureDrawerMock.Object.GetType().Assembly.GetName().Name,
                figureDrawerMock.Object);

            df.DrawBorder(figureMock.Object,
                Graphics.FromImage(new Bitmap(10, 10)));

            figureDrawerMock.Verify(
                x => x.DrawBorder(It.IsAny<FigureBase>(), It.IsAny<Graphics>()),
                Times.Once);
        }

        [Test]
        public void DrawBorderUnknownDrawerTest()
        {
            var df = new DrawerFactory();
            Mock<FigureBase> figureMock = new Mock<FigureBase>();

            Assert.Throws<KeyNotFoundException>(() =>
            {
                df.DrawBorder(figureMock.Object,
                    Graphics.FromImage(new Bitmap(10, 10)));
            });
        }
    }
}
