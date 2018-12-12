using System.Drawing;
using VectorEditorProject.Core.Figures;

namespace VectorEditorProject.Core.Drawing
{
    public abstract class BaseDrawer
    {
        public abstract void DrawFigure(BaseFigure figure, Graphics graphics);
        public abstract void DrawBorder(BaseFigure figure, Graphics graphics);
    }
}
