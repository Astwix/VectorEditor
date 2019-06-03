using System.Collections.Generic;
using System.Drawing;
using SDK;

namespace VectorEditorProject.Core.Commands
{
    /// <summary>
    /// Фабрика команд
    /// </summary>
    public static class CommandFactory
    {
        /// <summary>
        /// Создание команды добавления фигуры
        /// </summary>
        /// <param name="controlUnit">Control Unit</param>
        /// <param name="figure">Фигура</param>
        /// <returns></returns>
        public static CommandBase CreateAddFigureCommand(
            IControlUnit controlUnit, FigureBase figure)
        {
            return new AddFigureCommand(controlUnit, figure);
        }

        /// <summary>
        /// Создание команды добавления фигур
        /// </summary>
        /// <param name="controlUnit">Control Unit</param>
        /// <param name="figures">Список фигур (только для чтения)</param>
        /// <returns></returns>
        public static CommandBase CreateAddFigureCommand(
            IControlUnit controlUnit, IReadOnlyList<FigureBase> figures)
        {
            return new AddFigureCommand(controlUnit, figures);
        }

        /// <summary>
        /// Создание команды добавления точки
        /// </summary>
        /// <param name="figure">Фигура</param>
        /// <param name="point">Точка</param>
        /// <param name="controlUnit">Control Unit</param>
        /// <returns></returns>
        public static CommandBase CreateAddPointCommand(FigureBase figure,
            PointF point, IControlUnit controlUnit)
        {
            return new AddPointCommand(figure, point, controlUnit);
        }

        /// <summary>
        /// Создание команды изменения параметров документа
        /// </summary>
        /// <param name="controlUnit">Control Unit</param>
        /// <param name="newOptions">Новые параметры</param>
        /// <returns>Команда изменения параметров документа</returns>
        public static CommandBase CreateChangingDocumentOptionsCommand(
            IControlUnit controlUnit, Document newOptions)
        {
            return new ChangingDocumentOptionsCommand(controlUnit,
                newOptions);
        }

        /// <summary>
        /// Создание команды очистки документа
        /// </summary>
        /// <param name="controlUnit">Control Unit</param>
        /// <returns>Команда очистки документа</returns>
        public static CommandBase CreateClearDocumentCommand(
            IControlUnit controlUnit)
        {
            return new ClearDocumentCommand(controlUnit);
        }

        /// <summary>
        /// Создание команды изменения фигур
        /// </summary>
        /// <param name="controlUnit">Control Unit</param>
        /// <param name="newValues">Новые значения</param>
        /// <returns>Команда изменения фигур</returns>
        public static CommandBase CreateFiguresChangingCommand(
            IControlUnit controlUnit, List<FigureBase> newValues)
        {
            return new FiguresChangingCommand(controlUnit, newValues);
        }

        /// <summary>
        /// Создание команды изменения фигуры
        /// </summary>
        /// <param name="controlUnit">Control Unit</param>
        /// <param name="newValues">Новые значения</param>
        /// <returns>Команда изменения фигуры</returns>
        public static CommandBase CreateFiguresChangingCommand(
            IControlUnit controlUnit, FigureBase newValues)
        {
            return new FiguresChangingCommand(controlUnit, newValues);
        }

        /// <summary>
        /// Создание команды удаления фигуры
        /// </summary>
        /// <param name="controlUnit">Control Unit</param>
        /// <param name="figure">Фигура</param>
        /// <returns>Команда удаления фигуры</returns>
        public static CommandBase CreateRemoveFigureCommand(
            IControlUnit controlUnit, FigureBase figure)
        {
            return new RemoveFigureCommand(controlUnit, figure);
        }

        /// <summary>
        /// Создание команды удаления фигур
        /// </summary>
        /// <param name="controlUnit">Control Unit</param>
        /// <param name="figures">Список фигур</param>
        /// <returns>Команда удаления фигур</returns>
        public static CommandBase CreateRemoveFigureCommand(
            IControlUnit controlUnit, IReadOnlyList<FigureBase> figures)
        {
            return new RemoveFigureCommand(controlUnit, figures);
        }

        /// <summary>
        /// Починить команды при восстановлении файла
        /// Восстановление ссылки на Control Unit
        /// </summary>
        /// <param name="command">Команда</param>
        /// <param name="controlUnit">Control Unit</param>
        public static void MakeCommandOKAgain(CommandBase command, 
            ControlUnit controlUnit)
        {
            switch (command)
            {
                case AddFigureCommand addFigureCommand:
                    addFigureCommand.ControlUnit = controlUnit;
                    break;

                case AddPointCommand addPointCommand:
                    addPointCommand.ControlUnit = controlUnit;
                    break;

                case ChangingDocumentOptionsCommand
                    changingDocumentOptionsCommand:
                    changingDocumentOptionsCommand.ControlUnit = controlUnit;
                    break;

                case ClearDocumentCommand clearDocumentCommand:
                    clearDocumentCommand.ControlUnit = controlUnit;
                    break;

                case FiguresChangingCommand figuresChangingCommand:
                    figuresChangingCommand.ControlUnit = controlUnit;
                    break;

                case RemoveFigureCommand removeFigureCommand:
                    removeFigureCommand.ControlUnit = controlUnit;
                    break;
            }

        }
    }
}
