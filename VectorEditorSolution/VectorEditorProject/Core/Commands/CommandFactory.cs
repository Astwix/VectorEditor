using System.Collections.Generic;
using System.Drawing;
using VectorEditorProject.Core.Figures;

namespace VectorEditorProject.Core.Commands
{
    public static class CommandFactory
    {
        public static CommandBase CreateAddFigureCommand
            (ControlUnit controlUnit, FigureBase figure)
        {
            return new AddFigureCommand(controlUnit, figure);
        }

        public static CommandBase CreateAddFigureCommand
            (ControlUnit controlUnit, IReadOnlyList<FigureBase> figures)
        {
            return new AddFigureCommand(controlUnit, figures);
        }

        public static CommandBase CreateAddPointCommand
            (FigureBase figure, PointF point, ControlUnit controlUnit)
        {
            return new AddPointCommand(figure, point, controlUnit);
        }

        public static CommandBase CreateChangingDocumentOptionsCommand
            (ControlUnit controlUnit, Document newOptions)
        {
            return new ChangingDocumentOptionsCommand(controlUnit, newOptions);
        }

        public static CommandBase CreateClearDocumentCommand
            (ControlUnit controlUnit)
        {
            return new ClearDocumentCommand(controlUnit);
        }

        public static CommandBase CreateFiguresChangingCommand
            (ControlUnit controlUnit, List<FigureBase> newValues)
        {
            return new FiguresChangingCommand(controlUnit, newValues);
        }

        public static CommandBase CreateFiguresChangingCommand
            (ControlUnit controlUnit, FigureBase newValues)
        {
            return new FiguresChangingCommand(controlUnit, newValues);
        }

        public static CommandBase CreateRemoveFigureCommand(ControlUnit controlUnit, FigureBase figure)
        {
            return new RemoveFigureCommand(controlUnit, figure);
        }

        public static CommandBase CreateRemoveFigureCommand
            (ControlUnit controlUnit, IReadOnlyList<FigureBase> figures)
        {
            return new RemoveFigureCommand(controlUnit, figures);
        }

        public static CommandBase CreateSelectFiguresCommand
            (EditContext editContext, List<FigureBase> selectedFigures)
        {
            return new SelectFiguresCommand(editContext, selectedFigures);
        }

        public static CommandBase CreateSelectFiguresCommand
            (EditContext editContext, FigureBase selectedFigure)
        {
            return new SelectFiguresCommand(editContext, selectedFigure);
        }
    }
}
