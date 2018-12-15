using System.Collections.Generic;
using System.Drawing;
using VectorEditorProject.Core.Figures;

namespace VectorEditorProject.Core.Commands
{
    public static class CommandFactory
    {
        public static BaseCommand CreateAddFigureCommand
            (ControlUnit controlUnit, BaseFigure figure)
        {
            return new AddFigureCommand(controlUnit, figure);
        }

        public static BaseCommand CreateAddFigureCommand
            (ControlUnit controlUnit, IReadOnlyList<BaseFigure> figures)
        {
            return new AddFigureCommand(controlUnit, figures);
        }

        public static BaseCommand CreateAddPointCommand
            (BaseFigure figure, PointF point, ControlUnit controlUnit)
        {
            return new AddPointCommand(figure, point, controlUnit);
        }

        public static BaseCommand CreateChangingDocumentOptionsCommand
            (ControlUnit controlUnit, Document newOptions)
        {
            return new ChangingDocumentOptionsCommand(controlUnit, newOptions);
        }

        public static BaseCommand CreateClearDocumentCommand
            (ControlUnit controlUnit)
        {
            return new ClearDocumentCommand(controlUnit);
        }

        public static BaseCommand CreateFiguresChangingCommand
            (ControlUnit controlUnit, List<BaseFigure> newValues)
        {
            return new FiguresChangingCommand(controlUnit, newValues);
        }

        public static BaseCommand CreateFiguresChangingCommand
            (ControlUnit controlUnit, BaseFigure newValues)
        {
            return new FiguresChangingCommand(controlUnit, newValues);
        }

        public static BaseCommand CreateRemoveFigureCommand(ControlUnit controlUnit, BaseFigure figure)
        {
            return new RemoveFigureCommand(controlUnit, figure);
        }

        public static BaseCommand CreateRemoveFigureCommand
            (ControlUnit controlUnit, IReadOnlyList<BaseFigure> figures)
        {
            return new RemoveFigureCommand(controlUnit, figures);
        }

        public static BaseCommand CreateSelectFiguresCommand
            (EditContext editContext, List<BaseFigure> selectedFigures)
        {
            return new SelectFiguresCommand(editContext, selectedFigures);
        }

        public static BaseCommand CreateSelectFiguresCommand
            (EditContext editContext, BaseFigure selectedFigure)
        {
            return new SelectFiguresCommand(editContext, selectedFigure);
        }
    }
}
