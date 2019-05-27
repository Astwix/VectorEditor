using System;
using System.Drawing;
using Circle;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Assert = NUnit.Framework.Assert;

namespace FiguresTest
{
    [TestFixture]
    public class CircleFigureTest
    {
        [Test]
        public void ConstructorTest()
        {
            // Arrange
            var figure = new CircleFigure();

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
            var figure = new CircleFigure();

            // Act

            // Assert
            Assert.AreEqual("Circle", figure.GetFigureName());
        }

        [Test]
        public void GetBorderRectangleTest()
        {
            // Arrange
            var figure = new CircleFigure();
            figure.PointsSettings.AddPoint(new PointF(0, 0));
            figure.PointsSettings.AddPoint(new PointF(10, 10));

            // Act
            var rec1 = figure.GetBorderRectangle();
            figure.PointsSettings.ReplacePoint(1, new PointF(20, 0));
            var rec2 = figure.GetBorderRectangle();

            // Assert
            Assert.AreEqual(new Rectangle(0, 0, 10, 10), rec1);
            Assert.AreEqual(new Rectangle(0, 0, 20, 20), rec2);
        }
    }

}
