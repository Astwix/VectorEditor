using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Circle;
using NUnit.Framework;
using SDK;
using VectorEditorProject.Forms;
using VectorEditorTest.Stubs;

namespace VectorEditorTest
{
    [TestFixture]
    class FiguresChangingCommandTest
    {
        [Test]
        public void Constructor1Test()
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
            var command = new FiguresChangingCommandStub(controlUnit, figure);

            // Assert
            Assert.IsNotNull(command.ControlUnit);
            Assert.IsNotEmpty(command.NewValues);
            Assert.IsNotEmpty(command.OldValues);
        }

        [Test]
        public void Constructor2Test()
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
            var command = new FiguresChangingCommandStub(controlUnit,
                new List<FigureBase>() { figure });

            // Assert
            Assert.IsNotNull(command.ControlUnit);
            Assert.IsNotEmpty(command.NewValues);
            Assert.IsNotEmpty(command.OldValues);
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
            var newValues = controlUnit.GetDocument()
                .GetFigure(figure.guid) as FilledFigureBase;
            newValues.FillSettings.Color = Color.BlueViolet;
            var command = new FiguresChangingCommandStub(controlUnit,
                new List<FigureBase>() { figure });
            command.Do();
            var actualColor =
                ((controlUnit.GetDocument().GetFigure(figure.guid)) as
                    FilledFigureBase).FillSettings.Color;

            // Assert
            Assert.AreEqual(Color.BlueViolet, actualColor);
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
            var newValues = controlUnit.GetDocument()
                .GetFigure(figure.guid) as FilledFigureBase;
            newValues.FillSettings.Color = Color.BlueViolet;
            var command = new FiguresChangingCommandStub(controlUnit,
                new List<FigureBase>() { figure });
            newValues.FillSettings.Color = Color.Firebrick;
            command.Do();
            command.Undo();
            var actualColor =
                ((controlUnit.GetDocument().GetFigure(figure.guid)) as
                    FilledFigureBase).FillSettings.Color;

            // Assert
            Assert.AreNotEqual(Color.Firebrick, actualColor);
        }

        [Test]
        public void ToStringTest()
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
            var command = new FiguresChangingCommandStub(controlUnit,
                new List<FigureBase>() {figure});

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
            var command = new FiguresChangingCommandStub(controlUnit,
                new List<FigureBase>() { figure });

            // Assert
            Assert.AreNotEqual(0, command.GetHashCode());
        }
    }
}
