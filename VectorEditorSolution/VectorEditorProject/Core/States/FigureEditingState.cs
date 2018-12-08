using System.Drawing;
using System.Windows.Forms;
using VectorEditorProject.Drawing;

namespace VectorEditorProject.Core.States
{
    class FigureEditingState : BaseState
    {
        private DrawerFactory _drawerFactory = new DrawerFactory();
        private EditContext _editContext;
        private ControlUnit _controlUnit;

        public FigureEditingState(ControlUnit controlUnit, EditContext editContext)
        {
            _editContext = editContext;
            _controlUnit = controlUnit;
        }

        public override void Draw(Graphics graphics)
        {
            foreach (var selectedFigure in _editContext.GetSelectedFigures())
            {
                _drawerFactory.DrawBorder(selectedFigure, graphics);
            }
        }

        public override void MouseDown(object sender, MouseEventArgs e)
        {
            base.MouseDown(sender, e);
        }

        public override void MouseMove(object sender, MouseEventArgs e)
        {
            base.MouseMove(sender, e);
        }

        public override void MouseUp(object sender, MouseEventArgs e)
        {
            base.MouseUp(sender, e);
        }
    }
}
