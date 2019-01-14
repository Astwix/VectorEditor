using System;
using System.Drawing;

namespace VectorEditorProject.Core.Commands
{
    /// <summary>
    /// Команда изменения параметров документа
    /// </summary>
    [Serializable]
    public class ChangingDocumentOptionsCommand : CommandBase
    {
        /// <summary>
        /// Control Unit
        /// </summary>
        [field: NonSerialized] public ControlUnit ControlUnit { get; set; }

        /// <summary>
        /// Новый размер канвы
        /// </summary>
        private Size _newSize;

        /// <summary>
        /// Резервный размер канвы
        /// </summary>
        private Size _backUpSize;

        /// <summary>
        /// Новый цвет
        /// </summary>
        private Color _newColor;

        /// <summary>
        /// Резервный цвет
        /// </summary>
        private Color _backUpColor;

        /// <summary>
        /// Новое название
        /// </summary>
        private String _newName;

        /// <summary>
        /// Резервное название
        /// </summary>
        private String _backUpName;

        /// <summary>
        /// Изменение свойств документа
        /// </summary>
        /// <param name="controlUnit">Control ControlUnit</param>
        /// <param name="newOptions">Новые параметры</param>
        public ChangingDocumentOptionsCommand(ControlUnit controlUnit,
            Document newOptions)
        {
            ControlUnit = controlUnit;

            var target = ControlUnit.GetDocument();

            _backUpSize = target.Size;
            _backUpColor = target.Color;
            _backUpName = target.Name;

            _newSize = newOptions.Size;
            _newColor = newOptions.Color;
            _newName = newOptions.Name;
        }

        /// <summary>
        /// Действие
        /// </summary>
        public override void Do()
        {
            var target = ControlUnit.GetDocument();

            target.Size = _newSize;
            target.Color = _newColor;
            target.Name = _newName;
        }

        /// <summary>
        /// Отмена
        /// </summary>
        public override void Undo()
        {
            var target = ControlUnit.GetDocument();

            target.Size = _backUpSize;
            target.Color = _backUpColor;
            target.Name = _backUpName;
        }

        /// <summary>
        /// Получить хэш-код
        /// </summary>
        /// <returns>Хэш</returns>
        public override int GetHashCode()
        {
            return _backUpSize.GetHashCode() + 
                   _backUpColor.GetHashCode() + 
                   _backUpName.GetHashCode() + 
                   _newSize.GetHashCode() + 
                   _newColor.GetHashCode() + 
                   _newName.GetHashCode();
        }
    }
}
