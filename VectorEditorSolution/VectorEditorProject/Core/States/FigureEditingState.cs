using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using SDK;
using VectorEditorProject.Core.Commands;

namespace VectorEditorProject.Core.States
{
    /// <summary>
    /// Состояние редактирования фигуры
    /// </summary>
    public class FigureEditingState : StateBase
    {
        /// <summary>
        /// Edit Context
        /// </summary>
        protected readonly IEditContext _editContext;

        /// <summary>
        /// Control Unit
        /// </summary>
        protected readonly IControlUnit _controlUnit;

        /// <summary>
        /// Левый верхний маркер
        /// </summary>
        protected PointF _leftTopMarker;

        /// <summary>
        /// Правый нижний маркер
        /// </summary>
        protected PointF _rightBottomMarker;

        /// <summary>
        /// Прямоугольник выделения
        /// </summary>
        protected Rectangle _selectionRectangle;

        /// <summary>
        /// Нажата ли кнопка мыши
        /// </summary>
        protected bool _isMousePressed;

        /// <summary>
        /// Подсвечен ли левый верхний маркер
        /// </summary>
        protected bool _isLeftTopMarkerHovered;

        /// <summary>
        /// Подсвечен ли правый нижний маркер
        /// </summary>
        protected bool _isRightBottomMarkerHovered;

        /// <summary>
        /// Ширина фигуры
        /// </summary>
        protected float _fixedWidth;

        /// <summary>
        /// Высота фигуры
        /// </summary>
        protected float _fixedHeight;

        /// <summary>
        /// Расстояние по X до курсора
        /// </summary>
        protected float _deltaXtoCursor;

        /// <summary>
        /// Расстояние по Y до курсора
        /// </summary>
        protected float _deltaYtoCursor;

        /// <summary>
        /// Перемещается ли фигура
        /// </summary>
        protected bool _isFigureMoving;

        /// <summary>
        /// Список опорных точек
        /// </summary>
        protected readonly Dictionary<int, bool> _pointsHovered =
            new Dictionary<int, bool>();

        /// <summary>
        /// Число активных точек
        /// </summary>
        protected int _activePoint = -1;

        /// <summary>
        /// Размер маркера
        /// </summary>
        protected const float _markerSize = 10;

        /// <summary>
        /// Цвет маркера при наведении (выделение)
        /// </summary>
        protected readonly Color _markerHoverColor = Color.DeepPink;

        /// <summary>
        /// Цвет маркера при наведении (опорная точка)
        /// </summary>
        protected readonly Color _markerRefPointHoverColor = Color.Aquamarine;

        /// <summary>
        /// Резервный список фигур
        /// </summary>
        protected readonly List<FigureBase> _backUp = new List<FigureBase>();

        /// <summary>
        /// Конструктор состояния редактирования фигуры
        /// </summary>
        /// <param name="controlUnit">Control Unit</param>
        /// <param name="editContext">Edit Context</param>
        public FigureEditingState(IControlUnit controlUnit, 
            IEditContext editContext)
        {
            _editContext = editContext;
            _controlUnit = controlUnit;
            Initialization();
        }

        /// <summary>
        /// Инициализация
        /// </summary>
        private void Initialization()
        {
            var selectedFigures = _editContext.GetSelectedFigures();
            if (selectedFigures.Count > 0)
            {
                List<PointF> figuresPoints = new List<PointF>();

                foreach (var selectedFigure in selectedFigures)
                {
                    figuresPoints.AddRange(selectedFigure.PointsSettings.GetPoints());
                }

                // инициализация маркеров
                _leftTopMarker = PointsSettings.LeftTopPointF(figuresPoints);
                _rightBottomMarker =
                    PointsSettings.RightBottomPointF(figuresPoints);

                // инициализация прямоугольника выделения
                _selectionRectangle = selectedFigures[0]
                    .GetBorderRectangle();
                foreach (var figure in selectedFigures)
                {
                    _selectionRectangle = Rectangle.Union(_selectionRectangle,
                        figure.GetBorderRectangle());
                }

                // инициализация маркеров опорных точек (точек > 2)
                if (selectedFigures.Count == 1 &&
                    selectedFigures[0].PointsSettings.GetPoints().Count > 2)
                {
                    _pointsHovered.Clear();
                    for (int i = 0; i < selectedFigures[0]
                            .PointsSettings.GetPoints().Count; i++)
                    {
                        _pointsHovered.Add(i, false);
                    }
                }

                _controlUnit.UpdateCanvas();
            }
            else
            {
                _editContext.SetActiveState(States.SelectionState);
            }
        }

