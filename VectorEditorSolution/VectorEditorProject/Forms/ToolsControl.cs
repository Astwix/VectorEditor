using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SDK;
using StructureMap;
using VectorEditorProject.Core;
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
        private string _activeFigureType;

        /// <summary>
        /// Привязка кнопка -> фигура
        /// </summary>
        private readonly Dictionary<Button, string> _figures;

        /// <summary>
        /// Конструктор Control'а инструментов
        /// </summary>
        public ToolsControl()
        {
            InitializeComponent();
            int startVerticalpos = 10;
            
            var container = new Container(config =>
            {
                config.Scan(scanner =>
                {
                    scanner.AssembliesAndExecutablesFromApplicationBaseDirectory();
                    scanner.AddAllTypesOf<FigureBase>().
                        NameBy(type => type.Assembly.GetName().Name);
                });
            });

            foreach (var loadedFigure in container.GetAllInstances<FigureBase>())
            {
                Button figureButton 
                    = new Button {Text = loadedFigure.GetType().Assembly.GetName().Name};
                figureButton.Click += new EventHandler(FigureButtonOnClick);
                figureButton.Location = new Point(10, startVerticalpos);
                FiguresPanel.Controls.Add(figureButton);
                startVerticalpos += figureButton.Height + 10;
            }
        }

        private void FigureButtonOnClick(object sender, EventArgs e)
        {
            _activeFigureType = ((Button) sender).Text;
            EditContext.SetActiveState(States.AddFigureState);
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
        public string GetActiveFigureType()
        {
            return _activeFigureType;
        }
    }
}
