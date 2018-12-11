using System.ComponentModel;
using System.Drawing;

namespace VectorEditorProject.Figures.Utility
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [DisplayName("Настройки заливки")]
    public class FillSettings
    {
        [DisplayName("Цвет")]
        public Color Color { get; set; }

        /// <summary>
        /// Конструктор настройки заливки по умолчанию
        /// </summary>
        public FillSettings()
        {
            Color = Color.Transparent;
        }

        /// <summary>
        /// Конструктор настройки заливки
        /// </summary>
        /// <param name="color">Цвет</param>
        public FillSettings(Color color)
        {
            Color = color;
        }
    }
}
