using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SDK;

namespace VectorEditorProject.Core
{
    /// <summary>
    /// Интерфейс класса EditContext
    /// </summary>
    public interface IEditContext
    {
        /// <summary>
        /// Установить активное состояние
        /// </summary>
        /// <param name="state">Состояние</param>
        void SetActiveState(States.States state);

        /// <summary>
        /// Рисование
        /// </summary>
        /// <param name="graphics"></param>
        void Draw(Graphics graphics);

        /// <summary>
        /// Нажатие кнопки мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MouseDown(object sender, MouseEventArgs e);

        /// <summary>
        /// Перемещение мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MouseMove(object sender, MouseEventArgs e);

        /// <summary>
        /// Отжатие кнопки мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MouseUp(object sender, MouseEventArgs e);

        /// <summary>
        /// Обновление состояния
        /// </summary>
        void UpdateState();

        /// <summary>
        /// Установить активную фигуру
        /// </summary>
        /// <param name="figure">Фигура</param>
        void SetActiveFigure(FigureBase figure);

        /// <summary>
        /// Получить активную фигуру
        /// </summary>
        /// <returns>guid фигуры</returns>
        FigureBase GetActiveFigure();

        /// <summary> 
        /// Установить выделенную фигуру 
        /// </summary> 
        /// <param name="figure">Фигура</param> 
        void SetSelectedFigures(
            Guid figure);

        /// <summary>
        /// Выделение фигур (с перебором по фигурам)
        /// </summary>
        /// <param name="figuresList">Список фигур</param>
        void SetSelectedFigures(List<FigureBase> figuresList);

        /// <summary>
        /// Выделение фигур (с перебором по guid)
        /// </summary>
        /// <param name="figuresList">Список фигур</param>
        void SetSelectedFigures(List<Guid> figuresList);

        /// <summary>
        /// Получить выделенные фигуры
        /// </summary>
        /// <returns>Список выделенных фигур (только для чтения)</returns>
        IReadOnlyList<FigureBase> GetSelectedFigures();
    }
}