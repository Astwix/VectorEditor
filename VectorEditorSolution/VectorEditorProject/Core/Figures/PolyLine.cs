using VectorEditorProject.Figures.Utility;

namespace VectorEditorProject.Figures
{
    class PolyLine : BaseFigure
    {
        /// <summary>
        /// Конструктор "Полилиния"
        /// </summary>
        public PolyLine()
        {
            _lineSettings = new LineSettings();
            _pointsSettings = new PointsSettings();
        }
    }
}
