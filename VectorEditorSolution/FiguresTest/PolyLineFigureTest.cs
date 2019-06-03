using System;
using NUnit.Framework;
using PolyLine;

namespace FiguresTest
{
    [TestFixture]
    class PolyLineFigureTest
    {
        [TestCase(TestName = "Позитивное создание фигуры " +
                             "Полилиния через конструктор")]
        public void ConstructorTest()
        {
            // Arrange
            var figure = new PolyLineFigure();

            // Act
            // Assert
            Assert.NotNull(figure.PointsSettings);
            Assert.NotNull(figure.LineSettings);
            Assert.AreNotEqual(Guid.Empty, figure.guid);
        }

        [TestCase(TestName = "Позитивная проверка значения свойства Имя фигуры")]
        public void FigureNameTest()
        {
            // Arrange
            var figure = new PolyLineFigure();

            // Act
            // Assert
            Assert.AreEqual("PolyLine", figure.FigureName);
        }
    }

}
