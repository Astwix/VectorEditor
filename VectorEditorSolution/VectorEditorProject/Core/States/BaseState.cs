using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VectorEditorProject.Core.States
{
    public abstract class BaseState
    {
        public virtual void Draw(Graphics graphics)
        {
        }

        public virtual void MouseDown(object sender, MouseEventArgs e)
        {
        }

        public virtual void MouseUp(object sender, MouseEventArgs e)
        {
        }

        public virtual void MouseMove(object sender, MouseEventArgs e)
        {
        }
    }
}
