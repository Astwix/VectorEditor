using System.Drawing;
using System.Windows.Forms;
using Circle;
using NUnit.Framework;
using VectorEditorProject.Core.Commands;
using VectorEditorProject.Forms;
using VectorEditorTest.Stubs;

namespace VectorEditorTest
{
    [TestFixture()]
    class ClearDocumentCommandTest
    {
        [Test]
        public void ConstructorTest()
        {
            // Arrange
            var controlUnit = new ControlUnitStub(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                new PropertyGrid());
            var figure = new CircleFigure();
            figure.PointsSettings.AddPoint(new PointF(10, 10));
            figure.PointsSettings.AddPoint(new PointF(12, 33));
            controlUnit.GetDocument().AddFigure(figure);

            // Act
            var command = new ClearDocumentCommandStub(controlUnit);

            // Assert
            Assert.IsNotNull(command.ControlUnit);
            Assert.IsNotEmpty(command.BackUpFigures);
        }

        [Test]
        public void DoTest()
        {
            // Arrange
            var controlUnit = new ControlUnitStub(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                new PropertyGrid());
            var figure = new CircleFigure();
            figure.PointsSettings.AddPoint(new PointF(10, 10));
            figure.PointsSettings.AddPoint(new PointF(12, 33));
            controlUnit.GetDocument().AddFigure(figure);

            // Act
            var command = new ClearDocumentCommandStub(controlUnit);
            command.Do();

            // Assert
            Assert.IsEmpty(controlUnit.GetDocument().GetFigures());
        }

        [Test]
        public void UndoTest()
        {
            // Arrange
            var controlUnit = new ControlUnitStub(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                new PropertyGrid());
            var figure = new CircleFigure();
            figure.PointsSettings.AddPoint(new PointF(10, 10));
            figure.PointsSettings.AddPoint(new PointF(12, 33));
            controlUnit.GetDocument().AddFigure(figure);

            // Act
            var command = new ClearDocumentCommandStub(controlUnit);
            command.Do();
            command.Undo();

            // Assert
            Assert.IsNotEmpty(controlUnit.GetDocument().GetFigures());
        }

        [Test]
        public void ToStringTest()
        {
            // Arrange
            var controlUnit = new ControlUnitStub(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                new PropertyGrid());

            // Act
            var command = new ClearDocumentCommand(controlUnit);

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
            var figure = new CircleFigure();
            figure.PointsSettings.AddPoint(new PointF(10, 10));
            figure.PointsSettings.AddPoint(new PointF(12, 33));
            controlUnit.GetDocument().AddFigure(figure);

            // Act
            var command = new ClearDocumentCommand(controlUnit);

            // Assert
            Assert.AreNotEqual(0, command.GetHashCode());
        }
    }
}
