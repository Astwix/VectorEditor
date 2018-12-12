using System.Collections.Generic;
using VectorEditorProject.Core.Figures;

namespace VectorEditorProject.Core.Commands
{
    public class ClearDocumentCommand : BaseCommand
    {
        private Document _document;
        private List<BaseFigure> _backUpFigures = new List<BaseFigure>();

        public ClearDocumentCommand(Document document)
        {
            _document = document;
            foreach (var figure in document.GetFigures())
            {
                _backUpFigures.Add(figure);
            }
        }

        /// <summary>
        /// Действие
        /// </summary>
        public override void Do()
        {
            _document.ClearCanvas();
        }

        /// <summary>
        /// Отмена
        /// </summary>
        public override void Undo()
        {
            foreach (var figure in _backUpFigures)
            {
                _document.AddFigure(figure);
            }
        }
    }
}
