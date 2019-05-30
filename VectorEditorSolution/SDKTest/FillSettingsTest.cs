using System.Drawing;
using NUnit.Framework;
using SDK;

namespace SDKTest
{
    [TestFixture]
    public class FillSettingsTest
    {
        [Test]
        public void ConstructorTest()
        {
            // Arrange
            var settings = new FillSettings();

            // Act
            // Assert
            Assert.AreEqual(Color.Transparent, settings.Color);
        }

        [Test]
        public void ConstructorTest2()
        {
            // Arrange
            var settings =
                new FillSettings(Color.Azure);

            // Act
            // Assert
            Assert.AreEqual(Color.Azure, settings.Color);
        }

        [Test]
        public void ColorPropertyTest()
        {
            // Arrange
            var settings = new FillSettings();

            // Act
            settings.Color = Color.Red;

            // Assert
            Assert.AreEqual(Color.Red, settings.Color);
        }

        [Test]
        public void GetHashCodeTest()
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

        [Test]
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
