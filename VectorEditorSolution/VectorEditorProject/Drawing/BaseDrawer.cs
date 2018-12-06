using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorEditorProject.Figures;

namespace VectorEditorProject.Drawing
{
    public abstract class BaseDrawer
    {
        public abstract void DrawFigure(BaseFigure figure, Graphics graphics);
    }
}
