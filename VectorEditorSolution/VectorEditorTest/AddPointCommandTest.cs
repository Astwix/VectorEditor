using System;
using System.Collections.Generic;
using System.Drawing;
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
    class AddPointCommandTest
    {
        [Test]
        public void ConstructorTest()
        {
            // Arrange
            var controlUnitMock = new Mock<IControlUnit>();
            var figureMock = new Mock<FigureBase>();

            // Act
            var command = new AddPointCommandStub(figureMock.Object,
                new PointF(1, 5), controlUnitMock.Object);

            // Assert
            Assert.IsNotNull(command.ControlUnit);
            Assert.AreEqual(new PointF(1, 5), command.Point);
            Assert.AreEqual(figureMock.Object.guid, command.FigureGuid);
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
            var command =
                new AddPointCommand(figure, new PointF(10, 10), controlUnit);
            command.Do();
            var figureAfterAct =
                controlUnit.GetDocument().GetFigure(figure.guid);

            // Assert
            Assert.AreEqual(1, figureAfterAct.PointsSettings.GetPoints().Count);
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
            var command =
                new AddPointCommand(figure, new PointF(10, 10), controlUnit);
            command.Do();
            command.Undo();
            var figureAfterAct =
                controlUnit.GetDocument().GetFigure(figure.guid);

            // Assert
            Assert.AreEqual(0, figureAfterAct.PointsSettings.GetPoints().Count);
        }

        [Test]
        public void ToStringTest()
        {
            // Arrange
            var controlUnitMock = new Mock<IControlUnit>();
            var figureMock = new Mock<FigureBase>();

            // Act
            var command = new AddPointCommandStub(figureMock.Object,
                new PointF(1, 5), controlUnitMock.Object);

            // Assert
            Assert.IsTrue(command.ToString().Length > 0);
        }

        [Test]
        public void GetHashTest()
        {
            // Arrange
            var controlUnitMock = new Mock<IControlUnit>();
            var figureMock = new Mock<FigureBase>();

            // Act
            var command = new AddPointCommandStub(figureMock.Object,
                new PointF(1, 5), controlUnitMock.Object);

            // Assert
            Assert.AreNotEqual(0, command.GetHashCode());
        }
    }

}
