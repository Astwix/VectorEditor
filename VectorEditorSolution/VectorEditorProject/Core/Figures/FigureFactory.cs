using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using SDK;

namespace VectorEditorProject.Core.Figures
{
    /// <summary>
    /// Фабрика фигур
    /// </summary>
    public class FigureFactory
    {
        /// <summary>
        /// Словарь ссылок на фигуры
        /// </summary>
        private Dictionary<string, Type> _figuresTypes = new Dictionary<string, Type>();

        /// <summary>
        /// Конструктор фабрики фигур
        /// </summary>
        public FigureFactory()
        {
            DirectoryInfo figuresDirectory = new DirectoryInfo(Directory.GetCurrentDirectory());
            FileInfo[] figuresDLLs = figuresDirectory.GetFiles("*Figure.dll");
            foreach (var figureDLL in figuresDLLs)
            {
                var assembly = Assembly.LoadFrom(figureDLL.FullName);
                foreach (var assemblyDefinedType in assembly.DefinedTypes)
                {
                    if (assemblyDefinedType.Name.Contains("Figure"))
                    {
                        int cutAfter = figureDLL.Name.IndexOf("Figure.dll",
                            StringComparison.Ordinal);
                        _figuresTypes.Add(figureDLL.Name.Substring(0, cutAfter), 
                            assemblyDefinedType.AsType());
                    }
                }
            }
        }

        /// <summary>
        /// Создание фигуры
        /// </summary>
        /// <param name="figureType">Тип фигуры</param>
        /// <returns></returns>
        public FigureBase CreateFigure(string figureType)
        {
            return (FigureBase) Activator.CreateInstance(
                _figuresTypes[figureType]);
        }

        /// <summary>
        /// Копирование фигуры
        /// </summary>
        /// <param name="figure">Фигура</param>
        /// <returns>Копия фигуры</returns>
        public FigureBase CopyFigure(FigureBase figure)
        {
            var copy = (FigureBase) Activator.CreateInstance(figure.GetType());
            copy.guid = figure.guid;
            copy.PointsSettings.Clear();
            foreach (var point in figure.PointsSettings.GetPoints())
            {
                copy.PointsSettings.AddPoint(new PointF(point.X, point.Y));
            }

            copy.LineSettings.Color = figure.LineSettings.Color;
            copy.LineSettings.Style = figure.LineSettings.Style;
            copy.LineSettings.Width = figure.LineSettings.Width;

            if (figure is FilledFigureBase filledFigure && copy is FilledFigureBase filledCopy)
            {
                filledCopy.FillSettings.Color = filledFigure.FillSettings.Color;
            }

            return copy;
        }

        /// <summary>
        /// Получить список загруженных фигур
        /// </summary>
        /// <returns></returns>
        public List<string> GetLoadedFigures()
        {
            return _figuresTypes.Keys.ToList();
        }
    }
}
