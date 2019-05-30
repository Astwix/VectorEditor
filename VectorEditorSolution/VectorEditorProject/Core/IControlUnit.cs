using System.IO;
using SDK;
using VectorEditorProject.Core.Commands;

namespace VectorEditorProject.Core
{
    /// <summary>
    /// Интерфейс класса ControlUnit
    /// </summary>
    public interface IControlUnit
    {
        /// <summary>
        /// Edit Context
        /// </summary>
        IEditContext EditContext { get; set; }

        /// <summary>
        /// Удаление
        /// </summary>
        void Delete();

        /// <summary>
        /// Копирование
        /// </summary>
        void Copy();

        /// <summary>
        /// Вставка
        /// </summary>
        void Paste();

        /// <summary>
        /// Обновить состояние
        /// </summary>
        void UpdateState();

        /// <summary>
        /// Обновление Property Grid
        /// </summary>
        void UpdatePropertyGrid();

        /// <summary>
        /// Добавление команд
        /// </summary>
        /// <param name="command">Команда</param>
        void StoreCommand(CommandBase command);

        /// <summary>
        /// Действие
        /// </summary>
        void Do();

        /// <summary>
        /// Отмена
        /// </summary>
        void Undo();

        /// <summary>
        /// Сброс стека
        /// </summary>
        void Reset();

        /// <summary>
        /// Получить документ
        /// </summary>
        /// <returns>Текущий документ</returns>
        IDocument GetDocument();

        /// <summary>
        /// Принудительная перерисовка холста
        /// </summary>
        void UpdateCanvas();

        /// <summary>
        /// Получить настройки линии
        /// </summary>
        /// <returns>Настройки линии</returns>
        LineSettings GetActiveLineSettings();

        /// <summary>
        /// Получить настройки заливки
        /// </summary>
        /// <returns>Настройки заливки</returns>
        FillSettings GetActiveFillSettings();

        /// <summary>
        /// Получить тип фигуры
        /// </summary>
        /// <returns>Тип фигуры</returns>
        string GetActiveFigureType();

        /// <summary>
        /// Десериализация
        /// </summary>
        /// <param name="stream">Поток</param>
        void Deserialize(Stream stream);

        /// <summary>
        /// Сериализация
        /// </summary>
        /// <param name="stream">Поток</param>
        void Serialize(Stream stream);

        /// <summary>
        /// Есть ли несохраненные изменения
        /// </summary>
        /// <returns></returns>
        bool IsFileHaveUnsavedChanges();
    }
}