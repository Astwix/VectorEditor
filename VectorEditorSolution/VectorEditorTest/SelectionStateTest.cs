using System.Drawing;
using System.Windows.Forms;
using Circle;
using Moq;
using NUnit.Framework;
using VectorEditorProject.Core;
using VectorEditorProject.Forms;
using VectorEditorTest.Stubs;

namespace VectorEditorTest
{
    [TestFixture]
    class SelectionStateTest
    {
        [Test]
        public void ConstructorTest()
        {
            // Arragne
            var controlUnit = new Mock<IControlUnit>();
            var editContext = new Mock<IEditContext>();

            // Act
            var state =
                new SelectionStateStub(controlUnit.Object, editContext.Object);

            // Assert
            Assert.IsNotNull(state.ControlUnit);
            Assert.IsNotNull(state.EditContext);
        }

        [Test]
        public void DrawTest()
        {
            // Arragne
            var controlUnit = new Mock<IControlUnit>();
            var editContext = new Mock<IEditContext>();
            var state = new SelectionStateStub(controlUnit.Object,
                editContext.Object);
            Bitmap bitmap = new Bitmap(100, 100);

            // Act 
            state.SelectionRectangle = new Rectangle(10, 10, 20, 20);
            state.IsMousePressed = true;
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
            // Arragne
            var controlUnit = new Mock<IControlUnit>();
            var editContext = new Mock<IEditContext>();
            var state = new SelectionStateStub(controlUnit.Object, editContext.Object);

            // Act
            state.MouseDown(this,
                new MouseEventArgs(MouseButtons.Left, 1, 2, 3, 4));

            // Assert
            Assert.IsTrue(state.IsMousePressed);
            Assert.AreEqual(2, state.BeginX);
            Assert.AreEqual(3, state.BeginY);
            Assert.AreEqual(2, state.SelectionRectangle.X);
            Assert.AreEqual(3, state.SelectionRectangle.Y);
        }

        [Test]
        public void MouseMoveTest()
        {
            // Arragne
            var controlUnit = new Mock<IControlUnit>();
            var editContext = new Mock<IEditContext>();
            var state = new SelectionStateStub(controlUnit.Object, editContext.Object);
            
            // Act
            state.BeginX = 5;
            state.BeginY = 5;
            state.SelectionRectangle = new Rectangle(0, 0, 0, 0);

            state.MouseMove(this,
                new MouseEventArgs(MouseButtons.Left, 1, 20, 30, 1));

            // Assert
            Assert.AreNotEqual(0, state.SelectionRectangle.X);
            Assert.AreNotEqual(0, state.SelectionRectangle.Y);
            Assert.AreNotEqual(0, state.SelectionRectangle.Width);
            Assert.AreNotEqual(0, state.SelectionRectangle.Height);
            controlUnit.Verify(x => x.UpdateCanvas(), Times.Once);
        }

        [Test]
        public void MouseUpTest()
        {
            // Arragne
            var controlUnit = new ControlUnit(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                new PropertyGrid());
            var editContext = new EditContextStub(controlUnit);
            controlUnit.EditContext = editContext;
            var figure = new CircleFigure();
            figure.PointsSettings.AddPoint(new PointF(1, 1));
            figure.PointsSettings.AddPoint(new PointF(2, 2));
            controlUnit.GetDocument().AddFigure(figure);
            var state = new SelectionStateStub(controlUnit, editContext);

            // Act
            state.SelectionRectangle = new Rectangle(0, 0, 1, 1);

            // Assert
            state.IsMousePressed = false;
            state.MouseUp(this,
                new MouseEventArgs(MouseButtons.Left, 1, 20, 30, 1));
            state.IsMousePressed = true;
            state.MouseUp(this,
                new MouseEventArgs(MouseButtons.Left, 1, 20, 30, 1));
            Assert.IsNotEmpty(editContext.GetSelectedFigures());
            state.SelectionRectangle = new Rectangle(0, 0, 10, 10);
            state.IsMousePressed = true;
            state.MouseUp(this,
                new MouseEventArgs(MouseButtons.Left, 1, 20, 30, 1));
            Assert.IsNotEmpty(editContext.GetSelectedFigures());
        }
    }
}
