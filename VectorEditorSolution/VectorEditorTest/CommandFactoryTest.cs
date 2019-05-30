using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Circle;
using NUnit.Framework;
using SDK;
using VectorEditorProject.Core;
using VectorEditorProject.Core.Commands;
using VectorEditorProject.Forms;

namespace VectorEditorTest
{
    [TestFixture]
    class CommandFactoryTest
    {
        [Test]
        public void CreateAddFigureCommandTest()
        {
            // Arrange
            var controlUnit = new ControlUnit(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                new PropertyGrid());
            var figure = new CircleFigure();
            figure.PointsSettings.AddPoint(new PointF(10, 11));
            figure.PointsSettings.AddPoint(new PointF(102, 113));

            // Act
            var command1 =
                CommandFactory.CreateAddFigureCommand(controlUnit, figure);

            var command2 =
                CommandFactory.CreateAddFigureCommand(controlUnit,
                    new List<FigureBase>() { figure });

            // Assert
            Assert.IsNotNull(command1);
            Assert.IsNotNull(command2);
            Assert.IsInstanceOf<AddFigureCommand>(command1);
            Assert.IsInstanceOf<AddFigureCommand>(command2);
        }

        [Test]
        public void CreateAddPointCommandTest()
        {
            // Arrange
            var controlUnit = new ControlUnit(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                new PropertyGrid());
            var figure = new CircleFigure();
            figure.PointsSettings.AddPoint(new PointF(10, 11));

            // Act
            var command1 =
                CommandFactory.CreateAddPointCommand(figure, new PointF(10, 22),
                    controlUnit);

            // Assert
            Assert.IsNotNull(command1);
            Assert.IsInstanceOf<AddPointCommand>(command1);
        }

        [Test]
        public void CreateChangingDocumentOptionsCommandTest()
        {
            // Arrange
            var controlUnit = new ControlUnit(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                new PropertyGrid());

            // Act
            var command1 =
                CommandFactory.CreateChangingDocumentOptionsCommand(
                    controlUnit,
                    new Document("Test1", Color.Aqua,
                        new Size(100, 100)));

            // Assert
            Assert.IsNotNull(command1);
            Assert.IsInstanceOf<ChangingDocumentOptionsCommand>(command1);
        }

        [Test]
        public void CreateFiguresChangingCommandTest()
        {
            // Arrange
            var controlUnit = new ControlUnit(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                new PropertyGrid());
            var figure = new CircleFigure();
            figure.PointsSettings.AddPoint(new PointF(10, 11));
            figure.PointsSettings.AddPoint(new PointF(102, 113));
            controlUnit.GetDocument().AddFigure(figure);

            // Act
            var command1 =
                CommandFactory.CreateFiguresChangingCommand(controlUnit,
                    figure);

            var command2 =
                CommandFactory.CreateFiguresChangingCommand(controlUnit,
                    new List<FigureBase>() { figure });

            // Assert
            Assert.IsNotNull(command1);
            Assert.IsNotNull(command2);
            Assert.IsInstanceOf<FiguresChangingCommand>(command1);
            Assert.IsInstanceOf<FiguresChangingCommand>(command2);
        }

        [Test]
        public void CreateClearDocumentCommandTest()
        {
            // Arrange
            var controlUnit = new ControlUnit(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                new PropertyGrid());

            // Act
            var command1 =
                CommandFactory.CreateClearDocumentCommand(controlUnit);

            // Assert
            Assert.IsNotNull(command1);
            Assert.IsInstanceOf<ClearDocumentCommand>(command1);
        }

        [Test]
        public void CreateRemoveFigureCommandTest()
        {
            // Arrange
            var controlUnit = new ControlUnit(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                new PropertyGrid());
            var figure = new CircleFigure();
            figure.PointsSettings.AddPoint(new PointF(10, 11));
            figure.PointsSettings.AddPoint(new PointF(102, 113));
            controlUnit.GetDocument().AddFigure(figure);

            // Act
            var command1 =
                CommandFactory.CreateRemoveFigureCommand(controlUnit,
                    new List<FigureBase>() { figure });
            var command2 =
                CommandFactory.CreateRemoveFigureCommand(controlUnit, figure);

            // Assert
            Assert.IsNotNull(command1);
            Assert.IsInstanceOf<RemoveFigureCommand>(command1);
            Assert.IsNotNull(command2);
            Assert.IsInstanceOf<RemoveFigureCommand>(command2);
        }

        [Test]
        public void MakeCommandOKAgainTest()
        {
            // Arrange
            var controlUnit = new ControlUnit(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                new PropertyGrid());
            var figure = new CircleFigure();
            figure.PointsSettings.AddPoint(new PointF(10, 11));
            figure.PointsSettings.AddPoint(new PointF(102, 113));
            controlUnit.GetDocument().AddFigure(figure);

            var alsoControlUnit = new ControlUnit(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                new PropertyGrid());

            // Act
            var command1 =
                CommandFactory.CreateAddFigureCommand(controlUnit, figure);
            var command2 =
                CommandFactory.CreateAddPointCommand(figure, new PointF(10, 22),
                    controlUnit);
            var command3 =
                CommandFactory.CreateChangingDocumentOptionsCommand(
                    controlUnit,
                    new Document("Test1", Color.Aqua,
                        new Size(100, 100)));
            var command4 =
                CommandFactory.CreateFiguresChangingCommand(controlUnit,
                    figure);
            var command5 =
                CommandFactory.CreateClearDocumentCommand(controlUnit);
            var command6 =
                CommandFactory.CreateRemoveFigureCommand(controlUnit,
                    new List<FigureBase>() { figure });
            CommandFactory.MakeCommandOKAgain(command1, alsoControlUnit);
            CommandFactory.MakeCommandOKAgain(command2, alsoControlUnit);
            CommandFactory.MakeCommandOKAgain(command3, alsoControlUnit);
            CommandFactory.MakeCommandOKAgain(command4, alsoControlUnit);
            CommandFactory.MakeCommandOKAgain(command5, alsoControlUnit);
            CommandFactory.MakeCommandOKAgain(command6, alsoControlUnit);

            // Assert
            Assert.AreSame(alsoControlUnit,
                (command1 as AddFigureCommand).ControlUnit);
            Assert.AreSame(alsoControlUnit,
                (command2 as AddPointCommand).ControlUnit);
            Assert.AreSame(alsoControlUnit,
                (command3 as ChangingDocumentOptionsCommand).ControlUnit);
            Assert.AreSame(alsoControlUnit,
                (command4 as FiguresChangingCommand).ControlUnit);
            Assert.AreSame(alsoControlUnit,
                (command5 as ClearDocumentCommand).ControlUnit);
            Assert.AreSame(alsoControlUnit,
                (command6 as RemoveFigureCommand).ControlUnit);
        }
    }
}
