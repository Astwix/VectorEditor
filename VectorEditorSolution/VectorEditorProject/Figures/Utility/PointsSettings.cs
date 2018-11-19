using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorEditorProject.Figures.Utility
{
    class PointsSettings
    {
        private int _limitPoint = 0;
        private List<Point> _points = new List<Point>();

        /// <summary>
        /// Конструктор для безлимитных фигур
        /// </summary>
        public PointsSettings()
        {
        }

        /// <summary>
        /// Конструктор для фигур с лимитным числом точек
        /// </summary>
        /// <param name="limitPoint"></param>
        public PointsSettings(int limitPoint)
        {
            _limitPoint = limitPoint;
        }

        /// <summary>
        /// Добавление точки
        /// </summary>
        /// <param name="point">Точка</param>
        public void AddPoint(Point point)
        {
            if (CanAddPoint())
            {
                _points.Add(point);
            }
        }

        /// <summary>
        /// Возможно ли добавить точку
        /// </summary>
        /// <returns></returns>
        public bool CanAddPoint()
        {
            if (_limitPoint == 0)
            {
                // Если лимита нет (= 0), можно добавлять точки
                return true;
            }

            else
            {
                if (_points.Count < _limitPoint)
                {
                    return true;
                }

                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Возвращает список точек, доступный только для чтения
        /// </summary>
        /// <returns></returns>
        public IReadOnlyList<Point> GetPoints()
        {
            return _points;
        }
    }
}
