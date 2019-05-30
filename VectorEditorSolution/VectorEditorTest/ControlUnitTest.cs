using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Circle;
using Ellipse;
using Line;
using Moq;
using NUnit.Framework;
using Polygon;
using PolyLine;
using VectorEditorProject.Core;
using VectorEditorProject.Core.Commands;
using VectorEditorProject.Forms;
using VectorEditorTest.Stubs;

namespace VectorEditorTest
{
    [TestFixture]
    class ControlUnitTest
    {
        [Test]
        public void ConstructorTest()
        {
            // Arrange
            var controlUnit = new ControlUnitStub(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                new PropertyGrid());

            // Assert
            // Controls
            Assert.IsNotNull(controlUnit.Canvas);
            Assert.IsNotNull(controlUnit.PropertyGrid);
            Assert.IsNotNull(controlUnit.FigureSettingsControl);
            Assert.IsNotNull(controlUnit.ToolsControl);

            Assert.IsNotNull(controlUnit.Commands);
            Assert.IsTrue(controlUnit.ViewUpdateDictionary.Count > 0);
        }

        [Test]
        public void EditContextPropertyTest()
        {
            // Arrange
            var controlUnit = new ControlUnitStub(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                new PropertyGrid());
            var editContext = new Mock<IEditContext>();

            // Act
            controlUnit.EditContext = editContext.Object;
            
            // Assert
            Assert.IsNotNull(controlUnit.EditContext);
            Assert.AreEqual(editContext.Object, controlUnit.EditContext);
        }

        [Test]
        public void GetActiveFillSettingsTest()
        {
            // Arrange
            var controlUnit = new ControlUnitStub(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                new PropertyGrid());

            // Act
            var someFillSettings = controlUnit.GetActiveFillSettings();

            // Assert
            Assert.IsNotNull(someFillSettings);
        }

        [Test]
        public void GetActiveLineSettingsTest()
        {
            // Arrange
            var controlUnit = new ControlUnitStub(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                new PropertyGrid());

            // Act
            var someLineSettings = controlUnit.GetActiveLineSettings();

            // Assert
            Assert.IsNotNull(someLineSettings);
        }

        [Test]
        public void GetActiveFigureTypeTest()
        {
            // Arrange
            var controlUnit = new ControlUnitStub(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                new PropertyGrid());

            // Act
            var someFigureType = controlUnit.GetActiveFigureType();

            // Assert
            Assert.IsTrue(someFigureType.Length > 0);
        }

        [Test]
        public void CanvasUpdateTest()
        {
            // Arrange
            // Act
            // Assert
            // Проблема с проверкой вызова invalidate у контрола
        }

        [Test]
        public void CopyTest()
        {
            // Arrange
            var circle = new CircleFigure();
            var controlUnit = new ControlUnitStub(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                new PropertyGrid());
            var editContext = new EditContext(controlUnit);
            controlUnit.EditContext = editContext;

            // Act
            var shouldBeZero = controlUnit.Clipboard.Count;
            controlUnit.GetDocument().AddFigure(circle);
            editContext.SetSelectedFigures(circle.guid);
            controlUnit.Copy();
            var shouldBeOne = controlUnit.Clipboard.Count;

            // Assert
            Assert.AreEqual(shouldBeZero, 0);
            Assert.AreEqual(shouldBeOne, 1);
            Assert.AreEqual(circle.guid, controlUnit.Clipboard[0].guid);
        }

        [Test]
        public void DeleteTest()
        {
            // Arrange
            var circle = new CircleFigure();
            var controlUnit = new ControlUnitStub(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                new PropertyGrid());
            var editContext = new EditContext(controlUnit);
            controlUnit.EditContext = editContext;

            // Act
            var shouldBeZero = controlUnit.GetDocument().GetFigures().Count;
            controlUnit.GetDocument().AddFigure(circle);
            var shouldBeOne = controlUnit.GetDocument().GetFigures().Count;
            editContext.SetSelectedFigures(circle.guid);
            controlUnit.Delete();
            var shouldBeZero2 = controlUnit.GetDocument().GetFigures().Count;

            // Assert
            Assert.AreEqual(shouldBeZero, 0);
            Assert.AreEqual(shouldBeOne, 1);
            Assert.AreEqual(shouldBeZero2, 0);
        }

