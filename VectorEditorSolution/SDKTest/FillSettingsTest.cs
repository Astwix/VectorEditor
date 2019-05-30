using System.Drawing;
using NUnit.Framework;
using SDK;

namespace SDKTest
{
    [TestFixture]
    public class FillSettingsTest
    {
        [TestCase(TestName = "Позитивное создание через конструктор " +
                             "настроек заливки без параметров")]
        public void ConstructorTest()
        {
            // Arrange
            var settings = new FillSettings();

            // Act
            // Assert
            Assert.AreEqual(Color.Transparent, settings.Color);
        }

        [TestCase(TestName = "Позитивное создание через конструктор " +
                             "настроек заливки с параметром")]
        public void ConstructorTest2()
        {
            // Arrange
            var settings =
                new FillSettings(Color.Azure);

            // Act
            // Assert
            Assert.AreEqual(Color.Azure, settings.Color);
        }

        [TestCase(TestName = "Позитивное присваивание свойства Цвет")]
        public void ColorPropertyTest()
        {
            // Arrange
            var settings = new FillSettings();

            // Act
            settings.Color = Color.Red;

            // Assert
            Assert.AreEqual(Color.Red, settings.Color);
        }

        [TestCase(TestName = "Позитивный расчет и зависимость " +
                             "хэш-кода от свойств объекта")]
        public void GetHashTest()
        {
            // Arrange
            var settings = new FillSettings();

            // Act
            int code1 = settings.GetHashCode();
            settings.Color = Color.Bisque;
            int code2 = settings.GetHashCode();

            // Assert
            Assert.AreNotEqual(code1, code2);
        }

        [TestCase(TestName = "Позитивное переопределение ToString")]
        public void ToStringTest()
        {
            // Arrange
            var settings = new FillSettings();

            // Act
            var str = settings.ToString();

            // Assert
            Assert.AreEqual("", str);
        }
    }
}
