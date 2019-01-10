﻿using System;
using VectorEditorProject.Core.Figures.Utility;

namespace VectorEditorProject.Core.Figures
{
    /// <summary>
    /// Полилиния
    /// </summary>
    [Serializable]
    public class PolyLine : FigureBase
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
