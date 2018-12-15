using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VectorEditorProject.Core.Commands;
using VectorEditorProject.Core.Drawing;

namespace VectorEditorProject.Core.States
{
    public class AddPointState : BaseState
    {
        private DrawerFactory _drawerFactory = new DrawerFactory();
        private EditContext _editContext;
        private ControlUnit _controlUnit;

        private bool _isMousePressed = true;

        /// <summary>
        /// Состояние добавления точек
        /// </summary>
        /// <param name="controlUnit"></param>
        /// <param name="editContext"></param>
        public AddPointState(ControlUnit controlUnit, EditContext editContext)
        {
            _controlUnit = controlUnit;
            _editContext = editContext;

            var activeFigure = _editContext.GetActiveFigure();
            if (activeFigure == null)
            {
                editContext.SetActiveState(EditContext.States.SelectionState);
            }

            var lastPoint = activeFigure.PointsSettings.GetPoints().Last();
            activeFigure.PointsSettings.AddPoint(lastPoint);
        }

        public override void Draw(Graphics graphics)
        {
            var activeFigure = _editContext.GetActiveFigure();
            if (_isMousePressed && activeFigure != null)
            {
                _drawerFactory.DrawFigure(activeFigure, graphics);
            }
        }

        public override void MouseDown(object sender, MouseEventArgs e)
        {
            _isMousePressed = true;

            var activeFigure = _editContext.GetActiveFigure();
            if (activeFigure == null)
            {
                _editContext.SetActiveState(EditContext.States.SelectionState);
                return;
            }

            var lastPoint = activeFigure.PointsSettings.GetPoints().Last();
            activeFigure.PointsSettings.AddPoint(lastPoint);
        }

        public override void MouseMove(object sender, MouseEventArgs e)
        {
            var activeFigure = _editContext.GetActiveFigure();
            if (activeFigure == null)
            {
                _editContext.SetActiveState(EditContext.States.SelectionState);
                return;
            }

            if (_isMousePressed)
            {
                PointF point = new PointF(e.X, e.Y);
                int pointsCount = activeFigure.PointsSettings.GetPoints().Count;
                activeFigure.PointsSettings.ReplacePoint(pointsCount - 1, point);
            }

            _controlUnit.UpdateCanvas();
        }

        public override void MouseUp(object sender, MouseEventArgs e)
        {
            _isMousePressed = false;

            var activeFigure = _editContext.GetActiveFigure();
            if (activeFigure == null)
            {
                _editContext.SetActiveState(EditContext.States.SelectionState);
            }

            activeFigure.PointsSettings.RemoveLast();

            var command = CommandFactory.CreateAddPointCommand(activeFigure, new PointF(e.X, e.Y), _controlUnit);
            _controlUnit.StoreCommand(command);
            _controlUnit.Do();

            if (!activeFigure.PointsSettings.CanAddPoint())
            {
                _editContext.SetActiveState(EditContext.States.AddFigureState);
            }
        }
    }
}