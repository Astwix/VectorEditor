using System;
using VectorEditorProject.Core.Figures.Utility;

namespace VectorEditorProject.Core.Figures
{
    [Serializable]
    public abstract class FilledBaseFigure : BaseFigure
    {
        protected FillSettings _fillSettings;

        public FillSettings FillSettings { get => _fillSettings; set => _fillSettings = value; }

        /// <summary>
        /// Получить хэш-код
        /// </summary>
        /// <returns>Хэш</returns>
        public override int GetHashCode()
        {
            return _lineSettings.GetHashCode() + _pointsSettings.GetHashCode() + _fillSettings.GetHashCode();
        }
    }
}
