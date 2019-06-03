using System;

namespace SDK
{
    /// <summary>
    /// Базовая фигура с заливкой
    /// </summary>
    [Serializable]
    public abstract class FilledFigureBase : FigureBase
    {
        /// <summary>
        /// Настройки заливки
        /// </summary>
        protected FillSettings _fillSettings;

        /// <summary>
        /// Настройки заливки
        /// </summary>
        public FillSettings FillSettings
        {
            get => _fillSettings;
            set => _fillSettings = value;
        }

        /// <summary>
        /// Получить хэш-код
        /// </summary>
        /// <returns>Хэш</returns>
        public override int GetHashCode()
        {
            return _lineSettings.GetHashCode() +
                   _pointsSettings.GetHashCode() +
                   _fillSettings.GetHashCode();
        }

        /// <summary>
        /// Копирование фигуры
        /// </summary>
        /// <param name="figure">Фигура</param>
        /// <returns>Копия фигуры</returns>
        public override FigureBase CopyFigure()
        {
            var copy = base.CopyFigure();
            if (this is FilledFigureBase filledFigure 
                && copy is FilledFigureBase filledCopy)
            {
                filledCopy.FillSettings.Color = filledFigure.FillSettings.Color;
            }

            return copy;
        }
    }
}
