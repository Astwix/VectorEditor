using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SDK
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
            DirectoryInfo figuresDirectory
                = new DirectoryInfo(Directory.GetCurrentDirectory());
            FileInfo[] figuresDLLs = figuresDirectory.GetFiles("*.dll");
            foreach (var figureDLL in figuresDLLs)
            {
                var assembly = Assembly.LoadFrom(figureDLL.FullName);
                foreach (var assemblyDefinedType in assembly.DefinedTypes)
                {
                    if (assemblyDefinedType.IsSubclassOf(typeof(FigureBase))
                        && !assemblyDefinedType.IsAbstract)
                    {
                        _figuresTypes.Add(assembly.GetName().Name,
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
            return (FigureBase)Activator.CreateInstance(
                _figuresTypes[figureType]);
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
