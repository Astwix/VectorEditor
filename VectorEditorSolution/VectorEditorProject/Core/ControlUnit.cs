using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using SDK;
using VectorEditorProject.Core.Commands;
using VectorEditorProject.Forms;

namespace VectorEditorProject.Core
{
    /// <summary>
    /// Control Unit
    /// </summary>
    public class ControlUnit
    {
        /// <summary>
        /// Список команд
        /// </summary>
        private List<CommandBase> _commands;

        /// <summary>
        /// Текущая команда
        /// </summary>
        private int _currentCommand;

        /// <summary>
        /// Edit Context
        /// </summary>
        public EditContext EditContext
        {
            get;
            set;
        }

        /// <summary>
        /// Последний сохраненный хэш
        /// </summary>
        private int _lastSavedHash = -1;

        /// <summary>
        /// Канва
        /// </summary>
        private readonly PictureBox _canvas;

        /// <summary>
        /// Control настроек фигуры
        /// </summary>
        private readonly FigureSettingsControl _figureSettingsControl;

        /// <summary>
        /// Control инструментов
        /// </summary>
        private readonly ToolsControl _toolsControl;

        /// <summary>
        /// Редактор свойств
        /// </summary>
        private readonly PropertyGrid _propertyGrid;

        /// <summary>
        /// Резервные свойства
        /// </summary>
        private FigureBase _propertyBackUp;

        /// <summary>
        /// Буфер обмена
        /// </summary>
        private readonly List<FigureBase> _clipboard = new List<FigureBase>();

        /// <summary>
        /// Текущий документ
        /// </summary>
        private readonly Document _currentDocument = new Document("Untitled",
            Color.White, new Size(400, 400));

        /// <summary>
        /// Словарь для обновления view по действию
        /// </summary>
        private readonly Dictionary<Type, List<Action>> _viewUpdateDictionary;

        /// <summary>
        /// Конструктор класса Control Unit
        /// </summary>
        public ControlUnit(PictureBox canvas,
            FigureSettingsControl figureSettingsControl,
            ToolsControl toolsControl, PropertyGrid propertyGrid)
        {
            _commands = new List<CommandBase>();
            _currentCommand = 0;

            _canvas = canvas;
            _figureSettingsControl = figureSettingsControl;
            _toolsControl = toolsControl;
            _propertyGrid = propertyGrid;

            _propertyGrid.PropertyValueChanged +=
                new PropertyValueChangedEventHandler(this
                    .PropertyGrid_PropertyValueChanged);
            _propertyGrid.SelectedObjectsChanged +=
                new EventHandler(this.PropertyGrid_SelectedObjectsChanged);

            _viewUpdateDictionary = new Dictionary<Type, List<Action>>
            {
                {
                    typeof(AddFigureCommand),
                    new List<Action>() {UpdateState, UpdateCanvas}
                },
                {
                    typeof(AddPointCommand),
                    new List<Action>() {UpdateState, UpdateCanvas}
                },
                {
                    typeof(ClearDocumentCommand),
                    new List<Action>() {UpdateState, UpdateCanvas}
                },
                {
                    typeof(FiguresChangingCommand),
                    new List<Action>() {UpdateState, UpdateCanvas}
                },
                {
                    typeof(RemoveFigureCommand),
                    new List<Action>()
                    {
                        UpdateState, UpdateCanvas, UpdatePropertyGrid
                    }
                },
                {
                    typeof(ChangingDocumentOptionsCommand),
                    new List<Action>() {UpdateState, UpdateCanvas}
                }
            };

        }

        /// <summary>
        /// Удаление
        /// </summary>
        public void Delete()
        {
            var figures = EditContext.GetSelectedFigures();
            if (figures.Count > 0)
            {
                var command = CommandFactory.CreateRemoveFigureCommand(
                    this, figures);
                StoreCommand(command);
                Do();
            }
        }

