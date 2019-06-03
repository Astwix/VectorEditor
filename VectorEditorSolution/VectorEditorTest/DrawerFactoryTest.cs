using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
        [TestCase(TestName = "Позитивное создание фабрики Drawer'ов " +
                             "через контейнер")]
        public void ConstructorTest()
        {
            // Arrange
            var df = new DrawerFactory();

            // Act 
            int containerParsedCount = DI.GetInstance().Container
                .GetAllInstances<DrawerBase>()
                .Count();
            var _typeToDrawerBaseMap =
                (Dictionary<string, DrawerBase>)
                (new PrivateObject(df).GetField("_typeToDrawerBaseMap"));
            int drawerFactoryCreatedCount = _typeToDrawerBaseMap.Count;

            // Assert
            Assert.AreEqual(containerParsedCount, drawerFactoryCreatedCount);
        }

        [TestCase(TestName = "Смешанная проверка отрисовки холста")]
        public void DrawCanvasTest()
        {
            // Arrange 
            var df = new DrawerFactory();
            var bitmap = new Bitmap(10, 10);

            // Act 
            var bitmapBeforeDraw = (Bitmap)bitmap.Clone();
            df.DrawCanvas(Color.AliceBlue, new Size(10, 10),
                Graphics.FromImage(bitmap));
            var bitmapAfterDraw = (Bitmap)bitmap.Clone();

            // Assert
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

        [TestCase(TestName = "Смешанная проверка отрисовки по реальной фигуре")]
        public void DrawFigureWithRealFigureTest()
        {
            // Arrange 
            var df = new DrawerFactory();
            FigureBase figure = new CircleFigure();
            figure.PointsSettings.AddPoint(new PointF(0, 0));
            figure.PointsSettings.AddPoint(new PointF(10, 10));
            var bitmap = new Bitmap(10, 10);

            // Act 
            var bitmapBeforeDraw = (Bitmap)bitmap.Clone();
            df.DrawFigure(figure, Graphics.FromImage(bitmap));
            var bitmapAfterDraw = (Bitmap)bitmap.Clone();

            // Assert
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

        [TestCase(TestName = "Смешанная проверка отрисовки по мок фигуре")]
        public void DrawFigureWithMockTest()
        {
            // Arrange 
            var df = new DrawerFactory();
            Mock<FigureBase> figureMock = new Mock<FigureBase>();
            Mock<DrawerBase> figureDrawerMock = new Mock<DrawerBase>();
            var _typeToDrawerBaseMap =
                (Dictionary<string, DrawerBase>) (
                    new PrivateObject(df).GetField("_typeToDrawerBaseMap"));
            _typeToDrawerBaseMap.Add(
                figureDrawerMock.Object.GetType().Assembly.GetName().Name,
                figureDrawerMock.Object);

            // Act 
            df.DrawFigure(figureMock.Object,
                Graphics.FromImage(new Bitmap(10, 10)));

            // Assert
            figureDrawerMock.Verify(
                x => x.DrawFigure(It.IsAny<FigureBase>(), It.IsAny<Graphics>()),
                Times.Once);
        }

        [TestCase(TestName = "Позитивная проверка отрисовки " +
                             "фигуры по неизвестному Drawer'у")]
        public void DrawFigureUnknownDrawerTest()
        {
            // Arrange 
            var df = new DrawerFactory();
            Mock<FigureBase> figureMock = new Mock<FigureBase>();

            // Act 
            // Assert
            Assert.Throws<KeyNotFoundException>(() =>
            {
                df.DrawFigure(figureMock.Object,
                    Graphics.FromImage(new Bitmap(10, 10)));
            });
        }

        [TestCase(TestName = "Смешанная проверка отрисовки " +
                             "выделения по реальной фигуре")]
        public void DrawBorderWithRealFigureTest()
        {
            // Arrange 
            var df = new DrawerFactory();
            FigureBase figure = new CircleFigure();
            figure.PointsSettings.AddPoint(new PointF(0, 0));
            figure.PointsSettings.AddPoint(new PointF(10, 10));
            var bitmap = new Bitmap(10, 10);

            // Act 
            var bitmapBeforeDraw = (Bitmap)bitmap.Clone();
            df.DrawBorder(figure, Graphics.FromImage(bitmap));
            var bitmapAfterDraw = (Bitmap)bitmap.Clone();

            // Assert
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

        [TestCase(TestName = "Смешанная проверка отрисовки " +
                             "выделения по мок фигуре")]
        public void DrawBorderWithMockTest()
        {
            // Arrange 
            var df = new DrawerFactory();
            Mock<FigureBase> figureMock = new Mock<FigureBase>();
            Mock<DrawerBase> figureDrawerMock = new Mock<DrawerBase>();
            var _typeToDrawerBaseMap =
                (Dictionary<string, DrawerBase>) (
                    new PrivateObject(df).GetField("_typeToDrawerBaseMap"));
            _typeToDrawerBaseMap.Add(
                figureDrawerMock.Object.GetType().Assembly.GetName().Name,
                figureDrawerMock.Object);

            // Act 
            df.DrawBorder(figureMock.Object,
                Graphics.FromImage(new Bitmap(10, 10)));

            // Assert
            figureDrawerMock.Verify(
                x => x.DrawBorder(It.IsAny<FigureBase>(), It.IsAny<Graphics>()),
                Times.Once);
        }

        [TestCase(TestName = "Позитивная проверка отрисовки " +
                             "выделения по неизвестному Drawer'у")]
        public void DrawBorderUnknownDrawerTest()
        {
            // Arrange 
            var df = new DrawerFactory();
            Mock<FigureBase> figureMock = new Mock<FigureBase>();

            // Act 
            // Assert
            Assert.Throws<KeyNotFoundException>(() =>
            {
                df.DrawBorder(figureMock.Object,
                    Graphics.FromImage(new Bitmap(10, 10)));
            });
        }
    }
}
