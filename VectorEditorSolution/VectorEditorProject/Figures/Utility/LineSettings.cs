using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorEditorProject.Figures.Utility
{
    class LineSettings
    {
        public LineSettings(Color color, float width, DashStyle style)
        {
            Color = color;
            Width = width;
            Style = style;
        }

        public Color Color { get; set; }
        public float Width { get; set; }
        public DashStyle Style { get; set; }
    }
}
