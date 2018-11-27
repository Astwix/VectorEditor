using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorEditorProject.Figures;

namespace VectorEditorProject.Core.Commands
{
    class AddFigureCommand : BaseCommand
    {
        private Document _document = null;
        private BaseFigure _figure = null;

        /// <summary>
        /// Конструктор создания команды
        /// </summary>
        /// <param name="document">Документ</param>
        /// <param name="figure">Фигура</param>
        public AddFigureCommand(Document document, BaseFigure figure)
        {
            _document = document;
            _figure = figure;
        }

        /// <summary>
        /// Делай
        /// </summary>
        public override void Do()
        {
            _document.AddFigure(_figure);
        }

        /// <summary>
        /// Отмена
        /// </summary>
        public override void Undo()
        {
            _document.DeleteFigure(_figure);
        }
    }
}
