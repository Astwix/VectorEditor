using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using SDK;
using VectorEditorProject.Core;
using VectorEditorProject.Core.States;
using VectorEditorProject.Forms;
using VectorEditorTest.Stubs;

namespace VectorEditorTest
{
    [TestFixture]
    public class EditContextTest
    {
        [Test]
        public void MouseCallsTest()
        {
            // Arrange 
            Mock<StateBase> state = new Mock<StateBase>();
            EditContextStub ec = new EditContextStub(
                new ControlUnit(new PictureBox(), new FigureSettingsControl(),
                    new ToolsControl(), new PropertyGrid()));
            ec.ActiveState = state.Object;
            MouseEventArgs testArgs = new MouseEventArgs(MouseButtons.Left, 1, 2, 3, 4);

            // Act 
            ec.MouseDown(this, testArgs);
            ec.MouseUp(this, testArgs);
            ec.MouseMove(this, testArgs);

            // Assert
            state.Verify(stateBase => stateBase.MouseDown(this, testArgs), Times.Once);
            state.Verify(stateBase => stateBase.MouseUp(this, testArgs), Times.Once);
            state.Verify(stateBase => stateBase.MouseMove(this, testArgs), Times.Once);
        }

        [Test]
        public void UpdateStateTest()
        {
            // Arrange 
            Mock<StateBase> state = new Mock<StateBase>();
            EditContextStub ec = new EditContextStub(
                new ControlUnit(new PictureBox(), new FigureSettingsControl(),
                    new ToolsControl(), new PropertyGrid()));
            ec.ActiveState = state.Object;

            // Act 
            ec.UpdateState();

            // Assert
            state.Verify(stateBase => stateBase.Update(), Times.Once);
        }

        [Test]
        public void DrawTest()
        {
            // Arrange 
            Mock<StateBase> state = new Mock<StateBase>();
            EditContextStub ec = new EditContextStub(
                new ControlUnit(new PictureBox(), new FigureSettingsControl(),
                    new ToolsControl(), new PropertyGrid()));
            ec.ActiveState = state.Object;
            
            // Act 
            ec.Draw(new Control().CreateGraphics());

            // Assert
            state.Verify(stateBase => stateBase.Draw(It.IsAny<Graphics>()), Times.Once);
        }

        [Test]
        public void ConstructorTest()
        {
            // Arrange 
            EditContextStub ec = new EditContextStub(
                new ControlUnit(new PictureBox(), new FigureSettingsControl(),
                    new ToolsControl(), new PropertyGrid()));

            // Act 
            // Assert
            Assert.IsNotNull(ec.ControlUnit);
            Assert.IsNotNull(ec.ActiveState);
        }

        [Test]
        public void SetActiveFigureTest()
        {
            // Arrange 
            var controlUnit = new ControlUnit(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                new PropertyGrid());
            var editContext = new EditContextStub(controlUnit);
            Mock<FigureBase> mock = new Mock<FigureBase>();

            // Act
            editContext.SetActiveFigure(mock.Object);

            // Assert
            Assert.AreEqual(editContext.ActiveFigureGuid, mock.Object.guid);
        }

        [Test]
        public void GetActiveFigureTest1()
        {
            // Arrange 
            var controlUnit = new ControlUnit(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                new PropertyGrid());
            Mock<FigureBase> mock = new Mock<FigureBase>();
            controlUnit.GetDocument().AddFigure(mock.Object);
            var editContext = new EditContext(controlUnit);

            // Act 
            editContext.SetActiveFigure(mock.Object);

            // Assert
            Assert.AreEqual(mock.Object, editContext.GetActiveFigure());
        }

        [Test]
        public void GetActiveFigureTest2()
        {
            // Arrange 
            var controlUnit = new ControlUnit(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                new PropertyGrid());
            var editContext = new EditContext(controlUnit);

            // Act 
            // Assert
            Assert.IsNull(editContext.GetActiveFigure());
        }

        private static Array AllStates()
        {
            return Enum.GetValues(typeof(States));
        }
        [Test,
         TestCaseSource(nameof(AllStates)),
         TestCase(null)]
        public void SetActiveStateTest(States s)
        {
            // Arrange 
            var controlUnit = new ControlUnit(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                new PropertyGrid());
            var editContext = new EditContextStub(controlUnit);
            controlUnit.EditContext = editContext;

            // Act 
            editContext.SetActiveState(s);

            // Assert
            Assert.IsNotNull(editContext.ActiveState);
        }

        [Test]
        public void SetSelectedFigures1()
        {
            // Arrange 
            Mock<FigureBase> figureMock = new Mock<FigureBase>();
            Mock<IControlUnit> controlUnitMock = new Mock<IControlUnit>();
            var editContext = new EditContextStub(controlUnitMock.Object);

            // Act 
            int countBeforeAct = editContext.SelectedFigures.Count;
            editContext.SetSelectedFigures(figureMock.Object.guid);

            // Assert
            Assert.IsTrue(countBeforeAct == 0);
            Assert.IsTrue(editContext.SelectedFigures.Count == 1);
            controlUnitMock.Verify(unit => unit.UpdatePropertyGrid(), Times.Once);
        }

        [Test]
        public void SetSelectedFigures2()
        {
            // Arrange 
            Mock<FigureBase> figureMock = new Mock<FigureBase>();
            Mock<IControlUnit> controlUnitMock = new Mock<IControlUnit>();
            var editContext = new EditContextStub(controlUnitMock.Object);

            // Act 
            int countBeforeAct = editContext.SelectedFigures.Count;
            editContext.SetSelectedFigures(new List<Guid>
                {figureMock.Object.guid});

            // Assert
            Assert.IsTrue(countBeforeAct == 0);
            Assert.IsTrue(editContext.SelectedFigures.Count == 1);
            controlUnitMock.Verify(unit => unit.UpdatePropertyGrid(), Times.Once);
        }

        [Test]
        public void SetSelectedFigures3()
        {
            // Arrange 
            Mock<FigureBase> figureMock = new Mock<FigureBase>();
            Mock<IControlUnit> controlUnitMock = new Mock<IControlUnit>();
            var editContext = new EditContextStub(controlUnitMock.Object);

            // Act 
            int countBeforeAct = editContext.SelectedFigures.Count;
            editContext.SetSelectedFigures(new List<FigureBase>
                {figureMock.Object});

            // Assert
            Assert.IsTrue(countBeforeAct == 0);
            Assert.IsTrue(editContext.SelectedFigures.Count == 1);
            controlUnitMock.Verify(unit => unit.UpdatePropertyGrid(), Times.Once);
        }

        [Test]
        public void GetSelectedFigures()
        {
            // Arrange 
            Mock<FigureBase> figureMock = new Mock<FigureBase>();
            Mock<IDocument> docMock = new Mock<IDocument>();
            docMock.Setup(document => document.GetFigure(It.IsAny<Guid>()))
                .Returns(figureMock.Object);
            Mock<IControlUnit> controlUnitMock = new Mock<IControlUnit>();
            controlUnitMock.Setup(unit => unit.GetDocument())
                .Returns(docMock.Object);
            var editContext = new EditContextStub(controlUnitMock.Object);

            // Act 
            int countBeforeAct = editContext.GetSelectedFigures().Count;
            editContext.SelectedFigures.Add(figureMock.Object.guid);
            var actualSelectedFigures = editContext.GetSelectedFigures();

            // Assert
            Assert.IsTrue(actualSelectedFigures.Count == 1);
            Assert.IsTrue(countBeforeAct == 0);
        }
    }
}
