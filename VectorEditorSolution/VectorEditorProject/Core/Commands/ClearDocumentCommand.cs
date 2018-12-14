using System.Collections.Generic;
using VectorEditorProject.Core.Figures;

namespace VectorEditorProject.Core.Commands
{
    public class ClearDocumentCommand : BaseCommand
    {
        private ControlUnit _controlUnit;
        private List<BaseFigure> _backUpFigures = new List<BaseFigure>();
        
        public ClearDocumentCommand(ControlUnit controlUnit)
        {
            _controlUnit = controlUnit;
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
            _controlUnit.GetDocument().ClearCanvas();
        }

        /// <summary>
        /// Отмена
        /// </summary>
        public override void Undo()
        {
            foreach (var figure in _backUpFigures)
            {
                _controlUnit.GetDocument().AddFigure(figure);
            }
        }
    }
}