        [Test]
        public void SerializeDeserializeTest()
        {
            // Arrange
            string path = @"D:\TestVector.pika";

            // Delete the file if it exists.
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            // SERIALIZE TEST //
            using (var stream = File.Create(path))
            {
                var ellipse = new EllipseFigure();
                ellipse.PointsSettings.AddPoint(new PointF(10, 10));
                ellipse.PointsSettings.AddPoint(new PointF(100, 100));
                var controlUnit = new ControlUnitStub(new PictureBox(),
                    new FigureSettingsControl(), new ToolsControl(),
                    new PropertyGrid());
                var editContext = new EditContext(controlUnit);
                controlUnit.EditContext = editContext;
                // Act
                var addFigureCommand =
                    CommandFactory.CreateAddFigureCommand(controlUnit, ellipse);
                controlUnit.StoreCommand(addFigureCommand);
                controlUnit.Do();
                controlUnit.Serialize(stream);
            }

            int shouldBeOne = 0;

            // DESERIALIZE TEST //
            using (var stream = File.Open(path, FileMode.Open))
            {
                var controlUnit = new ControlUnitStub(new PictureBox(),
                    new FigureSettingsControl(), new ToolsControl(),
                    new PropertyGrid());
                var editContext = new EditContext(controlUnit);
                controlUnit.EditContext = editContext;
                controlUnit.Deserialize(stream);
                shouldBeOne = controlUnit.GetDocument().GetFigures().Count;
            }

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            // Assert
            Assert.AreEqual(1, shouldBeOne);
        }


        [Test]
        public void DoTest()
        {
            // Arrange
            var controlUnit = new ControlUnitStub(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                new PropertyGrid());
            var editContext = new EditContext(controlUnit);
            controlUnit.EditContext = editContext;

            // Act
            // Assert
            Assert.DoesNotThrow(() => controlUnit.Do());
        }

        [Test]
        public void GetDocumentTest()
        {
            // Arrange
            var controlUnit = new ControlUnitStub(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                new PropertyGrid());
            var editContext = new EditContext(controlUnit);
            controlUnit.EditContext = editContext;

            // Act
            // Assert
            Assert.IsNotNull(controlUnit.GetDocument());
        }

        [Test]
        public void IsFileHaveUnsavedChangesTest()
        {
            // Arrange
            var figure = new PolygonFigure();
            figure.PointsSettings.AddPoint(new PointF(10, 10));
            figure.PointsSettings.AddPoint(new PointF(12, 33));
            figure.PointsSettings.AddPoint(new PointF(14, 0));
            var controlUnit = new ControlUnitStub(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                new PropertyGrid());
            var editContext = new EditContext(controlUnit);
            controlUnit.EditContext = editContext;

            // Act
            var shouldBeFalse = controlUnit.IsFileHaveUnsavedChanges();
            var shouldBeZero = controlUnit.LastSavedHash;
            controlUnit.StoreCommand(
                CommandFactory.CreateAddFigureCommand(controlUnit, figure));
            var shouldBeTrue = controlUnit.IsFileHaveUnsavedChanges();

            // Assert
            Assert.AreEqual(false, shouldBeFalse);
            Assert.AreEqual(true, shouldBeTrue);
            Assert.AreEqual(0, shouldBeZero);
        }

        [Test]
        public void PasteTest()
        {
            // Arrange
            var figure = new LineFigure();
            figure.PointsSettings.AddPoint(new PointF(10, 10));
            figure.PointsSettings.AddPoint(new PointF(12, 33));
            var controlUnit = new ControlUnitStub(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                new PropertyGrid());
            var editContext = new EditContext(controlUnit);
            controlUnit.EditContext = editContext;

            // Act
            Assert.DoesNotThrow(() => controlUnit.Paste());
            controlUnit.Clipboard.Add(figure);
            var shouldBeZero = controlUnit.GetDocument().GetFigures().Count;
            controlUnit.Paste();
            var shouldBeOne = controlUnit.GetDocument().GetFigures().Count;
            controlUnit.Paste();
            var shouldBeTwo = controlUnit.GetDocument().GetFigures().Count;

            // Assert
            Assert.AreEqual(0, shouldBeZero);
            Assert.AreEqual(1, shouldBeOne);
            Assert.AreEqual(2, shouldBeTwo);
        }

        [Test]
        public void PropertyGridPropertyValueChangedTest()
        {
            // Arrange
            var figure = new CircleFigure();
            figure.PointsSettings.AddPoint(new PointF(10, 10));
            figure.PointsSettings.AddPoint(new PointF(12, 33));
            var propertyGridStub = new PropertyGridStub();
            var controlUnit = new ControlUnitStub(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                propertyGridStub);
            var editContext = new EditContext(controlUnit);
            controlUnit.EditContext = editContext;

            // Act
            controlUnit.PropertyGrid.SelectedObject = figure;
            propertyGridStub.FakePropertyChange();
            controlUnit.PropertyGrid.SelectedObject = null;
            propertyGridStub.FakePropertyChange();
            controlUnit.GetDocument().AddFigure(figure);
            controlUnit.PropertyGrid.SelectedObject = figure;
            propertyGridStub.FakePropertyChange();

            // Assert
            Assert.Pass();
        }

