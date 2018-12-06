using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using VectorEditorProject.Core.Commands;
using VectorEditorProject.Figures;
using VectorEditorProject.Figures.Utility;
using VectorEditorProject.Forms;

namespace VectorEditorProject.Core
{
    public class ControlUnit
    {
        private List<BaseCommand> _commands;
        private int _currentCommand;

        private readonly PictureBox _canvas;
        private FigureSettingsControl _figureSettingsControl;
        private ToolsControl _toolsControl;

        private Document _currentDocument = new Document("Untitled", Color.White, new Size(500, 500));

        private Dictionary<Type, Control> _viewUpdateDictionary = new Dictionary<Type, Control>();

        /// <summary>
        /// Конструктор класса управляющего control
        /// </summary>
        public ControlUnit(PictureBox canvas, FigureSettingsControl figureSettingsControl, ToolsControl toolsControl)
        {
            _commands = new List<BaseCommand>();
            _currentCommand = 0;

            _canvas = canvas;
            _figureSettingsControl = figureSettingsControl;
            _toolsControl = toolsControl;

            _viewUpdateDictionary.Add(typeof(AddFigureCommand), _canvas);
            _viewUpdateDictionary.Add(typeof(AddPointCommand), _canvas);
            _viewUpdateDictionary.Add(typeof(ClearDocumentCommand), _canvas);
        }

        /// <summary>
        /// Обновление view по соответствующей команде (команда -> контрол)
        /// Переделать, т.к. надо обновлять не только контролы
        /// </summary>
        /// <param name="command">Команда</param>
        private void UpdateView(BaseCommand command)
        {
            _viewUpdateDictionary[command.GetType()].Invalidate();
        }

        /// <summary>
        /// Добавление команд
        /// </summary>
        /// <param name="command">Команда</param>
        public void StoreCommand(BaseCommand command)
        {
            _commands = _commands.GetRange(0, _currentCommand); // обрезание списка

            _commands.Add(command);
        }

        /// <summary>
        /// Действие
        /// </summary>
        public void Do()
        {
            BaseCommand cmd = null;
            try
            {
                cmd = _commands[_currentCommand];
            }
            catch (Exception e)
            {
                
            }

            if (cmd == null)
            {
                return;
            }

            cmd.Do();
            _currentCommand = _currentCommand + 1;

            UpdateView(cmd);
        }

        /// <summary>
        /// Отмена
        /// </summary>
        public void Undo()
        {
            BaseCommand cmd = null;
            try
            {
                cmd = _commands[_currentCommand - 1];
            }
            catch (Exception e)
            {

            }

            if (cmd == null)
            {
                return;
            }

            cmd.Undo();
            _currentCommand = _currentCommand - 1;

            UpdateView(cmd);
        }

        /// <summary>
        /// Сброс стека
        /// </summary>
        public void Reset()
        {
            _commands = new List<BaseCommand>();
            _currentCommand = 0;
        }

        /// <summary>
        /// Получить документ
        /// </summary>
        /// <returns></returns>
        public Document GetDocument()
        {
            return _currentDocument;
        }

        /// <summary>
        /// Принудительная перерисовка холста
        /// </summary>
        public void UpdateCanvas()
        {
            _canvas.Invalidate();
        }

        /// <summary>
        /// Получить настройки линии
        /// </summary>
        /// <returns></returns>
        public LineSettings GetActiveLineSettings()
        {
            return _figureSettingsControl.GetLineSettings();
        }

        /// <summary>
        /// Получить настройки заливки
        /// </summary>
        /// <returns></returns>
        public FillSettings GetActiveFillSettings()
        {
            return _figureSettingsControl.GetFillSettings();
        }

        /// <summary>
        /// Получить тип фигуры
        /// </summary>
        /// <returns></returns>
        public FigureFactory.Figures GetActiveFigureType()
        {
            return _toolsControl.GetActiveFigureType();
        }
    }
}
