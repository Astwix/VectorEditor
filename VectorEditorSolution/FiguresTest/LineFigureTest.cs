using System;
using Line;
using NUnit.Framework;

namespace FiguresTest
{
    [TestFixture()]
    class LineFigureTest
    {
        [TestCase(TestName = "Позитивное создание фигуры " +
                             "Линия через конструктор")]
        public void ConstructorTest()
        {
            // Arrange
            var figure = new LineFigure();

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
            var figure = new LineFigure();

            // Act
            // Assert
            Assert.AreEqual("Line", figure.FigureName);
        }
    }

}
