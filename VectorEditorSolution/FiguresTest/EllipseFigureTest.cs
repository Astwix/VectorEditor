using System;
using Ellipse;
using NUnit.Framework;

namespace FiguresTest
{
    [TestFixture]
    class EllipseFigureTest
    {
        [TestCase(TestName = "Позитивное создание фигуры " +
                             "Эллипс через конструктор")]
        public void ConstructorTest()
        {
            // Arrange
            var figure = new EllipseFigure();

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
            var figure = new EllipseFigure();

            // Act
            // Assert
            Assert.AreEqual("Ellipse", figure.FigureName);
        }
    }

}
