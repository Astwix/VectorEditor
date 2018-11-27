using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorEditorProject.Figures;

namespace VectorEditorProject.Core
{
    public class Document
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public Size Size { get; set; }
        private List<BaseFigure> Figures { get; set; }

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
            Figures = new List<BaseFigure>();
        }

        /// <summary>
        /// Добавление фигуры
        /// </summary>
        /// <param name="figure">Фигура</param>
        public void AddFigure(BaseFigure figure)
        {
            Figures.Add(figure);
        }

        /// <summary>
        /// Удаление фигуры
        /// </summary>
        /// <param name="figure">Фигура</param>
        public void DeleteFigure(BaseFigure figure)
        {
            Figures.Remove(figure);
        }

        /// <summary>
        /// Удаление фигуры по guid
        /// </summary>
        /// <param name="guid">guid фигуры</param>
        public void DeleteFigure(Guid guid)
        {
            foreach (BaseFigure figure in Figures)
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
        private IReadOnlyList<BaseFigure> GetFigures()
        {
            return Figures;
        }
    }
}
