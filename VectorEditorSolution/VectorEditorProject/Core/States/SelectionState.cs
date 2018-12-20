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
    public class SelectionState : BaseState
    {
        private EditContext _editContext;
        private ControlUnit _controlUnit;
        private bool _isMousePressed;

        //todo Заменить точки на прямоугольник
        private int _beginX;
        private int _beginY;
        private int _endX;
        private int _endY;

        private int _leftTopX;
        private int _leftTopY;
        private int _rightBottomX;
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

        public override void MouseDown(object sender, MouseEventArgs e)
        {
            _isMousePressed = true;

            _beginX = e.X;
            _beginY = e.Y;
            _leftTopX = Math.Min(_beginX, _endX);
            _leftTopY = Math.Min(_beginY, _endY);
        }

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
            Dictionary<BaseFigure, float> distanceToFigures = new Dictionary<BaseFigure, float>();

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

                var command = CommandFactory.CreateSelectFiguresCommand(_editContext, nearFigure);
                _controlUnit.StoreCommand(command);
                _controlUnit.Do();

                _editContext.SetActiveState(EditContext.States.FigureEditingState);
            }
        }

        /// <summary>
        /// Выделение областью
        /// </summary>
        private void AreaSelection()
        {
            List<BaseFigure> selectedFigures = new List<BaseFigure>();
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
                var command = CommandFactory.CreateSelectFiguresCommand(_editContext, selectedFigures);
                _controlUnit.StoreCommand(command);
                _controlUnit.Do();

                _editContext.SetActiveState(EditContext.States.FigureEditingState);
            }
        }
    }
}
