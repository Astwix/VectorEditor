using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VectorEditorProject.Core;
using VectorEditorProject.Figures;

namespace VectorEditorProject.Forms
{
    public partial class ToolsControl : UserControl
    {
        public EditContext EditContext { get; set; }
        private FigureFactory.Figures _activeFigureType;

        private Dictionary<object, FigureFactory.Figures> _figures = 
            new Dictionary<object, FigureFactory.Figures>();

        public ToolsControl()
        {
            InitializeComponent();

            _figures.Add(LineButton, FigureFactory.Figures.Line);
            _figures.Add(PolylineButton, FigureFactory.Figures.PolyLine);
            _figures.Add(CircleButton, FigureFactory.Figures.Circle);
            _figures.Add(EllipseButton, FigureFactory.Figures.Ellipse);
            _figures.Add(PolygonButton, FigureFactory.Figures.Polygon);
        }

        private void CreateFigure(object sender, EventArgs e)
        {
            _activeFigureType = _figures[sender];

            EditContext.SetActiveState(EditContext.States.AddFigureState);
        }

        private void selectionButton_Click(object sender, EventArgs e)
        {
            EditContext.SetActiveState(EditContext.States.SelectionState);
        }

        public FigureFactory.Figures GetActiveFigureType()
        {
            return _activeFigureType;
        }
    }
}
