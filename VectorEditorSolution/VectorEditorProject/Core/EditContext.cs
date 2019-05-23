using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SDK;
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
        protected readonly IControlUnit _controlUnit;

        /// <summary>
        /// Активное состояние
        /// </summary>
        protected StateBase _activeState;

        /// <summary>
        /// Guid активной фигуры
        /// </summary>
        protected Guid _activeFigureGuid = Guid.Empty;

        /// <summary>
        /// Список выделенных фигур
        /// </summary>
        protected readonly List<Guid> _selectedFigures = new List<Guid>();

        /// <summary>
        /// Конструктор Edit Context
        /// </summary>
        /// <param name="controlUnit"></param>
        public EditContext(IControlUnit controlUnit)
        {
            _controlUnit = controlUnit;

            SetActiveState(States.States.SelectionState);
        }

        /// <summary>
        /// Установить активное состояние
        /// </summary>
        /// <param name="state">Состояние</param>
        public void SetActiveState(States.States state)
        {
            switch (state)
            {
                case States.States.AddFigureState:
                    // если есть выделение - сбросить
                    if (GetSelectedFigures().Count > 0)
                    {
                        SetSelectedFigures(new List<FigureBase>());
                    }

                    _activeState = new AddFigureState(_controlUnit,
                        this);
                    break;

                case States.States.AddPointState:
                    _activeState = new AddPointState(_controlUnit,
                        this);
                    break;

                case States.States.SelectionState:
                    _activeState = new SelectionState(_controlUnit,
                        this);
                    break;

                case States.States.FigureEditingState:
                    _activeState = new FigureEditingState(_controlUnit,
                        this);
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
            // суперсахар с "?": создается, только если объект существует
            _activeState?.Draw(graphics); 
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
        /// Установить выделенную фигуру 
        /// </summary> 
        /// <param name="figure">Фигура</param> 
        public void SetSelectedFigures(
            Guid figure)
        {
            _selectedFigures.Clear();
            _selectedFigures.Add(figure);
            _controlUnit.UpdatePropertyGrid();
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
