using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NUnit.Framework;
using PolyLine;
using SDK;
using VectorEditorProject.Core;
using VectorEditorProject.Core.States;
using VectorEditorProject.Forms;
using VectorEditorTest.Stubs;

namespace VectorEditorTest
{
    [TestFixture]
    class FigureEditingStateTest
    {
        [Test]
        public void ConstructorTest()
        {
            // Arrange
            var figure = new PolyLineFigure();
            figure.PointsSettings.AddPoint(new PointF(10, 10));
            figure.PointsSettings.AddPoint(new PointF(20, 20));
            figure.PointsSettings.AddPoint(new PointF(30, 30));
            var controlUnit = new ControlUnit(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                new PropertyGrid());
            var editContext = new EditContext(controlUnit);
            controlUnit.EditContext = editContext;
            controlUnit.GetDocument().AddFigure(figure);
            editContext.SetSelectedFigures(new List<FigureBase>() { figure });

            // Act
            var state = new FigureEditingState(controlUnit, editContext);

            // Assert
            Assert.IsNotNull(state);
        }

        [Test]
        public void DrawTest()
        {
            // Arragne
            var figure = new PolyLineFigure();
            figure.PointsSettings.AddPoint(new PointF(10, 10));
            figure.PointsSettings.AddPoint(new PointF(20, 20));
            figure.PointsSettings.AddPoint(new PointF(30, 30));
            var controlUnit = new ControlUnit(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                new PropertyGrid());
            var editContext = new EditContext(controlUnit);
            controlUnit.EditContext = editContext;
            controlUnit.GetDocument().AddFigure(figure);
            editContext.SetSelectedFigures(new List<FigureBase>() { figure });
            var state = new FigureEditingStateStub(controlUnit, editContext);
            Bitmap bitmap = new Bitmap(100, 100);

            // Act 
            state.IsLeftTopMarkerHovered = true;
            state.IsRightBottomMarkerHovered = true;
            state.PointsHovered[0] = true;
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
            // Arrange
            var figure = new PolyLineFigure();
            figure.PointsSettings.AddPoint(new PointF(10, 10));
            figure.PointsSettings.AddPoint(new PointF(20, 20));
            figure.PointsSettings.AddPoint(new PointF(30, 30));
            var controlUnit = new ControlUnit(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                new PropertyGrid());
            var editContext = new EditContext(controlUnit);
            controlUnit.EditContext = editContext;
            controlUnit.GetDocument().AddFigure(figure);
            editContext.SetSelectedFigures(new List<FigureBase>() { figure });
            var state = new FigureEditingStateStub(controlUnit, editContext);

            // Act
            state.SelectionRectangle = new Rectangle(0, 0, 10, 10);
            state.MouseDown(this,
                new MouseEventArgs(MouseButtons.Left, 1, 2, 3, 4));

            // Assert
            Assert.Pass();
        }

        [Test]
        public void MouseMoveTest()
        {
            // Arrange
            var figure = new PolyLineFigure();
            figure.PointsSettings.AddPoint(new PointF(10, 10));
            figure.PointsSettings.AddPoint(new PointF(20, 20));
            figure.PointsSettings.AddPoint(new PointF(30, 30));
            var controlUnit = new ControlUnit(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                new PropertyGrid());
            var editContext = new EditContext(controlUnit);
            controlUnit.EditContext = editContext;
            controlUnit.GetDocument().AddFigure(figure);
            editContext.SetSelectedFigures(new List<FigureBase>() { figure });
            var state = new FigureEditingStateStub(controlUnit, editContext);

            // Act
            state.SelectionRectangle = new Rectangle(10, 10, 30, 30);
            state.IsFigureMoving = true;
            state.MouseMove(this,
                new MouseEventArgs(MouseButtons.Left, 1, 2, 3, 4));

            state.IsMousePressed = true;
            state.ActivePoint = 0;
            state.MouseMove(this,
                new MouseEventArgs(MouseButtons.Left, 1, 2, 3, 4));
            state.IsLeftTopMarkerHovered = true;
            state.MouseMove(this,
                new MouseEventArgs(MouseButtons.Left, 1, 2, 3, 4));
            state.ActivePoint = -1;
            state.IsLeftTopMarkerHovered = false;
            state.MouseMove(this,
                new MouseEventArgs(MouseButtons.Left, 1, 2, 3, 4));

            // Assert
            Assert.Pass();
        }

        [Test]
        public void MouseUpTest()
        {
            // Arrange
            var figure = new PolyLineFigure();
            figure.PointsSettings.AddPoint(new PointF(10, 10));
            figure.PointsSettings.AddPoint(new PointF(20, 20));
            figure.PointsSettings.AddPoint(new PointF(30, 30));
            var controlUnit = new ControlUnitStub(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                new PropertyGrid());
            var editContext = new EditContext(controlUnit);
            controlUnit.EditContext = editContext;
            controlUnit.GetDocument().AddFigure(figure);
            editContext.SetSelectedFigures(new List<FigureBase>() { figure });
            var state = new FigureEditingStateStub(controlUnit, editContext);

            // Act
            state.Backup.Add(figure);
            state.MouseUp(this,
                new MouseEventArgs(MouseButtons.Left, 1, 2, 3, 4));

            // Assert
            Assert.IsNotEmpty(controlUnit.Commands);
        }
    }
}
