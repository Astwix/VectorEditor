using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SDK;
using VectorEditorProject.Core;
using VectorEditorProject.Core.Commands;
using VectorEditorProject.Forms;

namespace VectorEditorTest.Stubs
{
    class ControlUnitStub : ControlUnit
    {
        public ControlUnitStub(PictureBox canvas, FigureSettingsControl figureSettingsControl, 
            ToolsControl toolsControl, PropertyGrid propertyGrid) : 
            base(canvas, figureSettingsControl, toolsControl, propertyGrid)
        {
        }

        public PictureBox Canvas
        {
            get => _canvas;
        }

        public PropertyGrid PropertyGrid
        {
            get => _propertyGrid;
        }

        public FigureSettingsControl FigureSettingsControl
        {
            get => _figureSettingsControl;
        }

        public ToolsControl ToolsControl
        {
            get => _toolsControl;
        }

        public List<CommandBase> Commands
        {
            get => _commands;
        }

        public Dictionary<Type, List<Action>> ViewUpdateDictionary
        {
            get => _viewUpdateDictionary;
        }

        public List<FigureBase> Clipboard
        {
            get => _clipboard;
        }

        public IDocument CurrentDocument
        {
            get => _currentDocument;
        }

        public int CurrentCommand
        {
            get => _currentCommand;
        }

        public FigureBase PropertyBackUp
        {
            get => _propertyBackUp;
            set => _propertyBackUp = value;
        }

        public int LastSavedHash
        {
            get => _lastSavedHash;
            set => _lastSavedHash = value;
        }

        public int PublicCalcCurrentHashCode()
        {
            return CalcCurrentHash();
        }

        
    }
}
