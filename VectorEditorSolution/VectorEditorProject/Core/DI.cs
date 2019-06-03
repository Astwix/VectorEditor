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
        private static DI _instance;

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
        public static DI GetInstance()
        {
            if (_instance == null)
                _instance = new DI();
            return _instance;
        }

        /// <summary>
        /// Свойства (хранилище) для контейнера
        /// </summary>
        public Container Container { get; }
    }

}
