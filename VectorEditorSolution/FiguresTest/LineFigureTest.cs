using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Line;
using NUnit.Framework;

namespace FiguresTest
{
    [TestFixture()]
    class LineFigureTest
    {
        [Test]
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

        [Test]
        public void GetFigureNameTest()
        {
            // Arrange
            var figure = new LineFigure();

            // Act
            
            // Assert
            Assert.AreEqual("Line", figure.GetFigureName());
        }
    }

}
