using System;
using System.ComponentModel;
using System.Drawing;

namespace SDK
{
    /// <summary>
    /// Настройки заливки
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [DisplayName("Настройки заливки")]
    public class FillSettings
    {
        /// <summary>
        /// Цвет
        /// </summary>
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

        /// <summary>
        /// Получить хэш-код
        /// </summary>
        /// <returns>Хэш</returns>
        public override int GetHashCode()
        {
            return Color.GetHashCode();
        }

        /// <summary>
        /// Для красоты в PropertyGrid
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "";
        }
    }
}
