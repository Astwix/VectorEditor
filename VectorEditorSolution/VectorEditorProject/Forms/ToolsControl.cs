using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VectorEditorProject.Core;
using VectorEditorProject.Core.Figures;

namespace VectorEditorProject.Forms
{
    /// <summary>
    /// Control инструментов
    /// </summary>
    public partial class ToolsControl : UserControl
    {
        /// <summary>
        /// Edit Context
        /// </summary>
        public EditContext EditContext { get; set; }

        /// <summary>
        /// Тип активной фигуры
        /// </summary>
        private FigureFactory.Figures _activeFigureType;

        private Dictionary<object, FigureFactory.Figures> _figures = 
            new Dictionary<object, FigureFactory.Figures>();

        /// <summary>
        /// Конструктор Control'а инструментов
        /// </summary>
        public ToolsControl()
        {
            InitializeComponent();

            _figures.Add(LineButton, FigureFactory.Figures.Line);
            _figures.Add(PolylineButton, FigureFactory.Figures.PolyLine);
            _figures.Add(CircleButton, FigureFactory.Figures.Circle);
            _figures.Add(EllipseButton, FigureFactory.Figures.Ellipse);
            _figures.Add(PolygonButton, FigureFactory.Figures.Polygon);
        }

        /// <summary>
        /// Создание фигуры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateFigure(object sender, EventArgs e)
        {
            _activeFigureType = _figures[sender];

            EditContext.SetActiveState(EditContext.States.AddFigureState);
        }

        /// <summary>
        /// Клик по кнопке "Выделение"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectionButton_Click(object sender, EventArgs e)
        {
            EditContext.SetActiveState(EditContext.States.SelectionState);
        }

        /// <summary>
        /// Получить тип активной фигуры
        /// </summary>
        /// <returns></returns>
        public FigureFactory.Figures GetActiveFigureType()
        {
            return _activeFigureType;
        }
    }
}
