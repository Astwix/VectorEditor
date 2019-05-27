using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SDK;
using SDKTest.Stubs;

namespace SDKTest
{
    [TestFixture]
    class PointsSettingsTest
    {
        [Test]
        public void ConstructorTest()
        {
            // Arrange
            var settings = new PointsSettingsStub();

            // Act
            // Assert
            Assert.AreEqual(0, settings.LimitPoint);
            Assert.IsEmpty(settings.Points);
        }

        [Test]
        public void ConstructorTest2()
        {
            // Arrange
            var settings = new PointsSettingsStub(12);

            // Act
            // Assert
            Assert.AreEqual(12, settings.LimitPoint);
            Assert.IsEmpty(settings.Points);
        }

        [Test]
        public void TopLeftPointTest()
        {
            // Arrange
            var settings = new PointsSettingsStub();

            // Act
            settings.AddPoint(new PointF(10, 10));
            settings.AddPoint(new PointF(10, 20));
            settings.AddPoint(new PointF(20, 60));

            // Assert
            Assert.AreEqual(10, settings.LeftTopPointF().X);
            Assert.AreEqual(10, settings.LeftTopPointF().Y);
        }

        [Test]
        public void RightDownPointTest()
        {
            // Arrange
            var settings = new PointsSettingsStub();

            // Act
            settings.AddPoint(new PointF(10, 10));
            settings.AddPoint(new PointF(10, 20));
            settings.AddPoint(new PointF(20, 60));

            // Assert
            Assert.AreEqual(20, settings.RightBottomPointF().X);
            Assert.AreEqual(60, settings.RightBottomPointF().Y);
        }

        [Test]
        public void ReplacePointTest()
        {
            // Arrange
            var settings = new PointsSettingsStub();

            // Act
            settings.AddPoint(new PointF(10, 10));
            settings.AddPoint(new PointF(10, 20));
            settings.AddPoint(new PointF(20, 60));
            settings.ReplacePoint(1, new PointF(100, 200));

            // Assert
            Assert.AreEqual(100, settings.Points[1].X);
            Assert.AreEqual(200, settings.Points[1].Y);
        }

        [Test]
        public void RemovePointTest()
        {
            // Arrange
            var settings = new PointsSettingsStub();

            // Act
            settings.AddPoint(new PointF(10, 10));
            settings.AddPoint(new PointF(10, 20));
            settings.AddPoint(new PointF(20, 60));
            settings.DeletePoint(new PointF(10, 10));

            // Assert
            Assert.IsTrue(settings.Points.Count == 2);
            Assert.IsTrue(settings.Points.Contains(new PointF(10, 20)));
            Assert.IsTrue(settings.Points.Contains(new PointF(20, 60)));
        }

        [Test]
        public void RemoveLastTest()
        {
            // Arrange
            var settings = new PointsSettingsStub();

            // Act
            settings.AddPoint(new PointF(10, 10));
            settings.AddPoint(new PointF(10, 20));
            settings.AddPoint(new PointF(20, 60));
            settings.RemoveLast();

            // Assert
            Assert.IsTrue(settings.Points.Count == 2);
            Assert.IsTrue(settings.Points.Contains(new PointF(10, 10)));
            Assert.IsTrue(settings.Points.Contains(new PointF(10, 20)));
        }

        [Test]
        public void IsFigureInRectangleTest()
        {
            // Arrange
            var settings = new PointsSettingsStub();

            // Act
            settings.AddPoint(new PointF(10, 10));
            settings.AddPoint(new PointF(20, 20));

            bool shouldBeTrue =
                settings.IsFigureInRectangle(new Rectangle(0, 0, 30, 30));
            bool shouldBeFalse =
                settings.IsFigureInRectangle(new Rectangle(0, 0, 15, 15));

            // Assert
            Assert.IsTrue(shouldBeTrue);
            Assert.IsFalse(shouldBeFalse);

        }

        [Test]
        public void GetHashCodeTest()
        {
            // Arrange
            var settings = new PointsSettingsStub();

            // Act
            settings.AddPoint(new PointF(10, 10));
            settings.AddPoint(new PointF(20, 20));

            var code1 = settings.GetHashCode();
            settings.AddPoint(new PointF(33, 22));
            var code2 = settings.GetHashCode();
            
            // Assert
            Assert.AreNotEqual(code1, code2);
        }

        [Test]
        public void EditFiguresSizeTest()
        {
            // Arrange
            var settings = new PointsSettingsStub();

            // Act
            settings.AddPoint(new PointF(10, 10));
            settings.AddPoint(new PointF(20, 20));

            settings.EditFiguresSize(new RectangleF(0, 0, 10, 10));
            
            // Assert
            Assert.AreEqual(new PointF(0, 0), settings.LeftTopPointF());
            Assert.AreEqual(new PointF(10, 10), settings.RightBottomPointF());
        }

        [Test]
        public void DistanceBetweenPointsTest()
        {
            // Arrange
            var point1 = new PointF(10, 10);
            var point2 = new PointF(20, 20);

            // Assert
            Assert.AreEqual(Math.Sqrt(200),
                PointsSettings.DistanceBetweenPoints(point1, point2), 0.1);
        }

        [Test]
        public void ClearTest()
        {
            // Arrange
            var settings = new PointsSettingsStub();

            // Act
            settings.AddPoint(new PointF(10, 10));
            settings.AddPoint(new PointF(20, 20));

            settings.Clear();
            
            // Assert
            Assert.IsEmpty(settings.Points);
        }

        [Test]
        public void CanAddPointsTest()
        {
            // Arrange
            var settings = new PointsSettingsStub(1);

            // Act
            var shouldBeTrue = settings.CanAddPoint();
            settings.AddPoint(new PointF(10, 10));
            var shouldBeFalse = settings.CanAddPoint();
            settings.AddPoint(new PointF(20, 20));

            // Assert
            Assert.IsTrue(shouldBeTrue);
            Assert.IsFalse(shouldBeFalse);
            Assert.IsTrue(settings.Points.Count == 1);
        }

        [Test]
        public void AddPointsTest()
        {
            // Arrange
            var settings = new PointsSettingsStub();

            // Act
            var shouldBeZero = settings.Points.Count;
            settings.AddPoint(new PointF(10, 10));
            var shouldBeOne = settings.Points.Count;

            // Assert
            Assert.AreEqual(0, shouldBeZero);
            Assert.AreEqual(1, shouldBeOne);
        }
    }
}
