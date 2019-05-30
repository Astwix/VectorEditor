using System;
using NUnit.Framework;
using Polygon;

namespace FiguresTest
{
    [TestFixture]
    class PolygonFigureTest
    {
        [TestCase(TestName = "Позитивное создание фигуры " +
                             "Многоугольник через конструктор")]
        public void ConstructorTest()
        {
            // Arrange
            var figure = new PolygonFigure();

            // Act
            // Assert
            Assert.NotNull(figure.PointsSettings);
            Assert.NotNull(figure.LineSettings);
            Assert.NotNull(figure.FillSettings);
            Assert.AreNotEqual(Guid.Empty, figure.guid);
        }

        [TestCase(TestName = "Позитивная проверка значения свойства Имя фигуры")]
        public void FigureNameTest()
        {
            // Arrange
            var figure = new PolygonFigure();

            // Act
            // Assert
            Assert.AreEqual("Polygon", figure.FigureName);
        }
    }

}
