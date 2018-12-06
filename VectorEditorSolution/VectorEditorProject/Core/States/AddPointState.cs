using System.Drawing;
using System.Windows.Forms;
using VectorEditorProject.Core.Commands;
using VectorEditorProject.Drawing;

namespace VectorEditorProject.Core.States
{
    public class AddPointState : BaseState
    {
        private DrawerFactory _drawerFactory = new DrawerFactory();
        private EditContext _editContext;
        private ControlUnit _controlUnit;

        private bool _isMousePressed;

        /// <summary>
        /// Состояние добавления точек
        /// </summary>
        /// <param name="controlUnit"></param>
        /// <param name="editContext"></param>
        public AddPointState(ControlUnit controlUnit, EditContext editContext)
        {
            _controlUnit = controlUnit;
            _editContext = editContext;

            if (_editContext.GetActiveFigure() == null)
            {
                editContext.SetActiveState(EditContext.States.SelectionState);
            }
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
            if (activeFigure != null)
            {
                activeFigure.PointsSettings.AddPoint(new Point(e.X, e.Y));
            }
            else
            {
                _editContext.SetActiveState(EditContext.States.SelectionState);
            }
        }


        public override void MouseMove(object sender, MouseEventArgs e)
        {
            var activeFigure = _editContext.GetActiveFigure();
            if (_isMousePressed)
            {
                if (activeFigure != null)
                {
                    Point point = new Point(e.X, e.Y);
                    int pointsCount = activeFigure.PointsSettings.GetPoints().Count;
                    activeFigure.PointsSettings.ReplacePoint(pointsCount - 1, point);

                    _controlUnit.ForceRedrawCanvas();
                }
                else
                {
                    _editContext.SetActiveState(EditContext.States.SelectionState);
                }
            }
        }

        public override void MouseUp(object sender, MouseEventArgs e)
        {
            _isMousePressed = false;
            var activeFigure = _editContext.GetActiveFigure();

            if (activeFigure != null)
            {
                activeFigure.PointsSettings.DeletePoint(new Point(e.X, e.Y));
                var command = new AddPointCommand(activeFigure, new Point(e.X, e.Y), _controlUnit);
                _controlUnit.StoreCommand(command);
                _controlUnit.Do();
            }
            else
            {
                _editContext.SetActiveState(EditContext.States.SelectionState);
            }
        }
    }
}