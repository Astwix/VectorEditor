using System.Drawing;
using System.Windows.Forms;
using Circle;
using NUnit.Framework;
using Polygon;
using VectorEditorProject.Core;
using VectorEditorProject.Forms;
using VectorEditorTest.Stubs;

namespace VectorEditorTest
{
    [TestFixture]
    class AddPointStateTest
    {
        [Test]
        public void ConstructorTest()
        {
            // Arrange
            var figure = new CircleFigure();
            figure.PointsSettings.AddPoint(new PointF(10, 10));
            figure.PointsSettings.AddPoint(new PointF(15, 15));
            var controlUnit = new ControlUnit(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                new PropertyGrid());
            controlUnit.GetDocument().AddFigure(figure);
            var editContext = new EditContext(controlUnit);
            controlUnit.EditContext = editContext;

            // Act
            var state =
                new AddPointStateStub(controlUnit, editContext);
            editContext.SetActiveFigure(figure);
            state =
                new AddPointStateStub(controlUnit, editContext);
            // Assert
            Assert.IsNotNull(state.EditContext);
            Assert.IsNotNull(state.ControlUnit);
        }

        [Test]
        public void DrawTest()
        {
            // Arrange
            var figure = new PolygonFigure();
            figure.PointsSettings.AddPoint(new PointF(0, 0));
            figure.PointsSettings.AddPoint(new PointF(20, 19));
            figure.FillSettings.Color = Color.Red;
            var controlUnit = new ControlUnit(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                new PropertyGrid());
            controlUnit.GetDocument().AddFigure(figure);
            var editContext = new EditContext(controlUnit);
            controlUnit.EditContext = editContext;
            var bitmap = new Bitmap(100, 100);

            // Act
            editContext.SetActiveFigure(figure);
            var state =
                new AddPointStateStub(controlUnit, editContext);
            var bitmapBeforeDraw = (Bitmap)bitmap.Clone();
            state.Draw(Graphics.FromImage(bitmap));
            var bitmapAfterDraw = (Bitmap)bitmap.Clone();

            // Assert
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    var pixelBeforeDraw = bitmapBeforeDraw.GetPixel(i, j);
                    var pixelAfterDraw = bitmapAfterDraw.GetPixel(i, j);
                    if (!pixelBeforeDraw.Equals(pixelAfterDraw))
                    {
                        Assert.Pass();
                    }
                }
            }
            Assert.Fail();
        }

        [Test]
        public void MouseDownTest()
        {
            // Arrange
            var figure = new PolygonFigure();
            figure.PointsSettings.AddPoint(new PointF(10, 10));
            figure.PointsSettings.AddPoint(new PointF(15, 15));
            var controlUnit = new ControlUnit(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                new PropertyGrid());
            controlUnit.GetDocument().AddFigure(figure);
            var editContext = new EditContext(controlUnit);
            controlUnit.EditContext = editContext;

            // Act
            var state =
                new AddPointStateStub(controlUnit, editContext);
            state.MouseDown(this,
                new MouseEventArgs(MouseButtons.Left, 1, 2, 3, 4));
            state.IsMousePressed = false;
            editContext.SetActiveFigure(figure);
            state =
                new AddPointStateStub(controlUnit, editContext);

            state.MouseDown(this,
                new MouseEventArgs(MouseButtons.Left, 1, 2, 3, 4));

            // Assert
            Assert.IsTrue(state.IsMousePressed);
            Assert.IsTrue(figure.PointsSettings.GetPoints().Count > 2);
        }

        [Test]
        public void MouseUpTest()
        {
            // Arrange
            var figure = new CircleFigure();
            figure.PointsSettings.AddPoint(new PointF(10, 10));
            var controlUnit = new ControlUnit(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                new PropertyGrid());
            controlUnit.GetDocument().AddFigure(figure);
            var editContext = new EditContext(controlUnit);
            controlUnit.EditContext = editContext;

            // Act
            var state =
                new AddPointStateStub(controlUnit, editContext);
            state.MouseUp(this,
                new MouseEventArgs(MouseButtons.Left, 1, 2, 3, 4));
            state.IsMousePressed = true;
            editContext.SetActiveFigure(figure);
            state =
                new AddPointStateStub(controlUnit, editContext);

            state.MouseUp(this,
                new MouseEventArgs(MouseButtons.Left, 1, 2, 3, 4));
            
            // Assert
            Assert.IsFalse(state.IsMousePressed);
            Assert.IsTrue(figure.PointsSettings.GetPoints().Count > 1);
        }

        [Test]
        public void MouseMoveTest()
        {
            // Arrange
            var figure = new CircleFigure();
            figure.PointsSettings.AddPoint(new PointF(10, 10));
            var controlUnit = new ControlUnit(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                new PropertyGrid());
            controlUnit.GetDocument().AddFigure(figure);
            var editContext = new EditContext(controlUnit);
            controlUnit.EditContext = editContext;

            // Act
            var state =
                new AddPointStateStub(controlUnit, editContext);
            state.MouseMove(this,
                new MouseEventArgs(MouseButtons.Left, 1, 2, 3, 4));
            state.IsMousePressed = true;
            editContext.SetActiveFigure(figure);
            state =
                new AddPointStateStub(controlUnit, editContext);

            state.MouseMove(this,
                new MouseEventArgs(MouseButtons.Left, 1, 2, 3, 4));
            
            // Assert
            Assert.IsTrue(state.IsMousePressed);
            Assert.IsTrue(figure.PointsSettings.GetPoints().Count > 1);
        }
    }
}
