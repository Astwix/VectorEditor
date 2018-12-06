using System.Drawing;
using System.Drawing.Drawing2D;

namespace VectorEditorProject.Figures.Utility
{
    public class LineSettings
    {
        public Color Color { get; set; }
        public float Width { get; set; }
        public DashStyle Style { get; set; }

        /// <summary>
        /// Конструктор настроек линии по умолчанию
        /// </summary>
        public LineSettings()
        {
            Color = Color.Black;
            Width = 1;
            Style = DashStyle.Solid;
        }

        /// <summary>
        /// Конструктор настроек линии
        /// </summary>
        /// <param name="color">Цвет</param>
        /// <param name="width">Тощина</param>
        /// <param name="style">Стиль</param>
        public LineSettings(Color color, float width, DashStyle style)
        {
            Color = color;
            Width = width;
            Style = style;
        }
    }
}
