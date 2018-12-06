using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VectorEditorProject.Core.Commands;
using VectorEditorProject.Figures;

namespace VectorEditorProject.Core.States
{
    public class AddFigureState : BaseState
    {
        private EditContext _editContext;
        private ControlUnit _controlUnit;

        public AddFigureState(ControlUnit controlUnit, EditContext editContext)
        {
            _controlUnit = controlUnit;
            _editContext = editContext;
        }

        public override void MouseDown(object sender, MouseEventArgs e)
        {
            FigureFactory figureFactory = new FigureFactory();
            BaseFigure figure = figureFactory.CreateFigure(FigureFactory.Figures.Line);
            figure.LineSettings = _controlUnit.GetLineSettings();
            figure.PointsSettings.AddPoint(new PointF(e.X, e.Y));

            AddFigureCommand command = new AddFigureCommand(_controlUnit, figure);
            _controlUnit.StoreCommand(command);
            _controlUnit.Do();

            if (_controlUnit.GetDocument().GetFigures().Last().PointsSettings.CanAddPoint())
            {
                _editContext.SetActiveFigure(figure);
                _editContext.SetActiveState(EditContext.States.AddPointState);
            }
            else
            {
                _editContext.SetActiveState(EditContext.States.SelectionState);
            }
        }
    }
}