        /// <summary>
        /// Копирование
        /// </summary>
        public void Copy()
        {
            _clipboard.Clear();
            var figureFactory = new FigureFactory();
            foreach (var selectedFigure in EditContext.GetSelectedFigures())
            {
                _clipboard.Add(figureFactory.CopyFigure(selectedFigure));
            }
        }

        /// <summary>
        /// Вставка
        /// </summary>
        public void Paste()
        {
            if (_clipboard.Count == 0)
            {
                return;
            }

            var figureFactory = new FigureFactory();
            var copiedClipboard = new List<FigureBase>();

            foreach (var figure in _clipboard)
            {
                var copy = figureFactory.CopyFigure(figure);
                copy.guid = Guid.NewGuid();

                var leftTopPoint = copy.PointsSettings.LeftTopPointF();
                var rightBottomPoint = copy.PointsSettings.RightBottomPointF();
                var rectangle = new RectangleF(0, 0,
                    rightBottomPoint.X - leftTopPoint.X,
                    rightBottomPoint.Y - leftTopPoint.Y);

                copy.PointsSettings.EditFiguresSize(rectangle);

                copiedClipboard.Add(copy);
            }

            EditContext.SetSelectedFigures(new List<FigureBase>());

            var command = CommandFactory.CreateAddFigureCommand(this,
                copiedClipboard);
            StoreCommand(command);
            Do();

            EditContext.SetSelectedFigures(copiedClipboard);

            EditContext.SetActiveState(States.States.FigureEditingState);
        }

        /// <summary>
        /// Обновить состояние
        /// </summary>
        private void UpdateState()
        {
            EditContext.UpdateState();
        }

        /// <summary>
        /// Обновление view по соответствующей команде
        /// </summary>
        /// <param name="command">Команда</param>
        private void UpdateView(CommandBase command)
        {
            var actionList = _viewUpdateDictionary[command.GetType()];
            foreach (var action in actionList)
            {
                action();
            }
        }

        /// <summary>
        /// Обновление Property Grid
        /// </summary>
        public void UpdatePropertyGrid()
        {
            if (EditContext.GetSelectedFigures().Count == 1)
            {
                var figure = EditContext.GetSelectedFigures()[0];

                if (figure is FilledFigureBase filledFigure)
                {
                    _propertyGrid.SelectedObject = filledFigure;
                }
                else
                {
                    _propertyGrid.SelectedObject = figure;
                }

                _propertyGrid.ExpandAllGridItems();
            }
            else
            {
                _propertyGrid.SelectedObject = null;
            }
        }

        /// <summary>
        /// Добавление команд
        /// </summary>
        /// <param name="command">Команда</param>
        public void StoreCommand(CommandBase command)
        {
            // обрезание списка
            _commands = _commands.GetRange(0, _currentCommand); 

            _commands.Add(command);
        }

        /// <summary>
        /// Действие
        /// </summary>
        public void Do()
        {
            CommandBase command = null;
            try
            {
                command = _commands[_currentCommand];
            }
            catch (ArgumentOutOfRangeException e)
            {
                // В массиве нет больше команд, которые можно применить
                System.Media.SystemSounds.Beep.Play();
            }

            if (command == null)
            {
                return;
            }

            command.Do();
            _currentCommand = _currentCommand + 1;

            UpdateView(command);
        }

        /// <summary>
        /// Отмена
        /// </summary>
        public void Undo()
        {
            CommandBase command = null;
            try
            {
                command = _commands[_currentCommand - 1];
            }
            catch (ArgumentOutOfRangeException e)
            {
                // В массиве нет больше команд, которые можно отменить
                System.Media.SystemSounds.Beep.Play();
            }

            if (command == null)
            {
                return;
            }

            command.Undo();
            _currentCommand = _currentCommand - 1;

            UpdateView(command);
        }

        /// <summary>
        /// Сброс стека
        /// </summary>
        public void Reset()
        {
            _commands = new List<CommandBase>();
            _currentCommand = 0;
        }

        /// <summary>
        /// Получить документ
        /// </summary>
        /// <returns>Текущий документ</returns>
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
        /// <returns>Настройки линии</returns>
        public LineSettings GetActiveLineSettings()
        {
            return _figureSettingsControl.GetLineSettings();
        }

