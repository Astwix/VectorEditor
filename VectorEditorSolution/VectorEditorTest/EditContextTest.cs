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
            Mock<StateBase> state = new Mock<StateBase>();
            EditContextStub ec = new EditContextStub(
                new ControlUnit(new PictureBox(), new FigureSettingsControl(),
                    new ToolsControl(), new PropertyGrid()));
            ec.ActiveState = state.Object;
            MouseEventArgs testArgs = new MouseEventArgs(MouseButtons.Left, 1, 2, 3, 4);

            ec.MouseDown(this, testArgs);
            ec.MouseUp(this, testArgs);
            ec.MouseMove(this, testArgs);

            state.Verify(stateBase => stateBase.MouseDown(this, testArgs), Times.Once);
            state.Verify(stateBase => stateBase.MouseUp(this, testArgs), Times.Once);
            state.Verify(stateBase => stateBase.MouseMove(this, testArgs), Times.Once);
        }

        [Test]
        public void UpdateStateTest()
        {
            Mock<StateBase> state = new Mock<StateBase>();
            EditContextStub ec = new EditContextStub(
                new ControlUnit(new PictureBox(), new FigureSettingsControl(),
                    new ToolsControl(), new PropertyGrid()));
            ec.ActiveState = state.Object;

            ec.UpdateState();

            state.Verify(stateBase => stateBase.Update(), Times.Once);
        }

        [Test]
        public void DrawTest()
        {
            Mock<StateBase> state = new Mock<StateBase>();
            EditContextStub ec = new EditContextStub(
                new ControlUnit(new PictureBox(), new FigureSettingsControl(),
                    new ToolsControl(), new PropertyGrid()));
            ec.ActiveState = state.Object;

            ec.Draw(new Control().CreateGraphics());

            state.Verify(stateBase => stateBase.Draw(It.IsAny<Graphics>()), Times.Once);
        }

        [Test]
        public void ConstructorTest()
        {
            EditContextStub ec = new EditContextStub(
                new ControlUnit(new PictureBox(), new FigureSettingsControl(),
                    new ToolsControl(), new PropertyGrid()));

            Assert.IsNotNull(ec.ControlUnit);
            Assert.IsNotNull(ec.ActiveState);
        }

        [Test]
        public void SetActiveFigureTest()
        {
            var controlUnit = new ControlUnit(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                new PropertyGrid());
            var editContext = new EditContextStub(controlUnit);
            Mock<FigureBase> mock = new Mock<FigureBase>();

            editContext.SetActiveFigure(mock.Object);

            Assert.AreEqual(editContext.ActiveFigureGuid, mock.Object.guid);
        }

        [Test]
        public void GetActiveFigureTest1()
        {
            var controlUnit = new ControlUnit(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                new PropertyGrid());
            Mock<FigureBase> mock = new Mock<FigureBase>();
            controlUnit.GetDocument().AddFigure(mock.Object);
            var editContext = new EditContext(controlUnit);

            editContext.SetActiveFigure(mock.Object);

            Assert.AreEqual(mock.Object, editContext.GetActiveFigure());
        }

        [Test]
        public void GetActiveFigureTest2()
        {
            var controlUnit = new ControlUnit(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                new PropertyGrid());
            var editContext = new EditContext(controlUnit);

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
            var controlUnit = new ControlUnit(new PictureBox(),
                new FigureSettingsControl(), new ToolsControl(),
                new PropertyGrid());
            var editContext = new EditContextStub(controlUnit);
            controlUnit.EditContext = editContext;

            editContext.SetActiveState(s);

            Assert.IsNotNull(editContext.ActiveState);
        }

        [Test]
        public void SetSelectedFigures1()
        {
            Mock<FigureBase> figureMock = new Mock<FigureBase>();
            Mock<IControlUnit> controlUnitMock = new Mock<IControlUnit>();
            var editContext = new EditContextStub(controlUnitMock.Object);

            int countBeforeAct = editContext.SelectedFigures.Count;
            editContext.SetSelectedFigures(figureMock.Object.guid);

            Assert.IsTrue(countBeforeAct == 0);
            Assert.IsTrue(editContext.SelectedFigures.Count == 1);
            controlUnitMock.Verify(unit => unit.UpdatePropertyGrid(), Times.Once);
        }

        [Test]
        public void SetSelectedFigures2()
        {
            Mock<FigureBase> figureMock = new Mock<FigureBase>();
            Mock<IControlUnit> controlUnitMock = new Mock<IControlUnit>();
            var editContext = new EditContextStub(controlUnitMock.Object);

            int countBeforeAct = editContext.SelectedFigures.Count;
            editContext.SetSelectedFigures(new List<Guid>
                {figureMock.Object.guid});

            Assert.IsTrue(countBeforeAct == 0);
            Assert.IsTrue(editContext.SelectedFigures.Count == 1);
            controlUnitMock.Verify(unit => unit.UpdatePropertyGrid(), Times.Once);
        }

        [Test]
        public void SetSelectedFigures3()
        {
            Mock<FigureBase> figureMock = new Mock<FigureBase>();
            Mock<IControlUnit> controlUnitMock = new Mock<IControlUnit>();
            var editContext = new EditContextStub(controlUnitMock.Object);

            int countBeforeAct = editContext.SelectedFigures.Count;
            editContext.SetSelectedFigures(new List<FigureBase>
                {figureMock.Object});

            Assert.IsTrue(countBeforeAct == 0);
            Assert.IsTrue(editContext.SelectedFigures.Count == 1);
            controlUnitMock.Verify(unit => unit.UpdatePropertyGrid(), Times.Once);
        }

        [Test]
        public void GetSelectedFigures()
        {
            Mock<FigureBase> figureMock = new Mock<FigureBase>();
            Mock<IDocument> docMock = new Mock<IDocument>();
            docMock.Setup(document => document.GetFigure(It.IsAny<Guid>()))
                .Returns(figureMock.Object);
            Mock<IControlUnit> controlUnitMock = new Mock<IControlUnit>();
            controlUnitMock.Setup(unit => unit.GetDocument())
                .Returns(docMock.Object);
            var editContext = new EditContextStub(controlUnitMock.Object);

            int countBeforeAct = editContext.GetSelectedFigures().Count;
            editContext.SelectedFigures.Add(figureMock.Object.guid);
            var actualSelectedFigures = editContext.GetSelectedFigures();

            Assert.IsTrue(actualSelectedFigures.Count == 1);
            Assert.IsTrue(countBeforeAct == 0);
        }
    }
}
