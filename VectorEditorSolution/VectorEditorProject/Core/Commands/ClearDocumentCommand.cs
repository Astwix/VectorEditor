using System;
using System.Collections.Generic;
using SDK;

namespace VectorEditorProject.Core.Commands
{
    /// <summary>
    /// Команда очистки документа
    /// </summary>
    [Serializable]
    public class ClearDocumentCommand : CommandBase
    {
        /// <summary>
        /// Control Unit
        /// </summary>
        [field: NonSerialized]
        public IControlUnit ControlUnit { get; set; }

        /// <summary>
        /// Список резервных фигур
        /// </summary>
        private readonly List<FigureBase> _backUpFigures = new List<FigureBase>();

        /// <summary>
        /// Констуктор команды очистки документа
        /// </summary>
        /// <param name="controlUnit">Control Unit</param>
        public ClearDocumentCommand(IControlUnit controlUnit)
        {
            ControlUnit = controlUnit;
            foreach (var figure in controlUnit.GetDocument().GetFigures())
            {
                _backUpFigures.Add(figure);
            }
        }

        /// <summary>
        /// Действие
        /// </summary>
        public override void Do()
        {
            ControlUnit.GetDocument().ClearCanvas();
        }

        /// <summary>
        /// Отмена
        /// </summary>
        public override void Undo()
        {
            foreach (var figure in _backUpFigures)
            {
                ControlUnit.GetDocument().AddFigure(figure);
            }
        }

        /// <summary>
        /// Получить хэш-код
        /// </summary>
        /// <returns>Хэш</returns>
        public override int GetHashCode()
        {
            int hash = -1;
            foreach (var backUpFigure in _backUpFigures)
            {
                hash = hash + backUpFigure.GetHashCode();
            }

            return hash;
        }
    }
}
