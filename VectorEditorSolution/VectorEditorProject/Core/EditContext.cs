using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using VectorEditorProject.Core.Commands;
using VectorEditorProject.Core.States;
using VectorEditorProject.Figures;

namespace VectorEditorProject.Core
{
    public class EditContext
    {
        private ControlUnit _controlUnit;
        private BaseState _activeState;
        private Guid _activeFigureGuid = Guid.Empty;
        private List<Guid> _selectedFigures = new List<Guid>();

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
            AddFigureState,
            SelectionState,
            AddPointState,
            FigureEditingState
        }

        /// <summary>
        /// Установить активное состояние
        /// </summary>
        /// <param name="state">Состояние</param>
        public void SetActiveState(States state)
        {
            switch (state)
            {
                case States.AddFigureState:
                    if (GetSelectedFigures().Count > 0) // если есть выделение - сбросить
                    {
                        var command = new SelectFiguresCommand(this, new List<BaseFigure>());
                        _controlUnit.StoreCommand(command);
                        _controlUnit.Do();
                    }
                    _activeState = new AddFigureState(_controlUnit, this);
                    break;

                case States.AddPointState:
                    _activeState = new AddPointState(_controlUnit, this);
                    break;

                case States.SelectionState:
                    _activeState = new SelectionState(_controlUnit, this);
                    break;
                    
                case States.FigureEditingState:
                    _activeState = new FigureEditingState(_controlUnit, this);
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

        /// <summary>
        /// Выделение фигур (с перебором по фигурам)
        /// </summary>
        /// <param name="figuresList">Список фигур</param>
        public void SetSelectedFigures(List<BaseFigure> figuresList)
        {
            _selectedFigures.Clear();

            foreach (var baseFigure in figuresList)
            {
                _selectedFigures.Add(baseFigure.guid);
            }
        }

        /// <summary>
        /// Выделение фигур (с перебором по guid)
        /// </summary>
        /// <param name="figuresList">Список фигур</param>
        public void SetSelectedFigures(List<Guid> figuresList)
        {
            _selectedFigures.Clear();

            foreach (var guid in figuresList)
            {
                _selectedFigures.Add(guid);
            }
        }

        /// <summary>
        /// Список выделенных фигур, доступный только для чтения
        /// </summary>
        /// <returns></returns>
        public IReadOnlyList<BaseFigure> GetSelectedFigures()
        {
            List<BaseFigure> selectedFigures = new List<BaseFigure>();

            foreach (var guid in _selectedFigures)
            {
                var figure = _controlUnit.GetDocument().GetFigure(guid);

                // если не нашлась фигура - пропускаем
                if (figure == null)
                {
                    continue;
                }

                selectedFigures.Add(figure);
            }

            return selectedFigures;
        }
    }
}