        /// <summary>
        /// Рисование
        /// </summary>
        /// <param name="graphics">Объект graphics</param>
        public override void Draw(Graphics graphics)
        {
            var figures = _editContext.GetSelectedFigures();
            if (figures.Count < 1)
            {
                return;
            }

            Pen pen = new Pen(Color.Black);
            pen.DashStyle = DashStyle.Dash;

            graphics.DrawRectangle(pen, _selectionRectangle);
            pen.DashStyle = DashStyle.Solid;

            // рисование маркеров опорных точек (точек > 2)
            if (_pointsHovered.Count != 0)
            {
                var points = figures[0].PointsSettings.GetPoints().ToArray();
                Brush brush = new SolidBrush(_markerRefPointHoverColor);

                for (var i = 0; i < points.Length; i++)
                {
                    graphics.DrawEllipse(pen, 
                        points[i].X - _markerSize / 2, 
                        points[i].Y -_markerSize / 2, 
                        _markerSize, _markerSize);
                    if (_pointsHovered[i])
                    {
                        graphics.FillEllipse(brush,
                            points[i].X - _markerSize / 2,
                            points[i].Y - _markerSize / 2,
                            _markerSize, _markerSize);
                    }
                }

                brush.Dispose();
            }

            //обводка маркеров
            graphics.DrawEllipse(pen,
                _leftTopMarker.X - _markerSize / 2,
                _leftTopMarker.Y - _markerSize / 2,
                _markerSize, _markerSize);
            graphics.DrawEllipse(pen,
                _rightBottomMarker.X - _markerSize / 2,
                _rightBottomMarker.Y - _markerSize / 2,
                _markerSize, _markerSize);

            pen.Dispose();

            // закрашивание левого верхнего маркера при наведении
            if (_isLeftTopMarkerHovered)
            {
                Brush brush = new SolidBrush(_markerHoverColor);

                graphics.FillEllipse(brush,
                    _leftTopMarker.X - _markerSize / 2,
                    _leftTopMarker.Y - _markerSize / 2,
                    _markerSize,
                    _markerSize);

                brush.Dispose();
            }

            // закрашивание правого нижнего маркера при наведении
            if (_isRightBottomMarkerHovered)
            {
                Brush brush = new SolidBrush(_markerHoverColor);

                graphics.FillEllipse(brush,
                    _rightBottomMarker.X - _markerSize / 2,
                    _rightBottomMarker.Y - _markerSize / 2,
                    _markerSize, _markerSize);

                brush.Dispose();
            }
        }

