using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using VectorEditorProject.Core.Commands;
using VectorEditorProject.Core.Drawing;
using VectorEditorProject.Core.Figures;
using VectorEditorProject.Core.Figures.Utility;

namespace VectorEditorProject.Core.States
{
    public class FigureEditingState : BaseState
    {
        private DrawerFactory _drawerFactory = new DrawerFactory();
        private EditContext _editContext;
        private ControlUnit _controlUnit;

        private PointF _leftTopMarker;
        private PointF _rightBottomMarker;

        private bool _isMousePressed;
        private bool _isLeftTopMarkerHovered;
        private bool _isRightBottomMarkerHovered;

        private float _fixedWidth;
        private float _fixedHeight;

        private const float _markerSize = 10;
        private Color _markerHoverColor = Color.DeepPink;
        private List<BaseFigure> _backUp = new List<BaseFigure>();

        public FigureEditingState(ControlUnit controlUnit, EditContext editContext)
        {
            _editContext = editContext;
            _controlUnit = controlUnit;

            var selectedFigures = _editContext.GetSelectedFigures();
            if (selectedFigures.Count > 0)
            {
                _leftTopMarker = FigureEditor.LeftTopPointF(selectedFigures);
                _rightBottomMarker = FigureEditor.RightBottomPointF(selectedFigures);
                _controlUnit.UpdateCanvas();
            }
            else
            {
                _editContext.SetActiveState(EditContext.States.SelectionState);
            }
        }

        public override void Draw(Graphics graphics)
        {
            var figures = _editContext.GetSelectedFigures();
            if (figures.Count < 1)
            {
                return;
            }

            foreach (var figure in figures)
            {
                _drawerFactory.DrawBorder(figure, graphics);
            }

            Pen pen = new Pen(Color.Black);
            pen.DashStyle = DashStyle.Solid;

            //обводка маркеров
            graphics.DrawEllipse(pen, _leftTopMarker.X - _markerSize / 2, 
                _leftTopMarker.Y - _markerSize / 2, _markerSize, _markerSize);
            graphics.DrawEllipse(pen, _rightBottomMarker.X - _markerSize / 2,
                _rightBottomMarker.Y - _markerSize / 2, _markerSize, _markerSize);

            pen.Dispose();

            // закрашивание левого верхнего маркера при наведении
            if (_isLeftTopMarkerHovered)
            {
                Brush brush = new SolidBrush(_markerHoverColor);

                graphics.FillEllipse(brush, _leftTopMarker.X - _markerSize / 2,
                    _leftTopMarker.Y - _markerSize / 2, _markerSize, _markerSize);

                brush.Dispose();
            }

            // закрашивание правого нижнего маркера при наведении
            if (_isRightBottomMarkerHovered)
            {
                Brush brush = new SolidBrush(_markerHoverColor);

                graphics.FillEllipse(brush, _rightBottomMarker.X - _markerSize / 2,
                    _rightBottomMarker.Y - _markerSize / 2, _markerSize, _markerSize);

                brush.Dispose();
            }
        }

        public override void MouseDown(object sender, MouseEventArgs e)
        {
            _isMousePressed = true;
            // запоминаем габариты выделения 
            _fixedWidth = _rightBottomMarker.X - _leftTopMarker.X;
            _fixedHeight = _rightBottomMarker.Y - _leftTopMarker.Y;

            // создание резервной копии фигуры (для отката)
            foreach (var selectedFigure in _editContext.GetSelectedFigures())
            {
                _backUp.Add(new FigureFactory().CopyFigure(selectedFigure));
            }
        }

