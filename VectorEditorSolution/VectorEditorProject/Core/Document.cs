using System;
using System.Collections.Generic;
using System.Drawing;
using SDK;
using VectorEditorProject.Core.Figures;

namespace VectorEditorProject.Core
{
    /// <summary>
    /// Документ
    /// </summary>
    public class Document
    {
        /// <summary>
        /// Имя
        /// </summary>
        private string _name;

        /// <summary>
        /// Размер
        /// </summary>
        private Size _size;

        /// <summary>
        /// Имя
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                if (value.Length > 0 && value.Length < 50)
                {
                    _name = value;
                }
            } 
        }

        /// <summary>
        /// Цвет
        /// </summary>
        public Color Color
        {
            get;
            set;
        }

        /// <summary>
        /// Размер
        /// </summary>
        public Size Size
        {
            get => _size;
            set
            {
                if (value.Width >= 5 && value.Height >= 5)
                {
                    _size = value;
                }
            }
        }

        /// <summary>
        /// Фигуры
        /// </summary>
        private List<FigureBase> Figures
        {
            get;
            set;
        }

        /// <summary>
        /// Конструктор документа
        /// </summary>
        /// <param name="name">Название</param>
        /// <param name="color">Цвет канвы</param>
        /// <param name="size">Размер канвы</param>
        public Document(string name, Color color, Size size)
        {
            Name = name;
            Color = color;
            Size = size;
            Figures = new List<FigureBase>();
        }

        /// <summary>
        /// Добавление фигуры
        /// </summary>
        /// <param name="figure">Фигура</param>
        public void AddFigure(FigureBase figure)
        {
            Figures.Add(figure);
        }

        /// <summary>
        /// Удаление фигуры
        /// </summary>
        /// <param name="figure">Фигура</param>
        public void DeleteFigure(FigureBase figure)
        {
            DeleteFigure(figure.guid);
        }

        /// <summary>
        /// Удаление фигуры по guid
        /// </summary>
        /// <param name="guid">guid фигуры</param>
        public void DeleteFigure(Guid guid)
        {
            foreach (FigureBase figure in Figures)
            {
                if (figure.guid == guid)
                {
                    Figures.Remove(figure);
                    break;
                }
            }
        }

        /// <summary>
        /// Очистка канвы
        /// </summary>
        public void ClearCanvas()
        {
            Figures.Clear();
        }

        /// <summary>
        /// Возвращает список фигур, доступный только для чтения
        /// </summary>
        /// <returns>Список фигур</returns>
        public IReadOnlyList<FigureBase> GetFigures()
        {
            return Figures;
        }

        /// <summary>
        /// Получить фигуру по GUID
        /// </summary>
        /// <param name="guid">GUID фигуры</param>
        /// <returns>Фигура</returns>
        public FigureBase GetFigure(Guid guid)
        {
            foreach (var figure in Figures)
            {
                if (figure.guid.Equals(guid))
                {
                    return figure;
                }
            }

            return null;
        }
    }
}
