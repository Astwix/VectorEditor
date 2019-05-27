using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ellipse;
using NUnit.Framework;

namespace FiguresTest
{
    [TestFixture]
    class EllipseFigureTest
    {
        [Test]
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

        [Test]
        public void GetFigureNameTest()
        {
            // Arrange
            var figure = new EllipseFigure();

            // Act
            
            // Assert
            Assert.AreEqual("Ellipse", figure.GetFigureName());
        }
    }

}