        public override void MouseMove(object sender, MouseEventArgs e)
        {
            // перемещение маркеров
            if (_isMousePressed)
            {
                if (_isLeftTopMarkerHovered && 
                    e.X < _rightBottomMarker.X && e.Y < _rightBottomMarker.Y)
                {
                    _leftTopMarker = new PointF(e.X, e.Y);
                }
                else if (_isRightBottomMarkerHovered && 
                    e.X > _leftTopMarker.X && e.Y > _leftTopMarker.Y)
                {
                    _rightBottomMarker = new PointF(e.X, e.Y);
                }
            }

            // перерасчет подсвечен или нет маркер (левый)
            if (!_isRightBottomMarkerHovered)
            {
                _isLeftTopMarkerHovered = e.X >= _leftTopMarker.X - _markerSize / 2 &&
                                          e.X <= _leftTopMarker.X + _markerSize / 2 &&
                                          e.Y >= _leftTopMarker.Y - _markerSize / 2 &&
                                          e.Y <= _leftTopMarker.Y + _markerSize / 2;
            }

            // перерасчет подсвечен или нет маркер (правый)
            if (!_isLeftTopMarkerHovered)
            {
                _isRightBottomMarkerHovered = e.X >= _rightBottomMarker.X - _markerSize / 2 && 
                                              e.X <= _rightBottomMarker.X + _markerSize / 2 &&
                                              e.Y >= _rightBottomMarker.Y - _markerSize / 2 &&
                                              e.Y <= _rightBottomMarker.Y + _markerSize / 2;
            }

            // перемещение выделенных фигур
            if (_isMousePressed &&
                !_isLeftTopMarkerHovered &&
                !_isRightBottomMarkerHovered &&
                // внутри выделения
                e.X > _leftTopMarker.X &&
                e.X < _leftTopMarker.X + _fixedWidth &&
                e.Y > _leftTopMarker.Y &&
                e.Y < _leftTopMarker.Y + _fixedHeight)
            {
                _leftTopMarker.X = e.X - _fixedWidth / 2;
                _leftTopMarker.Y = e.Y - _fixedHeight / 2;
                _rightBottomMarker.X = e.X + _fixedWidth / 2;
                _rightBottomMarker.Y = e.Y + _fixedHeight / 2;
            }

            // изменение размеров выделенных фигур
            // соответственно текущему положению маркеров
            if (_isMousePressed && _editContext.GetSelectedFigures().Count > 0)
            {
                FigureEditor.EditFiguresSize(_editContext.GetSelectedFigures(), 
                    new RectangleF(_leftTopMarker.X, _leftTopMarker.Y, 
                        _rightBottomMarker.X - _leftTopMarker.X, 
                        _rightBottomMarker.Y - _leftTopMarker.Y));
            }

            _controlUnit.UpdateCanvas();
        }

        public override void MouseUp(object sender, MouseEventArgs e)
        {
            if (_editContext.GetSelectedFigures().Count == 0)
            {
                _editContext.SetActiveState(EditContext.States.SelectionState);
                return;
            }

            _isMousePressed = false;

            // сохранение изменений пользователя
            List<BaseFigure> newValues = new List<BaseFigure>();
            foreach (var selectedFigure in _editContext.GetSelectedFigures())
            {
                newValues.Add(new FigureFactory().CopyFigure(selectedFigure));
            }

            // т.к. пользователь меняет реальные фигуры
            // делаем откат
            foreach (var figure in _backUp)
            {
                var original = _controlUnit.GetDocument().GetFigure(figure.guid);
                original.LineSettings.Color = figure.LineSettings.Color;
                original.LineSettings.Style = figure.LineSettings.Style;
                original.LineSettings.Width = figure.LineSettings.Width;

                if (original is FilledBaseFigure originalFilled &&
                    figure is FilledBaseFigure filledFigure)
                {
                    originalFilled.FillSettings.Color = filledFigure.FillSettings.Color;
                }

                var points = figure.PointsSettings.GetPoints().ToArray();
                for (var i = 0; i < points.Length; i++)
                {
                    original.PointsSettings.ReplacePoint(i, points[i]);
                }
            }

            // создание команды изменения фигур
            var command = new FiguresChangingCommand(_controlUnit, newValues);
            _controlUnit.StoreCommand(command);
            _controlUnit.Do();
        }

        public override void Update()
        {
            var selectedFigures = _editContext.GetSelectedFigures();
            if (selectedFigures.Count > 0)
            {
                _leftTopMarker = FigureEditor.LeftTopPointF(selectedFigures);
                _rightBottomMarker = FigureEditor.RightBottomPointF(selectedFigures);
                _controlUnit.UpdateCanvas();
            }
            else
            {
                _editContext.SetActiveState(EditContext.States.SelectionState);
            }
        }
    }
}
