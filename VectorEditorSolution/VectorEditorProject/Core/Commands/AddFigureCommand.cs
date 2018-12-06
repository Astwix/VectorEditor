using VectorEditorProject.Figures;

namespace VectorEditorProject.Core.Commands
{
    class AddFigureCommand : BaseCommand
    {
        private ControlUnit _controlUnit;
        private BaseFigure _figure;

        /// <summary>
        /// Конструктор создания команды
        /// </summary>
        /// <param name="controlUnit">Control Unit</param>
        /// <param name="figure">Фигура</param>
        public AddFigureCommand(ControlUnit controlUnit, BaseFigure figure)
        {
            _controlUnit = controlUnit;
            _figure = figure;
        }

        /// <summary>
        /// Делай
        /// </summary>
        public override void Do()
        {
            _controlUnit.GetDocument().AddFigure(_figure);
        }

        /// <summary>
        /// Отмена
        /// </summary>
        public override void Undo()
        {
            _controlUnit.GetDocument().DeleteFigure(_figure);
        }
    }
}
