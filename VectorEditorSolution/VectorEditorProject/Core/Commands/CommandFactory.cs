using System.Collections.Generic;
using System.Drawing;
using VectorEditorProject.Core.Figures;

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
        public static CommandBase CreateAddFigureCommand
            (ControlUnit controlUnit, FigureBase figure)
        {
            return new AddFigureCommand(controlUnit, figure);
        }

        /// <summary>
        /// Создание команды добавления фигур
        /// </summary>
        /// <param name="controlUnit">Control Unit</param>
        /// <param name="figures">Список фигур (только для чтения)</param>
        /// <returns></returns>
        public static CommandBase CreateAddFigureCommand
            (ControlUnit controlUnit, IReadOnlyList<FigureBase> figures)
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
        public static CommandBase CreateAddPointCommand
            (FigureBase figure, PointF point, ControlUnit controlUnit)
        {
            return new AddPointCommand(figure, point, controlUnit);
        }

        /// <summary>
        /// Создание команды изменения параметров документа
        /// </summary>
        /// <param name="controlUnit">Control Unit</param>
        /// <param name="newOptions">Новые параметры</param>
        /// <returns></returns>
        public static CommandBase CreateChangingDocumentOptionsCommand
            (ControlUnit controlUnit, Document newOptions)
        {
            return new ChangingDocumentOptionsCommand(controlUnit, newOptions);
        }

        /// <summary>
        /// Создание команды очистки документа
        /// </summary>
        /// <param name="controlUnit"></param>
        /// <returns></returns>
        public static CommandBase CreateClearDocumentCommand
            (ControlUnit controlUnit)
        {
            return new ClearDocumentCommand(controlUnit);
        }

        /// <summary>
        /// Создание команды изменения фигур
        /// </summary>
        /// <param name="controlUnit">Control Unit</param>
        /// <param name="newValues">Новые значения</param>
        /// <returns></returns>
        public static CommandBase CreateFiguresChangingCommand
            (ControlUnit controlUnit, List<FigureBase> newValues)
        {
            return new FiguresChangingCommand(controlUnit, newValues);
        }

        /// <summary>
        /// Создание команды изменения фигуры
        /// </summary>
        /// <param name="controlUnit">Control Unit</param>
        /// <param name="newValues">Новые значения</param>
        /// <returns></returns>
        public static CommandBase CreateFiguresChangingCommand
            (ControlUnit controlUnit, FigureBase newValues)
        {
            return new FiguresChangingCommand(controlUnit, newValues);
        }

        /// <summary>
        /// Создание команды удаления фигуры
        /// </summary>
        /// <param name="controlUnit">Control Unit</param>
        /// <param name="figure">Фигура</param>
        /// <returns></returns>
        public static CommandBase CreateRemoveFigureCommand
            (ControlUnit controlUnit, FigureBase figure)
        {
            return new RemoveFigureCommand(controlUnit, figure);
        }

        /// <summary>
        /// Создание команды удаления фигур
        /// </summary>
        /// <param name="controlUnit">Control Unit</param>
        /// <param name="figures">Список фигур</param>
        /// <returns></returns>
        public static CommandBase CreateRemoveFigureCommand
            (ControlUnit controlUnit, IReadOnlyList<FigureBase> figures)
        {
            return new RemoveFigureCommand(controlUnit, figures);
        }
    }
}
