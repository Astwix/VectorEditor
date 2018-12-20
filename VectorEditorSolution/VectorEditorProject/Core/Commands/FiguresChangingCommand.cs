using System;
using System.Collections.Generic;
using System.Linq;
using VectorEditorProject.Core.Figures;

namespace VectorEditorProject.Core.Commands
{
    [Serializable]
    public class FiguresChangingCommand : BaseCommand
    {
        [field: NonSerialized] public ControlUnit ControlUnit { get; set; }
        private List<BaseFigure> _oldValues = new List<BaseFigure>();
        private List<BaseFigure> _newValues = new List<BaseFigure>();

        public FiguresChangingCommand(ControlUnit controlUnit, List<BaseFigure> newValues)
        {
            ControlUnit = controlUnit;
            
            var figureFactory = new FigureFactory();
            foreach (var figure in newValues)
            {
                var original = ControlUnit.GetDocument().GetFigure(figure.guid);
                _oldValues.Add(figureFactory.CopyFigure(original));
                _newValues.Add(figureFactory.CopyFigure(figure));
            }
        }

        public FiguresChangingCommand(ControlUnit controlUnit, BaseFigure newValues)
        {
            ControlUnit = controlUnit;

            var figureFactory = new FigureFactory();
            var original = ControlUnit.GetDocument().GetFigure(newValues.guid);
            _oldValues.Add(figureFactory.CopyFigure(original));
            _newValues.Add(figureFactory.CopyFigure(newValues));
        }

        public override void Do()
        {
            AcceptValues(_newValues);
        }

        public override void Undo()
        {
            AcceptValues(_oldValues);
        }

        /// <summary>
        /// Применить изменения к параметрам фигур
        /// </summary>
        /// <param name="values">Изменения</param>
        private void AcceptValues(List<BaseFigure> values)
        {
            foreach (var figure in values)
            {
                // применение параметров линии
                var original = ControlUnit.GetDocument().GetFigure(figure.guid);
                original.LineSettings.Color = figure.LineSettings.Color;
                original.LineSettings.Style = figure.LineSettings.Style;
                original.LineSettings.Width = figure.LineSettings.Width;

                // применение заливки
                if (original is FilledBaseFigure originalFilled && 
                    figure is FilledBaseFigure filledFigure)
                {
                    originalFilled.FillSettings.Color = filledFigure.FillSettings.Color;
                }

                // применение изменений точек
                var points = figure.PointsSettings.GetPoints().ToArray();
                for (var i = 0; i < points.Length; i++)
                {
                    original.PointsSettings.ReplacePoint(i, points[i]);
                }
            }
        }
    }
}
