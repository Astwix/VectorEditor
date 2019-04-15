using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK
{
    /// <summary>
    /// Настройки точек
    /// </summary>
    [Serializable]
    [Browsable(false)]
    public class PointsSettings
    {
        /// <summary>
        /// Лимит точек
        /// </summary>
        private readonly int _limitPoint = 0;

        /// <summary>
        /// Список точек
        /// </summary>
        private readonly List<PointF> _points = new List<PointF>();

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
        public void AddPoint(PointF point)
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
        /// <returns>Список точек</returns>
        public IReadOnlyList<PointF> GetPoints()
        {
            return _points;
        }

        /// <summary>
        /// Перемещение точки
        /// </summary>
        /// <param name="n">Индекс точки в массиве точек</param>
        /// <param name="p">Точка</param>
        public void ReplacePoint(int n, PointF p)
        {
            _points[n] = p;
        }

        /// <summary>
        /// Удаление точки
        /// </summary>
        /// <param name="point">Точка</param>
        public void DeletePoint(PointF point)
        {
            _points.Remove(point);
        }

        /// <summary>
        /// Удаление последней точки
        /// </summary>
        public void RemoveLast()
        {
            _points.RemoveAt(_points.Count - 1);
        }

        /// <summary>
        /// Получить хэш-код
        /// </summary>
        /// <returns>Хэш</returns>
        public override int GetHashCode()
        {
            int hash = -1;
            foreach (var point in _points)
            {
                hash = hash + point.GetHashCode();
            }

            return hash;
        }

        /// <summary>
        /// Возвращает верхнюю левую граничную точку фигуры 
        /// Грубо говоря верхний левый угол прямоугольника в который вписана фигура 
        /// То есть для фигуры из точек (0,1) и (1,0) результат будет (0,0)
        /// </summary>
        /// <param name="points">Список точек</param>
        /// <returns>Первый элемент списка точек у списка фигур</returns>
        public static PointF LeftTopPointF(
            List<PointF> points)
        {
            var result = points[0];
            foreach (var point in points)
            {
                result.X = Math.Min(result.X, point.X);
                result.Y = Math.Min(result.Y, point.Y);
            }

            return result;
        }

        /// <summary>
        /// Возвращает верхнюю левую граничную точку фигуры 
        /// Грубо говоря верхний левый угол прямоугольника в который вписана фигура 
        /// То есть для фигуры из точек (0,1) и (1,0) результат будет (0,0)
        /// </summary>
        /// <returns></returns>
        public PointF LeftTopPointF()
        {
            return LeftTopPointF(_points);
        }

        /// <summary>
        /// Возвращает нижнюю правую граничную точку фигуры 
        /// Грубо говоря нижний правый угол прямоугольника в который вписана фигура 
        /// То есть для фигуры из точек (0,1) и (1,0) результат будет (1,1) 
        /// </summary>
        /// <param name="points">Список точек</param>
        /// <returns></returns>
        public static PointF RightBottomPointF(
            List<PointF> points)
        {
            var result = points[0];
            foreach (var point in points)
            {
                result.X = Math.Max(result.X, point.X);
                result.Y = Math.Max(result.Y, point.Y);
            }

            return result;
        }

        /// <summary>
        /// Возвращает нижнюю правую граничную точку фигуры 
        /// Грубо говоря нижний правый угол прямоугольника в который вписана фигура 
        /// То есть для фигуры из точек (0,1) и (1,0) результат будет (1,1)
        /// </summary>
        /// <returns></returns>
        public PointF RightBottomPointF()
        {
            return RightBottomPointF(_points);
        }

        /// <summary>
        /// Попала ли фигура в выделение
        /// </summary>
        /// <param name="rectangle">Прямоугольник выделения</param>
        /// <returns></returns>
        public bool IsFigureInRectangle(RectangleF rectangle)
        {
            foreach (var point in _points)
            {
                if (point.X <= rectangle.X) // левая граница выделения
                {
                    return false;
                }

                if (point.X >= rectangle.X + rectangle.Width
                ) // правая граница выделения
                {
                    return false;
                }

                if (point.Y <= rectangle.Y) // верхняя граница выделения
                {
                    return false;
                }

                if (point.Y >= rectangle.Y + rectangle.Height
                ) // нижняя граница выделения
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Метод для соразмерного (пропорционального) изменения фигур
        /// </summary>
        /// <param name="newSize">Новая область</param>
        public void EditFiguresSize(RectangleF newSize)
        {
            var leftTopPoint = LeftTopPointF();
            var rightBottomPoint = RightBottomPointF();

            var rectangleWidth = rightBottomPoint.X - leftTopPoint.X;
            var rectangleHeight = rightBottomPoint.Y - leftTopPoint.Y;

            var points = _points.ToArray();
            for (int i = 0; i < points.Length; i++)
            {
                PointF newPoint = new PointF();

                newPoint.X = newSize.X + newSize.Width *
                             ((points[i].X - leftTopPoint.X) /
                              rectangleWidth);
                newPoint.Y = newSize.Y + newSize.Height *
                             ((points[i].Y - leftTopPoint.Y) /
                              rectangleHeight);

                ReplacePoint(i, newPoint);
            }
        }

        /// <summary>
        /// Расчет расстояния между точками
        /// </summary>
        /// <param name="point1">Первая точка</param>
        /// <param name="point2">Вторая точка</param>
        /// <returns>Расстояние между точками</returns>
        public static float DistanceBetweenPoints(PointF point1, PointF point2)
        {
            float deltaX = Math.Abs(point1.X - point2.X);
            float deltaY = Math.Abs(point1.Y - point2.Y);

            return (float)Math.Sqrt(Math.Pow(deltaX, 2) +
                                    Math.Pow(deltaY, 2));
        }

        /// <summary>
        /// Очистка точек
        /// </summary>
        public void Clear()
        {
            _points.Clear();
        }
    }
}
