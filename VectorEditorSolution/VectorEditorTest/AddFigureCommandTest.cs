using System.Collections.Generic;
using System.Windows.Forms;
using Circle;
using Moq;
using NUnit.Framework;
using SDK;
using VectorEditorProject.Core;
using VectorEditorProject.Core.Commands;
using VectorEditorProject.Forms;
using VectorEditorTest.Stubs;

namespace VectorEditorTest
{
    [TestFixture]
    class AddFigureCommandTest
    {
        [Test]
        public void Constructor1Test()
        {
            // Arrange
            var controlUnitMock = new Mock<IControlUnit>();
            var figureMock = new Mock<FigureBase>();

            // Act
            var command = new AddFigureCommandStub(controlUnitMock.Object,
                figureMock.Object);

            // Assert
            Assert.IsNotNull(command.ControlUnit);
            Assert.IsNotEmpty(command.Figures);
        }

        [Test]
        public void Constructor2Test()
        {
            // Arrange
            var controlUnitMock = new Mock<IControlUnit>();
            var figureMock = new Mock<FigureBase>();

            // Act
            var command = new AddFigureCommandStub(controlUnitMock.Object,
                new List<FigureBase> { figureMock.Object });

            // Assert
            Assert.IsNotNull(command.ControlUnit);
            Assert.IsNotEmpty(command.Figures);
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
            var command = new AddFigureCommand(controlUnit, figure);
            command.Do();
            var figureAfterAct =
                controlUnit.GetDocument().GetFigure(figure.guid);

            // Assert
            Assert.IsNotNull(figureAfterAct);
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
            var command = new AddFigureCommand(controlUnit, figure);
            command.Do();
            command.Undo();
            var figureAfterAct =
                controlUnit.GetDocument().GetFigure(figure.guid);

            // Assert
            Assert.IsNotNull(figureAfterAct);
        }

        [Test]
        public void ToStringTest()
        {
            // Arrange
            var controlUnitMock = new Mock<IControlUnit>();
            var figureMock = new Mock<FigureBase>();

            // Act
            var command = new AddFigureCommand(controlUnitMock.Object,
                figureMock.Object);

            // Assert
            Assert.IsTrue(command.ToString().Length > 0);
        }

        [Test]
        public void GetHashCodeTest()
        {
            // Arrange
            var controlUnitMock = new Mock<IControlUnit>();
            var figureMock = new Mock<FigureBase>();

            // Act
            var command = new AddFigureCommandStub(controlUnitMock.Object,
                figureMock.Object);

            // Assert
            Assert.AreNotEqual(0, command.GetHashCode());
        }
    }
}
