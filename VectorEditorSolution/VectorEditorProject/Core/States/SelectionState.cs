using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using SDK;

namespace VectorEditorProject.Core.States
{
    /// <summary>
    /// Состояние выделения
    /// </summary>
    public class SelectionState : StateBase
    {
        /// <summary>
        /// Edit Context
        /// </summary>
        private readonly EditContext _editContext;

        /// <summary>
        /// Control Unit
        /// </summary>
        private readonly IControlUnit _controlUnit;

        /// <summary>
        /// Нажата ли клавиша мыши
        /// </summary>
        private bool _isMousePressed;

        /// <summary>
        /// Начальный Х
        /// </summary>
        private int _beginX;

        /// <summary>
        /// Начальный У
        /// </summary>
        private int _beginY;

        /// <summary>
        /// Прямоугольник выделения
        /// </summary>
        private Rectangle _selectionRectangle;

        /// <summary>
        /// Конструктор состояния выделения
        /// </summary>
        /// <param name="controlUnit">Control Unit</param>
        /// <param name="editContext">EditContext</param>
        public SelectionState(IControlUnit controlUnit, EditContext editContext)
        {
            _controlUnit = controlUnit;
            _editContext = editContext;
        }

        /// <summary>
        /// Рисование
        /// </summary>
        /// <param name="graphics">Graphics</param>
        public override void Draw(Graphics graphics)
        {
            if (_isMousePressed)
            {
                Pen pen = new Pen(Color.Black);
                pen.DashStyle = DashStyle.Dot;

                graphics.DrawRectangle(pen, _selectionRectangle);

                pen.Dispose();
            }
        }

        /// <summary>
        /// Нажатие кнопки мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void MouseDown(object sender, MouseEventArgs e)
        {
            _isMousePressed = true;

            _beginX = e.X;
            _beginY = e.Y;
            _selectionRectangle = new Rectangle();
            _selectionRectangle.X = e.X;
            _selectionRectangle.Y = e.Y;
        }

        /// <summary>
        /// Перемещение мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void MouseMove(object sender, MouseEventArgs e)
        {   
            _selectionRectangle.X = Math.Min(_beginX, e.X);
            _selectionRectangle.Y = Math.Min(_beginY, e.Y);
            _selectionRectangle.Width = Math.Max(_beginX, e.X) - 
                                        _selectionRectangle.X;
            _selectionRectangle.Height = Math.Max(_beginY, e.Y) - 
                                         _selectionRectangle.Y;
            
            _controlUnit.UpdateCanvas();
        }

        /// <summary>
        /// Отжатие кнопки мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void MouseUp(object sender, MouseEventArgs e)
        {
            if (!_isMousePressed)
            {
                return;
            }

            _isMousePressed = false;
            if (_selectionRectangle.Width < 3 &&
                _selectionRectangle.Height < 3)
            {
                SingleSelection(e.X, e.Y);
            }
            else
            {
                AreaSelection();
            }
        }

        /// <summary>
        /// Единичное выделение
        /// </summary>
        private void SingleSelection(int x, int y)
        {
            Dictionary<FigureBase, float> distanceToFigures =
                new Dictionary<FigureBase, float>();

            var figures = _controlUnit.GetDocument().GetFigures();
            if (figures.Count > 0)
            {
                // по фигурам
                foreach (var figure in figures)
                {
                    float distance = PointsSettings.DistanceBetweenPoints(
                        figure.PointsSettings.GetPoints()[0],
                        new PointF(x, y));

                    // по точкам
                    foreach (var point in figure.PointsSettings.GetPoints())
                    {
                        distance = Math.Min(distance,
                            PointsSettings.DistanceBetweenPoints(point,
                                new PointF(x, y)));
                    }

                    distanceToFigures.Add(figure, distance);
                }

                // ближайшая (к клику пользователя) фигура из словаря
                var nearFigure = distanceToFigures.Aggregate(
                        (l, r) => l.Value < r.Value ? l : r).Key;
                _editContext.SetSelectedFigures(new List<FigureBase>()
                {
                    nearFigure
                });
                _editContext.SetActiveState(States.FigureEditingState);
            }
        }

        /// <summary>
        /// Выделение областью
        /// </summary>
        private void AreaSelection()
        {
            List<FigureBase> selectedFigures = new List<FigureBase>();

            foreach (var figure in _controlUnit.GetDocument().GetFigures())
            {
                if (figure.PointsSettings.IsFigureInRectangle(_selectionRectangle))
                {
                    selectedFigures.Add(figure);
                }
            }

            if (selectedFigures.Count > 0)
            {
                _editContext.SetSelectedFigures(selectedFigures);
                _editContext.SetActiveState(States.FigureEditingState);
            }
        }
    }
}
