using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    class RemoveFigureCommandTest
    {
        [Test]
        public void ConstructorTest()
        {
            // Arrange
            var controlUnitMock = new Mock<IControlUnit>();
            var figureMock = new Mock<FigureBase>();

            // Act
            var command1 = new RemoveFigureCommandStub(controlUnitMock.Object,
                new List<FigureBase>() { figureMock.Object });
            var command2 = new RemoveFigureCommandStub(controlUnitMock.Object,
                figureMock.Object);

            // Assert
            Assert.IsNotNull(command1.ControlUnit);
            Assert.IsNotEmpty(command1.Figures);
            Assert.IsNotNull(command2.ControlUnit);
            Assert.IsNotEmpty(command2.Figures);
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
            var command = new RemoveFigureCommand(controlUnit,
                new List<FigureBase>() { figure });
            command.Do();
            var figureAfterAct =
                controlUnit.GetDocument().GetFigures();

            // Assert
            Assert.IsEmpty(figureAfterAct);
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
            var command = new RemoveFigureCommand(controlUnit,
                new List<FigureBase>() { figure });
            command.Do();
            command.Undo();
            var figureAfterAct =
                controlUnit.GetDocument().GetFigures();

            // Assert
            Assert.IsNotEmpty(figureAfterAct);
        }

        [Test]
        public void ToStringTest()
        {
            // Arrange
            var figure = new CircleFigure();
            var controlUnit = new ControlUnitStub(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                new PropertyGrid());
            controlUnit.GetDocument().AddFigure(figure);

            // Act
            var command = new RemoveFigureCommand(controlUnit,
                new List<FigureBase>() { figure });

            // Assert
            Assert.IsTrue(command.ToString().Length > 0);
        }

        [Test]
        public void GetHashTest()
        {
            // Arrange
            var figure = new CircleFigure();
            var controlUnit = new ControlUnitStub(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                new PropertyGrid());
            controlUnit.GetDocument().AddFigure(figure);

            // Act
            var command = new RemoveFigureCommand(controlUnit,
                new List<FigureBase>() { figure });

            // Assert
            Assert.AreNotEqual(0, command.GetHashCode());
        }
    }

}
