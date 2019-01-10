using System;
using VectorEditorProject.Core.Figures.Utility;

namespace VectorEditorProject.Core.Figures
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
            return _lineSettings.GetHashCode() 
                   + _pointsSettings.GetHashCode() 
                   + _fillSettings.GetHashCode();
        }
    }
}
