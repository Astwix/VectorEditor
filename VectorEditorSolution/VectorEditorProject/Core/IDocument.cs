using System;
using System.Collections.Generic;
using System.Drawing;
using SDK;

namespace VectorEditorProject.Core
{
    /// <summary>
    /// Интерфейс класса Document
    /// </summary>
    public interface IDocument
    {
        /// <summary>
        /// Имя
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Цвет
        /// </summary>
        Color Color { get; set; }

        /// <summary>
        /// Размер
        /// </summary>
        Size Size { get; set; }

        /// <summary>
        /// Добавление фигуры
        /// </summary>
        /// <param name="figure">Фигура</param>
        void AddFigure(FigureBase figure);

        /// <summary>
        /// Удаление фигуры
        /// </summary>
        /// <param name="figure">Фигура</param>
        void DeleteFigure(FigureBase figure);

        /// <summary>
        /// Удаление фигуры по guid
        /// </summary>
        /// <param name="guid">guid фигуры</param>
        void DeleteFigure(Guid guid);

        /// <summary>
        /// Очистка канвы
        /// </summary>
        void ClearCanvas();

        /// <summary>
        /// Возвращает список фигур, доступный только для чтения
        /// </summary>
        /// <returns>Список фигур</returns>
        IReadOnlyList<FigureBase> GetFigures();

        /// <summary>
        /// Получить фигуру по GUID
        /// </summary>
        /// <param name="guid">GUID фигуры</param>
        /// <returns>Фигура</returns>
        FigureBase GetFigure(Guid guid);
    }
}