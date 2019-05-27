using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PolyLine;

namespace FiguresTest
{
    [TestFixture]
    class PolyLineFigureTest
    {
        [Test]
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

        [Test]
        public void GetFigureNameTest()
        {
            // Arrange
            var figure = new PolyLineFigure();

            // Act

            // Assert
            Assert.AreEqual("PolyLine", figure.GetFigureName());
        }
    }

}
