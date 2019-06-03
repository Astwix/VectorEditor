using System.Collections.Generic;
using System.Drawing;
using SDK;
using VectorEditorProject.Core;
using VectorEditorProject.Core.States;

namespace VectorEditorTest.Stubs
{
    /// <summary>
    /// Стаб FigureEditingState
    /// </summary>
    class FigureEditingStateStub : FigureEditingState
    {
        /// <summary>
        /// Стаб FigureEditingState
        /// </summary>
        /// <param name="controlUnit">Control Unit</param>
        /// <param name="editContext">Edit Context</param>
        public FigureEditingStateStub(IControlUnit controlUnit, IEditContext editContext) 
            : base(controlUnit, editContext)
        {
        }

        /// <summary>
        /// Edit Context
        /// </summary>
        public IEditContext EditContext
        {
            get => _editContext;
        }

        /// <summary>
        /// Control Unit
        /// </summary>
        public IControlUnit ControlUnit
        {
            get => _controlUnit;
        }

        /// <summary>
        /// Левый верхний маркер
        /// </summary>
        public PointF LeftTopMarker
        {
            get => _leftTopMarker;
            set => _leftTopMarker = value;
        }

        /// <summary>
        /// Правый нижний маркер
        /// </summary>
        public PointF RightBottomMarker
        {
            get => _rightBottomMarker;
            set => _rightBottomMarker = value;
        }

        /// <summary>
        /// Прямоугольник выделения
        /// </summary>
        public Rectangle SelectionRectangle
        {
            get => _selectionRectangle;
            set => _selectionRectangle = value;
        }

        /// <summary>
        /// Ширина фигуры
        /// </summary>
        public float FixedWidth
        {
            get => _fixedWidth;
            set => _fixedWidth = value;
        }

        /// <summary>
        /// Высота фигуры
        /// </summary>
        public float FixedHeight
        {
            get => _fixedHeight;
            set => _fixedHeight = value;
        }

        /// <summary>
        /// Расстояние по X до курсора
        /// </summary>
        public float DeltaXtoCursor
        {
            get => _deltaXtoCursor;
            set => _deltaXtoCursor = value;
        }

        /// <summary>
        /// Расстояние по Y до курсора
        /// </summary>
        public float DeltaYtoCursor
        {
            get => _deltaYtoCursor;
            set => _deltaYtoCursor = value;
        }

        /// <summary>
        /// Нажата ли кнопка мыши
        /// </summary>
        public bool IsMousePressed
        {
            get => _isMousePressed;
            set => _isMousePressed = value;
        }

        /// <summary>
        /// Перемещается ли фигура
        /// </summary>
        public bool IsFigureMoving
        {
            get => _isFigureMoving;
            set => _isFigureMoving = value;
        }

        /// <summary>
        /// Подсвечен ли левый верхний маркер
        /// </summary>
        public bool IsLeftTopMarkerHovered
        {
            get => _isLeftTopMarkerHovered;
            set => _isLeftTopMarkerHovered = value;
        }

        /// <summary>
        /// Подсвечен ли правый нижний маркер
        /// </summary>
        public bool IsRightBottomMarkerHovered
        {
            get => _isRightBottomMarkerHovered;
            set => _isRightBottomMarkerHovered = value;
        }

        /// <summary>
        /// Список опорных точек
        /// </summary>
        public Dictionary<int, bool> PointsHovered
        {
            get => _pointsHovered;
        }

        /// <summary>
        /// Число активных точек
        /// </summary>
        public int ActivePoint
        {
            get => _activePoint;
            set => _activePoint = value;
        }

        /// <summary>
        /// Резервный список фигур
        /// </summary>
        public List<FigureBase> Backup
        {
            get => _backUp;
        }
    }

}
