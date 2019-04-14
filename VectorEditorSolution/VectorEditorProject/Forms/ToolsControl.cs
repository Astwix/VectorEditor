using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VectorEditorProject.Core;
using VectorEditorProject.Core.Figures.Utility;
using VectorEditorProject.Core.States;

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
        private Figures _activeFigureType;

        /// <summary>
        /// Привязка кнопка -> фигура
        /// </summary>
        private readonly Dictionary<Button, Figures> _figures;

        /// <summary>
        /// Конструктор Control'а инструментов
        /// </summary>
        public ToolsControl()
        {
            InitializeComponent();

            _figures = new Dictionary<Button, Figures>
            {
                {LineButton, Figures.Line},
                {PolylineButton, Figures.PolyLine},
                {CircleButton, Figures.Circle},
                {EllipseButton, Figures.Ellipse},
                {PolygonButton, Figures.Polygon}
            };

        }

        /// <summary>
        /// Создание фигуры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateFigure(object sender, EventArgs e)
        {
            _activeFigureType = _figures[(Button)sender];

            EditContext.SetActiveState(States.AddFigureState);
        }

        /// <summary>
        /// Клик по кнопке "Выделение"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectionButton_Click(object sender, EventArgs e)
        {
            EditContext.SetActiveState(States.SelectionState);
        }

        /// <summary>
        /// Получить тип активной фигуры
        /// </summary>
        /// <returns></returns>
        public Figures GetActiveFigureType()
        {
            return _activeFigureType;
        }
    }
}
