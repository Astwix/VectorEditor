using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDK;
using StructureMap;

namespace VectorEditorProject.Core
{
    /// <summary>
    /// Синглтон, содежащий DI контейнер
    /// </summary>
    public class DI
    {
        /// <summary>
        /// Instance синглтона
        /// </summary>
        private static DI instance;

        /// <summary>
        /// Приватный контруктор
        /// </summary>
        private DI()
        {
            Container = new Container(expression =>
            {
                expression.Scan(scanner =>
                {
                    scanner.AssembliesAndExecutablesFromApplicationBaseDirectory();

                    //Для создания фигур и дроверов по ключам
                    //- использование контейнера как фабрики

                    scanner.AddAllTypesOf<FigureBase>().NameBy(type 
                        => type.Assembly.GetName().Name);
                    scanner.AddAllTypesOf<DrawerBase>().NameBy(type 
                        => type.Assembly.GetName().Name);

                    //Магия разрешения зависимостей на примере

                });
            });
        }

        /// <summary>
        /// Получить Instance синглтона
        /// </summary>
        /// <returns></returns>
        public static DI getInstance()
        {
            if (instance == null)
                instance = new DI();
            return instance;
        }

        /// <summary>
        /// Свойства (хранилище) для контейнера
        /// </summary>
        public Container Container { get; }
    }

}
