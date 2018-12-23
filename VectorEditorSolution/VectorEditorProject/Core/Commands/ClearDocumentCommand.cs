using System;
using System.Collections.Generic;
using VectorEditorProject.Core.Figures;

namespace VectorEditorProject.Core.Commands
{
    [Serializable]
    public class ClearDocumentCommand : BaseCommand
    {
        [field: NonSerialized] public ControlUnit ControlUnit { get; set; }
        private List<BaseFigure> _backUpFigures = new List<BaseFigure>();
        
        public ClearDocumentCommand(ControlUnit controlUnit)
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