        /// <summary>
        /// Получить настройки заливки
        /// </summary>
        /// <returns>Настройки заливки</returns>
        public FillSettings GetActiveFillSettings()
        {
            return _figureSettingsControl.GetFillSettings();
        }

        /// <summary>
        /// Получить тип фигуры
        /// </summary>
        /// <returns>Тип фигуры</returns>
        public string GetActiveFigureType()
        {
            return _toolsControl.GetActiveFigureType();
        }

        /// <summary>
        /// Изменение выделенного объекта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PropertyGrid_SelectedObjectsChanged(object sender,
            EventArgs e)
        {
            if ((FigureBase) _propertyGrid.SelectedObject != null)
            {
                _propertyBackUp =
                    new FigureFactory().CopyFigure(
                        (FigureBase) _propertyGrid.SelectedObject);
            }
        }

        /// <summary>
        /// Изменение свойств
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void PropertyGrid_PropertyValueChanged(
            object s, PropertyValueChangedEventArgs e)
        {
            var selectedFigure = (FigureBase) _propertyGrid.SelectedObject;

            if (selectedFigure == null)
            {
                return;
            }

            var newValue = GetDocument().GetFigure(selectedFigure.guid);
            if (newValue == null)
            {
                UpdatePropertyGrid();
                return;
            }

            var newValues = new FigureFactory().CopyFigure(newValue);

            selectedFigure.LineSettings.Color =
                _propertyBackUp.LineSettings.Color;
            selectedFigure.LineSettings.Style =
                _propertyBackUp.LineSettings.Style;
            selectedFigure.LineSettings.Width =
                _propertyBackUp.LineSettings.Width;

            var points = _propertyBackUp.PointsSettings.GetPoints().ToArray();

            for (var i = 0; i < points.Length; i++)
            {
                selectedFigure.PointsSettings.ReplacePoint(i, points[i]);
            }

            if (selectedFigure is FilledFigureBase selectedFilledFigure &&
                _propertyBackUp is FilledFigureBase backUpFilledValues)
            {
                selectedFilledFigure.FillSettings.Color =
                    backUpFilledValues.FillSettings.Color;
            }

            var command = CommandFactory.CreateFiguresChangingCommand(this,
                newValues);
            StoreCommand(command);
            Do();

            _propertyBackUp = newValues;
        }

        /// <summary>
        /// Десериализация
        /// </summary>
        /// <param name="stream">Поток</param>
        public void Deserialize(Stream stream)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            _currentDocument.ClearCanvas();
            _commands.Clear();
            _currentCommand = 0;

            // восстановление
            _commands = (List<CommandBase>)binaryFormatter.Deserialize(stream);
            MakeCommandsOKAgain();
            foreach (var command in _commands)
            {
                Do();
            }

            _lastSavedHash = CalcCurrentHash();
        }

        /// <summary>
        /// Сериализация
        /// </summary>
        /// <param name="stream">Поток</param>
        public void Serialize(Stream stream)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(stream, _commands);

            _lastSavedHash = CalcCurrentHash();
        }

        /// <summary>
        /// Расчет текущего хэша
        /// </summary>
        /// <returns>Хэш</returns>
        private int CalcCurrentHash()
        {
            int hash = -1;
            foreach (var command in _commands)
            {
                hash = hash + command.GetHashCode();
            }

            return hash;
        }

        /// <summary>
        /// Есть ли несохраненные изменения
        /// </summary>
        /// <returns></returns>
        public bool IsFileHaveUnsavedChanges()
        {
            bool isIt = false;
            if (_lastSavedHash != CalcCurrentHash())
            {
                isIt = true;
            }

            return isIt;
        }

        /// <summary>
        /// Починить команды при восстановлении файла
        /// </summary>
        private void MakeCommandsOKAgain()
        {
            foreach (var command in _commands)
            {
                CommandFactory.MakeCommandOKAgain(command, this);
            }
        }
    }
}
