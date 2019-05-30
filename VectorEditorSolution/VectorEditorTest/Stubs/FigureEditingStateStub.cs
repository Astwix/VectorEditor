using System.Collections.Generic;
using System.Drawing;
using SDK;
using VectorEditorProject.Core;
using VectorEditorProject.Core.States;

namespace VectorEditorTest.Stubs
{
    class FigureEditingStateStub : FigureEditingState
    {
        public FigureEditingStateStub(IControlUnit controlUnit, IEditContext editContext) 
            : base(controlUnit, editContext)
        {
        }

        public IEditContext EditContext
        {
            get => _editContext;
        }

        public IControlUnit ControlUnit
        {
            get => _controlUnit;
        }

        public PointF LeftTopMarker
        {
            get => _leftTopMarker;
            set => _leftTopMarker = value;
        }

        public PointF RightBottomMarker
        {
            get => _rightBottomMarker;
            set => _rightBottomMarker = value;
        }

        public Rectangle SelectionRectangle
        {
            get => _selectionRectangle;
            set => _selectionRectangle = value;
        }

        public float FixedWidth
        {
            get => _fixedWidth;
            set => _fixedWidth = value;
        }

        public float FixedHeight
        {
            get => _fixedHeight;
            set => _fixedHeight = value;
        }

        public float DeltaXtoCursor
        {
            get => _deltaXtoCursor;
            set => _deltaXtoCursor = value;
        }

        public float DeltaYtoCursor
        {
            get => _deltaYtoCursor;
            set => _deltaYtoCursor = value;
        }

        public bool IsMousePressed
        {
            get => _isMousePressed;
            set => _isMousePressed = value;
        }

        public bool IsFigureMoving
        {
            get => _isFigureMoving;
            set => _isFigureMoving = value;
        }

        public bool IsLeftTopMarkerHovered
        {
            get => _isLeftTopMarkerHovered;
            set => _isLeftTopMarkerHovered = value;
        }

        public bool IsRightBottomMarkerHovered
        {
            get => _isRightBottomMarkerHovered;
            set => _isRightBottomMarkerHovered = value;
        }

        public Dictionary<int, bool> PointsHovered
        {
            get => _pointsHovered;
        }

        public int ActivePoint
        {
            get => _activePoint;
            set => _activePoint = value;
        }

        public List<FigureBase> Backup
        {
            get => _backUp;
        }
    }

}
