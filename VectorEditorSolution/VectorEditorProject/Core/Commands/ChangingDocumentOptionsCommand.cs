using System;
using System.Drawing;

namespace VectorEditorProject.Core.Commands
{
    public class ChangingDocumentOptionsCommand : BaseCommand
    {
        private ControlUnit _controlUnit;

        private Size _newSize;
        private Size _backUpSize;
        private Color _newColor;
        private Color _backUpColor;
        private String _newName;
        private String _backUpName;

        /// <summary>
        /// Изменение свойств документа
        /// </summary>
        /// <param name="controlUnit">Control Unit</param>
        /// <param name="newOptions">Новые параметры</param>
        public ChangingDocumentOptionsCommand(ControlUnit controlUnit, Document newOptions)
        {
            _controlUnit = controlUnit;

            var target = _controlUnit.GetDocument();

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
            var target = _controlUnit.GetDocument();

            target.Size = _newSize;
            target.Color = _newColor;
            target.Name = _newName;
        }

        /// <summary>
        /// Отмена
        /// </summary>
        public override void Undo()
        {
            var target = _controlUnit.GetDocument();

            target.Size = _backUpSize;
            target.Color = _backUpColor;
            target.Name = _backUpName;
        }
    }
}
