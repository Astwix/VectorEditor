using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VectorEditorProject.Core.Commands;
using VectorEditorProject.Drawing;
using VectorEditorProject.Figures;

namespace VectorEditorProject.Core.States
{
    public class AddCircleState : BaseState
    {
        private BaseFigure _figure;
        private DrawerFactory _drawerFactory = new DrawerFactory();
        private bool _isMousePressed;

        private ControlUnit _controlUnit;

        public AddCircleState(ControlUnit controlUnit)
        {
            _controlUnit = controlUnit;
        }

        public override void Draw(Graphics graphics)
        {
            if (_isMousePressed)
            {
                _drawerFactory.DrawFigure(_figure, graphics);
            }
        }

        public override void MouseDown(object sender, MouseEventArgs e)
        {
            _isMousePressed = true;

            FigureFactory figureFactory = new FigureFactory();
            _figure = figureFactory.CreateFilledFigure(FigureFactory.FilledFigures.Circle);
            _figure.PointsSettings.AddPoint(new Point(e.X, e.Y));
            _figure.PointsSettings.AddPoint(new Point(e.X, e.Y));
        }

        public override void MouseMove(object sender, MouseEventArgs e)
        {
            if (_figure != null && _isMousePressed)
            {
                Point point = new Point(e.X, e.Y);
                _figure.PointsSettings.ReplacePoint(1, point);

                _controlUnit.ForceRedrawCanvas();
            }
        }

        public override void MouseUp(object sender, MouseEventArgs e)
        {
            _isMousePressed = false;

            var command = new AddFigureCommand(_controlUnit.GetDocument(), _figure);
            _controlUnit.StoreCommand(command);
            _controlUnit.Do();
        }
    }
}
