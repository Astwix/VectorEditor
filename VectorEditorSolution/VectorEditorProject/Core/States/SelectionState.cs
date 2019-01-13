using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using VectorEditorProject.Core.Commands;
using VectorEditorProject.Core.Figures;
using VectorEditorProject.Core.Figures.Utility;

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
        private EditContext _editContext;

        /// <summary>
        /// Control Unit
        /// </summary>
        private ControlUnit _controlUnit;

        /// <summary>
        /// Нажата ли клавиша мыши
        /// </summary>
        private bool _isMousePressed;

        //todo Заменить точки на прямоугольник
        /// <summary>
        /// Начальный Х
        /// </summary>
        private int _beginX;

        /// <summary>
        /// Начальный У
        /// </summary>
        private int _beginY;

        /// <summary>
        /// Конечный Х
        /// </summary>
        private int _endX;

        /// <summary>
        /// Конечный У
        /// </summary>
        private int _endY;

        /// <summary>
        /// Левый верхний Х
        /// </summary>
        private int _leftTopX;

        /// <summary>
        /// Левый верхний У
        /// </summary>
        private int _leftTopY;

        /// <summary>
        /// Правый нижний Х
        /// </summary>
        private int _rightBottomX;

        /// <summary>
        /// Правый нижний У
        /// </summary>
        private int _rightBottomY;

        /// <summary>
        /// Конструктор состояния выделения
        /// </summary>
        /// <param name="controlUnit"></param>
        /// <param name="editContext"></param>
        public SelectionState(ControlUnit controlUnit, EditContext editContext)
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

                graphics.DrawRectangle(pen, _leftTopX, _leftTopY, _rightBottomX - _leftTopX, _rightBottomY - _leftTopY);

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
            _leftTopX = Math.Min(_beginX, _endX);
            _leftTopY = Math.Min(_beginY, _endY);
        }

        /// <summary>
        /// Перемещение мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void MouseMove(object sender, MouseEventArgs e)
        {
            _endX = e.X;
            _endY = e.Y;

            _leftTopX = Math.Min(_beginX, _endX);
            _leftTopY = Math.Min(_beginY, _endY);
            _rightBottomX = Math.Max(_beginX, _endX);
            _rightBottomY = Math.Max(_beginY, _endY);

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
            if ((_rightBottomX - _leftTopX < 3) && (_rightBottomY - _leftTopY < 3))
            {
                SingleSelection();
            }
            else
            {
                AreaSelection();
            }
        }

        /// <summary>
        /// Единичное выделение
        /// </summary>
        private void SingleSelection()
        {
            Dictionary<FigureBase, float> distanceToFigures = new Dictionary<FigureBase, float>();

            var figures = _controlUnit.GetDocument().GetFigures();
            if (figures.Count > 0)
            {
                // по фигурам
                foreach (var figure in figures)
                {
                    float distance = FigureEditor.DistanceBetweenPoints(figure.PointsSettings.GetPoints()[0],
                        new PointF(_endX, _endY));

                    // по точкам
                    foreach (var point in figure.PointsSettings.GetPoints())
                    {
                        distance = Math.Min(distance,
                            FigureEditor.DistanceBetweenPoints(point, new PointF(_endX, _endY)));
                    }

                    distanceToFigures.Add(figure, distance);
                }

                // ближайшая (к клику пользователя) фигура из словаря
                var nearFigure = distanceToFigures.Aggregate((l, r) => l.Value < r.Value ? l : r).Key;
                _editContext.SetSelectedFigures(new List<FigureBase>(){nearFigure});
                _editContext.SetActiveState(EditContext.States.FigureEditingState);
            }
        }

        /// <summary>
        /// Выделение областью
        /// </summary>
        private void AreaSelection()
        {
            List<FigureBase> selectedFigures = new List<FigureBase>();
            RectangleF selectionRectangle = new RectangleF(_leftTopX, _leftTopY, 
                _rightBottomX - _leftTopX, _rightBottomY - _leftTopY);
            
            foreach (var figure in _controlUnit.GetDocument().GetFigures())
            {
                if (FigureEditor.IsFigureInRectangle(figure, selectionRectangle))
                {
                    selectedFigures.Add(figure);
                }
            }

            if (selectedFigures.Count > 0)
            {
                _editContext.SetSelectedFigures(selectedFigures);
                _editContext.SetActiveState(EditContext.States.FigureEditingState);
            }
        }
    }
}
