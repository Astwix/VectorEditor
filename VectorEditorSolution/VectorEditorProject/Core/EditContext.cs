using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VectorEditorProject.Core.States;
using VectorEditorProject.Figures;

namespace VectorEditorProject.Core
{
    public class EditContext
    {
        private ControlUnit _controlUnit;
        private BaseState _activeState;
        private Guid _activeFigureGuid = Guid.Empty;

        public EditContext(ControlUnit controlUnit)
        {
            _controlUnit = controlUnit;

            SetActiveState(States.SelectionState);
        }

        /// <summary>
        /// Перечисление состояний
        /// </summary>
        public enum States
        {
            AddLineState,
            AddPolylineState,
            AddPlygonState,
            AddCircleState,
            AddEllipseState,

            SelectionState,

            AddPointState
        }

        /// <summary>
        /// Установить активное состояние
        /// </summary>
        /// <param name="state"></param>
        public void SetActiveState(States state)
        {
            // todo (уменьшить) упростить количество состояний
            switch (state)
            {
                case States.AddLineState:
                    _activeState = new AddLineState(_controlUnit);
                    break;

                case States.AddCircleState:
                    _activeState = new AddCircleState(_controlUnit);
                    break;

                case States.AddEllipseState:
                    _activeState = new AddEllipseState(_controlUnit);
                    break;

                case States.AddPolylineState:
                    _activeState = new AddPolylineState(_controlUnit, this);
                    break;

                case States.AddPlygonState:
                    _activeState = new AddPolygonState(_controlUnit, this);
                    break;

                case States.AddPointState:
                    _activeState = new AddPointState(_controlUnit, this);
                    break;

                case States.SelectionState:
                    _activeState = new SelectionState(_controlUnit);
                    break;

                default:
                    _activeState = null;
                    break;
            }
        }

        public void Draw(Graphics graphics)
        {
            _activeState?.Draw(graphics); // суперсахар с "?": создается, только если объект существует
        }

        public void MouseDown(object sender, MouseEventArgs e)
        {
            _activeState?.MouseDown(sender, e);
        }

        public void MouseMove(object sender, MouseEventArgs e)
        {
            _activeState?.MouseMove(sender, e);
        }

        public void MouseUp(object sender, MouseEventArgs e)
        {
            _activeState?.MouseUp(sender, e);
        }

        /// <summary>
        /// Установить активную фигуру
        /// </summary>
        /// <param name="figure">Фигура</param>
        public void SetActiveFigure(BaseFigure figure)
        {
            _activeFigureGuid = figure.guid;
        }

        /// <summary>
        /// Получить активную фигуру
        /// </summary>
        /// <returns></returns>
        public BaseFigure GetActiveFigure()
        {
            return _controlUnit.GetDocument().GetFigure(_activeFigureGuid);
        }
    }
}
