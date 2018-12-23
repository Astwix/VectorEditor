﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace VectorEditorProject.Core.Figures.Utility
{
    [Serializable]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [DisplayName("Настройки линии")]
    public class LineSettings
    {
        [DisplayName("Цвет")]
        public Color Color { get; set; }
        [DisplayName("Толщина")]
        public float Width { get; set; }
        [DisplayName("Тип")]
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

        /// <summary>
        /// Получить хэш-код
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Color.GetHashCode() + Width.GetHashCode() + Style.GetHashCode();
        }
    }
}