        [Test]
        public void PropertyGridSelectedObjectsChangedTest()
        {
            // Arrange 
            var figure = new LineFigure();
            figure.PointsSettings.AddPoint(new PointF(10, 10));
            figure.PointsSettings.AddPoint(new PointF(12, 33));
            var controlUnit = new ControlUnitStub(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                new PropertyGrid());
            var editContext = new EditContext(controlUnit);
            controlUnit.EditContext = editContext;

            // Act
            controlUnit.PropertyGrid.SelectedObject = figure;
            controlUnit.PropertyGrid.SelectedObject = null;
            controlUnit.GetDocument().AddFigure(figure);
            controlUnit.PropertyGrid.SelectedObject = figure;

            // Assert
            Assert.Pass();
        }

        [Test]
        public void UpdatePropertyGridTest()
        {
            // Arrange
            var figure = new PolyLineFigure();
            figure.PointsSettings.AddPoint(new PointF(10, 10));
            figure.PointsSettings.AddPoint(new PointF(12, 33));
            var controlUnit = new ControlUnitStub(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                new PropertyGrid());
            var editContext = new EditContext(controlUnit);
            controlUnit.EditContext = editContext;

            // Act
            controlUnit.PropertyGrid.SelectedObject = null;
            controlUnit.UpdatePropertyGrid();
            controlUnit.PropertyGrid.SelectedObject = figure;
            controlUnit.UpdatePropertyGrid();

            // Assert
            Assert.Pass();
        }

        [Test]
        public void ResetTest()
        {
            // Arrange
            var figure = new PolyLineFigure();
            figure.PointsSettings.AddPoint(new PointF(10, 10));
            figure.PointsSettings.AddPoint(new PointF(12, 33));
            var controlUnit = new ControlUnitStub(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                new PropertyGrid());
            var editContext = new EditContext(controlUnit);
            controlUnit.EditContext = editContext;

            // Act
            var shouldBeZero = controlUnit.Commands.Count;
            var shouldBeZero2 = controlUnit.CurrentCommand;
            controlUnit.StoreCommand(
                CommandFactory.CreateAddFigureCommand(controlUnit, figure));
            var shouldBeOne = controlUnit.Commands.Count;
            controlUnit.Do();
            var shouldBeOne2 = controlUnit.CurrentCommand;
            controlUnit.Reset();

            // Assert
            Assert.AreEqual(0, shouldBeZero);
            Assert.AreEqual(0, shouldBeZero2);
            Assert.AreEqual(1, shouldBeOne);
            Assert.AreEqual(1, shouldBeOne2);
            Assert.AreEqual(0, controlUnit.Commands.Count);
            Assert.AreEqual(0, controlUnit.CurrentCommand);
        }

        [Test]
        public void UpdateStateTest()
        {
            // Arrange
            var controlUnit = new ControlUnitStub(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                new PropertyGrid());
            var editContextMock = new Mock<IEditContext>();
            controlUnit.EditContext = editContextMock.Object;

            // Act
            controlUnit.UpdateState();

            // Assert
            editContextMock.Verify(x => x.UpdateState(), Times.Once);
        }

        [Test]
        public void StoreCommandTest()
        {
            // Arrange
            var controlUnit = new ControlUnitStub(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                new PropertyGrid());

            // Act
            controlUnit.StoreCommand(
                CommandFactory.CreateClearDocumentCommand(controlUnit));
            controlUnit.StoreCommand(
                CommandFactory.CreateClearDocumentCommand(controlUnit));
            controlUnit.StoreCommand(
                CommandFactory.CreateClearDocumentCommand(controlUnit));

            // Assert
            Assert.AreEqual(1, controlUnit.Commands.Count);
            Assert.AreEqual(0, controlUnit.CurrentCommand);
        }

        [Test]
        public void UndoTest()
        {
            // Arrange
            var controlUnit = new ControlUnitStub(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                new PropertyGrid());
            var editContext = new EditContext(controlUnit);
            controlUnit.EditContext = editContext;

            // Act
            controlUnit.StoreCommand(
                CommandFactory.CreateClearDocumentCommand(controlUnit));

            // Assert
            Assert.DoesNotThrow(() =>
            {
                controlUnit.Undo();
                controlUnit.Do();
                controlUnit.Undo();
            });
        }
    }
}
