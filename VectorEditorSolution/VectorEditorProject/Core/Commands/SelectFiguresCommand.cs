using System;
using System.Collections.Generic;
using VectorEditorProject.Core.Figures;

namespace VectorEditorProject.Core.Commands
{
    public class SelectFiguresCommand : BaseCommand
    {
        private EditContext _editContext;
        private List<Guid> _doList = new List<Guid>();
        private List<Guid> _undoList = new List<Guid>();

        /// <summary>
        /// Конструктор команды веделения для нескольких фигур
        /// </summary>
        /// <param name="editContext"></param>
        /// <param name="selectedFigures"></param>
        public SelectFiguresCommand(EditContext editContext, List<BaseFigure> selectedFigures)
        {
            _editContext = editContext;

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
        /// <param name="editContext"></param>
        /// <param name="selectedFigure"></param>
        public SelectFiguresCommand(EditContext editContext, BaseFigure selectedFigure)
        {
            _editContext = editContext;

            _doList.Add(selectedFigure.guid);
            
            foreach (var figure in editContext.GetSelectedFigures())
            {
                _undoList.Add(figure.guid);
            }
        }

        public override void Do()
        {
            _editContext.SetSelectedFigures(_doList);
            _editContext.SetActiveState(EditContext.States.FigureEditingState);
        }

        public override void Undo()
        {
            _editContext.SetSelectedFigures(_undoList);
            _editContext.SetActiveState(EditContext.States.FigureEditingState);
        }
    }
}
