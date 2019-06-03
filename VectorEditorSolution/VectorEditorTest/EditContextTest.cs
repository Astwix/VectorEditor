using Moq;
using NUnit.Framework;
using SDK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using VectorEditorProject.Core;
using VectorEditorProject.Core.States;
using VectorEditorProject.Forms;
using VectorEditorTest.Stubs;

namespace VectorEditorTest
{
    [TestFixture]
    public class EditContextTest
    {
        [TestCase(TestName = "Позитивная проверка числа вызовов " +
                             "на действия с мышью")]
        public void MouseCallsTest()
        {
            // Arrange 
            Mock<StateBase> state = new Mock<StateBase>();
            EditContextStub ec = new EditContextStub(
                new ControlUnit(new PictureBox(), new FigureSettingsControl(),
                    new ToolsControl(), new PropertyGrid()));
            ec.ActiveState = state.Object;
            MouseEventArgs testArgs =
                new MouseEventArgs(MouseButtons.Left, 1, 2, 3, 4);

            // Act 
            ec.MouseDown(this, testArgs);
            ec.MouseUp(this, testArgs);
            ec.MouseMove(this, testArgs);

            // Assert
            state.Verify(stateBase => stateBase.MouseDown(this, testArgs),
                Times.Once);
            state.Verify(stateBase => stateBase.MouseUp(this, testArgs),
                Times.Once);
            state.Verify(stateBase => stateBase.MouseMove(this, testArgs),
                Times.Once);
        }

        [TestCase(TestName = "Позитивное обновление состояния")]
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

        [TestCase(TestName = "Позитивная проверка рисования")]
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
            state.Verify(stateBase => stateBase.Draw(It.IsAny<Graphics>()),
                Times.Once);
        }

        [TestCase(TestName = "Позитивное создание стаба Edit Context" +
                             "через конструктор")]
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

        [TestCase(TestName = "Позитивное сравнение guid созданной реальной " +
                             "фигуры и установленной ее активной")]
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

        [TestCase(TestName = "Позитивное сравнение созданной мок " +
                             "фигуры и установленной ее активной")]
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

        [TestCase(TestName = "Null проверка на активную фигуру")]
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
        [TestCaseSource(nameof(AllStates))]
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

        [TestCase(TestName = "Позитивное сравнение числа фигур до их создания " +
                             "и после создания фигуры по guid")]
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

        [TestCase(TestName = "Позитивное сравнение числа фигур до их создания " +
                             "и после создания фигуры по guid через список")]
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

        [TestCase(TestName = "Позитивное сравнение числа фигур до их создания " +
                             "и после создания фигуры по базовому типу через список")]
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

        [TestCase(TestName = "Позитивное сравнение числа фигур до " +
                             "и после их создания")]
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
