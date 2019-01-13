using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using VectorEditorProject.Core.Commands;
using VectorEditorProject.Core.Figures;
using VectorEditorProject.Core.States;

namespace VectorEditorProject.Core
{
    /// <summary>
    /// Edit Context
    /// </summary>
    public class EditContext
    {
        /// <summary>
        /// Control Unit
        /// </summary>
        private ControlUnit _controlUnit;

        /// <summary>
        /// Активное состояние
        /// </summary>
        private StateBase _activeState;

        /// <summary>
        /// Guid активной фигуры
        /// </summary>
        private Guid _activeFigureGuid = Guid.Empty;

        /// <summary>
        /// Список выделенных фигур
        /// </summary>
        private List<Guid> _selectedFigures = new List<Guid>();

        /// <summary>
        /// Конструктор Edit Context
        /// </summary>
        /// <param name="controlUnit"></param>
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
            /// <summary>
            /// Состояние добавления фигуры
            /// </summary>
            AddFigureState,
            /// <summary>
            /// Состояние выделения
            /// </summary>
            SelectionState,
            /// <summary>
            /// Состояние добавления точки
            /// </summary>
            AddPointState,
            /// <summary>
            /// Состояние редактирования фигуры
            /// </summary>
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
                        SetSelectedFigures(new List<FigureBase>());
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

            _controlUnit.UpdateCanvas();
        }

        /// <summary>
        /// Рисование
        /// </summary>
        /// <param name="graphics"></param>
        public void Draw(Graphics graphics)
        {
            _activeState?.Draw(graphics); // суперсахар с "?": создается, только если объект существует
        }

        /// <summary>
        /// Нажатие кнопки мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MouseDown(object sender, MouseEventArgs e)
        {
            _activeState?.MouseDown(sender, e);
        }

        /// <summary>
        /// Перемещение мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MouseMove(object sender, MouseEventArgs e)
        {
            _activeState?.MouseMove(sender, e);
        }

        /// <summary>
        /// Отжатие кнопки мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MouseUp(object sender, MouseEventArgs e)
        {
            _activeState?.MouseUp(sender, e);
        }

        /// <summary>
        /// Обновление состояния
        /// </summary>
        public void UpdateState()
        {
            _activeState?.Update();
        }

        /// <summary>
        /// Установить активную фигуру
        /// </summary>
        /// <param name="figure">Фигура</param>
        public void SetActiveFigure(FigureBase figure)
        {
            _activeFigureGuid = figure.guid;
        }

        /// <summary>
        /// Получить активную фигуру
        /// </summary>
        /// <returns>guid фигуры</returns>
        public FigureBase GetActiveFigure()
        {
            return _controlUnit.GetDocument().GetFigure(_activeFigureGuid);
        }

        /// <summary>
        /// Выделение фигур (с перебором по фигурам)
        /// </summary>
        /// <param name="figuresList">Список фигур</param>
        public void SetSelectedFigures(List<FigureBase> figuresList)
        {
            _selectedFigures.Clear();

            foreach (var baseFigure in figuresList)
            {
                _selectedFigures.Add(baseFigure.guid);
            }

            _controlUnit.UpdatePropertyGrid();
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

            _controlUnit.UpdatePropertyGrid();
        }

        /// <summary>
        /// Получить выделенные фигуры
        /// </summary>
        /// <returns>Список выделенных фигур (только для чтения)</returns>
        public IReadOnlyList<FigureBase> GetSelectedFigures()
        {
            List<FigureBase> selectedFigures = new List<FigureBase>();

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
