using System.Drawing;
using System.Windows.Forms;
using Circle;
using Moq;
using NUnit.Framework;
using VectorEditorProject.Core;
using VectorEditorProject.Core.Commands;
using VectorEditorProject.Forms;
using VectorEditorTest.Stubs;

namespace VectorEditorTest
{
    [TestFixture]
    class ChangingDocumentOptionsCommandTest
    {
        [Test]
        public void Constructor1Test()
        {
            // Arrange
            var controlUnitMock = new Mock<IControlUnit>();
            controlUnitMock.Setup(x => x.GetDocument())
                .Returns(new Document("Test02", Color.Green,
                    new Size(99, 88)));

            // Act
            var command = new ChangingDocumentOptionsCommandStub(controlUnitMock.Object,
                new Document("Test01", Color.Red, new Size(22, 33)));

            // Assert
            Assert.IsNotNull(command.ControlUnit);
            Assert.AreEqual("Test01", command.NewName);
            Assert.AreEqual(Color.Red, command.NewColor);
            Assert.AreEqual(new Size(22, 33), command.NewSize);
            Assert.AreEqual("Test02", command.BackUpName);
            Assert.AreEqual(Color.Green, command.BackUpColor);
            Assert.AreEqual(new Size(99, 88), command.BackUpSize);
            controlUnitMock.Verify(x => x.GetDocument(), Times.Once);
        }

        [Test]
        public void DoTest()
        {
            // Arrange
            var figure = new CircleFigure();
            var controlUnit = new ControlUnitStub(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                new PropertyGrid());
            controlUnit.GetDocument().AddFigure(figure);

            // Act
            var command = new ChangingDocumentOptionsCommand(controlUnit,
                new Document("Test01", Color.Red, new Size(22, 33)));
            command.Do();
            var docAfterAct =
                controlUnit.GetDocument();

            // Assert
            Assert.AreEqual("Test01", docAfterAct.Name);
            Assert.AreEqual(Color.Red, docAfterAct.Color);
            Assert.AreEqual(new Size(22, 33), docAfterAct.Size);
        }

        [Test]
        public void UndoTest()
        {
            // Arrange
            var figure = new CircleFigure();
            var controlUnit = new ControlUnitStub(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                new PropertyGrid());
            controlUnit.GetDocument().AddFigure(figure);

            // Act
            var command = new ChangingDocumentOptionsCommand(controlUnit,
                new Document("Test01", Color.Red, new Size(22, 33)));
            command.Do();
            command.Undo();
            var docAfterAct =
                controlUnit.GetDocument();

            // Assert
            Assert.AreNotEqual("Test01", docAfterAct.Name);
            Assert.AreNotEqual(Color.Red, docAfterAct.Color);
            Assert.AreNotEqual(new Size(22, 33), docAfterAct.Size);
        }

        [Test]
        public void ToStringTest()
        {
            // Arrange
            var controlUnit = new ControlUnitStub(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                new PropertyGrid());

            // Act
            var command = new ChangingDocumentOptionsCommand(controlUnit,
                new Document("Test01", Color.Red, new Size(22, 33)));

            // Assert
            Assert.IsTrue(command.ToString().Length > 0);
        }

        [Test]
        public void GetHashTest()
        {
            // Arrange
            var controlUnit = new ControlUnitStub(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                new PropertyGrid());

            // Act
            var command = new ChangingDocumentOptionsCommand(controlUnit,
                new Document("Test01", Color.Red, new Size(22, 33)));

            // Assert
            Assert.AreNotEqual(0, command.GetHashCode());
        }
    }
}
