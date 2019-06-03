using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SDK;
using VectorEditorProject.Core;
using VectorEditorProject.Core.Commands;
using VectorEditorProject.Forms;

namespace VectorEditorTest.Stubs
{
    /// <summary>
    /// 
    /// </summary>
    class ControlUnitStub : ControlUnit
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="figureSettingsControl"></param>
        /// <param name="toolsControl"></param>
        /// <param name="propertyGrid"></param>
        public ControlUnitStub(PictureBox canvas, 
            FigureSettingsControl figureSettingsControl, 
            ToolsControl toolsControl, PropertyGrid propertyGrid) : 
            base(canvas, figureSettingsControl, toolsControl, propertyGrid)
        {
        }

        /// <summary>
        /// Канва
        /// </summary>
        public PictureBox Canvas
        {
            get => _canvas;
        }

        /// <summary>
        /// Редактор свойств
        /// </summary>
        public PropertyGrid PropertyGrid
        {
            get => _propertyGrid;
        }

        /// <summary>
        /// Control настроек фигуры
        /// </summary>
        public FigureSettingsControl FigureSettingsControl
        {
            get => _figureSettingsControl;
        }

        /// <summary>
        /// Control инструментов
        /// </summary>
        public ToolsControl ToolsControl
        {
            get => _toolsControl;
        }

        /// <summary>
        /// Список команд
        /// </summary>
        public List<CommandBase> Commands
        {
            get => _commands;
        }

        /// <summary>
        /// Словарь для обновления view по действию
        /// </summary>
        public Dictionary<Type, List<Action>> ViewUpdateDictionary
        {
            get => _viewUpdateDictionary;
        }

        /// <summary>
        /// Буфер обмена
        /// </summary>
        public List<FigureBase> Clipboard
        {
            get => _clipboard;
        }

        /// <summary>
        /// Текущий документ
        /// </summary>
        public IDocument CurrentDocument
        {
            get => _currentDocument;
        }

        /// <summary>
        /// Текущая команда
        /// </summary>
        public int CurrentCommand
        {
            get => _currentCommand;
        }

        /// <summary>
        /// Резервные свойства
        /// </summary>
        public FigureBase PropertyBackUp
        {
            get => _propertyBackUp;
            set => _propertyBackUp = value;
        }

        /// <summary>
        /// Последний сохраненный хэш
        /// </summary>
        public int LastSavedHash
        {
            get => _lastSavedHash;
            set => _lastSavedHash = value;
        }

        /// <summary>
        /// Расчет текущего хэша
        /// </summary>
        /// <returns></returns>
        public int PublicCalcCurrentHashCode()
        {
            return CalcCurrentHash();
        }

        
    }
}
