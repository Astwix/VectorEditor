using System.Drawing;
using System.Drawing.Drawing2D;
using NUnit.Framework;
using SDK;

namespace SDKTest
{
    [TestFixture]
    public class LineSettingsTest
    {
        [TestCase(TestName = "Позитивное создание через конструктор " +
                             "настроек линии без параметров")]
        public void ConstructorTest()
        {
            // Arrange
            var settings = new LineSettings();

            // Act
            // Assert
            Assert.AreEqual(Color.Black, settings.Color);
            Assert.AreEqual(DashStyle.Solid, settings.Style);
            Assert.AreEqual(1, settings.Width);
        }

        [TestCase(TestName = "Позитивное создание через конструктор " +
                             "настроек заливки с параметрами")]
        public void ConstructorTest2()
        {
            // Arrange
            var settings =
                new LineSettings(Color.Azure, 19, DashStyle.DashDotDot);

            // Act
            // Assert
            Assert.AreEqual(Color.Azure, settings.Color);
            Assert.AreEqual(DashStyle.DashDotDot, settings.Style);
            Assert.AreEqual(19, settings.Width);
        }

        [TestCase(TestName = "Позитивное присваивание свойства Цвет линии")]
        public void ColorPropertyTest()
        {
            // Arrange
            var settings = new LineSettings();

            // Act
            settings.Color = Color.Red;

            // Assert
            Assert.AreEqual(Color.Red, settings.Color);
        }

        [TestCase(TestName = "Позитивное присваивание свойства Стиль линии")]
        public void StylePropertyTest()
        {
            // Arrange
            var settings = new LineSettings();

            // Act
            settings.Style = DashStyle.Dash;

            // Assert
            Assert.AreEqual(DashStyle.Dash, settings.Style);
        }

        [TestCase(TestName = "Позитивное присваивание свойства Ширина линии")]
        public void WidthPropertyTest()
        {
            // Arrange
            var settings = new LineSettings();

            // Act
            settings.Width = 26;

            // Assert
            Assert.AreEqual(26, settings.Width);
        }

        [TestCase(TestName = "Позитивный расчет и зависимость " +
                             "хэш-кода от свойств объекта")]
        public void GetHashTest()
        {
            // Arrange
            var settings = new LineSettings();

            // Act
            int code1 = settings.GetHashCode();
            settings.Width = 21;
            int code2 = settings.GetHashCode();

            // Assert
            Assert.AreNotEqual(code1, code2);
        }

        [TestCase(TestName = "Позитивное переопределение ToString")]
        public void ToStringTest()
        {
            // Arrange
            var settings = new LineSettings();

            // Act
            var str = settings.ToString();

            // Assert
            Assert.AreEqual("", str);
        }
    }
}
