using System;
using NUnit.Framework;
using Polygon;

namespace FiguresTest
{
    [TestFixture]
    class PolygonFigureTest
    {
        [Test]
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

        [Test]
        public void GetFigureNameTest()
        {
            // Arrange
            var figure = new PolygonFigure();

            // Act
            
            // Assert
            Assert.AreEqual("Polygon", figure.FigureName);
        }
    }

}
