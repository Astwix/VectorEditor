using System;
using System.Drawing;

namespace VectorEditorProject.Core.Commands
{
    [Serializable]
    public class ChangingDocumentOptionsCommand : BaseCommand
    {
        [field: NonSerialized] public ControlUnit ControlUnit { get; set; }

        private Size _newSize;
        private Size _backUpSize;
        private Color _newColor;
        private Color _backUpColor;
        private String _newName;
        private String _backUpName;

        /// <summary>
        /// Изменение свойств документа
        /// </summary>
        /// <param name="controlUnit">Control ControlUnit</param>
        /// <param name="newOptions">Новые параметры</param>
        public ChangingDocumentOptionsCommand(ControlUnit controlUnit, Document newOptions)
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
    }
}