        /// <summary>
        /// Редактирование фигуры
        /// </summary>
        private void EditFigure()
        {
            RectangleF newSize = new RectangleF(
                _leftTopMarker.X, _leftTopMarker.Y,
                _rightBottomMarker.X - _leftTopMarker.X,
                _rightBottomMarker.Y - _leftTopMarker.Y);

            List<PointF> figuresPoints = new List<PointF>();
            foreach (var selectedFigure in _editContext.GetSelectedFigures())
            {
                figuresPoints.AddRange(selectedFigure.PointsSettings.GetPoints());
            }

            var leftTopPoint = PointsSettings.LeftTopPointF(figuresPoints);
            var rightBottomPoint = PointsSettings.RightBottomPointF(figuresPoints);
            var rectWidth = rightBottomPoint.X - leftTopPoint.X;
            var rectHeight = rightBottomPoint.Y - leftTopPoint.Y;

            foreach (var selectedFigure in _editContext.GetSelectedFigures())
            {
                var points = selectedFigure.PointsSettings.GetPoints().ToArray();
                for (int i = 0; i < points.Length; i++)
                {
                    PointF newPoint = new PointF();
                    newPoint.X = newSize.X + newSize.Width *
                                 ((points[i].X - leftTopPoint.X) /
                                  rectWidth);
                    newPoint.Y = newSize.Y + newSize.Height *
                                 ((points[i].Y - leftTopPoint.Y) /
                                  rectHeight);

                    selectedFigure.PointsSettings.ReplacePoint(i, newPoint);
                }
            }

            var selectedFigures = _editContext.GetSelectedFigures();
            _selectionRectangle = selectedFigures[0].GetBorderRectangle();

            foreach (var selectedFigure in selectedFigures)
            {
                _selectionRectangle =
                    Rectangle.Union(_selectionRectangle,
                        selectedFigure.GetBorderRectangle());
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

            // создание резервной копии фигуры (для отката)
            _backUp.Clear();
            foreach (var selectedFigure in _editContext.GetSelectedFigures())
            {
                _backUp.Add(selectedFigure.CopyFigure());
            }

            // выбор редактируемой точки (точек > 2)
            if (_pointsHovered.Count != 0)
            {
                foreach (var keyValuePair in _pointsHovered)
                {
                    if (keyValuePair.Value)
                    {
                        _activePoint = keyValuePair.Key;
                        return;
                    }
                }

                _activePoint = -1;
            }

            // попадание в границы
            if (e.X > _selectionRectangle.X &&
                e.X < _selectionRectangle.X + _selectionRectangle.Width &&
                e.Y > _selectionRectangle.Y &&
                e.Y < _selectionRectangle.Y + _selectionRectangle.Height)
            {
                if (!_isLeftTopMarkerHovered &&
                    !_isRightBottomMarkerHovered)
                {
                    _isFigureMoving = true;
                    // запоминаем габариты выделения 
                    _fixedWidth = _rightBottomMarker.X - _leftTopMarker.X;
                    _fixedHeight = _rightBottomMarker.Y - _leftTopMarker.Y;

                    _deltaXtoCursor = e.X - _selectionRectangle.X;
                    _deltaYtoCursor = e.Y - _selectionRectangle.Y;
                }
            }
            else if (!_isLeftTopMarkerHovered &&
                     !_isRightBottomMarkerHovered)
            {
                _editContext.SetActiveState(States.SelectionState);
            }
        }

        /// <summary>
        /// Перемещение мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void MouseMove(object sender, MouseEventArgs e)
        {
            var figures = _editContext.GetSelectedFigures();
            if (figures.Count == 0)
            {
                return;
            }

            if (_isMousePressed)
            {
                // действия с левым верхним маркером
                if (_isLeftTopMarkerHovered &&
                    e.X < _rightBottomMarker.X &&
                    e.Y < _rightBottomMarker.Y)
                {
                    _leftTopMarker = new PointF(e.X, e.Y);
                    EditFigure();
                    _controlUnit.UpdateCanvas();
                    return;
                }

                // действия с правым нижним маркером
                if (_isRightBottomMarkerHovered &&
                    e.X > _leftTopMarker.X &&
                    e.Y > _leftTopMarker.Y)
                {
                    _rightBottomMarker = new PointF(e.X, e.Y);
                    EditFigure();
                    _controlUnit.UpdateCanvas();
                    return;
                }

                // действия с опорными точками
                if (_activePoint != -1)
                {
                    figures[0].PointsSettings.ReplacePoint(_activePoint,
                            new PointF(e.X, e.Y));

                    List<PointF> figuresPoints = new List<PointF>();
                    foreach (var figure in figures)
                    {
                        figuresPoints.AddRange(figure.PointsSettings.GetPoints());
                    }

                    _leftTopMarker = PointsSettings.LeftTopPointF(figuresPoints);
                    _rightBottomMarker =
                        PointsSettings.RightBottomPointF(figuresPoints);

                    EditFigure();
                    _controlUnit.UpdateCanvas();
                    return;
                }

                // перемещение фигуры
                if (_isFigureMoving)
                {
                    _leftTopMarker.X = e.X - _deltaXtoCursor;
                    _leftTopMarker.Y = e.Y - _deltaYtoCursor;
                    _rightBottomMarker.X = _leftTopMarker.X + _fixedWidth;
                    _rightBottomMarker.Y = _leftTopMarker.Y + _fixedHeight;
                    EditFigure();
                    _controlUnit.UpdateCanvas();
                    return;
                }
            }
            else
            {
                // подсветка маркеров опорных точек
                if (_pointsHovered.Count != 0 && figures.Count > 0)
                {
                    var points = figures[0].PointsSettings.GetPoints()
                        .ToArray();
                    for (var i = 0; i < points.Length; i++)
                    {
                        _pointsHovered[i] = 
                            e.X >= points[i].X - _markerSize / 2 &&
                            e.X <= points[i].X + _markerSize / 2 &&
                            e.Y >= points[i].Y - _markerSize / 2 &&
                            e.Y <= points[i].Y + _markerSize / 2;
                        if (_pointsHovered[i])
                        {
                            _controlUnit.UpdateCanvas();
                            return;
                        }
                    }
                }

                // перерасчет подсвечен или нет маркер (левый)
                _isLeftTopMarkerHovered =
                    e.X >= _leftTopMarker.X - _markerSize / 2 &&
                    e.X <= _leftTopMarker.X + _markerSize / 2 &&
                    e.Y >= _leftTopMarker.Y - _markerSize / 2 &&
                    e.Y <= _leftTopMarker.Y + _markerSize / 2;
                if (_isLeftTopMarkerHovered)
                {
                    _controlUnit.UpdateCanvas();
                    return;
                }

                // перерасчет подсвечен или нет маркер (правый)
                _isRightBottomMarkerHovered =
                    e.X >= _rightBottomMarker.X - _markerSize / 2 &&
                    e.X <= _rightBottomMarker.X + _markerSize / 2 &&
                    e.Y >= _rightBottomMarker.Y - _markerSize / 2 &&
                    e.Y <= _rightBottomMarker.Y + _markerSize / 2;
                if (_isRightBottomMarkerHovered)
                {
                    _controlUnit.UpdateCanvas();
                    return;
                }
            }

            _controlUnit.UpdateCanvas();
        }

        /// <summary>
        /// Отжатие кнопки мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void MouseUp(object sender, MouseEventArgs e)
        {
            _isMousePressed = false;
            _isFigureMoving = false;

            // сохранение изменений пользователя
            List<FigureBase> newValues = new List<FigureBase>();
            foreach (var selectedFigure in _editContext.GetSelectedFigures())
            {
                newValues.Add(selectedFigure.CopyFigure());
            }

            // т.к. пользователь меняет реальные фигуры, делаем откат
            foreach (var figure in _backUp)
            {
                var original = _controlUnit.GetDocument()
                    .GetFigure(figure.guid);
                if (original == null)
                {
                    return;
                }

                original.LineSettings.Color = figure.LineSettings.Color;
                original.LineSettings.Style = figure.LineSettings.Style;
                original.LineSettings.Width = figure.LineSettings.Width;

                if (original is FilledFigureBase originalFilled &&
                    figure is FilledFigureBase filledFigure)
                {
                    originalFilled.FillSettings.Color =
                        filledFigure.FillSettings.Color;
                }

                var points = figure.PointsSettings.GetPoints().ToArray();
                for (var i = 0; i < points.Length; i++)
                {
                    original.PointsSettings.ReplacePoint(i, points[i]);
                }
            }

            // создание команды изменения фигур
            var command = CommandFactory.CreateFiguresChangingCommand(
                _controlUnit, newValues);
            _controlUnit.StoreCommand(command);
            _controlUnit.Do();
        }

        /// <summary>
        /// Обновление
        /// </summary>
        public override void Update()
        {
            Initialization();
        }
    }
}
