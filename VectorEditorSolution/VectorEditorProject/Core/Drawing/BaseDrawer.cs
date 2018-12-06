using System.Drawing;
using VectorEditorProject.Figures;

namespace VectorEditorProject.Drawing
{
    public abstract class BaseDrawer
    {
        public abstract void DrawFigure(BaseFigure figure, Graphics graphics);
    }
}
