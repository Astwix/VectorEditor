using System;
using System.Drawing;
using NUnit.Framework;
using SDK;
using SDKTest.Stubs;

namespace SDKTest
{
    [TestFixture]
    class PointsSettingsTest
    {
        [TestCase(TestName = "Позитивное создание через конструктор " +
                             "настроек точек без параметров")]
        public void ConstructorTest()
        {
            // Arrange
            var settings = new PointsSettingsStub();

            // Act
            // Assert
            Assert.AreEqual(0, settings.LimitPoint);
            Assert.IsEmpty(settings.Points);
        }

        [TestCase(TestName = "Позитивное создание через конструктор " +
                             "настроек точек с параметрами")]
        public void ConstructorTest2()
        {
            // Arrange
            var settings = new PointsSettingsStub(12);

            // Act
            // Assert
            Assert.AreEqual(12, settings.LimitPoint);
            Assert.IsEmpty(settings.Points);
        }

        [TestCase(TestName = "Позитивное определение координат левой " +
                             "верхней точки приведенного прямоугольника")]
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

        [TestCase(TestName = "Позитивное определение координат правой " +
                             "нижней точки приведенного прямоугольника")]
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

        [TestCase(TestName = "Позитивное замещение точки по индексу")]
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

        [TestCase(TestName = "Позитивное удаление точки по самой точке")]
        public void DeletePointTest()
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

        [TestCase(TestName = "Позитивное удаление последней точки")]
        public void DeleteLastTest()
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

        [TestCase(TestName = "Позитивная проверка попадания фигуры " +
                             "в прямоугольник выделения")]
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

        [TestCase(TestName = "Позитивный расчет и зависимость " +
                             "хэш-кода от свойств объекта")]
        public void GetHashTest()
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

        [TestCase(TestName = "Позитивное пропорциональное изменение " +
                             "размера фигур")]
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

        [TestCase(TestName = "Позитивный расчет расстояния между двумя точками")]
        public void DistanceBetweenPointsTest()
        {
            // Arrange
            var point1 = new PointF(10, 10);
            var point2 = new PointF(20, 20);

            // Assert
            Assert.AreEqual(Math.Sqrt(200),
                PointsSettings.DistanceBetweenPoints(point1, point2), 0.1);
        }

        [TestCase(TestName = "Позитивная очистка списка точек")]
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

        [TestCase(TestName = "Смешанная проверка на корректное добавление " +
                             "точки, если лимит не превышен")]
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

        [TestCase(TestName = "Позитивное добавление точки")]
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
