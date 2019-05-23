using System;
using System.Collections.Generic;
using System.Drawing;
using SDK;

namespace VectorEditorProject.Core
{
    public interface IDocument
    {
        Color Color { get; set; }
        string Name { get; set; }
        Size Size { get; set; }

        void AddFigure(FigureBase figure);
        void ClearCanvas();
        void DeleteFigure(FigureBase figure);
        void DeleteFigure(Guid guid);
        FigureBase GetFigure(Guid guid);
        IReadOnlyList<FigureBase> GetFigures();
    }
}