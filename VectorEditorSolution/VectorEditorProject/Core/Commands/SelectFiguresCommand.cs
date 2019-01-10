using System;
using System.Collections.Generic;
using VectorEditorProject.Core.Figures;

namespace VectorEditorProject.Core.Commands
{
    /// <summary>
    /// Команда выделения фигур
    /// </summary>
    [Serializable]
    public class SelectFiguresCommand : CommandBase
    {
        /// <summary>
        /// Edit Context
        /// </summary>
        [field: NonSerialized] public EditContext EditContext { get; set; }

        /// <summary>
        /// Список действий
        /// </summary>
        private List<Guid> _doList = new List<Guid>();

        /// <summary>
        /// Список отмены
        /// </summary>
        private List<Guid> _undoList = new List<Guid>();

        /// <summary>
        /// Конструктор команды веделения для нескольких фигур
        /// </summary>
        /// <param name="editContext">Edit Context</param>
        /// <param name="selectedFigures">Выделенные фигуры</param>
        public SelectFiguresCommand(EditContext editContext, List<FigureBase> selectedFigures)
        {
            EditContext = editContext;

            foreach (var selectedFigure in selectedFigures)
            {
                _doList.Add(selectedFigure.guid);
            }

            foreach (var selectedFigure in editContext.GetSelectedFigures())
            {
                _undoList.Add(selectedFigure.guid);
            }
        }

        /// <summary>
        /// Конструктор команды веделения для одной фигуры
        /// </summary>
        /// <param name="editContext">Edit Context</param>
        /// <param name="selectedFigure">Выделенная фигура</param>
        public SelectFiguresCommand(EditContext editContext, FigureBase selectedFigure)
        {
            EditContext = editContext;

            _doList.Add(selectedFigure.guid);
            
            foreach (var figure in editContext.GetSelectedFigures())
            {
                _undoList.Add(figure.guid);
            }
        }

        /// <summary>
        /// Действие
        /// </summary>
        public override void Do()
        {
            EditContext.SetSelectedFigures(_doList);
            EditContext.SetActiveState(EditContext.States.FigureEditingState);
        }

        /// <summary>
        /// Отмена
        /// </summary>
        public override void Undo()
        {
            EditContext.SetSelectedFigures(_undoList);
            EditContext.SetActiveState(EditContext.States.FigureEditingState);
        }

        /// <summary>
        /// Получить хэш-код
        /// </summary>
        /// <returns>Хэш</returns>
        public override int GetHashCode()
        {
            int hash = -1;
            foreach (var doGuid in _doList)
            {
                hash = hash + doGuid.GetHashCode();
            }
            foreach (var undoGuid in _undoList)
            {
                hash = hash + undoGuid.GetHashCode();
            }

            return hash;
        }
    }
}
