using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace VectorEditorProject.Core.States
{
    public class SelectionState : BaseState
    {
        private ControlUnit _controlUnit;
        private bool _isMousePressed;
        private int startX;
        private int startY;
        private int endX;
        private int endY;

        public SelectionState(ControlUnit controlUnit)
        {
            _controlUnit = controlUnit;
        }

        public override void Draw(Graphics graphics)
        {
            if (_isMousePressed)
            {
                Pen pen = new Pen(Color.Black);
                pen.DashStyle = DashStyle.Dot;

                graphics.DrawRectangle(pen, startX, startY, endX-startX, endY-startY);

                pen.Dispose();
            }
        }

        public override void MouseDown(object sender, MouseEventArgs e)
        {
            _isMousePressed = true;

            startX = e.X;
            startY = e.Y;
            endX = e.X;
            endY = e.Y;
        }

        public override void MouseMove(object sender, MouseEventArgs e)
        {
            endX = e.X;
            endY = e.Y;

            _controlUnit.UpdateCanvas();
        }

        public override void MouseUp(object sender, MouseEventArgs e)
        {
            _isMousePressed = false;
        }
    }
}
