using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VectorEditorProject.Core.Commands;

namespace VectorEditorProject.Core.States
{
    /// <summary>
    /// Состояние добавления точки
    /// </summary>
    public class AddPointState : StateBase
    {
        /// <summary>
        /// Фабрика рисования
        /// </summary>
        protected readonly DrawerFactory _drawerFactory = new DrawerFactory();

        /// <summary>
        /// Edit Context
        /// </summary>
        protected readonly EditContext _editContext;

        /// <summary>
        /// Control Unit
        /// </summary>
        protected readonly IControlUnit _controlUnit;

        /// <summary>
        /// Нажата ли кнопка мыши
        /// </summary>
        protected bool _isMousePressed = true;

        /// <summary>
        /// Состояние добавления точек
        /// </summary>
        /// <param name="controlUnit">Control Unit</param>
        /// <param name="editContext">Edit Context</param>
        public AddPointState(IControlUnit controlUnit, EditContext editContext)
        {
            _controlUnit = controlUnit;
            _editContext = editContext;

            var activeFigure = _editContext.GetActiveFigure();
            if (activeFigure == null)
            {
                editContext.SetActiveState(States.SelectionState);
                return;
            }

            var lastPoint = activeFigure.PointsSettings.GetPoints().Last();
            activeFigure.PointsSettings.AddPoint(lastPoint);
        }

        /// <summary>
        /// Рисование
        /// </summary>
        /// <param name="graphics">Graphics</param>
        public override void Draw(Graphics graphics)
        {
            var activeFigure = _editContext.GetActiveFigure();
            if (_isMousePressed && activeFigure != null)
            {
                _drawerFactory.DrawFigure(activeFigure,
                    graphics);
            }
        }

        /// <summary>
        /// Нажатие кнопки мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void MouseDown(object sender, MouseEventArgs e)
        {
            _isMousePressed = true;

            var activeFigure = _editContext.GetActiveFigure();
            if (activeFigure == null)
            {
                _editContext.SetActiveState(States.SelectionState);
                return;
            }

            var lastPoint = activeFigure.PointsSettings.GetPoints().Last();
            activeFigure.PointsSettings.AddPoint(lastPoint);
        }

        /// <summary>
        /// Перемещение мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void MouseMove(object sender, MouseEventArgs e)
        {
            var activeFigure = _editContext.GetActiveFigure();
            if (activeFigure == null)
            {
                _editContext.SetActiveState(States.SelectionState);
                return;
            }

            if (_isMousePressed)
            {
                PointF point = new PointF(e.X, e.Y);
                int pointsCount = activeFigure.PointsSettings.GetPoints()
                    .Count;
                activeFigure.PointsSettings.ReplacePoint(pointsCount - 1,
                    point);
            }

            _controlUnit.UpdateCanvas();
        }

        /// <summary>
        /// Отжатие кнопки мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void MouseUp(object sender, MouseEventArgs e)
        {
            _isMousePressed = false;

            var activeFigure = _editContext.GetActiveFigure();
            if (activeFigure == null)
            {
                _editContext.SetActiveState(States.SelectionState);
                return;
            }

            activeFigure.PointsSettings.RemoveLast();

            var command = CommandFactory.CreateAddPointCommand(activeFigure,
                new PointF(e.X, e.Y), _controlUnit);
            _controlUnit.StoreCommand(command);
            _controlUnit.Do();

            if (!activeFigure.PointsSettings.CanAddPoint())
            {
                _editContext.SetActiveState(States.AddFigureState);
            }
        }
    }
}